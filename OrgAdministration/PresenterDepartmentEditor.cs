using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgAdministration
{
	class PresenterDepartmentEditor
	{
		ObservableCollection<Department> deps;
		public string NewDepName { get; set; }

		public ObservableCollection<Department> Deps { get => deps; set => deps = value; }

		public PresenterDepartmentEditor()
		{
			deps = Model.Deps;
		}
		public void AddNewDep(string newName)
		{
			if ("".Equals(newName) || Department.GetDepByName(newName) != null) return;
			Deps.Add(new Department(newName));

		}
	}
}
