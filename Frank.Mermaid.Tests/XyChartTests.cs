namespace Frank.Mermaid.Tests;

public class XyChartTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void Test1()
    {
        var chart = new XyChart("Chart 1");
        var series1 = new Series("Series 1");
        series1.Points.Add(new Point(1, 2));
        series1.Points.Add(new Point(2, 3));
        chart.AddSeries(series1);
        
        var series2 = new Series("Series 2");
        series2.Points.Add(new Point(1, 3));
        series2.Points.Add(new Point(2, 4));
        chart.AddSeries(series2);
        
        var xAxis = new Axis("X Axis");
        var yAxis = new Axis("Y Axis");
        
        chart.SetXAxis(xAxis);
        chart.SetYAxis(yAxis);
        
        var writer = chart.ToMermaidSyntax();
        var result = writer.ToString();
        
        outputHelper.WriteLine(result);
    }
}