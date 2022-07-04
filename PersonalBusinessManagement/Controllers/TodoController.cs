using Microsoft.AspNetCore.Mvc;
using PersonalBusinessManagement.Models;

public class TodoController : Controller
{
    private readonly ITodoData _todoDb;

    public TodoController(ITodoData todoData)
    {
        _todoDb = todoData;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _todoDb.GetAll());
    }

    public IActionResult Create()
    {
        return View();
    }

    // Post Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Todo todo)
    {
        if (ModelState.IsValid)
        {
            _todoDb.InsertTodo(todo);
            return RedirectToAction("Index");
        }
        return View(todo);
    }

    // Get Update
    public async Task<IActionResult> Update(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Todo todo = await _todoDb.GetById(id);
        if (todo == null)
        {
            return NotFound();
        }
        return View(todo);
    }

    // Post Update
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(Todo todo)
    {
        if (ModelState.IsValid)
        {
            await _todoDb.UpdateTodo(todo);
            return RedirectToAction("Index");
        }
        return View(todo);
    }

    // Get Delete
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Todo todo = await _todoDb.GetById(id);
        if (todo == null)
        {
            return NotFound();
        }
        return View(todo);

    }

    // Post Delete
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletePost(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Todo todo = await _todoDb.GetById(id);
        if (todo == null)
        {
            return NotFound();
        }
        await _todoDb.DeleteTodo(id);
        return RedirectToAction("Index");
    }

}


// Delete
//await _todoData.DeleteTodo(13);
//DBCC CHECKIDENT('Todo', RESEED, 13)


// Insert
//await _todoData.InsertTodo(new Todo { Name = "testOne", Description = "testOne", Priority = 1 });


// Update
//await _todoData.UpdateTodo(new Todo 
//{Id = 14, Name = "testTwo", Description = "testTwo" , Priority = 2});