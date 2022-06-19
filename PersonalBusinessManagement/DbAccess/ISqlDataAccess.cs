namespace PersonalBusinessManagement.DbAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T>(string sqlQuery);
    Task SaveData(string sqlQuery);
}