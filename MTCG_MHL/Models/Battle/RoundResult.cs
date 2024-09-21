using MTCG_MHL.Models.Cards;

namespace MTCG_MHL.Models.Battle;

public class RoundResult
{
    public RoundResult(Card winner, Card loser)
    {
        Winner = winner;
        Loser = loser;
    }

    public RoundResult(bool isDraw)
    {
        IsDraw = isDraw;
    }
    
    public Card Winner { get; private set; }
    public Card Loser { get; private set; }
    public bool IsDraw { get; private set; }
}