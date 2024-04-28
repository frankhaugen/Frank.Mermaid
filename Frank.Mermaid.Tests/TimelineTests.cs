namespace Frank.Mermaid.Tests;

public class TimelineTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void Test1()
    {
        var timeline = new Timeline("My Timeline");
        var section1 = new Section("Section 1");
        section1.AddEvent(new Event("Event 1", new DateTime(2022, 1, 1)));
        section1.AddEvent(new Event("Event 2", new DateTime(2022, 1, 2)));
        timeline.AddSection(section1);
        
        var section2 = new Section("Section 2");
        section2.AddEvent(new Event("Event 3", new DateTime(2022, 1, 3)));
        section2.AddEvent(new Event("Event 4", new DateTime(2022, 1, 4)));
        timeline.AddSection(section2);
        
        var section3 = new Section("Section 3");
        section3.AddEvent(new Event("Event 5", new DateTime(2022, 1, 5)));
        section3.AddEvent(new Event("Event 6", new DateTime(2022, 1, 6)));
        timeline.AddSection(section3);
        
        var writer = timeline.GetBuilder();
        var result = writer.ToString();

        outputHelper.WriteLine(result);
    }
}