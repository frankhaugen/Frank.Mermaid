using CodegenCS;

namespace Frank.Mermaid;

public class Node(Guid id, string label, Shape shape) : IMermaidable
{
    public Node(string label) : this(Guid.NewGuid(), label, Shape.Rectangle)
    {
    }
    
    public Node(string label, Shape shape) : this(Guid.NewGuid(), label, shape)
    {
    }

    /// <inheritdoc />
    public Guid Id { get; } = id;

    public string Label { get; } = label;
    public Shape Shape { get; } = shape;

    /// <inheritdoc />
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var label = Shape switch
        {
            Shape.Circle => $"(({Label}))",
            Shape.Subroutine => $"[[{Label}]]",
            Shape.Rounded => $"({Label})",
            Shape.Hexagon => $"{{{{{Label}}}}}",
            Shape.Database => $"[({Label})]",
            Shape.Rectangle => $"[{Label}]", // Default case
            _ => $"[{Label}]" // Default case
        };
        
        var writer = new CodegenTextWriter();
        writer.WriteLine("{0}{1}", this.GetId(), label);
        return writer;
    }
    
}
