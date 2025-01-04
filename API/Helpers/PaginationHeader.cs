using System;

namespace API.Helpers;

public class PaginationHeader
(
    int currentPage,
    int itemPerPage,
    int TotalItem,
    int totalPgaes
)
{
    public int CurrentPage { get; set; } = currentPage;
    public int ItemsPerPage { get; set; } = itemPerPage;
    public int TotalItems { get; set; } = TotalItem;
    public int TotalPages { get; set; } = totalPgaes;
}
