using CodegenCS;

namespace Frank.Mermaid;

public interface IMermaidable
{
    /// <summary>
    /// The unique identifier of the object.
    /// </summary>
    public Guid Id { get; }
    
    /// <summary>
    /// Returns a string representation of the object in Mermaid syntax.
    /// </summary>
    /// <returns>a string representation of the object in Mermaid syntax</returns>
    public ICodegenTextWriter ToMermaidSyntax();
}

public static class MermaidableExtensions
{
    /// <summary>
    /// Returns the unique identifier of the object as a string without dashes.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string GetId(this IMermaidable source) => source.Id.ToString("N");
}