using System;

namespace MLWE_UI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Search_text = new System.Windows.Forms.TextBox();
            this.open_file = new System.Windows.Forms.Button();
            this.FileName_box = new System.Windows.Forms.TextBox();
            this.run_test = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.S_VM = new System.Windows.Forms.TextBox();
            this.K_NN = new System.Windows.Forms.TextBox();
            this.SVM_IDF = new System.Windows.Forms.CheckBox();
            this.KNN_IDF = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SV_M = new System.Windows.Forms.TextBox();
            this.KN_N = new System.Windows.Forms.TextBox();
            this.SVM_B = new System.Windows.Forms.CheckBox();
            this.KNN_B = new System.Windows.Forms.CheckBox();
            this.Results_box_IDF = new System.Windows.Forms.GroupBox();
            this.SVM_Recall_IDF = new System.Windows.Forms.TextBox();
            this.KNN_Recall_IDF = new System.Windows.Forms.TextBox();
            this.SVM_Precision_IDF = new System.Windows.Forms.TextBox();
            this.KNN_Precision_IDF = new System.Windows.Forms.TextBox();
            this.SVM_Specificity_IDF = new System.Windows.Forms.TextBox();
            this.Recall_label_IDF = new System.Windows.Forms.Label();
            this.Precision_label_IDF = new System.Windows.Forms.Label();
            this.KNN_Specificity_IDF = new System.Windows.Forms.TextBox();
            this.SVM_Fscore_IDF = new System.Windows.Forms.TextBox();
            this.KNN_Fscore_IDF = new System.Windows.Forms.TextBox();
            this.Fscore_label_IDF = new System.Windows.Forms.Label();
            this.Specificity_label_IDF = new System.Windows.Forms.Label();
            this.Results_box_B = new System.Windows.Forms.GroupBox();
            this.SVM_Recall_B = new System.Windows.Forms.TextBox();
            this.KNN_Recall_B = new System.Windows.Forms.TextBox();
            this.SVM_Precision_B = new System.Windows.Forms.TextBox();
            this.KNN_Precision_B = new System.Windows.Forms.TextBox();
            this.SVM_Specificity_B = new System.Windows.Forms.TextBox();
            this.Recall_label_B = new System.Windows.Forms.Label();
            this.Precision_label_B = new System.Windows.Forms.Label();
            this.KNN_Specificity_B = new System.Windows.Forms.TextBox();
            this.SVM_Fscore_B = new System.Windows.Forms.TextBox();
            this.KNN_Fscore_B = new System.Windows.Forms.TextBox();
            this.Fscore_label_B = new System.Windows.Forms.Label();
            this.Specificity_label_B = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.new_Case_Button = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip4 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip5 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip6 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip7 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip8 = new System.Windows.Forms.ToolTip(this.components);
            this.Results_box_IDF.SuspendLayout();
            this.Results_box_B.SuspendLayout();
            this.SuspendLayout();
            // 
            // Search_text
            // 
            this.Search_text.Location = new System.Drawing.Point(68, 26);
            this.Search_text.Name = "Search_text";
            this.Search_text.Size = new System.Drawing.Size(231, 20);
            this.Search_text.TabIndex = 7;
            // 
            // open_file
            // 
            this.open_file.Location = new System.Drawing.Point(306, 25);
            this.open_file.Name = "open_file";
            this.open_file.Size = new System.Drawing.Size(75, 23);
            this.open_file.TabIndex = 8;
            this.open_file.Text = "Select File";
            this.open_file.UseVisualStyleBackColor = true;
            this.open_file.Click += new System.EventHandler(this.open_file_Click);
            // 
            // FileName_box
            // 
            this.FileName_box.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.FileName_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileName_box.Font = new System.Drawing.Font("Arial Rounded MT Bold", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileName_box.Location = new System.Drawing.Point(6, 30);
            this.FileName_box.Name = "FileName_box";
            this.FileName_box.Size = new System.Drawing.Size(55, 13);
            this.FileName_box.TabIndex = 12;
            this.FileName_box.Text = "File Name";
            // 
            // run_test
            // 
            this.run_test.Location = new System.Drawing.Point(287, 301);
            this.run_test.Name = "run_test";
            this.run_test.Size = new System.Drawing.Size(75, 20);
            this.run_test.TabIndex = 16;
            this.run_test.Text = "Run";
            this.run_test.UseVisualStyleBackColor = true;
            this.run_test.Click += new System.EventHandler(this.run_test_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 14);
            this.label1.TabIndex = 47;
            this.label1.Text = "TF-IDF";
            // 
            // S_VM
            // 
            this.S_VM.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.S_VM.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.S_VM.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.S_VM.Location = new System.Drawing.Point(9, 140);
            this.S_VM.Name = "S_VM";
            this.S_VM.Size = new System.Drawing.Size(68, 14);
            this.S_VM.TabIndex = 45;
            this.S_VM.Text = "SVM";
            // 
            // K_NN
            // 
            this.K_NN.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.K_NN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.K_NN.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.K_NN.Location = new System.Drawing.Point(10, 113);
            this.K_NN.Name = "K_NN";
            this.K_NN.Size = new System.Drawing.Size(68, 14);
            this.K_NN.TabIndex = 44;
            this.K_NN.Text = "KNN";
            // 
            // SVM_IDF
            // 
            this.SVM_IDF.AutoSize = true;
            this.SVM_IDF.Checked = true;
            this.SVM_IDF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SVM_IDF.Location = new System.Drawing.Point(79, 140);
            this.SVM_IDF.Name = "SVM_IDF";
            this.SVM_IDF.Size = new System.Drawing.Size(15, 14);
            this.SVM_IDF.TabIndex = 42;
            this.SVM_IDF.UseVisualStyleBackColor = true;
            // 
            // KNN_IDF
            // 
            this.KNN_IDF.AutoSize = true;
            this.KNN_IDF.Checked = true;
            this.KNN_IDF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KNN_IDF.Location = new System.Drawing.Point(79, 113);
            this.KNN_IDF.Name = "KNN_IDF";
            this.KNN_IDF.Size = new System.Drawing.Size(15, 14);
            this.KNN_IDF.TabIndex = 41;
            this.KNN_IDF.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(66, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 14);
            this.label6.TabIndex = 46;
            this.label6.Text = "Binary";
            // 
            // SV_M
            // 
            this.SV_M.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SV_M.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SV_M.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SV_M.Location = new System.Drawing.Point(10, 270);
            this.SV_M.Name = "SV_M";
            this.SV_M.Size = new System.Drawing.Size(68, 14);
            this.SV_M.TabIndex = 44;
            this.SV_M.Text = "SVM";
            // 
            // KN_N
            // 
            this.KN_N.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.KN_N.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KN_N.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KN_N.Location = new System.Drawing.Point(11, 243);
            this.KN_N.Name = "KN_N";
            this.KN_N.Size = new System.Drawing.Size(68, 14);
            this.KN_N.TabIndex = 43;
            this.KN_N.Text = "KNN";
            // 
            // SVM_B
            // 
            this.SVM_B.AutoSize = true;
            this.SVM_B.Checked = true;
            this.SVM_B.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SVM_B.Location = new System.Drawing.Point(80, 270);
            this.SVM_B.Name = "SVM_B";
            this.SVM_B.Size = new System.Drawing.Size(15, 14);
            this.SVM_B.TabIndex = 41;
            this.SVM_B.UseVisualStyleBackColor = true;
            // 
            // KNN_B
            // 
            this.KNN_B.AutoSize = true;
            this.KNN_B.Checked = true;
            this.KNN_B.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KNN_B.Location = new System.Drawing.Point(80, 243);
            this.KNN_B.Name = "KNN_B";
            this.KNN_B.Size = new System.Drawing.Size(15, 14);
            this.KNN_B.TabIndex = 40;
            this.KNN_B.UseVisualStyleBackColor = true;
            // 
            // Results_box_IDF
            // 
            this.Results_box_IDF.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Results_box_IDF.Controls.Add(this.SVM_Recall_IDF);
            this.Results_box_IDF.Controls.Add(this.KNN_Recall_IDF);
            this.Results_box_IDF.Controls.Add(this.SVM_Precision_IDF);
            this.Results_box_IDF.Controls.Add(this.KNN_Precision_IDF);
            this.Results_box_IDF.Controls.Add(this.SVM_Specificity_IDF);
            this.Results_box_IDF.Controls.Add(this.Recall_label_IDF);
            this.Results_box_IDF.Controls.Add(this.Precision_label_IDF);
            this.Results_box_IDF.Controls.Add(this.KNN_Specificity_IDF);
            this.Results_box_IDF.Controls.Add(this.SVM_Fscore_IDF);
            this.Results_box_IDF.Controls.Add(this.KNN_Fscore_IDF);
            this.Results_box_IDF.Controls.Add(this.Fscore_label_IDF);
            this.Results_box_IDF.Controls.Add(this.Specificity_label_IDF);
            this.Results_box_IDF.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F);
            this.Results_box_IDF.Location = new System.Drawing.Point(114, 72);
            this.Results_box_IDF.Name = "Results_box_IDF";
            this.Results_box_IDF.Size = new System.Drawing.Size(248, 95);
            this.Results_box_IDF.TabIndex = 48;
            this.Results_box_IDF.TabStop = false;
            this.Results_box_IDF.Text = "Results";
            // 
            // SVM_Recall_IDF
            // 
            this.SVM_Recall_IDF.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SVM_Recall_IDF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SVM_Recall_IDF.Location = new System.Drawing.Point(130, 65);
            this.SVM_Recall_IDF.Name = "SVM_Recall_IDF";
            this.SVM_Recall_IDF.Size = new System.Drawing.Size(37, 17);
            this.SVM_Recall_IDF.TabIndex = 38;
            this.SVM_Recall_IDF.Text = "-";
            this.SVM_Recall_IDF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // KNN_Recall_IDF
            // 
            this.KNN_Recall_IDF.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.KNN_Recall_IDF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KNN_Recall_IDF.Location = new System.Drawing.Point(129, 38);
            this.KNN_Recall_IDF.Name = "KNN_Recall_IDF";
            this.KNN_Recall_IDF.Size = new System.Drawing.Size(37, 17);
            this.KNN_Recall_IDF.TabIndex = 37;
            this.KNN_Recall_IDF.Text = "-";
            this.KNN_Recall_IDF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SVM_Precision_IDF
            // 
            this.SVM_Precision_IDF.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SVM_Precision_IDF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SVM_Precision_IDF.Location = new System.Drawing.Point(62, 65);
            this.SVM_Precision_IDF.Name = "SVM_Precision_IDF";
            this.SVM_Precision_IDF.Size = new System.Drawing.Size(60, 17);
            this.SVM_Precision_IDF.TabIndex = 35;
            this.SVM_Precision_IDF.Text = "-";
            this.SVM_Precision_IDF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // KNN_Precision_IDF
            // 
            this.KNN_Precision_IDF.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.KNN_Precision_IDF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KNN_Precision_IDF.Location = new System.Drawing.Point(63, 37);
            this.KNN_Precision_IDF.Name = "KNN_Precision_IDF";
            this.KNN_Precision_IDF.Size = new System.Drawing.Size(58, 17);
            this.KNN_Precision_IDF.TabIndex = 34;
            this.KNN_Precision_IDF.Text = "-";
            this.KNN_Precision_IDF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SVM_Specificity_IDF
            // 
            this.SVM_Specificity_IDF.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SVM_Specificity_IDF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SVM_Specificity_IDF.Location = new System.Drawing.Point(173, 65);
            this.SVM_Specificity_IDF.Name = "SVM_Specificity_IDF";
            this.SVM_Specificity_IDF.Size = new System.Drawing.Size(67, 17);
            this.SVM_Specificity_IDF.TabIndex = 32;
            this.SVM_Specificity_IDF.Text = "-";
            this.SVM_Specificity_IDF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Recall_label_IDF
            // 
            this.Recall_label_IDF.AutoSize = true;
            this.Recall_label_IDF.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Recall_label_IDF.Location = new System.Drawing.Point(125, 20);
            this.Recall_label_IDF.Name = "Recall_label_IDF";
            this.Recall_label_IDF.Size = new System.Drawing.Size(43, 14);
            this.Recall_label_IDF.TabIndex = 26;
            this.Recall_label_IDF.Text = "Recall";
            this.toolTip3.SetToolTip(this.Recall_label_IDF, "When something should be accepted, how often is it right?");
            // 
            // Precision_label_IDF
            // 
            this.Precision_label_IDF.AutoSize = true;
            this.Precision_label_IDF.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Precision_label_IDF.Location = new System.Drawing.Point(60, 20);
            this.Precision_label_IDF.Name = "Precision_label_IDF";
            this.Precision_label_IDF.Size = new System.Drawing.Size(61, 14);
            this.Precision_label_IDF.TabIndex = 25;
            this.Precision_label_IDF.Text = "Precision";
            this.toolTip2.SetToolTip(this.Precision_label_IDF, "When the model says the description is accepted, how often is it right?");
            // 
            // KNN_Specificity_IDF
            // 
            this.KNN_Specificity_IDF.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.KNN_Specificity_IDF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KNN_Specificity_IDF.Location = new System.Drawing.Point(173, 37);
            this.KNN_Specificity_IDF.Name = "KNN_Specificity_IDF";
            this.KNN_Specificity_IDF.Size = new System.Drawing.Size(67, 17);
            this.KNN_Specificity_IDF.TabIndex = 31;
            this.KNN_Specificity_IDF.Text = "-";
            this.KNN_Specificity_IDF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SVM_Fscore_IDF
            // 
            this.SVM_Fscore_IDF.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SVM_Fscore_IDF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SVM_Fscore_IDF.Location = new System.Drawing.Point(9, 65);
            this.SVM_Fscore_IDF.Name = "SVM_Fscore_IDF";
            this.SVM_Fscore_IDF.Size = new System.Drawing.Size(41, 17);
            this.SVM_Fscore_IDF.TabIndex = 22;
            this.SVM_Fscore_IDF.Text = "-";
            this.SVM_Fscore_IDF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // KNN_Fscore_IDF
            // 
            this.KNN_Fscore_IDF.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.KNN_Fscore_IDF.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KNN_Fscore_IDF.Location = new System.Drawing.Point(9, 36);
            this.KNN_Fscore_IDF.Name = "KNN_Fscore_IDF";
            this.KNN_Fscore_IDF.Size = new System.Drawing.Size(41, 17);
            this.KNN_Fscore_IDF.TabIndex = 21;
            this.KNN_Fscore_IDF.Text = "-";
            this.KNN_Fscore_IDF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Fscore_label_IDF
            // 
            this.Fscore_label_IDF.AutoSize = true;
            this.Fscore_label_IDF.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fscore_label_IDF.Location = new System.Drawing.Point(6, 20);
            this.Fscore_label_IDF.Name = "Fscore_label_IDF";
            this.Fscore_label_IDF.Size = new System.Drawing.Size(51, 14);
            this.Fscore_label_IDF.TabIndex = 19;
            this.Fscore_label_IDF.Text = "F Score";
            this.toolTip1.SetToolTip(this.Fscore_label_IDF, "Good metric for the overall performance of a model.");
            // 
            // Specificity_label_IDF
            // 
            this.Specificity_label_IDF.AutoSize = true;
            this.Specificity_label_IDF.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Specificity_label_IDF.Location = new System.Drawing.Point(170, 20);
            this.Specificity_label_IDF.Name = "Specificity_label_IDF";
            this.Specificity_label_IDF.Size = new System.Drawing.Size(68, 14);
            this.Specificity_label_IDF.TabIndex = 24;
            this.Specificity_label_IDF.Text = "Specificity";
            this.toolTip4.SetToolTip(this.Specificity_label_IDF, "When the model says the description is rejected, how often is it right?");
            // 
            // Results_box_B
            // 
            this.Results_box_B.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.Results_box_B.Controls.Add(this.SVM_Recall_B);
            this.Results_box_B.Controls.Add(this.KNN_Recall_B);
            this.Results_box_B.Controls.Add(this.SVM_Precision_B);
            this.Results_box_B.Controls.Add(this.KNN_Precision_B);
            this.Results_box_B.Controls.Add(this.SVM_Specificity_B);
            this.Results_box_B.Controls.Add(this.Recall_label_B);
            this.Results_box_B.Controls.Add(this.Precision_label_B);
            this.Results_box_B.Controls.Add(this.KNN_Specificity_B);
            this.Results_box_B.Controls.Add(this.SVM_Fscore_B);
            this.Results_box_B.Controls.Add(this.KNN_Fscore_B);
            this.Results_box_B.Controls.Add(this.Fscore_label_B);
            this.Results_box_B.Controls.Add(this.Specificity_label_B);
            this.Results_box_B.Font = new System.Drawing.Font("Arial Rounded MT Bold", 11F);
            this.Results_box_B.Location = new System.Drawing.Point(113, 204);
            this.Results_box_B.Name = "Results_box_B";
            this.Results_box_B.Size = new System.Drawing.Size(249, 91);
            this.Results_box_B.TabIndex = 39;
            this.Results_box_B.TabStop = false;
            this.Results_box_B.Text = "Results";
            // 
            // SVM_Recall_B
            // 
            this.SVM_Recall_B.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SVM_Recall_B.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SVM_Recall_B.Location = new System.Drawing.Point(129, 65);
            this.SVM_Recall_B.Name = "SVM_Recall_B";
            this.SVM_Recall_B.Size = new System.Drawing.Size(37, 17);
            this.SVM_Recall_B.TabIndex = 38;
            this.SVM_Recall_B.Text = "-";
            this.SVM_Recall_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // KNN_Recall_B
            // 
            this.KNN_Recall_B.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.KNN_Recall_B.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KNN_Recall_B.Location = new System.Drawing.Point(128, 38);
            this.KNN_Recall_B.Name = "KNN_Recall_B";
            this.KNN_Recall_B.Size = new System.Drawing.Size(37, 17);
            this.KNN_Recall_B.TabIndex = 37;
            this.KNN_Recall_B.Text = "-";
            this.KNN_Recall_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SVM_Precision_B
            // 
            this.SVM_Precision_B.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SVM_Precision_B.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SVM_Precision_B.Location = new System.Drawing.Point(61, 65);
            this.SVM_Precision_B.Name = "SVM_Precision_B";
            this.SVM_Precision_B.Size = new System.Drawing.Size(60, 17);
            this.SVM_Precision_B.TabIndex = 35;
            this.SVM_Precision_B.Text = "-";
            this.SVM_Precision_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // KNN_Precision_B
            // 
            this.KNN_Precision_B.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.KNN_Precision_B.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KNN_Precision_B.Location = new System.Drawing.Point(62, 37);
            this.KNN_Precision_B.Name = "KNN_Precision_B";
            this.KNN_Precision_B.Size = new System.Drawing.Size(58, 17);
            this.KNN_Precision_B.TabIndex = 34;
            this.KNN_Precision_B.Text = "-";
            this.KNN_Precision_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SVM_Specificity_B
            // 
            this.SVM_Specificity_B.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SVM_Specificity_B.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SVM_Specificity_B.Location = new System.Drawing.Point(172, 65);
            this.SVM_Specificity_B.Name = "SVM_Specificity_B";
            this.SVM_Specificity_B.Size = new System.Drawing.Size(67, 17);
            this.SVM_Specificity_B.TabIndex = 32;
            this.SVM_Specificity_B.Text = "-";
            this.SVM_Specificity_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Recall_label_B
            // 
            this.Recall_label_B.AutoSize = true;
            this.Recall_label_B.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Recall_label_B.Location = new System.Drawing.Point(123, 20);
            this.Recall_label_B.Name = "Recall_label_B";
            this.Recall_label_B.Size = new System.Drawing.Size(43, 14);
            this.Recall_label_B.TabIndex = 26;
            this.Recall_label_B.Text = "Recall";
            this.toolTip7.SetToolTip(this.Recall_label_B, "When something should be accepted, how often is it right?");
            // 
            // Precision_label_B
            // 
            this.Precision_label_B.AutoSize = true;
            this.Precision_label_B.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Precision_label_B.Location = new System.Drawing.Point(60, 20);
            this.Precision_label_B.Name = "Precision_label_B";
            this.Precision_label_B.Size = new System.Drawing.Size(61, 14);
            this.Precision_label_B.TabIndex = 25;
            this.Precision_label_B.Text = "Precision";
            this.toolTip6.SetToolTip(this.Precision_label_B, "When the model says the description is accepted, how often is it right?");
            // 
            // KNN_Specificity_B
            // 
            this.KNN_Specificity_B.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.KNN_Specificity_B.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KNN_Specificity_B.Location = new System.Drawing.Point(172, 37);
            this.KNN_Specificity_B.Name = "KNN_Specificity_B";
            this.KNN_Specificity_B.Size = new System.Drawing.Size(67, 17);
            this.KNN_Specificity_B.TabIndex = 31;
            this.KNN_Specificity_B.Text = "-";
            this.KNN_Specificity_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SVM_Fscore_B
            // 
            this.SVM_Fscore_B.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.SVM_Fscore_B.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SVM_Fscore_B.Location = new System.Drawing.Point(8, 65);
            this.SVM_Fscore_B.Name = "SVM_Fscore_B";
            this.SVM_Fscore_B.Size = new System.Drawing.Size(41, 17);
            this.SVM_Fscore_B.TabIndex = 22;
            this.SVM_Fscore_B.Text = "-";
            this.SVM_Fscore_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // KNN_Fscore_B
            // 
            this.KNN_Fscore_B.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.KNN_Fscore_B.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.KNN_Fscore_B.Location = new System.Drawing.Point(8, 36);
            this.KNN_Fscore_B.Name = "KNN_Fscore_B";
            this.KNN_Fscore_B.Size = new System.Drawing.Size(41, 17);
            this.KNN_Fscore_B.TabIndex = 21;
            this.KNN_Fscore_B.Text = "-";
            this.KNN_Fscore_B.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Fscore_label_B
            // 
            this.Fscore_label_B.AutoSize = true;
            this.Fscore_label_B.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fscore_label_B.Location = new System.Drawing.Point(6, 20);
            this.Fscore_label_B.Name = "Fscore_label_B";
            this.Fscore_label_B.Size = new System.Drawing.Size(51, 14);
            this.Fscore_label_B.TabIndex = 19;
            this.Fscore_label_B.Text = "F Score";
            this.toolTip5.SetToolTip(this.Fscore_label_B, "Good metric for the overall performance of a model.");
            // 
            // Specificity_label_B
            // 
            this.Specificity_label_B.AutoSize = true;
            this.Specificity_label_B.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Specificity_label_B.Location = new System.Drawing.Point(170, 20);
            this.Specificity_label_B.Name = "Specificity_label_B";
            this.Specificity_label_B.Size = new System.Drawing.Size(68, 14);
            this.Specificity_label_B.TabIndex = 24;
            this.Specificity_label_B.Text = "Specificity";
            this.toolTip8.SetToolTip(this.Specificity_label_B, "When something should be accepted, how often is it right?");
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(112, 322);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(16, 13);
            this.progressLabel.TabIndex = 50;
            this.progressLabel.Text = "...";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 312);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 51;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_Complete);
            // 
            // new_Case_Button
            // 
            this.new_Case_Button.Location = new System.Drawing.Point(244, 327);
            this.new_Case_Button.Name = "new_Case_Button";
            this.new_Case_Button.Size = new System.Drawing.Size(118, 23);
            this.new_Case_Button.TabIndex = 52;
            this.new_Case_Button.Text = "Test New Case";
            this.new_Case_Button.UseVisualStyleBackColor = true;
            this.new_Case_Button.Click += new System.EventHandler(this.new_Case_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(384, 355);
            this.Controls.Add(this.new_Case_Button);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.Results_box_B);
            this.Controls.Add(this.Results_box_IDF);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SV_M);
            this.Controls.Add(this.KN_N);
            this.Controls.Add(this.S_VM);
            this.Controls.Add(this.K_NN);
            this.Controls.Add(this.SVM_B);
            this.Controls.Add(this.KNN_B);
            this.Controls.Add(this.SVM_IDF);
            this.Controls.Add(this.KNN_IDF);
            this.Controls.Add(this.run_test);
            this.Controls.Add(this.FileName_box);
            this.Controls.Add(this.open_file);
            this.Controls.Add(this.Search_text);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MLWE Results";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.Results_box_IDF.ResumeLayout(false);
            this.Results_box_IDF.PerformLayout();
            this.Results_box_B.ResumeLayout(false);
            this.Results_box_B.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void newCaseReady()
        {
            this.new_Case_Button.Enabled = true;
        }

        #endregion
        public System.Windows.Forms.TextBox Search_text;
        public System.Windows.Forms.Button open_file;
        public System.Windows.Forms.TextBox FileName_box;
        public System.Windows.Forms.Button run_test;
        public System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox S_VM;
        public System.Windows.Forms.TextBox K_NN;
        public System.Windows.Forms.CheckBox SVM_IDF;
        public System.Windows.Forms.CheckBox KNN_IDF;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox SV_M;
        public System.Windows.Forms.TextBox KN_N;
        public System.Windows.Forms.CheckBox SVM_B;
        public System.Windows.Forms.CheckBox KNN_B;
        public System.Windows.Forms.GroupBox Results_box_IDF;
        public System.Windows.Forms.TextBox SVM_Recall_IDF;
        public System.Windows.Forms.TextBox KNN_Recall_IDF;
        public System.Windows.Forms.TextBox SVM_Precision_IDF;
        public System.Windows.Forms.TextBox KNN_Precision_IDF;
        public System.Windows.Forms.TextBox SVM_Specificity_IDF;
        public System.Windows.Forms.Label Recall_label_IDF;
        public System.Windows.Forms.Label Precision_label_IDF;
        public System.Windows.Forms.TextBox KNN_Specificity_IDF;
        public System.Windows.Forms.TextBox SVM_Fscore_IDF;
        public System.Windows.Forms.TextBox KNN_Fscore_IDF;
        public System.Windows.Forms.Label Fscore_label_IDF;
        public System.Windows.Forms.Label Specificity_label_IDF;
        public System.Windows.Forms.GroupBox Results_box_B;
        public System.Windows.Forms.TextBox SVM_Recall_B;
        public System.Windows.Forms.TextBox KNN_Recall_B;
        public System.Windows.Forms.TextBox SVM_Precision_B;
        public System.Windows.Forms.TextBox KNN_Precision_B;
        public System.Windows.Forms.TextBox SVM_Specificity_B;
        public System.Windows.Forms.Label Recall_label_B;
        public System.Windows.Forms.Label Precision_label_B;
        public System.Windows.Forms.TextBox KNN_Specificity_B;
        public System.Windows.Forms.TextBox SVM_Fscore_B;
        public System.Windows.Forms.TextBox KNN_Fscore_B;
        public System.Windows.Forms.Label Fscore_label_B;
        public System.Windows.Forms.Label Specificity_label_B;
        private System.Windows.Forms.Label progressLabel;
        private readonly EventHandler Form1_Load;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button new_Case_Button;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.ToolTip toolTip4;
        private System.Windows.Forms.ToolTip toolTip7;
        private System.Windows.Forms.ToolTip toolTip6;
        private System.Windows.Forms.ToolTip toolTip5;
        private System.Windows.Forms.ToolTip toolTip8;
    }

   
}

