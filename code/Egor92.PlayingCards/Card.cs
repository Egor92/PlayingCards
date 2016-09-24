using System;

namespace Egor92.PlayingCards
{
    public class Card : ICard, IEquatable<Card>
    {
        #region Ctor

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        #endregion

        #region Properties

        #region Rank

        public Rank Rank { get; }

        #endregion

        #region Suit

        public Suit Suit { get; }

        #endregion

        #region Color

        public CardColor Color
        {
            get { return Suit.ToColor(); }
        }

        #endregion

        #endregion

        #region Overridden members

        public override string ToString()
        {
            return $"Card: {Rank.ToSymbol()}{Suit.ToSymbol()}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Card)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int)Rank * 397) ^ (int)Suit;
            }
        }

        #endregion

        #region Implementation of ICard

        public string Key
        {
            get { return $"{Rank.ToString().ToUpper()}_OF_{Suit.ToString().ToUpper()}"; }
        }

        public string Code
        {
            get { return $"{Rank.ToSymbol()}{Suit.ToSymbol()}"; }
        }

        #endregion

        #region Implementation of IEquatable<Card>

        public bool Equals(Card other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Rank == other.Rank && Suit == other.Suit;
        }

        #endregion

        public static bool operator ==(Card left, Card right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Card left, Card right)
        {
            return !Equals(left, right);
        }
    }
}
