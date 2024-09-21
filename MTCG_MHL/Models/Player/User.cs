using MTCG_MHL.Models.Cards;

namespace MTCG_MHL.Models.Player;

public class User
{
    public User(string username, string password)
    {
        Username = username;
        Password = password;
        Elo = 100;
        Gold = 20;
        PlayerDeck = new Deck(new List<Card>());
        PlayerStash = new Stash(new List<Card>());
    }
    
    public string Username { get; private set; }
    
    public string Password { get; private set; }
    
    public int Elo { get; private set; }
    
    public int Gold { get; private set; }
    
    public Deck PlayerDeck { get; set; }
    
    public Stash PlayerStash { get; set; }
}