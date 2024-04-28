using CodegenCS;

namespace Frank.Mermaid;

public class Axis(string xAxis, bool logarithmic = false) : IMermaidable
{
    public string Title { get; } = xAxis;

    public bool Logarithmic { get; } = logarithmic;

    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();

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