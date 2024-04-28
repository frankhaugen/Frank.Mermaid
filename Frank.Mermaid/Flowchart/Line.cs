namespace Frank.Mermaid;

public class Line(LineStyle lineStyle, int lineWidth = 1) : IMermaidable
{
    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();
    
    /// <inheritdoc />
    public IIndentedStringBuilder GetBuilder()
    {
        var writer = new IndentedStringBuilder();        
        var arrow = lineStyle.ToString().Contains("Arrow") ? ">" : "";
        
        switch (lineStyle)
        {
            case LineStyle.Normal:
            case LineStyle.NormalWithArrow:
                writer.Write(new string('-', lineWidth));
                break;
            case LineStyle.Thick:
            case LineStyle.ThickWithArrow:
                writer.Write(new string('=', lineWidth));
                break;
            case LineStyle.Dotted:
            case LineStyle.DottedWithArrow:
                for (var i = 0; i < lineWidth; i++)
                {
                    writer.Write(i == lineWidth - 1 ? "." : ".-");
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        writer.Write(arrow);
        
        return writer;
    }
}