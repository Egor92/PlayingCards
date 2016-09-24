namespace Egor92.PlayingCards
{
    using System;

    public class Joker : ICard, IEquatable<Joker>
    {
        #region Ctor

        public Joker(CardColor color)
        {
            Color = color;
        }

        #endregion

        #region Properties

        #region Color

        public CardColor Color { get; }

        #endregion

        #endregion

        #region Overridden members

        #region Overrides of Object

        public override string ToString()
        {
            return $"Card: {Color} Joker";
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Joker)obj);
        }

        public override int GetHashCode()
        {
            return (int)Color;
        }

        #endregion

        #region Implementation of ICard

        public string Key
        {
            get { return $"{Color.ToString().ToUpper()}_JOKER"; }
        }

        public string Code
        {
            get { return $"{Color.ToSymbol()}J"; }
        }

        #endregion

        #region Implementation of IEquatable<Joker>

        public bool Equals(Joker other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Color == other.Color;
        }

        #endregion

        public static bool operator ==(Joker left, Joker right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Joker left, Joker right)
        {
            return !Equals(left, right);
        }
    }
}
