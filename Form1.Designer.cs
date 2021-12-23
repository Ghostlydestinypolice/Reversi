namespace Reversi
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
            this.NieuwSpel = new System.Windows.Forms.Button();
            this.HelpKnop = new System.Windows.Forms.Button();
            this.speelbord = new System.Windows.Forms.Panel();
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 744);
            this.Controls.Add(this.speelbord);
            this.Controls.Add(this.HelpKnop);
            this.Controls.Add(this.NieuwSpel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NieuwSpel;
        private System.Windows.Forms.Button HelpKnop;
        private System.Windows.Forms.Panel speelbord;
    }
}

