using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OrgAdministration
{
	static class Model
	{
		public static ObservableCollection<Employee> Employees { get; set; }
		public static ObservableCollection<Employee> GetEmployees()
		{
			Employees = Employee.SetTestData();
			return Employees;
		}


		public static ObservableCollection<Department> Deps { get; set; }
		
		public static ObservableCollection<Department> GetDeps()
		{
			if (Deps?.Count > 0) return Deps;
			Deps = new ObservableCollection<Department>();
			Department.Deps.Values.ToList().ForEach(e => Deps.Add(e));
			return Deps;
		}
	}
}
