namespace UMS.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly SqlConnection _connection;
    public BaseRepository()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new SqlConnection("Server = WIN-F7NIMF7A3VO;Database = UMS;Trusted_Connection = True;");
    }
}
