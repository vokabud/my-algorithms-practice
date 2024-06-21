namespace AP001_DextraAlgorithm;

public class Path
{
    public Path(int distance, List<Node> path)
    {
        Distance = distance;
        Nodes = path;
    }

    public int Distance { get; }

    public List<Node> Nodes { get; }

    public override string ToString() => string.Join(" -> ", Nodes.Select(_ => _.Name));
}
