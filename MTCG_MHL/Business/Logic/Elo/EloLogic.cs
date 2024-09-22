using MTCG_MHL.Models.Player;

namespace MTCG_MHL.Business.Logic.Elo;

public class EloLogic
{
    public void AdjustEloPointsAfterBattle(User winner, User loser)
    {
        winner.Elo += 3;
        if ((loser.Elo - 5) < 0)
        {
            loser.Elo = 0;
        }
        else
        {
            loser.Elo -= 5;
        }
    }
}