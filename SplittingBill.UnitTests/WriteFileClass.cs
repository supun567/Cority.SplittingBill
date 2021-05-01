using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SplittingBill.UnitTests
{
    [TestClass]
    public class WriteFileClass
    {
        [TestMethod]
        public void CheckOutput_OutputNotNullOrEmpty_ShoulReturnTrue()
        {
            //Arrange
            _ = new WriteFile();
            List<string> OutputText = new() { "($10.21)","($1.00)","","$1.00" };
            

            //Act
            var result = WriteFile.CheckOutputForNullOrEmpty(OutputText);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckOutput_OutputNullOrEmpty_ShoulReturnFalse()
        {
            //Arrange
            _ = new WriteFile();
            List<string> OutputText = new() { };


            //Act
            var result = WriteFile.CheckOutputForNullOrEmpty(OutputText);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
