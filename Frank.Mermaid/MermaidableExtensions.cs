namespace Frank.Mermaid;

public static class MermaidableExtensions
{
    /// <summary>
    /// Returns the unique identifier of the object as a string without dashes.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string GetId(this IMermaidable source) => source.Id.ToString("N");
    
    /// <summary>
    /// Returns the object as a string in Mermaid syntax ready to be used in a Mermaid diagram.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string GetMermaidString(this IMermaidable source) => source.ToMermaidSyntax().ToString();
}