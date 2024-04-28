using CodegenCS;

namespace Frank.Mermaid.Flowchart;

public class Flowchart(Direction direction = Direction.TopToBottom) : IMermaidable
{
    private readonly List<Node> _nodes = new();
    private readonly List<Link> _links = new();
    private readonly List<Subgraph> _subgraphs = new();

    public void AddSubgraph(Subgraph subgraph) => _subgraphs.Add(subgraph);
    public void AddSubgraphs(IEnumerable<Subgraph> subgraphs) => _subgraphs.AddRange(subgraphs);
    
    public void AddNode(Node node) => _nodes.Add(node);
    public void AddNodes(IEnumerable<Node> nodes) => _nodes.AddRange(nodes);
    
    public void AddLink(Link link) => _links.Add(link);
    public void AddLinks(IEnumerable<Link> links) => _links.AddRange(links);

    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();

    /// <inheritdoc />
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
        writer.WriteLine("flowchart {0}", direction.ToMermaidSyntax());
        writer.IncreaseIndent();
        
        foreach (var node in _nodes)
        {
            writer.Write(node.ToMermaidSyntax());
        }
        
        foreach (var link in _links)
        {
            writer.Write(link.ToMermaidSyntax());
        }
        
        foreach (var subgraph in _subgraphs)
        {
            writer.Write(subgraph.ToMermaidSyntax());
        }
        
        writer.DecreaseIndent();
        
        return writer;
    }
}