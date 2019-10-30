using FriendOrganize.Model;

namespace FriendOrganize.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FriendOrganize.DataAccess.FriendOrganizeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FriendOrganize.DataAccess.FriendOrganizeDbContext context)
        {
            //context.Friends.AddOrUpdate(f => f.FirstName == "Chutipong",
            //    new Friend() {FirstName = "Rob", LastName = "Chuti", Email = "RobChu@gmail.com"},
            //    new Friend() {FirstName = "Rob1", LastName = "Chuti", Email = "RobChu@gmail.com"},
            //    new Friend() {FirstName = "Rob2", LastName = "Chuti", Email = "RobChu@gmail.com"},
            //    new Friend() {FirstName = "Rob3", LastName = "Chuti", Email = "RobChu@gmail.com"},
            //    new Friend() {FirstName = "Rob4", LastName = "Chuti", Email = "RobChu@gmail.com"}
            //);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}