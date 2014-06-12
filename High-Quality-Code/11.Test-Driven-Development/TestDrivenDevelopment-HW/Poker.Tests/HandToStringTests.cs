using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class HandToStringTests
    {
        [TestMethod]
        public void EmptyHandTest()
        {
            var hand = new Hand(new List<ICard>());
            var expectedResult = string.Empty;

            Assert.AreEqual(expectedResult, hand.ToString());
        }

        [TestMethod]
        public void JackOfDiamondsHandTest()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Jack, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            var expectedResult = "J♦";

            Assert.AreEqual(expectedResult, hand.ToString());
        }

        [TestMethod]
        public void TwoOfClubsAndFiveOfHeartsHandTest()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts)
            };

            var hand = new Hand(cards);
            var expectedResult = "2♣ 5♥";

            Assert.AreEqual(expectedResult, hand.ToString());
        }

        [TestMethod]
        public void RoyalFlushOfSpadesHandTest()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades)
            };

            var hand = new Hand(cards);
            var expectedResult = "A♠ K♠ Q♠ J♠ 10♠";

            Assert.AreEqual(expectedResult, hand.ToString());
        }
    }
}
