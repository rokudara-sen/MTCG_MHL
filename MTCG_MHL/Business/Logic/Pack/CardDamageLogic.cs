namespace MTCG_MHL.Business.Logic.Pack;

public class CardDamageLogic
{
    private readonly Random _rnd;

    public CardDamageLogic()
    {
        _rnd = new Random();
    }
    
    public int CalculateBaseDamage(int cardRarity)
    {
        return cardRarity switch
        {
            >= 45 => _rnd.Next(20, 25),
            >= 30 => _rnd.Next(15, 19),
            >= 20 => _rnd.Next(10, 14),
            >= 10 => _rnd.Next(5, 9),
            _ => _rnd.Next(1, 4),
        };
    }
}