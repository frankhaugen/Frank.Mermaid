namespace Frank.Mermaid;

public class Link : IMermaidable, IComparable<Link>, IEquatable<Link>
{
    public string? Label { get; }

    public string Target { get; }

    public string Source { get; }
    
    public Line Line { get; private set; } = new Line(LineStyle.NormalWithArrow, 3);

    public Link(IMermaidable source, IMermaidable target, string? label = null)
    {
        Source = source switch
        {
            Node sourceNode => sourceNode.Id.ToString(),
            Subgraph sourceSubgraph => sourceSubgraph.Label,
            _ => throw new ArgumentException("Source must be a Node or Subgraph", nameof(source))
        };

        Target = target switch
        {
            Node targetNode => targetNode.Id.ToString(),
            Subgraph targetSubgraph => targetSubgraph.Label,
            _ => throw new ArgumentException("Target must be a Node or Subgraph", nameof(target))
        };

        Label = label;
    }

    public void SetLineStyle(Line line)
    {
        Line = line;
    }
    
    /// <inheritdoc />
    public Hash Id { get; } = Hash.NewHash();
    
    /// <inheritdoc />
    public IIndentedStringBuilder GetBuilder()
    {
        var writer = new IndentedStringBuilder();
        
        writer.Write("{0} {1}{2} {3}", Source, Line.GetBuilder(), GetLabel(), Target);
        
        writer.WriteLine();
        return writer;
    }

    private string GetLabel() => !string.IsNullOrWhiteSpace(Label) ? $"|{Label}|" : string.Empty;

    /// <inheritdoc />
    public int CompareTo(Link? other)
    {
        if (other == null) return 1;
        if (ReferenceEquals(this, other)) return 0;
        if (Id == other.Id) return 0;
        if (Source == other.Source && Target == other.Target) return 0;
        return string.CompareOrdinal(Id.ToString(), other.Id.ToString());
    }

    /// <inheritdoc />
    public bool Equals(Link? other)
    {
        if (other == null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Id == other.Id && Source == other.Source && Target == other.Target;
    }
}