using Microsoft.VisualStudio.TestTools.UnitTesting;
using СaesarСipherTask;



namespace CaesarCipherTask.Tests
{

    [TestClass]
    public class CaesarCipherTests
    {
        [TestMethod]
        public void TestEncryptionWithZeroOffset()
        {
            string original = "message";

            string encrypted = CaesarCipher.Encrypt(original, 0);

            string decrypted = CaesarCipher.Decrypt(encrypted, 0);

            Assert.AreEqual(original, decrypted);
        }

        [TestMethod]
        public void TestEncryptionWithPositiveOffset()
        {
            string original = "abcdef";

            string encrypted = CaesarCipher.Encrypt(original, 1);
            
            Assert.AreEqual("bcdefg" , encrypted);
        }

        [TestMethod]
        public void TestEncryptionWithNegativeOffset()
        {
            string original = "bcdefg";

            string encrypted = CaesarCipher.Encrypt(original, -1);

            Assert.AreEqual("abcdef", encrypted);
        }

        [TestMethod]
        public void TestEncryptionOusideRange()
        {
            string original = "zZ";

            string encrypted = CaesarCipher.Encrypt(original, 1);

            Assert.AreEqual("aA", encrypted);

            original = "aA";

            encrypted = CaesarCipher.Encrypt(original, -1);

            Assert.AreEqual("zZ", encrypted);

        }

        [TestMethod]
        public void TestEncryptionNumbers()
        {
            string original = "12345";

            string encrypted = CaesarCipher.Encrypt(original, 1);

            Assert.AreEqual("12345", encrypted);
        }

        [TestMethod]
        public void TestDecryption()
        {
            string original = "message";

            string encrypted = CaesarCipher.Encrypt(original, 1);

            string decrypted = CaesarCipher.Decrypt(encrypted, 1);
            Assert.AreEqual(original, decrypted );
        }

        [TestMethod]
        public void TestEncryptionWithLargeOffset()
        {
            string original = "message";

            string encrypted = CaesarCipher.Encrypt(original, 1547);

            string decrypted = CaesarCipher.Decrypt(encrypted, 1547);
            Assert.AreEqual(original, decrypted);
        }
    }
}
