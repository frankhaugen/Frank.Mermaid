﻿namespace Frank.Mermaid;

public class Timeline(string title) : IMermaidable
{
    private readonly List<Section> _sections = new();
    private readonly List<Event> _events = new();

    public void AddSection(Section section) => _sections.Add(section);
    public void AddSections(IEnumerable<Section> sections) => _sections.AddRange(sections);
    
    public void AddEvent(Event @event) => _events.Add(@event);
    public void AddEvents(IEnumerable<Event> events) => _events.AddRange(events);
    
    /// <inheritdoc />
    public Hash Id { get; } = Hash.NewHash();
    
    public IIndentedStringBuilder GetBuilder()
    {
        var writer = new IndentedStringBuilder();
        writer.WriteLine("timeline");
        writer.IncreaseIndent();
        writer.WriteLine("title {0}", title);

        if (_sections.Any())
        {
            foreach (var section in _sections)
            {
                writer.WriteLine(section.GetBuilder());
            }
            
            writer.DecreaseIndent();
        }
        else
        {
            foreach (var @event in _events)
            {
                writer.WriteLine(@event.GetBuilder());
            }
        }
        
        return writer;
    }
}