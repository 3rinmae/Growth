namespace Growth.Repositories;

public class SprintsRepository
{
  private readonly IDbConnection _db;

  public SprintsRepository(IDbConnection db)
  {
    _db = db;
  }
}