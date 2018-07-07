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
			Employees = Model.GetEmployees();
		}

		
	}
}
