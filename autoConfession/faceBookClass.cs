using Mmosoft.Facebook.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace autoConfession
{
    public class faceBookClass
    {
        private FacebookClient fbClient;
        public static FacebookClient _fbclient { get; set; }

        public bool testLogingToFacebook(string username, string passsword)
        {
            bool result  = false;
            try
            {
                fbClient = new FacebookClient(username, passsword);
                
                _fbclient = fbClient;
                result = true;
            }
            catch (Exception)
            {

                
            }
            return result;
        }
    }
}
