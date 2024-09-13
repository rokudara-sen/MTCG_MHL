namespace MTCG_MHL.Game;

public abstract class Card
{
    public string ElementType
    {
        get;
        set;
    }

    public string CardName
    {
        get;
        set;
    }

    public abstract void AttackTarget(Card card);
    
    protected abstract int CardSpecialEffect(Card card, int damage);
}