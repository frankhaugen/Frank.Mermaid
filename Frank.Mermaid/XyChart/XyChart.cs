﻿namespace Frank.Mermaid;

/// <summary>
/// Represents an XY chart.
/// </summary>
/// <remarks>Beta</remarks>
public class XyChart(string? title) : IMermaidable
{
    public string? Title { get; } = title;
    public Axis XAxis { get; private set; }
    public Axis YAxis { get; private set; }
    public List<Series> Series { get; } = new();

    /// <inheritdoc />
    public Hash Id { get; } = Hash.NewHash();
    
    public void AddSeries(Series series) => Series.Add(series);

    public void AddSeries(IEnumerable<Series> series) => Series.AddRange(series);
    
    public void SetXAxis(Axis axis) => XAxis = axis;
    
    public void SetYAxis(Axis axis) => YAxis = axis;
    
    /// <inheritdoc />
    public IIndentedStringBuilder GetBuilder()
    {
        var writer = new IndentedStringBuilder();
        writer.Write("xyChart-beta");
        writer.IncreaseIndent();
        writer.Write("title \"{0}\"", Title);
        writer.WriteLine("x-axis {0} {1}", XAxis, "CCC");
        writer.WriteLine("y-axis {0}", YAxis);
        foreach (var series in Series)
        {
            writer.WriteLine(series.GetBuilder());
        }
        
        writer.DecreaseIndent();
        
        return writer;
    }
}