using EntityFramework.Domain.Entities;
using EntityFramework.Domain.Enums;
using EntityFramework.Infra.CrossCutting.Logging;
using EntityFramework.Infra.Data3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace EntityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User CreateUser(string name)
            {
                return new User()
                {
                    Name = name,
                    LastName = "Sobrenome",
                    Email = "teste@teste.com",
                    DateBirth = DateTime.Now,
                    Sex = SexEnum.Male,
                    Password = "1234",
                    UrlPhoto = "C\\:teste"
                };
            }

            User user3 = CreateUser("Usuario3");
            User user4 = CreateUser("Usuario4");
            User user5 = CreateUser("Usuario5");
            User user6 = CreateUser("Usuario6");

            List<User> users = new List<User>()
            {
                user3,
                user4,
                user5,
                user6
            };


            var optionsBuilder = new DbContextOptionsBuilder<EntityContext>();
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySql("Server=localhost;userid=root;password=123456;database=EntityDB",
                m => m.MigrationsAssembly("EntityFramework.Data3"));

            try
            {
                using (var dbContext = new EntityContext(optionsBuilder.Options))
                {
                    dbContext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    dbContext.Users.AddRange(users);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
