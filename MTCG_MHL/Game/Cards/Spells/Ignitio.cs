using System.Net;
using MTCG_MHL.Interface;

namespace MTCG_MHL.Game.Cards.Spells;

public class Ignitio : Card, ISpell
{
    public Ignitio()
    {
        ElementType = "Fire";
        CardName = "Ignitio";
        CardDamage = 5;
    }
    
    public void SpellCast()
    {
        throw new NotImplementedException();
    }
}