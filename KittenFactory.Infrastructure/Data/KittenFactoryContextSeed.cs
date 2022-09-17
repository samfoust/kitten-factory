using KittenFactory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittenFactory.Infrastructure.Data
{
    public class KittenFactoryContextSeed
    {
        public static void SeedAsync(KittenFactoryContext context)
        {
            if (context.Cats.Any()==false)
            {
                context.Cats.AddRange(GetSeedCats());
                context.SaveChanges();
            }
        }

        private static IEnumerable<Cat> GetSeedCats()
        {
            return new List<Cat>()
            {
                new Cat(){ Name = "Fluffy", ImageUrl = "https://cdn2.thecatapi.com/images/37.gif"},
                new Cat(){ Name = "Chicken", ImageUrl = "https://cdn2.thecatapi.com/images/8u5.gif"},
                new Cat(){ Name = "Kitty-Kat", ImageUrl = "https://cdn2.thecatapi.com/images/MTUwODA5NQ.jpg"},
            };
        }
    }
}
