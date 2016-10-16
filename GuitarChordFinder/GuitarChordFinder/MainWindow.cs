using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GuitarChordFinder
{

    public partial class GuitarChordFinder : Form
    {
        private int root = -1;      //root neboli zakladni ton akordu
        private bool isPainting;      //udava, zda jiz byl ci nebyl vykreslen nejaky diagram - pokud je true, zmeny napr. v ladeni se projevi okamzite
        private List<ChordFormula> knownFormulas = new List<ChordFormula>();
        List<int[]> evaluatedFingerings = new List<int[]>();
        string[] intervalSymbols = new string[12];       //symbolicke znacky intervalu, slouzi pro vypis
        CheckBox[] checkbox = new CheckBox[12];    //pomocne pole pro zjednoduseni prace s checkboxy

        public GuitarChordFinder()
        {
            //inicializace komponent - standardni ladeni, akord C dur
            InitializeComponent();
            checkbox[0] = checkC;
            checkbox[1] = checkCs;
            checkbox[2] = checkD;
            checkbox[3] = checkDs;
            checkbox[4] = checkE;
            checkbox[5] = checkF;
            checkbox[6] = checkFs;
            checkbox[7] = checkG;
            checkbox[8] = checkGs;
            checkbox[9] = checkA;
            checkbox[10] = checkAs;
            checkbox[11] = checkB;
            comboRoot.SelectedIndex = 0;
            groupChordStructure.Enabled = false;
            groupChordNotes.Enabled = false;
            comboThird.SelectedIndex = 3;
            comboFifth.SelectedIndex = 2;
            comboSeventh.SelectedIndex = 0;
            comboNinth.SelectedIndex = 0;
            comboEleventh.SelectedIndex = 0;
            comboThirteenth.SelectedIndex = 0;
            UDTuning1.SelectedIndex = 11 - Fretboard.GetTuning(0);
            UDTuning2.SelectedIndex = 11 - Fretboard.GetTuning(1);
            UDTuning3.SelectedIndex = 11 - Fretboard.GetTuning(2);
            UDTuning4.SelectedIndex = 11 - Fretboard.GetTuning(3);
            UDTuning5.SelectedIndex = 11 - Fretboard.GetTuning(4);
            UDTuning6.SelectedIndex = 11 - Fretboard.GetTuning(5);
            
            
            List<string> knownFormulasNames = new List<string>();
            
            //nacteni znamych schemat ze souboru
            StreamReader formulasReader = new StreamReader("schemata.in");
            while (!formulasReader.EndOfStream)
            {
                string row = formulasReader.ReadLine();
                string[] s_items = row.Split(';');
                int[] items = new int[s_items.Length];
                for (int i = 1; i < s_items.Length; i++)
                {
                    items[i] = Int16.Parse(s_items[i]);
                }

                knownFormulas.Add(new ChordFormula(s_items[0], items[1], items[2], items[3], items[4], items[5], items[6]));
                knownFormulasNames.Add(s_items[0]);
            }
            formulasReader.Close();

            comboChordName.DataSource = knownFormulasNames;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {   //spoustec cele masinerie - generovani prstokladu, vykreslovani atd.
 
            if (root > -1)
            {
                //nastaveni ladeni podle uzivatelem vybranych hodnot, popr. i "umisteni kapodastru"
                Fretboard.SetTuning(0, 11 - (UDTuning1.SelectedIndex % 12) + (int)capoLocation.Value);
                Fretboard.SetTuning(1, 11 - (UDTuning2.SelectedIndex % 12) + (int)capoLocation.Value);
                Fretboard.SetTuning(2, 11 - (UDTuning3.SelectedIndex % 12) + (int)capoLocation.Value);
                Fretboard.SetTuning(3, 11 - (UDTuning4.SelectedIndex % 12) + (int)capoLocation.Value);
                Fretboard.SetTuning(4, 11 - (UDTuning5.SelectedIndex % 12) + (int)capoLocation.Value);
                Fretboard.SetTuning(5, 11 - (UDTuning6.SelectedIndex % 12) + (int)capoLocation.Value);

                //vytvoreni instance tridy Akord
                Chord currentChord = new Chord
                    (
                    new List<int>(), 
                    root, 
                    comboThird.SelectedIndex, 
                    comboFifth.SelectedIndex, 
                    comboSeventh.SelectedIndex, 
                    comboNinth.SelectedIndex, 
                    comboEleventh.SelectedIndex, 
                    comboThirteenth.SelectedIndex, 
                    comboBass.SelectedIndex, 
                    checkOmitRoot.Checked
                    );
               
                //pridani tonu pouzitych v akordu do instance aktualniAkord
                for (int i = 0; i < 12; i++)
                {
                    if (checkbox[i].Checked)
                        currentChord.Notes.Add(i);
                }
                
                //vygenerovani hratelnych prstokladu
                List<int[]> feasibleFingerings = currentChord.findFingerings();
                
                //ohodnoceni a setrideni nalezenych prstokladu
                evaluatedFingerings = currentChord.evaluateFingerings(ref feasibleFingerings);

                //vygenerovani znacek pro vypis
                intervalSymbols = currentChord.generateSymbols();
                
                outputFingerings();
            }
        }

        private void outputFingerings()
        {
            //vypise nalezene prstoklady do ListBoxu
            
            List<string> items = new List<string>();
            for (int i = 0; (i < evaluatedFingerings.Count); i++)
            {
                StringBuilder item = new StringBuilder();
                int[] currentFingering = evaluatedFingerings[i];
                for (int j = 0; j < Fretboard.StringsCount; j++)
                {
                    if (currentFingering[j] == -1)
                        item.Append(" X ");
                    else
                        if (currentFingering[j] >= 10)
                        {
                            item.Append(currentFingering[j]);
                            item.Append(" ");
                        }
                        else
                        {
                            item.Append(" ");
                            item.Append(currentFingering[j]);
                            item.Append(" ");
                        }
                        

                    if (j < Fretboard.StringsCount - 1)
                        item.Append("|");  
                }
                items.Add(item.ToString());
            }
            listAlternativeFingerings.DataSource = items;
            
            //vykresli prvni diagram
            if (evaluatedFingerings.Count > 0)
            {
                repaintDiagram(evaluatedFingerings[0], ref intervalSymbols);
            }
        }

        private ChordFormula tryBuildFormula()
        {
            //funkce se pokusi sestavit ze zadanych tonu akord a dosadit patricne hodnoty do sekce Struktura

            ChordFormula formulaUnderConstruction = new ChordFormula("", 0, 0, 0, 0, 0, 0);
            int found = 0;

            //snazime se najit a priradit prislusne harmonicke funkci konkretni ton. Zkousime vsechny mozne modulace intervalu (napr. tercie
            //muze byt velka, mala, zmensena nebo zvetsena).

            //tercie
            if (checkbox[(root + 4) % 12].Checked) { formulaUnderConstruction.Third = 3; found++; }
            else
            {
                if (checkbox[(root + 3) % 12].Checked) { formulaUnderConstruction.Third = 2; found++; }
                else
                {
                    if (checkbox[(root + 2) % 12].Checked) { formulaUnderConstruction.Third = 1; found++; }
                    else
                    {
                        if (checkbox[(root + 5) % 12].Checked) { formulaUnderConstruction.Third = 4; found++; }
                    }
                }
            }
            //kvinta
            if (checkbox[(root + 7) % 12].Checked) { formulaUnderConstruction.Fifth = 2; found++; }
            else
            {
                if (checkbox[(root + 6) % 12].Checked) { formulaUnderConstruction.Fifth = 1; found++; }
                else
                {
                    if (checkbox[(root + 8) % 12].Checked) { formulaUnderConstruction.Fifth = 3; found++; }
                }
            }
            //septima
            if (checkbox[(root + 10) % 12].Checked) { formulaUnderConstruction.Seventh = 2; found++; }
            else
            {
                if (checkbox[(root + 11) % 12].Checked) { formulaUnderConstruction.Seventh = 3; found++; }
                else
                {
                    if (checkbox[(root + 9) % 12].Checked) { formulaUnderConstruction.Seventh = 1; found++; }
                }
            }
            //nona
            if ((checkbox[(root + 2) % 12].Checked) && (formulaUnderConstruction.Third > 1)) { formulaUnderConstruction.Ninth = 2; found++; }
            else
            {
                if (checkbox[(root + 1) % 12].Checked) { formulaUnderConstruction.Ninth = 1; found++; }
            }
            //undecima
            if ((checkbox[(root + 5) % 12].Checked) && (formulaUnderConstruction.Third < 4)) { formulaUnderConstruction.Eleventh = 1; found++; }
            else
            {
                if ((checkbox[(root + 6) % 12].Checked) && (formulaUnderConstruction.Fifth > 1)) { formulaUnderConstruction.Eleventh = 1; found++; }
            }
            //tercdecima
            if ((checkbox[(root + 9) % 12].Checked) && (formulaUnderConstruction.Seventh > 1)) { formulaUnderConstruction.Thirteenth = 2; found++; }
            else
            {
                if ((checkbox[(root + 8) % 12].Checked) && (formulaUnderConstruction.Fifth < 3)) { formulaUnderConstruction.Thirteenth = 1; found++; }
            }
            //pozn. poradi testu na intervaly je DULEZITE! Napr. interval 2 muze znamenat zmensenou tercii, ale i cistou nonu; musime testovat tercii driv,
            //protoze v akordove skladbe ma prednost. Pouze v pripade, ze jsme jiz nasli cistou tercii (malou - 3 nebo velkou - 4) muze byt interval 2 
            //interpretovan jako nona.

            int checkedCount = 0;
            for (int i = 0; i < 12; i++)
            {
                if (checkbox[i].Checked) { checkedCount++; }
            }
            //kontrola, zda pocet tonu zadanych pomoci checkboxu je stejny, jako pocet nalezenych harmonickych funkci
            if (checkedCount > found + 1) //+1 znamena root (ten se v prubehu funkce nezapocetl)
            {
                return null;  //nepodarilo se najit schema zahrnujici vsechny tony
            }
            return formulaUnderConstruction;
        }

        private void updateCheckboxes()
        {
            //funkce prepise checkboxy v sekci 'Tony v akordu' podle hodnot v sekci 'Struktura akordu'

            for (int i = 0; i < checkbox.Length; i++) 
                checkbox[i].Checked = false;    //vynulovani

            checkbox[root].Checked = true;
            if (comboThird.SelectedIndex > 0)
            { checkbox[(root + comboThird.SelectedIndex + 1) % 12].Checked = true; }
            if (comboFifth.SelectedIndex > 0)
            { checkbox[(root + comboFifth.SelectedIndex + 5) % 12].Checked = true; }
            if (comboSeventh.SelectedIndex > 0)
            { checkbox[(root + comboSeventh.SelectedIndex + 8) % 12].Checked = true; }
            if (comboNinth.SelectedIndex > 0)
            { checkbox[(root + comboNinth.SelectedIndex) % 12].Checked = true; }
            if (comboEleventh.SelectedIndex > 0)
            { checkbox[(root + comboEleventh.SelectedIndex + 4) % 12].Checked = true; }
            if (comboThirteenth.SelectedIndex > 0)
            { checkbox[(root + comboThirteenth.SelectedIndex + 7) % 12].Checked = true; }
        }

        private bool isKnownFormula(ChordFormula schema)
        {
            //funkce porovna parametry v sekci "struktura akordu" s konkretnim schematem
            if (comboThird.SelectedIndex != schema.Third) { return false; }
            if (comboFifth.SelectedIndex != schema.Fifth) { return false; }
            if (comboSeventh.SelectedIndex != schema.Seventh) { return false; }
            if (comboNinth.SelectedIndex != schema.Ninth) { return false; }
            if (comboEleventh.SelectedIndex != schema.Eleventh) { return false; }
            if (comboThirteenth.SelectedIndex != schema.Thirteenth) { return false; }

            return true;
        }

        private void repaintDiagram(int[] fingering, ref string[] intervalSymbols)
        {
            isPainting = true;
            Graphics grafika = picBoxFretboard.CreateGraphics();

            //nakreslime prazdne pozadi
            grafika.DrawImage(Image.FromFile("background.png"), 0, 0, 200, 300);
           
            int lowestDisplayedFret = 0;
            
            //diagram obsahuje pouze 5 prazcu, pro vyse umistene prstoklady se zobrazeni posouva
            if (fingering.Max() > 5)
            {
                List<int> nonZeroValues = new List<int>();

                //prazdne ci zatlumene struny nas nezajimaji
                for (int i = 0; i < fingering.Length; i++)
                {
                    if (fingering[i] > 0)
                    { nonZeroValues.Add(fingering[i]); }
                }

                //misto prvniho prazce zacina diagram na nejnizsim prazci v prstokladu
                lowestDisplayedFret = nonZeroValues.Min() - 1;
            }
			lblFret.Text = "Fret " + (lowestDisplayedFret + 1);

			for (int i = 0; i < fingering.Length; i++)
            {
                //vykresleni tecek a krizku na patricna mista
                if (fingering[i] == 0) //prazdna struna
                {
                    grafika.DrawImage(Image.FromFile("emptydot.bmp"), 34 * i, 10, 30, 30);
                }
                if (fingering[i] == -1) //zatlumena struna
                {
                    grafika.DrawImage(Image.FromFile("cross.bmp"), 34 * i, 10, 30, 30);
                }
                if (fingering[i] > 0)  //struna drzena na nejakem prazci
                {
                    grafika.DrawImage(Image.FromFile("dot.bmp"), 34 * i, 10 + 50 * (fingering[i] - lowestDisplayedFret), 30, 30);
                }
            }

            //vykresleni bare (bare = skupina not, ktere jsou v prstokladu na stejnem prazci a lze je tedy hrat jednim prstem polozenym pres vice strun (vetsinou ukazovak)
            if (fingering[Fretboard.StringsCount - 1] > 0) //posledni struna neni prazdna, potencialne existuje bare
            {
                int barreFret = fingering[Fretboard.StringsCount - 1];
                List<int> barreStrings = new List<int>();
                barreStrings.Add(Fretboard.StringsCount - 1);
                bool endOfBarre = false;
                try
                {
                    for (int i = Fretboard.StringsCount - 2; i >= 0; i--)  //postupujeme od vyssich strun k basovym (bare muze byt i castecne, napr pouze pres ctyri struny
                    {                                                       
                        if (endOfBarre)
                        {
                            if (fingering[i] > 0)
                            {
                                //bare je ukonceno, dalsi pozice uz musi byt pouze niz na hmatniku (jinak se to neda chytnout)
                                throw new Exception("Barre does not exist.");
                            }
                        }
                        switch (fingering[i].CompareTo(barreFret))
                        {
                            case 1:
                                {
                                    //pozice na aktualni strune je vys nez drzene bare - OK, lze chytnout zbylymi prsty
                                    break;
                                }
                            case 0:
                                {
                                    //pozice je na stejnem prazci jako budovane bare - pridame do bare
                                    barreStrings.Add(i);
                                    break;
                                }
                            case -1:
                                {
                                    //pozice "pod" bare, pokud je to prazdna ci zatlumena nota, bare ukoncime
                                    if (fingering[i] <= 0)
                                    {
                                        endOfBarre = true;
                                    }
                                    //jinak zacneme budovat nove bare na teto nizsi pozici
                                    else
                                    {
                                        barreFret = fingering[i];
                                        barreStrings.Clear();
                                        barreStrings.Add(i);
                                    }
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
                catch (Exception)
                {
                    barreStrings.Clear();
                }
                
                if (barreStrings.Count > 1) //bare existuje (resp. za bare jej povazujeme, pokud obsahuje alespon dve struny), vykreslime
                {
                    grafika.DrawLine(new Pen(Color.Black, 8), 32 * barreStrings.Min() + 15 , 50 * (barreFret - lowestDisplayedFret) + 25 , 32 * barreStrings.Max() + 15, 50 * (barreFret - lowestDisplayedFret) + 25);
                }
            }

            //vypsani popisku pod diagramem (na jednom radku konkretni tony, na druhem jejich harmonicke funkce v aktualnim akordu)
            string[] noteLabels = new string[Fretboard.StringsCount];
            string[] intervalLabels = new string[Fretboard.StringsCount];
            for (int i = 0; i < fingering.Length; i++)
            {
                if (fingering[i] == -1)
                {
                    noteLabels[i] = "";
                    intervalLabels[i] = "";
                }
                else
                {
                    noteLabels[i] = Note.getName((fingering[i] + Fretboard.GetTuning(i)) % 12);
                    intervalLabels[i] = intervalSymbols[(fingering[i] + Fretboard.GetTuning(i)) % 12];
                }
            }
            labelString1.Text = noteLabels[0];
            labelString2.Text = noteLabels[1];
            labelString3.Text = noteLabels[2];
            labelString4.Text = noteLabels[3];
            labelString5.Text = noteLabels[4];
            labelString6.Text = noteLabels[5];
            labelInterval1.Text = intervalLabels[0];
            labelInterval2.Text = intervalLabels[1];
            labelInterval3.Text = intervalLabels[2];
            labelInterval4.Text = intervalLabels[3];
            labelInterval5.Text = intervalLabels[4];
            labelInterval6.Text = intervalLabels[5];
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            listAlternativeFingerings.SelectedIndex++;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            listAlternativeFingerings.SelectedIndex--;
        }

        //prepinani mezi moznostmi zadani akordu
        private void radioStructure_CheckedChanged(object sender, EventArgs e)
        {
            groupChordStructure.Enabled = true;
            groupChordNotes.Enabled = false;
            groupChordName.Enabled = false;
            comboRoot.Enabled = true;
        }

        private void radioName_CheckedChanged(object sender, EventArgs e)
        {
            groupChordNotes.Enabled = false;
            groupChordStructure.Enabled = false;
            groupChordName.Enabled = true;
            comboRoot.Enabled = true;
            comboChordName_SelectedIndexChanged(radioName, e);
        }

        private void radioChordNotes_CheckedChanged(object sender, EventArgs e)
        {
            groupChordStructure.Enabled = false;
            groupChordNotes.Enabled = true;
            groupChordName.Enabled = false;
            comboRoot.Enabled = false;
        }

        //zmena zakladniho tonu - pokud se nezadavalo vyctem tonu, je nutno prepsat (transponovat) checkboxy
        private void comboRoot_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBass.SelectedIndex = comboRoot.SelectedIndex;
            root = comboRoot.SelectedIndex;
            if (radioChordNotes.Checked == false)
                { updateCheckboxes(); }
        }

        //manualni zmena nazvu akordu - prepsani informaci v sekci ' struktura' (coz nasledne vede k prepsani checkboxu)
        private void comboChordName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboChordName.SelectedIndex > -1) && (radioName.Checked))
            {
                ChordFormula current = knownFormulas[comboChordName.SelectedIndex];
                comboThird.SelectedIndex = current.Third;
                comboFifth.SelectedIndex = current.Fifth;
                comboSeventh.SelectedIndex = current.Seventh;
                comboNinth.SelectedIndex = current.Ninth;
                comboEleventh.SelectedIndex = current.Eleventh;
                comboThirteenth.SelectedIndex = current.Thirteenth;
            }
        }

        private void comboStruktura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioChordNotes.Checked == false)
            {
                //pokud zmena nebyla inicializovana zmenou v checkboxech, prepiseme je
                updateCheckboxes();
            }
            if (radioName.Checked == false)
            {
                //pokud zmena nebyla inicializovana zmenou nazvu, zkusime najit nazev odpovidajici aktualni strukture
                for (int i = 0; i < knownFormulas.Count; i++)
                {
                    if (isKnownFormula(knownFormulas[i]))
                    {
                        if (comboChordName.SelectedIndex != i)
                        { comboChordName.SelectedIndex = i; }
                        break;
                    }
                    else
                    { comboChordName.SelectedIndex = -1; }
                }
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            //prepsani checkboxu mohla volat i jina metoda, veskere dalsi akce se vsak provadi pouze pokud byly prepsany skutecne, "manualne"
            if (radioChordNotes.Checked)
            {
                if ((comboRoot.SelectedIndex == -1) || (checkbox[root].Checked == false))
                {
                    //pokud ton s funkci zakladniho tonu (rootu) je odznacen, vybere se novy - nejnizsi zaskrtnuty
                    comboRoot.SelectedIndex = -1;
                    for (int i = 0; i < 12; i++)
                    {
                        if (checkbox[i].Checked)
                        {
                            comboRoot.SelectedIndex = i; 
                            break;
                        }
                    }
                }
              

                //pokusi se sestavit ze zadanych tonu schema a vyplnit sekci "Struktura akordu"
                ChordFormula current = tryBuildFormula();
                if (current == null)
                {
                    //pokud se nepovedlo, vynulujeme udaje v sekci 'Struktura' (tony zrejme netvori korektni akord)
                    current = new ChordFormula("", 0, 0, 0, 0, 0, 0);
                }
                comboThird.SelectedIndex = current.Third;
                comboFifth.SelectedIndex = current.Fifth;
                comboSeventh.SelectedIndex = current.Seventh;
                comboNinth.SelectedIndex = current.Ninth;
                comboEleventh.SelectedIndex = current.Eleventh;
                comboThirteenth.SelectedIndex = current.Thirteenth;
            }
        }

        private void UDTuning_SelectedItemChanged(object sender, EventArgs e)
        {
            DomainUpDown upDown = (DomainUpDown)sender;
            
            //zajisteni cyklicnosti UpDown boxu
            if (upDown.SelectedIndex == 0)
                upDown.SelectedIndex = 12;
            if (upDown.SelectedIndex == 13)
                upDown.SelectedIndex = 1;

            if (isPainting)
            {
                //zmena ladeni vyvola okamzite prepsani diagramu -> "klikne" na  tlacitko 'Generuj'
                btnFind_Click(upDown, new EventArgs());
            }
        }

        private void btnDefaultTuning_Click(object sender, EventArgs e)
        {
            //zmeni ladeni na standardni (tj. EADGHe)
            UDTuning1.SelectedIndex = 7;
            UDTuning2.SelectedIndex = 2;
            UDTuning3.SelectedIndex = 9;
            UDTuning4.SelectedIndex = 4;
            UDTuning5.SelectedIndex = 0;
            UDTuning6.SelectedIndex = 7;
        }

        private void listOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            //prochazeni seznamem vygenerovanych prstokladu -> prekresleni diagramu + osetreni funkcnosti tlacitek pro listovani seznamem
            repaintDiagram(evaluatedFingerings[listAlternativeFingerings.SelectedIndex], ref intervalSymbols);

            if (listAlternativeFingerings.SelectedIndex == evaluatedFingerings.Count - 1)
                btnNext.Enabled = false;
            else
                btnNext.Enabled = true;

            if (listAlternativeFingerings.SelectedIndex == 0)
                btnPrevious.Enabled = false;
            else
                btnPrevious.Enabled = true;
        }

        private void capoUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (isPainting)
            {
                //"umisteni kapodastru" vyvola okamzite prepsani diagramu -> "klikne" na  tlacitko 'Generuj'
                btnFind_Click(sender, new EventArgs());
            }
        }
    }
    


    public static class Note
    {
        //pomocna trida obsahujici nazvy tonu
        private static string[] NOTE = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "B", "H" };

        public static string getName(int index)
        {
            return NOTE[index];
        }
    }

    public static class Fretboard
        //staticka trida implementujici abstraktni konstrukci Hmatnik a funkce s nim spojene
    {
        private const int MAX_FRET = 15;
        private const int STRINGS_COUNT = 6;
        public static int StringsCount
        {
            get { return STRINGS_COUNT; }
        }
        private static int[] tuning = new int[] { 4, 9, 2, 7, 11, 4 }; //default je standardni ladeni EADGHe
        public static int GetTuning(int index)
        {
            return tuning[index];
        }
        public static void SetTuning(int index, int value)
        {
            tuning[index] = value;
        }

        public static List<List<int>> findNotesOnFretboard(List<int> notes)
        {
            //funkce dostane jako parametr seznam tonu v aktualnim akordu a vrati pozice tonu na 
            //hmatniku v aktualnim ladeni ve formatu sestice Listu s pozicemi na kazde strune (v pripade sesti strun)

            List<List<int>> notesOnFretboard = new List<List<int>>();

            for (int string_index = 0; string_index < STRINGS_COUNT; string_index++)
            {
                notesOnFretboard.Add(new List<int>());
                for (int fret = 0; fret < MAX_FRET; fret++)
                {
                    if (notes.Contains((tuning[string_index] + fret) % 12))
                        notesOnFretboard[string_index].Add(fret);
                }
            }

            //pro prvni 2 struny je povoleno zatlumeni (-1) explicitne, u ostatnich jen pokud neexistuje hratelna pozice (osetreno dale)
            notesOnFretboard[0].Add(-1);
            notesOnFretboard[1].Add(-1);

            return notesOnFretboard;
        }
    }


    public class ChordFormula
    {
        //pomocna konstrukce implementujici schema akordu (ve smyslu intervalove sablony)
        private string name;
        public string Name { get { return name; } }

        private int third, fifth, seventh, ninth, eleventh, thirteenth;
        public int Third
        {
            get { return third; }
            set { third = value; }
        }
        public int Fifth
        {
            get { return fifth; }
            set { fifth = value; }
        }
        public int Seventh
        {
            get { return seventh; }
            set { seventh = value; }
        }
        public int Ninth
        {
            get { return ninth; }
            set { ninth = value; }
        }
        public int Eleventh
        {
            get { return eleventh; }
            set { eleventh = value; }
        }
        public int Thirteenth
        {
            get { return thirteenth; }
            set { thirteenth = value; }
        }


        public ChordFormula(string name, int third, int fifth, int seventh, int ninth, int eleventh, int thirteenth)
        {
            this.name = name;
            this.third = third;
            this.fifth = fifth;
            this.seventh = seventh;
            this.ninth = ninth;
            this.eleventh = eleventh;
            this.thirteenth = thirteenth;
        }
    }


    public class Fingering
    {
        //krome sestice tonu obsazenych v prstokladu obsahuje navic promennou 'penalizace' - tedy udrzuje hodnoceni daneho prstokladu
        private int[] fretsInFingering;
        public int[] FretsInFignering
        {
            get { return fretsInFingering; }
        }
        private int penalty;
        public int Penalty
        {
            get { return penalty; }
            set { penalty = value; }
        }

        public Fingering(int[] fretsInFingering, int penalty)
        {
            this.fretsInFingering = fretsInFingering;
            this.penalty = penalty;
        }
    }


    public class Chord
    {
        private const int MAX_SPAN = 3;

        private List<int> notes;
        public List<int> Notes
        {
            get { return notes; }
            set { notes = value; }
        }
        private int third, fifth, seventh, ninth, eleventh, thirteenth;
        public int Third
        {
            get { return third; }
            set { third = value; }
        }
        public int Fifth
        {
            get { return fifth; }
            set { fifth = value; }
        }
        public int Seventh
        {
            get { return seventh; }
            set { seventh = value; }
        }
        public int Ninth
        {
            get { return ninth; }
            set { ninth = value; }
        }
        public int Eleventh
        {
            get { return eleventh; }
            set { eleventh = value; }
        }
        public int Thirteenth
        {
            get { return thirteenth; }
            set { thirteenth = value; }
        }
        public int Bass
        {
            get { return bass; }
            set { bass = value; }
        }
        private int root, bass;
        private bool rootOmissionAllowed = false;

        public Chord(List<int> notes, int root, int third, int fifth, int seventh, int ninth, int eleventh, int thirteenth, int bass, bool rootOmissionAllowed)
        {
            this.root = root;
            this.third = third;
            this.fifth = fifth;
            this.seventh = seventh;
            this.ninth = ninth;
            this.eleventh = eleventh;
            this.thirteenth = thirteenth;
            this.notes = notes;
            this.bass = bass;
            this.rootOmissionAllowed = rootOmissionAllowed;
        }

        public string[] generateSymbols()
        {
            //pro kazdy ton od C po H vygeneruje "znacku" - zkratku pro jeho harmonickou funkci 
            //v akordu, popr prazdny retezec pro tony, jez v akordu nejsou

            string[] symbols = new string[12];

            symbols[this.root] = "R";

            //Obcas mohou tony kolidovat - v akordu muze byt napr. velka nona a zmensena tercie, coz je 
            //ve skutecnosti tentyz ton. V takovem pripade znacka pro tercii prepise znacku pro nonu
            //(proto se harmonicke funkce vyhodnocuji v tomto poradi).

            switch (this.Ninth)
            {
                case 0: break;
                case 1: symbols[(this.root + 1) % 12] = "9b";
                    break;
                case 2: symbols[(this.root + 2) % 12] = "9";
                    break;
                default:
                    break;
            }
            switch (this.Eleventh)
            {
                case 0: break;
                case 1: symbols[(this.root + 5) % 12] = "11";
                    break;
                case 2: symbols[(this.root + 6) % 12] = "11#";
                    break;
                default:
                    break;
            }
            switch (this.Thirteenth)
            {
                case 0: break;
                case 1: symbols[(this.root + 8) % 12] = "13b";
                    break;
                case 2: symbols[(this.root + 9) % 12] = "13";
                    break;
                default:
                    break;
            }
            switch (this.Third)
            {
                case 0: break;
                case 1: symbols[(this.root + 2) % 12] = "2";
                    break;
                case 2: symbols[(this.root + 3) % 12] = "m3";
                    break;
                case 3: symbols[(this.root + 4) % 12] = "3";
                    break;
                case 4: symbols[(this.root + 5) % 12] = "4";
                    break;
                default:
                    break;
            }
            switch (this.Fifth)
            {
                case 0: break;
                case 1: symbols[(this.root + 6) % 12] = "5b";
                    break;
                case 2: symbols[(this.root + 7) % 12] = "5";
                    break;
                case 3: symbols[(this.root + 8) % 12] = "5#";
                    break;
                default:
                    break;
            }
            switch (this.Seventh)
            {
                case 0: break;
                case 1: symbols[(this.root + 9) % 12] = "6";
                    break;
                case 2: symbols[(this.root + 10) % 12] = "7";
                    break;
                case 3: symbols[(this.root + 11) % 12] = "M7";
                    break;
                default:
                    break;
            }
            if (symbols[this.Bass] == null)
            {
                //pokud je bas v tonu obsazen, nijak se neoznacuje, v opacnem pripade je mu pridelena vlastni znacka
                symbols[this.Bass] = "(B)";
            }

            return symbols;
        }

        public List<int[]> findFingerings()
        {
            //budeme potrebovat pozice tonu na hmatniku, navic vsak take pozice basoveho tonu na hmatniku - potrebujeme ho hledat zvlast

            List<List<int>> notesOnFretboard = Fretboard.findNotesOnFretboard(this.Notes);

            //funkce NajdiTonyNaHmatniku bere jako argument List<int>, nemuzu predat pouze int (this.Bas), proto si pomuzeme jednoprvkovym Listem
            List<int> basses = new List<int>() { this.Bass };

            List<List<int>> bassesOnFretboard = Fretboard.findNotesOnFretboard(basses);

            //inicializace promennych, ktere se budou rekurzivne predavat
            int[] currentFingering = new int[Fretboard.StringsCount];
            List<int[]> fingerings = new List<int[]>();
            int bassOnString = 0;

            //zavolani rekurzivni funkce s referencne predavanymi parametry
            nextString(ref notesOnFretboard, ref bassesOnFretboard, ref bassOnString, ref fingerings, 0, ref currentFingering);
            return fingerings;
        }

        private void nextString(ref List<List<int>> notesOnFretboard, ref List<List<int>> bassesOnFretboard, ref int bassOnString, ref List<int[]> fingerings, int currentString, ref int[] currentFingering)
        {
            List<List<int>> onFretboard = notesOnFretboard;

            //funkce nejprve hleda pouze bas a az po jeho uspesnem nalezeni "prepne" na hledani ostatnich tonu
            if (bassOnString == currentString)
                onFretboard = bassesOnFretboard;

            bool found = false;
            for (int i = 0; i < onFretboard[currentString].Count() + 1; i++)
            {
                // jeden cyklus navic pro pripad, ze nebyla nalezena vhodna pozice na aktualni strune - tj. 
                // ve vhodne vzdalenosti - v takovem pripade je povoleno zatlumeni struny (pozn.: pro prvni dve struny
                //je zatlumeni povoleno defaultne)
                if (i == onFretboard[currentString].Count())
                {
                    if (found == false)
                    {
                        currentFingering[currentString] = -1;
                        if (bassOnString == currentString)
                        {
                            //pokud se hledal bas a nenasel se, jeho hledani se presouva na dalsi strunu
                            bassOnString = currentString + 1;
                        }
                    }
                    else
                    { break; }
                }
                else
                {
                    //pridame do prstokladu na aktualni pozici vybrany ton
                    currentFingering[currentString] = onFretboard[currentString][i];

                    if (currentFingering[currentString] == -1)
                    {
                        //nasel se vhodny ton, ale je to -1 tzn. zatlumena nota - hledani basu se presouva o strunu vys
                        //toto nastane pouze u prvnich dvou strun, kde je zatlumeni povoleno explicitne, u ostatnich jen
                        //v pripade, ktery je osetren o par radek vyse
                        if (bassOnString == currentString)
                        {
                        bassOnString = currentString + 1;
                        }
                    }
                }

                if (isFeasible(currentFingering, currentString))
                // prorezavani stromu - v prohledavani vetve se pokracuje
                //jen tehdy, pokud akord stale jeste dava smysl
                {
                    found = true;
                    if (currentString < Fretboard.StringsCount - 1)
                    {
                        //rekurzivni volani funkce pro dalsi strunu
                        nextString(ref notesOnFretboard, ref bassesOnFretboard, ref bassOnString, ref fingerings, currentString + 1, ref currentFingering);
                    }
                    else
                    //posledni struna, nasli jsme smysluplny prstoklad
                    {
                        //test na obsazeni vsech tonu akordu
                        if (containsAllNecessaryNotes(currentFingering))
                        {
                            //pridani tonu do seznamu prstokladu
                            int[] fingering_copy = new int[Fretboard.StringsCount]; //nemohu pridat referencne predavanou prommenou, musim vytvorit kopii
                            for (int j = 0; j < Fretboard.StringsCount; j++)
                                { fingering_copy[j] = currentFingering[j]; }
                            
                            fingerings.Add(fingering_copy);
                        }
                    }
                }
            }
        }

        private bool isFeasible(int[] fingering, int currentString)
        {
            //funkce vyhodnoti smysluplnost (castecneho) akordu
            int[] toCompare = new int[currentString + 1];
            if (currentString + 1 == fingering.Length)
            { 
                toCompare = fingering; 
            }
            else
            {
                for (int i = 0; i <= currentString; i++)
                {
                    //vyber relevantnich tonu z castecneho akordu
                    toCompare[i] = fingering[i];   
                }
            }


            //podminky (zatim jen jedna, moznost rozsireni - napady: akord ma obsahovat jeste ctyri dalsi ruzne tony, zbyvaji uz vsak jen tri struny)
            if (maxSpan(toCompare) > MAX_SPAN) { return false; }

            return true;
        }

        private int maxSpan(int[] notes)
        {
            //Funkce vraci meximalni vzdalenost tonu na hmatniku, tj. maximalni pocet prazcu, 
            //pres ktere by bylo treba roztahnout prsty.
            List<int> nonzeroValues = new List<int>();
            for (int i = 0; i < notes.Length; i++)
            {
                //prazdne a zatlumene struny nas nezajimaji
                if (notes[i] > 0)
                { nonzeroValues.Add(notes[i]); }
            }
            try
            { 
                return nonzeroValues.Max() - nonzeroValues.Min(); 
            }
            catch (Exception)
            {
                return 0;
                // vyjimka pro osetreni prazdneho pole BezNul - tj. v akordu jsou same prazdne a zatlumene struny
            }
        }

        private bool containsAllNecessaryNotes(int[] fingering)
        {
            //osetri kompletni prstoklad pred vlozenim do seznamu - zkouma tonovou kompletnost

            List<int> notesInFingering = new List<int>();
            for (int i = 0; i < Fretboard.StringsCount; i++)
            {
                if ((fingering[i] > -1) && (notesInFingering.Contains((Fretboard.GetTuning(i) + fingering[i]) % 12) == false))
                { notesInFingering.Add((Fretboard.GetTuning(i) + fingering[i]) % 12); }
            }

            Chord currentChord = this;

            //osetreni pripadu, kdy je v akordu vice tonu nez je pocet strun (napr. tercdecimove akordy obsahuji v plnem tvaru 7 tonu)
            if (currentChord.Notes.Count() >= Fretboard.StringsCount)
            {
                currentChord.omitSuitableNotes();
            }

            for (int i = 0; i < currentChord.Notes.Count(); i++)
            {
                if (notesInFingering.Contains(currentChord.Notes[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void omitSuitableNotes()
        {
            //u "velkych" akordu povolujeme vypusteni nekterych tonu, avsak podle urcitych pravidel

            int omitted = 0;

            //uzivatelsky nastavena moznost vynechani rootu - ale jen pokud akord neni bez kvinty
            if ((rootOmissionAllowed) && (this.Fifth > 0))
            {
                this.Notes.Remove(this.root);
                omitted++;
            }

            //cistou kvintu muzu vynechat kdykoliv (pokud jsem jiz nevynechal root)
            if ((this.Fifth == 2) && (this.Notes.Contains(this.root)))
            {
                this.Notes.Remove((this.root + 7) % 12);
                omitted++;
            }

            //cistou undecimu v 13 muzu vynechat
            if ((this.Thirteenth > 0) && (this.Eleventh == 1))
            {
                this.Notes.Remove((this.root + 5) % 12);
                omitted++;
            }

            //cistou devitku v 11 muzu vynechat
            if ((this.Eleventh > 0) && (this.Ninth == 2))
            {
                this.Notes.Remove((this.root + 2) % 12);
                omitted++;
            }
            //cistou devitku v 13 muzu vynechat
            if ((this.Thirteenth > 0) && (this.Ninth == 2))
            {
                this.Notes.Remove((this.root + 2) % 12);
                omitted++;
            }

        }

        public List<int[]> evaluateFingerings(ref List<int[]> feasibleFingerings)
        {
            //kazdy prstoklad ohodnoti podle nastavenych kriterii a nasledne je seradi
            List<Fingering> evaluatedFingerings = new List<Fingering>();
            
            //uprava ratingu dle kriterii (pozn. rating = trestne body, cim vyssi tim hur)
            foreach (var fingering in feasibleFingerings)
            {
                int penalty = 0;

                //KRITERIA
                //***********************************

                //pozice na hmatniku
                penalty += fingering.Max() * 10;

                //pocet zatlumenych not
                for (int i = 0; i < fingering.Length; i++)
                    if (fingering[i] == -1)
                        penalty++;

                //pocet vynechanych not
                List<int> containedInFingering = new List<int>();
                for (int i = 0; i < Fretboard.StringsCount; i++)
                {
                    if ((containedInFingering.Contains((fingering[i] + Fretboard.GetTuning(i)) % 12) == false) && (fingering[i] > -1))
                    {
                        containedInFingering.Add((fingering[i] + Fretboard.GetTuning(i)) % 12);
                    }
                }
                penalty += (this.Notes.Count - containedInFingering.Count)*100; //silne kriterium

                evaluatedFingerings.Add(new Fingering(fingering, penalty));
            }

            //setridi prstoklady podle ratingu
            evaluatedFingerings.Sort(new Comparison<Fingering>(CompareFingerings));
            List<int[]> sortedFingerings = new List<int[]>();
            foreach (var item in evaluatedFingerings)
                sortedFingerings.Add(item.FretsInFignering);
            return sortedFingerings;
        }

        static int CompareFingerings(Fingering a, Fingering b)
        {
            return a.Penalty.CompareTo(b.Penalty);
        }
    }
}
