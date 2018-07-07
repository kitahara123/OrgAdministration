using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OrgAdministration
{
	class BackEnd // Я кучу времени потратил пытаясь натянуть сюда MVP, но так и не понял как это правильно сделать
	{
		List<Department> departments;
		List<Employee> employees;
		IView form;
		public BackEnd(IView form)
		{
			this.form = form;

		}

		public void LoadData()
		{
			if(form is EmployeeEditor)
			{
				departments = Department.Deps.Values.ToList();
				departments.ForEach(e => form.Data.Add(e));
				
			}
			if (form is MainWindow)
			{
				employees = Employee.SetTestData();
				employees.ForEach(e => form.Data.Add(e));
			}

		}
	}
}
