using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgAdministration
{
	public class Employee : Person, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public bool Changed { get; set; }
		public int id;
		private string position;
		private int salary;
		private int grade;
		private Department dep;

		public string Name { get => name; set { name = value; Changed = true; } }
		public int Age { get => age; set { age = value; Changed = true; } }
		public string Position { get => position; set { position = value; Changed = true; } }
		public int Grade { get => grade; set { grade = value; Changed = true; } }
		public int Salary { get => salary; set { salary = value; Changed = true; } }

		public Department Dep
		{
			get => dep;
			set
			{
				value.EmployeeList.Add(this);
				this.dep = value;
				Changed = true;
			}
		}

		public Employee(string name, int age, string position, int grade, int salary, string depName) : base(age, name)
		{
			Salary = salary;
			Grade = grade;
			Position = position;
			Dep = Department.GetDepByName(depName);
		}

		public Employee(int id, string name, int age, string position, int grade, int salary, int depId)
			: this(name, age, position, grade, salary, Department.GetDepById(depId).Name)
		{
			Changed = false;
			this.id = id;
		}

		public Employee()
		{

		}

		public static ObservableCollection<Employee> SetTestData()
		{
			ObservableCollection<Employee> l = new ObservableCollection<Employee>
			{
				new Employee("Jan Itor", 36, "Janitor", 1, 30000, "Cleaning"),
				new Employee("Kevin", 42, "Middle Janitor",  2, 40000, "Cleaning"),
				new Employee("Pasha", 23, "Developer", 3, 60000, "IT"),
				new Employee("Alexey", 36, "Team Lead",  5, 100000, "IT"),
				new Employee("Misha", 28, "DevOps",  4, 80000, "IT"),
				new Employee("Katerina",  29, "HR Generalist", 4, 70000, "HR"),
				new Employee("Sergey Sergeich", 40, "Project Manager",  6, 120000, "Managers")
			};

			return l;
		}

		public string FullInfo
		{
			get => this.ToString();
			set
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FullInfo"));
			}
		}


		public override string ToString()
		{
			return $"Сотрудник: {name} Возраст: {age} Должность: {Position} Grade: {Grade} Зарплата: {Salary} Департамент: {Dep?.name}";
		}
	}
}
