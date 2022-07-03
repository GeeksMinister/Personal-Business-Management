namespace PersonalBusinessManagement.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string sqlQuery, U parameters);
    Task SaveData<T>(string sqlQuery, T parameters);
}