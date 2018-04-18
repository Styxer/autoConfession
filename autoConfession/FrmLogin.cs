using Mmosoft.Facebook.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace autoConfession
{
    public partial class FrmLogin : Form
    {
        private faceBookClass _fbClass;
        FacebookClient _fbClient;
        userConfigUtils.userConfig _userConfig;
        bool _rememeberChecked;
       
        public FrmLogin()
        {
            InitializeComponent();
            _userConfig = new userConfigUtils.userConfig();


        }

        private void logInBtn_Click(object sender, EventArgs e)
        {
            string username = userNameTxtBox.Text;
            string password = passwordTextBox.Text;
            _fbClass = new faceBookClass();
            if (!String.IsNullOrEmpty(username) && (!String.IsNullOrEmpty(password)))
            {
                //userConfigUtils.writeConfigFile(_rememeberChecked , username , PasswordProctection.encryptPassword(password));
                
                if (_fbClass.testLogingToFacebook(userNameTxtBox.Text, passwordTextBox.Text))
                {

                    using (FrmMain frm = new FrmMain())
                    {                        
                        
                        Hide();
                        frm.ShowDialog();
                    }
                }
                else
                    MessageBox.Show("סיסמא או שם מישתמש שגויים");
            }
            else
                MessageBox.Show("סיסמא או שם מישתמש חסרים");

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

#if DEBUG
            userNameTxtBox.Text = "gennin@gmail.com";
            passwordTextBox.Text = "trustno12";
            
#else
#endif
            //string password = PasswordProctection.decryptePassword();
            userConfigUtils.checkForConfigFile();           
            if (_userConfig != null)
            {

            }
        }

        private void rememberMeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            _rememeberChecked = checkBox.Checked;
            
        }
    }

   
}
