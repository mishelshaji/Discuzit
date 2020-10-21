namespace Discuzit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAdminAndRole : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd30c0d1e-97c5-4df3-b947-c945ba302bd7', N'IsAdmin')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e174554c-5eeb-436d-946e-3fe339bb0d07', N'mishelvettukattil@outlook.com', 0, N'ACrzh5DdQ6qkvMSvC/opP2pyv3357vDsSPlaxK1gnv5NZYHAaJ+ERCWWI9ED3TyjIA==', N'91eda48d-2fa6-4278-ab0c-719c1c1a025e', NULL, 0, 0, NULL, 1, 0, N'mishel')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e174554c-5eeb-436d-946e-3fe339bb0d07', N'd30c0d1e-97c5-4df3-b947-c945ba302bd7')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
