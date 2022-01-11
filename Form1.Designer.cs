namespace Reversi
{
    partial class MainClass
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
            this.NieuwSpel = new System.Windows.Forms.Button();
            this.HelpKnop = new System.Windows.Forms.Button();
            this.speelbord = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Score1 = new System.Windows.Forms.Label();
            this.Score2 = new System.Windows.Forms.Label();
            this.Beurtlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NieuwSpel
            // 
            this.NieuwSpel.Location = new System.Drawing.Point(217, 24);
            this.NieuwSpel.Name = "NieuwSpel";
            this.NieuwSpel.Size = new System.Drawing.Size(119, 33);
            this.NieuwSpel.TabIndex = 0;
            this.NieuwSpel.Text = "Nieuw Spel";
            this.NieuwSpel.UseVisualStyleBackColor = true;
            this.NieuwSpel.Click += new System.EventHandler(this.NieuwSpelKlik);
            // 
            // HelpKnop
            // 
            this.HelpKnop.Location = new System.Drawing.Point(408, 24);
            this.HelpKnop.Name = "HelpKnop";
            this.HelpKnop.Size = new System.Drawing.Size(119, 33);
            this.HelpKnop.TabIndex = 1;
            this.HelpKnop.Text = "Help";
            this.HelpKnop.UseVisualStyleBackColor = true;
            this.HelpKnop.Click += new System.EventHandler(this.HelpKlik);
            // 
            // speelbord
            // 
            this.speelbord.Location = new System.Drawing.Point(80, 80);
            this.speelbord.Name = "speelbord";
            this.speelbord.Size = new System.Drawing.Size(600, 600);
            this.speelbord.TabIndex = 2;
            this.speelbord.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelTeken);
            this.speelbord.MouseClick += new System.Windows.Forms.MouseEventHandler(this.speelbord_MouseKlik);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Score speler 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(624, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Score speler 2";
            // 
            // Score1
            // 
            this.Score1.AutoSize = true;
            this.Score1.Location = new System.Drawing.Point(36, 48);
            this.Score1.Name = "Score1";
            this.Score1.Size = new System.Drawing.Size(67, 20);
            this.Score1.TabIndex = 5;
            this.Score1.Text = score1.ToString();
            // 
            // Score2
            // 
            this.Score2.AutoSize = true;
            this.Score2.Location = new System.Drawing.Point(624, 48);
            this.Score2.Name = "Score2";
            this.Score2.Size = new System.Drawing.Size(67, 20);
            this.Score2.TabIndex = 6;
            this.Score2.Text = score2.ToString();
            // 
            // label3
            // 
            this.Beurtlabel.AutoSize = true;
            this.Beurtlabel.Location = new System.Drawing.Point(76, 706);
            this.Beurtlabel.Name = "Beurtlabel";
            this.Beurtlabel.Size = new System.Drawing.Size(51, 20);
            this.Beurtlabel.TabIndex = 7;
            this.Beurtlabel.Text = beurt.ToString();
            // 
            // MainClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 744);
            this.Controls.Add(this.Beurtlabel);
            this.Controls.Add(this.Score2);
            this.Controls.Add(this.Score1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speelbord);
            this.Controls.Add(this.HelpKnop);
            this.Controls.Add(this.NieuwSpel);
            this.Name = "MainClass";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NieuwSpel;
        private System.Windows.Forms.Button HelpKnop;
        private System.Windows.Forms.Panel speelbord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Score1;
        private System.Windows.Forms.Label Score2;
        private System.Windows.Forms.Label Beurtlabel;
    }
}

