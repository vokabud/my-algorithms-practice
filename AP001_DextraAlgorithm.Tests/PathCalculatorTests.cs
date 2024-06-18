namespace AP001_DextraAlgorithm.Tests;

public class PathCalculatorTests
{
    [Fact]
    public void Sunshine()
    {
        // arrange
        var house = new Node { Name = "House" };
        var school = new Node { Name = "School" };
        var park = new Node { Name = "Park" };
        var work = new Node { Name = "Work" };

        house.Edges.Add(new Edge { To = park, Weight = 6 });
        house.Edges.Add(new Edge { To = school, Weight = 2 });

        school.Edges.Add(new Edge { To = park, Weight = 1 });
        school.Edges.Add(new Edge { To = work, Weight = 5 });

        park.Edges.Add(new Edge { To = work, Weight = 3 });

        // act
        var result = new PathCalculator().CalculatePath(house, work);

        // assert
        Assert.Equal(6, result);
    }
}