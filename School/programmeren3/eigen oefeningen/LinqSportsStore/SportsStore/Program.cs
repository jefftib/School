using SportsStore.Data;
using SportsStore.Models;
using SportsStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore
{
    class Program
    {
        static void Main(string[] args)
        {
            // where geeft row select geeft een column
            IEnumerable<Category> categories = DataSourceProvider.Categories;
            IEnumerable<Customer> customers = DataSourceProvider.Customers;
            IEnumerable<Product> products = DataSourceProvider.Products;

            #region 1. Toon de gemiddelde prijs van de producten
            var gemiddelde = products.Select(p => p.Price).Average();

            Console.WriteLine($"De gemiddelde prijs van de producten is { gemiddelde:0.00}");
            #endregion

            #region 2. Toon hoeveel categorieen en hoeveel customers er zijn
            var TotalCustomers = customers.Select(s => s.Name).Count();
            var categorieeenCount = categories.Select(c => c.Name).Count();
            Console.WriteLine($"Er zijn {categorieeenCount} categorieen.");
            Console.WriteLine($"Er zijn {TotalCustomers} TotalCustomers.");
            #endregion

            #region 3. Hoeveel karakters telt de langste productnaam?
            var characters = products.Max(p => p.Name.Length);
            Console.WriteLine($"De langste productnaam is {characters} karakters lang.");
            #endregion

            #region 4. Toon de naam van het product met de langste productnaam

            string productnaam = products.OrderByDescending(p => p.Name.Length).FirstOrDefault()?.Name; // ? = als er nx is negeer statement maar
            Console.WriteLine($"De langste productnaam is {productnaam}.");
            #endregion

            #region 5. Toon alle customers gesorteerd op naam, en vervolgens dalend op voornaam
            IEnumerable<Customer> customersSorted = customers.OrderBy(c => c.Name).ThenByDescending(c => c.FirstName);
            PrintCustomers("Klanten gesorteerd op naam, en dan dalend op voornaam:", customersSorted);
            #endregion

            #region 6. Toon alle producten die meer dan 92.5 dollar kosten, dalend op prijs
            IEnumerable<Product> expensiveProducts = products.Where(p => p.Price > 92.5M).OrderByDescending(p => p.Price);
            PrintProducts("Producten die meer dan 92.5 dollar kosten", expensiveProducts);
            #endregion

            #region 7. Toon de categorieen die meer dan twee producten bevatten

            IEnumerable<Category> myCategories = categories.Where(c => c.Products.Count() > 2);
            PrintCategories("Categorieën met meer dan twee producten", myCategories);
            #endregion

            #region 8. Maak een lijst van strings die alle productnamen bevat
            IEnumerable<string> productNamen = products.Select(p => p.Name);
            PrintStrings("Namen van producten", productNamen);
            #endregion

            #region 9. Maak een lijst van namen van steden waar customers wonen (zonder dubbels) 
            IEnumerable<string> steden = customers.Select(c => c.City.Name).Distinct();
            PrintStrings("Namen van steden waar klanten wonen", steden);
            #endregion

            #region 10. Maak een lijst van ProductViewModels (vorm elk product om tot een productViewModel)
            IEnumerable<ProductViewModel> pvm = products.Select(s => new ProductViewModel
            {
                Name = s.Name,
                Price = s.Price,
                PriceEuro = s.Price * 0.90M
            });
            Console.WriteLine("Lijst van ProductViewModels");
            foreach (var p in pvm)
            {
                Console.WriteLine($"{p.Name} kost { p.Price:0.00} dollar, dat is {p.PriceEuro:0.00} euro");
            }
            Console.WriteLine();
            #endregion

            #region 11. Maak gebruik van een anoniem type 
            // maak een lijst die de naam, de voornaam
            // en de naam van de stad van elke customer bevat
            var customerDetails = customers.Select(c => new
            {
                c.Name,
                c.FirstName,
                cityName = c.City.Name



            });
            Console.WriteLine("Details van customers");
            foreach (var c in customerDetails)
            {
                Console.WriteLine($"{c.Name} {c.FirstName} woont in {c.cityName}");
            }
            #endregion

            #region 12. Pas vorige query aan 
            // zodat het anoniem type nu ook een boolse property bevat
            // die aangeeft of de customer reeds orders heeft
            var customerDetails2 = customers.Select(c => new
            {
                naam = c.Name,
                voornaam = c.FirstName,
                city = c.City.Name,
                order = c.Orders.Count >= 1 ? "" : "geen"
            }); ;

            Console.WriteLine("Details van customers");
            foreach (var c in customerDetails2)
            {
                Console.WriteLine($"{c.naam} {c.voornaam} woont in {c.city} en heeft {c.order} bestellingen");
            }
            #endregion

            #region 13. Geef de namen van de categorieën met enkel producten die de letter 'o' in de naam hebben

            IEnumerable<string> oCategories = categories.Where(c => c.Products.All(cp => cp.Name.Contains("o"))).Select(c => c.Name);


            PrintStrings("Categorieën waarbij alle producten de letter 'o' bevatten", oCategories);
            #endregion

            #region 14. Geef het eerste product die de letter 'f' bevat, vertrek van de lijst van producten gesorteerd op naam

            Product myProductF = products.OrderBy(p => p.Name).Where(p => p.Name.Contains("f")).FirstOrDefault();
            PrintProduct("Eerste product met letter f", myProductF);
            #endregion

            #region 15. Maak een lijst van customers die reeds een product met de naam Football hebben besteld
            IEnumerable<Customer> customersWithFootball = customers.Where(c => c.Orders.Any(c => c.OrderLines.Any(ol => ol.Product.Name.Equals("Football"))));
            // customers.selectMany(o => o.orderlines).Select(o => product.name).Contains("Football");

            PrintCustomers("Klanten die reeds Football bestelden:", customersWithFootball);
            #endregion

            #region 16. Toon de voornaam van de customer met naam Student1.
            // Geef een gepaste melding indien
            //  - er geen customers zijn met die naam, 
            //  - of indien er meerdere customers zijn met die naam  
            // Test je code ook met Student0 en Student9
            string naam = "Student1";
            try
            {


                var studentName = customers.SingleOrDefault(c => c.Name.Equals(naam));
                Console.WriteLine($"{studentName}");

                if (studentName == null)
                {
                    Console.WriteLine($"er zijn  geen studenten met {naam} gevonden");
                }
            }

            catch (Exception)
            {
                Console.WriteLine($"er zijn  meerder studenten met {naam} gevonden");
            }
            #endregion
        }
    
      /*    #region 17. Pas de klasse Cart aan en maak zoveel mogelijk gebruik van expression bodied members
          //Pas de klasse Cart aan
         #endregion
      */
        
        #region Print helpmethodes
        private static void PrintCustomers(string message, IEnumerable<Customer> customers)
        {
            Console.WriteLine(message);
            foreach (Customer c in customers)
                Console.WriteLine($"{ c.Name} {c.FirstName}");
            Console.WriteLine();
        }

        private static void PrintProducts(string message, IEnumerable<Product> products)
        {
            Console.WriteLine(message);
            foreach (Product p in products)
                Console.WriteLine($"{ p.Name}, prijs: { p.Price}");
            Console.WriteLine();
        }

        private static void PrintCategories(string message, IEnumerable<Category> categories)
        {
            Console.WriteLine(message);
            foreach (Category c in categories)
                Console.WriteLine(c.Name);
            Console.WriteLine();
        }

        private static void PrintStrings(string message, IEnumerable<string> strings)
        {
            Console.WriteLine(message);
            foreach (string s in strings)
                Console.WriteLine(s);
            Console.WriteLine();
        }

        private static void PrintProduct(string message, Product product)
        {
            Console.WriteLine(message);
            if (product == null)
                Console.WriteLine("Product is null");
            else
                Console.WriteLine($"{ product.Name}, prijs: {product.Price}");

            Console.WriteLine();
        }
        #endregion
    
        }
    }

