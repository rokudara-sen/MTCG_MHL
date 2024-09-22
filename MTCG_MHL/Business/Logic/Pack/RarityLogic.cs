namespace MTCG_MHL.Business.Logic.Pack;

public class RarityLogic
{
    public static int GetRandomRarity(int packageCost)
    {
        Random rnd = new Random();
        
        int[] rarityLevels = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20, 25, 30, 35, 40, 45, 50};
        
        int minCost = 10;
        int maxCost = 100;
        
        double minAlpha = 0.5;
        double maxAlpha = 2.0;
        
        packageCost = Math.Max(minCost, Math.Min(packageCost, maxCost));
        
        double alpha = maxAlpha - (packageCost - minCost) * (maxAlpha - minAlpha) / (maxCost - minCost);
        
        double totalWeight = 0;
        List<double> weights = new List<double>();
        foreach (int rarity in rarityLevels)
        {
            double weight = 1.0 / Math.Pow(rarity, alpha);
            weights.Add(weight);
            totalWeight += weight;
        }
        
        for (int i = 0; i < weights.Count; i++)
        {
            weights[i] /= totalWeight;
        }
        
        double rand = rnd.NextDouble();
        
        double cumulative = 0;
        for (int i = 0; i < rarityLevels.Length; i++)
        {
            cumulative += weights[i];
            if (rand <= cumulative)
            {
                return rarityLevels[i];
            }
        }
        
        return rarityLevels[rarityLevels.Length - 1];
    }
}