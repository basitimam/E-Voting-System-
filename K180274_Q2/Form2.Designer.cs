
namespace K180274_Q2
{
    partial class Form2
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
            this.Nic = new System.Windows.Forms.TextBox();
            this.President = new System.Windows.Forms.ComboBox();
            this.VicePresident = new System.Windows.Forms.ComboBox();
            this.GenralSecratory = new System.Windows.Forms.ComboBox();
            this.Submit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Nic
            // 
            this.Nic.Location = new System.Drawing.Point(339, 42);
            this.Nic.Name = "Nic";
            this.Nic.Size = new System.Drawing.Size(125, 27);
            this.Nic.TabIndex = 0;
            this.Nic.TextChanged += new System.EventHandler(this.Nic_TextChanged);
            // 
            // President
            // 
            this.President.FormattingEnabled = true;
            this.President.Location = new System.Drawing.Point(330, 147);
            this.President.Name = "President";
            this.President.Size = new System.Drawing.Size(151, 28);
            this.President.TabIndex = 1;
            this.President.SelectedIndexChanged += new System.EventHandler(this.President_SelectedIndexChanged);
            // 
            // VicePresident
            // 
            this.VicePresident.FormattingEnabled = true;
            this.VicePresident.Location = new System.Drawing.Point(330, 232);
            this.VicePresident.Name = "VicePresident";
            this.VicePresident.Size = new System.Drawing.Size(151, 28);
            this.VicePresident.TabIndex = 2;
            this.VicePresident.SelectedIndexChanged += new System.EventHandler(this.VicePresident_SelectedIndexChanged);
            // 
            // GenralSecratory
            // 
            this.GenralSecratory.FormattingEnabled = true;
            this.GenralSecratory.Location = new System.Drawing.Point(330, 317);
            this.GenralSecratory.Name = "GenralSecratory";
            this.GenralSecratory.Size = new System.Drawing.Size(151, 28);
            this.GenralSecratory.TabIndex = 3;
            this.GenralSecratory.SelectedIndexChanged += new System.EventHandler(this.GenralSecratory_SelectedIndexChanged);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(360, 394);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(94, 29);
            this.Submit.TabIndex = 4;
            this.Submit.Text = "Submit";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nic";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "President";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Vice President";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "General Secratory";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.GenralSecratory);
            this.Controls.Add(this.VicePresident);
            this.Controls.Add(this.President);
            this.Controls.Add(this.Nic);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Nic;
        private System.Windows.Forms.ComboBox President;
        private System.Windows.Forms.ComboBox VicePresident;
        private System.Windows.Forms.ComboBox GenralSecratory;
        private System.Windows.Forms.Button Submit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}