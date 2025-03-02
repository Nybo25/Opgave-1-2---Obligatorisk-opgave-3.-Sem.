using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opgave_1_og_2___Obl_Opgave;

namespace TrophyTests
{
    [TestClass]
    public class TrophyTests
    {
        [TestMethod]
        public void Trophy_ValidProperties_ShouldSetProperties()
        {
            var trophy = new Trophy
            {
                Id = 1,
                Competition = "Championship",
                Year = 2020
            };

            Assert.AreEqual(1, trophy.Id);
            Assert.AreEqual("Championship", trophy.Competition);
            Assert.AreEqual(2020, trophy.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Trophy_InvalidId_ShouldThrowException()
        {
            var trophy = new Trophy();
            trophy.Id = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Trophy_InvalidCompetition_ShouldThrowException()
        {
            var trophy = new Trophy();
            trophy.Competition = "AB";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Trophy_InvalidCompetition_ShouldThrowException_Null()
        {
            var trophy = new Trophy();
            trophy.Competition = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Trophy_InvalidYear_ShouldThrowException()
        {
            var trophy = new Trophy();
            trophy.Year = 1969;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Trophy_InvalidYear_ShouldThrowException_TooHigh()
        {
            var trophy = new Trophy();
            trophy.Year = 2026;
        }

        [TestMethod]
        public void Trophy_ToString_ShouldReturnCorrectFormat()
        {
            var trophy = new Trophy
            {
                Id = 1,
                Competition = "Championship",
                Year = 2020
            };

            var expected = "Trophy [Id=1, Competition=Championship, Year=2020]";
            Assert.AreEqual(expected, trophy.ToString());
        }
    }
}