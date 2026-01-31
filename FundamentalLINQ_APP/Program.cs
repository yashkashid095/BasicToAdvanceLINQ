using FundamentalLINQ_APP.Contracts;
using FundamentalLINQ_APP.Data;
using FundamentalLINQ_APP.Queries;

Console.WriteLine("LINQ In Action");

IExecuteQuery executeQuery = new ExecuteQuery();

var evenNumbersDeffered = executeQuery.GetEvenNumbersDeffered(FetchData.Numbers);

var evenNumbersImmediate = executeQuery.GetEvenNumbersImmediate(FetchData.Numbers);

var getFirstOddNumber = executeQuery.GetFirstOddNumber(FetchData.Numbers);

var getFirstEvenNumber = executeQuery.GetFirstEvenNumber(FetchData.Numbers);

var anyNumberGreaterThanThreshold = executeQuery.AnyNumberGreaterThan(FetchData.Numbers, 100);

var getEmpInEachDept = executeQuery.GetEmpInEachDept(FetchData.GetEmployees);

var getHighestPaidEmpInEachDept = executeQuery.GetHighestPaidEmpInEachDept(FetchData.GetEmployees);

Console.WriteLine("Even Numbers Deffered:");
foreach (var n in evenNumbersDeffered)
{
    Console.WriteLine(n);
}

Console.WriteLine("Even Numbers Immediate:");
foreach (var n in evenNumbersImmediate)
{
    Console.WriteLine(n);
}

Console.WriteLine("Get first odd number: "+ getFirstOddNumber);

Console.WriteLine("Get first odd number: " + getFirstEvenNumber);

Console.WriteLine("Numbers Greater than 5 if yes True or False:"+anyNumberGreaterThanThreshold);

Console.WriteLine("Group By dept");
foreach(var group in getEmpInEachDept)
{
    Console.WriteLine(group.Key);
    foreach(var emp in group)
    {
        Console.WriteLine(emp);
    }
    

}

Console.WriteLine("Maximum salaried EMP in each Dept");
foreach(var emp in getHighestPaidEmpInEachDept)
{
    Console.WriteLine(emp);
}
Console.ReadLine();