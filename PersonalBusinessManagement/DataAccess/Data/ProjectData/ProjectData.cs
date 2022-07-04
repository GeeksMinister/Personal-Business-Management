
using PersonalBusinessManagement.Models;


public class ProjectData : IProjectData
{
    private readonly ISqlDataAccess _db;

    public ProjectData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Project>> GetAll() =>
        await _db.LoadData<Project, dynamic>("SELECT * FROM Project", new { });

    public async Task<Project> GetById(int? id)
    {
#pragma warning disable CS8603
        var result =  await _db.LoadData<Project, dynamic>($"SELECT * FROM Project WHERE Id = @Id", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task InsertProject(Project project)
    {
        await _db.SaveData($"INSERT INTO Project (Name, Description, Delivered) " +
                           $"VALUES(@Name, @Description, @Delivered)", new 
                           {
                               project.Name,
                               project.Description,
                               project.Delivered
                           });
    }

    public async Task UpdateProject(Project project)
    {
        string query = $"UPDATE Project SET Name = @Name, Description = @Description, Delivered = @Delivered WHERE Id = @Id";
        await _db.SaveData(query, project);
    }

    public async Task DeleteProject(int? id) =>
        await _db.SaveData($"DELETE FROM Project WHERE Id = @Id", new { Id = id });

    public async Task<IEnumerable<Project>> SearchProject(string searchTerm)
    {
        var result = await _db.LoadData<Project, dynamic>("SELECT * FROM Project WHERE " +
            "Name LIKE '%' || @searchTerm || '%' OR Description LIKE '%' || @searchTerm || '%'"
            , new { searchTerm });
        return result;
    }
}
