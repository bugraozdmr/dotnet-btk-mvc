namespace MVCWEB.Models;

// sadece bu klosor altında MVCWEB altında olduğu için buraya tanımlandı -- yoksa entity'de olurdu
public class Pagination
{
    public int TotalItems { get; set; }
    public int ItemsPerPage { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPage => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
}