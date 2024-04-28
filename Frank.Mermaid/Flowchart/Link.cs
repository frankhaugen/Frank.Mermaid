using CodegenCS;

namespace Frank.Mermaid.Flowchart;

public class Link : IMermaidable
{
    public Link(string source, string target, string? label = null)
    {
        Source = source;
        Target = target;
        Label = label;
    }

    public string? Label { get; }

    public string Target { get; }

    public string Source { get; }
    
    public Line Line { get; private set; } = new Line(LineStyle.Normal, 3);

    public Link(IMermaidable source, IMermaidable target, string? label = null)
    {
        Source = GetIdentifier(source);
        Target = GetIdentifier(target);
        Label = label;
    }

    private string? GetIdentifier(IMermaidable source)
    {
        if (source is Subgraph subgraph)
        {
            return subgraph.Label;
        }
        
        return source.Id.ToString("N");
    }

    public void SetLineStyle(Line line)
    {
        Line = line;
    }
    
    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();
    
    /// <inheritdoc />
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
        
        writer.Write("{0} {1}{2} {3}", Source, Line.ToMermaidSyntax(), GetLabel(), Target);
        
        writer.WriteLine();
        return writer;
    }

    private string GetLabel() => !string.IsNullOrWhiteSpace(Label) ? $"|{Label}|" : string.Empty;

    /*
    Length	            1	    2	    3
    Normal	            ---	    ----	-----
    Normal with arrow	-->	    --->	---->
    Thick	            ===	    ====	=====
    Thick with arrow	==>	    ===>	====>
    Dotted	            -.-	    -..-	-...-
    Dotted with arrow	-.->    -..->	-...->
     */
}