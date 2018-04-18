using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using autoConfession;
using System.Text;

namespace UnitTestProject
{
    [TestClass]
    public class TestLogingIntoFaceBookAcccount
    {
        faceBookClass fb;
        string orignalUserName, originalPassword;
        Random rand;
        StringBuilder sb;

        [TestInitialize]
        public void init()
        {
            fb = new faceBookClass();
            orignalUserName = @"gennin@gmail.com";
            originalPassword = @"trustno12";
            rand = new Random();
        }

      

        [TestMethod]
        public void testLoginToFacebookSucsess()
        {
          bool result = testLoginTofacebook(orignalUserName, originalPassword);
          Assert.AreEqual(expected: true, actual: result);
        }

        //test can pass if on char is added the the password for reason unkown
        [TestMethod]
        public void testLoginToFacebookfailPassword()
        {
            //at start
            string randStr =  getRandomChar(rand.Next(2,5));
            bool result = testLoginTofacebook(orignalUserName, originalPassword + randStr);
            Assert.AreEqual(expected: false, actual: result);
            //at end
            randStr = getRandomChar(rand.Next(2, 5));
            result = testLoginTofacebook(orignalUserName, randStr + originalPassword);
            Assert.AreEqual(expected: false, actual: result);
            //at random letter
            int randLocation = rand.Next(originalPassword.Length - 1);
            randStr = getRandomChar();
            sb = new StringBuilder(originalPassword);
            sb[randLocation] = randStr[0];
            originalPassword = sb.ToString();
            result = testLoginTofacebook(orignalUserName, originalPassword);
            Assert.AreEqual(expected: false, actual: result);
            
           
        }

        [TestMethod]
        public void testLoginToFacebookfailUserName()
        {
            //at start
            string randStr = getRandomChar(rand.Next(2, 5));
            bool result = testLoginTofacebook(orignalUserName + randStr, originalPassword );
            Assert.AreEqual(expected: false, actual: result);
            //at end
            randStr = getRandomChar(rand.Next(2, 5));
            result = testLoginTofacebook(randStr + orignalUserName,  originalPassword);
            Assert.AreEqual(expected: false, actual: result);
            //at random letter
            int randLocation = rand.Next(orignalUserName.Length - 1);
            randStr = getRandomChar();
            sb = new StringBuilder(orignalUserName);
            sb[randLocation] = randStr[0];
            orignalUserName = sb.ToString();
            result = testLoginTofacebook(orignalUserName, originalPassword);
            Assert.AreEqual(expected: false, actual: result);
        }

        private bool testLoginTofacebook(string username, string password)
        {
            return fb.testLogingToFacebook(username, password);
        }

        private string getRandomChar(int count = 1)
        {
            string result = String.Empty;
            char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
            

            for (int i = 0; i < count; i++)
            {
                int j = rand.Next(chars.Length);
                result += chars[j].ToString(); 
            }

            return result;
        }
    }
}
