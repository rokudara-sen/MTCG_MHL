using System;
using MTCG_MHL.Business.Logic.Battle;
using MTCG_MHL.Models.Player;
using MTCG_MHL.Business.Logic.Inventory;
using MTCG_MHL.Business.Logic.Pack;


namespace MTCG_MHL;

class Program
{
    static void Main(string[] args)
    {
        var packLogic = new PackLogic();
        var user1 = new User("Peter", "Peter");
        var user2 = new User("Franz", "Franz");
        var inventoryLogic1 = new InventoryLogic(user1);
        var inventoryLogic2 = new InventoryLogic(user2);

        user1.Gold = 100;

        var packagePeter = packLogic.CreatePackage(5, 100);
        var packageFranz = packLogic.CreatePackage(5, 10);
        
        packLogic.BuyPackage(user1, packagePeter);
        packLogic.BuyPackage(user2, packageFranz);
        
        foreach (var card in packagePeter.Cards.OrderByDescending(x => x.CardRarity).Take(4))
        {
            inventoryLogic1.AddCardToDeck(card);
        }
        
        foreach (var card in packageFranz.Cards.OrderByDescending(x => x.CardRarity).Take(4))
        {
            inventoryLogic2.AddCardToDeck(card);
        }

        
        var battleLogic = new BattleLogic(user1, user2);
        var battleResult = battleLogic.StartBattle(user1, user2);
        
        if (battleResult.IsDraw)
        {
            Console.WriteLine("The battle ended in a draw.");
        }
        else
        {
            Console.WriteLine("Winner: {0}, Loser: {1}", battleResult.Winner.Username, battleResult.Loser.Username);
        }

    }
}