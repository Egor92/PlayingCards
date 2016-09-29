namespace Egor92.PlayingCards
{
    public enum CardColor
    {
        Red,
        Black,
    }

    public static class CardColorExtensions
    {
        public static char ToSymbol(this CardColor cardColor)
        {
            return cardColor.ToString()[0];
        }
    }
}
