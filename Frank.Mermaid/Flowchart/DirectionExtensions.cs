namespace Frank.Mermaid.Flowchart;

public static class DirectionExtensions
{
    public static string ToMermaidSyntax(this Direction direction)
    {
        return direction switch
        {
            Direction.TopToBottom => "TB",
            Direction.TopDown => "TD",
            Direction.BottomToTop => "BT",
            Direction.RightToLeft => "RL",
            Direction.LeftToRight => "LR",
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
}