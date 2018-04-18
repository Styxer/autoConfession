using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace autoConfession
{
    class PasswordProctection
    {

        public static byte[] encryptPassword(string passwrod)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
          
            byte[] dataToEncrypt = ByteConverter.GetBytes(passwrod);
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
               return RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);

            }
        }

        public static string decryptePassword()
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] decryptedData;
            userConfigUtils.userConfig userConfig = new userConfigUtils.userConfig();
            userConfig = userConfigUtils.ReadConfigFile();
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                decryptedData = RSADecrypt(userConfig.userPassword, RSA.ExportParameters(true), false);
                return ByteConverter.GetString(decryptedData);

            }
        }
        static private byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                RSAKeyInfo.D = new byte[] { 10, 20 };
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

        static private byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider.
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This needs
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.  
                    //OAEP padding is only available on Microsoft Windows XP or
                    //later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException  
            //to the console.
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }

        }
    }
}
