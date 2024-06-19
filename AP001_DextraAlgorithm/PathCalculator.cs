namespace AP001_DextraAlgorithm;

public class PathCalculator
{
    private class PriceTable
    {
        public required string Parent { get; set; }

        public required string EdgeTo { get; set; }

        public int Weight { get; set; }
    }

    List<PriceTable> DestinationTable = [];

    public int CalculatePath(Node start, Node finish)
    {
        var parents = new Dictionary<string, Node>();
        var distance = new Dictionary<string, int>();

        DestinationTable = [];

        AddToDestinationTable(0, start, finish, parents, distance);

        var count = DestinationTable.Count();
        Console.WriteLine(count);

        var result = DestinationTable
            .Where(_ => _.EdgeTo == finish.Name)
            .OrderByDescending(_ => _.Weight)
            .First()
            .Weight;

        return result;
    }

    private void AddToDestinationTable(
        int weightToEdge,
        Node start,
        Node finish,
        Dictionary<string, Node> parents,
        Dictionary<string, int> distance)
    {
        foreach (var edge in start.Edges)
        {
            var nodeInTable = DestinationTable
                .FirstOrDefault(_ => _.EdgeTo == edge.To.Name);

            if (nodeInTable != null)
            {
                if (edge.Weight + weightToEdge < nodeInTable.Weight)
                {
                    nodeInTable.Parent = start.Name;
                    nodeInTable.Weight = edge.Weight + weightToEdge;
                }
            }
            else
            {
                DestinationTable.Add(new PriceTable
                {
                    Parent = start.Name,
                    EdgeTo = edge.To.Name,
                    Weight = edge.Weight + weightToEdge
                });
            }
        }

        foreach (var edge in start.Edges)
        {
            var nodeInTable = DestinationTable.First(_ => _.EdgeTo == edge.To.Name);

            AddToDestinationTable(nodeInTable.Weight, edge.To, finish, parents, distance);
        }
    }
}
