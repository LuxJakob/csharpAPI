namespace FrogWorld.Models;

public class Frog
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool ScreamingCroak { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        Frog otherFroggi = (Frog)obj;

        return
            Id == otherFroggi.Id &&
            Name == otherFroggi.Name &&
            ScreamingCroak == otherFroggi.ScreamingCroak;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, ScreamingCroak);
    }
}