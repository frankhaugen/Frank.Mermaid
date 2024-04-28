namespace Frank.Mermaid.Tests;

public class FlowchartTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void Test1()
    {
        var flowchart = new Flowchart(Direction.LeftToRight);
        var node1 = new Node("Node 1");
        var node2 = new Node("Node 2");
        flowchart.AddNode(node1);
        flowchart.AddNode(node2);
        
        var link = new Link(node1, node2, "Node 1 Link to Node 2");
        flowchart.AddLink(link);
        
        var subgraph = new Subgraph("Subgraph1", Direction.TopToBottom);
        var subgraphNode1 = new Node("Subgraph Node 1", Shape.Hexagon);
        var subgraphNode2 = new Node("Subgraph Node 2");
        subgraph.AddNode(subgraphNode1);
        subgraph.AddNode(subgraphNode2);
        
        var subgraphLink = new Link(subgraphNode1, subgraphNode2, "Subgraph Link 1");
        subgraph.AddLink(subgraphLink);
        
        var link2 = new Link(node2, subgraph, "Node 2 Link to Subgraph");
        flowchart.AddLink(link2);
        
        flowchart.AddSubgraph(subgraph);
        
        var writer = flowchart.GetBuilder();
        var result = writer.ToString();
        
        outputHelper.WriteLine(result);
    }
    
    [Fact]
    public void Test2()
    {
        var flowchart = new Flowchart();
        
        var subgraph1 = new Subgraph("subgraph1", Direction.TopToBottom);
        var top1 = new Node("top 1");
        var bottom1 = new Node("bottom 1");
        subgraph1.AddNode(top1);
        subgraph1.AddNode(bottom1);
        var link1 = new Link(top1, bottom1, "Link 1");
        subgraph1.AddLink(link1);
        flowchart.AddSubgraph(subgraph1);
        
        var subgraph2 = new Subgraph("subgraph2", Direction.LeftToRight);
        var top2 = new Node("top 2");
        var bottom2 = new Node("bottom 2");
        subgraph2.AddNode(top2);
        subgraph2.AddNode(bottom2);
        var link2 = new Link(top2, bottom2, "Link 2");
        subgraph2.AddLink(link2);
        flowchart.AddSubgraph(subgraph2);
        
        var outside = new Node("outside");
        flowchart.AddNode(outside);
        var link3 = new Link(outside, top2, "Link 3");
        flowchart.AddLink(link3);
        
        var link4 = new Link(outside, subgraph1, "Link 4");
        flowchart.AddLink(link4);
        
        var writer = flowchart.GetBuilder();
        var result = writer.ToString();
        
        outputHelper.WriteLine(result);
    }
    
    [Fact]
    public void Test3_SuperComplexFlowOfSomeonesBiggestChoicesInLife()
    {
        var flowchart = new Flowchart();

        // Early Life Decisions
        var subgraphEarlyLife = new Subgraph("EarlyLife", Direction.TopToBottom);
        var birth = new Node("Birth", Shape.Circle);
        var school = new Node("Choose School", Shape.Diamond);
        subgraphEarlyLife.AddNode(birth);
        subgraphEarlyLife.AddNode(school);
        var linkEarlySchool = new Link(birth, school, "Start School");
        subgraphEarlyLife.AddLink(linkEarlySchool);
        flowchart.AddSubgraph(subgraphEarlyLife);

        // Career Path
        var subgraphCareer = new Subgraph("Career", Direction.LeftToRight);
        var college = new Node("College", Shape.Subroutine);
        var job = new Node("Job", Shape.Rectangle);
        subgraphCareer.AddNode(college);
        subgraphCareer.AddNode(job);
        var linkCareer = new Link(college, job, "Get Job");
        subgraphCareer.AddLink(linkCareer);
        flowchart.AddSubgraph(subgraphCareer);

        // Linking School to Career
        var linkSchoolToCareer = new Link(school, college, "Choose Major");
        flowchart.AddLink(linkSchoolToCareer);

        // Personal Life
        var subgraphPersonalLife = new Subgraph("PersonalLife", Direction.TopToBottom);
        var marriage = new Node("Marriage", Shape.Hexagon);
        var children = new Node("Children", Shape.Circle);
        subgraphPersonalLife.AddNode(marriage);
        subgraphPersonalLife.AddNode(children);
        var linkMarriageChildren = new Link(marriage, children, "Have Children");
        subgraphPersonalLife.AddLink(linkMarriageChildren);
        flowchart.AddSubgraph(subgraphPersonalLife);

        // Link from Job to Personal Life
        var linkJobToPersonal = new Link(job, marriage, "Balance Work-Family");
        flowchart.AddLink(linkJobToPersonal);

        // Late Life Decisions
        var retirement = new Node("Retirement", Shape.Database);
        var linkJobToRetirement = new Link(job, retirement, "Retire");
        flowchart.AddNode(retirement);
        flowchart.AddLink(linkJobToRetirement);

        var legacy = new Node("Legacy", Shape.Rounded);
        var linkChildrenToLegacy = new Link(children, legacy, "Pass on Legacy");
        flowchart.AddNode(legacy);
        flowchart.AddLink(linkChildrenToLegacy);

        // Generating the flowchart description
        var writer = flowchart.GetBuilder();
        var result = writer.ToString();

        outputHelper.WriteLine(result);
    }

    [Fact]
    public void Test4_AbeLincoln()
    {
        var flowchart = new Flowchart();

        // Common start point
        var birth = new Node("Birth", Shape.Circle);
        flowchart.AddNode(birth);

        // Historical Abraham Lincoln
        var subgraphHistorical = new Subgraph("HistoricalLife", Direction.TopToBottom);
        var earlyLife = new Node("Early Life and Family", Shape.Rectangle);
        var professionalCareer = new Node("Professional and Political Career", Shape.Rectangle);
        var presidency = new Node("Presidency and Civil War", Shape.Rectangle);
        var assassination = new Node("Assassination", Shape.Diamond);

        subgraphHistorical.AddNode(earlyLife);
        subgraphHistorical.AddNode(professionalCareer);
        subgraphHistorical.AddNode(presidency);
        subgraphHistorical.AddNode(assassination);

        var linkEarlyCareer = new Link(earlyLife, professionalCareer, "Becomes Lawyer");
        var linkCareerPresidency = new Link(professionalCareer, presidency, "Elected President");
        var linkPresidencyAssassination = new Link(presidency, assassination, "Assassinated by Booth");

        subgraphHistorical.AddLink(linkEarlyCareer);
        subgraphHistorical.AddLink(linkCareerPresidency);
        subgraphHistorical.AddLink(linkPresidencyAssassination);

        flowchart.AddSubgraph(subgraphHistorical);

        // Fictional Abraham Lincoln
        var subgraphFictional = new Subgraph("FictionalLife", Direction.TopToBottom);
        var earlyLifeFiction = new Node("Mother's Death by Vampire", Shape.Hexagon);
        var hunterCareer = new Node("Becomes Vampire Hunter", Shape.Hexagon);
        var supernaturalPresidency = new Node("Supernatural Civil War", Shape.Hexagon);
        var supernaturalAssassination = new Node("Killed by a Vampire", Shape.Diamond);

        subgraphFictional.AddNode(earlyLifeFiction);
        subgraphFictional.AddNode(hunterCareer);
        subgraphFictional.AddNode(supernaturalPresidency);
        subgraphFictional.AddNode(supernaturalAssassination);

        var linkEarlyHunter = new Link(earlyLifeFiction, hunterCareer, "Vows Vengeance");
        var linkHunterSupernatural = new Link(hunterCareer, supernaturalPresidency, "Hidden Agenda in Policies");
        var linkSupernaturalAssassination = new Link(supernaturalPresidency, supernaturalAssassination, "Assassinated by a Vampire-Controlled Booth");

        subgraphFictional.AddLink(linkEarlyHunter);
        subgraphFictional.AddLink(linkHunterSupernatural);
        subgraphFictional.AddLink(linkSupernaturalAssassination);

        flowchart.AddSubgraph(subgraphFictional);

        // Initial link from birth to both life paths
        var linkToHistorical = new Link(birth, earlyLife, "Historical Path");
        var linkToFictional = new Link(birth, earlyLifeFiction, "Fictional Path");

        flowchart.AddLink(linkToHistorical);
        flowchart.AddLink(linkToFictional);

        // Generating the flowchart description
        var writer = flowchart.GetBuilder();
        var result = writer.ToString();

        outputHelper.WriteLine(result);
    }
    
    [Fact]
    public void Test5_ProblemSolvingFlowchart()
    {
        var flowchart = new Flowchart();

        // Nodes for the decision points
        var doesItWork = new Node("Does it work?", Shape.Diamond);
        var didYouTouchIt = new Node("Did you touch it?", Shape.Diamond);
        var doesAnyoneElseKnow = new Node("Does anyone else know?", Shape.Diamond);
        var willYouGetIntoTrouble = new Node("Will you get into trouble?", Shape.Diamond);
        var canYouBlameSomeoneElse = new Node("Can you blame someone else?", Shape.Diamond);
        var leaveItAlone = new Node("Leave the bloody thing alone", Shape.Diamond);
        
        // Nodes for the outcomes
        var noProblems = new Node("No problems", Shape.Rectangle);
        var youIdiot = new Node("You Idiot", Shape.Rectangle);
        var youPoorBastard = new Node("You Poor Bastard", Shape.Rectangle);
        var hideIt = new Node("Hide it", Shape.Rectangle);
        var passTheBuck = new Node("Pass the buck", Shape.Rectangle);
        
        // Adding nodes to the flowchart
        flowchart.AddNode(doesItWork);
        flowchart.AddNode(didYouTouchIt);
        flowchart.AddNode(doesAnyoneElseKnow);
        flowchart.AddNode(willYouGetIntoTrouble);
        flowchart.AddNode(canYouBlameSomeoneElse);
        flowchart.AddNode(noProblems);
        flowchart.AddNode(youIdiot);
        flowchart.AddNode(youPoorBastard);
        flowchart.AddNode(leaveItAlone);
        flowchart.AddNode(hideIt);
        flowchart.AddNode(passTheBuck);

        // Links between the decision points and outcomes
        var linkWorkToLeave = new Link(doesItWork, leaveItAlone, "YES");
        var linkLeaveToNoProblems = new Link(leaveItAlone, noProblems, "YES");
        var linkLeaveToYouIdiot = new Link(leaveItAlone, youIdiot, "NO");
        
        var linkWorkToTouch = new Link(doesItWork, didYouTouchIt, "NO");
        var linkTouchToIdiot = new Link(didYouTouchIt, youIdiot, "YES");
        var linkIdiotToKnow = new Link(youIdiot, doesAnyoneElseKnow);
        var linkKnowToHide = new Link(doesAnyoneElseKnow, hideIt, "NO");
        var linkKnowToBastard = new Link(doesAnyoneElseKnow, youPoorBastard, "YES");
        var linkHideToNoProblems = new Link(hideIt, noProblems);
        
        var linkTouchToTrouble = new Link(didYouTouchIt, willYouGetIntoTrouble, "NO");
        var linkTroubleToBastard = new Link(willYouGetIntoTrouble, youPoorBastard, "YES");
        var linkTroubleToBuck = new Link(willYouGetIntoTrouble, passTheBuck, "NO");
        var linkBuckToNoProblems = new Link(passTheBuck, noProblems);
        
        var lingBastardToBlame = new Link(youPoorBastard, canYouBlameSomeoneElse);
        
        var linkBlameToBastard = new Link(canYouBlameSomeoneElse, youPoorBastard, "NO");
        var linkBlameToNoProblems = new Link(canYouBlameSomeoneElse, noProblems, "YES");
        
        // Adding links to the flowchart
        flowchart.AddLink(linkTroubleToBastard);
        flowchart.AddLink(linkBlameToBastard);
        flowchart.AddLink(linkBlameToNoProblems);
        flowchart.AddLink(linkHideToNoProblems);
        flowchart.AddLink(linkIdiotToKnow);
        flowchart.AddLink(linkKnowToBastard);
        flowchart.AddLink(linkKnowToHide);
        flowchart.AddLink(linkLeaveToNoProblems);
        flowchart.AddLink(linkTouchToIdiot);
        flowchart.AddLink(linkTouchToTrouble);
        flowchart.AddLink(linkTroubleToBuck);
        flowchart.AddLink(linkWorkToLeave);
        flowchart.AddLink(linkWorkToTouch);
        flowchart.AddLink(lingBastardToBlame);
        flowchart.AddLink(linkBuckToNoProblems);
        flowchart.AddLink(linkLeaveToYouIdiot);
        
        // Generating the flowchart description
        var writer = flowchart.GetBuilder();
        var result = writer.ToString();

        outputHelper.WriteLine(result);
    }


}