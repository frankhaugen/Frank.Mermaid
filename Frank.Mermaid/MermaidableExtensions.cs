namespace Frank.Mermaid;

public static class MermaidableExtensions
{
    /// <summary>
    /// Returns the unique identifier of the object as a string without dashes.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string GetId(this IMermaidable source) => source.Id.ToString("N");
}