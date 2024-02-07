namespace Growth.Models;

public class Sprint : RepoItem<int>
{
  public string Name { get; set; }
  public bool? IsOpen { get; set; }
  public int ProjectId { get; set; }
  public string CreatorId { get; set; }
  public Project Project { get; set; }
  public Account Creator { get; set; }
}