using Xunit.Abstractions;

namespace Frank.Mermaid.Tests;

public class PieChartTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void Test1()
    {
        var chart = new PieChart.PieChart("Chart 1");
        chart.AddValue("Slice 1", 10);
        chart.AddValue("Slice 2", 20);
        chart.AddValue("Slice 3", 30);
        
        var writer = chart.ToMermaidSyntax();
        var result = writer.ToString();
        
        outputHelper.WriteLine(result);
    }
    
    [Fact]
    public void Test2()
    {
        var chart = new PieChart.PieChart("Chart 1", false);
        chart.AddValue("Slice 1", 10);
        chart.AddValue("Slice 2", 20);
        chart.AddValue("Slice 3", 30);
        
        var writer = chart.ToMermaidSyntax();
        var result = writer.ToString();
        
        outputHelper.WriteLine(result);
    }
}