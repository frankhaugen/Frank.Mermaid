using CodegenCS;

namespace Frank.Mermaid.XyChart;

public class Point : IMermaidable
{
    public double X { get; }
    public double Y { get; }

    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();

    /// <inheritdoc />
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
        writer.WriteLine("{0} {1}", X, Y);
        return writer;
    }
}