namespace Repository.Migrations
{
    using Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Repository.WeedShopDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Repository.WeedShopDBContext";
        }

        DBManager dBManage = new DBManager();

        protected override void Seed(Repository.WeedShopDBContext context)
        {
            var user = new User
            {
                UserId = 1,
                FirstName = "Gal",
                LastName = "Gur",
                UserName = "GalGur",
                Password = "123",
                DateOfBirth = new DateTime(1989, 10, 8),
                Email = "Gal.Gur@email.com"
            };

            context.Users.AddOrUpdate(user);

            context.WeedProducts.AddOrUpdate(new Weed
            {
                WeedId = 1,
                User = user,
                Title = "Lemon Haze",
                Description = "A hazy high with a lemony scent",
                WeedKind = WeedKind.LemonHaze,
                WeedType = WeedType.Indica,
                PriceForOunce = 10,
                PublishDate = DateTime.Today
            });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
