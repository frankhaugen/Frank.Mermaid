namespace Frank.Mermaid;

public class Axis(string xAxis, bool logarithmic = false) : IMermaidable
{
    public string Title { get; } = xAxis;

    public bool Logarithmic { get; } = logarithmic;

    /// <inheritdoc />
    public Hash Id { get; } = Hash.NewHash();

    /// <inheritdoc />
    public IIndentedStringBuilder GetBuilder()
    {
        var writer = new IndentedStringBuilder();
        writer.WriteLine("axis {0}", Title);
        writer.IncreaseIndent();
        writer.WriteLine("log {0}", Logarithmic.ToString().ToLower());
        writer.DecreaseIndent();
        return writer;
    }
}