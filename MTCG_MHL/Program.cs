using System;
using MTCG_MHL.Business.Logic.Battle;
using MTCG_MHL.Models.Player;
using MTCG_MHL.Business.Logic.Inventory;
using MTCG_MHL.Business.Logic.Pack;
using MTCG_MHL.Models.Cards.Monsters;
using MTCG_MHL.Models.Battle;
using MTCG_MHL.Models.Cards;

namespace MTCG_MHL;

class Program
{
    static void Main(string[] args)
    {
        var packLogic1 = new PackLogic();
        var user1 = new User("Peter", "Peter");
        var packLogic2 = new PackLogic();
        var user2 = new User("Franz", "Franz");
        var inventoryLogic1 = new InventoryLogic(user1);
        var inventoryLogic2 = new InventoryLogic(user2);

        var packagePeter = packLogic1.Package(50);
        var packageFranz = packLogic2.Package(50);
        
        var rnd = new Random();

        // For Peter
        foreach (var card in packagePeter)
        {
            inventoryLogic1.AddCardToStash(card);  // Add cards to the stash first
        }

        // Now add cards to the deck
        foreach (var card in packagePeter.OrderBy(x => rnd.Next()).Take(4))
        {
            inventoryLogic1.AddCardToDeck(card);
        }

        // For Franz
        foreach (var card in packageFranz)
        {
            inventoryLogic2.AddCardToStash(card);
        }

        // Now add cards to the deck
        foreach (var card in packageFranz.OrderBy(x => rnd.Next()).Take(4))
        {
            inventoryLogic2.AddCardToDeck(card);
        }

        
        var battleLogic = new BattleLogic(user1, user2);
        var battleResult = battleLogic.StartBattle(user1, user2);

        Console.WriteLine("Winner: {0}, Loser: {1}", battleResult.Winner.Username, battleResult.Loser.Username);

    }
}