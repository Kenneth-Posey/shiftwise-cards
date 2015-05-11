using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftwiseTestCsharp
{
    public class Card
    {
        public enum Face
        {
            Hearts,
            Clubs,
            Diamond,
            Spade
        }

        public Face CardFace { get; private set; }
        public int CardValue { get; private set; }

        public Card(Face face, int value)
        {
            if (value <= 0 || 13 < value)
                throw new ArgumentOutOfRangeException("value", "Argument out of range. Value must be 1 to 13 inclusive.");

            CardFace = face;
            CardValue = value;
        }
    }
    
    public class CardDeck
    {
        public static List<Card> BuildDeck()
        {
            var deck = new List<Card>();
            var faces = new List<Card.Face>(){
                Card.Face.Hearts, Card.Face.Clubs, Card.Face.Diamond, Card.Face.Spade
            };

            foreach (var face in faces)
            {
                for (int i = 1; i <= 13; i++)
                {
                    deck.Add(new Card(face, i));
                }
            }

            return deck;
        }

        public static List<Card> SortDeck(List<Card> deck)
        {
            // This compares the face *first* and the value *second*
            deck.Sort(delegate(Card first, Card second)
            {
                int face = first.CardFace.CompareTo(second.CardFace);

                if (face == 0)
                    return first.CardValue.CompareTo(second.CardValue);

                return face;
            });

            return deck;
        }

        public static List<Card> ShuffleDeck(List<Card> deck)
        {
            return deck.Shuffle();
        }
    }
}
