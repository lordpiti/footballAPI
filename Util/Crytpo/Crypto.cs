using System;
using System.Text;
using System.Security.Cryptography;
using Util.Exceptions;


namespace Util.Crypto {

    /// <summary>
    /// Static Class with cryptografic utilities
    /// </summary>
    public static class Crypto {

        /// <summary>
        /// Method to encrypt with a SHA 256 Algorithm
        /// </summary>
        /// <param name="password">String to encrypt</param>
        /// <returns>Returns a String with the <paramref name="password"/> encrypted
        /// </returns>
        /// <exception cref="InternalErrorException"/>
        public static String crypt(String password) {
            try {

                HashAlgorithm hashAlg = new SHA256Managed();                

                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                byte[] encryptedPasswordBytes = hashAlg.ComputeHash(passwordBytes);

                String encryptedPassword = Convert.ToBase64String(encryptedPasswordBytes);

                return encryptedPassword;

            } catch (Exception e) {
                throw new InternalErrorException(e);
            }

        }


        #region Test Code Region. Uncomment for testing.

        ///**
        // * NOTE: Project must be previously changed from class library to 
        // * console application in project options menu
        // */
        //public static void Main(string[] args) {

        //    String clearPwd = "password";

        //    Log.LogManager.RecordMessage("Clear Password = '" + clearPwd + "'",
        //        Log.LogManager.MessageType.INFO);

        //    String encryptedPwd = crypt(clearPwd);

        //    Log.LogManager.RecordMessage("Encrypted Password = '" + 
        //        encryptedPwd + "'", Log.LogManager.MessageType.INFO);

        //    Console.ReadLine();

        //}

        #endregion
    }
}
