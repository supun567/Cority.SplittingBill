using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace SplittingBill.UnitTests
{
    [TestClass]
    public class SplitBillClass
    {

        [TestMethod]

        public void CheckStructureOfInput_CorrectStructureReceived_ShouldReturnTrue()
        {
            //Arrange
            var splitbill = new SplitBill();
            string[] inputstring = { "3", "1", "12.00", "3", "14.00", "12.25", "6.00", "1", "5.75", "2", "2", "12.00", "9.00", "3", "9.45", "6.12","1.75", "0" };

            //Act
            var result = splitbill.IsStructureValid(inputstring);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckStructureOfInput_IncorrectStructureReceived_ShouldReturnFalse()
        {
            //Arrange
            var splitbill = new SplitBill();
            //String structure incorrect at position 1, it should be corrected to 1
            string[] inputstring = { "3", "3", "12.00", "3", "14.00", "12.25", "6.00", "1", "5.75", "2", "2", "12.00", "9.00", "3", "9.45", "6.12", "1.75", "0" };

            //Act
            var result = splitbill.IsStructureValid(inputstring);

            //Assert
            Assert.IsFalse(result);
        }




    }
}
