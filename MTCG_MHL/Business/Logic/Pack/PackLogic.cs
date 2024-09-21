using MTCG_MHL.Business.Enums;
using MTCG_MHL.Enums;
using MTCG_MHL.Models.Cards;

namespace MTCG_MHL.Business.Logic.Pack;

public class PackLogic
{
    public List<Card> Package(int amountOfCards)
    {
        Random rnd = new Random();
        List<Card> cards = new List<Card>();
        
        ElementType[] elementTypeValues = (ElementType[])Enum.GetValues(typeof(ElementType));
        CardType[] cardTypeValues = (CardType[])Enum.GetValues(typeof(CardType));
        CardName[] cardNameValues = (CardName[])Enum.GetValues(typeof(CardName));
        VisibleName[] visibleNameValues = (VisibleName[])Enum.GetValues(typeof(VisibleName));

        Card card;
        for (int i = 0; i < amountOfCards; i++)
        {
            ElementType randomElementType = elementTypeValues[rnd.Next(elementTypeValues.Length)];
            CardType randomCardType = cardTypeValues[rnd.Next(cardTypeValues.Length)];
            CardName randomCardName = cardNameValues[rnd.Next(cardNameValues.Length)];
            VisibleName randomVisibleName = visibleNameValues[rnd.Next(visibleNameValues.Length)];
            
            int cardRarity = RarityLogic.GetRandomRarity();
            int baseDamage = 0;
            
            if (cardRarity >= 45)
            {
                baseDamage = rnd.Next(20, 25);
            }
            else if (cardRarity >= 30)
            { 
                baseDamage = rnd.Next(15, 19);
            }
            else if (cardRarity >= 20)
            { 
                baseDamage = rnd.Next(10, 14);
            }
            else if (cardRarity >= 10)
            {
                baseDamage = rnd.Next(5, 9);
            }
            else
            {
                baseDamage = rnd.Next(1, 4);
            }
            card = CardFactory.CreateCard(randomElementType, randomCardName, randomVisibleName, randomCardType, baseDamage, cardRarity);
            cards.Add(card);
        }
        return cards;
    }
    
    public void PrintPackage(List<Card> cards)
    {
        Console.WriteLine("Generated Cards in Package:");
        foreach (var card in cards)
        {
            Console.WriteLine($"Card Name: {EnumHelper.GetDescription(card.CardName)}");
            Console.WriteLine($"Element Type: {EnumHelper.GetDescription(card.ElementType)}");
            Console.WriteLine($"Visible Name: {EnumHelper.GetDescription(card.VisibleName)}");
            Console.WriteLine($"Base Damage: {card.BaseDamage}");
            Console.WriteLine($"Card Rarity: {card.CardRarity}");
            Console.WriteLine(new string('-', 30));
        }
    }
}