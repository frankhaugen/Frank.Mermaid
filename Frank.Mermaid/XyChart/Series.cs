namespace Frank.Mermaid;

public class Series(string name) : IMermaidable
{
    public string Name { get; } = name;
    public List<Point> Points { get; } = new();

    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();

    /// <inheritdoc />
    public IIndentedStringBuilder GetBuilder()
    {
        var writer = new IndentedStringBuilder();
        writer.WriteLine("series {0}", Name);
        writer.IncreaseIndent();
        foreach (var point in Points)
        {
            writer.WriteLine(point.GetBuilder());
        }
        
        writer.DecreaseIndent();
        
        return writer;
    }
}