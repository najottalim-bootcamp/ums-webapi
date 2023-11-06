using UMS.DataAccess.Common.Paginations;

namespace UMS.Service.Common.Paginations;

public interface IPagination
{
    public void Paginate(long itemsCount, PaginationParams @params);
}
