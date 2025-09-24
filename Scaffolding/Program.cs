using Microsoft.EntityFrameworkCore;
using Scaffolding.Models;

namespace Scaffolding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BikeStores519Context db = new(); 
            //var customers = db.Customers.AsEnumerable(); // Fetch all records from the Customers table this store data in c#
            var customers = db.Customers.AsQueryable(); // Fetch all records from the Customers table but if make any operation like filter or sort it will be done in the database server
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
            var customer = customers.SingleOrDefault(state=>state.CustomerId==1);


            Console.WriteLine($"Id:{customer.CustomerId} city: {customer.City} Name: {customer.FirstName} Email:{customer.Email}");
            
        }
    }
}
