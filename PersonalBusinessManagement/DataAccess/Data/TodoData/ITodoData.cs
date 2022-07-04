using PersonalBusinessManagement.Models;

public interface ITodoData
{
    Task<IEnumerable<Todo>> GetAll();
    Task<Todo> GetById(int? id);
    Task InsertTodo(Todo todo);
    Task UpdateTodo(Todo todo);
    Task DeleteTodo(int? id);
}