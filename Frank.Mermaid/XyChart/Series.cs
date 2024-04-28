using CodegenCS;

namespace Frank.Mermaid;

public class Series(string name) : IMermaidable
{
    public string Name { get; } = name;
    public List<Point> Points { get; } = new();

    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();

    /// <inheritdoc />
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
        writer.WriteLine("series {0}", Name);
        writer.IncreaseIndent();
        foreach (var point in Points)
        {
            writer.WriteLine(point.ToMermaidSyntax());
        }
        
        writer.DecreaseIndent();
        
        return writer;
    }
}