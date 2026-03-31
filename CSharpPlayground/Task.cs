namespace AddressNamespace;

using System;

class Address
{
    void PrintAddress(int building)
    {
        var street = new Street().GetStreet("Arbat");
        Console.WriteLine($"{street}, {building}");
    }
}

class Street
{
    public string GetStreet(string street)
    {
        return $"Улица {street}";
    }
}
