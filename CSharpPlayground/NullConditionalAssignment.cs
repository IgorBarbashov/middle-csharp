using System;

namespace CSharpPlayground.Features;

public class NullConditionalAssignment
{
    public static void Run()
    {
        var addressMoscow = new Address();
        addressMoscow?.Street ??= "Arbat"; // Выполнится, т.к. address не равен null и Street равен null
        Console.WriteLine(addressMoscow.Street);

        var addressNN = new Address() { Street = "Minia" };
        addressNN?.Street ??= "Arbat"; // Не выполнится, т.к. address не равен null и Street не равен null
        Console.WriteLine(addressNN.Street);

        var addressPiter = new Address() { Buildings = new int[1] };
        addressPiter?.Buildings?[0] = 1035; // Присваивание выполнится, т.к. address и building не равны null
        Console.WriteLine(addressPiter?.Buildings[0]);

        PrintCity();
    }

    public class Address
    {
        public string Street { get; set; } = null;
        public int[] Buildings { get; set; }
    }

    public static void PrintCity()
    {
        var city = new City();

        city?.Name ??= "Arbat";
        Console.WriteLine(city.Name);
    }

    public class City()
    {
        public string? Name { get; set; } = null;
    }



}
