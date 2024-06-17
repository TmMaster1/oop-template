namespace oop_template
{
    partial class FormaZaIzborTable
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
            this.radioBtn4x4 = new System.Windows.Forms.RadioButton();
            this.radioBtn8x8 = new System.Windows.Forms.RadioButton();
            this.radioBtn10x10 = new System.Windows.Forms.RadioButton();
            this.labelIzborVelicinePolja = new System.Windows.Forms.Label();
            this.potvrdiBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // radioBtn4x4
            // 
            this.radioBtn4x4.AutoSize = true;
            this.radioBtn4x4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioBtn4x4.Location = new System.Drawing.Point(61, 76);
            this.radioBtn4x4.Name = "radioBtn4x4";
            this.radioBtn4x4.Size = new System.Drawing.Size(50, 22);
            this.radioBtn4x4.TabIndex = 0;
            this.radioBtn4x4.TabStop = true;
            this.radioBtn4x4.Text = "4x4";
            this.radioBtn4x4.UseVisualStyleBackColor = true;
            this.radioBtn4x4.CheckedChanged += new System.EventHandler(this.radioBtn4x4_CheckedChanged);
            // 
            // radioBtn8x8
            // 
            this.radioBtn8x8.AutoSize = true;
            this.radioBtn8x8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioBtn8x8.Location = new System.Drawing.Point(61, 108);
            this.radioBtn8x8.Name = "radioBtn8x8";
            this.radioBtn8x8.Size = new System.Drawing.Size(50, 22);
            this.radioBtn8x8.TabIndex = 1;
            this.radioBtn8x8.TabStop = true;
            this.radioBtn8x8.Text = "8x8";
            this.radioBtn8x8.UseVisualStyleBackColor = true;
            this.radioBtn8x8.CheckedChanged += new System.EventHandler(this.radioBtn8x8_CheckedChanged);
            // 
            // radioBtn10x10
            // 
            this.radioBtn10x10.AutoSize = true;
            this.radioBtn10x10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioBtn10x10.Location = new System.Drawing.Point(61, 140);
            this.radioBtn10x10.Name = "radioBtn10x10";
            this.radioBtn10x10.Size = new System.Drawing.Size(66, 22);
            this.radioBtn10x10.TabIndex = 2;
            this.radioBtn10x10.TabStop = true;
            this.radioBtn10x10.Text = "10x10";
            this.radioBtn10x10.UseVisualStyleBackColor = true;
            this.radioBtn10x10.CheckedChanged += new System.EventHandler(this.radioBtn10x10_CheckedChanged);
            // 
            // labelIzborVelicinePolja
            // 
            this.labelIzborVelicinePolja.AutoSize = true;
            this.labelIzborVelicinePolja.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelIzborVelicinePolja.Location = new System.Drawing.Point(57, 43);
            this.labelIzborVelicinePolja.Name = "labelIzborVelicinePolja";
            this.labelIzborVelicinePolja.Size = new System.Drawing.Size(184, 19);
            this.labelIzborVelicinePolja.TabIndex = 3;
            this.labelIzborVelicinePolja.Text = "Izaberite veličinu polja:";
            this.labelIzborVelicinePolja.Click += new System.EventHandler(this.labelIzborVelicinePolja_Click);
            // 
            // potvrdiBtn
            // 
            this.potvrdiBtn.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.potvrdiBtn.Location = new System.Drawing.Point(152, 130);
            this.potvrdiBtn.Name = "potvrdiBtn";
            this.potvrdiBtn.Size = new System.Drawing.Size(89, 32);
            this.potvrdiBtn.TabIndex = 4;
            this.potvrdiBtn.Text = "POTVRDI";
            this.potvrdiBtn.UseVisualStyleBackColor = true;
            this.potvrdiBtn.Click += new System.EventHandler(this.potvrdiBtn_Click);
            // 
            // FormaZaIzborTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 216);
            this.Controls.Add(this.potvrdiBtn);
            this.Controls.Add(this.labelIzborVelicinePolja);
            this.Controls.Add(this.radioBtn10x10);
            this.Controls.Add(this.radioBtn8x8);
            this.Controls.Add(this.radioBtn4x4);
            this.Name = "FormaZaIzborTable";
            this.Text = "FormaZaIzborTable";
            this.Load += new System.EventHandler(this.FormaZaIzborTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioBtn4x4;
        private System.Windows.Forms.RadioButton radioBtn8x8;
        private System.Windows.Forms.RadioButton radioBtn10x10;
        private System.Windows.Forms.Label labelIzborVelicinePolja;
        private System.Windows.Forms.Button potvrdiBtn;
    }
}