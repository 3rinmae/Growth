
namespace Growth.Services;

public class SprintsService
{
  private readonly SprintsRepository _repository;

  public SprintsService(SprintsRepository repository)
  {
    _repository = repository;
  }

  internal Sprint CreateSprint(Sprint sprintData)
  {
    Sprint sprint = _repository.CreateSprint(sprintData);
    return sprint;
  }
}