using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgAdministration
{
	public class Department
	{
		public static Dictionary<string, Department> Deps { get; }
		public string name;
		public HashSet<Employee> EmployeeList { get; set; }

		public string Name { get => name.ToString(); set { } }
		public int EmpCount { get => EmployeeList.Count; set { } }
		
		static Department()
		{
			Deps = new Dictionary<string, Department>();
		}
		private Department(string name)
		{
			this.name = name;
			EmployeeList = new HashSet<Employee>();
			Deps.Add(name, this);
		}

		public static Department GetDepByName(string name)
		{
			if (null == name || "".Equals(name)) return null;
			return Deps.ContainsKey(name) ? Deps[name] : new Department(name);
		}
		
		public override string ToString()
		{
			return $"Название: {name} Количество сотрудников: {EmployeeList.Count}";
		}
	}
}
