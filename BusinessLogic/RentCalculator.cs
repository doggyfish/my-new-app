public enum TierLevels {
        TierOne = 1,
        TierTwo = 2,
        TierThree = 3
    }
public static class RentCalculator
{
    const double compondingRate = 2.5; 
    public static Sale CalculateSale(double yearOneSale, int yearOfSale)
    {
        var sale = new Sale();
        sale.YearOfSale = yearOfSale;
        sale.SaleForTheYear = Helper.GetSaleForTheYear(yearOneSale, yearOfSale, compondingRate);
        sale.Id = yearOfSale;
        
        var baseAmt = Helper.GetBaseRent(sale.YearOfSale);
        sale.TierOne = sale.CreateTier(TierLevels.TierOne, baseAmt, 5.0, 
                                Helper.GetTierUpperLimit(TierLevels.TierOne, baseAmt), 
                                Helper.GetTierLowerLimit(TierLevels.TierOne, baseAmt), 
                                sale.SaleForTheYear);
        sale.TierOne.TeirPercentageRent = Helper.GetTierPercentageRent(sale.SaleForTheYear, sale.TierOne.UpperLimit, sale.TierOne.LowerLimit, sale.TierOne.TeirRentPercentage);
        
        sale.TierTwo = sale.CreateTier(TierLevels.TierTwo, baseAmt, 3.0, 
                                Helper.GetTierUpperLimit(TierLevels.TierTwo, baseAmt), 
                                Helper.GetTierLowerLimit(TierLevels.TierTwo, baseAmt), 
                                sale.SaleForTheYear);
        sale.TierTwo.TeirPercentageRent = Helper.GetTierPercentageRent(sale.SaleForTheYear, sale.TierTwo.UpperLimit, sale.TierTwo.LowerLimit, sale.TierTwo.TeirRentPercentage);

        sale.TierThree = sale.CreateTier(TierLevels.TierThree, baseAmt, 1.0, 
                                Helper.GetTierUpperLimit(TierLevels.TierThree, baseAmt), 
                                Helper.GetTierLowerLimit(TierLevels.TierThree, baseAmt), 
                                sale.SaleForTheYear);
        sale.TierThree.TeirPercentageRent = Helper.GetTierPercentageRent(sale.SaleForTheYear, sale.TierThree.UpperLimit, sale.TierThree.LowerLimit, sale.TierThree.TeirRentPercentage);

        return sale;
    }


}

public static class Helper
{
    const double baseUpperBasePencentage = 8.0/100.0; 

    public static double GetSaleForTheYear(double baseAmt, int yearOfSale, double compondingRate)
    {
        double saleAmtforTheYear = 0.0;
        saleAmtforTheYear = baseAmt *  Math.Pow(1 + compondingRate / 100.0, yearOfSale);

        return saleAmtforTheYear;
    }

    public static double GetBaseRent(int yearOfSale)
    {
        if(yearOfSale>=1 && yearOfSale<=5)
            return 750000;
        return 850000;
    }

    public static double GetTierLowerLimit(TierLevels tierLevel, double baseAmt)
    {
       switch(tierLevel)
       {
        case TierLevels.TierOne:
            return baseAmt/baseUpperBasePencentage;
        case TierLevels.TierTwo:
            return baseAmt/(baseUpperBasePencentage/2.0);
        default:
            return baseAmt/(baseUpperBasePencentage/2.0/2.0);
       } 
    }
    public static double GetTierUpperLimit(TierLevels tierLevel, double baseAmt)
    {
       switch(tierLevel)
       {
        case TierLevels.TierOne:
            return baseAmt/(baseUpperBasePencentage/2.0);
        case TierLevels.TierTwo:
            return baseAmt/(baseUpperBasePencentage/2.0/2.0);
        default:
            return double.MaxValue;
       } 
    }

    public static double GetTierPercentageRent(double saleForTheYear, double upperLimit, double lowerLimit, double teirRentPercentage)
    {
        if(saleForTheYear <= lowerLimit)
            return 0.0;
        if(saleForTheYear < upperLimit)
            upperLimit = saleForTheYear;

        double tierPercentageRent = (upperLimit - lowerLimit) * teirRentPercentage / 100.0;
        return tierPercentageRent;
    }
}