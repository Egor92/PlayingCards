namespace Egor92.PlayingCards
{
    public class Card : ICard
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

        public Rank Rank { get; private set; }

        #endregion

        #region Suit

        public Suit Suit { get; private set; }

        #endregion

        #region Color

        public CardColor Color
        {
            get { return Suit.ToColor(); }
        }

        #endregion

        #endregion
    }
}
