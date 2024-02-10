
namespace Growth.Repositories;

public class SprintsRepository
{
  private readonly IDbConnection _db;

  public SprintsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Sprint CreateSprint(Sprint sprintData)
  {
    string sql = @"
      
      INSERT INTO
      sprints(name, isOpen, projectId, creatorId)
      VALUES(@Name, @IsOpen, @ProjectId, @CreatorId);
      
      SELECT
      spr.*,
      acc.*
      FROM sprints spr
      JOIN accounts acc on acc.id = spr.creatorId
      WHERE spr.id = LAST_INSERT_ID();";
    Sprint sprint = _db.Query<Sprint, Account, Sprint>(sql, SprintBuilder, sprintData).FirstOrDefault();
    return sprint;
  }

  private Sprint SprintBuilder(Sprint sprint, Account account)
  {
    sprint.Creator = account;
    return sprint;
  }
}
