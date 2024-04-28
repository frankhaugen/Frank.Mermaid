using CodegenCS;

namespace Frank.Mermaid.Flowchart;

public class Line : IMermaidable
{
    private readonly LineStyle _lineStyle;
    private readonly int _lineWidth;

    public Line(LineStyle lineStyle, int lineWidth = 1)
    {
        _lineStyle = lineStyle;
        _lineWidth = lineWidth;
    }

    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();
    
    /// <inheritdoc />
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();        
        var arrow = _lineStyle.ToString().Contains("Arrow") ? ">" : "";
        
        switch (_lineStyle)
        {
            case LineStyle.Normal:
            case LineStyle.NormalWithArrow:
                writer.Write(new string('-', _lineWidth));
                break;
            case LineStyle.Thick:
            case LineStyle.ThickWithArrow:
                writer.Write(new string('=', _lineWidth));
                break;
            case LineStyle.Dotted:
            case LineStyle.DottedWithArrow:
                for (var i = 0; i < _lineWidth; i++)
                {
                    writer.Write(i == _lineWidth - 1 ? "." : ".-");
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        writer.Write(arrow);
        
        return writer;
    }
}