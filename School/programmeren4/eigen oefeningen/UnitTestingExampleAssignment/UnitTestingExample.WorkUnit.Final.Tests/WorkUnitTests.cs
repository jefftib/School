using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTesting.WorkUnit.Final;

namespace UnitTestingExample.WorkUnit.Final.Tests
{
    [TestClass]
    public class WorkUnitTests
    {
        [TestMethod]
        public void MockedFibonacciTest()
        {
            // Arrange
            var moqLogger = new Mock<ILogger>();

            moqLogger
                .Setup(m => m.Log(It.Is<string>(s => string.Compare(s, "Starting Fibonacci calculation", StringComparison.CurrentCulture) == 0)))
                .Verifiable();

            moqLogger
                .Setup(m => m.Log(It.Is<string>(s => string.Compare(s, "Finished calculation for n=10: 55", StringComparison.CurrentCulture) == 0)))
                .Verifiable();

            // Act
            var workUnit = new UnitTesting.WorkUnit.Final.WorkUnit(moqLogger.Object);
            var result = workUnit.GetNthFibonacci(10);

            // Assert
            result.Should().Be(55);
            moqLogger.Verify();
        }

        /// <summary>
        /// n should be a positive integer
        /// </summary>
        [TestMethod]
        public void InvalidNValueTest()
        {
            // Arrange
            var moqLogger = new Mock<ILogger>();
            var workUnit = new UnitTesting.WorkUnit.Final.WorkUnit(moqLogger.Object);

            // Act
            throw new NotImplementedException();

            // Assert
            throw new NotImplementedException();
        }

        /// <summary>
        /// Should be 0; logging: string, exactly two times
        /// </summary>
        [TestMethod]
        public void TestShortcutForNIs0()
        {
            // Arrange
            var moqLogger = new Mock<ILogger>();

            var workUnit = new UnitTesting.WorkUnit.Final.WorkUnit(moqLogger.Object);

            // Act
            var result = workUnit.GetNthFibonacci(0);

            // Assert
            throw new NotImplementedException();
        }

        /// <summary>
        /// Should be 1; logging: string, exactly two times
        /// </summary>
        [TestMethod]
        public void TestShortcutForNIs1()
        {
            // Arrange
            var moqLogger = new Mock<ILogger>();

            var workUnit = new UnitTesting.WorkUnit.Final.WorkUnit(moqLogger.Object);

            // Act
            var result = workUnit.GetNthFibonacci(1);

            // Assert
            throw new NotImplementedException();
        }
    }
}
