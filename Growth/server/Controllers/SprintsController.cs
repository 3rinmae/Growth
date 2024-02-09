namespace Growth.Controllers;

[ApiController]
[Route("api/[controller]")]

public class SprintsController : ControllerBase
{
  private readonly Auth0Provider _auth0Provider;
  private readonly SprintsService _sprintsService;

  public SprintsController(Auth0Provider auth0Provider, SprintsService sprintsService)
  {
    _auth0Provider = auth0Provider;
    _sprintsService = sprintsService;
  }
}