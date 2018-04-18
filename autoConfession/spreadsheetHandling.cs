using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace autoConfession
{

    public class sheetData
    {
        public string timeStamp;
        public string confesionText;
        public string personalInfo;
        public int confessionNumber;
        public int excelLine;
        public string Sex;
    }

    public class SpreadsheetHandling
    {
        static string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static string ApplicationName = "Google Sheets API .NET Quickstart";

        static string _formName = "Form responses 1";
        private string _spreadsheetId;
        private static int _readRange;
        private static string _fullReadRange;

        private static int  _counter;

        SpreadsheetsResource.ValuesResource.GetRequest _request;
        SheetsService _service;

        public void initSpreadSheet()
        {
            UserCredential credential;
            using (var stream =
               new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

                //credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                //    GoogleClientSecrets.Load(stream).Secrets,
                //    Scopes,
                //    "user",
                //    CancellationToken.None,
                //    new FileDataStore(credPath, true)).Result;
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
            GoogleClientSecrets.Load(stream).Secrets,
            Scopes,
            "user",
            CancellationToken.None
            //new FileDataStore(credPath, true)
            ).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Sheets API service.
             _service = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        public void initRequest(string spreadSheetLink, string readRange, string basicConfessionNum)
        {
             _counter = Convert.ToInt32(basicConfessionNum) - 1;
            _readRange = Convert.ToInt32(readRange) ;
            String spreadsheetId = _spreadsheetId = extractIDFromLink(spreadSheetLink);  // "15HIx2tD-E-zBn6ZY4rMjv0IlE0pu_dGoc7ybuqbkXXI";
            // String readRange = "Form responses 1!A270:B";
    
        }

        private string extractIDFromLink(string Link)
        {
            //https://docs.google.com/spreadsheets/d/15HIx2tD-E-zBn6ZY4rMjv0IlE0pu_dGoc7ybuqbkXXI/edit#gid=1070981831
            return Utilities.extractIDFromLink(Link);//string.Join(String.Empty, Link.Split('/').Reverse().Skip(1).Take(1));
        }

        public sheetData getSheetRowData()
        {
            _fullReadRange = _formName + "!A" + _readRange + ":D";
            _request = _service.Spreadsheets.Values.Get(_spreadsheetId, _fullReadRange);

            sheetData data = new sheetData();
            ValueRange response = _request.Execute();
            IList<IList<Object>> values = response.Values;

            if (values != null && values.Count > 0)
            {
               // string writeRange = "Form responses 1!";
                string personalInfo = String.Empty, text = String.Empty, timeStamp = String.Empty, sex = String.Empty;

               
                string phoneNumber = string.Empty;             
                
                for (int i = 0; i < 1; i++)
                {
                    IList<Object> row = values[i];
                    if (row.ElementAtOrDefault(0) != null && row.ElementAtOrDefault(1) != null //text and timestamp
                         && row.ElementAtOrDefault(3) != null)
                    {
                        text = row[1].ToString();
                        timeStamp = row[0].ToString();
                        personalInfo = row[2].ToString();
                        sex = row[3].ToString();
                        fillSpreadSheet(_service, _spreadsheetId, _formName + "!E" + (_readRange), "#" + _counter);
                        //int startIndex = text.IndexOf("$$"), endindex = -1;
                        //if (startIndex > -1)
                        //{
                        //    endindex = text.IndexOf("$$", text.IndexOf("$$") + 1);
                        //    if (endindex > -1)
                        //    {
                        //        personalInfo = text.Substring(startIndex, endindex - startIndex).Replace("$$", string.Empty);
                        //        fillSpreadSheet(_service, _spreadsheetId, _formName + "!C" + (_readRange + 1), personalInfo);
                        //        text = text.Substring(0, startIndex);
                        //    }
                        //    else
                        //    {
                        //        fillSpreadSheet(_service, _spreadsheetId, _formName + "!C" + (_readRange + 1), "no end speical end charchaters(\"$$\")");

                        //    }
                        //}


                        //fillSpreadSheet(_service, _spreadsheetId, _formName + "!D" + (_readRange + 1), "#" + _counter);
                        Debug.WriteLine("number {0} {1}, {2}", _counter, timeStamp, text);

                       

                        _counter++;
                    }
                    else
                        text = "אין וידוי בשורה זו";
                    

                    data.timeStamp = timeStamp;
                    data.confesionText = text;
                    data.confessionNumber =  _counter;
                    data.personalInfo = personalInfo;
                    data.excelLine = _readRange;
                    data.Sex = sex;


                    _readRange++;
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
            return data;
        }

        private static void fillSpreadSheet(SheetsService service, string spreadsheetId, string range, string text)
        {
            //ValueRange response = request.Execute();
            ValueRange valueRange = new ValueRange();
            valueRange.MajorDimension = "COLUMNS"; //Rows or Columns

            var oblist = new List<object>() { text };
            valueRange.Values = new List<IList<object>> { oblist };

            SpreadsheetsResource.ValuesResource.UpdateRequest update =
                service.Spreadsheets.Values.Update(valueRange, spreadsheetId, range);
            update.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.RAW;
            UpdateValuesResponse result2 = update.Execute();
        }
    }
}
