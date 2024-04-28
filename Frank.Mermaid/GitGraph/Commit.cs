namespace Frank.Mermaid;

public class Commit : IMermaidable
{
    public Commit(string message, string branch, DateTime? dateTime = null)
    {
        if (dateTime.HasValue)
        {
            Id = new Hash(dateTime.Value);
        }
        Message = message;
        Branch = branch;
    }
    
    public string Message { get; }
    public string Branch { get; }
    
    /// <inheritdoc />
    public Hash Id { get; } = Hash.NewHash();

    /// <inheritdoc />
    public IIndentedStringBuilder GetBuilder()
    {
        var writer = new IndentedStringBuilder();
        writer.Write("commit {0}", Id);
        writer.IncreaseIndent();
        writer.WriteLine("message {0}", Message);
        writer.WriteLine("branch {0}", Branch);
        writer.DecreaseIndent();
        return writer;
    }
}