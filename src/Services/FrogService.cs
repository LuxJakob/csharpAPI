using FrogWorld.Models;

namespace FrogWorld.Services;

public static class FrogService
{
    static List<Frog> Frogs { get; }
    static int nextId = 3;
    static FrogService()
    {
        Frogs = new List<Frog>
        {
            new() { Id = 1, Name = "Big Frog", ScreamingCroak = true },
            new() { Id = 2, Name = "Fire Frog", ScreamingCroak = false }
        };
    }

    public static List<Frog> GetAll() => Frogs;

    public static Frog? Get(int id) => Frogs.FirstOrDefault(f => f.Id == id);

    public static void Add(Frog frog)
    {
        frog.Id = nextId++;
        Frogs.Add(frog);
    }

    public static void Update(Frog frog)
    {
        var index = Frogs.FindIndex(p => p.Id == frog.Id);
        if (index == -1)
            return;

        Frogs[index] = frog;
    }

    public static void Delete(int id)
    {
        var frog = Get(id);
        if (frog is null)
            return;

        Frogs.Remove(frog);
    }
}