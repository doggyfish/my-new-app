public class Profile
{
    public List<Sale> Sales { get; set; }

    public double TotalPercentageRent { get; set; }

    public Profile()
    {
        Sales = new List<Sale>();
    }

    public double CalculateTotalPercentageRent()
    {
        return Sales.Sum(s => s.TierOne.TeirPercentageRent + s.TierTwo.TeirPercentageRent + s.TierThree.TeirPercentageRent);
    }
}