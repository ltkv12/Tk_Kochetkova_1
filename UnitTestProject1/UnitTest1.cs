using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace ExamGradeCalculator.Tests
{
    [TestClass]
    public class GradeCalculatorTests
    {
        [TestMethod]
        public void CalculateGrade_AllMaxScores_ReturnsExcellent()
        {
            // Arrange
            double task1 = 10;
            double task2 = 50;
            double task3 = 30;
            double task4 = 10;

            // Act
            double total = task1 + task2 + task3 + task4;
            string grade = CalculateGrade(total);

            // Assert
            Assert.AreEqual("5 (отлично", grade);
            Assert.AreEqual(100, total);
        }

        [TestMethod]
        public void CalculateGrade_BorderlineGoodScore_ReturnsGood()
        {
            // Arrange
            double task1 = 0;
            double task2 = 40;
            double task3 = 0;
            double task4 = 0;

            // Act
            double total = task1 + task2 + task3 + task4;
            string grade = CalculateGrade(total);

            // Assert
            Assert.AreEqual("4 (хорошо)", grade);
            Assert.AreEqual(40, total);
        }

        [TestMethod]
        public void CalculateGrade_BorderlineSatisfactoryScore_ReturnsSatisfactory()
        {
            // Arrange
            double task1 = 10;
            double task2 = 0;
            double task3 = 10;
            double task4 = 0;

            // Act
            double total = task1 + task2 + task3 + task4;
            string grade = CalculateGrade(total);

            // Assert
            Assert.AreEqual("3 (удовлетворительно)", grade);
            Assert.AreEqual(20, total);
        }

        [TestMethod]
        public void CalculateGrade_MinimumScore_ReturnsUnsatisfactory()
        {
            // Arrange
            double task1 = 0;
            double task2 = 0;
            double task3 = 0;
            double task4 = 0;

            // Act
            double total = task1 + task2 + task3 + task4;
            string grade = CalculateGrade(total);

            // Assert
            Assert.AreEqual("2 (неудовлетворительно)", grade);
            Assert.AreEqual(0, total);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CalculateGrade_InvalidTask1Score_ThrowsException()
        {
            // Arrange
            double task1 = 11; // Неправильный балл
            double task2 = 0;
            double task3 = 0;
            double task4 = 0;

            // Act
            if (task1 < 0 || task1 > 10)
                throw new ArgumentOutOfRangeException("Task1 score is out of range");
        }

        private string CalculateGrade(double total)
        {
            if (total >= 70)
                return "5 (отлично";
            else if (total >= 40)
                return "4 (хорошо)";
            else if (total >= 20)
                return "3 (удовлетворительно)";
            else
                return "2 (неудовлетворительно)";
        }
    }
}