using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgAdministration
{
	public class PresenterEmployeeEditor
	{

		public ObservableCollection<Department> Deps { get => deps; set => deps = value; }
		ObservableCollection<Department> deps;


		private Employee employee;
		public Employee SelectedEmployee
		{
			get
			{
				if (employee == null)
				{
					employee = new Employee();
					Model.Employees.Add(employee);
					return employee;
				}
				return employee;
			}
			set => employee = value;
		}


		public PresenterEmployeeEditor()
		{
			deps = Model.Deps;
		}

		public string FullInfo => SelectedEmployee.FullInfo;

		public string Name
		{
			get => SelectedEmployee.Name;
			set => SelectedEmployee.Name = value;
		}

		public int Age
		{
			get => SelectedEmployee.Age;
			set => SelectedEmployee.Age = value;
		}

		public string Position
		{
			get => SelectedEmployee.Position;
			set => SelectedEmployee.Position = value;
		}
		public int Grade
		{
			get => SelectedEmployee.Grade;
			set => SelectedEmployee.Grade = value;
		}
		public int Salary
		{
			get => SelectedEmployee.Salary;
			set => SelectedEmployee.Salary = value;
		}

		public Department Dep
		{
			get => SelectedEmployee.Dep;
			set => SelectedEmployee.Dep = value;
		}

	}
}
