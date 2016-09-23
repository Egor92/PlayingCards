namespace Egor92.PlayingCards
{
    public class Joker : ICard
    {
        public Joker(CardColor color)
        {
            Color = color;
        }
        
        public CardColor Color { get; private set; }
    }
}
