namespace AP001_DextraAlgorithm;

public class Node
{
    public required string Name { get; set; }

    public IEnumerable<Relation> Relations { get; set; } = [];
}
