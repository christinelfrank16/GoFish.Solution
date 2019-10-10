using System.Collections.Generic;
using System.Linq;

namespace GoFish.Models
{
    public class Card
    {
        public static List<Card> Deck = CreateDeck().ShuffleDeck();

        public string Suit { get; }
        public string Value { get; }
        public int Player { get; set; }
        public bool Color { get; }
        public bool IsMatched { get; set; }
        private static List<string> _values = new List<string> { "ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "jack", "queen", "king" };
        private static List<string> _suits = new List<string> { "clubs", "spades", "hearts", "diamonds" };
        public Card(string suit, string value, bool color)
        {
            Value = value;
            Suit = suit;
            Player = 0;  // represents deck
            Color = color;
            IsMatched = false;
        }

        public List<Card> CreateDeck()
        {
            List<Card> deck = new List<Card> { };
            for (int i = 0; i < _suits.Count; i++)
            {
                for (int j = 0; j < _values.Count; j++)
                {
                    bool color = (_suits[i] == "diamonds" || _suits[i] == "hearts") ? true : false;
                    Card card = new Card(_suits[i], _values[j], color);
                    deck.Add();
                }
            }
            return deck;
        }

        public void ShuffleDeck()
        {
            List<Card> shuffledDeck = new List<Card> { };
            Random rnd = new Random();
            for (int i = 0; i < 52; i++)
            {
                bool cardAvailable = false;
                int index = rnd.Next(0, Deck.Count);
                shuffledDeck.Add(Deck[index]);
                Deck.Remove(Deck[index]);
            }
            Deck = shuffledDeck;
        }

        public bool DealCard(int playerNum)
        {
            for (int i = 0; i < 52; i++)
            {
                if (Deck[i].Player == 0)
                {
                    Player = playerNum;
                    return true;
                }
            }
            return false;
        }

        public void InitialDeal(int playerCount)
        {
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < playerCount; j++)
                {
                    DealCard(j);
                }
            }
        }
        public Card FindCard(int playerNum, string value)
        {
            Card foundCard = Deck.Where(card => (card.Player == playerNum && card.Value == value)).FirstOrDefault();
            return foundCard;
        }

        public Card FindCard(int playerNum, string suit, string value)
        {
            Card foundCard = Deck.Where(card => (card.Player == playerNum && card.Suit == suit && card.Value == value)).FirstOrDefault();
            return foundCard;
        }

        public void GiveCard(Card card, int newPlayer)
        {
            card.Player = newPlayer;
        }

        public void CheckForMatch(int playerNum)
        {
            
        }

    }
}