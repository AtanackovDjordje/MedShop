using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public static class DbInitializer
    {

        public static async Task Initialize(DataContext context, UserManager<User> userManager)
        {

            if(!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "djordje",
                    Email = "djordje@test.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");

                 var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] {"Member", "Admin"});
            }
            

            if(context.Products == null) return;
            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Bagremov med",
                    Description="Privremeni opis",
                    Price = 1500,
                    PictureUrl="/images/medtegla.jpg",
                    Type="med",
                    QuantityInStock= 1000
                },
                new Product
                {
                    Name = "Bagremov med",
                    Description="bagremov med tegla",
                    Price = 900,
                    PictureUrl="/images/medtegla2.jpg",
                    Type="med",
                    QuantityInStock= 1000
                },
                new Product
                {
                    Name = "Livadski med",
                    Description="opis livadskog meda",
                    Price = 1200,
                    PictureUrl="/images/medTegla3.jpg",
                    Type="med",
                    QuantityInStock= 1000
                },
                new Product
                {
                    Name = "Livadski Med",
                    Description="livadski med tegla",
                    Price = 700,
                    PictureUrl="/images/medTegla3.jpg",
                    Type="med",
                    QuantityInStock= 1000
                },
                new Product
                {
                    Name = "Polen",
                    Description="polen opis",
                    Price = 12,
                    PictureUrl="/images/polen1.jpg",
                    Type="",
                    QuantityInStock= 1000
                },
                new Product
                {
                    Name = "Polen",
                    Description="opis polen",
                    Price = 1500,
                    PictureUrl="/images/polen2.jpg",
                    Type="polen",
                    QuantityInStock= 1000
                },
                new Product
                {
                    Name = "Polen",
                    Description="polen12",
                    Price = 2200,
                    PictureUrl="/images/polen2.jpg",
                    Type="polen",
                    QuantityInStock= 1000
                },

            };

            foreach(var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();

        }
    }
}