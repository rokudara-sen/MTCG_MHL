using MTCG_MHL.Models.Cards;

namespace MTCG_MHL.Models.Player;

public class Deck
{
    public Deck(List<Card> playerDeck)
    {
        PlayerDeck = playerDeck;
    }
    
    public List<Card> PlayerDeck { get; set; }
}