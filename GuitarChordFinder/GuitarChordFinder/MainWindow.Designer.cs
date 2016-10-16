
namespace GuitarChordFinder
{
    partial class GuitarChordFinder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonGeneruj = new System.Windows.Forms.Button();
            this.comboRoot = new System.Windows.Forms.ComboBox();
            this.comboNazev = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vystup = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkVynechRoot = new System.Windows.Forms.CheckBox();
            this.comboBas = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gB_StrukturaAkordu = new System.Windows.Forms.GroupBox();
            this.comboKvinta = new System.Windows.Forms.ComboBox();
            this.comboSeptima = new System.Windows.Forms.ComboBox();
            this.comboNona = new System.Windows.Forms.ComboBox();
            this.comboUndecima = new System.Windows.Forms.ComboBox();
            this.comboTercdecima = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboTercie = new System.Windows.Forms.ComboBox();
            this.gB_NazevAkordu = new System.Windows.Forms.GroupBox();
            this.gB_TonyVAkordu = new System.Windows.Forms.GroupBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.radioStruktura = new System.Windows.Forms.RadioButton();
            this.radioTony = new System.Windows.Forms.RadioButton();
            this.radioNazev = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonDalsi = new System.Windows.Forms.Button();
            this.labelPrazec = new System.Windows.Forms.Label();
            this.buttonPredchozi = new System.Windows.Forms.Button();
            this.labelStruna1 = new System.Windows.Forms.Label();
            this.labelStruna2 = new System.Windows.Forms.Label();
            this.labelStruna3 = new System.Windows.Forms.Label();
            this.labelStruna4 = new System.Windows.Forms.Label();
            this.labelStruna5 = new System.Windows.Forms.Label();
            this.labelStruna6 = new System.Windows.Forms.Label();
            this.labelInterval1 = new System.Windows.Forms.Label();
            this.labelInterval2 = new System.Windows.Forms.Label();
            this.labelInterval3 = new System.Windows.Forms.Label();
            this.labelInterval4 = new System.Windows.Forms.Label();
            this.labelInterval5 = new System.Windows.Forms.Label();
            this.labelInterval6 = new System.Windows.Forms.Label();
            this.UDLadeni1 = new System.Windows.Forms.DomainUpDown();
            this.UDLadeni2 = new System.Windows.Forms.DomainUpDown();
            this.UDLadeni3 = new System.Windows.Forms.DomainUpDown();
            this.UDLadeni4 = new System.Windows.Forms.DomainUpDown();
            this.UDLadeni5 = new System.Windows.Forms.DomainUpDown();
            this.UDLadeni6 = new System.Windows.Forms.DomainUpDown();
            this.BtnDefaultTuning = new System.Windows.Forms.Button();
            this.listOut = new System.Windows.Forms.ListBox();
            this.capoUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gB_StrukturaAkordu.SuspendLayout();
            this.gB_NazevAkordu.SuspendLayout();
            this.gB_TonyVAkordu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.capoUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonGeneruj
            // 
            this.buttonGeneruj.Location = new System.Drawing.Point(109, 56);
            this.buttonGeneruj.Name = "buttonGeneruj";
            this.buttonGeneruj.Size = new System.Drawing.Size(159, 48);
            this.buttonGeneruj.TabIndex = 0;
            this.buttonGeneruj.Text = "Generuj akordy";
            this.buttonGeneruj.UseVisualStyleBackColor = true;
            this.buttonGeneruj.Click += new System.EventHandler(this.buttonGeneruj_Click);
            // 
            // comboRoot
            // 
            this.comboRoot.FormattingEnabled = true;
            this.comboRoot.Items.AddRange(new object[] {
            "C",
            "C#/Db",
            "D",
            "D#/Eb",
            "E",
            "F",
            "F#/Gb",
            "G",
            "G#/Ab",
            "A",
            "B",
            "H"});
            this.comboRoot.Location = new System.Drawing.Point(80, 9);
            this.comboRoot.Name = "comboRoot";
            this.comboRoot.Size = new System.Drawing.Size(61, 21);
            this.comboRoot.TabIndex = 1;
            this.comboRoot.SelectedIndexChanged += new System.EventHandler(this.comboRoot_SelectedIndexChanged);
            // 
            // comboNazev
            // 
            this.comboNazev.FormattingEnabled = true;
            this.comboNazev.Location = new System.Drawing.Point(9, 27);
            this.comboNazev.Name = "comboNazev";
            this.comboNazev.Size = new System.Drawing.Size(70, 21);
            this.comboNazev.TabIndex = 2;
            this.comboNazev.SelectedIndexChanged += new System.EventHandler(this.comboNazev_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Základní tón";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Název";
            // 
            // vystup
            // 
            this.vystup.AutoSize = true;
            this.vystup.Location = new System.Drawing.Point(670, 100);
            this.vystup.Name = "vystup";
            this.vystup.Size = new System.Drawing.Size(31, 13);
            this.vystup.TabIndex = 5;
            this.vystup.Text = "        ";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkVynechRoot);
            this.panel1.Controls.Add(this.comboBas);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.gB_StrukturaAkordu);
            this.panel1.Controls.Add(this.gB_NazevAkordu);
            this.panel1.Controls.Add(this.gB_TonyVAkordu);
            this.panel1.Controls.Add(this.radioStruktura);
            this.panel1.Controls.Add(this.comboRoot);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonGeneruj);
            this.panel1.Controls.Add(this.radioTony);
            this.panel1.Controls.Add(this.radioNazev);
            this.panel1.Location = new System.Drawing.Point(12, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 367);
            this.panel1.TabIndex = 6;
            // 
            // checkVynechRoot
            // 
            this.checkVynechRoot.AutoSize = true;
            this.checkVynechRoot.Location = new System.Drawing.Point(14, 335);
            this.checkVynechRoot.Name = "checkVynechRoot";
            this.checkVynechRoot.Size = new System.Drawing.Size(253, 17);
            this.checkVynechRoot.TabIndex = 20;
            this.checkVynechRoot.Text = "Povolit vynechání základního tónu v prstokladu";
            this.checkVynechRoot.UseVisualStyleBackColor = true;
            // 
            // comboBas
            // 
            this.comboBas.FormattingEnabled = true;
            this.comboBas.Items.AddRange(new object[] {
            "C",
            "C#/Db",
            "D",
            "D#/Eb",
            "E",
            "F",
            "F#/Gb",
            "G",
            "G#/Ab",
            "A",
            "B",
            "H"});
            this.comboBas.Location = new System.Drawing.Point(202, 9);
            this.comboBas.Name = "comboBas";
            this.comboBas.Size = new System.Drawing.Size(57, 21);
            this.comboBas.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(171, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Bas";
            // 
            // gB_StrukturaAkordu
            // 
            this.gB_StrukturaAkordu.Controls.Add(this.comboKvinta);
            this.gB_StrukturaAkordu.Controls.Add(this.comboSeptima);
            this.gB_StrukturaAkordu.Controls.Add(this.comboNona);
            this.gB_StrukturaAkordu.Controls.Add(this.comboUndecima);
            this.gB_StrukturaAkordu.Controls.Add(this.comboTercdecima);
            this.gB_StrukturaAkordu.Controls.Add(this.label9);
            this.gB_StrukturaAkordu.Controls.Add(this.label8);
            this.gB_StrukturaAkordu.Controls.Add(this.label7);
            this.gB_StrukturaAkordu.Controls.Add(this.label6);
            this.gB_StrukturaAkordu.Controls.Add(this.label5);
            this.gB_StrukturaAkordu.Controls.Add(this.label4);
            this.gB_StrukturaAkordu.Controls.Add(this.comboTercie);
            this.gB_StrukturaAkordu.Location = new System.Drawing.Point(109, 127);
            this.gB_StrukturaAkordu.Name = "gB_StrukturaAkordu";
            this.gB_StrukturaAkordu.Size = new System.Drawing.Size(158, 197);
            this.gB_StrukturaAkordu.TabIndex = 17;
            this.gB_StrukturaAkordu.TabStop = false;
            // 
            // comboKvinta
            // 
            this.comboKvinta.FormattingEnabled = true;
            this.comboKvinta.Items.AddRange(new object[] {
            "---",
            "zmenšená",
            "čistá",
            "zvětšená"});
            this.comboKvinta.Location = new System.Drawing.Point(69, 42);
            this.comboKvinta.Name = "comboKvinta";
            this.comboKvinta.Size = new System.Drawing.Size(81, 21);
            this.comboKvinta.TabIndex = 11;
            this.comboKvinta.SelectedIndexChanged += new System.EventHandler(this.comboStruktura_SelectedIndexChanged);
            // 
            // comboSeptima
            // 
            this.comboSeptima.FormattingEnabled = true;
            this.comboSeptima.Items.AddRange(new object[] {
            "---",
            "zmenšená",
            "malá",
            "velká"});
            this.comboSeptima.Location = new System.Drawing.Point(69, 69);
            this.comboSeptima.Name = "comboSeptima";
            this.comboSeptima.Size = new System.Drawing.Size(81, 21);
            this.comboSeptima.TabIndex = 10;
            this.comboSeptima.SelectedIndexChanged += new System.EventHandler(this.comboStruktura_SelectedIndexChanged);
            // 
            // comboNona
            // 
            this.comboNona.FormattingEnabled = true;
            this.comboNona.Items.AddRange(new object[] {
            "---",
            "malá",
            "velká"});
            this.comboNona.Location = new System.Drawing.Point(69, 96);
            this.comboNona.Name = "comboNona";
            this.comboNona.Size = new System.Drawing.Size(81, 21);
            this.comboNona.TabIndex = 9;
            this.comboNona.SelectedIndexChanged += new System.EventHandler(this.comboStruktura_SelectedIndexChanged);
            // 
            // comboUndecima
            // 
            this.comboUndecima.FormattingEnabled = true;
            this.comboUndecima.Items.AddRange(new object[] {
            "---",
            "čistá",
            "zvětšená"});
            this.comboUndecima.Location = new System.Drawing.Point(69, 123);
            this.comboUndecima.Name = "comboUndecima";
            this.comboUndecima.Size = new System.Drawing.Size(81, 21);
            this.comboUndecima.TabIndex = 8;
            this.comboUndecima.SelectedIndexChanged += new System.EventHandler(this.comboStruktura_SelectedIndexChanged);
            // 
            // comboTercdecima
            // 
            this.comboTercdecima.FormattingEnabled = true;
            this.comboTercdecima.Items.AddRange(new object[] {
            "---",
            "malá",
            "velká"});
            this.comboTercdecima.Location = new System.Drawing.Point(69, 150);
            this.comboTercdecima.Name = "comboTercdecima";
            this.comboTercdecima.Size = new System.Drawing.Size(81, 21);
            this.comboTercdecima.TabIndex = 7;
            this.comboTercdecima.SelectedIndexChanged += new System.EventHandler(this.comboStruktura_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "tercdecima";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "undecima";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "nóna";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "septima";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "kvinta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "tercie";
            // 
            // comboTercie
            // 
            this.comboTercie.FormattingEnabled = true;
            this.comboTercie.Items.AddRange(new object[] {
            "---",
            "zmenšená",
            "malá",
            "velká",
            "zvětšená"});
            this.comboTercie.Location = new System.Drawing.Point(69, 15);
            this.comboTercie.Name = "comboTercie";
            this.comboTercie.Size = new System.Drawing.Size(81, 21);
            this.comboTercie.TabIndex = 0;
            this.comboTercie.SelectedIndexChanged += new System.EventHandler(this.comboStruktura_SelectedIndexChanged);
            // 
            // gB_NazevAkordu
            // 
            this.gB_NazevAkordu.Controls.Add(this.comboNazev);
            this.gB_NazevAkordu.Controls.Add(this.label2);
            this.gB_NazevAkordu.Location = new System.Drawing.Point(5, 53);
            this.gB_NazevAkordu.Name = "gB_NazevAkordu";
            this.gB_NazevAkordu.Size = new System.Drawing.Size(97, 55);
            this.gB_NazevAkordu.TabIndex = 5;
            this.gB_NazevAkordu.TabStop = false;
            // 
            // gB_TonyVAkordu
            // 
            this.gB_TonyVAkordu.Controls.Add(this.checkBox12);
            this.gB_TonyVAkordu.Controls.Add(this.checkBox11);
            this.gB_TonyVAkordu.Controls.Add(this.checkBox10);
            this.gB_TonyVAkordu.Controls.Add(this.checkBox9);
            this.gB_TonyVAkordu.Controls.Add(this.checkBox8);
            this.gB_TonyVAkordu.Controls.Add(this.checkBox7);
            this.gB_TonyVAkordu.Controls.Add(this.checkBox6);
            this.gB_TonyVAkordu.Controls.Add(this.checkBox5);
            this.gB_TonyVAkordu.Controls.Add(this.checkBox4);
            this.gB_TonyVAkordu.Controls.Add(this.checkBox3);
            this.gB_TonyVAkordu.Controls.Add(this.checkBox2);
            this.gB_TonyVAkordu.Controls.Add(this.checkBox1);
            this.gB_TonyVAkordu.Location = new System.Drawing.Point(5, 127);
            this.gB_TonyVAkordu.Name = "gB_TonyVAkordu";
            this.gB_TonyVAkordu.Size = new System.Drawing.Size(98, 198);
            this.gB_TonyVAkordu.TabIndex = 16;
            this.gB_TonyVAkordu.TabStop = false;
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.Location = new System.Drawing.Point(9, 177);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(34, 17);
            this.checkBox12.TabIndex = 15;
            this.checkBox12.Text = "H";
            this.checkBox12.UseVisualStyleBackColor = true;
            this.checkBox12.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.Location = new System.Drawing.Point(9, 162);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(33, 17);
            this.checkBox11.TabIndex = 14;
            this.checkBox11.Text = "B";
            this.checkBox11.UseVisualStyleBackColor = true;
            this.checkBox11.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.Location = new System.Drawing.Point(9, 147);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(33, 17);
            this.checkBox10.TabIndex = 13;
            this.checkBox10.Text = "A";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.Location = new System.Drawing.Point(9, 132);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(41, 17);
            this.checkBox9.TabIndex = 12;
            this.checkBox9.Text = "G#";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.Location = new System.Drawing.Point(9, 117);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(34, 17);
            this.checkBox8.TabIndex = 11;
            this.checkBox8.Text = "G";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(9, 102);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(39, 17);
            this.checkBox7.TabIndex = 10;
            this.checkBox7.Text = "F#";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(9, 87);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(32, 17);
            this.checkBox6.TabIndex = 9;
            this.checkBox6.Text = "F";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(9, 72);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(33, 17);
            this.checkBox5.TabIndex = 8;
            this.checkBox5.Text = "E";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(9, 57);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(41, 17);
            this.checkBox4.TabIndex = 7;
            this.checkBox4.Text = "D#";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(9, 42);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(34, 17);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "D";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(9, 27);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(40, 17);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "C#";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(33, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "C";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
            // 
            // radioStruktura
            // 
            this.radioStruktura.AutoSize = true;
            this.radioStruktura.Location = new System.Drawing.Point(109, 112);
            this.radioStruktura.Name = "radioStruktura";
            this.radioStruktura.Size = new System.Drawing.Size(102, 17);
            this.radioStruktura.TabIndex = 3;
            this.radioStruktura.Text = "struktura akordu";
            this.radioStruktura.UseVisualStyleBackColor = true;
            this.radioStruktura.CheckedChanged += new System.EventHandler(this.radioStruktura_CheckedChanged);
            // 
            // radioTony
            // 
            this.radioTony.AutoSize = true;
            this.radioTony.Location = new System.Drawing.Point(5, 112);
            this.radioTony.Name = "radioTony";
            this.radioTony.Size = new System.Drawing.Size(90, 17);
            this.radioTony.TabIndex = 16;
            this.radioTony.Text = "tóny v akordu";
            this.radioTony.UseVisualStyleBackColor = true;
            this.radioTony.CheckedChanged += new System.EventHandler(this.radioTony_CheckedChanged);
            // 
            // radioNazev
            // 
            this.radioNazev.AutoSize = true;
            this.radioNazev.Checked = true;
            this.radioNazev.Location = new System.Drawing.Point(5, 38);
            this.radioNazev.Name = "radioNazev";
            this.radioNazev.Size = new System.Drawing.Size(90, 17);
            this.radioNazev.TabIndex = 2;
            this.radioNazev.TabStop = true;
            this.radioNazev.Text = "název akordu";
            this.radioNazev.UseVisualStyleBackColor = true;
            this.radioNazev.CheckedChanged += new System.EventHandler(this.radioNazev_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Zadejte akord";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::GuitarChordFinder.Properties.Resources.background;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(364, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 307);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // buttonDalsi
            // 
            this.buttonDalsi.Enabled = false;
            this.buttonDalsi.Location = new System.Drawing.Point(571, 100);
            this.buttonDalsi.Name = "buttonDalsi";
            this.buttonDalsi.Size = new System.Drawing.Size(75, 23);
            this.buttonDalsi.TabIndex = 11;
            this.buttonDalsi.Text = "Další";
            this.buttonDalsi.UseVisualStyleBackColor = true;
            this.buttonDalsi.Click += new System.EventHandler(this.buttonDalsi_Click);
            // 
            // labelPrazec
            // 
            this.labelPrazec.AutoSize = true;
            this.labelPrazec.Location = new System.Drawing.Point(303, 121);
            this.labelPrazec.Name = "labelPrazec";
            this.labelPrazec.Size = new System.Drawing.Size(51, 13);
            this.labelPrazec.TabIndex = 12;
            this.labelPrazec.Text = "1. pražec";
            // 
            // buttonPredchozi
            // 
            this.buttonPredchozi.Enabled = false;
            this.buttonPredchozi.Location = new System.Drawing.Point(571, 129);
            this.buttonPredchozi.Name = "buttonPredchozi";
            this.buttonPredchozi.Size = new System.Drawing.Size(75, 23);
            this.buttonPredchozi.TabIndex = 13;
            this.buttonPredchozi.Text = "Předchozí";
            this.buttonPredchozi.UseVisualStyleBackColor = true;
            this.buttonPredchozi.Click += new System.EventHandler(this.buttonPredchozi_Click);
            // 
            // labelStruna1
            // 
            this.labelStruna1.AutoSize = true;
            this.labelStruna1.Location = new System.Drawing.Point(376, 369);
            this.labelStruna1.Name = "labelStruna1";
            this.labelStruna1.Size = new System.Drawing.Size(0, 13);
            this.labelStruna1.TabIndex = 14;
            // 
            // labelStruna2
            // 
            this.labelStruna2.AutoSize = true;
            this.labelStruna2.Location = new System.Drawing.Point(407, 369);
            this.labelStruna2.Name = "labelStruna2";
            this.labelStruna2.Size = new System.Drawing.Size(0, 13);
            this.labelStruna2.TabIndex = 15;
            // 
            // labelStruna3
            // 
            this.labelStruna3.AutoSize = true;
            this.labelStruna3.Location = new System.Drawing.Point(442, 369);
            this.labelStruna3.Name = "labelStruna3";
            this.labelStruna3.Size = new System.Drawing.Size(0, 13);
            this.labelStruna3.TabIndex = 16;
            // 
            // labelStruna4
            // 
            this.labelStruna4.AutoSize = true;
            this.labelStruna4.Location = new System.Drawing.Point(476, 369);
            this.labelStruna4.Name = "labelStruna4";
            this.labelStruna4.Size = new System.Drawing.Size(0, 13);
            this.labelStruna4.TabIndex = 17;
            // 
            // labelStruna5
            // 
            this.labelStruna5.AutoSize = true;
            this.labelStruna5.Location = new System.Drawing.Point(510, 369);
            this.labelStruna5.Name = "labelStruna5";
            this.labelStruna5.Size = new System.Drawing.Size(0, 13);
            this.labelStruna5.TabIndex = 18;
            // 
            // labelStruna6
            // 
            this.labelStruna6.AutoSize = true;
            this.labelStruna6.Location = new System.Drawing.Point(542, 369);
            this.labelStruna6.Name = "labelStruna6";
            this.labelStruna6.Size = new System.Drawing.Size(0, 13);
            this.labelStruna6.TabIndex = 19;
            // 
            // labelInterval1
            // 
            this.labelInterval1.AutoSize = true;
            this.labelInterval1.Location = new System.Drawing.Point(376, 392);
            this.labelInterval1.Name = "labelInterval1";
            this.labelInterval1.Size = new System.Drawing.Size(0, 13);
            this.labelInterval1.TabIndex = 20;
            // 
            // labelInterval2
            // 
            this.labelInterval2.AutoSize = true;
            this.labelInterval2.Location = new System.Drawing.Point(407, 392);
            this.labelInterval2.Name = "labelInterval2";
            this.labelInterval2.Size = new System.Drawing.Size(0, 13);
            this.labelInterval2.TabIndex = 21;
            // 
            // labelInterval3
            // 
            this.labelInterval3.AutoSize = true;
            this.labelInterval3.Location = new System.Drawing.Point(442, 392);
            this.labelInterval3.Name = "labelInterval3";
            this.labelInterval3.Size = new System.Drawing.Size(0, 13);
            this.labelInterval3.TabIndex = 22;
            // 
            // labelInterval4
            // 
            this.labelInterval4.AutoSize = true;
            this.labelInterval4.Location = new System.Drawing.Point(476, 392);
            this.labelInterval4.Name = "labelInterval4";
            this.labelInterval4.Size = new System.Drawing.Size(0, 13);
            this.labelInterval4.TabIndex = 23;
            // 
            // labelInterval5
            // 
            this.labelInterval5.AutoSize = true;
            this.labelInterval5.Location = new System.Drawing.Point(510, 392);
            this.labelInterval5.Name = "labelInterval5";
            this.labelInterval5.Size = new System.Drawing.Size(0, 13);
            this.labelInterval5.TabIndex = 24;
            // 
            // labelInterval6
            // 
            this.labelInterval6.AutoSize = true;
            this.labelInterval6.Location = new System.Drawing.Point(542, 392);
            this.labelInterval6.Name = "labelInterval6";
            this.labelInterval6.Size = new System.Drawing.Size(0, 13);
            this.labelInterval6.TabIndex = 25;
            // 
            // UDLadeni1
            // 
            this.UDLadeni1.BackColor = System.Drawing.SystemColors.Window;
            this.UDLadeni1.Cursor = System.Windows.Forms.Cursors.Default;
            this.UDLadeni1.Items.Add("H");
            this.UDLadeni1.Items.Add("B");
            this.UDLadeni1.Items.Add("A");
            this.UDLadeni1.Items.Add("G#");
            this.UDLadeni1.Items.Add("G");
            this.UDLadeni1.Items.Add("F#");
            this.UDLadeni1.Items.Add("F");
            this.UDLadeni1.Items.Add("E");
            this.UDLadeni1.Items.Add("D#");
            this.UDLadeni1.Items.Add("D");
            this.UDLadeni1.Items.Add("C#");
            this.UDLadeni1.Items.Add("C");
            this.UDLadeni1.Items.Add("H");
            this.UDLadeni1.Items.Add("B");
            this.UDLadeni1.Location = new System.Drawing.Point(364, 26);
            this.UDLadeni1.Name = "UDLadeni1";
            this.UDLadeni1.ReadOnly = true;
            this.UDLadeni1.Size = new System.Drawing.Size(35, 20);
            this.UDLadeni1.TabIndex = 27;
            this.UDLadeni1.SelectedItemChanged += new System.EventHandler(this.UDLadeni_SelectedItemChanged);
            // 
            // UDLadeni2
            // 
            this.UDLadeni2.BackColor = System.Drawing.SystemColors.Window;
            this.UDLadeni2.Cursor = System.Windows.Forms.Cursors.Default;
            this.UDLadeni2.Items.Add("H");
            this.UDLadeni2.Items.Add("B");
            this.UDLadeni2.Items.Add("A");
            this.UDLadeni2.Items.Add("G#");
            this.UDLadeni2.Items.Add("G");
            this.UDLadeni2.Items.Add("F#");
            this.UDLadeni2.Items.Add("F");
            this.UDLadeni2.Items.Add("E");
            this.UDLadeni2.Items.Add("D#");
            this.UDLadeni2.Items.Add("D");
            this.UDLadeni2.Items.Add("C#");
            this.UDLadeni2.Items.Add("C");
            this.UDLadeni2.Items.Add("H");
            this.UDLadeni2.Items.Add("B");
            this.UDLadeni2.Location = new System.Drawing.Point(399, 26);
            this.UDLadeni2.Name = "UDLadeni2";
            this.UDLadeni2.ReadOnly = true;
            this.UDLadeni2.Size = new System.Drawing.Size(35, 20);
            this.UDLadeni2.TabIndex = 29;
            this.UDLadeni2.SelectedItemChanged += new System.EventHandler(this.UDLadeni_SelectedItemChanged);
            // 
            // UDLadeni3
            // 
            this.UDLadeni3.BackColor = System.Drawing.SystemColors.Window;
            this.UDLadeni3.Cursor = System.Windows.Forms.Cursors.Default;
            this.UDLadeni3.Items.Add("H");
            this.UDLadeni3.Items.Add("B");
            this.UDLadeni3.Items.Add("A");
            this.UDLadeni3.Items.Add("G#");
            this.UDLadeni3.Items.Add("G");
            this.UDLadeni3.Items.Add("F#");
            this.UDLadeni3.Items.Add("F");
            this.UDLadeni3.Items.Add("E");
            this.UDLadeni3.Items.Add("D#");
            this.UDLadeni3.Items.Add("D");
            this.UDLadeni3.Items.Add("C#");
            this.UDLadeni3.Items.Add("C");
            this.UDLadeni3.Items.Add("H");
            this.UDLadeni3.Items.Add("B");
            this.UDLadeni3.Location = new System.Drawing.Point(434, 26);
            this.UDLadeni3.Name = "UDLadeni3";
            this.UDLadeni3.ReadOnly = true;
            this.UDLadeni3.Size = new System.Drawing.Size(35, 20);
            this.UDLadeni3.TabIndex = 30;
            this.UDLadeni3.SelectedItemChanged += new System.EventHandler(this.UDLadeni_SelectedItemChanged);
            // 
            // UDLadeni4
            // 
            this.UDLadeni4.BackColor = System.Drawing.SystemColors.Window;
            this.UDLadeni4.Cursor = System.Windows.Forms.Cursors.Default;
            this.UDLadeni4.Items.Add("H");
            this.UDLadeni4.Items.Add("B");
            this.UDLadeni4.Items.Add("A");
            this.UDLadeni4.Items.Add("G#");
            this.UDLadeni4.Items.Add("G");
            this.UDLadeni4.Items.Add("F#");
            this.UDLadeni4.Items.Add("F");
            this.UDLadeni4.Items.Add("E");
            this.UDLadeni4.Items.Add("D#");
            this.UDLadeni4.Items.Add("D");
            this.UDLadeni4.Items.Add("C#");
            this.UDLadeni4.Items.Add("C");
            this.UDLadeni4.Items.Add("H");
            this.UDLadeni4.Items.Add("B");
            this.UDLadeni4.Location = new System.Drawing.Point(469, 26);
            this.UDLadeni4.Name = "UDLadeni4";
            this.UDLadeni4.ReadOnly = true;
            this.UDLadeni4.Size = new System.Drawing.Size(35, 20);
            this.UDLadeni4.TabIndex = 31;
            this.UDLadeni4.SelectedItemChanged += new System.EventHandler(this.UDLadeni_SelectedItemChanged);
            // 
            // UDLadeni5
            // 
            this.UDLadeni5.BackColor = System.Drawing.SystemColors.Window;
            this.UDLadeni5.Cursor = System.Windows.Forms.Cursors.Default;
            this.UDLadeni5.Items.Add("H");
            this.UDLadeni5.Items.Add("B");
            this.UDLadeni5.Items.Add("A");
            this.UDLadeni5.Items.Add("G#");
            this.UDLadeni5.Items.Add("G");
            this.UDLadeni5.Items.Add("F#");
            this.UDLadeni5.Items.Add("F");
            this.UDLadeni5.Items.Add("E");
            this.UDLadeni5.Items.Add("D#");
            this.UDLadeni5.Items.Add("D");
            this.UDLadeni5.Items.Add("C#");
            this.UDLadeni5.Items.Add("C");
            this.UDLadeni5.Items.Add("H");
            this.UDLadeni5.Items.Add("B");
            this.UDLadeni5.Location = new System.Drawing.Point(504, 26);
            this.UDLadeni5.Name = "UDLadeni5";
            this.UDLadeni5.ReadOnly = true;
            this.UDLadeni5.Size = new System.Drawing.Size(35, 20);
            this.UDLadeni5.TabIndex = 32;
            this.UDLadeni5.SelectedItemChanged += new System.EventHandler(this.UDLadeni_SelectedItemChanged);
            // 
            // UDLadeni6
            // 
            this.UDLadeni6.BackColor = System.Drawing.SystemColors.Window;
            this.UDLadeni6.Cursor = System.Windows.Forms.Cursors.Default;
            this.UDLadeni6.Items.Add("H");
            this.UDLadeni6.Items.Add("B");
            this.UDLadeni6.Items.Add("A");
            this.UDLadeni6.Items.Add("G#");
            this.UDLadeni6.Items.Add("G");
            this.UDLadeni6.Items.Add("F#");
            this.UDLadeni6.Items.Add("F");
            this.UDLadeni6.Items.Add("E");
            this.UDLadeni6.Items.Add("D#");
            this.UDLadeni6.Items.Add("D");
            this.UDLadeni6.Items.Add("C#");
            this.UDLadeni6.Items.Add("C");
            this.UDLadeni6.Items.Add("H");
            this.UDLadeni6.Items.Add("B");
            this.UDLadeni6.Location = new System.Drawing.Point(539, 26);
            this.UDLadeni6.Name = "UDLadeni6";
            this.UDLadeni6.ReadOnly = true;
            this.UDLadeni6.Size = new System.Drawing.Size(35, 20);
            this.UDLadeni6.TabIndex = 33;
            this.UDLadeni6.SelectedItemChanged += new System.EventHandler(this.UDLadeni_SelectedItemChanged);
            // 
            // BtnDefaultTuning
            // 
            this.BtnDefaultTuning.Location = new System.Drawing.Point(584, 25);
            this.BtnDefaultTuning.Name = "BtnDefaultTuning";
            this.BtnDefaultTuning.Size = new System.Drawing.Size(117, 23);
            this.BtnDefaultTuning.TabIndex = 34;
            this.BtnDefaultTuning.Text = "Standardní ladění";
            this.BtnDefaultTuning.UseVisualStyleBackColor = true;
            this.BtnDefaultTuning.Click += new System.EventHandler(this.BtnDefaultTuning_Click);
            // 
            // listOut
            // 
            this.listOut.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listOut.FormattingEnabled = true;
            this.listOut.ItemHeight = 14;
            this.listOut.Location = new System.Drawing.Point(652, 57);
            this.listOut.Name = "listOut";
            this.listOut.Size = new System.Drawing.Size(188, 298);
            this.listOut.TabIndex = 36;
            this.listOut.SelectedIndexChanged += new System.EventHandler(this.listOut_SelectedIndexChanged);
            // 
            // capoUpDown
            // 
            this.capoUpDown.Location = new System.Drawing.Point(306, 74);
            this.capoUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.capoUpDown.Name = "capoUpDown";
            this.capoUpDown.Size = new System.Drawing.Size(48, 20);
            this.capoUpDown.TabIndex = 37;
            this.capoUpDown.ValueChanged += new System.EventHandler(this.capoUpDown_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(303, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Kapodastr";
            // 
            // GuitarChordFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(862, 440);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.capoUpDown);
            this.Controls.Add(this.listOut);
            this.Controls.Add(this.BtnDefaultTuning);
            this.Controls.Add(this.UDLadeni6);
            this.Controls.Add(this.UDLadeni5);
            this.Controls.Add(this.UDLadeni4);
            this.Controls.Add(this.UDLadeni3);
            this.Controls.Add(this.UDLadeni2);
            this.Controls.Add(this.UDLadeni1);
            this.Controls.Add(this.labelInterval6);
            this.Controls.Add(this.labelInterval5);
            this.Controls.Add(this.labelInterval4);
            this.Controls.Add(this.labelInterval3);
            this.Controls.Add(this.labelInterval2);
            this.Controls.Add(this.labelInterval1);
            this.Controls.Add(this.labelStruna6);
            this.Controls.Add(this.labelStruna5);
            this.Controls.Add(this.labelStruna4);
            this.Controls.Add(this.labelStruna3);
            this.Controls.Add(this.labelStruna2);
            this.Controls.Add(this.labelStruna1);
            this.Controls.Add(this.buttonPredchozi);
            this.Controls.Add(this.labelPrazec);
            this.Controls.Add(this.buttonDalsi);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.vystup);
            this.Name = "FGenerator";
            this.Text = "Generátor kytarových akordů";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gB_StrukturaAkordu.ResumeLayout(false);
            this.gB_StrukturaAkordu.PerformLayout();
            this.gB_NazevAkordu.ResumeLayout(false);
            this.gB_NazevAkordu.PerformLayout();
            this.gB_TonyVAkordu.ResumeLayout(false);
            this.gB_TonyVAkordu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.capoUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGeneruj;
        private System.Windows.Forms.ComboBox comboRoot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label vystup;
        public System.Windows.Forms.ComboBox comboNazev;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioStruktura;
        private System.Windows.Forms.RadioButton radioNazev;
        private System.Windows.Forms.RadioButton radioTony;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gB_TonyVAkordu;
        private System.Windows.Forms.CheckBox checkBox12;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox gB_NazevAkordu;
        private System.Windows.Forms.GroupBox gB_StrukturaAkordu;
        private System.Windows.Forms.ComboBox comboKvinta;
        private System.Windows.Forms.ComboBox comboSeptima;
        private System.Windows.Forms.ComboBox comboNona;
        private System.Windows.Forms.ComboBox comboUndecima;
        private System.Windows.Forms.ComboBox comboTercdecima;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboTercie;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonDalsi;
        private System.Windows.Forms.Label labelPrazec;
        private System.Windows.Forms.Button buttonPredchozi;
        private System.Windows.Forms.ComboBox comboBas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelStruna1;
        private System.Windows.Forms.Label labelStruna2;
        private System.Windows.Forms.Label labelStruna3;
        private System.Windows.Forms.Label labelStruna4;
        private System.Windows.Forms.Label labelStruna5;
        private System.Windows.Forms.Label labelStruna6;
        private System.Windows.Forms.Label labelInterval1;
        private System.Windows.Forms.Label labelInterval2;
        private System.Windows.Forms.Label labelInterval3;
        private System.Windows.Forms.Label labelInterval4;
        private System.Windows.Forms.Label labelInterval5;
        private System.Windows.Forms.Label labelInterval6;
        private System.Windows.Forms.DomainUpDown UDLadeni1;
        private System.Windows.Forms.DomainUpDown UDLadeni2;
        private System.Windows.Forms.DomainUpDown UDLadeni3;
        private System.Windows.Forms.DomainUpDown UDLadeni4;
        private System.Windows.Forms.DomainUpDown UDLadeni5;
        private System.Windows.Forms.DomainUpDown UDLadeni6;
        private System.Windows.Forms.Button BtnDefaultTuning;
        private System.Windows.Forms.ListBox listOut;
        private System.Windows.Forms.NumericUpDown capoUpDown;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.CheckBox checkVynechRoot;
    }
}

