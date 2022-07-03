using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonalBusinessManagement.Data.ProjectData;
using PersonalBusinessManagement.Models;

namespace PersonalBusinessManagement.Controllers;
public class ProjectsController : Controller
{
    private readonly IProjectData _projectDb;

    public ProjectsController(IProjectData context)
    {
        _projectDb = context;
    }

    // GET: Projects
    public async Task<IActionResult> Index()
    {
        return _projectDb != null ?
                    View(await _projectDb.GetAll()) :
                    Problem("Entity set 'PersonalBusinessManagementContext.Project'  is null.");
    }

    // GET: Projects/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || _projectDb == null)
        {
            return NotFound();
        }

        var project = await _projectDb.GetById(id);
        if (project == null)
        {
            return NotFound();
        }

        return View(project);
    }

    // GET: Projects/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Projects/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name,Description,Delivered")] Project project)
    {
        if (ModelState.IsValid)
        {
            _projectDb.InsertProject(project);
            return RedirectToAction(nameof(Index));
        }
        return View(project);
    }

    // GET: Projects/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _projectDb == null)
        {
            return NotFound();
        }

        var project = await _projectDb.GetById(id);
        if (project == null)
        {
            return NotFound();
        }
        return View(project);
    }

    // POST: Projects/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Delivered")] Project project)
    {
        if (id != project.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _projectDb.UpdateProject(project);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(project.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(project);
    }

    // GET: Projects/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _projectDb == null)
        {
            return NotFound();
        }

        var project = await _projectDb
            .GetById(id);
        if (project == null)
        {
            return NotFound();
        }

        return View(project);
    }

    // POST: Projects/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_projectDb == null)
        {
            return Problem("Entity set 'PersonalBusinessManagementContext.Project'  is null.");
        }
        var project = await _projectDb.GetById(id);
        if (project != null)
        {
            _projectDb.DeleteProject(id);
        }

        return RedirectToAction(nameof(Index));
    }

    private bool ProjectExists(int id)
    {
        var result = _projectDb.GetById(id);
        return (result is null);

    }


    public IActionResult Search()
    {
        return View();
    }

    public async Task<IActionResult> ShowSearchResults(string searchPhrase)
    {
        searchPhrase = searchPhrase.ToUpper();
        var collection = await _projectDb.GetAll();
        var result = collection.ToList().Where(
           proj => proj.Name.ToUpper().Contains(searchPhrase) || proj.Description.ToUpper().Contains(searchPhrase));
        return View(result);
    }


}

