public class Sale 
{
    public int Id { get; set; }
     
    public int YearOfSale { get; set; }

    public double SaleForTheYear { get; set; }

    public Tier TierOne { get; set; }

    public Tier TierTwo { get; set; }

    public Tier TierThree { get; set; }

    public Sale()
    {
        TierOne = new Tier();
        TierTwo = new Tier();
        TierThree = new Tier();
    }

    public Tier CreateTier(TierLevels level, double baseAmt, double tierPentPercentage, double tierUpperLimit, double tierLowerLimit, double saleForTheYear)
    {
        var tier = new Tier();
        tier.TierLevel = level;
        tier.UpperLimit = Helper.GetTierUpperLimit(level, baseAmt);
        tier.LowerLimit = Helper.GetTierLowerLimit(level, baseAmt);
        tier.TeirRentPercentage = 5.0;
        tier.TeirPercentageRent = Helper.GetTierPercentageRent(saleForTheYear, tierUpperLimit, tierLowerLimit, tierPentPercentage);
        return tier;
    }
}