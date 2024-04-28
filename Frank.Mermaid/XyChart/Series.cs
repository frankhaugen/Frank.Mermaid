using CodegenCS;

namespace Frank.Mermaid.XyChart;

public class Series : IMermaidable
{
    public string Name { get; }
    public List<Point> Points { get; }

    /// <inheritdoc />
    public Guid Id { get; }

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