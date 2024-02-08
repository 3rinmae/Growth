namespace Growth.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProjectsController : ControllerBase
{
  private readonly Auth0Provider _auth0Provider;
  private readonly ProjectsService _projectsService;

  public ProjectsController(Auth0Provider auth0Provider, ProjectsService projectsService)
  {
    _auth0Provider = auth0Provider;
    _projectsService = projectsService;
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

}