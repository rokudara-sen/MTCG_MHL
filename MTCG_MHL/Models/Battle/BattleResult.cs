using MTCG_MHL.Models.Player;

namespace MTCG_MHL.Models.Battle;

public class BattleResult
{
    public BattleResult(User winner, User loser)
    {
        Winner = winner;
        Loser = loser;
    }

    public BattleResult(bool isDraw)
    {
        IsDraw = isDraw;
    }
    
    public User Winner { get; private set; }
    public User Loser { get; private set; }
    public bool IsDraw { get; private set; }
}