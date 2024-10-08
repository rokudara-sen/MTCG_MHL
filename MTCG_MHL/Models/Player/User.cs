using Microsoft.VisualBasic;
using MTCG_MHL.Models.Cards;

namespace MTCG_MHL.Models.Player;

public class User
{
    public User()
    {
        
    }
    public User(string username, string password)
    {
        Username = username;
        Password = password;
        Elo = 100;
        Gold = 20;
        PlayerDeck = new Deck(new List<Card>());
        PlayerStash = new Stash(new List<Card>());
        Wins = 0;
        Losses = 0;
    }
    
    public string Username { get; set; }
    
    public string Password { get; set; }
    
    public int Elo { get; set; }
    
    public int Gold { get; set; }
    
    public Deck PlayerDeck { get; set; }
    
    public Stash PlayerStash { get; set; }
    
    public int Wins { get; set; }
    
    public int Losses { get; set; }
    
    public string AuthToken { get; set; }
}