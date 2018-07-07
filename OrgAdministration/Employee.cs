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
		
		public int Salary { get; set; }
		public int Grade { get; set; }
		public String Position { get; set; }

		private Department dep;

		public event PropertyChangedEventHandler PropertyChanged;

		public Department Dep 
		{
			get { return this.dep; }
			set
			{
				value.EmployeeList.Add(this);
				this.dep = value;	 				
			}
		}	

		public Employee(int salary, int grade, String position, int age, String name, string depName) : base(age, name)
		{
			Salary = salary;
			Grade = grade;
			Position = position;
			Dep = Department.GetDepByName(depName);
		}

		public Employee()
		{

		}

		public static ObservableCollection<Employee> SetTestData()
		{
			ObservableCollection<Employee> l = new ObservableCollection<Employee>
			{
				new Employee(30000, 1, "Janitor", 36, "Jan Itor", "Cleaning"),
				new Employee(40000, 2, "Middle Janitor", 42, "Kevin", "Cleaning"),
				new Employee(60000, 3, "Developer", 23, "Pasha", "IT"),
				new Employee(100000, 5, "Team Lead", 36, "Alexey", "IT"),
				new Employee(80000, 4, "DevOps", 28, "Misha", "IT"),
				new Employee(70000, 4, "HR Generalist", 29, "Katerina", "HR"),
				new Employee(120000, 6, "Project Manager", 40, "Sergey Sergeich", "Managers")
			};

			return l;
		}

		public string FullInfo { get =>this.ToString();
			set
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("FullInfo"));
			}
		}

		public override string ToString()
		{
			return $"Сотрудник: {name} Возраст: {age} Должность: {Position} Зарплата: {Salary} Grade: {Grade} Департамент: {Dep?.name}";
		}
	}
}
