using Microsoft.EntityFrameworkCore;
using Ordering.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
              new Order()
              {
                  Id = 1,
                  UserName = "mmraihan99@gmail.com",
                  FirstName = "Mubasshir",
                  LastName = "Raihan",
                  EmailAddress = "mmraihan99@gmail.com",
                  Address = "Chattogram",
                  TotalPrice = 100,
                  City = "Chattogram"
                  //CVV = "Test",
                  //CardName = "Test",
                  //CardNumber = "Test",
                  //Expiraton = "Test",
                  //PaymentMethod = 1,
                  //CreatedBy = "Test",
                  //CreatedDate = DateTime.Now,
                  //PhoneNumber = "0160000000",
                  //State = "Test",
                  //ZipCode = "Test"
              }
             );

        }
    }
}
