
using PersonalBusinessManagement.DbAccess;
using PersonalBusinessManagement.Models;

namespace PersonalBusinessManagement.Data.TodoData;

public class TodoData : ITodoData
{
    private readonly ISqlDataAccess _db;

    public TodoData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Todo>> GetAll() =>
        await _db.LoadData<Todo, dynamic>("SELECT * FROM Todo", new { });

    public async Task<Todo> GetById(int? id)
    {
#pragma warning disable CS8603
        var result =  await _db.LoadData<Todo, dynamic>($"SELECT * FROM Todo WHERE Id = @Id", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task InsertTodo(Todo todo)
    {
        await _db.SaveData($"INSERT INTO Todo (Name, Description, Priority) " +
                           $"VALUES(@Name, @Description, @Priority)", new 
                           {
                               todo.Name,
                               todo.Description,
                               todo.Priority
                           });
    }

    public async Task UpdateTodo(Todo todo)
    {
        string query = $"UPDATE Todo SET Name = @Name, Description = @Description, Priority = @Priority WHERE Id = @Id";

        await _db.SaveData(query, todo);
    }

    public async Task DeleteTodo(int? id) =>
        await _db.SaveData($"DELETE FROM Todo WHERE Id = @Id", new { Id = id });
}
