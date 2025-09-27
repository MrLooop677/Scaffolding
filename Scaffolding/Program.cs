using Microsoft.EntityFrameworkCore;
using Scaffolding.Models;
using System.Diagnostics.Metrics;

namespace Scaffolding
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region Scaffolding
            //BikeStores519Context db = new(); 
            //var customers = db.Customers.AsEnumerable(); // Fetch all records from the Customers table this store data in c#
            //var customers = db.Customers.AsQueryable(); // Fetch all records from the Customers table but if make any operation like filter or sort it will be done in the database server
            //customers= customers.Where((c)=>c.City=="New York"&&c.FirstName== "Sharie"); // Filter the records where city is New York
            //customers = customers.Where(c => c.Phone == null && c.Email.Contains("acevedo")).OrderBy(c=>c.FirstName).ThenBy(c=>c.LastName).OrderByDescending((c)=>c.CustomerId); 
            //customers = customers.Where(c => c.State == "NY").Skip(0).Take(10).OrderBy(c=>c.CustomerId);
            //foreach (var item in customers)
            //{
            //    Console.WriteLine($"Id:{item.CustomerId} city: {item.City} Name: {item.FirstName} Email:{item.Email}");
            //}
            //customers = customers.Where(c => c.State == "NY").Skip(0).Take(10).OrderBy(c=>c.CustomerId);

            //single record 
            //first is return record or exciption if not found
            //firstDefault is return record or null if not found

            //var customer = customers.First(c => c.State == "NY");
            //var customer = customers.FirstOrDefault(c => c.State == "NY");
            //var customer = customers.OrderBy((c)=>c.CustomerId).LastOrDefault(c => c.State == "NY");

            //if (customer == null)
            //{
            //    Console.WriteLine("No record found");
            //    return;
            //}
            //Find method use primary key to find the record and dont use AsQueryable or AsEnumerable with this method
            //var customer = db.Customers.Find(1);
            //var customer = customers.SingleOrDefault(state=>state.CustomerId==1);

            //Console.WriteLine($"Id:{customer.CustomerId} city: {customer.City} Name: {customer.FirstName} Email:{customer.Email}");

            //to select specific columns in table
            //var res =db.Customers.AsEnumerable().Where(state => state.State == "NY").Select((e,count) => new { 
            //  counter=count,  e.FirstName, e.LastName,e.CustomerId,e.State,e.City,e.Email,e.ZipCode
            //});
            //if(!res.Any())
            //{
            //    Console.WriteLine("No record found");
            //    return; 
            //}
            //foreach (var item in res)
            //{
            //    Console.WriteLine($" index:{item.counter} Id:{item.CustomerId} city: {item.City} Name: {item.FirstName} Email:{item.Email}");
            //}
            //aggregation function 
            //Console.WriteLine(res.Count());
            //Console.WriteLine("min zip code" + res.Min(e => e.ZipCode));

            //using distinct to get unique records
            //var uniqueStates = db.Customers.Select(e => e.State).Distinct();
            //foreach (var item in uniqueStates)
            //{
            //    Console.WriteLine($" {item}");
            //}

            #endregion

            //Joins
            #region Joins
            //first way
            //BikeStores519Context _db = new();
            // var orderWithCustomer = _db.Orders.Join(
            //     _db.Customers,
            //     o => o.CustomerId,
            //     c => c.CustomerId,
            //     (o, c) => new
            //     {
            //         o.OrderId,
            //         o.OrderDate,
            //         o.OrderStatus,
            //         c.FirstName,
            //         c.LastName,
            //     });

            //foreach (var item in orderWithCustomer)
            //{
            //    Console.WriteLine($"OrderId: {item.OrderId}, Date:{item.OrderDate}, Name:{item.FirstName} {item.LastName}");
            //}

            //second way include method but this return all columns 
            //var orderWithCustomer = _db.Orders.Include(e=>e.Customer);

            //to return specific columns using select method
            //var orderWithCustomer = _db.Orders.Select(e => new{

            //    e.OrderId,
            //    e.OrderDate,
            //    e.OrderStatus,
            //    Customer = new {
            //        e.Customer.FirstName,
            //        e.Customer.LastName
            //    }
            //});

            //foreach (var item in orderWithCustomer)
            //{
            //    Console.WriteLine($"OrderId: {item.OrderId}, Date:{item.OrderDate}, Name:{item.Customer.FirstName} {item.Customer.LastName}");
            //}
            #endregion

            //group by
            #region Group By
          //  BikeStores519Context _db = new();
          //var customerByStates= _db.Customers.GroupBy(e => e.State).Select(e => new{
          //     group= e.Key,
          //     count= e.Count()
          //  });
          //  foreach (var item in customerByStates)
          //  {
          //      Console.WriteLine($"Group Name: {item.group}, Count:{item.count}");
          //  }
            #endregion

            // craete-update-delete
            #region CRUD

            //create
            BikeStores519Context _db = new();
            //_db.Categories.Add(new Category() { 
            //    CategoryName="new category from c#-1",
            //});
            //_db.Categories.Add(new Category()
            //{
            //    CategoryName = "new category from c#-2",
            //});
            //await _db.Categories.AddRangeAsync(
            //new Category { CategoryName = "Category A" },
            //new Category { CategoryName = "Category B" },
            //new Category { CategoryName = "Category C" }
            //);
            //_db.SaveChanges();

            //update (fully update and set column im not update with null )
            //_db.Categories.Update(new Category()
            //{
            //    CategoryId = 12,
            //    CategoryName = "updated category from c#-1",
            //});

            //partial update
            //var customersReadNotForUpdate=_db.Customers.AsNoTracking().FirstOrDefault(c => c.CustomerId == 1);
            //var customer = _db.Customers.FirstOrDefault(c => c.CustomerId == 1);

            //if (customer != null)
            //{
            //    customer.FirstName = "updated first name";
            //    customer.LastName = "updated last name";

            //    _db.SaveChanges(); // أو await _db.SaveChangesAsync();
            //}
            //else  
            //{
            //    Console.WriteLine("Customer with Id = 1 not found.");
            //}

            //delete
            //_db.Categories.Remove(new Category()
            //{
            //    CategoryId = 12
            //});
            //_db.SaveChanges();


            //transaction
            var transaction=_db.Database.BeginTransaction();
            try { 
                //create
                //delte
                //update
                transaction.Commit();
            }catch(Exception ex)
            {
                transaction.Rollback();
            }
            #endregion
        }
    }
} 
