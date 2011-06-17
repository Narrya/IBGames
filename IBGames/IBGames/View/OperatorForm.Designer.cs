namespace IBGames.View
{
    partial class OperatorForm
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
            this.AssociatedStudents = new System.Windows.Forms.DataGridView();
            this.AllStudents = new System.Windows.Forms.DataGridView();
            this.btnAssociateStudents = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AssociatedStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // AssociatedStudents
            // 
            this.AssociatedStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AssociatedStudents.Location = new System.Drawing.Point(12, 12);
            this.AssociatedStudents.Name = "AssociatedStudents";
            this.AssociatedStudents.Size = new System.Drawing.Size(389, 339);
            this.AssociatedStudents.TabIndex = 0;
            // 
            // AllStudents
            // 
            this.AllStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllStudents.Location = new System.Drawing.Point(407, 12);
            this.AllStudents.Name = "AllStudents";
            this.AllStudents.Size = new System.Drawing.Size(375, 300);
            this.AllStudents.TabIndex = 1;
            // 
            // btnAssociateStudents
            // 
            this.btnAssociateStudents.Location = new System.Drawing.Point(407, 318);
            this.btnAssociateStudents.Name = "btnAssociateStudents";
            this.btnAssociateStudents.Size = new System.Drawing.Size(375, 33);
            this.btnAssociateStudents.TabIndex = 2;
            this.btnAssociateStudents.Text = "Associate selected to me";
            this.btnAssociateStudents.UseVisualStyleBackColor = true;
            this.btnAssociateStudents.Click += new System.EventHandler(this.btnAssociateStudents_Click);
            // 
            // OperatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 363);
            this.Controls.Add(this.btnAssociateStudents);
            this.Controls.Add(this.AllStudents);
            this.Controls.Add(this.AssociatedStudents);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OperatorForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operator module";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OperatorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AssociatedStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllStudents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView AssociatedStudents;
        private System.Windows.Forms.DataGridView AllStudents;
        private System.Windows.Forms.Button btnAssociateStudents;
    }
}