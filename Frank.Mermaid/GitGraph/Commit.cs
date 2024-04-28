using CodegenCS;

namespace Frank.Mermaid;

public class Commit : IMermaidable
{
    public Commit(string message, string branch, DateTime? dateTime = null)
    {
        Hash = new Hash(dateTime).ToString();
        Message = message;
        Branch = branch;
    }
    
    public string Hash { get; }
    public string Message { get; }
    public string Branch { get; }
    
    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();

    /// <inheritdoc />
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
        writer.Write("commit {0}", Hash);
        writer.IncreaseIndent();
        writer.WriteLine("message {0}", Message);
        writer.WriteLine("branch {0}", Branch);
        writer.DecreaseIndent();
        return writer;
    }
}