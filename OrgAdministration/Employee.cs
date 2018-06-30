using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgAdministration
{
	public class Employee : Person
	{
		public int Salary { get; set; }
		public int Grade { get; set; }
		public String Position { get; set; }
		public Department Dep { get; set; }
		public Department jopa;

		public Employee(int salary, int grade, String position, int age, String name, DepName depName) : base(age, name)
		{
			Salary = salary;
			Grade = grade;
			Position = position;
			Dep = Department.GetDepByName(depName);
			Dep.EmployeeList.Add(this);
		}

		public static List<Employee> SetTestData()
		{
			List<Employee> l = new List<Employee>
			{
				new Employee(30000, 1, "Janitor", 36, "Jan Itor", DepName.Cleaning),
				new Employee(40000, 2, "Middle Janitor", 42, "Kevin", DepName.Cleaning),
				new Employee(60000, 3, "Developer", 23, "Pasha", DepName.IT),
				new Employee(100000, 5, "Team Lead", 36, "Alexey", DepName.IT),
				new Employee(80000, 4, "DevOps", 28, "Misha", DepName.IT),
				new Employee(70000, 4, "HR Generalist", 29, "Katerina", DepName.HR),
				new Employee(120000, 6, "Project Manager", 40, "Sergey Sergeich", DepName.Managers)
			};

			return l;
		}

		public override string ToString()
		{
			return $"Сотрудник: {name} Дрожность: {Position} Зарплата: {Salary} Grade: {Grade} Департамент: {Dep.name}";
		}
	}
}
