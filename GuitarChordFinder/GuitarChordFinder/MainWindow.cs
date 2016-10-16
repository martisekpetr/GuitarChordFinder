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
        private bool kresliSe;      //udava, zda jiz byl ci nebyl vykreslen nejaky diagram - pokud je true, zmeny napr. v ladeni se projevi okamzite
        private List<Schema> znamaSchemata = new List<Schema>();
        List<int[]> ohodnocenePrstoklady = new List<int[]>();
        string[] znacky = new string[12];       //symbolicke znacky intervalu, slouzi pro vypis
        CheckBox[] check = new CheckBox[12];    //pomocne pole pro zjednoduseni prace s checkboxy

        public GuitarChordFinder()
        {
            //inicializace komponent - standardni ladeni, akord C dur
            InitializeComponent();
            check[0] = checkBox1;
            check[1] = checkBox2;
            check[2] = checkBox3;
            check[3] = checkBox4;
            check[4] = checkBox5;
            check[5] = checkBox6;
            check[6] = checkBox7;
            check[7] = checkBox8;
            check[8] = checkBox9;
            check[9] = checkBox10;
            check[10] = checkBox11;
            check[11] = checkBox12;
            comboRoot.SelectedIndex = 0;
            gB_StrukturaAkordu.Enabled = false;
            gB_TonyVAkordu.Enabled = false;
            comboTercie.SelectedIndex = 3;
            comboKvinta.SelectedIndex = 2;
            comboSeptima.SelectedIndex = 0;
            comboNona.SelectedIndex = 0;
            comboUndecima.SelectedIndex = 0;
            comboTercdecima.SelectedIndex = 0;
            UDLadeni1.SelectedIndex = 11 - Hmatnik.GetLadeni(0);
            UDLadeni2.SelectedIndex = 11 - Hmatnik.GetLadeni(1);
            UDLadeni3.SelectedIndex = 11 - Hmatnik.GetLadeni(2);
            UDLadeni4.SelectedIndex = 11 - Hmatnik.GetLadeni(3);
            UDLadeni5.SelectedIndex = 11 - Hmatnik.GetLadeni(4);
            UDLadeni6.SelectedIndex = 11 - Hmatnik.GetLadeni(5);
            
            
            List<string> znamaSchemataJmena = new List<string>();
            
            //nacteni znamych schemat ze souboru
            StreamReader schemata = new StreamReader("schemata.in");
            while (!schemata.EndOfStream)
            {
                string radek = schemata.ReadLine();
                string[] Sparametry = radek.Split(';');
                int[] parametry = new int[Sparametry.Length];
                for (int i = 1; i < Sparametry.Length; i++)
                {
                    parametry[i] = Int16.Parse(Sparametry[i]);
                }

                znamaSchemata.Add(new Schema(Sparametry[0], parametry[1], parametry[2], parametry[3], parametry[4], parametry[5], parametry[6]));
                znamaSchemataJmena.Add(Sparametry[0]);
            }
            schemata.Close();

            comboNazev.DataSource = znamaSchemataJmena;
        }

        private void buttonGeneruj_Click(object sender, EventArgs e)
        {   //spoustec cele masinerie - generovani prstokladu, vykreslovani atd.
 
            if (root > -1)
            {
                //nastaveni ladeni podle uzivatelem vybranych hodnot, popr. i "umisteni kapodastru"
                Hmatnik.SetLadeni(0, 11 - (UDLadeni1.SelectedIndex % 12) + (int)capoUpDown.Value);
                Hmatnik.SetLadeni(1, 11 - (UDLadeni2.SelectedIndex % 12) + (int)capoUpDown.Value);
                Hmatnik.SetLadeni(2, 11 - (UDLadeni3.SelectedIndex % 12) + (int)capoUpDown.Value);
                Hmatnik.SetLadeni(3, 11 - (UDLadeni4.SelectedIndex % 12) + (int)capoUpDown.Value);
                Hmatnik.SetLadeni(4, 11 - (UDLadeni5.SelectedIndex % 12) + (int)capoUpDown.Value);
                Hmatnik.SetLadeni(5, 11 - (UDLadeni6.SelectedIndex % 12) + (int)capoUpDown.Value);

                //vytvoreni instance tridy Akord
                Akord aktualniAkord = new Akord
                    (
                    new List<int>(), 
                    root, 
                    comboTercie.SelectedIndex, 
                    comboKvinta.SelectedIndex, 
                    comboSeptima.SelectedIndex, 
                    comboNona.SelectedIndex, 
                    comboUndecima.SelectedIndex, 
                    comboTercdecima.SelectedIndex, 
                    comboBas.SelectedIndex, 
                    checkVynechRoot.Checked
                    );
               
                //pridani tonu pouzitych v akordu do instance aktualniAkord
                for (int i = 0; i < 12; i++)
                {
                    if (check[i].Checked)
                        aktualniAkord.Tony.Add(i);
                }
                
                //vygenerovani hratelnych prstokladu
                List<int[]> vhodnePrstoklady = aktualniAkord.VygenerujPrstoklady();
                
                //ohodnoceni a setrideni nalezenych prstokladu
                ohodnocenePrstoklady = aktualniAkord.OhodnotPrstoklady(ref vhodnePrstoklady);

                //vygenerovani znacek pro vypis
                znacky = aktualniAkord.VygenerujZnacky();
                
                Vypis();
            }
        }

        private void Vypis()
        {
            //vypise nalezene prstoklady do ListBoxu
            
            List<string> items = new List<string>();
            for (int i = 0; (i < ohodnocenePrstoklady.Count); i++)
            {
                StringBuilder item = new StringBuilder();
                int[] aktualniPrstoklad = ohodnocenePrstoklady[i];
                for (int j = 0; j < Hmatnik.PocetStrun; j++)
                {
                    if (aktualniPrstoklad[j] == -1)
                        item.Append(" X ");
                    else
                        if (aktualniPrstoklad[j] >= 10)
                        {
                            item.Append(aktualniPrstoklad[j]);
                            item.Append(" ");
                        }
                        else
                        {
                            item.Append(" ");
                            item.Append(aktualniPrstoklad[j]);
                            item.Append(" ");
                        }
                        

                    if (j < Hmatnik.PocetStrun - 1)
                        item.Append("|");  
                }
                items.Add(item.ToString());
            }
            listOut.DataSource = items;
            
            //vykresli prvni diagram
            if (ohodnocenePrstoklady.Count > 0)
            {
                PrekresliDiagram(ohodnocenePrstoklady[0], ref znacky);
            }
        }

        private Schema SestavSchema()
        {
            //funkce se pokusi sestavit ze zadanych tonu akord a dosadit patricne hodnoty do sekce Struktura

            Schema sestavovaneSchema = new Schema("", 0, 0, 0, 0, 0, 0);
            int nalezenych = 0;

            //snazime se najit a priradit prislusne harmonicke funkci konkretni ton. Zkousime vsechny mozne modulace intervalu (napr. tercie
            //muze byt velka, mala, zmensena nebo zvetsena).

            //tercie
            if (check[(root + 4) % 12].Checked) { sestavovaneSchema.Tercie = 3; nalezenych++; }
            else
            {
                if (check[(root + 3) % 12].Checked) { sestavovaneSchema.Tercie = 2; nalezenych++; }
                else
                {
                    if (check[(root + 2) % 12].Checked) { sestavovaneSchema.Tercie = 1; nalezenych++; }
                    else
                    {
                        if (check[(root + 5) % 12].Checked) { sestavovaneSchema.Tercie = 4; nalezenych++; }
                    }
                }
            }
            //kvinta
            if (check[(root + 7) % 12].Checked) { sestavovaneSchema.Kvinta = 2; nalezenych++; }
            else
            {
                if (check[(root + 6) % 12].Checked) { sestavovaneSchema.Kvinta = 1; nalezenych++; }
                else
                {
                    if (check[(root + 8) % 12].Checked) { sestavovaneSchema.Kvinta = 3; nalezenych++; }
                }
            }
            //septima
            if (check[(root + 10) % 12].Checked) { sestavovaneSchema.Septima = 2; nalezenych++; }
            else
            {
                if (check[(root + 11) % 12].Checked) { sestavovaneSchema.Septima = 3; nalezenych++; }
                else
                {
                    if (check[(root + 9) % 12].Checked) { sestavovaneSchema.Septima = 1; nalezenych++; }
                }
            }
            //nona
            if ((check[(root + 2) % 12].Checked) && (sestavovaneSchema.Tercie > 1)) { sestavovaneSchema.Nona = 2; nalezenych++; }
            else
            {
                if (check[(root + 1) % 12].Checked) { sestavovaneSchema.Nona = 1; nalezenych++; }
            }
            //undecima
            if ((check[(root + 5) % 12].Checked) && (sestavovaneSchema.Tercie < 4)) { sestavovaneSchema.Undecima = 1; nalezenych++; }
            else
            {
                if ((check[(root + 6) % 12].Checked) && (sestavovaneSchema.Kvinta > 1)) { sestavovaneSchema.Undecima = 1; nalezenych++; }
            }
            //tercdecima
            if ((check[(root + 9) % 12].Checked) && (sestavovaneSchema.Septima > 1)) { sestavovaneSchema.Tercdecima = 2; nalezenych++; }
            else
            {
                if ((check[(root + 8) % 12].Checked) && (sestavovaneSchema.Kvinta < 3)) { sestavovaneSchema.Tercdecima = 1; nalezenych++; }
            }
            //pozn. poradi testu na intervaly je DULEZITE! Napr. interval 2 muze znamenat zmensenou tercii, ale i cistou nonu; musime testovat tercii driv,
            //protoze v akordove skladbe ma prednost. Pouze v pripade, ze jsme jiz nasli cistou tercii (malou - 3 nebo velkou - 4) muze byt interval 2 
            //interpretovan jako nona.

            int zadanych = 0;
            for (int i = 0; i < 12; i++)
            {
                if (check[i].Checked) { zadanych++; }
            }
            //kontrola, zda pocet tonu zadanych pomoci checkboxu je stejny, jako pocet nalezenych harmonickych funkci
            if (zadanych > nalezenych + 1) //+1 znamena root (ten se v prubehu funkce nezapocetl)
            {
                return null;  //nepodarilo se najit schema zahrnujici vsechny tony
            }
            return sestavovaneSchema;
        }

        private void PrepisCheckboxy()
        {
            //funkce prepise checkboxy v sekci 'Tony v akordu' podle hodnot v sekci 'Struktura akordu'

            for (int i = 0; i < check.Length; i++) 
                check[i].Checked = false;    //vynulovani

            check[root].Checked = true;
            if (comboTercie.SelectedIndex > 0)
            { check[(root + comboTercie.SelectedIndex + 1) % 12].Checked = true; }
            if (comboKvinta.SelectedIndex > 0)
            { check[(root + comboKvinta.SelectedIndex + 5) % 12].Checked = true; }
            if (comboSeptima.SelectedIndex > 0)
            { check[(root + comboSeptima.SelectedIndex + 8) % 12].Checked = true; }
            if (comboNona.SelectedIndex > 0)
            { check[(root + comboNona.SelectedIndex) % 12].Checked = true; }
            if (comboUndecima.SelectedIndex > 0)
            { check[(root + comboUndecima.SelectedIndex + 4) % 12].Checked = true; }
            if (comboTercdecima.SelectedIndex > 0)
            { check[(root + comboTercdecima.SelectedIndex + 7) % 12].Checked = true; }
        }

        private bool JeZnameSchema(Schema schema)
        {
            //funkce porovna parametry v sekci "struktura akordu" s konkretnim schematem
            if (comboTercie.SelectedIndex != schema.Tercie) { return false; }
            if (comboKvinta.SelectedIndex != schema.Kvinta) { return false; }
            if (comboSeptima.SelectedIndex != schema.Septima) { return false; }
            if (comboNona.SelectedIndex != schema.Nona) { return false; }
            if (comboUndecima.SelectedIndex != schema.Undecima) { return false; }
            if (comboTercdecima.SelectedIndex != schema.Tercdecima) { return false; }

            return true;
        }

        private void PrekresliDiagram(int[] prstoklad, ref string[] znacky)
        {
            kresliSe = true;
            Graphics grafika = pictureBox1.CreateGraphics();

            //nakreslime prazdne pozadi
            grafika.DrawImage(Image.FromFile("background.png"), 0, 0, 200, 300);
           
            int prazec = 0;
            
            //diagram obsahuje pouze 5 prazcu, pro vyse umistene prstoklady se zobrazeni posouva
            if (prstoklad.Max() > 5)
            {
                List<int> BezNul = new List<int>();

                //prazdne ci zatlumene struny nas nezajimaji
                for (int i = 0; i < prstoklad.Length; i++)
                {
                    if (prstoklad[i] > 0)
                    { BezNul.Add(prstoklad[i]); }
                }

                //misto prvniho prazce zacina diagram na nejnizsim prazci v prstokladu
                prazec = BezNul.Min() - 1;
                labelPrazec.Text = (prazec + 1) + ". pražec";
            }
            else
            {
                prazec = 0;
                labelPrazec.Text = (prazec + 1) + ". pražec";
            }

            for (int i = 0; i < prstoklad.Length; i++)
            {
                //vykresleni tecek a krizku na patricna mista
                if (prstoklad[i] == 0) //prazdna struna
                {
                    grafika.DrawImage(Image.FromFile("emptydot.bmp"), 34 * i, 10, 30, 30);
                }
                if (prstoklad[i] == -1) //zatlumena struna
                {
                    grafika.DrawImage(Image.FromFile("cross.bmp"), 34 * i, 10, 30, 30);
                }
                if (prstoklad[i] > 0)  //struna drzena na nejakem prazci
                {
                    grafika.DrawImage(Image.FromFile("dot.bmp"), 34 * i, 10 + 50 * (prstoklad[i] - prazec), 30, 30);
                }
            }

            //vykresleni bare (bare = skupina not, ktere jsou v prstokladu na stejnem prazci a lze je tedy hrat jednim prstem polozenym pres vice strun (vetsinou ukazovak)
            if (prstoklad[Hmatnik.PocetStrun - 1] > 0) //posledni struna neni prazdna, potencialne existuje bare
            {
                int barePrazec = prstoklad[Hmatnik.PocetStrun - 1];
                List<int> bareStruny = new List<int>();
                bareStruny.Add(Hmatnik.PocetStrun - 1);
                bool konecBare = false;
                try
                {
                    for (int i = Hmatnik.PocetStrun - 2; i >= 0; i--)  //postupujeme od vyssich strun k basovym (bare muze byt i castecne, napr pouze pres ctyri struny
                    {                                                       
                        if (konecBare)
                        {
                            if (prstoklad[i] > 0)
                            {
                                //bare je ukonceno, dalsi pozice uz musi byt pouze niz na hmatniku (jinak se to neda chytnout)
                                throw new Exception("Bare neexistuje.");
                            }
                        }
                        switch (prstoklad[i].CompareTo(barePrazec))
                        {
                            case 1:
                                {
                                    //pozice na aktualni strune je vys nez drzene bare - OK, lze chytnout zbylymi prsty
                                    break;
                                }
                            case 0:
                                {
                                    //pozice je na stejnem prazci jako budovane bare - pridame do bare
                                    bareStruny.Add(i);
                                    break;
                                }
                            case -1:
                                {
                                    //pozice "pod" bare, pokud je to prazdna ci zatlumena nota, bare ukoncime
                                    if (prstoklad[i] <= 0)
                                    {
                                        konecBare = true;
                                    }
                                    //jinak zacneme budovat nove bare na teto nizsi pozici
                                    else
                                    {
                                        barePrazec = prstoklad[i];
                                        bareStruny.Clear();
                                        bareStruny.Add(i);
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
                    bareStruny.Clear();
                }
                
                if (bareStruny.Count > 1) //bare existuje (resp. za bare jej povazujeme, pokud obsahuje alespon dve struny), vykreslime
                {
                    grafika.DrawLine(new Pen(Color.Black, 8), 32 * bareStruny.Min() + 15 , 50 * (barePrazec - prazec) + 25 , 32 * bareStruny.Max() + 15, 50 * (barePrazec - prazec) + 25);
                }
            }

            //vypsani popisku pod diagramem (na jednom radku konkretni tony, na druhem jejich harmonicke funkce v aktualnim akordu)
            string[] popiskyTonu = new string[Hmatnik.PocetStrun];
            string[] popiskyZnacek = new string[Hmatnik.PocetStrun];
            for (int i = 0; i < prstoklad.Length; i++)
            {
                if (prstoklad[i] == -1)
                {
                    popiskyTonu[i] = "";
                    popiskyZnacek[i] = "";
                }
                else
                {
                    popiskyTonu[i] = Tony.VratNazev((prstoklad[i] + Hmatnik.GetLadeni(i)) % 12);
                    popiskyZnacek[i] = znacky[(prstoklad[i] + Hmatnik.GetLadeni(i)) % 12];
                }
            }
            labelStruna1.Text = popiskyTonu[0];
            labelStruna2.Text = popiskyTonu[1];
            labelStruna3.Text = popiskyTonu[2];
            labelStruna4.Text = popiskyTonu[3];
            labelStruna5.Text = popiskyTonu[4];
            labelStruna6.Text = popiskyTonu[5];
            labelInterval1.Text = popiskyZnacek[0];
            labelInterval2.Text = popiskyZnacek[1];
            labelInterval3.Text = popiskyZnacek[2];
            labelInterval4.Text = popiskyZnacek[3];
            labelInterval5.Text = popiskyZnacek[4];
            labelInterval6.Text = popiskyZnacek[5];
        }

        private void buttonDalsi_Click(object sender, EventArgs e)
        {
            listOut.SelectedIndex++;
        }

        private void buttonPredchozi_Click(object sender, EventArgs e)
        {
            listOut.SelectedIndex--;
        }

        //prepinani mezi moznostmi zadani akordu
        private void radioStruktura_CheckedChanged(object sender, EventArgs e)
        {
            gB_StrukturaAkordu.Enabled = true;
            gB_TonyVAkordu.Enabled = false;
            gB_NazevAkordu.Enabled = false;
            comboRoot.Enabled = true;
        }

        private void radioNazev_CheckedChanged(object sender, EventArgs e)
        {
            gB_TonyVAkordu.Enabled = false;
            gB_StrukturaAkordu.Enabled = false;
            gB_NazevAkordu.Enabled = true;
            comboRoot.Enabled = true;
            comboNazev_SelectedIndexChanged(radioNazev, e);
        }

        private void radioTony_CheckedChanged(object sender, EventArgs e)
        {
            gB_StrukturaAkordu.Enabled = false;
            gB_TonyVAkordu.Enabled = true;
            gB_NazevAkordu.Enabled = false;
            comboRoot.Enabled = false;
        }

        //zmena zakladniho tonu - pokud se nezadavalo vyctem tonu, je nutno prepsat (transponovat) checkboxy
        private void comboRoot_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBas.SelectedIndex = comboRoot.SelectedIndex;
            root = comboRoot.SelectedIndex;
            if (radioTony.Checked == false)
                { PrepisCheckboxy(); }
        }

        //manualni zmena nazvu akordu - prepsani informaci v sekci ' struktura' (coz nasledne vede k prepsani checkboxu)
        private void comboNazev_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((comboNazev.SelectedIndex > -1) && (radioNazev.Checked))
            {
                Schema current = znamaSchemata[comboNazev.SelectedIndex];
                comboTercie.SelectedIndex = current.Tercie;
                comboKvinta.SelectedIndex = current.Kvinta;
                comboSeptima.SelectedIndex = current.Septima;
                comboNona.SelectedIndex = current.Nona;
                comboUndecima.SelectedIndex = current.Undecima;
                comboTercdecima.SelectedIndex = current.Tercdecima;
            }
        }

        private void comboStruktura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioTony.Checked == false)
            {
                //pokud zmena nebyla inicializovana zmenou v checkboxech, prepiseme je
                PrepisCheckboxy();
            }
            if (radioNazev.Checked == false)
            {
                //pokud zmena nebyla inicializovana zmenou nazvu, zkusime najit nazev odpovidajici aktualni strukture
                for (int i = 0; i < znamaSchemata.Count; i++)
                {
                    if (JeZnameSchema(znamaSchemata[i]))
                    {
                        if (comboNazev.SelectedIndex != i)
                        { comboNazev.SelectedIndex = i; }
                        break;
                    }
                    else
                    { comboNazev.SelectedIndex = -1; }
                }
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            //prepsani checkboxu mohla volat i jina metoda, veskere dalsi akce se vsak provadi pouze pokud byly prepsany skutecne, "manualne"
            if (radioTony.Checked)
            {
                if ((comboRoot.SelectedIndex == -1) || (check[root].Checked == false))
                {
                    //pokud ton s funkci zakladniho tonu (rootu) je odznacen, vybere se novy - nejnizsi zaskrtnuty
                    comboRoot.SelectedIndex = -1;
                    for (int i = 0; i < 12; i++)
                    {
                        if (check[i].Checked)
                        {
                            comboRoot.SelectedIndex = i; 
                            break;
                        }
                    }
                }
              

                //pokusi se sestavit ze zadanych tonu schema a vyplnit sekci "Struktura akordu"
                Schema current = SestavSchema();
                if (current == null)
                {
                    //pokud se nepovedlo, vynulujeme udaje v sekci 'Struktura' (tony zrejme netvori korektni akord)
                    current = new Schema("", 0, 0, 0, 0, 0, 0);
                }
                comboTercie.SelectedIndex = current.Tercie;
                comboKvinta.SelectedIndex = current.Kvinta;
                comboSeptima.SelectedIndex = current.Septima;
                comboNona.SelectedIndex = current.Nona;
                comboUndecima.SelectedIndex = current.Undecima;
                comboTercdecima.SelectedIndex = current.Tercdecima;
            }
        }

        private void UDLadeni_SelectedItemChanged(object sender, EventArgs e)
        {
            DomainUpDown ud = (DomainUpDown)sender;
            
            //zajisteni cyklicnosti UpDown boxu
            if (ud.SelectedIndex == 0)
                ud.SelectedIndex = 12;
            if (ud.SelectedIndex == 13)
                ud.SelectedIndex = 1;

            if (kresliSe)
            {
                //zmena ladeni vyvola okamzite prepsani diagramu -> "klikne" na  tlacitko 'Generuj'
                buttonGeneruj_Click(ud, new EventArgs());
            }
        }

        private void BtnDefaultTuning_Click(object sender, EventArgs e)
        {
            //zmeni ladeni na standardni (tj. EADGHe)
            UDLadeni1.SelectedIndex = 7;
            UDLadeni2.SelectedIndex = 2;
            UDLadeni3.SelectedIndex = 9;
            UDLadeni4.SelectedIndex = 4;
            UDLadeni5.SelectedIndex = 0;
            UDLadeni6.SelectedIndex = 7;
        }

        private void listOut_SelectedIndexChanged(object sender, EventArgs e)
        {
            //prochazeni seznamem vygenerovanych prstokladu -> prekresleni diagramu + osetreni funkcnosti tlacitek pro listovani seznamem
            PrekresliDiagram(ohodnocenePrstoklady[listOut.SelectedIndex], ref znacky);

            if (listOut.SelectedIndex == ohodnocenePrstoklady.Count - 1)
                buttonDalsi.Enabled = false;
            else
                buttonDalsi.Enabled = true;

            if (listOut.SelectedIndex == 0)
                buttonPredchozi.Enabled = false;
            else
                buttonPredchozi.Enabled = true;
        }

        private void capoUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (kresliSe)
            {
                //"umisteni kapodastru" vyvola okamzite prepsani diagramu -> "klikne" na  tlacitko 'Generuj'
                buttonGeneruj_Click(sender, new EventArgs());
            }
        }
    }
    


    public static class Tony
    {
        //pomocna trida obsahujici nazvy tonu
        private static string[] TON = new string[12] { "C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "B", "H" };

        public static string VratNazev(int index)
        {
            return TON[index];
        }
    }

    public static class Hmatnik
        //staticka trida implementujici abstraktni konstrukci Hmatnik a funkce s nim spojene
    {
        private const int MAXPRAZEC = 15;
        private const int POCETSTRUN = 6;
        public static int PocetStrun
        {
            get { return POCETSTRUN; }
        }
        private static int[] ladeni = new int[] { 4, 9, 2, 7, 11, 4 }; //default je standardni ladeni EADGHe
        public static int GetLadeni(int index)
        {
            return ladeni[index];
        }
        public static void SetLadeni(int index, int value)
        {
            ladeni[index] = value;
        }

        public static List<List<int>> NajdiTonyNaHmatniku(List<int> tony)
        {
            //funkce dostane jako parametr seznam tonu v aktualnim akordu a vrati pozice tonu na 
            //hmatniku v aktualnim ladeni ve formatu sestice Listu s pozicemi na kazde strune (v pripade sesti strun)

            List<List<int>> tonyNaHmatniku = new List<List<int>>();

            for (int struna = 0; struna < POCETSTRUN; struna++)
            {
                tonyNaHmatniku.Add(new List<int>());
                for (int prazec = 0; prazec < MAXPRAZEC; prazec++)
                {
                    if (tony.Contains((ladeni[struna] + prazec) % 12))
                        tonyNaHmatniku[struna].Add(prazec);
                }
            }

            //pro prvni 2 struny je povoleno zatlumeni (-1) explicitne, u ostatnich jen pokud neexistuje hratelna pozice (osetreno dale)
            tonyNaHmatniku[0].Add(-1);
            tonyNaHmatniku[1].Add(-1);

            return tonyNaHmatniku;
        }
    }


    public class Schema
    {
        //pomocna konstrukce implementujici schema akordu (ve smyslu intervalove sablony)
        private string nazev;
        public string Nazev { get { return nazev; } }

        private int tercie, kvinta, septima, nona, undecima, tercdecima;
        public int Tercie
        {
            get { return tercie; }
            set { tercie = value; }
        }
        public int Kvinta
        {
            get { return kvinta; }
            set { kvinta = value; }
        }
        public int Septima
        {
            get { return septima; }
            set { septima = value; }
        }
        public int Nona
        {
            get { return nona; }
            set { nona = value; }
        }
        public int Undecima
        {
            get { return undecima; }
            set { undecima = value; }
        }
        public int Tercdecima
        {
            get { return tercdecima; }
            set { tercdecima = value; }
        }


        public Schema(string nazev, int tercie, int kvinta, int septima, int nona, int undecima, int tercdecima)
        {
            this.nazev = nazev;
            this.tercie = tercie;
            this.kvinta = kvinta;
            this.septima = septima;
            this.nona = nona;
            this.undecima = undecima;
            this.tercdecima = tercdecima;
        }
    }


    public class Prstoklad
    {
        //krome sestice tonu obsazenych v prstokladu obsahuje navic promennou 'penalizace' - tedy udrzuje hodnoceni daneho prstokladu
        private int[] prazceVPrstokladu;
        public int[] PrazceVPrstokladu
        {
            get { return prazceVPrstokladu; }
        }
        private int penalizace;
        public int Penalizace
        {
            get { return penalizace; }
            set { penalizace = value; }
        }

        public Prstoklad(int[] prazceVPrstokladu, int penalizace)
        {
            this.prazceVPrstokladu = prazceVPrstokladu;
            this.penalizace = penalizace;
        }
    }


    public class Akord
    {
        private const int MAXROZPETI = 3;

        private List<int> tony;
        public List<int> Tony
        {
            get { return tony; }
            set { tony = value; }
        }
        private int tercie, kvinta, septima, nona, undecima, tercdecima;
        public int Tercie
        {
            get { return tercie; }
            set { tercie = value; }
        }
        public int Kvinta
        {
            get { return kvinta; }
            set { kvinta = value; }
        }
        public int Septima
        {
            get { return septima; }
            set { septima = value; }
        }
        public int Nona
        {
            get { return nona; }
            set { nona = value; }
        }
        public int Undecima
        {
            get { return undecima; }
            set { undecima = value; }
        }
        public int Tercdecima
        {
            get { return tercdecima; }
            set { tercdecima = value; }
        }
        public int Bas
        {
            get { return bas; }
            set { bas = value; }
        }
        private int root, bas;
        private bool lzeVynechatRoot = false;

        public Akord(List<int> tony, int root, int tercie, int kvinta, int septima, int nona, int undecima, int tercdecima, int bas, bool lzeVynechatRoot)
        {
            this.root = root;
            this.tercie = tercie;
            this.kvinta = kvinta;
            this.septima = septima;
            this.nona = nona;
            this.undecima = undecima;
            this.tercdecima = tercdecima;
            this.tony = tony;
            this.bas = bas;
            this.lzeVynechatRoot = lzeVynechatRoot;
        }

        public string[] VygenerujZnacky()
        {
            //pro kazdy ton od C po H vygeneruje "znacku" - zkratku pro jeho harmonickou funkci 
            //v akordu, popr prazdny retezec pro tony, jez v akordu nejsou

            string[] znacky = new string[12];

            znacky[this.root] = "R";

            //Obcas mohou tony kolidovat - v akordu muze byt napr. velka nona a zmensena tercie, coz je 
            //ve skutecnosti tentyz ton. V takovem pripade znacka pro tercii prepise znacku pro nonu
            //(proto se harmonicke funkce vyhodnocuji v tomto poradi).

            switch (this.Nona)
            {
                case 0: break;
                case 1: znacky[(this.root + 1) % 12] = "9b";
                    break;
                case 2: znacky[(this.root + 2) % 12] = "9";
                    break;
                default:
                    break;
            }
            switch (this.Undecima)
            {
                case 0: break;
                case 1: znacky[(this.root + 5) % 12] = "11";
                    break;
                case 2: znacky[(this.root + 6) % 12] = "11#";
                    break;
                default:
                    break;
            }
            switch (this.Tercdecima)
            {
                case 0: break;
                case 1: znacky[(this.root + 8) % 12] = "13b";
                    break;
                case 2: znacky[(this.root + 9) % 12] = "13";
                    break;
                default:
                    break;
            }
            switch (this.Tercie)
            {
                case 0: break;
                case 1: znacky[(this.root + 2) % 12] = "2";
                    break;
                case 2: znacky[(this.root + 3) % 12] = "m3";
                    break;
                case 3: znacky[(this.root + 4) % 12] = "3";
                    break;
                case 4: znacky[(this.root + 5) % 12] = "4";
                    break;
                default:
                    break;
            }
            switch (this.Kvinta)
            {
                case 0: break;
                case 1: znacky[(this.root + 6) % 12] = "5b";
                    break;
                case 2: znacky[(this.root + 7) % 12] = "5";
                    break;
                case 3: znacky[(this.root + 8) % 12] = "5#";
                    break;
                default:
                    break;
            }
            switch (this.Septima)
            {
                case 0: break;
                case 1: znacky[(this.root + 9) % 12] = "6";
                    break;
                case 2: znacky[(this.root + 10) % 12] = "7";
                    break;
                case 3: znacky[(this.root + 11) % 12] = "M7";
                    break;
                default:
                    break;
            }
            if (znacky[this.Bas] == null)
            {
                //pokud je bas v tonu obsazen, nijak se neoznacuje, v opacnem pripade je mu pridelena vlastni znacka
                znacky[this.Bas] = "(B)";
            }

            return znacky;
        }

        public List<int[]> VygenerujPrstoklady()
        {
            //budeme potrebovat pozice tonu na hmatniku, navic vsak take pozice basoveho tonu na hmatniku - potrebujeme ho hledat zvlast

            List<List<int>> tonyNaHmatniku = Hmatnik.NajdiTonyNaHmatniku(this.Tony);

            //funkce NajdiTonyNaHmatniku bere jako argument List<int>, nemuzu predat pouze int (this.Bas), proto si pomuzeme jednoprvkovym Listem
            List<int> basy = new List<int>();
            basy.Add(this.Bas);

            List<List<int>> basyNaHmatniku = Hmatnik.NajdiTonyNaHmatniku(basy);

            //inicializace promennych, ktere se budou rekurzivne predavat
            int[] aktualniPrstoklad = new int[Hmatnik.PocetStrun];
            List<int[]> prstoklady = new List<int[]>();
            int basNaStrune = 0;

            //zavolani rekurzivni funkce s referencne predavanymi parametry
            DalsiStruna(ref tonyNaHmatniku, ref basyNaHmatniku, ref basNaStrune, ref prstoklady, 0, ref aktualniPrstoklad);
            return prstoklady;
        }

        private void DalsiStruna(ref List<List<int>> tonyNaHmatniku, ref List<List<int>> basyNaHmatniku, ref int basNaStrune, ref List<int[]> prstoklady, int aktualniStruna, ref int[] prstoklad)
        {
            List<List<int>> naHmatniku = tonyNaHmatniku;

            //funkce nejprve hleda pouze bas a az po jeho uspesnem nalezeni "prepne" na hledani ostatnich tonu
            if (basNaStrune == aktualniStruna)
                naHmatniku = basyNaHmatniku;

            bool nasel = false;
            for (int i = 0; i < naHmatniku[aktualniStruna].Count() + 1; i++)
            {
                // jeden cyklus navic pro pripad, ze nebyla nalezena vhodna pozice na aktualni strune - tj. 
                // ve vhodne vzdalenosti - v takovem pripade je povoleno zatlumeni struny (pozn.: pro prvni dve struny
                //je zatlumeni povoleno defaultne)
                if (i == naHmatniku[aktualniStruna].Count())
                {
                    if (nasel == false)
                    {
                        prstoklad[aktualniStruna] = -1;
                        if (basNaStrune == aktualniStruna)
                        {
                            //pokud se hledal bas a nenasel se, jeho hledani se presouva na dalsi strunu
                            basNaStrune = aktualniStruna + 1;
                        }
                    }
                    else
                    { break; }
                }
                else
                {
                    //pridame do prstokladu na aktualni pozici vybrany ton
                    prstoklad[aktualniStruna] = naHmatniku[aktualniStruna][i];

                    if (prstoklad[aktualniStruna] == -1)
                    {
                        //nasel se vhodny ton, ale je to -1 tzn. zatlumena nota - hledani basu se presouva o strunu vys
                        //toto nastane pouze u prvnich dvou strun, kde je zatlumeni povoleno explicitne, u ostatnich jen
                        //v pripade, ktery je osetren o par radek vyse
                        if (basNaStrune == aktualniStruna)
                        {
                        basNaStrune = aktualniStruna + 1;
                        }
                    }
                }

                if (JeSmysluplny(prstoklad, aktualniStruna))
                // prorezavani stromu - v prohledavani vetve se pokracuje
                //jen tehdy, pokud akord stale jeste dava smysl
                {
                    nasel = true;
                    if (aktualniStruna < Hmatnik.PocetStrun - 1)
                    {
                        //rekurzivni volani funkce pro dalsi strunu
                        DalsiStruna(ref tonyNaHmatniku, ref basyNaHmatniku, ref basNaStrune, ref prstoklady, aktualniStruna + 1, ref prstoklad);
                    }
                    else
                    //posledni struna, nasli jsme smysluplny prstoklad
                    {
                        //test na obsazeni vsech tonu akordu
                        if (ObsahujeVseCoMa(prstoklad))
                        {
                            //pridani tonu do seznamu prstokladu
                            int[] prstoklad_fin = new int[Hmatnik.PocetStrun]; //nemohu pridat referencne predavanou prommenou, musim vytvorit kopii
                            for (int j = 0; j < Hmatnik.PocetStrun; j++)
                                { prstoklad_fin[j] = prstoklad[j]; }
                            
                            prstoklady.Add(prstoklad_fin);
                        }
                    }
                }
            }
        }

        private bool JeSmysluplny(int[] prstoklad, int aktualniStruna)
        {
            //funkce vyhodnoti smysluplnost (castecneho) akordu
            int[] KPorovnani = new int[aktualniStruna + 1];
            if (aktualniStruna + 1 == prstoklad.Length)
            { 
                KPorovnani = prstoklad; 
            }
            else
            {
                for (int i = 0; i <= aktualniStruna; i++)
                {
                    //vyber relevantnich tonu z castecneho akordu
                    KPorovnani[i] = prstoklad[i];   
                }
            }


            //podminky (zatim jen jedna, moznost rozsireni - napady: akord ma obsahovat jeste ctyri dalsi ruzne tony, zbyvaji uz vsak jen tri struny)
            if (MaxRozptyl(KPorovnani) > MAXROZPETI) { return false; }

            return true;
        }

        private int MaxRozptyl(int[] tony)
        {
            //Funkce vraci meximalni vzdalenost tonu na hmatniku, tj. maximalni pocet prazcu, 
            //pres ktere by bylo treba roztahnout prsty.
            List<int> BezNul = new List<int>();
            for (int i = 0; i < tony.Length; i++)
            {
                //prazdne a zatlumene struny nas nezajimaji
                if (tony[i] > 0)
                { BezNul.Add(tony[i]); }
            }
            try
            { 
                return BezNul.Max() - BezNul.Min(); 
            }
            catch (Exception)
            {
                return 0;
                // vyjimka pro osetreni prazdneho pole BezNul - tj. v akordu jsou same prazdne a zatlumene struny
            }
        }

        private bool ObsahujeVseCoMa(int[] prstoklad)
        {
            //osetri kompletni prstoklad pred vlozenim do seznamu - zkouma tonovou kompletnost

            List<int> tonyVPrstokladu = new List<int>();
            for (int i = 0; i < Hmatnik.PocetStrun; i++)
            {
                if ((prstoklad[i] > -1) && (tonyVPrstokladu.Contains((Hmatnik.GetLadeni(i) + prstoklad[i]) % 12) == false))
                { tonyVPrstokladu.Add((Hmatnik.GetLadeni(i) + prstoklad[i]) % 12); }
            }

            Akord porovnavanyAkord = this;

            //osetreni pripadu, kdy je v akordu vice tonu nez je pocet strun (napr. tercdecimove akordy obsahuji v plnem tvaru 7 tonu)
            if (porovnavanyAkord.Tony.Count() >= Hmatnik.PocetStrun)
            {
                porovnavanyAkord.VypustVhodneTony();
            }

            for (int i = 0; i < porovnavanyAkord.Tony.Count(); i++)
            {
                if (tonyVPrstokladu.Contains(porovnavanyAkord.Tony[i]) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void VypustVhodneTony()
        {
            //u "velkych" akordu povolujeme vypusteni nekterych tonu, avsak podle urcitych pravidel

            int omitted = 0;

            //uzivatelsky nastavena moznost vynechani rootu - ale jen pokud akord neni bez kvinty
            if ((lzeVynechatRoot) && (this.Kvinta > 0))
            {
                this.Tony.Remove(this.root);
                omitted++;
            }

            //cistou kvintu muzu vynechat kdykoliv (pokud jsem jiz nevynechal root)
            if ((this.Kvinta == 2) && (this.Tony.Contains(this.root)))
            {
                this.Tony.Remove((this.root + 7) % 12);
                omitted++;
            }

            //cistou undecimu v 13 muzu vynechat
            if ((this.Tercdecima > 0) && (this.Undecima == 1))
            {
                this.Tony.Remove((this.root + 5) % 12);
                omitted++;
            }

            //cistou devitku v 11 muzu vynechat
            if ((this.Undecima > 0) && (this.Nona == 2))
            {
                this.Tony.Remove((this.root + 2) % 12);
                omitted++;
            }
            //cistou devitku v 13 muzu vynechat
            if ((this.Tercdecima > 0) && (this.Nona == 2))
            {
                this.Tony.Remove((this.root + 2) % 12);
                omitted++;
            }

        }

        public List<int[]> OhodnotPrstoklady(ref List<int[]> vhodnePrstoklady)
        {
            //kazdy prstoklad ohodnoti podle nastavenych kriterii a nasledne je seradi
            List<Prstoklad> prstokladySHodnocenim = new List<Prstoklad>();
            
            //uprava ratingu dle kriterii (pozn. rating = trestne body, cim vyssi tim hur)
            foreach (var prstoklad in vhodnePrstoklady)
            {
                int penalizace = 0;

                //KRITERIA
                //***********************************

                //pozice na hmatniku
                penalizace += prstoklad.Max() * 10;

                //pocet zatlumenych not
                for (int i = 0; i < prstoklad.Length; i++)
                    if (prstoklad[i] == -1)
                        penalizace++;

                //pocet vynechanych not
                List<int> VPrstokladu = new List<int>();
                for (int i = 0; i < Hmatnik.PocetStrun; i++)
                {
                    if ((VPrstokladu.Contains((prstoklad[i] + Hmatnik.GetLadeni(i)) % 12) == false) && (prstoklad[i] > -1))
                    {
                        VPrstokladu.Add((prstoklad[i] + Hmatnik.GetLadeni(i)) % 12);
                    }
                }
                penalizace += (this.Tony.Count - VPrstokladu.Count)*100; //silne kriterium

                prstokladySHodnocenim.Add(new Prstoklad(prstoklad, penalizace));
            }

            //setridi prstoklady podle ratingu
            prstokladySHodnocenim.Sort(new Comparison<Prstoklad>(ComparePrst));
            List<int[]> serazenePrstoklady = new List<int[]>();
            foreach (var item in prstokladySHodnocenim)
                serazenePrstoklady.Add(item.PrazceVPrstokladu);
            return serazenePrstoklady;
        }

        static int ComparePrst(Prstoklad a, Prstoklad b)
        {
            return a.Penalizace.CompareTo(b.Penalizace);
        }
    }
}
