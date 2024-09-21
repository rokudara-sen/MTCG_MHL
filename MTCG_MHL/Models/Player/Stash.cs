using MTCG_MHL.Models.Cards;

namespace MTCG_MHL.Models.Player;

public class Stash
{
    public Stash(List<Card> playerStash)
    {
        PlayerStash = playerStash;
    }
    
    public List<Card> PlayerStash { get; set; }
}