using Frank.Mermaid.Flowchart;
using Frank.Mermaid.Timeline;
using Xunit.Abstractions;

namespace Frank.Mermaid.Tests;

public class FlowchartTests
{
    private readonly ITestOutputHelper _outputHelper;

    public FlowchartTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public void Test1()
    {
        var flowchart = new Flowchart.Flowchart();
        var node1 = new Node("Node 1");
        var node2 = new Node("Node 2");
        flowchart.AddNode(node1);
        flowchart.AddNode(node2);
        
        var link = new Link(node1, node2);
        flowchart.AddLink(link);
        
        var subgraph = new Subgraph("Subgraph 1", Direction.TopToBottom);
        var subgraphNode1 = new Node("Subgraph Node 1");
        var subgraphNode2 = new Node("Subgraph Node 2");
        subgraph.AddNode(subgraphNode1);
        subgraph.AddNode(subgraphNode2);
        
        var subgraphLink = new Link(subgraphNode1, subgraphNode2, "Subgraph Link 1");
        subgraph.AddLink(subgraphLink);
        
        var link2 = new Link(subgraph, node2, "Subgraph Link to Node 2");
        flowchart.AddLink(link2);
        
        flowchart.AddSubgraph(subgraph);
        
        var writer = flowchart.ToMermaidSyntax();
        var result = writer.ToString();
        
        _outputHelper.WriteLine(result);
    }
    
    [Fact]
    public void Test2()
    {
        /*
         Testcase:
         flowchart LR
            subgraph subgraph1
                direction TB
                top1[top] --> bottom1[bottom]
            end
            subgraph subgraph2
                direction TB
                top2[top] --> bottom2[bottom]
            end
            %% ^ These subgraphs are identical, except for the links to them:

            %% Link *to* subgraph1: subgraph1 direction is maintained
            outside --> subgraph1
            %% Link *within* subgraph2:
            %% subgraph2 inherits the direction of the top-level graph (LR)
            outside ---> top2
         */
        
        var flowchart = new Flowchart.Flowchart();
        
        var subgraph1 = new Subgraph("subgraph1", Direction.TopToBottom);
        var top1 = new Node("top");
        var bottom1 = new Node("bottom");
        subgraph1.AddNode(top1);
        subgraph1.AddNode(bottom1);
        var link1 = new Link(top1, bottom1);
        subgraph1.AddLink(link1);
        flowchart.AddSubgraph(subgraph1);
        
        var subgraph2 = new Subgraph("subgraph2", Direction.TopToBottom);
        var top2 = new Node("top");
        var bottom2 = new Node("bottom");
        subgraph2.AddNode(top2);
        subgraph2.AddNode(bottom2);
        var link2 = new Link(top2, bottom2);
        subgraph2.AddLink(link2);
        flowchart.AddSubgraph(subgraph2);
        
        var outside = new Node("outside");
        flowchart.AddNode(outside);
        var link3 = new Link(outside, subgraph1);
        flowchart.AddLink(link3);
        
        var link4 = new Link(outside, top2);
        flowchart.AddLink(link4);
        
        var writer = flowchart.ToMermaidSyntax();
        var result = writer.ToString();
        
        _outputHelper.WriteLine(result);
    }
}