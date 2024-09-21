using MTCG_MHL.Enums;

namespace MTCG_MHL.Models.Cards;

public class SpellCard : Card
{
    public SpellCard(ElementType elementType, CardName cardName, int baseDamage, int cardRarity, string specialEffect, VisibleName visibleName) : base(elementType, cardName,
        baseDamage, cardRarity)
    {
        SpecialEffect = specialEffect;
        VisibleName = visibleName;
    }
    
    public string SpecialEffect { get; set; }
}