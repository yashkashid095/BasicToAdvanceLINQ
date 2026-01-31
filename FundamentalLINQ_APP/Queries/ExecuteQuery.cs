using FundamentalLINQ_APP.Contracts;
using FundamentalLINQ_APP.Models;
namespace FundamentalLINQ_APP.Queries
{
    public class ExecuteQuery: IExecuteQuery
    {
        public IEnumerable<int> GetEvenNumbersDeffered(List<int> numbers)
        {
            //Executes later when it is enumerated and does not freeze the data and it is not executed now executed when enumerated.           
            var getEvenNumbers = numbers.Where(x => x % 2 == 0).Select(x => x-1);
            numbers.Add(12);
            return getEvenNumbers;
        }

        public IEnumerable<int> GetEvenNumbersImmediate(List<int> numbers)
        {
            //Executes immediately and Freeze the data  here  //Materialize = execute a deferred query and produce a concrete in-memory collection or value.
            var getEvenNumbers = numbers.Where(x => x % 2 == 0).Select(x => x - 1).ToList();
            numbers.Add(12);
            return getEvenNumbers;
        }

        public int GetFirstOddNumber(IEnumerable<int> numbers)
        {
            var getFirstOddNumber = numbers.Where(x => x % 2 != 0).FirstOrDefault();
            return getFirstOddNumber;
        }

        public int GetFirstEvenNumber(IEnumerable<int> numbers)
        {
            var getFirstEvenNumber = numbers.Where(x => x % 2 == 0).FirstOrDefault();
            return getFirstEvenNumber;
        }

        public bool AnyNumberGreaterThan(IEnumerable<int> numbers, int threshold)
        {
            var result = numbers.Any(x => x > threshold);
            if (result )
                return true;
            return false;
        }

        public IEnumerable<string> GetAllEmplyeeNames(IEnumerable<Employee> employees)
        {
            return employees.Select(x => x.Name);
        }

       public IEnumerable<IGrouping<string, Employee>> GetEmpInEachDept(IEnumerable<Employee> employees)
        {
            var getEmpInEachDept = employees.GroupBy(dept => dept.Department);
            return getEmpInEachDept;
        }

        public IEnumerable< Employee> GetHighestPaidEmpInEachDept(IEnumerable<Employee> employees)
        {
            var getHighestPaidEmpInEachDept = employees.GroupBy(x => x.Department)
                .Select(x => x.OrderByDescending(s => s.Salary).First())
                .ToList();
            return getHighestPaidEmpInEachDept;
        }
    }
}


/*
Key rule: LINQ is immutable (original list never changes)

| LINQ Method | Returns | Execution |
| ----------------------- | ---------------- | --------- |
| `Where`, `Select`       | `IEnumerable<T>` | Deferred  |
| `OrderBy`, `GroupBy`    | `IEnumerable<T>` | Deferred  |
| `ToList()`, `ToArray()` | List / Array     | Immediate |
| `Count()`, `First()`    | int / T          | Immediate |

*/

/*

###LINQ queries do not always execute immediately.
There are two types of execution:

-Deferred Execution

-Immediate Execution
 
####Deferred Execution
The query is not executed when you define it.
It is only executed when you enumerate it LINQ methods that return IEnumerable<T> are deferred, e.g.:


-Where()

-Select()

-OrderBy()

-GroupBy()

-SelectMany()

The query was deferred — it didn’t ‘freeze’ the data.”

Example:
var numbers = new List<int> { 1, 2, 3, 4, 5 };

If a query froze the data, it would mean:

Whatever numbers exist right now are what the query uses

Any future changes to the list would not affect the query

For example, if it “froze”:

var evenNumbers = numbers.Where(n => n % 2 == 0); 
numbers.Add(6);

If “frozen” → query only sees 1,2,3,4,5

6 would not appear

Deferred execution does NOT freeze the data.

LINQ just remembers the logic: “Give me all numbers divisible by 2.”

The actual numbers are not picked yet

When you enumerate (foreach, .ToList(), etc.), it fetches the current numbers

var numbers = new List<int> { 1, 2, 3, 4, 5 };

var evenNumbers = numbers.Where(n => n % 2 == 0); // DEFERRED, not executed

numbers.Add(6); // Add new number after query created

foreach (var n in evenNumbers)
{
    Console.WriteLine(n); // Execution happens here
}


Output:

2
4
6

Notice how 6 is included? That’s because the query was deferred — it evaluated after the data changed.

If LINQ “froze the data”, 6 would never appear.

###Immediate Execution
The query is executed right when you call it, producing a concrete result (List, Array, int, etc.)

| Method                           | Returns / Behavior                 |
| -------------------------------- | ---------------------------------- |
| `ToList()`                       | Materializes IEnumerable → List    |
| `ToArray()`                      | Materializes IEnumerable → Array   |
| `Count()`                        | Counts items immediately           |
| `First() / FirstOrDefault()`     | Returns the first item immediately |
| `Any()`                          | Checks existence immediately       |
| `Sum(), Max(), Min(), Average()` | Executes immediately               |



Rule of Thumb:

Use deferred execution to save memory / improve performance if you don’t need immediate results.

Use immediate execution when you need stable results or multiple enumerations.

Before materialize → query is lazy, not executed

After materialize → results are stored in memory, independent of source

 */