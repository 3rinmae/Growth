namespace Growth.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProjectsController : ControllerBase
{
  private readonly Auth0Provider _auth0Provider;
  private readonly ProjectsService _projectsService;
  private readonly SprintsService _sprintsService;

  public ProjectsController(Auth0Provider auth0Provider, ProjectsService projectsService, SprintsService sprintsService)
  {
    _auth0Provider = auth0Provider;
    _projectsService = projectsService;
    _sprintsService = sprintsService;
  }

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Project>> CreateProject([FromBody] Project projectData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      projectData.CreatorId = userInfo.Id;
      Project project = _projectsService.CreateProject(projectData);
      return Ok(project);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpGet]
  public async Task<ActionResult<List<Project>>> GetMyProjects()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<Project> projects = _projectsService.GetMyProjects(userInfo?.Id);
      return Ok(projects);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpGet("{projectId}")]
  public async Task<ActionResult<Project>> GetProjectById(int projectId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      Project project = _projectsService.GetProjectById(projectId, userInfo?.Id);
      return Ok(project);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpDelete("{projectId}")]
  public async Task<ActionResult<string>> DestroyProject(int projectId)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      string message = _projectsService.DestroyProject(projectId, userInfo.Id);
      return Ok(message);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [Authorize]
  [HttpPost("{projectId}/sprints")]
  public async Task<ActionResult<Sprint>> CreateSprint([FromBody] Sprint sprintData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      sprintData.CreatorId = userInfo.Id;
      Sprint sprint = _sprintsService.CreateSprint(sprintData);
      return Ok(sprint);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}