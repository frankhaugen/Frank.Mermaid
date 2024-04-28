using CodegenCS;

namespace Frank.Mermaid.Timeline;

public class Section : IMermaidable
{
    private readonly string _title;
    private readonly List<Event> _events = new();
    
    public Section(string title)
    {
        _title = title;
    }
    
    public void AddEvent(Event @event) => _events.Add(@event);
    
    public void AddEvents(IEnumerable<Event> events) => _events.AddRange(events);
    
    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();
    
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
        writer.WriteLine("section {0}", _title);
        
        writer.IncreaseIndent();
        foreach (var @event in _events)
        {
            writer.WriteLine(@event.ToMermaidSyntax());
        }
        
        return writer;
    }
}