using Microsoft.AspNetCore.Http;
using UMS.DataAccess.Common.Paginations;

namespace UMS.Service.Common.Paginations;

public class Pagination : IPagination
{
    public void Paginate(long itemsCount, PaginationParams @params)
    {
        PaginationData pagination = new PaginationData();
        pagination.CurrentPage = @params.PageNumber;
        pagination.TotalItems = (int)itemsCount;
        pagination.PageSize = @params.PageSize;

        pagination.TotalPages = (int)Math.Ceiling((double)itemsCount / @params.PageSize);
        pagination.HasPrevious = pagination.CurrentPage > 1;
        pagination.HasNext = pagination.CurrentPage < pagination.TotalPages;
    }
}
