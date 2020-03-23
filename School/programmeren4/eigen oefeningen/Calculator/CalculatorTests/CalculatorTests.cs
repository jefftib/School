using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;
namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_ShouldAddNumbers_ShouldSuccesfullyAdd20To7Return27()
        {
            //arrange
            var calculator = new Calculator();
            var a = 7;
            var b = 20;
            //act
          var result =  calculator.Add(a, b);
            //assert
            Assert.AreEqual(result, 27);
        }
        [TestMethod]
        public void Subtract_ShouldSubtractNumbers_ShouldSuccesfullySubtract7From20Returning13()
        {
            //arrange
            var calculator = new Calculator();
            var a = 20;
            var b = 7;
            //act
            var result = calculator.Subtract(a, b);
            //assert
            Assert.AreEqual(result, 13);
        }
        [TestMethod]
        public void Multiply_ShouldMultiplyNumbers_ShouldMultiply3by4Returning12()
        {
            //arrange
            var calculator = new Calculator();
            var a = 3;
            var b = 4;
            //act
            var result = calculator.Multiply(a, b);
            //assert
            Assert.AreEqual(result, 12);
        }
        [TestMethod]
        public void Divide_ShouldDivideNumbers_ShouldDivide12by4Returning3()
        {
            //arrange
            var calculator = new Calculator();
            var a = 12;
            var b = 4;
            //act
            var result = calculator.Divide(a, b);
            //assert
            Assert.AreEqual(result, 3);
        }
    }
}
