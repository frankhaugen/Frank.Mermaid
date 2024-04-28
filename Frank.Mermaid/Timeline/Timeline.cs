using CodegenCS;

namespace Frank.Mermaid.Timeline;

public class Timeline(string title) : IMermaidable
{
    private readonly List<Section> _sections = new();
    private readonly List<Event> _events = new();

    public void AddSection(Section section) => _sections.Add(section);
    public void AddSections(IEnumerable<Section> sections) => _sections.AddRange(sections);
    
    public void AddEvent(Event @event) => _events.Add(@event);
    public void AddEvents(IEnumerable<Event> events) => _events.AddRange(events);
    
    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();
    
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
        writer.WriteLine("timeline");
        writer.IncreaseIndent();
        writer.WriteLine("title {0}", title);

        if (_sections.Any())
        {
            foreach (var section in _sections)
            {
                writer.Write(section.ToMermaidSyntax());
            }
            
            writer.DecreaseIndent();
        }
        else
        {
            foreach (var @event in _events)
            {
                writer.Write(@event.ToMermaidSyntax());
            }
        }
        
        return writer;
    }
}