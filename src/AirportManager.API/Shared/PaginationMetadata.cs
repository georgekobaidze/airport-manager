using Newtonsoft.Json;

namespace AirportManager.API.Shared;

public class PaginationMetadata
{
    [JsonProperty("totalItems")]
    public int TotalItems { get; set; }

    [JsonProperty("totalPages")]
    public int TotalPages { get; set; }

    [JsonProperty("pageSize")]
    public int PageSize { get; set; }

    [JsonProperty("currentPage")]
    public int CurrentPage { get; set; }

    [JsonProperty("hasPrevious")]
    public bool HasPrevious { get; set; }

    [JsonProperty("hasNext")]
    public bool HasNext { get; set; }

    public PaginationMetadata(int totalItems, int pageSize, int currentPage)
    {
        TotalItems = totalItems;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize);
        CurrentPage = currentPage > TotalPages ? TotalPages : currentPage;
        HasPrevious = currentPage > 1;
        HasNext = currentPage < TotalPages;
    }
}