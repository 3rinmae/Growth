


namespace Growth.Services;

public class ProjectsService
{
  private readonly ProjectsRepository _repository;

  public ProjectsService(ProjectsRepository repository)
  {
    _repository = repository;
  }

  internal Project CreateProject(Project projectData)
  {
    Project project = _repository.CreateProject(projectData);
    return project;
  }

  internal string DestroyProject(int projectId, string userId)
  {
    Project project = GetProjectById(projectId, userId);
    if (project.CreatorId != userId)
    {
      throw new Exception("Thisis not your Project to delete");
    }
    _repository.DestroyProject(projectId);
    return $"{project.Name} has been deleted!";
  }

  internal List<Project> GetMyProjects(string userId)
  {
    List<Project> projects = _repository.GetMyProjects(userId);
    return projects;
  }

  internal Project GetProjectById(int projectId, string userId)
  {
    Project project = _repository.GetProjectById(projectId, userId);
    if (project == null)
    {
      throw new Exception($"Invalid Id: {projectId}");
    }
    return project;
  }
}