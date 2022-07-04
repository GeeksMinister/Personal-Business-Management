using PersonalBusinessManagement.Models;

public interface IProjectData
{
    Task<IEnumerable<Project>> GetAll();
    Task<Project> GetById(int? id);
    Task<IEnumerable<Project>> SearchProject(string searchTerm);
    Task InsertProject(Project todo);
    Task UpdateProject(Project todo);
    Task DeleteProject(int? id);
}