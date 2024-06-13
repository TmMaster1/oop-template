namespace oop_template
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
            this.dvaIgracaButton = new System.Windows.Forms.Button();
            this.protivKompjuteraButton = new System.Windows.Forms.Button();
            this.naslovLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dvaIgracaButton
            // 
            this.dvaIgracaButton.Location = new System.Drawing.Point(202, 97);
            this.dvaIgracaButton.Name = "dvaIgracaButton";
            this.dvaIgracaButton.Size = new System.Drawing.Size(231, 53);
            this.dvaIgracaButton.TabIndex = 0;
            this.dvaIgracaButton.Text = "IGRA U 2 IGRACA";
            this.dvaIgracaButton.UseVisualStyleBackColor = true;
            this.dvaIgracaButton.Click += new System.EventHandler(this.dvaIgracaButton_Click);
            // 
            // protivKompjuteraButton
            // 
            this.protivKompjuteraButton.Location = new System.Drawing.Point(202, 170);
            this.protivKompjuteraButton.Name = "protivKompjuteraButton";
            this.protivKompjuteraButton.Size = new System.Drawing.Size(233, 53);
            this.protivKompjuteraButton.TabIndex = 1;
            this.protivKompjuteraButton.Text = "IGRA PROTIV KOMPJUTERA";
            this.protivKompjuteraButton.UseVisualStyleBackColor = true;
            this.protivKompjuteraButton.Click += new System.EventHandler(this.protivKompjuteraButton_Click);
            // 
            // naslovLabel
            // 
            this.naslovLabel.AutoSize = true;
            this.naslovLabel.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.naslovLabel.Location = new System.Drawing.Point(133, 40);
            this.naslovLabel.Name = "naslovLabel";
            this.naslovLabel.Size = new System.Drawing.Size(369, 37);
            this.naslovLabel.TabIndex = 2;
            this.naslovLabel.Text = "POTAPANJE BRODOVA";
            this.naslovLabel.Click += new System.EventHandler(this.naslovLabel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 275);
            this.Controls.Add(this.naslovLabel);
            this.Controls.Add(this.protivKompjuteraButton);
            this.Controls.Add(this.dvaIgracaButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button dvaIgracaButton;
        private System.Windows.Forms.Button protivKompjuteraButton;
        private System.Windows.Forms.Label naslovLabel;
    }
}

