using System;
using System.Collections.Generic;

namespace CSharpPlayground.Features
{
    public class ParamsCollections
    {
        public static void Run()
        {

            Address address = new Address();
            Console.WriteLine(address.CountApartments(1, 2, 3, 10, 20));
            Console.WriteLine(address.CountApartments());
            Console.WriteLine(address.CountApartments([1, 2, 3]));
            Console.WriteLine(address.CountApartments([]));
        }

        public class Address
        {
            public int CountApartments(params List<int> apartments)
            {
                return apartments.Count;
            }
        }
    }
}
