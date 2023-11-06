namespace UMS.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly SqlConnection _connection;
    public BaseRepository()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new SqlConnection("Server = DESKTOP-K36HGB0; Database = UMSDB; Trusted_Connection=True;");
    }
}
