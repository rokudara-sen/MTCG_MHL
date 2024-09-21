using MTCG_MHL.Models.Cards;
using MTCG_MHL.Models.Player;
using MTCG_MHL.Models.Trade;

namespace MTCG_MHL.Business.Logic.Inventory;

public class InventoryLogic
{
    private readonly User _user;

    public InventoryLogic(User user)
    {
        _user = user;
        TotalWins = 0;
    }
    
    public int TotalWins { get; set; }

    public void AddCardToStash(Card card)
    {
        _user.PlayerStash.PlayerStash.Add(card);
        Console.WriteLine("{0}, {1}: {2} has been added to your stash.\n", _user.Username, card.CardName, card.VisibleName);
    }

    public void RemoveCardFromStash(Card card)
    {
        if (_user.PlayerStash.PlayerStash.Contains(card) == false)
        {
            throw new Exception("You cannot remove a card from your stash that doesn't exist.");
        }
        _user.PlayerStash.PlayerStash.Remove(card);
    }

    public void AddCardToDeck(Card card, bool exception = false)
    {
        if (exception)
        {
            _user.PlayerDeck.PlayerDeck.Add(card);
            return;
        }
            
        if (_user.PlayerDeck.PlayerDeck.Count > 4)
        {
            throw new Exception("You cannot have more than 4 cards in your deck.\n");
        }

        if (_user.PlayerStash.PlayerStash.Contains(card) == false)
        {
            throw new Exception("You cannot add a card to your deck that is not stashed.\n");
        }

        if (IsStashEmpty())
        {
            throw new Exception("You cannot add a card to your deck if your stash is empty.\n");
        }

        RemoveCardFromStash(card);
        _user.PlayerDeck.PlayerDeck.Add(card);
        Console.WriteLine("{0}, {1}: {2} has been added to your deck.\n", _user.Username, card.CardName, card.VisibleName);
    }

    public void RemoveCardFromDeck(Card card, bool exception = false)
    {
        if (exception)
        {
            _user.PlayerDeck.PlayerDeck.Remove(card);
            return;
        }

        if (_user.PlayerDeck.PlayerDeck.Count < 0)
        {
            throw new Exception("You Deck cannot have less than 0 cards.\n");
        }

        if (_user.PlayerDeck.PlayerDeck.Contains(card) == false)
        {
            throw new Exception("You cannot remove a card that doesn't exist in your deck.\n");
        }
        _user.PlayerDeck.PlayerDeck.Remove(card);
        AddCardToStash(card);
        Console.WriteLine("{0}, {1}: {2} has been removed from your deck.\n", _user.Username, card.CardName, card.VisibleName);
    }

    public bool IsDeckEmpty()
    {
        if (_user.PlayerDeck.PlayerDeck.Count == 0)
            return true;
        return false;
    }
    
    public bool IsStashEmpty()
    {
        if (_user.PlayerStash.PlayerStash.Count == 0)
            return true;
        return false;
    }
}