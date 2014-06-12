using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.Tests
{
    [TestClass]
    public class CardToStringTests
    {
        [TestMethod]
        public void TenOfSpadesToStringTest()
        {
            var tenOfSpades = new Card(CardFace.Ten, CardSuit.Spades);
            string expectedResult = "10♠";

            Assert.AreEqual(expectedResult, tenOfSpades.ToString());
        }

        [TestMethod]
        public void KingOfDiamondsToStringTest()
        {
            var kingOfDiamonds = new Card(CardFace.King, CardSuit.Diamonds);
            string expectedResult = "K♦";

            Assert.AreEqual(expectedResult, kingOfDiamonds.ToString());
        }

        [TestMethod]
        public void QueenOfClubsToStringTest()
        {
            var queenOfClubs = new Card(CardFace.Queen, CardSuit.Clubs);
            string expectedResult = "Q♣";

            Assert.AreEqual(expectedResult, queenOfClubs.ToString());
        }

        [TestMethod]
        public void FourOfHeartsToStringTest()
        {
            var fourOfHearts = new Card(CardFace.Four, CardSuit.Hearts);
            string expectedResult = "4♥";

            Assert.AreEqual(expectedResult, fourOfHearts.ToString());
        }
    }
}
