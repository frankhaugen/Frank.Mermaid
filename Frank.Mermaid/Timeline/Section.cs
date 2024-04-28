namespace Frank.Mermaid;

public class Section(string title) : IMermaidable
{
    private readonly List<Event> _events = new();

    public void AddEvent(Event @event) => _events.Add(@event);
    
    public void AddEvents(IEnumerable<Event> events) => _events.AddRange(events);
    
    /// <inheritdoc />
    public Hash Id { get; } = Hash.NewHash();
    
    public IIndentedStringBuilder GetBuilder()
    {
        var writer = new IndentedStringBuilder();
        writer.WriteLine("section {0}", title);
        
        writer.IncreaseIndent();
        foreach (var @event in _events)
        {
            writer.WriteLine(@event.GetBuilder());
        }
        
        return writer;
    }
}