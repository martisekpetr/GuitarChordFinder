
namespace GuitarChordFinder
{
    partial class GuitarChordFinderGUI
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
			this.btnFind = new System.Windows.Forms.Button();
			this.comboRoot = new System.Windows.Forms.ComboBox();
			this.comboChordName = new System.Windows.Forms.ComboBox();
			this.lblRoot = new System.Windows.Forms.Label();
			this.lblChordName = new System.Windows.Forms.Label();
			this.output = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.checkOmitRoot = new System.Windows.Forms.CheckBox();
			this.comboBass = new System.Windows.Forms.ComboBox();
			this.lblBassNote = new System.Windows.Forms.Label();
			this.groupChordStructure = new System.Windows.Forms.GroupBox();
			this.comboFifth = new System.Windows.Forms.ComboBox();
			this.comboSeventh = new System.Windows.Forms.ComboBox();
			this.comboNinth = new System.Windows.Forms.ComboBox();
			this.comboEleventh = new System.Windows.Forms.ComboBox();
			this.comboThirteenth = new System.Windows.Forms.ComboBox();
			this.lblThirteenth = new System.Windows.Forms.Label();
			this.lblEleventh = new System.Windows.Forms.Label();
			this.lblNinth = new System.Windows.Forms.Label();
			this.lblSeventh = new System.Windows.Forms.Label();
			this.lblFifth = new System.Windows.Forms.Label();
			this.lblThird = new System.Windows.Forms.Label();
			this.comboThird = new System.Windows.Forms.ComboBox();
			this.groupChordName = new System.Windows.Forms.GroupBox();
			this.groupChordNotes = new System.Windows.Forms.GroupBox();
			this.checkB = new System.Windows.Forms.CheckBox();
			this.checkAs = new System.Windows.Forms.CheckBox();
			this.checkA = new System.Windows.Forms.CheckBox();
			this.checkGs = new System.Windows.Forms.CheckBox();
			this.checkG = new System.Windows.Forms.CheckBox();
			this.checkFs = new System.Windows.Forms.CheckBox();
			this.checkF = new System.Windows.Forms.CheckBox();
			this.checkE = new System.Windows.Forms.CheckBox();
			this.checkDs = new System.Windows.Forms.CheckBox();
			this.checkD = new System.Windows.Forms.CheckBox();
			this.checkCs = new System.Windows.Forms.CheckBox();
			this.checkC = new System.Windows.Forms.CheckBox();
			this.radioStructure = new System.Windows.Forms.RadioButton();
			this.radioChordNotes = new System.Windows.Forms.RadioButton();
			this.radioName = new System.Windows.Forms.RadioButton();
			this.lblEnterChord = new System.Windows.Forms.Label();
			this.picBoxFretboard = new System.Windows.Forms.PictureBox();
			this.btnNext = new System.Windows.Forms.Button();
			this.lblFret = new System.Windows.Forms.Label();
			this.btnPrevious = new System.Windows.Forms.Button();
			this.labelString1 = new System.Windows.Forms.Label();
			this.labelString2 = new System.Windows.Forms.Label();
			this.labelString3 = new System.Windows.Forms.Label();
			this.labelString4 = new System.Windows.Forms.Label();
			this.labelString5 = new System.Windows.Forms.Label();
			this.labelString6 = new System.Windows.Forms.Label();
			this.labelInterval1 = new System.Windows.Forms.Label();
			this.labelInterval2 = new System.Windows.Forms.Label();
			this.labelInterval3 = new System.Windows.Forms.Label();
			this.labelInterval4 = new System.Windows.Forms.Label();
			this.labelInterval5 = new System.Windows.Forms.Label();
			this.labelInterval6 = new System.Windows.Forms.Label();
			this.UDTuning1 = new System.Windows.Forms.DomainUpDown();
			this.UDTuning2 = new System.Windows.Forms.DomainUpDown();
			this.UDTuning3 = new System.Windows.Forms.DomainUpDown();
			this.UDTuning4 = new System.Windows.Forms.DomainUpDown();
			this.UDTuning5 = new System.Windows.Forms.DomainUpDown();
			this.UDTuning6 = new System.Windows.Forms.DomainUpDown();
			this.btnDefaultTuning = new System.Windows.Forms.Button();
			this.listAlternativeFingerings = new System.Windows.Forms.ListBox();
			this.capoLocation = new System.Windows.Forms.NumericUpDown();
			this.lblCapo = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.groupChordStructure.SuspendLayout();
			this.groupChordName.SuspendLayout();
			this.groupChordNotes.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBoxFretboard)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.capoLocation)).BeginInit();
			this.SuspendLayout();
			// 
			// btnFind
			// 
			this.btnFind.Location = new System.Drawing.Point(145, 69);
			this.btnFind.Margin = new System.Windows.Forms.Padding(4);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(212, 59);
			this.btnFind.TabIndex = 0;
			this.btnFind.Text = "Find chords!";
			this.btnFind.UseVisualStyleBackColor = true;
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
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
			this.comboRoot.Location = new System.Drawing.Point(58, 11);
			this.comboRoot.Margin = new System.Windows.Forms.Padding(4);
			this.comboRoot.Name = "comboRoot";
			this.comboRoot.Size = new System.Drawing.Size(80, 24);
			this.comboRoot.TabIndex = 1;
			this.comboRoot.SelectedIndexChanged += new System.EventHandler(this.comboRoot_SelectedIndexChanged);
			// 
			// comboChordName
			// 
			this.comboChordName.FormattingEnabled = true;
			this.comboChordName.Location = new System.Drawing.Point(12, 33);
			this.comboChordName.Margin = new System.Windows.Forms.Padding(4);
			this.comboChordName.Name = "comboChordName";
			this.comboChordName.Size = new System.Drawing.Size(92, 24);
			this.comboChordName.TabIndex = 2;
			this.comboChordName.SelectedIndexChanged += new System.EventHandler(this.comboChordName_SelectedIndexChanged);
			// 
			// lblRoot
			// 
			this.lblRoot.AutoSize = true;
			this.lblRoot.Location = new System.Drawing.Point(4, 14);
			this.lblRoot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblRoot.Name = "lblRoot";
			this.lblRoot.Size = new System.Drawing.Size(37, 16);
			this.lblRoot.TabIndex = 3;
			this.lblRoot.Text = "Root";
			// 
			// lblChordName
			// 
			this.lblChordName.AutoSize = true;
			this.lblChordName.Location = new System.Drawing.Point(8, 14);
			this.lblChordName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblChordName.Name = "lblChordName";
			this.lblChordName.Size = new System.Drawing.Size(95, 16);
			this.lblChordName.TabIndex = 4;
			this.lblChordName.Text = "Choose name:";
			// 
			// output
			// 
			this.output.AutoSize = true;
			this.output.Location = new System.Drawing.Point(893, 123);
			this.output.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.output.Name = "output";
			this.output.Size = new System.Drawing.Size(32, 16);
			this.output.TabIndex = 5;
			this.output.Text = "        ";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.checkOmitRoot);
			this.panel1.Controls.Add(this.comboBass);
			this.panel1.Controls.Add(this.lblBassNote);
			this.panel1.Controls.Add(this.groupChordStructure);
			this.panel1.Controls.Add(this.groupChordName);
			this.panel1.Controls.Add(this.groupChordNotes);
			this.panel1.Controls.Add(this.radioStructure);
			this.panel1.Controls.Add(this.comboRoot);
			this.panel1.Controls.Add(this.lblRoot);
			this.panel1.Controls.Add(this.btnFind);
			this.panel1.Controls.Add(this.radioChordNotes);
			this.panel1.Controls.Add(this.radioName);
			this.panel1.Location = new System.Drawing.Point(16, 31);
			this.panel1.Margin = new System.Windows.Forms.Padding(4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(366, 451);
			this.panel1.TabIndex = 6;
			// 
			// checkOmitRoot
			// 
			this.checkOmitRoot.AutoSize = true;
			this.checkOmitRoot.Location = new System.Drawing.Point(19, 412);
			this.checkOmitRoot.Margin = new System.Windows.Forms.Padding(4);
			this.checkOmitRoot.Name = "checkOmitRoot";
			this.checkOmitRoot.Size = new System.Drawing.Size(246, 20);
			this.checkOmitRoot.TabIndex = 20;
			this.checkOmitRoot.Text = "Allow omitting the root in the fingering.";
			this.checkOmitRoot.UseVisualStyleBackColor = true;
			// 
			// comboBass
			// 
			this.comboBass.FormattingEnabled = true;
			this.comboBass.Items.AddRange(new object[] {
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
			this.comboBass.Location = new System.Drawing.Point(237, 11);
			this.comboBass.Margin = new System.Windows.Forms.Padding(4);
			this.comboBass.Name = "comboBass";
			this.comboBass.Size = new System.Drawing.Size(90, 24);
			this.comboBass.TabIndex = 19;
			// 
			// lblBassNote
			// 
			this.lblBassNote.AutoSize = true;
			this.lblBassNote.Location = new System.Drawing.Point(156, 14);
			this.lblBassNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblBassNote.Name = "lblBassNote";
			this.lblBassNote.Size = new System.Drawing.Size(68, 16);
			this.lblBassNote.TabIndex = 18;
			this.lblBassNote.Text = "Bass note";
			// 
			// groupChordStructure
			// 
			this.groupChordStructure.Controls.Add(this.comboFifth);
			this.groupChordStructure.Controls.Add(this.comboSeventh);
			this.groupChordStructure.Controls.Add(this.comboNinth);
			this.groupChordStructure.Controls.Add(this.comboEleventh);
			this.groupChordStructure.Controls.Add(this.comboThirteenth);
			this.groupChordStructure.Controls.Add(this.lblThirteenth);
			this.groupChordStructure.Controls.Add(this.lblEleventh);
			this.groupChordStructure.Controls.Add(this.lblNinth);
			this.groupChordStructure.Controls.Add(this.lblSeventh);
			this.groupChordStructure.Controls.Add(this.lblFifth);
			this.groupChordStructure.Controls.Add(this.lblThird);
			this.groupChordStructure.Controls.Add(this.comboThird);
			this.groupChordStructure.Location = new System.Drawing.Point(145, 156);
			this.groupChordStructure.Margin = new System.Windows.Forms.Padding(4);
			this.groupChordStructure.Name = "groupChordStructure";
			this.groupChordStructure.Padding = new System.Windows.Forms.Padding(4);
			this.groupChordStructure.Size = new System.Drawing.Size(211, 242);
			this.groupChordStructure.TabIndex = 17;
			this.groupChordStructure.TabStop = false;
			// 
			// comboFifth
			// 
			this.comboFifth.FormattingEnabled = true;
			this.comboFifth.Items.AddRange(new object[] {
            "---",
            "diminished",
            "perfect",
            "augmented"});
			this.comboFifth.Location = new System.Drawing.Point(92, 52);
			this.comboFifth.Margin = new System.Windows.Forms.Padding(4);
			this.comboFifth.Name = "comboFifth";
			this.comboFifth.Size = new System.Drawing.Size(107, 24);
			this.comboFifth.TabIndex = 11;
			this.comboFifth.SelectedIndexChanged += new System.EventHandler(this.comboStruktura_SelectedIndexChanged);
			// 
			// comboSeventh
			// 
			this.comboSeventh.FormattingEnabled = true;
			this.comboSeventh.Items.AddRange(new object[] {
            "---",
            "diminished",
            "minor",
            "major"});
			this.comboSeventh.Location = new System.Drawing.Point(92, 85);
			this.comboSeventh.Margin = new System.Windows.Forms.Padding(4);
			this.comboSeventh.Name = "comboSeventh";
			this.comboSeventh.Size = new System.Drawing.Size(107, 24);
			this.comboSeventh.TabIndex = 10;
			this.comboSeventh.SelectedIndexChanged += new System.EventHandler(this.comboStruktura_SelectedIndexChanged);
			// 
			// comboNinth
			// 
			this.comboNinth.FormattingEnabled = true;
			this.comboNinth.Items.AddRange(new object[] {
            "---",
            "minor",
            "major"});
			this.comboNinth.Location = new System.Drawing.Point(92, 118);
			this.comboNinth.Margin = new System.Windows.Forms.Padding(4);
			this.comboNinth.Name = "comboNinth";
			this.comboNinth.Size = new System.Drawing.Size(107, 24);
			this.comboNinth.TabIndex = 9;
			this.comboNinth.SelectedIndexChanged += new System.EventHandler(this.comboStruktura_SelectedIndexChanged);
			// 
			// comboEleventh
			// 
			this.comboEleventh.FormattingEnabled = true;
			this.comboEleventh.Items.AddRange(new object[] {
            "---",
            "perfect",
            "augmented"});
			this.comboEleventh.Location = new System.Drawing.Point(92, 151);
			this.comboEleventh.Margin = new System.Windows.Forms.Padding(4);
			this.comboEleventh.Name = "comboEleventh";
			this.comboEleventh.Size = new System.Drawing.Size(107, 24);
			this.comboEleventh.TabIndex = 8;
			this.comboEleventh.SelectedIndexChanged += new System.EventHandler(this.comboStruktura_SelectedIndexChanged);
			// 
			// comboThirteenth
			// 
			this.comboThirteenth.FormattingEnabled = true;
			this.comboThirteenth.Items.AddRange(new object[] {
            "---",
            "minor",
            "major"});
			this.comboThirteenth.Location = new System.Drawing.Point(92, 185);
			this.comboThirteenth.Margin = new System.Windows.Forms.Padding(4);
			this.comboThirteenth.Name = "comboThirteenth";
			this.comboThirteenth.Size = new System.Drawing.Size(107, 24);
			this.comboThirteenth.TabIndex = 7;
			this.comboThirteenth.SelectedIndexChanged += new System.EventHandler(this.comboStruktura_SelectedIndexChanged);
			// 
			// lblThirteenth
			// 
			this.lblThirteenth.AutoSize = true;
			this.lblThirteenth.Location = new System.Drawing.Point(11, 188);
			this.lblThirteenth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblThirteenth.Name = "lblThirteenth";
			this.lblThirteenth.Size = new System.Drawing.Size(61, 16);
			this.lblThirteenth.TabIndex = 6;
			this.lblThirteenth.Text = "thirteenth";
			// 
			// lblEleventh
			// 
			this.lblEleventh.AutoSize = true;
			this.lblEleventh.Location = new System.Drawing.Point(11, 154);
			this.lblEleventh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblEleventh.Name = "lblEleventh";
			this.lblEleventh.Size = new System.Drawing.Size(59, 16);
			this.lblEleventh.TabIndex = 5;
			this.lblEleventh.Text = "eleventh";
			// 
			// lblNinth
			// 
			this.lblNinth.AutoSize = true;
			this.lblNinth.Location = new System.Drawing.Point(11, 121);
			this.lblNinth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblNinth.Name = "lblNinth";
			this.lblNinth.Size = new System.Drawing.Size(35, 16);
			this.lblNinth.TabIndex = 4;
			this.lblNinth.Text = "ninth";
			// 
			// lblSeventh
			// 
			this.lblSeventh.AutoSize = true;
			this.lblSeventh.Location = new System.Drawing.Point(11, 88);
			this.lblSeventh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblSeventh.Name = "lblSeventh";
			this.lblSeventh.Size = new System.Drawing.Size(55, 16);
			this.lblSeventh.TabIndex = 3;
			this.lblSeventh.Text = "seventh";
			// 
			// lblFifth
			// 
			this.lblFifth.AutoSize = true;
			this.lblFifth.Location = new System.Drawing.Point(11, 55);
			this.lblFifth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblFifth.Name = "lblFifth";
			this.lblFifth.Size = new System.Drawing.Size(27, 16);
			this.lblFifth.TabIndex = 2;
			this.lblFifth.Text = "fifth";
			// 
			// lblThird
			// 
			this.lblThird.AutoSize = true;
			this.lblThird.Location = new System.Drawing.Point(11, 21);
			this.lblThird.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblThird.Name = "lblThird";
			this.lblThird.Size = new System.Drawing.Size(33, 16);
			this.lblThird.TabIndex = 1;
			this.lblThird.Text = "third";
			// 
			// comboThird
			// 
			this.comboThird.FormattingEnabled = true;
			this.comboThird.Items.AddRange(new object[] {
            "---",
            "dimished",
            "minor",
            "major",
            "augmented"});
			this.comboThird.Location = new System.Drawing.Point(92, 18);
			this.comboThird.Margin = new System.Windows.Forms.Padding(4);
			this.comboThird.Name = "comboThird";
			this.comboThird.Size = new System.Drawing.Size(107, 24);
			this.comboThird.TabIndex = 0;
			this.comboThird.SelectedIndexChanged += new System.EventHandler(this.comboStruktura_SelectedIndexChanged);
			// 
			// groupChordName
			// 
			this.groupChordName.Controls.Add(this.comboChordName);
			this.groupChordName.Controls.Add(this.lblChordName);
			this.groupChordName.Location = new System.Drawing.Point(7, 65);
			this.groupChordName.Margin = new System.Windows.Forms.Padding(4);
			this.groupChordName.Name = "groupChordName";
			this.groupChordName.Padding = new System.Windows.Forms.Padding(4);
			this.groupChordName.Size = new System.Drawing.Size(129, 68);
			this.groupChordName.TabIndex = 5;
			this.groupChordName.TabStop = false;
			// 
			// groupChordNotes
			// 
			this.groupChordNotes.Controls.Add(this.checkB);
			this.groupChordNotes.Controls.Add(this.checkAs);
			this.groupChordNotes.Controls.Add(this.checkA);
			this.groupChordNotes.Controls.Add(this.checkGs);
			this.groupChordNotes.Controls.Add(this.checkG);
			this.groupChordNotes.Controls.Add(this.checkFs);
			this.groupChordNotes.Controls.Add(this.checkF);
			this.groupChordNotes.Controls.Add(this.checkE);
			this.groupChordNotes.Controls.Add(this.checkDs);
			this.groupChordNotes.Controls.Add(this.checkD);
			this.groupChordNotes.Controls.Add(this.checkCs);
			this.groupChordNotes.Controls.Add(this.checkC);
			this.groupChordNotes.Location = new System.Drawing.Point(7, 156);
			this.groupChordNotes.Margin = new System.Windows.Forms.Padding(4);
			this.groupChordNotes.Name = "groupChordNotes";
			this.groupChordNotes.Padding = new System.Windows.Forms.Padding(4);
			this.groupChordNotes.Size = new System.Drawing.Size(131, 244);
			this.groupChordNotes.TabIndex = 16;
			this.groupChordNotes.TabStop = false;
			// 
			// checkB
			// 
			this.checkB.AutoSize = true;
			this.checkB.Location = new System.Drawing.Point(12, 218);
			this.checkB.Margin = new System.Windows.Forms.Padding(4);
			this.checkB.Name = "checkB";
			this.checkB.Size = new System.Drawing.Size(36, 20);
			this.checkB.TabIndex = 15;
			this.checkB.Text = "B";
			this.checkB.UseVisualStyleBackColor = true;
			this.checkB.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// checkAs
			// 
			this.checkAs.AutoSize = true;
			this.checkAs.Location = new System.Drawing.Point(12, 199);
			this.checkAs.Margin = new System.Windows.Forms.Padding(4);
			this.checkAs.Name = "checkAs";
			this.checkAs.Size = new System.Drawing.Size(64, 20);
			this.checkAs.TabIndex = 14;
			this.checkAs.Text = "A#/Bb";
			this.checkAs.UseVisualStyleBackColor = true;
			this.checkAs.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// checkA
			// 
			this.checkA.AutoSize = true;
			this.checkA.Location = new System.Drawing.Point(12, 181);
			this.checkA.Margin = new System.Windows.Forms.Padding(4);
			this.checkA.Name = "checkA";
			this.checkA.Size = new System.Drawing.Size(36, 20);
			this.checkA.TabIndex = 13;
			this.checkA.Text = "A";
			this.checkA.UseVisualStyleBackColor = true;
			this.checkA.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// checkGs
			// 
			this.checkGs.AutoSize = true;
			this.checkGs.Location = new System.Drawing.Point(12, 162);
			this.checkGs.Margin = new System.Windows.Forms.Padding(4);
			this.checkGs.Name = "checkGs";
			this.checkGs.Size = new System.Drawing.Size(65, 20);
			this.checkGs.TabIndex = 12;
			this.checkGs.Text = "G#/Ab";
			this.checkGs.UseVisualStyleBackColor = true;
			this.checkGs.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// checkG
			// 
			this.checkG.AutoSize = true;
			this.checkG.Location = new System.Drawing.Point(12, 144);
			this.checkG.Margin = new System.Windows.Forms.Padding(4);
			this.checkG.Name = "checkG";
			this.checkG.Size = new System.Drawing.Size(37, 20);
			this.checkG.TabIndex = 11;
			this.checkG.Text = "G";
			this.checkG.UseVisualStyleBackColor = true;
			this.checkG.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// checkFs
			// 
			this.checkFs.AutoSize = true;
			this.checkFs.Location = new System.Drawing.Point(12, 126);
			this.checkFs.Margin = new System.Windows.Forms.Padding(4);
			this.checkFs.Name = "checkFs";
			this.checkFs.Size = new System.Drawing.Size(64, 20);
			this.checkFs.TabIndex = 10;
			this.checkFs.Text = "F#/Gb";
			this.checkFs.UseVisualStyleBackColor = true;
			this.checkFs.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// checkF
			// 
			this.checkF.AutoSize = true;
			this.checkF.Location = new System.Drawing.Point(12, 107);
			this.checkF.Margin = new System.Windows.Forms.Padding(4);
			this.checkF.Name = "checkF";
			this.checkF.Size = new System.Drawing.Size(35, 20);
			this.checkF.TabIndex = 9;
			this.checkF.Text = "F";
			this.checkF.UseVisualStyleBackColor = true;
			this.checkF.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// checkE
			// 
			this.checkE.AutoSize = true;
			this.checkE.Location = new System.Drawing.Point(12, 89);
			this.checkE.Margin = new System.Windows.Forms.Padding(4);
			this.checkE.Name = "checkE";
			this.checkE.Size = new System.Drawing.Size(36, 20);
			this.checkE.TabIndex = 8;
			this.checkE.Text = "E";
			this.checkE.UseVisualStyleBackColor = true;
			this.checkE.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// checkDs
			// 
			this.checkDs.AutoSize = true;
			this.checkDs.Location = new System.Drawing.Point(12, 70);
			this.checkDs.Margin = new System.Windows.Forms.Padding(4);
			this.checkDs.Name = "checkDs";
			this.checkDs.Size = new System.Drawing.Size(65, 20);
			this.checkDs.TabIndex = 7;
			this.checkDs.Text = "D#/Eb";
			this.checkDs.UseVisualStyleBackColor = true;
			this.checkDs.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// checkD
			// 
			this.checkD.AutoSize = true;
			this.checkD.Location = new System.Drawing.Point(12, 52);
			this.checkD.Margin = new System.Windows.Forms.Padding(4);
			this.checkD.Name = "checkD";
			this.checkD.Size = new System.Drawing.Size(37, 20);
			this.checkD.TabIndex = 6;
			this.checkD.Text = "D";
			this.checkD.UseVisualStyleBackColor = true;
			this.checkD.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// checkCs
			// 
			this.checkCs.AutoSize = true;
			this.checkCs.Location = new System.Drawing.Point(12, 33);
			this.checkCs.Margin = new System.Windows.Forms.Padding(4);
			this.checkCs.Name = "checkCs";
			this.checkCs.Size = new System.Drawing.Size(65, 20);
			this.checkCs.TabIndex = 5;
			this.checkCs.Text = "C#/Db";
			this.checkCs.UseVisualStyleBackColor = true;
			this.checkCs.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// checkC
			// 
			this.checkC.AutoSize = true;
			this.checkC.Location = new System.Drawing.Point(12, 15);
			this.checkC.Margin = new System.Windows.Forms.Padding(4);
			this.checkC.Name = "checkC";
			this.checkC.Size = new System.Drawing.Size(36, 20);
			this.checkC.TabIndex = 4;
			this.checkC.Text = "C";
			this.checkC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.checkC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.checkC.UseVisualStyleBackColor = true;
			this.checkC.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// radioStructure
			// 
			this.radioStructure.AutoSize = true;
			this.radioStructure.Location = new System.Drawing.Point(145, 138);
			this.radioStructure.Margin = new System.Windows.Forms.Padding(4);
			this.radioStructure.Name = "radioStructure";
			this.radioStructure.Size = new System.Drawing.Size(137, 20);
			this.radioStructure.TabIndex = 3;
			this.radioStructure.Text = "Describe structure:";
			this.radioStructure.UseVisualStyleBackColor = true;
			this.radioStructure.CheckedChanged += new System.EventHandler(this.radioStructure_CheckedChanged);
			// 
			// radioChordNotes
			// 
			this.radioChordNotes.AutoSize = true;
			this.radioChordNotes.Location = new System.Drawing.Point(7, 138);
			this.radioChordNotes.Margin = new System.Windows.Forms.Padding(4);
			this.radioChordNotes.Name = "radioChordNotes";
			this.radioChordNotes.Size = new System.Drawing.Size(128, 20);
			this.radioChordNotes.TabIndex = 16;
			this.radioChordNotes.Text = "Specify by notes:";
			this.radioChordNotes.UseVisualStyleBackColor = true;
			this.radioChordNotes.CheckedChanged += new System.EventHandler(this.radioChordNotes_CheckedChanged);
			// 
			// radioName
			// 
			this.radioName.AutoSize = true;
			this.radioName.Checked = true;
			this.radioName.Location = new System.Drawing.Point(7, 47);
			this.radioName.Margin = new System.Windows.Forms.Padding(4);
			this.radioName.Name = "radioName";
			this.radioName.Size = new System.Drawing.Size(131, 20);
			this.radioName.TabIndex = 2;
			this.radioName.TabStop = true;
			this.radioName.Text = "Choose by name:";
			this.radioName.UseVisualStyleBackColor = true;
			this.radioName.CheckedChanged += new System.EventHandler(this.radioName_CheckedChanged);
			// 
			// lblEnterChord
			// 
			this.lblEnterChord.AutoSize = true;
			this.lblEnterChord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblEnterChord.Location = new System.Drawing.Point(16, 11);
			this.lblEnterChord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblEnterChord.Name = "lblEnterChord";
			this.lblEnterChord.Size = new System.Drawing.Size(95, 13);
			this.lblEnterChord.TabIndex = 7;
			this.lblEnterChord.Text = "Enter the chord";
			// 
			// picBoxFretboard
			// 
			this.picBoxFretboard.BackgroundImage = global::GuitarChordFinder.Properties.Resources.background;
			this.picBoxFretboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picBoxFretboard.Location = new System.Drawing.Point(485, 70);
			this.picBoxFretboard.Margin = new System.Windows.Forms.Padding(4);
			this.picBoxFretboard.Name = "picBoxFretboard";
			this.picBoxFretboard.Size = new System.Drawing.Size(267, 377);
			this.picBoxFretboard.TabIndex = 8;
			this.picBoxFretboard.TabStop = false;
			// 
			// btnNext
			// 
			this.btnNext.Enabled = false;
			this.btnNext.Location = new System.Drawing.Point(761, 203);
			this.btnNext.Margin = new System.Windows.Forms.Padding(4);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(100, 57);
			this.btnNext.TabIndex = 11;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// lblFret
			// 
			this.lblFret.AutoSize = true;
			this.lblFret.Location = new System.Drawing.Point(405, 144);
			this.lblFret.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblFret.Name = "lblFret";
			this.lblFret.Size = new System.Drawing.Size(41, 16);
			this.lblFret.TabIndex = 12;
			this.lblFret.Text = "Fret 1";
			// 
			// btnPrevious
			// 
			this.btnPrevious.Enabled = false;
			this.btnPrevious.Location = new System.Drawing.Point(761, 130);
			this.btnPrevious.Margin = new System.Windows.Forms.Padding(4);
			this.btnPrevious.Name = "btnPrevious";
			this.btnPrevious.Size = new System.Drawing.Size(100, 57);
			this.btnPrevious.TabIndex = 13;
			this.btnPrevious.Text = "Previous";
			this.btnPrevious.UseVisualStyleBackColor = true;
			this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
			// 
			// labelString1
			// 
			this.labelString1.AutoSize = true;
			this.labelString1.Location = new System.Drawing.Point(501, 454);
			this.labelString1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelString1.Name = "labelString1";
			this.labelString1.Size = new System.Drawing.Size(0, 16);
			this.labelString1.TabIndex = 14;
			// 
			// labelString2
			// 
			this.labelString2.AutoSize = true;
			this.labelString2.Location = new System.Drawing.Point(543, 454);
			this.labelString2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelString2.Name = "labelString2";
			this.labelString2.Size = new System.Drawing.Size(0, 16);
			this.labelString2.TabIndex = 15;
			// 
			// labelString3
			// 
			this.labelString3.AutoSize = true;
			this.labelString3.Location = new System.Drawing.Point(589, 454);
			this.labelString3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelString3.Name = "labelString3";
			this.labelString3.Size = new System.Drawing.Size(0, 16);
			this.labelString3.TabIndex = 16;
			// 
			// labelString4
			// 
			this.labelString4.AutoSize = true;
			this.labelString4.Location = new System.Drawing.Point(635, 454);
			this.labelString4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelString4.Name = "labelString4";
			this.labelString4.Size = new System.Drawing.Size(0, 16);
			this.labelString4.TabIndex = 17;
			// 
			// labelString5
			// 
			this.labelString5.AutoSize = true;
			this.labelString5.Location = new System.Drawing.Point(680, 454);
			this.labelString5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelString5.Name = "labelString5";
			this.labelString5.Size = new System.Drawing.Size(0, 16);
			this.labelString5.TabIndex = 18;
			// 
			// labelString6
			// 
			this.labelString6.AutoSize = true;
			this.labelString6.Location = new System.Drawing.Point(723, 454);
			this.labelString6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelString6.Name = "labelString6";
			this.labelString6.Size = new System.Drawing.Size(0, 16);
			this.labelString6.TabIndex = 19;
			// 
			// labelInterval1
			// 
			this.labelInterval1.AutoSize = true;
			this.labelInterval1.Location = new System.Drawing.Point(501, 482);
			this.labelInterval1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelInterval1.Name = "labelInterval1";
			this.labelInterval1.Size = new System.Drawing.Size(0, 16);
			this.labelInterval1.TabIndex = 20;
			// 
			// labelInterval2
			// 
			this.labelInterval2.AutoSize = true;
			this.labelInterval2.Location = new System.Drawing.Point(543, 482);
			this.labelInterval2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelInterval2.Name = "labelInterval2";
			this.labelInterval2.Size = new System.Drawing.Size(0, 16);
			this.labelInterval2.TabIndex = 21;
			// 
			// labelInterval3
			// 
			this.labelInterval3.AutoSize = true;
			this.labelInterval3.Location = new System.Drawing.Point(589, 482);
			this.labelInterval3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelInterval3.Name = "labelInterval3";
			this.labelInterval3.Size = new System.Drawing.Size(0, 16);
			this.labelInterval3.TabIndex = 22;
			// 
			// labelInterval4
			// 
			this.labelInterval4.AutoSize = true;
			this.labelInterval4.Location = new System.Drawing.Point(635, 482);
			this.labelInterval4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelInterval4.Name = "labelInterval4";
			this.labelInterval4.Size = new System.Drawing.Size(0, 16);
			this.labelInterval4.TabIndex = 23;
			// 
			// labelInterval5
			// 
			this.labelInterval5.AutoSize = true;
			this.labelInterval5.Location = new System.Drawing.Point(680, 482);
			this.labelInterval5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelInterval5.Name = "labelInterval5";
			this.labelInterval5.Size = new System.Drawing.Size(0, 16);
			this.labelInterval5.TabIndex = 24;
			// 
			// labelInterval6
			// 
			this.labelInterval6.AutoSize = true;
			this.labelInterval6.Location = new System.Drawing.Point(723, 482);
			this.labelInterval6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelInterval6.Name = "labelInterval6";
			this.labelInterval6.Size = new System.Drawing.Size(0, 16);
			this.labelInterval6.TabIndex = 25;
			// 
			// UDTuning1
			// 
			this.UDTuning1.BackColor = System.Drawing.SystemColors.Window;
			this.UDTuning1.Cursor = System.Windows.Forms.Cursors.Default;
			this.UDTuning1.Items.Add("H");
			this.UDTuning1.Items.Add("B");
			this.UDTuning1.Items.Add("A");
			this.UDTuning1.Items.Add("G#");
			this.UDTuning1.Items.Add("G");
			this.UDTuning1.Items.Add("F#");
			this.UDTuning1.Items.Add("F");
			this.UDTuning1.Items.Add("E");
			this.UDTuning1.Items.Add("D#");
			this.UDTuning1.Items.Add("D");
			this.UDTuning1.Items.Add("C#");
			this.UDTuning1.Items.Add("C");
			this.UDTuning1.Items.Add("H");
			this.UDTuning1.Items.Add("B");
			this.UDTuning1.Location = new System.Drawing.Point(485, 32);
			this.UDTuning1.Margin = new System.Windows.Forms.Padding(4);
			this.UDTuning1.Name = "UDTuning1";
			this.UDTuning1.ReadOnly = true;
			this.UDTuning1.Size = new System.Drawing.Size(47, 22);
			this.UDTuning1.TabIndex = 27;
			this.UDTuning1.SelectedItemChanged += new System.EventHandler(this.UDTuning_SelectedItemChanged);
			// 
			// UDTuning2
			// 
			this.UDTuning2.BackColor = System.Drawing.SystemColors.Window;
			this.UDTuning2.Cursor = System.Windows.Forms.Cursors.Default;
			this.UDTuning2.Items.Add("H");
			this.UDTuning2.Items.Add("B");
			this.UDTuning2.Items.Add("A");
			this.UDTuning2.Items.Add("G#");
			this.UDTuning2.Items.Add("G");
			this.UDTuning2.Items.Add("F#");
			this.UDTuning2.Items.Add("F");
			this.UDTuning2.Items.Add("E");
			this.UDTuning2.Items.Add("D#");
			this.UDTuning2.Items.Add("D");
			this.UDTuning2.Items.Add("C#");
			this.UDTuning2.Items.Add("C");
			this.UDTuning2.Items.Add("H");
			this.UDTuning2.Items.Add("B");
			this.UDTuning2.Location = new System.Drawing.Point(532, 32);
			this.UDTuning2.Margin = new System.Windows.Forms.Padding(4);
			this.UDTuning2.Name = "UDTuning2";
			this.UDTuning2.ReadOnly = true;
			this.UDTuning2.Size = new System.Drawing.Size(47, 22);
			this.UDTuning2.TabIndex = 29;
			this.UDTuning2.SelectedItemChanged += new System.EventHandler(this.UDTuning_SelectedItemChanged);
			// 
			// UDTuning3
			// 
			this.UDTuning3.BackColor = System.Drawing.SystemColors.Window;
			this.UDTuning3.Cursor = System.Windows.Forms.Cursors.Default;
			this.UDTuning3.Items.Add("H");
			this.UDTuning3.Items.Add("B");
			this.UDTuning3.Items.Add("A");
			this.UDTuning3.Items.Add("G#");
			this.UDTuning3.Items.Add("G");
			this.UDTuning3.Items.Add("F#");
			this.UDTuning3.Items.Add("F");
			this.UDTuning3.Items.Add("E");
			this.UDTuning3.Items.Add("D#");
			this.UDTuning3.Items.Add("D");
			this.UDTuning3.Items.Add("C#");
			this.UDTuning3.Items.Add("C");
			this.UDTuning3.Items.Add("H");
			this.UDTuning3.Items.Add("B");
			this.UDTuning3.Location = new System.Drawing.Point(579, 32);
			this.UDTuning3.Margin = new System.Windows.Forms.Padding(4);
			this.UDTuning3.Name = "UDTuning3";
			this.UDTuning3.ReadOnly = true;
			this.UDTuning3.Size = new System.Drawing.Size(47, 22);
			this.UDTuning3.TabIndex = 30;
			this.UDTuning3.SelectedItemChanged += new System.EventHandler(this.UDTuning_SelectedItemChanged);
			// 
			// UDTuning4
			// 
			this.UDTuning4.BackColor = System.Drawing.SystemColors.Window;
			this.UDTuning4.Cursor = System.Windows.Forms.Cursors.Default;
			this.UDTuning4.Items.Add("H");
			this.UDTuning4.Items.Add("B");
			this.UDTuning4.Items.Add("A");
			this.UDTuning4.Items.Add("G#");
			this.UDTuning4.Items.Add("G");
			this.UDTuning4.Items.Add("F#");
			this.UDTuning4.Items.Add("F");
			this.UDTuning4.Items.Add("E");
			this.UDTuning4.Items.Add("D#");
			this.UDTuning4.Items.Add("D");
			this.UDTuning4.Items.Add("C#");
			this.UDTuning4.Items.Add("C");
			this.UDTuning4.Items.Add("H");
			this.UDTuning4.Items.Add("B");
			this.UDTuning4.Location = new System.Drawing.Point(625, 32);
			this.UDTuning4.Margin = new System.Windows.Forms.Padding(4);
			this.UDTuning4.Name = "UDTuning4";
			this.UDTuning4.ReadOnly = true;
			this.UDTuning4.Size = new System.Drawing.Size(47, 22);
			this.UDTuning4.TabIndex = 31;
			this.UDTuning4.SelectedItemChanged += new System.EventHandler(this.UDTuning_SelectedItemChanged);
			// 
			// UDTuning5
			// 
			this.UDTuning5.BackColor = System.Drawing.SystemColors.Window;
			this.UDTuning5.Cursor = System.Windows.Forms.Cursors.Default;
			this.UDTuning5.Items.Add("H");
			this.UDTuning5.Items.Add("B");
			this.UDTuning5.Items.Add("A");
			this.UDTuning5.Items.Add("G#");
			this.UDTuning5.Items.Add("G");
			this.UDTuning5.Items.Add("F#");
			this.UDTuning5.Items.Add("F");
			this.UDTuning5.Items.Add("E");
			this.UDTuning5.Items.Add("D#");
			this.UDTuning5.Items.Add("D");
			this.UDTuning5.Items.Add("C#");
			this.UDTuning5.Items.Add("C");
			this.UDTuning5.Items.Add("H");
			this.UDTuning5.Items.Add("B");
			this.UDTuning5.Location = new System.Drawing.Point(672, 32);
			this.UDTuning5.Margin = new System.Windows.Forms.Padding(4);
			this.UDTuning5.Name = "UDTuning5";
			this.UDTuning5.ReadOnly = true;
			this.UDTuning5.Size = new System.Drawing.Size(47, 22);
			this.UDTuning5.TabIndex = 32;
			this.UDTuning5.SelectedItemChanged += new System.EventHandler(this.UDTuning_SelectedItemChanged);
			// 
			// UDTuning6
			// 
			this.UDTuning6.BackColor = System.Drawing.SystemColors.Window;
			this.UDTuning6.Cursor = System.Windows.Forms.Cursors.Default;
			this.UDTuning6.Items.Add("H");
			this.UDTuning6.Items.Add("B");
			this.UDTuning6.Items.Add("A");
			this.UDTuning6.Items.Add("G#");
			this.UDTuning6.Items.Add("G");
			this.UDTuning6.Items.Add("F#");
			this.UDTuning6.Items.Add("F");
			this.UDTuning6.Items.Add("E");
			this.UDTuning6.Items.Add("D#");
			this.UDTuning6.Items.Add("D");
			this.UDTuning6.Items.Add("C#");
			this.UDTuning6.Items.Add("C");
			this.UDTuning6.Items.Add("H");
			this.UDTuning6.Items.Add("B");
			this.UDTuning6.Location = new System.Drawing.Point(719, 32);
			this.UDTuning6.Margin = new System.Windows.Forms.Padding(4);
			this.UDTuning6.Name = "UDTuning6";
			this.UDTuning6.ReadOnly = true;
			this.UDTuning6.Size = new System.Drawing.Size(47, 22);
			this.UDTuning6.TabIndex = 33;
			this.UDTuning6.SelectedItemChanged += new System.EventHandler(this.UDTuning_SelectedItemChanged);
			// 
			// btnDefaultTuning
			// 
			this.btnDefaultTuning.Location = new System.Drawing.Point(779, 31);
			this.btnDefaultTuning.Margin = new System.Windows.Forms.Padding(4);
			this.btnDefaultTuning.Name = "btnDefaultTuning";
			this.btnDefaultTuning.Size = new System.Drawing.Size(146, 28);
			this.btnDefaultTuning.TabIndex = 34;
			this.btnDefaultTuning.Text = "Default tuning";
			this.btnDefaultTuning.UseVisualStyleBackColor = true;
			this.btnDefaultTuning.Click += new System.EventHandler(this.btnDefaultTuning_Click);
			// 
			// listAlternativeFingerings
			// 
			this.listAlternativeFingerings.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listAlternativeFingerings.FormattingEnabled = true;
			this.listAlternativeFingerings.ItemHeight = 14;
			this.listAlternativeFingerings.Location = new System.Drawing.Point(869, 70);
			this.listAlternativeFingerings.Margin = new System.Windows.Forms.Padding(4);
			this.listAlternativeFingerings.Name = "listAlternativeFingerings";
			this.listAlternativeFingerings.Size = new System.Drawing.Size(249, 382);
			this.listAlternativeFingerings.TabIndex = 36;
			this.listAlternativeFingerings.SelectedIndexChanged += new System.EventHandler(this.listOut_SelectedIndexChanged);
			// 
			// capoLocation
			// 
			this.capoLocation.Location = new System.Drawing.Point(408, 91);
			this.capoLocation.Margin = new System.Windows.Forms.Padding(4);
			this.capoLocation.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.capoLocation.Name = "capoLocation";
			this.capoLocation.Size = new System.Drawing.Size(54, 22);
			this.capoLocation.TabIndex = 37;
			this.capoLocation.ValueChanged += new System.EventHandler(this.capoUpDown_ValueChanged);
			// 
			// lblCapo
			// 
			this.lblCapo.AutoSize = true;
			this.lblCapo.Location = new System.Drawing.Point(404, 70);
			this.lblCapo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblCapo.Name = "lblCapo";
			this.lblCapo.Size = new System.Drawing.Size(41, 16);
			this.lblCapo.TabIndex = 38;
			this.lblCapo.Text = "Capo";
			// 
			// GuitarChordFinder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(1149, 542);
			this.Controls.Add(this.lblCapo);
			this.Controls.Add(this.capoLocation);
			this.Controls.Add(this.listAlternativeFingerings);
			this.Controls.Add(this.btnDefaultTuning);
			this.Controls.Add(this.UDTuning6);
			this.Controls.Add(this.UDTuning5);
			this.Controls.Add(this.UDTuning4);
			this.Controls.Add(this.UDTuning3);
			this.Controls.Add(this.UDTuning2);
			this.Controls.Add(this.UDTuning1);
			this.Controls.Add(this.labelInterval6);
			this.Controls.Add(this.labelInterval5);
			this.Controls.Add(this.labelInterval4);
			this.Controls.Add(this.labelInterval3);
			this.Controls.Add(this.labelInterval2);
			this.Controls.Add(this.labelInterval1);
			this.Controls.Add(this.labelString6);
			this.Controls.Add(this.labelString5);
			this.Controls.Add(this.labelString4);
			this.Controls.Add(this.labelString3);
			this.Controls.Add(this.labelString2);
			this.Controls.Add(this.labelString1);
			this.Controls.Add(this.btnPrevious);
			this.Controls.Add(this.lblFret);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.picBoxFretboard);
			this.Controls.Add(this.lblEnterChord);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.output);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "GuitarChordFinder";
			this.Text = "Guitar chord finder";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupChordStructure.ResumeLayout(false);
			this.groupChordStructure.PerformLayout();
			this.groupChordName.ResumeLayout(false);
			this.groupChordName.PerformLayout();
			this.groupChordNotes.ResumeLayout(false);
			this.groupChordNotes.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picBoxFretboard)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.capoLocation)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFind;
       
        private System.Windows.Forms.Label output;
        
        private System.Windows.Forms.Panel panel1;

		private System.Windows.Forms.Label lblEnterChord;
		private System.Windows.Forms.Label lblRoot;
		private System.Windows.Forms.ComboBox comboRoot; 
		private System.Windows.Forms.Label lblBassNote;
		private System.Windows.Forms.ComboBox comboBass;


		private System.Windows.Forms.RadioButton radioName;
		private System.Windows.Forms.GroupBox groupChordName;
		private System.Windows.Forms.Label lblChordName;
		public System.Windows.Forms.ComboBox comboChordName;

		private System.Windows.Forms.RadioButton radioChordNotes;
		private System.Windows.Forms.GroupBox groupChordNotes;
		private System.Windows.Forms.CheckBox checkB;
        private System.Windows.Forms.CheckBox checkAs;
        private System.Windows.Forms.CheckBox checkA;
        private System.Windows.Forms.CheckBox checkGs;
        private System.Windows.Forms.CheckBox checkG;
        private System.Windows.Forms.CheckBox checkFs;
        private System.Windows.Forms.CheckBox checkF;
        private System.Windows.Forms.CheckBox checkE;
        private System.Windows.Forms.CheckBox checkDs;
        private System.Windows.Forms.CheckBox checkD;
        private System.Windows.Forms.CheckBox checkCs;
        private System.Windows.Forms.CheckBox checkC;

		private System.Windows.Forms.RadioButton radioStructure;
		private System.Windows.Forms.GroupBox groupChordStructure;
		private System.Windows.Forms.ComboBox comboThird;
		private System.Windows.Forms.ComboBox comboFifth;
        private System.Windows.Forms.ComboBox comboSeventh;
        private System.Windows.Forms.ComboBox comboNinth;
        private System.Windows.Forms.ComboBox comboEleventh;
        private System.Windows.Forms.ComboBox comboThirteenth;
		private System.Windows.Forms.Label lblThird;
		private System.Windows.Forms.Label lblFifth;
		private System.Windows.Forms.Label lblSeventh;
		private System.Windows.Forms.Label lblNinth;
		private System.Windows.Forms.Label lblEleventh;
		private System.Windows.Forms.Label lblThirteenth;

		public System.Windows.Forms.CheckBox checkOmitRoot;


		private System.Windows.Forms.PictureBox picBoxFretboard;
		private System.Windows.Forms.DomainUpDown UDTuning1;
		private System.Windows.Forms.DomainUpDown UDTuning2;
		private System.Windows.Forms.DomainUpDown UDTuning3;
		private System.Windows.Forms.DomainUpDown UDTuning4;
		private System.Windows.Forms.DomainUpDown UDTuning5;
		private System.Windows.Forms.DomainUpDown UDTuning6;
		private System.Windows.Forms.Button btnDefaultTuning;
		private System.Windows.Forms.Label lblFret;
		private System.Windows.Forms.Label lblCapo;
		private System.Windows.Forms.NumericUpDown capoLocation;
		private System.Windows.Forms.Label labelString1;
        private System.Windows.Forms.Label labelString2;
        private System.Windows.Forms.Label labelString3;
        private System.Windows.Forms.Label labelString4;
        private System.Windows.Forms.Label labelString5;
        private System.Windows.Forms.Label labelString6;
        private System.Windows.Forms.Label labelInterval1;
        private System.Windows.Forms.Label labelInterval2;
        private System.Windows.Forms.Label labelInterval3;
        private System.Windows.Forms.Label labelInterval4;
        private System.Windows.Forms.Label labelInterval5;
        private System.Windows.Forms.Label labelInterval6;
        

		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrevious;
		private System.Windows.Forms.ListBox listAlternativeFingerings;        
    }
}

