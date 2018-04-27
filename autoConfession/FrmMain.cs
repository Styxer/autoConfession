using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Centvrio.Emoji;

namespace autoConfession
{
    public partial class FrmMain : Form
    {
        SpreadsheetHandling handler;

        private string _excelLink, _readBeginLine, _basicConfessionNum, _facebookGroupLink ,_pesonalIfno;
        private string _confesionText,  _confessionNum,  _sex;


        public FrmMain()
        {
            InitializeComponent();
            handler = new SpreadsheetHandling();
        }

        private void saveSettingBtn_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_excelLink) && !String.IsNullOrEmpty(_readBeginLine) && !String.IsNullOrEmpty(_basicConfessionNum) && !String.IsNullOrEmpty(_facebookGroupLink))
            {
                if (Convert.ToInt32(_readBeginLine) > 1)
                {
                    handler.initRequest(_excelLink, _readBeginLine, _basicConfessionNum);
                    saveSettingBtn.Enabled = false;
                    importNextConfession.Enabled = true;
                    excelLinkTxtBox.Enabled = basicConfessionNumTxtBox.Enabled = spreedSheetBeginLineTxtBox.Enabled = faceBookLinkTxtBox.Enabled = false; 
                }
                else
                    MessageBox.Show("מיספר שורה חייב להיות גדול מ1");
            }
            else
            {
                MessageBox.Show("אנא מלא את כל השדות");
            }
        }
        
        private void TxtBox_TextChanged(object sender, EventArgs e)
        {
            string txtBoxName = (sender as TextBox).Name;
            string txtBoxTxt = (sender as TextBox).Text;

           switch(txtBoxName)
            {
                case "excelLinkTxtBox":
                    _excelLink = excelLinkTxtBox.Text = txtBoxTxt;
                    break;
                case "basicConfessionNumTxtBox":
                    _basicConfessionNum =  basicConfessionNumTxtBox.Text = txtBoxTxt;
                    break;
                case "spreedSheetBeginLineTxtBox":
                    _readBeginLine = spreedSheetBeginLineTxtBox.Text = txtBoxTxt;
                    break;
                case "faceBookLinkTxtBox":
                    _facebookGroupLink = faceBookLinkTxtBox.Text = txtBoxTxt;

                    break;
            }
        }


        private void importNextConfession_Click(object sender, EventArgs e)
        {
            publishConfessionToFBSucsessLbl.Visible = false;
            publishConfessionToFBFailLbl.Visible = false;
            sheetData data = handler.getSheetRowData();
            if (data != null)
            {
                confessionTimeStampTxtBox.Text = data.timeStamp;
                _confessionNum = confessionNumTxtBox.Text = data.confessionNumber.ToString();
                _pesonalIfno =  personalDetailTxtBox.Text = data.personalInfo;
                confessionTxtBox.Text = _confesionText = data.confesionText;
                excelLineTxtBox.Text = data.excelLine.ToString();
                _sex = sexTxtBox.Text = data.Sex;


                if (!String.IsNullOrEmpty(confessionTimeStampTxtBox.Text))
                {
                    publishConfessionToFaceBook.Enabled = true;
                    
                }
            }
            else
              confessionTxtBox.Text = "היית בעייה בקריאת הוידוי";




        }

        private UnicodeString parseCodePoint(string sex)
        {
            if (_sex == "בן")
                return Geometric.BlueCircle;
            else
                return Geometric.RedCircle;
        }

        private void publishConfessionToFaceBook_Click(object sender, EventArgs e)
        {
            UnicodeString indecator = parseCodePoint(_sex);
            string targetId = Utilities.extractIDFromLink(_facebookGroupLink);
            string ConfeesionNumber = String.IsNullOrEmpty(_pesonalIfno) ? String.Empty : Environment.NewLine + "#" + _confessionNum;
            string textToPublish = indecator + ConfeesionNumber + Environment.NewLine + _confesionText;
            bool result = faceBookClass._fbclient.PostToGroup(textToPublish, targetId);
            if (result)
            {
                publishConfessionToFaceBook.Enabled = false;
              
                publishConfessionToFBSucsessLbl.Visible = true;
                publishConfessionToFBFailLbl.Visible = false;
            }
            else
            {
                publishConfessionToFBSucsessLbl.Visible = false;
                publishConfessionToFBFailLbl.Visible = true;
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            handler.initSpreadSheet();

            versionLbl.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
#if DEBUG
            _excelLink = excelLinkTxtBox.Text = @"https://docs.google.com/spreadsheets/d/1HgSHbjAFAHZKumTlwNQbZ4ybZ5gvzk43RkS6ruxr1Hs/edit#gid=895544017";
            _basicConfessionNum = basicConfessionNumTxtBox.Text = "10";
            _readBeginLine =  spreedSheetBeginLineTxtBox.Text = "8";
            _facebookGroupLink = faceBookLinkTxtBox.Text = @"https://www.facebook.com/%D7%95%D7%99%D7%93%D7%95%D7%99%D7%99%D7%9D-%D7%9C%D7%9E%D7%98%D7%A8%D7%95%D7%AA-%D7%94%D7%99%D7%9B%D7%A8%D7%95%D7%AA-22-990693251093160/";
#else
#endif
        }
    }
}
