using MTCG_MHL.Enums;

namespace MTCG_MHL.Models.Cards;

public class MonsterCard : Card
{
    public MonsterCard(ElementType elementType, CardName cardName, int baseDamage, int cardRarity, int monsterHealth, VisibleName visibleName) : base(elementType, cardName, baseDamage, cardRarity)
    {
        MonsterHealth = monsterHealth;
        VisibleName = visibleName;
        
    }
    
    public int MonsterHealth { get; set; }
}