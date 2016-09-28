namespace MLWE_UI
{
    partial class MLWE_UI2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MLWE_UI2));
            this.decision_text = new System.Windows.Forms.Label();
            this.run_job_description = new System.Windows.Forms.Button();
            this.job_description_label = new System.Windows.Forms.Label();
            this.kNN_Binary_Pred = new System.Windows.Forms.Label();
            this.kNN_TFIDF_Pred = new System.Windows.Forms.Label();
            this.svm_TFIDF_Pred = new System.Windows.Forms.Label();
            this.svm_Binary_Pred = new System.Windows.Forms.Label();
            this.job_Description_text_box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // decision_text
            // 
            this.decision_text.AutoSize = true;
            this.decision_text.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.decision_text.Location = new System.Drawing.Point(3, 35);
            this.decision_text.Name = "decision_text";
            this.decision_text.Size = new System.Drawing.Size(80, 14);
            this.decision_text.TabIndex = 19;
            this.decision_text.Text = "Predictions: ";
            this.decision_text.Click += new System.EventHandler(this.Fscore_label_TF_Click);
            // 
            // run_job_description
            // 
            this.run_job_description.Location = new System.Drawing.Point(351, 12);
            this.run_job_description.Name = "run_job_description";
            this.run_job_description.Size = new System.Drawing.Size(75, 20);
            this.run_job_description.TabIndex = 24;
            this.run_job_description.Text = "Run";
            this.run_job_description.UseVisualStyleBackColor = true;
            this.run_job_description.Click += new System.EventHandler(this.run_job_description_Click);
            // 
            // job_description_label
            // 
            this.job_description_label.AutoSize = true;
            this.job_description_label.Location = new System.Drawing.Point(3, 15);
            this.job_description_label.Name = "job_description_label";
            this.job_description_label.Size = new System.Drawing.Size(80, 13);
            this.job_description_label.TabIndex = 26;
            this.job_description_label.Text = "Job Description";
            this.job_description_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // kNN_Binary_Pred
            // 
            this.kNN_Binary_Pred.AutoSize = true;
            this.kNN_Binary_Pred.Location = new System.Drawing.Point(87, 35);
            this.kNN_Binary_Pred.Name = "kNN_Binary_Pred";
            this.kNN_Binary_Pred.Size = new System.Drawing.Size(0, 13);
            this.kNN_Binary_Pred.TabIndex = 27;
            // 
            // kNN_TFIDF_Pred
            // 
            this.kNN_TFIDF_Pred.AutoSize = true;
            this.kNN_TFIDF_Pred.Location = new System.Drawing.Point(85, 63);
            this.kNN_TFIDF_Pred.Name = "kNN_TFIDF_Pred";
            this.kNN_TFIDF_Pred.Size = new System.Drawing.Size(0, 13);
            this.kNN_TFIDF_Pred.TabIndex = 28;
            // 
            // svm_TFIDF_Pred
            // 
            this.svm_TFIDF_Pred.AutoSize = true;
            this.svm_TFIDF_Pred.Location = new System.Drawing.Point(86, 121);
            this.svm_TFIDF_Pred.Name = "svm_TFIDF_Pred";
            this.svm_TFIDF_Pred.Size = new System.Drawing.Size(0, 13);
            this.svm_TFIDF_Pred.TabIndex = 30;
            this.svm_TFIDF_Pred.Click += new System.EventHandler(this.svm_TFIDF_Pred_Click);
            // 
            // svm_Binary_Pred
            // 
            this.svm_Binary_Pred.AutoSize = true;
            this.svm_Binary_Pred.Location = new System.Drawing.Point(86, 93);
            this.svm_Binary_Pred.Name = "svm_Binary_Pred";
            this.svm_Binary_Pred.Size = new System.Drawing.Size(0, 13);
            this.svm_Binary_Pred.TabIndex = 29;
            // 
            // job_Description_text_box
            // 
            this.job_Description_text_box.Location = new System.Drawing.Point(88, 12);
            this.job_Description_text_box.Multiline = true;
            this.job_Description_text_box.Name = "job_Description_text_box";
            this.job_Description_text_box.Size = new System.Drawing.Size(257, 20);
            this.job_Description_text_box.TabIndex = 31;

            // 
            // MLWE_UI2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(436, 143);
            this.Controls.Add(this.job_Description_text_box);
            this.Controls.Add(this.svm_TFIDF_Pred);
            this.Controls.Add(this.svm_Binary_Pred);
            this.Controls.Add(this.kNN_TFIDF_Pred);
            this.Controls.Add(this.kNN_Binary_Pred);
            this.Controls.Add(this.job_description_label);
            this.Controls.Add(this.run_job_description);
            this.Controls.Add(this.decision_text);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MLWE_UI2";
            this.Text = "MLWE Results ";
            this.Load += new System.EventHandler(this.MLWE_UI2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label decision_text;
        private System.Windows.Forms.Button run_job_description;
        private System.Windows.Forms.Label job_description_label;
        private System.Windows.Forms.Label kNN_Binary_Pred;
        private System.Windows.Forms.Label kNN_TFIDF_Pred;
        private System.Windows.Forms.Label svm_TFIDF_Pred;
        private System.Windows.Forms.Label svm_Binary_Pred;
        private System.Windows.Forms.TextBox job_Description_text_box;
    }
}