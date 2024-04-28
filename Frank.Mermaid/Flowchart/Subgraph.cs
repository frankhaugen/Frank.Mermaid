using CodegenCS;

namespace Frank.Mermaid;
// Define the line styles using an enumeration

public class Subgraph(string label, Direction direction) : IMermaidable
{
    public void AddNode(Node node) => Nodes.Add(node);
    public void AddNodes(IEnumerable<Node> nodes) => Nodes.AddRange(nodes);

    public void AddLink(Link link) => Links.Add(link);
    public void AddLinks(IEnumerable<Link> links) => Links.AddRange(links);

    public void AddSubgraph(Subgraph subgraph) => _subgraphs.Add(subgraph);
    public void AddSubgraphs(IEnumerable<Subgraph> subgraphs) => _subgraphs.AddRange(subgraphs);

    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();
    
    public string Label { get; } = label;

    public Direction Direction { get; } = direction;

    public List<Node> Nodes { get; } = new();
    
    private List<Link> Links { get; } = new();
    
    
    
    private readonly List<Subgraph> _subgraphs = new();
    
    /// <inheritdoc />
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
        writer.WriteLine("subgraph {0}", Label);
        writer.IncreaseIndent();
        
        writer.WriteLine("direction {0}", Direction.ToMermaidSyntax());
        
        foreach (var node in Nodes)
        {
            writer.Write(node.ToMermaidSyntax());
        }

        foreach (var link in Links)
        {
            writer.Write(link.ToMermaidSyntax());
        }

        foreach (var subgraph in _subgraphs)
        {
            writer.Write(subgraph.ToMermaidSyntax());
        }
        

        writer.DecreaseIndent();
        writer.WriteLine("end");
        return writer;
    }
}