using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DotNetPOC.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO USERS 
                        (Name, Login, Password, email) VALUES 
                        ('User 1', 'user1', '1234@qwer', 'user1@gmail.com')");
            migrationBuilder.Sql(@"INSERT INTO USERS 
                        (Name, Login, Password, email) VALUES 
                        ('User 2', 'user2', '1234@qwer', 'user2@gmail.com')");
            migrationBuilder.Sql(@"INSERT INTO USERS 
                        (Name, Login, Password, email) VALUES 
                        ('User 3', 'user3', '1234@qwer', 'user3@gmail.com')");
            migrationBuilder.Sql(@"INSERT INTO USERS 
                        (Name, Login, Password, email) VALUES 
                        ('User 4', 'user4', '1234@qwer', 'user4@gmail.com')");
            migrationBuilder.Sql(@"INSERT INTO USERS 
                        (Name, Login, Password, email) VALUES 
                        ('User 5', 'user5', '1234@qwer', 'user5@gmail.com')");
            migrationBuilder.Sql(@"INSERT INTO USERS 
                        (Name, Login, Password, email) VALUES 
                        ('User 6', 'user6', '1234@qwer', 'user6@gmail.com')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Users");
        }
    }
}
