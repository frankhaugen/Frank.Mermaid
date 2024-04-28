using CodegenCS;

namespace Frank.Mermaid.PieChart;

public class PieChart(string title, bool showData = true) : IMermaidable
{
    public bool ShowData { get; } = showData;

    public string Title { get; } = title;

    public List<ChartValue> Values { get; } = new();
    
    public void AddValue(string name, double value) => Values.Add(new ChartValue(name, value));

    /// <inheritdoc />
    public Guid Id { get; } = Guid.NewGuid();

    /// <inheritdoc />
    public ICodegenTextWriter ToMermaidSyntax()
    {
        var writer = new CodegenTextWriter();
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
