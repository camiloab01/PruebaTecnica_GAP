namespace SuperZapatos_API.Migrations
{
    using SuperZapatos_API.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperZapatos_API.Models.SuperZapatos_APIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SuperZapatos_API.Models.SuperZapatos_APIContext context)
        {
            context.Stores.AddOrUpdate(x => x.Id,
                new Store() { Id = 1, Name = "Super Zapatos San Pedro", Address = "San Pedro" },
                new Store() { Id = 2, Name = "Super Zapatos Desamparados", Address = "Desamparados" },
                new Store() { Id = 3, Name = "Super Zapatos Curridabat", Address = "Curridabat" }
            );

            context.Articles.AddOrUpdate(x => x.Id,
                new Article()
                {
                    Id = 1,
                    Name = "Zapatos de hombre negros",
                    Description = "Zapatos de hombre negros",
                    Price = 20000,
                    Total_in_shelf = 5,
                    Total_in_vault = 5,
                    StoreId = 1
                },
                new Article()
                {
                    Id = 2,
                    Name = "Zapatos de hombre blancos",
                    Description = "Zapatos de hombre blancos",
                    Price = 25000,
                    Total_in_shelf = 2,
                    Total_in_vault = 3,
                    StoreId = 1
                },
                new Article()
                {
                    Id = 3,
                    Name = "Zapatos de mujer negros",
                    Description = "Zapatos de mujer negros",
                    Price = 15000,
                    Total_in_shelf = 3,
                    Total_in_vault = 1,
                    StoreId = 1
                },
                new Article()
                {
                    Id = 4,
                    Name = "Zapatos de niño escuela",
                    Description = "Zapatos de niño escuela",
                    Price = 10000,
                    Total_in_shelf = 1,
                    Total_in_vault = 5,
                    StoreId = 2
                },
                new Article()
                {
                    Id = 5,
                    Name = "Zapatos de niña escuela",
                    Description = "Zapatos de niña escuela",
                    Price = 10000,
                    Total_in_shelf = 5,
                    Total_in_vault = 5,
                    StoreId = 2
                },
                new Article()
                {
                    Id = 6,
                    Name = "Zapatos deportivos azules",
                    Description = "Zapatos de deportivos azules",
                    Price = 30000,
                    Total_in_shelf = 3,
                    Total_in_vault = 15,
                    StoreId = 3
                },
                new Article()
                {
                    Id = 7,
                    Name = "Tacones negros",
                    Description = "Tacones negros",
                    Price = 25000,
                    Total_in_shelf = 5,
                    Total_in_vault = 5,
                    StoreId = 3
                },
                new Article()
                {
                    Id = 8,
                    Name = "Tacos de futbol",
                    Description = "Tacos de futbol",
                    Price = 27000,
                    Total_in_shelf = 2,
                    Total_in_vault = 2,
                    StoreId = 3
                },
                new Article()
                {
                    Id = 9,
                    Name = "Sandalias de playa",
                    Description = "Sandalias de playa",
                    Price = 5000,
                    Total_in_shelf = 1,
                    Total_in_vault = 2,
                    StoreId = 3
                }
            );
        }
    }
}
