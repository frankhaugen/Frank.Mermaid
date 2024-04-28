using CodegenCS;

namespace Frank.Mermaid.Timeline;

public class Event(string title, DateTime date, TimePeriod timePeriod = TimePeriod.Day) : IMermaidable
{
    public readonly TimePeriod TimePeriod = timePeriod;

    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();
    
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
        writer.Write("{0} : {1}", GetPeriodString(date), title);
        return writer;
    }

    private string GetPeriodString(DateTime dateTime)
    {
        return TimePeriod switch
        {
            TimePeriod.Year => dateTime.ToString("yyyy"),
            TimePeriod.Month => dateTime.ToString("yyyy-MM"),
            TimePeriod.Day => dateTime.ToString("yyyy-MM-dd"),
            TimePeriod.Hour => dateTime.ToString("yyyy-MM-dd HH"),
            TimePeriod.Minute => dateTime.ToString("yyyy-MM-dd HH:mm"),
            TimePeriod.Second => dateTime.ToString("yyyy-MM-dd HH:mm:ss"),
            TimePeriod.Millisecond => dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff"),
            TimePeriod.Microsecond => dateTime.ToString("yyyy-MM-dd HH:mm:ss.ffffff"),
            TimePeriod.Nanosecond => dateTime.ToString("yyyy-MM-dd HH:mm:ss.fffffff"),
            TimePeriod.Tick => dateTime.ToString("yyyy-MM-dd HH:mm:ss.fffffffff"),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}