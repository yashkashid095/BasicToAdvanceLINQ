using FundamentalLINQ_APP.Models;

namespace FundamentalLINQ_APP.Contracts
{
    public interface IExecuteQuery
    {
        IEnumerable<int> GetEvenNumbersDeffered(List<int> numbers);

        IEnumerable<int> GetEvenNumbersImmediate(List<int> numbers);

        int GetFirstOddNumber(IEnumerable<int> numbers);

        int GetFirstEvenNumber(IEnumerable<int> numbers);

        bool AnyNumberGreaterThan(IEnumerable<int> numbers, int threshold);

        IEnumerable<IGrouping<string, Employee>> GetEmpInEachDept(IEnumerable<Employee> employees);

        IEnumerable<Employee> GetHighestPaidEmpInEachDept(IEnumerable<Employee> employees);
    }
}
