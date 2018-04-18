namespace autoConfession
{
    partial class FrmLogin
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
            this.userNameTxtBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.logInBtn = new System.Windows.Forms.Button();
            this.rememberMeCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // userNameTxtBox
            // 
            this.userNameTxtBox.Location = new System.Drawing.Point(299, 211);
            this.userNameTxtBox.Name = "userNameTxtBox";
            this.userNameTxtBox.Size = new System.Drawing.Size(212, 20);
            this.userNameTxtBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(675, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "פייסבוק";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(551, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "שם מישתמש";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(580, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "סיסמא";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(299, 244);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(212, 20);
            this.passwordTextBox.TabIndex = 4;
            // 
            // logInBtn
            // 
            this.logInBtn.Location = new System.Drawing.Point(279, 315);
            this.logInBtn.Name = "logInBtn";
            this.logInBtn.Size = new System.Drawing.Size(75, 23);
            this.logInBtn.TabIndex = 5;
            this.logInBtn.Text = "היתחבר";
            this.logInBtn.UseVisualStyleBackColor = true;
            this.logInBtn.Click += new System.EventHandler(this.logInBtn_Click);
            // 
            // rememberMeCheckBox
            // 
            this.rememberMeCheckBox.AutoSize = true;
            this.rememberMeCheckBox.Location = new System.Drawing.Point(430, 315);
            this.rememberMeCheckBox.Name = "rememberMeCheckBox";
            this.rememberMeCheckBox.Size = new System.Drawing.Size(86, 17);
            this.rememberMeCheckBox.TabIndex = 6;
            this.rememberMeCheckBox.Text = "זכור סיסמא";
            this.rememberMeCheckBox.UseVisualStyleBackColor = true;
            this.rememberMeCheckBox.Visible = false;
            this.rememberMeCheckBox.CheckedChanged += new System.EventHandler(this.rememberMeCheckBox_CheckedChanged);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rememberMeCheckBox);
            this.Controls.Add(this.logInBtn);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userNameTxtBox);
            this.Name = "FrmLogin";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userNameTxtBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Button logInBtn;
        private System.Windows.Forms.CheckBox rememberMeCheckBox;
    }
}

