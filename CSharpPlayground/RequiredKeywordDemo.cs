using System;

namespace CSharpPlayground.Features
{
    public class RequiredKeywordDemo
    {
        public static void Run()
        {
            var addressMoscow = new Address() { Street = "Arbat" };
            var addressNN = new Address() { Street = "Bolshaya Pokrovskaya" };

            //var addressError = new Address(); // Ошибка компиляции: требуется инициализация свойства Street

            Console.WriteLine(addressMoscow.Street);
            Console.WriteLine(addressNN.Street);
        }

        public class Address
        {
            // required - обязательное поле при инициализации объекта
            public required string Street { get; set; }
        }
    }
}
