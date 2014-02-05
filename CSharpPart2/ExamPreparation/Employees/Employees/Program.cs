using System;
using System.Collections.Generic;
using System.Linq;
class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Rank { get; set; }
    public string Position { get; set; }

    public Employee(string firstName, string lastName, int rank)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Rank = rank;
    }
}
class Program
{
    static void Main()
    {
        Dictionary<string, int> posAndRank = new Dictionary<string, int>();
        
        int positions = int.Parse(Console.ReadLine());

        for (int i = 0; i < positions; i++)
        {
            string[] input = Console.ReadLine().Split(new char[]{'-'}, StringSplitOptions.RemoveEmptyEntries);

            if(!posAndRank.ContainsKey(input[0].Trim()))
            {
                posAndRank.Add(input[0].Trim(), int.Parse(input[1].Trim()));
            }
            
        }

        int employeesCount = int.Parse(Console.ReadLine());

        List<Employee> employees = new List<Employee>();

        for (int i = 0; i < employeesCount; i++)
        {
            string[] job = Console.ReadLine().Split(new char[]{'-'},StringSplitOptions.RemoveEmptyEntries);
            string[] name = job[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            
            employees.Add(new Employee(name[0], name[1], posAndRank[job[1].Trim()]));
            
        }

        var sortedEmployees = employees
            .OrderByDescending(em => em.Rank)
            .ThenBy(em => em.LastName)
            .ThenBy(em => em.FirstName);

        foreach (var employee in sortedEmployees)
        {
            Console.WriteLine("{0} {1}",employee.FirstName, employee.LastName);
        }
    }
}

