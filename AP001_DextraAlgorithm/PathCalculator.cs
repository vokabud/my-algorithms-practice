namespace AP001_DextraAlgorithm;

public class PathCalculator
{
    public Path CalculatePath(Node start, Node finish)
    {
        var parents = new Dictionary<Node, Node>();
        var distance = new Dictionary<Node, int>();

        MeasureDistanceFrom(0, start, parents, distance);

        var node = finish;
        var path = new Stack<Node>();

        do
        {
            path.Push(node);
            node = parents.ContainsKey(node)
                ? parents[node]
                : null;
        }
        while (node != null);

        return new Path(distance[finish], path.ToList());
    }

    private void MeasureDistanceFrom(
        int distanceToNode,
        Node start,
        Dictionary<Node, Node> parents,
        Dictionary<Node, int> distances)
    {
        foreach (var edge in start.Edges)
        {
            var distance = edge.Weight + distanceToNode;

            if (distances.ContainsKey(edge.To))
            {

                if (distance < distances[edge.To])
                {
                    parents[edge.To] = start;
                    distances[edge.To] = distance;
                }
            }
            else
            {
                parents.Add(edge.To, start);
                distances.Add(edge.To, distance);
            }
        }

        foreach (var edge in start.Edges)
        {
            MeasureDistanceFrom(distances[edge.To], edge.To, parents, distances);
        }
    }
}
