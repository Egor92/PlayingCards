namespace Egor92.PlayingCards
{
    using System;

    public enum Suit
    {
        Spades,
        Diamonds,
        Clubs,
        Hearts,
    }

    public static class SuitExtensions
    {
        public static CardColor ToColor(this Suit suit)
        {
            switch (suit)
            {
                case Suit.Clubs:
                case Suit.Spades:
                    return CardColor.Black;
                case Suit.Diamonds:
                case Suit.Hearts:
                    return CardColor.Red;
                default:
                    throw new Exception($"Unhandled case with {typeof(CardColor).FullName}");
            }
        }

    }
}
