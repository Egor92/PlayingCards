using System;
using System.Collections.Generic;
using System.Linq;

namespace Egor92.PlayingCards
{
    using System.Collections;

    public interface IDeck<TCard>
    {
        int Count { get; }
        bool IsEmpty { get; }
        TCard TakeCard();
        void PutCard(TCard card);
        void Shuffle();
    }

    public class Deck<TCard> : IDeck<TCard>, IEnumerable<TCard>
        where TCard : ICard
    {
        #region Fields

        private Queue<TCard> _cards;

        #endregion

        #region Ctor

        public Deck(IEnumerable<TCard> cards)
        {
            _cards = new Queue<TCard>(cards);
        }

        #endregion

        #region Implementation of IDeck<TCard>

        public int Count
        {
            get { return _cards.Count; }
        }

        public bool IsEmpty
        {
            get { return _cards.Count == 0; }
        }

        public TCard TakeCard()
        {
            return _cards.Dequeue();
        }

        public void PutCard(TCard card)
        {
            _cards.Enqueue(card);
        }

        public void Shuffle()
        {
            var seed = (int)(DateTime.Now.ToFileTime() % int.MaxValue);
            var random = new Random(seed);
            var shuffledCards = _cards.ToDictionary(item => random.NextDouble())
                                      .OrderBy(x => x.Key)
                                      .Select(x => x.Value);
            _cards = new Queue<TCard>(shuffledCards);
        }

        #endregion

        #region Implementation of IEnumerable<TCard>

        public IEnumerator<TCard> GetEnumerator()
        {
            return _cards.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
