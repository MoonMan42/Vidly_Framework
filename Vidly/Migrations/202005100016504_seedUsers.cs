namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'283dbf23-b4a8-4be4-8962-4f464f0a2827', N'guest@vidly.com', 0, N'ANLEzc9wvITjw4CV99qKu8AbVcd8DHFKLONcRugjgMXZUYd1s3Wg4hp5oVtvbsC8Cg==', N'1c1eff2e-86dc-4c4c-ac1e-1d99c7795b12', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4d540749-3a72-40c3-a60f-ff6b267339f5', N'admin@vidly.com', 0, N'AGgDTfzfS5LkGNxbP1HVpDMlCr2MmqcpGlOYLr9x1QCyuaJeNqTPlDL5QTK/WRD9ew==', N'083a0afa-96a9-429e-b1fc-7cccb0a57b3c', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
               
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'efc4e561-303e-48bd-9f76-ccb151097d9d', N'CanManageMovies')
              
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4d540749-3a72-40c3-a60f-ff6b267339f5', N'efc4e561-303e-48bd-9f76-ccb151097d9d')

    ");

        }
        
        public override void Down()
        {
        }
    }
}
