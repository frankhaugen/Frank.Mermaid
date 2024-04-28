using CodegenCS;

namespace Frank.Mermaid.XyChart;

/// <summary>
/// Represents an XY chart.
/// </summary>
/// <remarks>Beta</remarks>
public class XyChart : IMermaidable
{
    public string Title { get; }
    public Axis XAxis { get; }
    public Axis YAxis { get; }
    public List<Series> Series { get; }

    /// <inheritdoc />
    public Guid Id { get; }

    /// <inheritdoc />
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
        writer.WriteLine("xyChart {0}", Title);
        writer.IncreaseIndent();
        writer.WriteLine("xAxis");
        writer.WriteLine(XAxis.ToMermaidSyntax());
        writer.WriteLine("yAxis");
        writer.WriteLine(YAxis.ToMermaidSyntax());
        foreach (var series in Series)
        {
            writer.WriteLine(series.ToMermaidSyntax());
        }
        
        writer.DecreaseIndent();
        
        return writer;
    }
}