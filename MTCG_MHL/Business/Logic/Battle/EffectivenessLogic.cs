using System.Diagnostics;
using MTCG_MHL.Enums;
using MTCG_MHL.Models.Cards;

namespace MTCG_MHL.Business.Logic.Battle;

public class EffectivenessLogic
{
    public double CalculateEffectiveness(Card attacker, Card defender)
    {
        if (attacker.ElementType == ElementType.Water)
        {
            switch (defender.ElementType)
            {
                case ElementType.Fire:
                    return 2.0;
                case ElementType.Normal:
                    return 0.5;
                default:
                    return 1.0;
            }
        }
        if (attacker.ElementType == ElementType.Fire)
        {
            switch (defender.ElementType)
            {
                case ElementType.Water:
                    return 0.5;
                case ElementType.Normal:
                    return 2.0;
                default:
                    return 1.0;
            }
        }
        if (attacker.ElementType == ElementType.Normal)
        {
            switch (defender.ElementType)
            {
                case ElementType.Water:
                    return 2.0;
                case ElementType.Fire:
                    return 0.5;
                default:
                    return 1.0;
            }
        }
        return 1.0;
    }
}