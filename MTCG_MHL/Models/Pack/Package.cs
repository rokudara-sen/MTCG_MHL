using MTCG_MHL.Models.Cards;

namespace MTCG_MHL.Models.Package;

public class Package
{
    public Package(List<Card> cards, int costOfCoins)
    {
        Cards = cards;
        Cost = costOfCoins;
    }
    
    public List<Card> Cards { get; private set; } = new List<Card>();
    
    public int Cost { get; private set; }
}