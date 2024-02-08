
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
}