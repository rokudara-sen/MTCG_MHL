namespace MTCG_MHL.Business.Logic.Pack;

public class RarityLogic
{
    public static int GetRandomRarity()
    {
        Random rnd = new Random();
        
        int[] rarityDistribution = {
            1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7,
            8, 8, 8, 9, 9, 9, 10, 10, 10, 15, 15, 20, 20, 25, 25, 30, 30, 
            35, 40, 45, 50
        };
        
        int randomIndex = rnd.Next(rarityDistribution.Length);
        return rarityDistribution[randomIndex];
    }
}