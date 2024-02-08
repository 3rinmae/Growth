namespace Growth.Services;

public class ProjectsService
{
  private readonly ProjectsRepository _repository;

  public ProjectsService(ProjectsRepository repository)
  {
    _repository = repository;
  }
}