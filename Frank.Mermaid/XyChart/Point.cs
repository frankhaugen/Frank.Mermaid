namespace Frank.Mermaid;

public class Point(int x, int y) : IMermaidable
{
    public double X { get; } = x;
    public double Y { get; } = y;

    /// <inheritdoc />
    public Hash Id { get; } = Hash.NewHash();

    /// <inheritdoc />
    public IIndentedStringBuilder GetBuilder()
    {
        var writer = new IndentedStringBuilder();
        writer.WriteLine("{0} {1}", X, Y);
        return writer;
    }
}