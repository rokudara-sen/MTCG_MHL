using System.Numerics;
using MTCG_MHL.Game;

namespace MTCG_MHL.Client;

public class User
{
    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }
    
    public string Username
    {
        get;
        private set;
    }
    
    public string Password
    {
        get;
        private set;
    }

    public List<Card> Deck
    {
        get;
        set;
    }

    public void AddCardToDeck(Card card)
    {
        Deck.Add(card);
    }

    public void RemoveCardFromDeck(Card card)
    {
        Deck.Remove(card);
    }

    public void ListDeck()
    {
        for (int i = 0; i < Deck.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Deck[i]}");
        }
    }
}