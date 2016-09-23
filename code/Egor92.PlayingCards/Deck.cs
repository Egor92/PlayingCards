using System;
using System.Collections.Generic;

namespace Egor92.PlayingCards
{
    using System.Linq;

    public static class DeckFactory
    {
        private static readonly Rank[] Deck52Ranks = (Rank[])Enum.GetValues(typeof(Rank));

        private static readonly Rank[] Deck36Ranks = new Rank[]
        {
            Rank.Ace,
            Rank.Six,
            Rank.Seven,
            Rank.Eight,
            Rank.Nine,
            Rank.Ten,
            Rank.Jack,
            Rank.Queen,
            Rank.King,
        };

        public static List<Card> Create36Cards()
        {
            return Enumerate36Cards().ToList();
        }

        public static List<Card> Create52Cards()
        {
            return Enumerate52Cards().ToList();
        }

        public static List<ICard> Create52CardsAndJokers()
        {
            return Enumerable.Union<ICard>(Enumerate52Cards(), EnumerateJokers()).ToList();
        }

        private static IEnumerable<Card> Enumerate36Cards()
        {
            return EnumerateCards(Deck36Ranks);
        }

        private static IEnumerable<Card> Enumerate52Cards()
        {
            return EnumerateCards(Deck52Ranks);
        }

        private static IEnumerable<Card> EnumerateCards(IList<Rank> ranks)
        {
            var suits = (Suit[])Enum.GetValues(typeof(Suit));
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    yield return new Card(rank, suit);
                }
            }
        }

        private static IEnumerable<Joker> EnumerateJokers()
        {
            yield return new Joker(CardColor.Black);
            yield return new Joker(CardColor.Red);
        }
    }
}
