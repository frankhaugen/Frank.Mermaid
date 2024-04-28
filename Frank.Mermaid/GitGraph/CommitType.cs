namespace Frank.Mermaid;

public enum CommitType
{
    /// <summary>Default commit type. Represented by a solid circle in the diagram</summary>
    Normal,
    /// <summary>To emphasize a commit as a reverse commit. Represented by a crossed solid circle in the diagram</summary>
    Reverse,
    /// <summary>To highlight a particular commit in the diagram. Represented by a filled rectangle in the diagram</summary>
    Highlight
}