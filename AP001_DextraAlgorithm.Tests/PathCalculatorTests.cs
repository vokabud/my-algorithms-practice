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
        Assert.Equal(6, result.Distance);
        Assert.Equal("House -> School -> Park -> Work", result.ToString());
    }

    [Fact]
    public void Sunshine_Extended()
    {
        // arrange
        var notebook = new Node { Name = "notebook" };
        var vinyl = new Node { Name = "vinyl" };
        var poster = new Node { Name = "poster" };
        var guitar = new Node { Name = "guitar" };
        var drum = new Node { Name = "drum" };
        var piano = new Node { Name = "piano" };

        notebook.Edges.Add(new Edge { To = vinyl, Weight = 5 });
        notebook.Edges.Add(new Edge { To = poster, Weight = 0 });

        vinyl.Edges.Add(new Edge { To = guitar, Weight = 15 });
        vinyl.Edges.Add(new Edge { To = drum, Weight = 20 });

        poster.Edges.Add(new Edge { To = guitar, Weight = 30 });
        poster.Edges.Add(new Edge { To = drum, Weight = 35 });

        guitar.Edges.Add(new Edge { To = piano, Weight = 20 });

        drum.Edges.Add(new Edge { To = piano, Weight = 10 });

        // act
        var result = new PathCalculator().CalculatePath(notebook, piano);

        // assert
        Assert.Equal(35, result.Distance);
        Assert.Equal("notebook -> vinyl -> drum -> piano", result.ToString());
    }
}
