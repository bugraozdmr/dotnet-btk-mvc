namespace Entities.RequestParameters;

public class ProductRequestParameters : RequestParameters
{
    public int? CategoryId { get; set; }
    public int? MinPrice { get; set; } = 0;
    public int? MaxPrice { get; set; } = int.MaxValue;

    // true ya da false döner
    public bool IsValidPrice => MaxPrice > MinPrice;
}