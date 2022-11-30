using Microsoft.AspNetCore.Mvc;

namespace my_new_app.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfileController : ControllerBase
{
    private static readonly int[] YearsOfSale = new[]
    {
        1,2,3,4,5,6,7,8,9,10
    };

    private static readonly double YearOneSale = 50000000;

    private readonly ILogger<ProfileController> _logger;

    public ProfileController(ILogger<ProfileController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IResult> Get()
    {
       var profile = new Profile();

       foreach(var i in YearsOfSale)
       {
            var sale = RentCalculator.CalculateSale(YearOneSale, i);
            profile.Sales.Add(sale);
       }

       profile.TotalPercentageRent = profile.CalculateTotalPercentageRent();

       return Results.Ok(profile);
    }
}
