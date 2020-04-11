using EntityFramework.Domain.Entities;
using EntityFramework.Domain.Enums;
using EntityFramework.Infra.CrossCutting.Logging;
using EntityFramework.Infra.Data3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

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
            optionsBuilder.UseMySql("Server=localhost;userid=newuser2;password=@1234567;database=EntityDB",
                m => m.MigrationsAssembly("EntityFramework.Data3")
                .MaxBatchSize(100));

            try
            {
                using (var dbContext = new EntityContext(optionsBuilder.Options))
                {
                    dbContext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    //dbContext.Users.AddRange(users);

                    var userJoao = CreateUser("userJoao");
                    Console.WriteLine("Check using ChangeTracker of user0");
                    dbContext.Users.Add(userJoao);
                    dbContext.SaveChanges();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static void WatchChangeTracker (ChangeTracker changeTracker)
        {
            foreach (var entry in changeTracker.Entries())
            {
                Console.WriteLine("Instance name: " + entry.Entity.GetType().FullName);
                Console.WriteLine("Instance State: " + entry.State);
                Console.WriteLine("-----------------------");
            }
            Console.WriteLine("");
        }

    }
}

