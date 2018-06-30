using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgAdministration
{
	public enum DepName
	{
		IT, Cleaning, HR, Managers
	}
	public class Department
	{
		public static Dictionary<DepName, Department> Deps { get; }
		public DepName name;
		public List<Employee> EmployeeList { get; set; }


		static Department()
		{
			Deps = new Dictionary<DepName, Department>();
		}
		private Department(DepName name)
		{
			this.name = name;
			EmployeeList = new List<Employee>();
			Deps.Add(name, this);
		}

		public static Department GetDepByName(DepName name)
		{
			return Deps.ContainsKey(name) ? Deps[name] : new Department(name);
		}
		
		public override string ToString()
		{
			return $"Название: {name} Количество сотрудников: {EmployeeList.Count}";
		}
	}
}
