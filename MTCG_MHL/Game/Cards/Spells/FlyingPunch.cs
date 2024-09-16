using MTCG_MHL.Interface;

namespace MTCG_MHL.Game.Cards.Spells;

public class FlyingPunch : Card, ISpell
{
    public FlyingPunch()
    {
        ElementType = "Normal";
        CardName = "FlyingPunch";
        CardDamage = 5;
    }
    
    public void SpellCast()
    {
        throw new NotImplementedException();
    }
}