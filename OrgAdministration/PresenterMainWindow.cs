using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgAdministration
{
	class PresenterMainWindow
	{
		public ObservableCollection<Employee> Employees { get => employees; set => employees = value; }
		ObservableCollection<Employee> employees;

		public PresenterMainWindow()
		{
			Model.LoadDepartments();
			Model.LoadPeople();
			Employees = Model.Employees;
		}

		internal void SaveData()
		{
			Model.SaveDeps();
			Model.SavePeople();
		}

		internal void deleteEmployee(Employee emp)
		{
			Model.Employees.Remove(emp);
			Model.deletedEmps.Add(emp);
		}

		internal void SetTestData()
		{
			Model.SetTestData();
		}
	}
}
