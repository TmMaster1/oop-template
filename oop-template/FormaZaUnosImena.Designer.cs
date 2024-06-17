namespace oop_template
{
    partial class FormaZaUnosImena
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
            this.labelIgrac1 = new System.Windows.Forms.Label();
            this.textBoxImeIgrac1 = new System.Windows.Forms.TextBox();
            this.labelIgrac2 = new System.Windows.Forms.Label();
            this.textBoxImeIgrac2 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIgrac1
            // 
            this.labelIgrac1.AutoSize = true;
            this.labelIgrac1.Location = new System.Drawing.Point(9, 12);
            this.labelIgrac1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIgrac1.Name = "labelIgrac1";
            this.labelIgrac1.Size = new System.Drawing.Size(43, 13);
            this.labelIgrac1.TabIndex = 0;
            this.labelIgrac1.Text = "Igrač 1:";
            // 
            // textBoxImeIgrac1
            // 
            this.textBoxImeIgrac1.Location = new System.Drawing.Point(56, 10);
            this.textBoxImeIgrac1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxImeIgrac1.Name = "textBoxImeIgrac1";
            this.textBoxImeIgrac1.Size = new System.Drawing.Size(150, 20);
            this.textBoxImeIgrac1.TabIndex = 1;
            // 
            // labelIgrac2
            // 
            this.labelIgrac2.AutoSize = true;
            this.labelIgrac2.Location = new System.Drawing.Point(9, 35);
            this.labelIgrac2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIgrac2.Name = "labelIgrac2";
            this.labelIgrac2.Size = new System.Drawing.Size(43, 13);
            this.labelIgrac2.TabIndex = 2;
            this.labelIgrac2.Text = "Igrač 2:";
            // 
            // textBoxImeIgrac2
            // 
            this.textBoxImeIgrac2.Location = new System.Drawing.Point(56, 32);
            this.textBoxImeIgrac2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxImeIgrac2.Name = "textBoxImeIgrac2";
            this.textBoxImeIgrac2.Size = new System.Drawing.Size(150, 20);
            this.textBoxImeIgrac2.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(87, 55);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 19);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "Potvrdi";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.Location = new System.Drawing.Point(148, 55);
            this.btnOtkazi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(56, 19);
            this.btnOtkazi.TabIndex = 5;
            this.btnOtkazi.Text = "Otkaži";
            this.btnOtkazi.UseVisualStyleBackColor = true;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            // 
            // FormaZaUnosImena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 85);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.textBoxImeIgrac2);
            this.Controls.Add(this.labelIgrac2);
            this.Controls.Add(this.textBoxImeIgrac1);
            this.Controls.Add(this.labelIgrac1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormaZaUnosImena";
            this.Text = "Unos imena";
            this.Load += new System.EventHandler(this.FormaZaUnosImena_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label labelIgrac1;
        private System.Windows.Forms.TextBox textBoxImeIgrac1;
        private System.Windows.Forms.Label labelIgrac2;
        private System.Windows.Forms.TextBox textBoxImeIgrac2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnOtkazi;

    }

        #endregion
}