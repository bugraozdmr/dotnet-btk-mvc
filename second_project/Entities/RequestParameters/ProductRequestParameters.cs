namespace Entities.RequestParameters;

public class ProductRequestParameters : RequestParameters
{
    public int? CategoryId { get; set; }
    public int? MinPrice { get; set; } = 0;
    public int? MaxPrice { get; set; } = int.MaxValue;

    // true ya da false döner
    public bool IsValidPrice => MaxPrice > MinPrice;

    public int PageNumber { get; set; }
    public int Pagesize { get; set; }

    public ProductRequestParameters() : this(1,5)
    {
        
    }
    
    // eğer boş constructor gelirsede alttaki const çalışsın
    public ProductRequestParameters(int pageNumber=1,int pagesize=5)
    {
        PageNumber = pageNumber;
        Pagesize = pagesize;
    }
}