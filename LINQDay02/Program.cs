using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQDay02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ========== RESTRICTION OPERATORS ==========
            Console.WriteLine("============ LINQ - RESTRICTION OPERATORS ============\n");
            RestrictionOperators();

            // ========== ELEMENT OPERATORS ==========
            Console.WriteLine("\n============ LINQ - ELEMENT OPERATORS ============\n");
            ElementOperators();

            // ========== AGGREGATE OPERATORS ==========
            Console.WriteLine("\n============ LINQ - AGGREGATE OPERATORS ============\n");
            AggregateOperators();

            // ========== ORDERING OPERATORS ==========
            Console.WriteLine("\n============ LINQ - ORDERING OPERATORS ============\n");
            OrderingOperators();

            // ========== TRANSFORMATION OPERATORS ==========
            Console.WriteLine("\n============ LINQ - TRANSFORMATION OPERATORS ============\n");
            TransformationOperators();

            // ========== PARTITIONING OPERATORS ==========
            Console.WriteLine("\n============ LINQ - PARTITIONING OPERATORS ============\n");
            PartitioningOperators();

            // ========== QUANTIFIERS ==========
            Console.WriteLine("\n============ LINQ - QUANTIFIERS ============\n");
            QuantifiersOperators();

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }

        // ============= RESTRICTION OPERATORS =============
        static void RestrictionOperators()
        {
            // 1. Find all products that are out of stock
            Console.WriteLine("1. Find all products that are out of stock:");

            var outOfStockProducts = ListGenerators.ProductList.Where(p => p.UnitsInStock == 0);

            foreach (var product in outOfStockProducts)
                Console.WriteLine(product.ProductName);

            // 2. Find all products that are in stock and cost more than 3.00 per unit
            Console.WriteLine("\n2. Find all products in stock and cost more than 3.00:");

            var inStockExpensive = ListGenerators.ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);

            foreach (var product in inStockExpensive.Take(5))
                Console.WriteLine(product.ProductName);
            

            // 3. Returns digits whose name is shorter than their value
            Console.WriteLine("\n3. Digits whose name is shorter than their value:");

            string[] arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortNames = arr.Where((name, index) => name.Length < index);

            foreach (var digit in shortNames)
                Console.WriteLine($"   {digit}");
        }

        // ============= ELEMENT OPERATORS =============
        static void ElementOperators()
        {
            // 1. Get first Product out of Stock
            Console.WriteLine("1. First product out of stock:");

            var firstOutOfStock = ListGenerators.ProductList.FirstOrDefault(p => p.UnitsInStock == 0);

            if (firstOutOfStock != null)
                Console.WriteLine($"   {firstOutOfStock.ProductName} - Stock: {firstOutOfStock.UnitsInStock}");

            // 2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned
            
            Console.WriteLine("\n2. First product with price > 1000 (or null if none):");
            
            var expensiveProduct = ListGenerators.ProductList.FirstOrDefault(p => p.UnitPrice > 1000);
            
            Console.WriteLine($"   {expensiveProduct.ProductName} - Price: {expensiveProduct.UnitPrice:C}");

            // 3. Retrieve the second number greater than 5
            Console.WriteLine("\n3. Second number greater than 5:");
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            
            var secondGreaterThan5 = numbers.Where(n => n > 5).ElementAtOrDefault(1);

            Console.WriteLine($"   {secondGreaterThan5}");

        }

        // ============= AGGREGATE OPERATORS =============
        static void AggregateOperators()
        {
            // 1. Uses Count to get the number of odd numbers in the array
            Console.WriteLine("1. Count of odd numbers in array:");

            int[] arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int oddCount = arr.Count(n => n % 2 == 1);

            Console.WriteLine($"   {oddCount} odd numbers");

            // 2. Return a list of customers and how many orders each has

            Console.WriteLine("\n2. Customers and their order counts:");

            var customerOrders = ListGenerators.CustomerList.Select(c => new { c.Name, OrderCount = c.Orders.Length });

            foreach (var co in customerOrders)
                Console.WriteLine($"   {co.Name}: {co.OrderCount} orders");

            // 3. Return a list of categories and how many products each has
            Console.WriteLine("\n3. Categories and product counts:");

            var categoryProducts = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count);

            foreach (var cp in categoryProducts)
                Console.WriteLine($"   {cp.Category}: {cp.Count} products");

            // 4. Get the total of the numbers in an array

            Console.WriteLine("\n4. Sum of numbers in array:");

            int total = arr.Sum();

            Console.WriteLine($"   Total: {total}");

            // 5. Get the total units in stock for each product category
            Console.WriteLine("\n5. Total units in stock per category:");

            var categoryStock = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, TotalUnits = g.Sum(p => p.UnitsInStock) })
                .OrderByDescending(x => x.TotalUnits);

            foreach (var cs in categoryStock.Take(5))
                Console.WriteLine($"   {cs.Category}: {cs.TotalUnits} units");

            // 6. Get the cheapest price among each category's products
            Console.WriteLine("\n6. Cheapest price in each category:");

            var cheapestByCategory = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, CheapestPrice = g.Min(p => p.UnitPrice) });

            foreach (var cc in cheapestByCategory.Take(5))
                Console.WriteLine($"   {cc.Category}: {cc.CheapestPrice:C}");

            // 7. Get the products with the cheapest price in each category (Use Let)
            Console.WriteLine("\n7. Products with cheapest price in each category (Let):");

            var cheapestProductsByCategory = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    CheapestProduct = g.OrderBy(p => p.UnitPrice).First()
                });

            foreach (var cp in cheapestProductsByCategory.Take(3))
                Console.WriteLine($"   {cp.Category}: {cp.CheapestProduct.ProductName} - {cp.CheapestProduct.UnitPrice:C}");

            // 8. Get the most expensive price among each category's products
            Console.WriteLine("\n8. Most expensive price in each category:");

            var mostExpensiveByCategory = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, MostExpensivePrice = g.Max(p => p.UnitPrice) });

            foreach (var me in mostExpensiveByCategory.Take(5))
                Console.WriteLine($"   {me.Category}: {me.MostExpensivePrice:C}");

            // 9. Get the products with the most expensive price in each category
            Console.WriteLine("\n9. Products with most expensive price in each category:");

            var mostExpensiveProductsByCategory = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    MostExpensiveProduct = g.OrderByDescending(p => p.UnitPrice).First()
                });

            foreach (var mp in mostExpensiveProductsByCategory.Take(3))
                Console.WriteLine($"   {mp.Category}: {mp.MostExpensiveProduct.ProductName} - {mp.MostExpensiveProduct.UnitPrice:C}");

            // 10. Get the average price of each category's products
            Console.WriteLine("\n10. Average price per category:");
            
            var averageByCategory = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Select(g => new { Category = g.Key, AveragePrice = g.Average(p => p.UnitPrice) });

            foreach (var ap in averageByCategory.Take(5))
                Console.WriteLine($"   {ap.Category}: {ap.AveragePrice:C}");
        }

        // ============= ORDERING OPERATORS =============
        static void OrderingOperators()
        {
            // 1. Sort a list of products by name
            Console.WriteLine("1. Products sorted by name:");

            var sortedByName = ListGenerators.ProductList.OrderBy(p => p.ProductName);

            foreach (var product in sortedByName.Take(5))
                Console.WriteLine($"   {product.ProductName}");

            // 2. Uses a custom comparer to do a case-insensitive sort of words
            Console.WriteLine("\n2. Case-insensitive sort of words:");

            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var sortedWords = words.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);

            foreach (var word in sortedWords)
                Console.WriteLine($"   {word}");

            // 3. Sort products by units in stock from highest to lowest
            Console.WriteLine("\n3. Products sorted by units in stock (highest to lowest):");

            var sortedByStock = ListGenerators.ProductList.OrderByDescending(p => p.UnitsInStock);

            foreach (var product in sortedByStock.Take(5))
                Console.WriteLine($"   {product.ProductName}: {product.UnitsInStock} units");

            // 4. Sort digits by name length, then alphabetically
            Console.WriteLine("\n4. Digits sorted by name length, then alphabetically:");

            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var sortedDigits = digits.OrderBy(d => d.Length).ThenBy(d => d);

            foreach (var digit in sortedDigits)
                Console.WriteLine($"   {digit}");

            // 5. Sort words by length, then case-insensitive
            Console.WriteLine("\n5. Words sorted by length, then case-insensitive:");

            var sortedWordsComplex = words.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

            foreach (var word in sortedWordsComplex)
                Console.WriteLine($"   {word}");

            // 6. Sort products by category, then by price (highest to lowest)
            Console.WriteLine("\n6. Products sorted by category, then by price (descending):");

            var sortedByCategory = ListGenerators.ProductList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);

            foreach (var product in sortedByCategory.Take(5))
                Console.WriteLine($"   {product.Category}: {product.ProductName} - {product.UnitPrice:C}");

            // 7. Sort words by length, then case-insensitive descending
            Console.WriteLine("\n7. Words sorted by length, then case-insensitive descending:");

            var sortedWordsDesc = words.OrderBy(w => w.Length)
                .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);
            
            foreach (var word in sortedWordsDesc)
                Console.WriteLine($"   {word}");

            // 8. Digits with second letter 'i', reversed
            Console.WriteLine("\n8. Digits with second letter 'i', reversed:");

            var digitsWithI = digits.Where(d => d.Length > 1 && d[1] == 'i').Reverse();

            foreach (var digit in digitsWithI)
                Console.WriteLine($"   {digit}");
        }

        // ============= TRANSFORMATION OPERATORS =============
        static void TransformationOperators()
        {
            // 1. Return a sequence of just the names of products
            Console.WriteLine("1. Product names only:");

            var productNames = ListGenerators.ProductList.Select(p => p.ProductName);

            foreach (var name in productNames.Take(5))
                Console.WriteLine($"   {name}");          

            // 2. Produce sequence of uppercase and lowercase versions (Anonymous Types)
            Console.WriteLine("\n2. Uppercase and lowercase versions of words:");

            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var caseVersions = words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() });

            foreach (var cv in caseVersions)
                Console.WriteLine($"   Upper: {cv.Upper}, Lower: {cv.Lower}");

            // 3. Sequence of product properties with Price alias
            Console.WriteLine("\n3. Products with Price alias:");

            var productInfo = ListGenerators.ProductList.Select(p => new
            {
                p.ProductName,
                p.Category,
                Price = p.UnitPrice,
                p.UnitsInStock
            });

            foreach (var pi in productInfo.Take(3))
                Console.WriteLine($"   {pi.ProductName}: {pi.Price:C}, Stock: {pi.UnitsInStock}");

            // 4. Determine if values match their position
            Console.WriteLine("\n4. Values matching their position:");

            int[] arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var inPlace = arr.Select((num, index) => new { Number = num, InPlace = (num == index) });

            foreach (var ip in inPlace)
                Console.WriteLine($"   {ip.Number}: {ip.InPlace}");

            // 5. All pairs where numbersA < numbersB
            Console.WriteLine("\n5. Pairs where a < b:");

            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };

            int[] numbersB = { 1, 3, 5, 7, 8 };

            var pairs = numbersA.SelectMany(a => numbersB.Where(b => a < b), (a, b) => $"{a} is less than {b}");

            foreach (var pair in pairs)
                Console.WriteLine($"   {pair}");

            // 6. Select all orders where the order total is less than 500.00
            Console.WriteLine("\n6. Orders with total less than 500.00:");

            var smallOrders = ListGenerators.CustomerList
                .SelectMany(c => c.Orders)
                .Where(o => o.Total < 500);

            foreach (var order in smallOrders.Take(5))
                Console.WriteLine($"   Order {order.Id}: {order.Total:C} - {order.OrderDate.ToShortDateString()}");

            // 7. Select all orders made in 1998 or later
            Console.WriteLine("\n7. Orders made in 1998 or later:");

            var recentOrders = ListGenerators.CustomerList
                .SelectMany(c => c.Orders)
                .Where(o => o.OrderDate.Year >= 1998);

            foreach (var order in recentOrders)
                Console.WriteLine($"   Order {order.Id}: {order.OrderDate.ToShortDateString()}");
        }

        // ============= PARTITIONING OPERATORS =============
        static void PartitioningOperators()
        {
            // 1. Get the first 3 orders from customers (simplified - all customers)
            Console.WriteLine("1. First 3 orders from all customers:");

            var firstThreeOrders = ListGenerators.CustomerList
                .SelectMany(c => c.Orders)
                .Take(3);

            foreach (var order in firstThreeOrders)
                Console.WriteLine($"   Order {order.Id}: {order.OrderDate.ToShortDateString()}");

            // 2. Get all but the first 2 orders from customers
            Console.WriteLine("\n2. All but first 2 orders from all customers:");

            var skipFirstTwo = ListGenerators.CustomerList
                .SelectMany(c => c.Orders)
                .Skip(2);

            foreach (var order in skipFirstTwo.Take(3))
                Console.WriteLine($"   Order {order.Id}: {order.OrderDate.ToShortDateString()}");

            // 3. Elements until a number is less than its position
            Console.WriteLine("\n3. Elements until number < position:");

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var untilLess = numbers.TakeWhile((n, i) => n >= i);

            foreach (var num in untilLess)
                Console.WriteLine($"   {num}");

            // 4. Elements starting from first divisible by 3
            Console.WriteLine("\n4. Elements starting from first divisible by 3:");

            var fromDivisibleBy3 = numbers.SkipWhile(n => n % 3 != 0);

            foreach (var num in fromDivisibleBy3)
                Console.WriteLine($"   {num}");

            // 5. Elements starting from first less than its position
            Console.WriteLine("\n5. Elements starting from first < position:");

            var fromLessThanPosition = numbers.SkipWhile((n, i) => n >= i);

            foreach (var num in fromLessThanPosition)
                Console.WriteLine($"   {num}");
        }

        // ============= QUANTIFIERS =============
        static void QuantifiersOperators()
        {
            // 1. Check if any product is out of stock
            Console.WriteLine("1. Are there any products out of stock?");

            bool anyOutOfStock = ListGenerators.ProductList.Any(p => p.UnitsInStock == 0);

            Console.WriteLine($"   {(anyOutOfStock ? "Yes" : "No")} - Found {ListGenerators.ProductList.Count(p => p.UnitsInStock == 0)} out of stock");

            // 2. Return categories that have at least one product out of stock
            Console.WriteLine("\n2. Categories with at least one product out of stock:");

            var categoriesWithOutOfStock = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Where(g => g.Any(p => p.UnitsInStock == 0))
                .Select(g => g.Key);

            foreach (var category in categoriesWithOutOfStock)
                Console.WriteLine($"   {category}");

            // 3. Return categories where all products are in stock
            Console.WriteLine("\n3. Categories where all products are in stock:");

            var categoriesAllInStock = ListGenerators.ProductList
                .GroupBy(p => p.Category)
                .Where(g => g.All(p => p.UnitsInStock > 0))
                .Select(g => g.Key);

            foreach (var category in categoriesAllInStock)
                Console.WriteLine($"   {category}");
        }
    }
}
