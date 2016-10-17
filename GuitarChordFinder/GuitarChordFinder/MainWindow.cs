using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GuitarChordFinder
{
	public enum Note { C, Cs, D, Ds, E, F, Fs, G, Gs, A, As, B, None = -1 }

	public partial class GuitarChordFinder : Form
    {
		static readonly string[] NOTES = { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "B", "H" };
		const int MAX_FRET = 15;
		const int STRINGS_COUNT = 6;
		const int MAX_SPAN = 3;
		static readonly Note[] DEFAULT_TUNING = { Note.E, Note.A, Note.D, Note.G, Note.B, Note.E }; //default je standardni ladeni EADGHe
		
		Note root = Note.None;      //root neboli zakladni ton akordu
        bool isPainting;      //udava, zda jiz byl ci nebyl vykreslen nejaky diagram - pokud je true, zmeny napr. v ladeni se projevi okamzite
        List<ChordFormula> knownFormulas = new List<ChordFormula>();
        CheckBox[] checkbox = new CheckBox[12];    //pomocne pole pro zjednoduseni prace s checkboxy
		Fretboard fretboard = new Fretboard(MAX_FRET, STRINGS_COUNT, DEFAULT_TUNING);

		/// <summary>
		/// Initializes GUI components to show default tuning and C major chord. Loads known chord formulas from file.
		/// </summary>
		public GuitarChordFinder()
		{
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
			UDTuning1.SelectedIndex = 11 - (int)fretboard.GetTuning(0);
			UDTuning2.SelectedIndex = 11 - (int)fretboard.GetTuning(1);
			UDTuning3.SelectedIndex = 11 - (int)fretboard.GetTuning(2);
			UDTuning4.SelectedIndex = 11 - (int)fretboard.GetTuning(3);
			UDTuning5.SelectedIndex = 11 - (int)fretboard.GetTuning(4);
			UDTuning6.SelectedIndex = 11 - (int)fretboard.GetTuning(5);


			List<string> knownFormulasNames = new List<string>();

			// load known chord formulas from file
			using (StreamReader formulasReader = new StreamReader("schemata.in")) {
				string line;
				while ((line = formulasReader.ReadLine()) != null)
				{
					string[] s_items = line.Split(';');
					int[] items = new int[s_items.Length];

					for (int i = 1; i < s_items.Length; i++)
					{
						int val;
						items[i] = int.TryParse(s_items[i], out val) ? val : 0;
					}
					knownFormulas.Add(new ChordFormula(s_items[0], items[1], items[2], items[3], items[4], items[5], items[6]));
					knownFormulasNames.Add(s_items[0]);
				}
			} 
            
            comboChordName.DataSource = knownFormulasNames;
        }


		/// <summary>
		/// Finds suitable fingerings for given chord, evaluates, sorts and displays them.
		/// </summary>
		private void findChordFingerings() {
			if (root != Note.None)
			{
				// change fretboard tuning according to user defined values
				fretboard.SetTuning(0, (Note)(11 - (UDTuning1.SelectedIndex % 12) + (int)capoLocation.Value));
				fretboard.SetTuning(1, (Note)(11 - (UDTuning2.SelectedIndex % 12) + (int)capoLocation.Value));
				fretboard.SetTuning(2, (Note)(11 - (UDTuning3.SelectedIndex % 12) + (int)capoLocation.Value));
				fretboard.SetTuning(3, (Note)(11 - (UDTuning4.SelectedIndex % 12) + (int)capoLocation.Value));
				fretboard.SetTuning(4, (Note)(11 - (UDTuning5.SelectedIndex % 12) + (int)capoLocation.Value));
				fretboard.SetTuning(5, (Note)(11 - (UDTuning6.SelectedIndex % 12) + (int)capoLocation.Value));

				// construct a Chord instance from the input values
				Chord currentChord = new Chord
					(
					new HashSet<Note>(),
					root,
					comboThird.SelectedIndex,
					comboFifth.SelectedIndex,
					comboSeventh.SelectedIndex,
					comboNinth.SelectedIndex,
					comboEleventh.SelectedIndex,
					comboThirteenth.SelectedIndex,
					(Note) comboBass.SelectedIndex,
					checkOmitRoot.Checked
					);

				for (int i = 0; i < 12; i++)
				{
					if (checkbox[i].Checked)
						currentChord.Notes.Add((Note)i);
				}

				// generate all possible fingerings
				List<int[]> feasibleFingerings = findFingerings(currentChord);

				// evaluate and sort the fingerings
				List<int[]> sortedFingerings = sortFingerings(currentChord, feasibleFingerings);

				//vygenerovani znacek pro vypis
				Dictionary<Note, string> intervalSymbols = generateHarmonicFunctionSymbols(currentChord);

				outputFingerings(intervalSymbols);
			}
		}
		       
        private void outputFingerings(Dictionary<Note, string> intervalSymbols)
        {
            //vypise nalezene prstoklady do ListBoxu
            
            List<string> items = new List<string>();
            for (int i = 0; (i < evaluatedFingerings.Count); i++)
            {
                StringBuilder item = new StringBuilder();
                int[] currentFingering = evaluatedFingerings[i];
                for (int j = 0; j < fretboard.StringsCount; j++)
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
                        

                    if (j < fretboard.StringsCount - 1)
                        item.Append("|");  
                }
                items.Add(item.ToString());
            }
            listAlternativeFingerings.DataSource = items;
            
            //vykresli prvni diagram
            if (evaluatedFingerings.Count > 0)
            {
                repaintDiagram(evaluatedFingerings[0], intervalSymbols);
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

        private void repaintDiagram(int[] fingering, Dictionary<Note, string> intervalSymbols)
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
            if (fingering[fretboard.StringsCount - 1] > 0) //posledni struna neni prazdna, potencialne existuje bare
            {
                int barreFret = fingering[fretboard.StringsCount - 1];
                List<int> barreStrings = new List<int>();
                barreStrings.Add(fretboard.StringsCount - 1);
                bool endOfBarre = false;
                try
                {
                    for (int i = fretboard.StringsCount - 2; i >= 0; i--)  //postupujeme od vyssich strun k basovym (bare muze byt i castecne, napr pouze pres ctyri struny
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
            string[] noteLabels = new string[fretboard.StringsCount];
            string[] intervalLabels = new string[fretboard.StringsCount];
            for (int i = 0; i < fingering.Length; i++)
            {
                if (fingering[i] == -1)
                {
                    noteLabels[i] = "";
                    intervalLabels[i] = "";
                }
                else
                {
                    noteLabels[i] = NOTES[(fingering[i] + (int)fretboard.GetTuning(i)) % 12];
                    intervalLabels[i] = intervalSymbols[(Note)((fingering[i] + (int)fretboard.GetTuning(i)) % 12)];
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
            root = (Note)comboRoot.SelectedIndex;
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
				findChordFingerings();
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


		/// <summary>
		/// For each of the 12 notes, return the symbol of a harmonic function this note fulfills in the chord.
		/// </summary>
		/// <returns>Dictionary with 12 entries containing the symbols of the harmonic functions of individual notes. If the note is not present in chord, the corresponding value is empty string.</returns>
		public Dictionary<Note, string> generateHarmonicFunctionSymbols(Chord chord)
		{
			var symbols = new Dictionary<Note, string>();

			symbols[chord.Root] = "R";

			// The order of assigning is IMPORTANT!
			// Same note can serve as different harmonic functions, e.g. major ninth and diminished third.
			// In case of such collision, the more important function will overwrite the other one (e.g. third will overwrite ninth).

			switch (chord.Ninth)
			{
				case 0: break;
				case 1:
					symbols[(Note)(((int)chord.Root + 1) % 12)] = "9b";
					break;
				case 2:
					symbols[(Note)(((int)chord.Root + 2) % 12)] = "9";
					break;
				default:
					break;
			}
			switch (chord.Eleventh)
			{
				case 0: break;
				case 1:
					symbols[(Note)(((int)chord.Root + 5) % 12)] = "11";
					break;
				case 2:
					symbols[(Note)(((int)chord.Root + 6) % 12)] = "11#";
					break;
				default:
					break;
			}
			switch (chord.Thirteenth)
			{
				case 0: break;
				case 1:
					symbols[(Note)(((int)chord.Root + 8) % 12)] = "13b";
					break;
				case 2:
					symbols[(Note)(((int)chord.Root + 9) % 12)] = "13";
					break;
				default:
					break;
			}
			switch (chord.Third)
			{
				case 0: break;
				case 1:
					symbols[(Note)(((int)chord.Root + 2) % 12)] = "2";
					break;
				case 2:
					symbols[(Note)(((int)chord.Root + 3) % 12)] = "m3";
					break;
				case 3:
					symbols[(Note)(((int)chord.Root + 4) % 12)] = "3";
					break;
				case 4:
					symbols[(Note)(((int)chord.Root + 5) % 12)] = "4";
					break;
				default:
					break;
			}
			switch (chord.Fifth)
			{
				case 0: break;
				case 1:
					symbols[(Note)(((int)chord.Root + 6) % 12)] = "5b";
					break;
				case 2:
					symbols[(Note)(((int)chord.Root + 7) % 12)] = "5";
					break;
				case 3:
					symbols[(Note)(((int)chord.Root + 8) % 12)] = "5#";
					break;
				default:
					break;
			}
			switch (chord.Seventh)
			{
				case 0: break;
				case 1:
					symbols[(Note)(((int)chord.Root + 9) % 12)] = "6";
					break;
				case 2:
					symbols[(Note)(((int)chord.Root + 10) % 12)] = "7";
					break;
				case 3:
					symbols[(Note)(((int)chord.Root + 11) % 12)] = "M7";
					break;
				default:
					break;
			}
			if (symbols[chord.Bass] == null)
			{
				// if the bass tone does not fulfill any other harmonic function, it is assigned its own symbol
				symbols[chord.Bass] = "(B)";
			}

			return symbols;
		}


		public List<int[]> findFingerings(Chord chord)
		{
			// positions of chord tones on the fretboard
			List<List<int>> notesOnFretboard = fretboard.findNotesOnFretboard(chord.Notes);
			// positions of the bass tone on the fretboard
			List<List<int>> bassOnFretboard = fretboard.findNotesOnFretboard(new HashSet<Note>(){ chord.Bass });

			// initialize recursive variables
			int[] currentFingering = new int[fretboard.StringsCount];
			List<int[]> fingerings = new List<int[]>();
			int bassOnString = 0;

			// call the recursive function
			nextString(notesOnFretboard, bassOnFretboard, ref bassOnString, fingerings, 0, currentFingering);
			return fingerings;
		}

		private void nextString(List<List<int>> notesOnFretboard, List<List<int>> bassesOnFretboard, ref int bassOnString, List<int[]> fingerings, int currentString, int[] currentFingering)
		{
			// first look for the bass note; only switch after it has been found
			List<List<int>> onFretboard = bassesOnFretboard;
			if (bassOnString < currentString)
				onFretboard = notesOnFretboard;


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
					if (currentString < fretboard.StringsCount - 1)
					{
						//rekurzivni volani funkce pro dalsi strunu
						nextString(ref notesOnFretboard, ref bassesOnFretboard, ref bassOnString, ref fingerings, currentString + 1, ref currentFingering);
					}
					else
					//posledni struna, nasli jsme smysluplny prstoklad
					{
						//test na obsazeni vsech tonu akordu
						if (containsAllNecessaryNotes(chord, currentFingering))
						{
							//pridani tonu do seznamu prstokladu
							int[] fingering_copy = new int[fretboard.StringsCount]; //nemohu pridat referencne predavanou prommenou, musim vytvorit kopii
							for (int j = 0; j < fretboard.StringsCount; j++)
							{ fingering_copy[j] = currentFingering[j]; }

							fingerings.Add(fingering_copy);
						}
					}
				}
			}
		}


		/// <summary>
		/// Evaluate feasibility of a (partial) fingering.
		/// </summary>
		/// <param name="fingering">Partial fingering.</param>
		/// <param name="currentString">The last string which has been assigned a value.</param>
		/// <returns></returns>
		private bool isFeasible(int[] fingering, int currentString)
		{
			// take the finished subset of the fingering
			int[] toCompare = fingering.Take(currentString + 1).ToArray();

			// CONDITIONS
			// max span 
			if (maxSpan(toCompare) > MAX_SPAN)
				return false; 

			// ...possible expansion...

			return true;
		}


		/// <summary>
		/// Returns span of the fingering, i.e. max fret - min fret (discarding empty or muted strings).
		/// </summary>
		/// <param name="frets">Frets in the fingering.</param>
		/// <returns></returns>
		private int maxSpan(int[] frets)
		{
			List<int> nonzeroValues = frets.Where(x => x > 0).ToList();
			return nonzeroValues.Count > 0 ? nonzeroValues.Max() - nonzeroValues.Min() : 0;
		}

		/// <summary>
		/// Check if the fingering constructed for the given chord contains all the notes it should. 
		/// If the chord contains more notes than can be feasibly played, some of them are omitted (according to a set of rules).
		/// </summary>
		/// <param name="chord">The chord to be checked against.</param>
		/// <param name="fingering">The constructed fingering</param>
		/// <returns></returns>
		private bool containsAllNecessaryNotes(Chord chord, int[] fingering)
		{
			var notesInFingering = new HashSet<Note>();
			for (int str = 0; str < fretboard.StringsCount; str++)
			{
				if (fingering[str] > -1)
				{
					notesInFingering.Add((Note)(((int)fretboard.GetTuning(str) + fingering[str]) % 12));
				}
			}

			// deep copy the set of notes in the chord (it may be modified)
			HashSet<Note> chordNotes = new HashSet<Note>(chord.Notes);

			// if there are more notes in the chord than strings on the guitar, some can be omitted
			if (chord.Notes.Count() >= fretboard.StringsCount)
			{
				 omitSuitableNotes(chord, chordNotes);
			}

			foreach (Note note in chordNotes)
			{
				if (!notesInFingering.Contains(note))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// /// Removes the least important notes from the chord.
		/// </summary>
		/// <param name="chord">The chord to be reduced (will not be modified).</param>
		/// <param name="chordNotes">The resulting reduced set of notes.</param>
		private void omitSuitableNotes(Chord chord, HashSet<Note> chordNotes)
		{
			int omitted = 0;

			// user can allow omission of the Root; however, it will only be carried out if the fifth is present
			if ((chord.isRootOmissionAllowed()) && (chord.Fifth > 0))
			{
				chordNotes.Remove(chord.Root);
				omitted++;
			}

			// perfect fifth can be omitted (if the root was not omitted)
			if ((chord.Fifth == 2) && (chordNotes.Contains(chord.Root)))
			{
				chordNotes.Remove((Note)(((int)chord.Root + 7) % 12));
				omitted++;
			}

			// perfect eleventh in thirteenth chord can be omitted
			if ((chord.Thirteenth > 0) && (chord.Eleventh == 1))
			{
				chordNotes.Remove((Note)(((int)chord.Root + 5) % 12));
				omitted++;
			}

			// major ninth in eleventh chord can be omitted
			if ((chord.Eleventh > 0) && (chord.Ninth == 2))
			{
				chordNotes.Remove((Note)(((int)chord.Root + 2) % 12));
				omitted++;
			}
			// major ninth in thirteenth chord can be omitted
			if ((chord.Thirteenth > 0) && (chord.Ninth == 2))
			{
				chordNotes.Remove((Note)(((int)chord.Root + 2) % 12));
				omitted++;
			}
		}

		public List<int[]> sortFingerings(Chord chord, List<int[]> feasibleFingerings)
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
				for (int i = 0; i < fretboard.StringsCount; i++)
				{
					if ((containedInFingering.Contains((fingering[i] + (int)fretboard.GetTuning(i)) % 12) == false) && (fingering[i] > -1))
					{
						containedInFingering.Add((fingering[i] + (int)fretboard.GetTuning(i)) % 12);
					}
				}
				penalty += (chord.Notes.Count - containedInFingering.Count) * 100; //silne kriterium

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



		private void btnFind_Click(object sender, EventArgs e)
		{
			findChordFingerings();
		}

		private void capoUpDown_ValueChanged(object sender, EventArgs e)
		{
			if (isPainting)
				findChordFingerings();
		}

	}

	/// <summary>
	/// Class representing the guitar fretboard. 
	/// </summary>
	class Fretboard
    {
        int maxFret;
		int stringsCount;
		Note[] tuning;

		public int StringsCount
		{
			get{ return stringsCount;} 
		}

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="maxFret">The highest (usable) fret on the fretboard.</param>
		/// <param name="stringsCount">Number of strings.</param>
		/// <param name="tuning"></param>
		public Fretboard(int maxFret, int stringsCount, Note[] tuning){
			this.maxFret = maxFret;
			this.stringsCount = stringsCount;
			this.tuning = tuning;
		}

        public Note GetTuning(int index)
        {
            return tuning[index];
        }
        public void SetTuning(int index, Note value)
        {
            tuning[index] = value;
        }

		/// <summary>
		/// Returns a ragged list of all the locations of given notes on individual strings.
		/// </summary>
		/// <param name="notes">Notes to be searched for.</param>
		/// <returns></returns>
        public List<List<int>> findNotesOnFretboard(HashSet<Note> notes)
        {
            List<List<int>> notesOnFretboard = new List<List<int>>();

            for (int str = 0; str < StringsCount; str++)
            {
                notesOnFretboard.Add(new List<int>());
                for (int fret = 0; fret < maxFret; fret++)
                {
					Note currentNote = (Note)(((int)tuning[str] + fret) % 12);
					if (notes.Contains(currentNote)){
						notesOnFretboard[str].Add(fret);
					}
                }
            }

			// first two strings can be muted explicitly (others only if there is no other feasible solution (handled elsewhere))
            notesOnFretboard[0].Add(-1);
            notesOnFretboard[1].Add(-1);

            return notesOnFretboard;
        }
    }

	/// <summary>
	/// Describes the chord skeleton (no absolute pitches, only relative stepwise distances)
	/// </summary>
    class ChordFormula
    {
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

	/// <summary>
	/// Simple data structure describing a specific fingering on a guitar together with its penalty score. 
	/// </summary>
    class Fingering
    {
        private int[] fretsInFingering;
        public int[] FretsInFignering
        {
            get { return fretsInFingering; }
        }
        private int penalty;
        public int Penalty
        {
            get { return penalty; }
        }

        public Fingering(int[] fretsInFingering, int penalty)
        {
            this.fretsInFingering = fretsInFingering;
            this.penalty = penalty;
        }
    }

	/// <summary>
	/// Represents a chord.
	/// </summary>
    public class Chord
    {
        HashSet<Note> notes;
        public HashSet<Note> Notes
        {
            get { return notes; }
            set { notes = value; }
        }

		
		bool rootOmissionAllowed = false;
		Note root, bass;
		int third, fifth, seventh, ninth, eleventh, thirteenth;
		public Note Root
		{
			get { return root; }
			set { root = value; }
		}
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
        public Note Bass
        {
            get { return bass; }
            set { bass = value; }
        }

		/// <summary>
		/// Default constructor.
		/// </summary>
		/// <param name="notes">List of Notes present in the chord.</param>
		/// <param name="root">Root note.</param>
		/// <param name="third">Quality of third.</param>
		/// <param name="fifth">Quality of fifth.</param>
		/// <param name="seventh">Quality of seventh.</param>
		/// <param name="ninth">Quality of ninth.</param>
		/// <param name="eleventh">Quality of eleventh.</param>
		/// <param name="thirteenth">Quality of thirteenth.</param>
		/// <param name="bass">Bass note.</param>
		/// <param name="rootOmissionAllowed">True if it is allowed to omit the root in the fingering.</param>
		public Chord(HashSet<Note> notes, Note root, int third, int fifth, int seventh, int ninth, int eleventh, int thirteenth, Note bass, bool rootOmissionAllowed)
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

		public bool isRootOmissionAllowed() {
			return rootOmissionAllowed;
		}    
    }
}
