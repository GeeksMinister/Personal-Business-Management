using PersonalBusinessManagement.Models;

namespace PersonalBusinessManagement.Data.ProjectData;

public interface IProjectData
{
    Task<IEnumerable<Project>> GetAll();
    Task<Project> GetById(int? id);
    Task InsertProject(Project todo);
    Task UpdateProject(Project todo);
    Task DeleteProject(int? id);
}