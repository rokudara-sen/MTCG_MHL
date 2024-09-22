using System.Data;
using MTCG_MHL.Business.Logic.Elo;
using MTCG_MHL.Business.Logic.Inventory;
using MTCG_MHL.Enums;
using MTCG_MHL.Models.Battle;
using MTCG_MHL.Models.Player;
using MTCG_MHL.Models.Cards;
using BattleResult = MTCG_MHL.Models.Battle.BattleResult;

namespace MTCG_MHL.Business.Logic.Battle;

public class BattleLogic
{
    private readonly InventoryLogic _inventoyLogicUser1;
    private readonly InventoryLogic _inventoyLogicUser2;

    private readonly EffectivenessLogic _effectivenessLogic;
    private readonly SpecialRulesLogic _specialRulesLogic;
    
    private readonly EloLogic _eloLogic;
    
    public BattleLogic(User user1, User user2)
    {
        _inventoyLogicUser1 = new InventoryLogic(user1);
        _inventoyLogicUser2 = new InventoryLogic(user2);
        
        _effectivenessLogic = new EffectivenessLogic();
        _specialRulesLogic = new SpecialRulesLogic();
        
        _eloLogic = new EloLogic();
    }

    public BattleResult StartBattle(User user1, User user2)
    {
        var roundNumber = 1;
        for(int i = 0; i < 100; i++)
        {
            Console.WriteLine($"Round #{roundNumber}");
            var cardUser1 = ChooseRandomCardFromDeck(user1);
            var cardUser2 = ChooseRandomCardFromDeck(user2);
            
            var result = ResolveRound(cardUser1, cardUser2);
            UpdatePlayerDecks(result, cardUser1, cardUser2);

            var winner = CheckForWinner(user1, user2);
            
            if (winner == user1)
            {
                _eloLogic.AdjustEloPointsAfterBattle(winner, user2);
                Console.WriteLine("{0}, you won. Congratulations", user1.Username);
                return new BattleResult(user1, user2);
            }

            if (winner == user2)
            {
                _eloLogic.AdjustEloPointsAfterBattle(winner, user1);
                Console.WriteLine("{0}, you won. Congratulations", user2.Username);
                return new BattleResult(user2, user1);
            }
            roundNumber++;
        }
        return new BattleResult(true);
    }
    
    private User CheckForWinner(User user1, User user2)
    {
        if (_inventoyLogicUser1.IsDeckEmpty())
            return user2;
        if (_inventoyLogicUser2.IsDeckEmpty())
            return user1;
        return null;
    }

    private void UpdatePlayerDecks(RoundResult result, Card cardUser1, Card cardUser2)
    {
        if (result.IsDraw)
            return;

        // Compare by card properties (like CardName) instead of reference equality
        if (result.Winner.CardName == cardUser1.CardName)
        {
            _inventoyLogicUser1.AddCardToDeck(cardUser1, true);
            _inventoyLogicUser2.RemoveCardFromDeck(cardUser2, true);
        }
        else if (result.Winner.CardName == cardUser2.CardName)
        {
            _inventoyLogicUser2.AddCardToDeck(cardUser2, true);
            _inventoyLogicUser1.RemoveCardFromDeck(cardUser1, true);
        }
        else
        {
            throw new Exception("Something went wrong with updating the Player Decks during battle.");
        }
    }

    private RoundResult ResolveRound(Card cardUser1, Card cardUser2)
    {
        int damageUser1 = CalculateDamage(cardUser1, cardUser2);
        int damageUser2 = CalculateDamage(cardUser2, cardUser1);

        if (damageUser1 > damageUser2)
        {
            return new RoundResult(cardUser1, cardUser2);
        }
        if (damageUser2 > damageUser1)
        {
            return new RoundResult(cardUser2, cardUser1);
        }
        return new RoundResult(true);
    }

    private int CalculateDamage(Card attacker, Card defender)
    {
        int baseDamage = attacker.BaseDamage;
        double effectivenessMultiplies = _effectivenessLogic.CalculateEffectiveness(attacker, defender);
        
        SpecialRuleOutcome outcome = _specialRulesLogic.CheckSpecialRules(attacker, defender);
        switch (outcome)
        {
            case SpecialRuleOutcome.NoDamage:
                return 0;
            case SpecialRuleOutcome.InstantDeath:
                return int.MaxValue;
            case SpecialRuleOutcome.Immunity:
                return 0;
            case SpecialRuleOutcome.DoubleDamage:
                baseDamage *= 2;
                break;
            case SpecialRuleOutcome.HalfDamage:
                baseDamage /= 2;
                break;
            case SpecialRuleOutcome.NoEffect:
                break;
            default:
                throw new ArgumentOutOfRangeException("Something went wrong with calculating damage for special rules.");
        }
        int finalDamage = (int)(baseDamage * effectivenessMultiplies);
        return finalDamage;
    }

    private Card ChooseRandomCardFromDeck(User user)
    {
        if (user.PlayerDeck.PlayerDeck.Count == 0)
        {
            throw new Exception("No player deck available");
        }
        Random rnd = new Random();
        int num = rnd.Next(0, user.PlayerDeck.PlayerDeck.Count);
        return user.PlayerDeck.PlayerDeck[num];
    }
}