using CodegenCS;

namespace Frank.Mermaid.XyChart;

public class Axis : IMermaidable
{
    public string Title { get; }
    public bool Logarithmic { get; }

    /// <inheritdoc />
    public Guid Id { get; }

    /// <inheritdoc />
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
        writer.WriteLine("axis {0}", Title);
        writer.IncreaseIndent();
        writer.WriteLine("log {0}", Logarithmic.ToString().ToLower());
        writer.DecreaseIndent();
        return writer;
    }
}