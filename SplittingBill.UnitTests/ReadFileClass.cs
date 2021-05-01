using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SplittingBill.UnitTests
{
    
    [TestClass]
    
    public class ReadFileClass
    {
        
        [TestMethod]
        public void CheckIfArgsReceived_ArgsReceived_ShoulReturnTrue()
        {
            //Arrange
            var readfile = new ReadFile();
            string[] FileName = { "inputFile.txt" };

            //Act
            var result = ReadFile.CheckArguements(FileName);

            //Assert
            Assert.IsTrue(result);
        }

        
        [TestMethod]
        public void CheckIfArgsReceived_ArgsNotReceived_ShoulReturnFalse()
        {
            //Arrange
            var readfile = new ReadFile();
            string[] FileName = null;
            //Act
            var result = ReadFile.CheckArguements(FileName);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckIfArgsReceived_MultipleArgsReceived_ShoulReturnFalse()
        {
            //Arrange
            var readfile = new ReadFile();
            string[] FileName = { "input", "File.txt" };

            //Act
            var result = ReadFile.CheckArguements(FileName);

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void CheckForInvalidCharacters_InvalidReceived_ShouldReturnFalse()
        {
            //Arange
            var readfile = new ReadFile();
            string[] inputstring = { "2", "2", "10.00", "15.00", "1", "25.00"};

            //Act
            var result = ReadFile.CheckForInvalidCharacters(inputstring);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckForInvalidCharacters_AllValid_ShouldReturnTrue()
        {
            //Arange
            var readfile = new ReadFile();
            string[] inputstring = { "2", "2", "10.00", "s", "1", "12.00" };

            //Act
            var result = ReadFile.CheckForInvalidCharacters(inputstring);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
