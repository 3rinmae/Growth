

namespace Growth.Repositories;

public class ProjectsRepository
{
  private readonly IDbConnection _db;

  public ProjectsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Project CreateProject(Project projectData)
  {
    string sql = @"
      INSERT INTO
      projects(name, description, creatorId)
      VALUES(@Name, @Description, @CreatorId);

      SELECT
      pro.*,
      acc.*
      FROM projects pro
      JOIN accounts acc on acc.id = pro.creatorId
      WHERE pro.id = LAST_INSERT_ID();";
    Project project = _db.Query<Project, Account, Project>(sql, ProjectBuilder, projectData).FirstOrDefault();
    return project;
  }

  internal List<Project> GetMyProjects(string userId)
  {
    string sql = @"
      SELECT
      pro.*,
      acc.*
      FROM projects pro
      JOIN accounts acc on acc.id = pro.creatorId
      WHERE pro.creatorId = @userId;";
    List<Project> projects = _db.Query<Project, Account, Project>(sql, (projects, account) =>
    {
      projects.Creator = account;
      return projects;
    }, new { userId }).ToList();
    return projects;
  }

  private Project ProjectBuilder(Project project, Account account)
  {
    project.Creator = account;
    return project;
  }
}