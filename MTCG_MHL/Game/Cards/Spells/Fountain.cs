using MTCG_MHL.Interface;

namespace MTCG_MHL.Game.Cards.Spells;

public class Fountain : Card, ISpell
{
    public Fountain()
    {
        ElementType = "Water";
        CardName = "Fountain";
        CardDamage = 5;
    }
    
    public void SpellCast()
    {
        throw new NotImplementedException();
    }
}