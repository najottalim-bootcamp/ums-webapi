namespace UMS.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly SqlConnection _connection;
    public BaseRepository()
    {
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new SqlConnection("Server = DESKTOP-02F3BCI; Database = UMS_DB; Trusted_Connection = True; TrustServerCertificate = True");
    }
}
