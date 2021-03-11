using ShopKzLINQHomework.DataAccessLayer;
using System;
using System.Linq;

namespace ShopKzLINQHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ShopContext())
            {
                int pageSize = 4;

                var manufacturers = context.Manufacturer.ToList();
                var categories = context.Category.ToList();
                int pageNumber = 0;
                var products = context.Product.ToList();
                int count = context.Product.Count();

                do
                {
                    Console.WriteLine("Для сортировки нажмити на одну из указанных клавиш. Для перемещения по странице нажмите на стрелки\n\tN - сортировка по алфавиту\tP - сортировка по цене  \tD- сортировка по дате\n");
                    Console.WriteLine("\t\tShop.kz\n");

                    var products2 = products.Skip(pageNumber * pageSize).Take(pageSize).ToList();

                    foreach (var product in products2)
                    {
                        Console.WriteLine($"{product.Category.Name} {product.Manufacturer.Name} {product.Name}" +
                            $"\n\tPrice: {product.Price}\n\tManufacturer: {product.Manufacturer.Name}\n\tCategory: {product.Category.Name}\n\tDate: {product.PublicityDate}\n");
                    }
                    var input = Console.ReadKey(true).Key;

                    switch (input)
                    {
                        case ConsoleKey.N:
                            products = products.OrderBy(product => product.Name).ToList();
                            break;
                        case ConsoleKey.P:
                            products = products.OrderBy(product => product.Price).ToList();
                            break;
                        case ConsoleKey.D:
                            products = products.OrderBy(product => product.PublicityDate).ToList();
                            break;
                        case ConsoleKey.RightArrow:
                            if (count >= pageNumber * pageSize && pageNumber * pageSize  < products.Count - pageSize)
                            {
                                pageNumber++;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (count >= pageNumber * pageSize && pageNumber > 0)
                            {
                                pageNumber--;
                            }
                            break;
                    }
                    Console.Clear();
                } while (true);               

            }

        }
    }
}
