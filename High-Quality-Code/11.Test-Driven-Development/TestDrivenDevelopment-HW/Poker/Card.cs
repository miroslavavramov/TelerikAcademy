using System;
using System.Text;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            if ((int)this.Face <= 10)
            {
                output.Append((int)this.Face);
            }
            else
            {
                output.Append(this.Face.ToString()[0]);
            }

            switch ((int)this.Suit)
            {
                case 1: output.Append("♣"); break;
                case 2: output.Append("♦"); break;
                case 3: output.Append("♥"); break;
                case 4: output.Append("♠"); break;
            }

            return output.ToString();
        }
    }
}
