using Frank.Mermaid.GitGraph;
using Xunit.Abstractions;

namespace Frank.Mermaid.Tests;

public class GitGraphTests
{
    private readonly ITestOutputHelper _outputHelper;

    public GitGraphTests(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }
    
    [Fact]
    public void Test1()
    {
        var graph = new GitGraph.GitGraph();
        var commit1 = new Commit( "", "","Commit 1");
        var commit2 = new Commit("", "", "Commit 2");
        graph.AddCommit(commit1);
        graph.AddCommit(commit2);
        
        
        var writer = graph.ToMermaidSyntax();
        var result = writer.ToString();
        
        _outputHelper.WriteLine(result);
    }
}