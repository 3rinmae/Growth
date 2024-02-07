namespace Growth.Models;

public class Note : RepoItem<int>
{
  public string Body { get; set; }
  public int TaskId { get; set; }
  public int ProjectId { get; set; }
  public string CreatorId { get; set; }
  public Task Task { get; set; }
  public Project Project { get; set; }
  public Account Creator { get; set; }
}