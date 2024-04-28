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
    
    [Fact]
    public void Test2_NorwaysHistorySinceTheVikingAge()
    {
        var timeline = new Timeline("Norway's Historical Timeline");

        // Viking Age
        var vikingAge = new Section("Viking Age");
        vikingAge.AddEvent(new Event("Beginning of Viking Age", new DateTime(793, 1, 1)));
        vikingAge.AddEvent(new Event("Battle of Hafrsfjord", new DateTime(872, 1, 1)));
        timeline.AddSection(vikingAge);

        // Middle Ages
        var middleAges = new Section("Middle Ages");
        middleAges.AddEvent(new Event("Christianization of Norway", new DateTime(1000, 1, 1)));
        middleAges.AddEvent(new Event("Black Death", new DateTime(1349, 1, 1)));
        timeline.AddSection(middleAges);

        // Union Periods
        var unionPeriods = new Section("Union Periods");
        unionPeriods.AddEvent(new Event("Kalmar Union", new DateTime(1397, 1, 1)));
        unionPeriods.AddEvent(new Event("Denmark-Norway Union", new DateTime(1536, 1, 1)));
        unionPeriods.AddEvent(new Event("Sweden-Norway Union", new DateTime(1814, 1, 1)));
        timeline.AddSection(unionPeriods);

        // Modern History
        var modernHistory = new Section("Modern History");
        modernHistory.AddEvent(new Event("Dissolution of Sweden-Norway Union", new DateTime(1905, 1, 1)));
        modernHistory.AddEvent(new Event("WWII - German Occupation", new DateTime(1940, 4, 9)));
        modernHistory.AddEvent(new Event("Discovery of Oil", new DateTime(1969, 1, 1)));
        modernHistory.AddEvent(new Event("Current Era", DateTime.Now));
        timeline.AddSection(modernHistory);

        // Building and outputting the timeline
        var writer = timeline.GetBuilder();
        var result = writer.ToString();

        outputHelper.WriteLine(result);
    }

}