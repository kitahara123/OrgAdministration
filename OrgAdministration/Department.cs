using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgAdministration
{
	
	public class Department
	{
		public bool Changed { get; set; }
		public static Dictionary<int, Department> Deps { get; }
		public string name;
		public HashSet<Employee> EmployeeList { get; set; }
		public int id;

		public string Name { get => name; set { name = value; Changed = true; } }
		public int EmpCount { get => EmployeeList.Count; set { } }

		static Department()
		{
			Deps = new Dictionary<int, Department>();
		}

		public Department(string name)
		{
			this.name = name;
			EmployeeList = new HashSet<Employee>();
			
		}

		public Department(string name, int id) : this(name)
		{
			Changed = false;
			this.id = id;
			Deps.Add(this.id, this);
		}

		public static Department GetDepById(int id)
		{
			return Deps[id];
		}
		public static Department GetDepByName(string name)
		{
			if (Model.Deps.Where(e => name.Equals(e.name)).Count() == 0) return Model.Deps[0];
			return Model.Deps.Where(e => name.Equals(e.name)).First();
		}

		public static ObservableCollection<Department> SetTestData()
		{
			return new ObservableCollection<Department>() { new Department("IT"), new Department("Cleaning"), new Department("Managers"), new Department("HR") };
		}


		public override string ToString()
		{
			return $"Название: {name} Количество сотрудников: {EmpCount}";
		}
	}
}
