using EntityFramework.Domain.Entities;
using EntityFramework.Domain.Enums;
using EntityFramework.Infra.CrossCutting.Logging;
using EntityFramework.Infra.Data3;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;

namespace EntityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                Name = "Usuario2",
                LastName = "Sobrenome",
                Email = "teste@teste.com",
                DateBirth = DateTime.Now,
                Sex = SexEnum.Male,
                Password = "1234",
                UrlPhoto= "C\\:teste"
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
                    dbContext.Users.Add(user);
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
