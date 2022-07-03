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

    public async Task<IEnumerable<T>> LoadData<T, U>(string query, U parameters)
    {
                                //Or:    new SqliteConnection("Data Source= Data\\ToDo.DB.sqlite");
        using IDbConnection connection = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));

        return await connection.QueryAsync<T>(query, parameters);
    }

    public async Task SaveData<T>(string query, T parameters)
    {
        using IDbConnection connection = new SqliteConnection(_config.GetConnectionString("DefaultConnection"));

        await connection.ExecuteAsync(query, parameters);
    }

}
