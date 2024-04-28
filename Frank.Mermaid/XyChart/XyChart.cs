using CodegenCS;

namespace Frank.Mermaid;

/// <summary>
/// Represents an XY chart.
/// </summary>
/// <remarks>Beta</remarks>
public class XyChart(string title) : IMermaidable
{
    public string Title { get; } = title;
    public Axis XAxis { get; private set; }
    public Axis YAxis { get; private set; }
    public List<Series> Series { get; } = new();

    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();
    
    public void AddSeries(Series series) => Series.Add(series);

    public void AddSeries(IEnumerable<Series> series) => Series.AddRange(series);
    
    public void SetXAxis(Axis axis) => XAxis = axis;
    
    public void SetYAxis(Axis axis) => YAxis = axis;
    
    /// <inheritdoc />
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
        writer.Write("xyChart-beta");
        writer.IncreaseIndent();
        writer.Write("title \"{0}\"", Title);
        writer.WriteLine("x-axis {0} {1}", XAxis.ToMermaidSyntax());
        writer.WriteLine("y-axis {0}", YAxis.ToMermaidSyntax());
        foreach (var series in Series)
        {
            writer.WriteLine(series.ToMermaidSyntax());
        }
        
        writer.DecreaseIndent();
        
        return writer;
    }
}