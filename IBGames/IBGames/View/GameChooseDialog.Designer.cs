namespace IBGames.View
{
    partial class GameChooseDialog
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
            this.FirstGame = new System.Windows.Forms.Button();
            this.SecondGame = new System.Windows.Forms.Button();
            this.ThirdGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FirstGame
            // 
            this.FirstGame.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FirstGame.Location = new System.Drawing.Point(12, 6);
            this.FirstGame.Name = "FirstGame";
            this.FirstGame.Size = new System.Drawing.Size(260, 56);
            this.FirstGame.TabIndex = 0;
            this.FirstGame.Text = "Memo";
            this.FirstGame.UseVisualStyleBackColor = true;
            this.FirstGame.Click += new System.EventHandler(this.FirstGame_Click);
            // 
            // SecondGame
            // 
            this.SecondGame.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SecondGame.Location = new System.Drawing.Point(12, 75);
            this.SecondGame.Name = "SecondGame";
            this.SecondGame.Size = new System.Drawing.Size(260, 56);
            this.SecondGame.TabIndex = 1;
            this.SecondGame.Text = "Tetris";
            this.SecondGame.UseVisualStyleBackColor = true;
            this.SecondGame.Click += new System.EventHandler(this.SecondGame_Click);
            // 
            // ThirdGame
            // 
            this.ThirdGame.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ThirdGame.Location = new System.Drawing.Point(12, 145);
            this.ThirdGame.Name = "ThirdGame";
            this.ThirdGame.Size = new System.Drawing.Size(260, 56);
            this.ThirdGame.TabIndex = 2;
            this.ThirdGame.Text = "Image Catcher";
            this.ThirdGame.UseVisualStyleBackColor = true;
            this.ThirdGame.Click += new System.EventHandler(this.ThirdGame_Click);
            // 
            // GameChooseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 212);
            this.Controls.Add(this.ThirdGame);
            this.Controls.Add(this.SecondGame);
            this.Controls.Add(this.FirstGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameChooseDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choose game";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FirstGame;
        private System.Windows.Forms.Button SecondGame;
        private System.Windows.Forms.Button ThirdGame;
    }
}