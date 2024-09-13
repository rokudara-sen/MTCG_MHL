namespace MTCG_MHL.Interface;

public interface IMonster
{
    public int MonsterHealth
    {
        get;
        set;
    }

    public int MonsterDamage
    {
        get;
        set;
    }
    
    public void ReceiveDamage(int damage);
}