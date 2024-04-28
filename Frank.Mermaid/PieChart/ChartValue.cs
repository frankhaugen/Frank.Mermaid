namespace Frank.Mermaid.PieChart;

public class ChartValue(string name, double value)
{
    public string Name { get; } = name;
    public double Value { get; } = value;
}