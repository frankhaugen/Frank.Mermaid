namespace Frank.Mermaid;

public interface IMermaidable
{
    /// <summary>
    /// The unique identifier of the object.
    /// </summary>
    Guid Id { get; }
    
    /// <summary>
    /// Returns a string representation of the object in Mermaid syntax.
    /// </summary>
    /// <returns>a string representation of the object in Mermaid syntax</returns>
    IIndentedStringBuilder GetBuilder();
}