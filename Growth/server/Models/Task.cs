namespace Growth.Models;

public class Task : RepoItem<int>
{
  public string Name { get; set; }
  public int Weight { get; set; }
  public bool? IsCompleted { get; set; }
  public string AssignedTo { get; set; }
  public int ProjectId { get; set; }
  public string CreatorId { get; set; }
  public int SprintId { get; set; }
  public Project Project { get; set; }
  public Account Creator { get; set; }
  public Sprint Sprint { get; set; }
}