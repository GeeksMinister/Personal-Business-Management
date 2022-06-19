
using PersonalBusinessManagement.DbAccess;
using PersonalBusinessManagement.Models;

namespace PersonalBusinessManagement.Data.TodoData;

public class TodoData : ITodoData
{
#pragma warning disable CS8602
    private readonly ISqlDataAccess _db;

    public TodoData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Todo>> GetAll() =>
        await _db.LoadData<Todo>("SELECT * FROM Todo");

    public async Task<Todo> GetById(int? id)
    {
#pragma warning disable CS8603
        var result =  await _db.LoadData<Todo>($"SELECT * FROM Todo WHERE Id = {id}");
        return result.FirstOrDefault();
    }

    public async Task InsertTodo(Todo todo)
    {
        await _db.SaveData($"INSERT INTO Todo (Name, Description, Priority) " +
                           $"VALUES('{todo.Name}', '{todo.Description}', {todo.Priority})");
    }

    public async Task UpdateTodo(Todo todo)
    {
        string query = string.Empty; 
        if (todo.Priority is null)
        {
            query = $"UPDATE Todo SET Name = '{todo.Name}', Description = '{todo.Description}'" +
               $", Priority = NULL WHERE Id = {todo.Id}";
        }
        else
        {
            query = $"UPDATE Todo SET Name = '{todo.Name}', Description = '{todo.Description}'" +
                           $", Priority = {todo?.Priority} WHERE Id = {todo.Id}";
        }
        await _db.SaveData(query);
    }

    public async Task DeleteTodo(int? id) =>
        await _db.SaveData($"DELETE FROM Todo WHERE Id = {id}");
}
