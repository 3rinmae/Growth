using System.Runtime;

namespace Growth.Models;

public class Project : RepoItem<int>
{
  public string Name { get; set; }
  public string Description { get; set; }
  public string CreatorId { get; set; }
  public Account Creator { get; set; }
}