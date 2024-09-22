using MTCG_MHL.Enums;
using MTCG_MHL.Models.Cards;
using MTCG_MHL.Models.Cards.Monsters;
using MTCG_MHL.Models.Cards.Spells;

namespace MTCG_MHL.Business.Logic.Pack;

public class CardFactory
{
    public static Card CreateCard(ElementType elementType, CardName cardName, VisibleName visibleName, int baseDamage, int cardRarity = 0)
    {
        if(cardRarity == 0)
        {
            cardRarity = RarityLogic.GetRandomRarity(10);
        }
        switch (cardName)
        {
            // Monster cards
            case CardName.Dragon:
                return new Dragon(elementType, visibleName, baseDamage, cardRarity, 50);
            case CardName.Elf:
                return new Elf(elementType, visibleName, baseDamage, cardRarity, 20);
            case CardName.Goblin:
                return new Goblin(elementType, visibleName, baseDamage, cardRarity, 15);
            case CardName.Knight:
                return new Kraken(elementType, visibleName, baseDamage, cardRarity, 30);
            case CardName.Kraken:
                return new Ork(elementType, visibleName, baseDamage, cardRarity, 40);
            case CardName.Wizard:
                return new Wizard(elementType, visibleName, baseDamage, cardRarity, 20);
            case CardName.Ork:
                return new Ork(elementType, visibleName, baseDamage, cardRarity, 40);

            // Spell cards
            case CardName.FlyingPunch:
                return new FlyingPunch(elementType, visibleName, baseDamage, cardRarity, "Sheesh");
            case CardName.Ignitio:
                return new Ignitio(elementType, visibleName, baseDamage, cardRarity, "Shash");
            case CardName.Tsunami:
                return new Tsunami(elementType, visibleName, baseDamage, cardRarity, "Sasdad");

            default:
                throw new ArgumentException($"Unknown card name: {cardName}");
        }
    }
}