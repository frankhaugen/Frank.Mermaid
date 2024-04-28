namespace Frank.Mermaid;

public class PieChart(string title, bool showData = true) : IMermaidable
{
    public bool ShowData { get; } = showData;

    public string Title { get; } = title;

    public List<ChartValue> Values { get; } = new();
    
    public void AddValue(string name, double value) => Values.Add(new ChartValue(name, value));
    
    public void AddValue(ChartValue value) => Values.Add(value);
    
    public void AddValues(IEnumerable<ChartValue> values) => Values.AddRange(values);
    
    public void AddValues(params KeyValuePair<string, double>[] values) => Values.AddRange(values.Select(pair => new ChartValue(pair.Key, pair.Value)));

    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();

    /// <inheritdoc />
    public IIndentedStringBuilder GetBuilder()
    {
        var writer = new IndentedStringBuilder();
        writer.Write("pie {0}", ShowData ? "showData\n" : string.Empty);
        writer.IncreaseIndent();
        writer.WriteLine("title {0}", Title);
        foreach (var value in Values)
        {
            writer.WriteLine("\"{0}\" : {1}", value.Name, value.Value);
        }
        writer.DecreaseIndent();
        return writer;
    }
    
    /*
    pie showData
    title Key elements in Product X
    "Calcium" : 42.96
    "Potassium" : 50.05
    "Magnesium" : 10.01
    "Iron" :  5
     */
}
