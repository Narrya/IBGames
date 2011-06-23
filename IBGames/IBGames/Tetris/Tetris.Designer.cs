namespace projekt
{
    partial class Tetris
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
            this.licznik = new System.Windows.Forms.Timer(this.components);
            this.next = new System.Windows.Forms.GroupBox();
            this.lbl_punktow = new System.Windows.Forms.Label();
            this.lbl_poziomow = new System.Windows.Forms.Label();
            this.punkty = new System.Windows.Forms.Label();
            this.poziom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // licznik
            // 
            this.licznik.Tick += new System.EventHandler(this.licznik_tick_1);
            // 
            // next
            // 
            this.next.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.next.Location = new System.Drawing.Point(17, 34);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(114, 105);
            this.next.TabIndex = 0;
            this.next.TabStop = false;
            this.next.Text = "Next";
            // 
            // lbl_punktow
            // 
            this.lbl_punktow.AutoSize = true;
            this.lbl_punktow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_punktow.Location = new System.Drawing.Point(20, 179);
            this.lbl_punktow.Name = "lbl_punktow";
            this.lbl_punktow.Size = new System.Drawing.Size(58, 17);
            this.lbl_punktow.TabIndex = 0;
            this.lbl_punktow.Text = "Points:";
            // 
            // lbl_poziomow
            // 
            this.lbl_poziomow.AutoSize = true;
            this.lbl_poziomow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_poziomow.Location = new System.Drawing.Point(20, 208);
            this.lbl_poziomow.Name = "lbl_poziomow";
            this.lbl_poziomow.Size = new System.Drawing.Size(52, 17);
            this.lbl_poziomow.TabIndex = 0;
            this.lbl_poziomow.Text = "Level:";
            // 
            // punkty
            // 
            this.punkty.AutoSize = true;
            this.punkty.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.punkty.Location = new System.Drawing.Point(101, 179);
            this.punkty.Name = "punkty";
            this.punkty.Size = new System.Drawing.Size(17, 17);
            this.punkty.TabIndex = 0;
            this.punkty.Text = "0";
            // 
            // poziom
            // 
            this.poziom.AutoSize = true;
            this.poziom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.poziom.Location = new System.Drawing.Point(101, 208);
            this.poziom.Name = "poziom";
            this.poziom.Size = new System.Drawing.Size(17, 17);
            this.poziom.TabIndex = 0;
            this.poziom.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(21, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "HELP:    F1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(442, 496);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.poziom);
            this.Controls.Add(this.punkty);
            this.Controls.Add(this.lbl_poziomow);
            this.Controls.Add(this.lbl_punktow);
            this.Controls.Add(this.next);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Tetris";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer licznik;
        private System.Windows.Forms.GroupBox next;
        private System.Windows.Forms.Label lbl_punktow;
        private System.Windows.Forms.Label lbl_poziomow;
        private System.Windows.Forms.Label punkty;
        private System.Windows.Forms.Label poziom;
        private System.Windows.Forms.Label label1;
    }
}

