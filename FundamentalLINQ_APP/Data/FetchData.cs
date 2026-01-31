using FundamentalLINQ_APP.Models;
namespace FundamentalLINQ_APP.Data
{
    public static class FetchData
    {
     
        public static List<Employee> GetEmployees =>
              new List<Employee>
            {
                new () { Id = 1, Name = "Alice", Age = 30, Department = "HR", Salary = 60000 },
                new () { Id = 2, Name = "Bob", Age = 25, Department = "IT", Salary = 75000 },
                new () { Id = 3, Name = "Charlie", Age = 28, Department = "Finance", Salary = 70000 },
                new () { Id = 4, Name = "David", Age = 35, Department = "IT", Salary = 80000 },
                new () { Id = 5, Name = "Eve", Age = 32, Department = "HR", Salary = 65000 },
            };
        public static List<int> Numbers => 
            new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10  };
        public static List<string> Words =>
            new List<string> { "apple", "banana", "cherry", "date", "fig", "grape" };


    }
}
