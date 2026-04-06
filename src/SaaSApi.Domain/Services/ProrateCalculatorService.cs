using SaaSApi.Domain;

public class ProrateCalculatorService
{
    public decimal Calculate(Subscription oldSus, Plan newPlan, Plan oldPlan)
    {
        const int MONTH_DAYS = 30;

        var daysRemaining = (int)oldSus.EndDate.Date - DateTime.UtcNow.Date;
        var currentPrice = oldPlan.Price.Amount;
        var credit = (currentPrice / MONTH_DAYS) * daysRemaining;
        var newDailyPrice = newPlan.Price.Amount / MONTH_DAYS;
        var newCost = newDailyPrice * (DateTime.UtcNow.Day - MONTH_DAYS);
        var priceToPay = newCost - credit;

        return priceToPay;
    }
}