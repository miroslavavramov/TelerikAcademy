using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class PokerHandsCheckerTests
    {
        private static PokerHandsChecker checker;

        [ClassInitialize]
        public static void InitializePokerHandsChecker(TestContext textContext)
        {
            checker = new PokerHandsChecker();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SetNullHandToIsValidHandMethod()
        {
            checker.IsValidHand(null);
        }

        [TestMethod]
        public void SetValidHandToIsValidHandMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
            };

            var hand = new Hand(cards);
            Assert.IsTrue(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void SetDuplicateCardsToIsValidHandMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
            };

            var hand = new Hand(cards);
            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void SetMoreThanAllowedCardsToIsValidHandMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Six, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Clubs),
            };

            var hand = new Hand(cards);
            Assert.IsFalse(checker.IsValidHand(hand));
        }

        [TestMethod]
        public void SetValidFlushHandToIsFlushMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            Assert.IsTrue(checker.IsFlush(hand));
        }

        [TestMethod]
        public void SetInvalidFlushHandToIsFlushMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            Assert.IsFalse(checker.IsFlush(hand));
        }

        [TestMethod]
        public void SetValidFourOfAKindInIsFourOfAKindMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            Assert.IsTrue(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void SetInvalidFourOfAKindInIsFourOfAKindMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            Assert.IsFalse(checker.IsFourOfAKind(hand));
        }

        [TestMethod]
        public void SetValidFullHouseInIsFullHouseMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            Assert.IsTrue(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void SetInvalidFullHouseInIsFullHouseMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Spades)
            };

            var hand = new Hand(cards);
            Assert.IsFalse(checker.IsFullHouse(hand));
        }

        [TestMethod]
        public void SetValidStraightToIsStraightMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades)
            };

            var hand = new Hand(cards);
            Assert.IsTrue(checker.IsStraight(hand));
        }

        [TestMethod]
        public void SetInvalidStraightToIsStraightMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Spades)
            };

            var hand = new Hand(cards);
            Assert.IsFalse(checker.IsStraight(hand));
        }

        [TestMethod]
        public void SetValidStraightFlushToIsStraightFlushMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades)
            };

            var hand = new Hand(cards);
            Assert.IsTrue(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void SetInvalidStraightFlushToIsStraightFlushMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades)
            };

            var hand = new Hand(cards);
            Assert.IsFalse(checker.IsStraightFlush(hand));
        }

        [TestMethod]
        public void SetValidThreeOfKindToIsThreeOfKindMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades)
            };

            var hand = new Hand(cards);
            Assert.IsTrue(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void SetInvalidThreeOfKindToIsThreeOfKindMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades)
            };

            var hand = new Hand(cards);
            Assert.IsFalse(checker.IsThreeOfAKind(hand));
        }

        [TestMethod]
        public void SetValidTwoPairsToIsTwoPairMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades)
            };

            var hand = new Hand(cards);
            Assert.IsTrue(checker.IsTwoPair(hand));
        }

        [TestMethod]
        public void SetInvalidTwoPairsToIsTwoPairMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            Assert.IsFalse(checker.IsTwoPair(hand));
        }
        
        [TestMethod]
        public void SetValidPairToIsOnePairMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            Assert.IsTrue(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void SetInvalidPairToIsOnePairMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            Assert.IsFalse(checker.IsOnePair(hand));
        }

        [TestMethod]
        public void SetValidHandToIsHighHandMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Six, CardSuit.Diamonds)
            };

            var hand = new Hand(cards);
            Assert.IsTrue(checker.IsHighCard(hand));
        }

        [TestMethod]
        public void SetInvalidHandToIsHighHandMethod()
        {
            var cards = new List<ICard>() 
            {
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts)
            };

            var hand = new Hand(cards);
            Assert.IsFalse(checker.IsHighCard(hand));
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void SetHandsWithDuplicateCardsInCompareHandsMethod()
        {
            var firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Hearts)
            });

            var secondHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Jack, CardSuit.Hearts),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds)
            });

            checker.CompareHands(firstHand, secondHand);
        }

        [TestMethod]
        public void CompareHandsRoyalFlushVsStraightFlushTest()
        {
            var royalFlush = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Spades)
            });

            var straightFlush = new Hand(new List<ICard>() 
            {
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            Assert.IsTrue(checker.CompareHands(royalFlush, straightFlush) == 1);
        }

        [TestMethod]
        public void CompareHandsFourOfAKindVsFullHouseTest()
        {
            var fourSevens = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Spades)
            });

            var fullHouse = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds)
            });

            Assert.IsTrue(checker.CompareHands(fourSevens, fullHouse) == 1);
        }

        [TestMethod]
        public void CompareHandsHighCardWithKingVsHighCardWithJackTest()
        {
            var highCardWithJack = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Jack, CardSuit.Spades),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds)
            });

            var highCardWithKing = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Spades)
            });

            Assert.IsTrue(checker.CompareHands(highCardWithJack, highCardWithKing) == -1);
        }

        [TestMethod]
        public void CompareHandsTwoEqualPairsTest()
        {
            var firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds)
            });

            var secondHand = new Hand(new List<ICard>() 
            { 
                 new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            });

            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 0);
        }

        [TestMethod]
        public void CompareHandsTwoPairsTest()
        {
            var firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Diamonds)
            });

            var secondHand = new Hand(new List<ICard>() 
            { 
                 new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.King, CardSuit.Hearts)
            });

            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == -1);
        }

        [TestMethod]
        public void CompareHandsStraightVsStraightTest()
        {
            var firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Diamonds)
            });

            var secondHand = new Hand(new List<ICard>() 
            { 
                 new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts)
            });

            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == -1);
        }

        [TestMethod]
        public void CompareHandsOnePairWithQueenVsOnePairWithTenTest()
        {
            var firstHand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Diamonds)
            });

            var secondHand = new Hand(new List<ICard>() 
            { 
                 new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Hearts)
            });

            Assert.IsTrue(checker.CompareHands(firstHand, secondHand) == 1);
        }
    }
}
