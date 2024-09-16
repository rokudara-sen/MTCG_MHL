using System.Numerics;
using MTCG_MHL.Game;

namespace MTCG_MHL.Client;

public class User
{
    public User(string username, string password)
    {
        Username = username;
        Password = password;
        Elo = 100;
        Gold = 20;
    }
    
    public string Username { get; private set; }
    
    public string Password { get; private set; }
    
    public int Elo { get; private set; }
    
    public int Gold { get; private set; }

    public List<Card> Deck { get; set; } = new List<Card>();
    
    public List<Card> CardStack { get; set; } = new List<Card>();

    public void AddCardToStash(Card card)
    {
        CardStack.Add(card);
    }

    public void RemoveCardFromStash(Card card)
    {
        CardStack.Remove(card);
    }
    
    public void AddCardToDeck(Card card)
    {
        if (CardStack.Count < 4)
        {
            for (int i = 0; i < CardStack.Count; i++)
            {
                if (CardStack[i] == card)
                    Deck.Add(card);
                else
                {
                    Console.WriteLine("Card is not in Stash\n");
                }
            }
        }
        else
            Console.WriteLine("Deck is full. Please remove a card first.\n");
    }

    public void RemoveCardFromDeck(Card card)
    {
        Deck.Remove(card);
        Console.WriteLine("{0} has been removed.\n", card);
    }

    public void ListDeck()
    {
        for (int i = 0; i < Deck.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Deck[i]}");
        }
    }
}