using CodegenCS;

namespace Frank.Mermaid;

public class Section(string title) : IMermaidable
{
    private readonly List<Event> _events = new();

    public void AddEvent(Event @event) => _events.Add(@event);
    
    public void AddEvents(IEnumerable<Event> events) => _events.AddRange(events);
    
    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();
    
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
        writer.WriteLine("section {0}", title);
        
        writer.IncreaseIndent();
        foreach (var @event in _events)
        {
            writer.WriteLine(@event.ToMermaidSyntax());
        }
        
        return writer;
    }
}