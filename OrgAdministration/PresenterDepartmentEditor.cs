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
			deps = Model.GetDeps();
		}
		public void AddNewDep(string newName)
		{
			if ("".Equals(newName)) return;
			int cntBefore = Department.Deps.Count();
			Department d = Department.GetDepByName(newName);
			int cntAfter = Department.Deps.Count();

			if (cntAfter > cntBefore)
			Deps.Add(d);
		}
	}
}
