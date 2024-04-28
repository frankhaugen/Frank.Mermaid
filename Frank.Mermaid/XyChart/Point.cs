using CodegenCS;

namespace Frank.Mermaid.XyChart;

public class Point(int x, int y) : IMermaidable
{
    public double X { get; } = x;
    public double Y { get; } = y;

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