namespace Poker
{
    using System;
    using System.Linq;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        private const int CardsPerHand = 5;

        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != CardsPerHand)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count - 1; i++)
            {
                for (int k = i + 1; k < hand.Cards.Count; k++)
                {
                    if (hand.Cards[i].ToString() == hand.Cards[k].ToString())
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Provided hand is not valid.");
            }

            return this.AreCardsOfSameSuit(hand) && this.IsStraight(hand);
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Provided hand is not valid.");
            }

            return this.AreCardsOfSameKind(hand, 4);
        }

        public bool IsFullHouse(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Provided hand is not valid.");
            }

            return this.AreCardsOfSameKind(hand, 3) && this.AreCardsOfSameKind(hand, 2);
        }

        public bool IsFlush(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Provided hand is not valid.");
            }

            return this.AreCardsOfSameSuit(hand) && this.AreCardsSequential(hand);
        }

        public bool IsStraight(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Provided hand is not valid.");
            }

            var orderedByCardFace = hand.Cards
                .OrderBy(x => (int)x.Face)
                .ToArray();

            for (int i = 0; i < orderedByCardFace.Count() - 1; i++)
            {
                if ((int)orderedByCardFace[i].Face != (int)orderedByCardFace[i + 1].Face - 1)
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Provided hand is not valid.");
            }

            return this.AreCardsOfSameKind(hand, 3) && !this.AreCardsOfSameKind(hand,2);
        }

        public bool IsTwoPair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Provided hand is not valid.");
            }

            var groupedByCardFace = hand.Cards
                .GroupBy(x => x.Face)
                .ToDictionary(x => x.Key, y => y.Count())
                .Where(x => x.Value == 2);

            return groupedByCardFace.Count() == 2;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Provided hand is not valid.");
            }

            var groupedByCardFace = hand.Cards
                .GroupBy(x => x.Face)
                .ToDictionary(x => x.Key, y => y.Count())
                .Where(x => x.Value == 2);

            return groupedByCardFace.Count() == 1;
        }

        public bool IsHighCard(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Provided hand is not valid.");
            }

            if (this.IsStraight(hand) || this.AreCardsOfSameSuit(hand))
            {
                return false;
            }

            var groupedByCardFace = hand.Cards
                .GroupBy(x => x.Face)
                .ToDictionary(x => x.Key, y => y.Count());

            return groupedByCardFace.Count == hand.Cards.Count;
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (!IsValidHand(firstHand) || !IsValidHand(secondHand))
            {
                throw new ArgumentException("Provided hand is not valid.");
            }

            if (DuplicateCardsCheck(firstHand, secondHand))
            {
                throw new ArgumentException("Two hands can't contain duplicate cards.");
            }

            var firstHandStrength = this.CheckHandStrength(firstHand);
            var secondHandStrength = this.CheckHandStrength(secondHand);

            if (firstHandStrength > secondHandStrength)
            {
                return 1;
            }
            else if (firstHandStrength < secondHandStrength)
            {
                return -1;
            }
            else
            {
                var firstHandOrderedByCardFace = firstHand.Cards.OrderByDescending(x => (int)x.Face).ToArray();
                var secondHandOrderedByCardFace = secondHand.Cards.OrderByDescending(x => (int)x.Face).ToArray();

                for (int i = 0; i < CardsPerHand; i++)
                {
                    if ((int)firstHandOrderedByCardFace[i].Face > (int)secondHandOrderedByCardFace[i].Face)
                    {
                        return 1;
                    }
                    else if ((int)firstHandOrderedByCardFace[i].Face < (int)secondHandOrderedByCardFace[i].Face)
                    {
                        return -1;
                    }
                }

                return 0;
            }
        }

        private bool AreCardsOfSameSuit(IHand hand)
        {
            var suit = hand.Cards[0].Suit;
            return hand.Cards.All(x => x.Suit == suit);
        }

        private bool AreCardsSequential(IHand hand)
        {
            var groupedByValue = hand.Cards.GroupBy(x => x.Face);
            return groupedByValue.Count() == hand.Cards.Count;
        }

        private bool AreCardsOfSameKind(IHand hand, int sameCardsCount)
        {
            var groupedByFace = hand.Cards
                .GroupBy(x => x.Face)
                .ToDictionary(x => x.Key, y => y.Count());

            return groupedByFace.ContainsValue(sameCardsCount);
        }

        private int CheckHandStrength(IHand hand)
        {
            var handStrengthCheckers = new Func<IHand, bool>[] 
            {
                    IsStraightFlush,
                    IsFourOfAKind,
                    IsFullHouse,
                    IsFlush,
                    IsStraight,
                    IsThreeOfAKind,
                    IsTwoPair,
                    IsOnePair,
                    IsHighCard
            };

            var length = handStrengthCheckers.Length;

            for (int i = 0; i < length; i++)
            {
                if (handStrengthCheckers[i](hand))
                {
                    return length - i;
                }
            }

            throw new InvalidOperationException("Fatal error! Hand strength can not be correctly determined.");
        }

        private bool DuplicateCardsCheck(IHand firstHand, IHand secondHand)
        {
            for (int i = 0; i < CardsPerHand; i++)
            {
                if (firstHand.Cards[i].ToString() == secondHand.Cards[i].ToString())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
