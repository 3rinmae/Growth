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

}