using Xunit.Abstractions;

namespace Frank.Mermaid.Tests;

public class PieChartTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void Test1()
    {
        var chart = new PieChart("Chart 1");
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
        var chart = new PieChart("Chart 1", false);
        chart.AddValue("Slice 1", 10);
        chart.AddValue("Slice 2", 20);
        chart.AddValue("Slice 3", 30);
        
        var writer = chart.ToMermaidSyntax();
        var result = writer.ToString();
        
        outputHelper.WriteLine(result);
    }
    
    [Fact]
    public void Test3()
    {
        var mermaidPieChart = new PieChart("MyPieChart");
        mermaidPieChart.AddValue("A", 999);
        mermaidPieChart.AddValue("B", 666);
        mermaidPieChart.AddValue("C", 420);
        mermaidPieChart.AddValue("D", 69);
        
        outputHelper.WriteLine(mermaidPieChart.ToMermaidSyntax().ToString());
    }
}