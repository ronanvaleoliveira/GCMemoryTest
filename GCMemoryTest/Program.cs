var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


app.MapGet("/", () =>
{
    var barry = GenerateAndSelectABarry();

    //GC.Collect();

    return barry
    + Environment.NewLine
    + GC.GetTotalMemory(false) / 1024 / 1024 + "Mb managed memory"
    + Environment.NewLine
    + System.Environment.WorkingSet / 1024 / 1024 + "Mb total used";
});

app.Run();

static string GenerateAndSelectABarry()
{
var barryGenerator = new BarryGenerator();
var barrys = barryGenerator.GenerateBarrys();
return barrys[new Random().Next(barrys.Count)];
}

public class BarryGenerator
{
    public List<string> GenerateBarrys()
    {
        return Enumerable.Range(1, 10000000)
            .Select(i => "Barry " +
            Guid.NewGuid().ToString()).ToList();
    }
}