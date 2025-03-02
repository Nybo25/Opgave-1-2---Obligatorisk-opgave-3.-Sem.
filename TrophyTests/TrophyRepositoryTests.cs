using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Opgave_1_og_2___Obl_Opgave;

namespace TrophyTests
{
    [TestClass]
    public class TrophiesRepositoryTests
    {
        private TrophiesRepository _repository;

        [TestInitialize]
        public void SetUp()
        {
            _repository = new TrophiesRepository();
        }

        [TestMethod]
        public void Get_ShouldReturnAllTrophies()
        {
            var trophies = _repository.Get();
            Assert.AreEqual(5, trophies.Count);
        }

        [TestMethod]
        public void GetById_ShouldReturnCorrectTrophy()
        {
            var trophy = _repository.GetById(1);
            Assert.IsNotNull(trophy);
            Assert.AreEqual(1, trophy.Id);
        }

        [TestMethod]
        public void Add_ShouldAddTrophy()
        {
            var newTrophy = new Trophy { Competition = "New Competition", Year = 2023 };
            var addedTrophy = _repository.Add(newTrophy);

            Assert.AreEqual(6, addedTrophy.Id);
            Assert.AreEqual(6, _repository.Get().Count);
        }
    }
}