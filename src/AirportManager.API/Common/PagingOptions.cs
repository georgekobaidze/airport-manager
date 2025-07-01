namespace AirportManager.API.Common;

public class PagingOptions
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? OrderBy { get; set; }
    public bool Desc { get; set; } = false;
}