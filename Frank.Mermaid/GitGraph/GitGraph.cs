namespace Frank.Mermaid;

public class GitGraph : IMermaidable
{
    public List<Commit> Commits { get; } = new();
    
    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();
    
    public void AddCommit(Commit commit) => Commits.Add(commit);

    /// <inheritdoc />
    public IIndentedStringBuilder GetBuilder()
    {
        var writer = new IndentedStringBuilder();
        writer.WriteLine("gitGraph");
        writer.IncreaseIndent();
        foreach (var commit in Commits)
        {
            writer.WriteLine(commit.GetBuilder());
        }
        writer.DecreaseIndent();
        return writer;
    }
}