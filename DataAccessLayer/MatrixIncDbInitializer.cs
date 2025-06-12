using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace DataAccessLayer
{
    public static class MatrixIncDbInitializer
    {
        public static void Initialize(MatrixIncDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            // TODO: Hier moet ik nog wat namen verzinnen die betrekking hebben op de matrix.
            // - Denk aan de m3 boutjes, moertjes en ringetjes.
            // - Denk aan namen van schepen
            // - Denk aan namen van vliegtuigen            
            var customers = new Customer[]
            {
                new Customer { Name = "Neo", Address = "123 Elm St" , Active=true},
                new Customer { Name = "Morpheus", Address = "456 Oak St", Active = true },
                new Customer { Name = "Trinity", Address = "789 Pine St", Active = true }
            };
            context.Customers.AddRange(customers);

            var orders = new Order[]
            {
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-01-01")},
                new Order { Customer = customers[0], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[1], OrderDate = DateTime.Parse("2021-02-01")},
                new Order { Customer = customers[2], OrderDate = DateTime.Parse("2021-03-01")}
            };  
            context.Orders.AddRange(orders);

            var products = new Product[]
            {
                new Product { Name = "Nebuchadnezzar", Description = "The ship on which Neo first learns about the real world.", Price = 10000.00m, Image = "https://www.masterreplicas.com/cdn/shop/files/NS2iCrop4Shop.jpg?v=1741783820&width=533", Visible = true },
                new Product { Name = "Jack-in Chair", Description = "Chair used to connect humans to the Matrix through a neck port.", Price = 500.50m, Image = "https://dyn1.heritagestatic.com/lf?set=path%5B2%2F3%2F9%2F4%2F0%2F23940467%5D&call=url%5Bfile%3Aproduct.chain%5D", Visible = true },
                new Product { Name = "EMP Device", Description = "Electro-Magnetic Pulse device used to disable Sentinels.", Price = 129.99m, Image = "https://pbs.twimg.com/media/FRhACAvX0AA0oPw.png", Visible = true },
                new Product { Name = "Red Pill", Description = "Symbolic pill Neo takes to escape the Matrix.", Price = 9.99m, Image = "https://atlas-content-cdn.pixelsquid.com/stock-images/red-pill-z0nyO48-600.jpg", Visible = true },
                new Product { Name = "Sentinel Drone", Description = "Machine designed to hunt and destroy humans outside the Matrix.", Price = 2000.00m, Image = "https://i.ytimg.com/vi/a4CpkdmsvHg/sddefault.jpg", Visible = true },
                new Product { Name = "Matrix Code Poster", Description = "Poster showing the iconic falling green code from the Matrix.", Price = 19.95m, Image = "https://i.etsystatic.com/31553834/r/il/2af60f/6308303214/il_570xN.6308303214_ai3x.jpg", Visible = true },
                new Product { Name = "Trench Coat", Description = "Long black coat worn by Neo inside the Matrix.", Price = 89.90m, Image = "https://m.media-amazon.com/images/I/31zmgvuci8L._AC_.jpg", Visible = true },
                new Product { Name = "Operator Headset", Description = "Headset used by operators to communicate with agents and rebels.", Price = 49.99m, Image = "https://nl.hama.com/bilder/00139/abx/00139938abx.webp", Visible = true },
                new Product { Name = "Training Program Disc", Description = "Virtual training program uploaded directly into the brain.", Price = 29.99m, Image = "https://cdn.tc.promotron.com/web-images/79078a38-cb2d-47ad-a4a3-392033e050f5", Visible = true },
                new Product { Name = "Dual Pistols", Description = "Guns used by Neo during the rescue mission.", Price = 2009.00m, Image = "https://blogmedia.wideners.com/blog/wp-content/uploads/WRS-Blog-Matrix-Guns-Template-Model-61-Skorpion.jpg", Visible = true }
            };
            context.Products.AddRange(products);


            var parts = new Part[]
{
            new Part { Name = "Tandwiel", Description = "Overdracht van rotatie in bijvoorbeeld de motor of luikmechanismen", Stock = 12, BuyInPrice = 15.50m, Image = "default.jpg" },
            new Part { Name = "M5 Boutje", Description = "Bevestiging van panelen, buizen of interne modules", Stock = 250, BuyInPrice = 0.05m, Image = "default.jpg" },
            new Part { Name = "Hydraulische cilinder", Description = "Openen/sluiten van zware luchtsluizen of bewegende onderdelen", Stock = 5, BuyInPrice = 89.90m, Image = "default.jpg" },
            new Part { Name = "Koelvloeistofpomp", Description = "Koeling van de motor of elektronische systemen.", Stock = 7, BuyInPrice = 49.95m, Image = "default.jpg" }
};
;
            context.SaveChanges();



        }
    }
}
