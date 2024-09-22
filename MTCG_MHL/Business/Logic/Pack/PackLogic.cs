using MTCG_MHL.Business.Enums;
using MTCG_MHL.Business.Logic.Inventory;
using MTCG_MHL.Enums;
using MTCG_MHL.Models.Cards;
using MTCG_MHL.Models.Package;
using MTCG_MHL.Models.Player;

namespace MTCG_MHL.Business.Logic.Pack;

public class PackLogic
{
    public Package CreatePackage(int amountOfCards, int costOfCoins)
    {
        Random rnd = new Random();
        CardDamageLogic cardDamageLogic = new CardDamageLogic();
        List<Card> cards = new List<Card>();
        
        ElementType[] elementTypeValues = (ElementType[])Enum.GetValues(typeof(ElementType));
        CardName[] cardNameValues = (CardName[])Enum.GetValues(typeof(CardName));
        VisibleName[] visibleNameValues = (VisibleName[])Enum.GetValues(typeof(VisibleName));

        
        for (int i = 0; i < amountOfCards; i++)
        {
            ElementType randomElementType = elementTypeValues[rnd.Next(elementTypeValues.Length)];
            CardName randomCardName = cardNameValues[rnd.Next(cardNameValues.Length)];
            VisibleName randomVisibleName = visibleNameValues[rnd.Next(visibleNameValues.Length)];
            
            int cardRarity = RarityLogic.GetRandomRarity(costOfCoins);
            int baseDamage = cardDamageLogic.CalculateBaseDamage(cardRarity);
            Card card = CardFactory.CreateCard(randomElementType, randomCardName, randomVisibleName, baseDamage, cardRarity);
            cards.Add(card);
        }
        return new Package(cards, costOfCoins);
    }
    
    public void BuyPackage(User user, Package package)
    {
        InventoryLogic inventoryLogic = new InventoryLogic(user);
        if (user.Gold < package.Cost)
        {
            throw new ArgumentException("Not enough gold to buy this package.");
        }
        if ((user.Gold - package.Cost) < 0)
        {
            throw new ArgumentException("You cannot go into negative gold.");
        }
        user.Gold -= package.Cost;
        foreach (var card in package.Cards)
        {
            inventoryLogic.AddCardToStash(card);
        }
    }
    
    public void PrintPackage(Package package)
    {
        Console.WriteLine("Generated Cards in Package:");
        foreach (var card in package.Cards)
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