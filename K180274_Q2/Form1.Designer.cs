
namespace K180274_Q2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Email_Input = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.Submit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Email_Input
            // 
            this.Email_Input.Location = new System.Drawing.Point(279, 73);
            this.Email_Input.Name = "Email_Input";
            this.Email_Input.Size = new System.Drawing.Size(125, 27);
            this.Email_Input.TabIndex = 0;
            this.Email_Input.TextChanged += new System.EventHandler(this.Email_Input_TextChanged);
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(279, 156);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(125, 27);
            this.Password.TabIndex = 1;
            this.Password.TextChanged += new System.EventHandler(this.Password_TextChanged);
            // 
            // Submit
            // 
            this.Submit.Location = new System.Drawing.Point(301, 233);
            this.Submit.Name = "Submit";
            this.Submit.Size = new System.Drawing.Size(94, 29);
            this.Submit.TabIndex = 3;
            this.Submit.Text = "Login";
            this.Submit.UseVisualStyleBackColor = true;
            this.Submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Submit);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Email_Input);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Email_Input;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button Submit;
    }
}

