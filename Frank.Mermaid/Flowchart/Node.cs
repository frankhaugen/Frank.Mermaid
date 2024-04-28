using CodegenCS;

namespace Frank.Mermaid.Flowchart;

public class Node : IMermaidable
{
    public Node(Guid id, string label, Shape shape)
    {
        Id = id;
        Label = label;
        Shape = shape;
    }
    
    public Node(string label) : this(Guid.NewGuid(), label, Shape.Rectangle)
    {
    }
    
    public Node(string label, Shape shape) : this(Guid.NewGuid(), label, shape)
    {
    }

    /// <inheritdoc />
    public Guid Id { get; }
    public string Label { get; }
    public Shape Shape { get; }

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
