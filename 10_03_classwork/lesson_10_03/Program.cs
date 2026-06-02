namespace lesson_10_03;

class Program
{
    static void Main(string[] args)
    {
        Plant[] plants = new Plant[4];
        plants[0] = new Flower(10);
        plants[1] = new Vegetable(56);
        plants[2] = new Flower(2);
        plants[3] = new Vegetable(20);
        
        foreach (var p in plants)
        {
            Console.WriteLine(p.Name);
            if (p is Flower f)
            {
                Console.WriteLine(f.Petals);
            }

            if (p is Vegetable)
            {
                var v = p as Vegetable;
                Console.WriteLine(v.Energy);
            }
        }
        Console.WriteLine(((Flower)plants[0]).Petals);
    }
}

public abstract class Plant
{
    public string Name { get; }

    public Plant(string name)
    {
        Name = name;
    }
}

public class Flower : Plant
{
    public int Petals { get; }
    public Flower(int petals) : base(nameof(Flower)) // base(typeof(Flower).Name)
    {
        Petals = petals;
    }
}

public class Vegetable : Plant
{
    public int Energy { get; } // kcal
    public Vegetable(int energy) : base(nameof(Flower))
    {
        Energy = energy;
    }
}