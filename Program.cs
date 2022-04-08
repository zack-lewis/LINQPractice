using System;
using System.Linq;

namespace LINQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product(1252, ProductCategory.Computers, "Logitech M510 Wireless Computer Mouse", 18.49, 25),
                new Product(1343, ProductCategory.Computers, "Redragon K552 KUMARA LED Backlit Mechanical Gaming Keyboard", 29.99, 9),
                new Product(1542, ProductCategory.Computers, "Corsair Vengeance LPX 16GB (2x8GB) DDR4 DRAM 3000MHz", 139.99, 42),
                new Product(1721, ProductCategory.Computers, "USB 3.0 A to A Cable Type A Male to Male, 3 feet", 7.29, 112),
                new Product(2231, ProductCategory.Computers, "USB C to USB A", 10.99, 84),
                new Product(2405, ProductCategory.Computers, "EVGA GeForce GTX 1050 Ti Gaming Video Card, 4GB GDDR5", 169.99, 25),
                new Product(2502, ProductCategory.Computers, "ASUS ROG Strix Z370-E Motherboard LGA1151 ", 209.99, 8),
                new Product(3152, ProductCategory.Electronics, "Tascam DR05 Stereo Portable Digital Recorder", 92.99, 14),
                new Product(3178, ProductCategory.Electronics, "Toshiba 43LF621U19 43-inch 4K Ultra HD Smart LED TV HDR", 319.99, 23),
                new Product(3556, ProductCategory.Electronics, "Crown XLS1502 Two-channel, 525W at 4Ω Power Amplifier", 399.00, 17),
                new Product(4339, ProductCategory.Kitchen, "KitchenAid KSM150PSER Artisan Tilt-Head Stand Mixer", 278.63, 36),
                new Product(4411, ProductCategory.Kitchen, "Hamilton Beach 62682RZ Hand Mixer", 14.99, 67),
                new Product(4523, ProductCategory.Kitchen, "Tovolo Flex-Core All Silicone Spatula", 10.49, 98),
                new Product(5134, ProductCategory.Kitchen, "Circulon Symmetry Hard Anodized Nonstick Skillet", 49.95, 62),
                new Product(5216, ProductCategory.Pet, "Neater Feeder Express Pet Bowls", 22.99, 6),
                new Product(5678, ProductCategory.Pet, "Magic Roller Ball Dog Toy", 10.80, 9),
                new Product(6123, ProductCategory.Pet, "Pillow Pets Signature Cozy Cow Plush Toy", 19.99, 17),
                new Product(6732, ProductCategory.Pet, "Evriholder FURemover Broom with Squeegee ", 15.99, 21),
                new Product(7128, ProductCategory.Pet, "Fabreze Pet Oder Eliminator", 4.94, 33),
                new Product(7231, ProductCategory.Pet, "Professional Pet Slicker Rug Brush for Dogs", 7.59, 17)
            };

            // QUERIES

            // 1. List of products with prices in range $10 to $20:
            var productsWithPricesInRange10To20 = from product in products where product.Price >= 10.00 & product.Price <= 20.00 select product;
            var productsWithPricesInRange10To20Functional = products.Where(product => (product.Price >= 10.00 & product.Price <= 20.00));
            
            // 2. List of products with prices in range $10 to $20 ordered by price ascending:
            var products_price10To20AscendingByPrice_nonfun = from product in products where product.Price <= 20 & product.Price >= 10 orderby product.Price ascending select product;
            var products_price10To20AscendingByPrice_fun = products.Where(product => (product.Price <= 20 & product.Price >= 10)).OrderBy(product => (product.Price));
            
            // 3. List of titles for products with prices in range $10 to $20 ordered by title alphabetically ascending:
            var titles_price10To20AscendingByTitle_nonfun = from product in products where product.Price <= 20 & product.Price >= 10 orderby product.Title ascending select product.Title;
            var titles_price10To20AscendingByTitle_fun = products.Where(product => (product.Price <=20 & product.Price >= 10)).OrderBy(product => product.Title).Select(product => product.Title);
            
            // 4. List of IDs for products with prices in range $10 to $20 ordered by ID descending:
            var id_price10To20DescendingById_nonfun = from product in products where product.Price <= 20 & product.Price >= 10 orderby product.ID descending select product.ID;
            var id_price10To20DescendingById_fun = products.Where(product => (product.Price <= 20 & product.Price >= 10)).OrderByDescending(product => product.ID).Select(product => product.ID);
            
            // 5. Kitchen products:
            var products_categoryKitchen_nonfun = from product in products where product.Category == ProductCategory.Kitchen select product;
            var products_categoryKitchen_fun = products.Where(product => product.Category == ProductCategory.Kitchen);
            
            // 6. Kitchen products ordered by quantity in stock descending:
            var products_categoryKitchenDescendingByStockQty_nonfun = from product in products where product.Category == ProductCategory.Kitchen orderby product.StockedQuantity descending select product;
            var products_categoryKitchenDescendingByStockQty_fun = products.Where(product => product.Category == ProductCategory.Kitchen).OrderByDescending(product => product.StockedQuantity);
            
            // 7. Computer products costing more than $100:
            var products_categoryComputerPriceGT100_nonfun = from product in products where product.Price > 100 & product.Category == ProductCategory.Computers select product;
            var products_categoryComputerPriceGT100_fun = products.Where(product => (product.Category == ProductCategory.Computers & product.Price > 100));
            
            // 8. Title of product with an ID of 3152:
            var title_productId3152_nonfun = (from product in products where product.ID == 3152 select product.Title).FirstOrDefault();
            var title_productId3152_fun = products.Where(product => product.ID == 3152).Select(product => product.Title).FirstOrDefault();
            
            // 9. List of products with titles longer than 50 characters:
            var products_titleGT50Chars_nonfun = from product in products where product.Title.Length > 50 select product;
            var products_titleGT50Chars_fun = products.Where(product => product.Title.Length > 50);
            
            // 10. List of Pet products ordered by price from lowest to highest:
            var products_categoryPetAscendingByPrice_nonfun = from product in products where product.Category == ProductCategory.Pet orderby product.Price ascending select product;
            var products_categoryPetAscendingByPrice_fun = products.Where(product => product.Category == ProductCategory.Pet).OrderBy(product => product.Price);
            
            // 11. List of products with IDs in range 2000 to 2999 ordered by ID:
            var products_id2000to2999OrderByID_nonfun = from product in products where product.ID <= 2999 & product.ID >= 2000 orderby product.ID select product;
            var products_id2000to2999OrderByID_fun = products.Where(product => (product.ID <= 2999 & product.ID >= 2000)).OrderBy(product => product.ID);
            
            // 12. List of titles for products with IDs in range 2000 to 2999 ordered by title length:
            var titles_id2000To2999OrderByTitleLength_nonfun = from product in products where product.ID <= 2999 & product.ID >= 2000 orderby product.Title.Length select product.Title;
            var titles_id2000To2999OrderByTitleLength_fun = products.Where(product => (product.ID <= 2999 & product.ID >= 2000)).OrderBy(product => product.Title.Length).Select(product => product.Title);
            
            // 13. Titles and stocked quantity for products with less than 20 in stock:
            var titlesWQty_qtyLT20InStock_nonfun = from product in products where product.StockedQuantity < 20 select new { Title = product.Title,StockedQuantity = product.StockedQuantity };
            var titlesWQty_qtyLT20InStock_fun = products.Where(product => product.StockedQuantity < 20).Select(product => new {Title = product.Title, StockedQuantity = product.StockedQuantity});
            
            // 14. Titles and stocked quantity for products with less than 20 in stock ordered by stock ascending:
            var titlesWQty_qtyLT20InStockAscendingByStock_nonfun = from product in products where product.StockedQuantity < 20 orderby product.StockedQuantity ascending select new { Title = product.Title,StockedQuantity = product.StockedQuantity };
            var titlesWQty_qtyLT20InStockAscendingByStock_fun = products.Where(product => product.StockedQuantity < 20).OrderBy(product => product.StockedQuantity).Select(product => new {Title = product.Title, StockedQuantity = product.StockedQuantity});
            



            // WRITING OUTPUT OF ABOVE QUERIES
            Console.WriteLine("1. List of products with prices in range $10 to $20:");
            Console.WriteLine("Non-functional: ");
            foreach(Product p in productsWithPricesInRange10To20) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Functional: ");
            foreach(Product p in productsWithPricesInRange10To20Functional) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("----------------------------------------------------\n");
            
            Console.WriteLine("2. List of products with prices in range $10 to $20 ordered by price ascending:");
            Console.WriteLine("Non-functional: ");
            foreach(Product p in products_price10To20AscendingByPrice_nonfun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Functional: ");
            foreach(Product p in products_price10To20AscendingByPrice_fun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("3. List of titles for products with prices in range $10 to $20 ordered by title alphabetically ascending:");
            Console.WriteLine("Non-functional: ");
            foreach(String t in titles_price10To20AscendingByTitle_nonfun) {
                Console.WriteLine(t.ToString());
            }
            Console.WriteLine("Functional: ");
            foreach(String t in titles_price10To20AscendingByTitle_fun) {
                Console.WriteLine(t.ToString());
            }
            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("4. List of IDs for products with prices in range $10 to $20 ordered by ID descending:");
            Console.WriteLine("Non-functional: ");
            foreach (int id in id_price10To20DescendingById_nonfun)
            {
                Console.WriteLine(id);
            }
            Console.WriteLine("Functional: ");
            foreach (int id in id_price10To20DescendingById_fun)
            {
                Console.WriteLine(id);
            }
            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("5. Kitchen products:");
            Console.WriteLine("Non-functional: ");
            foreach(Product p in products_categoryKitchen_nonfun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Functional: ");
            foreach(Product p in products_categoryKitchen_fun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("6. Kitchen products ordered by quantity in stock descending:");
            Console.WriteLine("Non-functional: ");
            foreach(Product p in products_categoryKitchenDescendingByStockQty_nonfun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Functional: ");
            foreach(Product p in products_categoryKitchenDescendingByStockQty_fun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("7. Computer products costing more than $100:");
            Console.WriteLine("Non-functional: ");
            foreach(Product p in products_categoryComputerPriceGT100_nonfun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Functional: ");
            foreach(Product p in products_categoryComputerPriceGT100_fun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("8. Title of product with an ID of 3152:");
            Console.WriteLine("Non-functional: ");
            Console.WriteLine(title_productId3152_nonfun);
            Console.WriteLine("Functional: ");
            Console.WriteLine(title_productId3152_fun);
            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("9. List of products with titles longer than 50 characters:");
            Console.WriteLine("Non-functional: ");
            foreach(Product p in products_titleGT50Chars_nonfun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Functional: ");
            foreach(Product p in products_titleGT50Chars_fun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("10. List of Pet products ordered by price from lowest to highest:");
            Console.WriteLine("Non-functional: ");
            foreach(Product p in products_categoryPetAscendingByPrice_nonfun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Functional: ");
            foreach(Product p in products_categoryPetAscendingByPrice_fun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("11. List of products with IDs in range 2000 to 2999 ordered by ID:");
            Console.WriteLine("Non-functional: ");
            foreach(Product p in products_id2000to2999OrderByID_nonfun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("Functional: ");
            foreach(Product p in products_id2000to2999OrderByID_fun) {
                Console.WriteLine(p.ToString());
            }
            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("12. List of titles for products with IDs in range 2000 to 2999 ordered by title length:");
            Console.WriteLine("Non-functional: ");
            foreach (string t in titles_id2000To2999OrderByTitleLength_nonfun)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("Functional: ");
            foreach (string t in titles_id2000To2999OrderByTitleLength_fun)
            {
                Console.WriteLine(t);
            }
            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("13. Titles and stocked quantity for products with less than 20 in stock:");
            Console.WriteLine("Non-functional: ");
            foreach (var t in titlesWQty_qtyLT20InStock_nonfun)
            {
                Console.WriteLine(t.ToString());
            }
            Console.WriteLine("Functional: ");
            foreach (var t in titlesWQty_qtyLT20InStock_fun)
            {
                Console.WriteLine(t.ToString());
            }
            Console.WriteLine("----------------------------------------------------\n");

            Console.WriteLine("14. Titles and stocked quantity for products with less than 20 in stock ordered by stock ascending:");
            Console.WriteLine("Non-functional: ");
            foreach (var t in titlesWQty_qtyLT20InStockAscendingByStock_nonfun)
            {
                Console.WriteLine(t.ToString());
            }
            Console.WriteLine("Functional: ");
            foreach (var t in titlesWQty_qtyLT20InStockAscendingByStock_fun)
            {
                Console.WriteLine(t.ToString());
            }
            Console.WriteLine("----------------------------------------------------\n");

        }
    }
}
