using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.Data.Sqlite;

namespace PersonalBusinessManagement.DbAccess;
public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration confic)
    {
        _config = confic;
    }

    public async Task<IEnumerable<T>> LoadData<T>(string query)
    {
                                //Or:    new SqliteConnection("Data Source= Data\\ToDo.DB.sqlite");
        using IDbConnection connection = new SqliteConnection(_config.GetConnectionString("TodoDbConnection"));

        return await connection.QueryAsync<T>(query);
    }

    public async Task SaveData(string query)
    {
        using IDbConnection connection = new SqliteConnection(_config.GetConnectionString("TodoDbConnection"));

        await connection.ExecuteAsync(query);
    }

}
