public record Manufacturer(string name, IEnumerable<Vehicle> vehicles);


public record Vehicle(string name, bool isAvailable);

public static class DB
{
    public static IEnumerable<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>
    {
        new Manufacturer("SpaceX", new List<Vehicle>{
            new Vehicle("Falcon 9", true),
            new Vehicle("Falcon Heavy",true),
            new Vehicle("Starship", false)
        }),
        new Manufacturer("Blue Origin",new List<Vehicle>{
            new Vehicle("New Shepard", true),
            new Vehicle("New Glenn", false),
        }),
        new Manufacturer("virgin Galactic", new List<Vehicle>{
            new Vehicle("Space Ship One",false),
            new Vehicle("Space Ship Two", true),
            new Vehicle("Space Ship Three", false),
        }),
        new Manufacturer("Roscosmos", new List<Vehicle>{
            new Vehicle("Proton-M",true),
            new Vehicle("Soyuz-2.1a",true),
            new Vehicle("Soyuz-2.1b",true),
            new Vehicle("Soyuz-2.1v",true),
        }),
        new Manufacturer("Rocket Lab",new List<Vehicle>{
            new Vehicle("Electron",true),
            new Vehicle("Neutron",false),
        }),
        new Manufacturer("Firefly Aerospace",new List<Vehicle>{
            new Vehicle("Firefly Alpha",false),
            new Vehicle("Firefly Beta",false),
        }),
    };
}