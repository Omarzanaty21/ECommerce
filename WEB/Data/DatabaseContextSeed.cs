using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WEB.Models;

namespace WEB.Data
{
    public static class DatabaseContextSeed
    {
        public static void SeedData(DatabaseContext context, IWebHostEnvironment env)
        {
            using var hmac = new HMACSHA512();

            if (!context.Admins.Any())
            {
                var admin = new Admin();
                    admin.FirstName = "Abdelrahman";
                    admin.LastName = "Osama";
                    admin.Email = "admin@admin.com";
                    admin.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("admin"));
                    admin.PasswordSalt = hmac.Key;

                context.Admins.Add(admin);
                context.SaveChanges();
            }
            /*

            // if(context.Categories.Count() < 5)
            // {
            //     List<Category> categoriesToSeed = new List<Category>();

            //     var category1 = new Category{Name = "TVs"};
            //     categoriesToSeed.Add(category1);

            //     var category2 = new Category{Name = "Electronic Devices"};
            //     categoriesToSeed.Add(category2);

            //     var category3 = new Category{Name = "Entertainment"};
            //     categoriesToSeed.Add(category3);

            //     var category4 = new Category{Name = "Pen"};
            //     categoriesToSeed.Add(category4);

            //     var category5 = new Category{Name = "Computers"};
            //     categoriesToSeed.Add(category5);

            //     foreach(var category in categoriesToSeed)
            //     {
            //         context.Categories.Add(category);
            //     }

            //     context.SaveChanges();
            // }
           
            // if (context.Products.Count() < 9)
            // {
            //     List<Product> productsToSeed = new List<Product>();

            //     var product1 = new Product{
            //         Description = "Game entertaining platform",
            //         CategoryId = 2,
            //         Name = "XBox",
            //         pictureLocationName = "XBox.jpg",
            //         PicturePath = Path.Combine(env.WebRootPath, "Uploads", "ProductPictures", "XBox.jpeg"),
            //         Price = 200.00M,
            //         Quantity = 12,
            //     };
            //     productsToSeed.Add(product1);

            //     var product2 = new Product{
            //         Description = "High quality screen",
            //         CategoryId = 2,
            //         Name = "Toshiba Screen",
            //         pictureLocationName = "ToshibaScreen.jpg",
            //         PicturePath = Path.Combine(env.WebRootPath, "Uploads", "ProductPictures", "ToshibaScreen.jpg"),
            //         Price = 249.99M,
            //         Quantity = 20,
            //     };
            //     productsToSeed.Add(product2);

            //     var product3 = new Product{
            //         Description = "Collection of jel pens",
            //         CategoryId = 2,
            //         Name = "PensGel",
            //         pictureLocationName = "PensGel.jpg",
            //         PicturePath = Path.Combine(env.WebRootPath, "Uploads", "ProductPictures", "PensGel.jpg"),
            //         Price = 18.99M,
            //         Quantity = 10,
            //     };
            //     productsToSeed.Add(product3);

            //     var product4 = new Product{
            //         Description = "15.6 HD LED-Backlit Display, Intel Pentium Silver N5030 Processor, 16GB DDR4 RAM, 1TB Hard Disk Drive, Online Meeting Ready, Webcam, WiFi, Win10 Home, Black",
            //         Name = "2021 Newest Dell Inspiron 3000 Laptop",
            //         CategoryId = 2,
            //         pictureLocationName = "81zuU5gsJ4L._AC_SL1500_.jpg",
            //         PicturePath = Path.Combine(env.WebRootPath, "Uploads", "ProductPictures", "81zuU5gsJ4L._AC_SL1500_.jpg"),
            //         Price = 538.00M,
            //         Quantity = 13,
            //     };
            //     productsToSeed.Add(product4);

            //      var product5 = new Product{
            //         Description = "'14.0' FHD Display, AMD Ryzen 5 5500U, 8GB RAM, 256GB Storage, AMD Radeon 7 Graphics, Windows 11 Home, Abyss Blue",
            //         Name = "Lenovo IdeaPad 3 Laptop",
            //         CategoryId = 2,
            //         pictureLocationName = "71eLIuDmIgL._AC_SL1500_.jpg",
            //         PicturePath = Path.Combine(env.WebRootPath, "Uploads", "ProductPictures", "71eLIuDmIgL._AC_SL1500_.jpg"),
            //         Price = 429.99M,
            //         Quantity = 14,
            //     };
            //     productsToSeed.Add(product5);

            //     var product6 = new Product{
            //         Description = "Pink/Purple",
            //         CategoryId = 2,
            //         Name = "Storm Tropical Surge",
            //         pictureLocationName = "61E8CPzQRJL._AC_SL1025_.jpg",
            //         PicturePath = Path.Combine(env.WebRootPath, "Uploads", "ProductPictures", "61E8CPzQRJL._AC_SL1025_.jpg"),
            //         Price = 90M,
            //         Quantity = 14,
            //     };
            //     productsToSeed.Add(product6);

            //     var product7 = new Product{
            //         Description = "U.S. POLO ASSN. | Show 1fx New Season Gray Color Men's Sneaker Sports Shoes - TYC00179093987_d8_t",
            //         Name = "U.S. POLO ASSN.",
            //         CategoryId = 2,
            //         pictureLocationName = "0_org_zoom__46484.1624513489.jpg",
            //         PicturePath = Path.Combine(env.WebRootPath, "Uploads", "ProductPictures", "0_org_zoom__46484.1624513489.jpg"),
            //         Price = 804M,
            //         Quantity = 23,
            //     };
            //     productsToSeed.Add(product7);

            //     var product8 = new Product{
            //         Description = "U.S. POLO ASSN. | Asta Hi 1pr Black Men's Sneaker Hi - ASTA HI 1PR_84_t",
            //         Name = "U.S. POLO ASSN.",
            //         CategoryId = 2,
            //         pictureLocationName = "1_org_zoom__94497.1633753985.jpg",
            //         PicturePath = Path.Combine(env.WebRootPath, "Uploads", "ProductPictures", "1_org_zoom__94497.1633753985.jpg"),
            //         Price = 809M,
            //         Quantity = 25,
            //     };
            //     productsToSeed.Add(product8);

            //     var product9 = new Product{
            //         Description = "7 Kg, Black GVS107DC3B-ELA",
            //         Name = "CANDY Washing Machine Fully Automatic",
            //         CategoryId = 2,
            //         pictureLocationName = "candy-washing-machine-fully-automatic-7-kg-gvs107dc3b-ela-zoom.jpg",
            //         PicturePath = Path.Combine(env.WebRootPath, "Uploads", "ProductPictures", "candy-washing-machine-fully-automatic-7-kg-gvs107dc3b-ela-zoom.jpg"),
            //         Price = 7.149M,
            //         Quantity = 32,
            //     };
            //     productsToSeed.Add(product9);

            //     var product10 = new Product{
            //         Description = "Advanced No Frost 650 Liter, Champagne SJ-FSD910N-CH",
            //         Name = "SHARP Refrigerator Inverter Digital",
            //         CategoryId = 2,
            //         pictureLocationName = "sharp-refrigerator-inverter-advanced-no-frost-650l-5-doors-champagne-sj-fsd910n-ch.jpg",
            //         PicturePath = Path.Combine(env.WebRootPath, "Uploads", "ProductPictures", "sharp-refrigerator-inverter-advanced-no-frost-650l-5-doors-champagne-sj-fsd910n-ch.jpg"),
            //         Price = 65.999M,
            //         Quantity = 10,
            //     };
            //     productsToSeed.Add(product10);

            //     foreach(var product in productsToSeed)
            //     {
            //         context.Products.Add(product);
            //     }

            //     context.SaveChanges();

            // }
            */
        }
    }
}