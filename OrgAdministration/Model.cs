using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;

namespace OrgAdministration
{
	static class Model
	{
		private const string con = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=demoDB;Integrated Security=True;Pooling=False";

		public static ObservableCollection<Employee> Employees { get; set; }
		public static ObservableCollection<Department> Deps { get; set; }

		public static HashSet<Employee> deletedEmps { get; set; }
		public static HashSet<Department> deletedDeps { get; set; }

		/// <summary>
		/// Забирает список департаментов из удалённого сервиса
		/// </summary>
		public static void LoadDepartments()
		{
			deletedDeps = new HashSet<Department>();
			Deps = new ObservableCollection<Department>();

			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("Accept", "application/xml");
			string url = @"http://localhost:62107/api/deps";
			var response = client.GetStringAsync(url).Result;

			int st = ("<ArrayOfDepartment").Length;
			int ed = response.IndexOf(">") - st;

			string fuckNs = response.Remove(st, ed); //обращение по имени Element("Name") не работает если не добавить NS, так что удалим их вообще из документа

			XDocument doc = XDocument.Parse(fuckNs);

			var col = from dep in doc.Root.Elements("Department")
					  select new Department(
						  dep.Element("Name")?.Value,
						  Convert.ToInt32(dep.Element("id")?.Value)
						  );

			foreach (var s in col)
			{
				Deps.Add(s);
			}

		}


		/// <summary>
		/// Забирает список работников из удалённого сервиса
		/// </summary>
		public static void LoadPeople()
		{
			deletedEmps = new HashSet<Employee>();
			Employees = new ObservableCollection<Employee>();

			HttpClient client = new HttpClient();
			client.DefaultRequestHeaders.Add("Accept", "application/xml");
			string url = @"http://localhost:62107/api/people";
			var response = client.GetStringAsync(url).Result;

			int st = ("<ArrayOfEmployee").Length;
			int ed = response.IndexOf(">") - st;

			string fuckNs = response.Remove(st, ed); //обращение по имени Element("Name") не работает если не добавить NS, так что удалим их вообще из документа
			Trace.WriteLine(fuckNs);
			XDocument doc = XDocument.Parse(fuckNs);

			var col = from dep in doc.Root.Elements("Employee")
					  select new Employee(
						  Convert.ToInt32(dep.Element("id")?.Value),
						  dep.Element("Name")?.Value,
						  Convert.ToInt32(dep.Element("Age")?.Value),
						  dep.Element("Position")?.Value,
						  Convert.ToInt32(dep.Element("Grade")?.Value),
						  Convert.ToInt32(dep.Element("Salary")?.Value),
						  Convert.ToInt32(dep.Element("DepId")?.Value)
						  );

			foreach (var s in col)
			{
				Employees.Add(s);
			}

		}


		/// <summary>
		/// Сохраняет список департаментов в локальную БД
		/// </summary>
		public static void SaveDeps()
		{
			using (SqlConnection connection = new SqlConnection(con))
			{
				string expression;

				connection.Open();
				SqlCommand command; command = new SqlCommand(@"SELECT COUNT(id) FROM Departments", connection);
				int cnt = Convert.ToInt32(command.ExecuteScalar());

				foreach (Department d in Deps)
				{
					if (d.id == 0)
					{
						expression = $@"INSERT INTO Departments VALUES ({cnt + 1}, '{d.name}')";
						SqlCommand add = new SqlCommand(expression, connection);
						add.ExecuteNonQuery();
						d.id = cnt + 1;
						cnt++;
					}
					if (d.id != 0 && d.Changed)
					{
						expression = $@"UPDATE Departments SET Name = '{d.name}' WHERE Id = {d.id}";
						SqlCommand upd = new SqlCommand(expression, connection);
						upd.ExecuteNonQuery();
						d.Changed = false;

					}
				}
			}
		}


		/// <summary>
		/// Сохраняет Работников в локальную БД
		/// </summary>
		public static void SavePeople()
		{
			using (SqlConnection connection = new SqlConnection(con))
			{
				string expression;

				connection.Open();
				SqlCommand command = new SqlCommand(@"SELECT COUNT(id) FROM People", connection);
				int cnt = Convert.ToInt32(command.ExecuteScalar());


				foreach (Employee e in Employees)
				{
					if (e.id == 0)
					{
						expression = $@"INSERT INTO People VALUES ({cnt + 1}, '{e.name}', {e.age}, '{e.Position}', {e.Grade}, {e.Salary}, {e.Dep.id})";
						SqlCommand add = new SqlCommand(expression, connection);
						add.ExecuteNonQuery();
						cnt++;
					}

					if (e.id != 0 && e.Changed)
					{
						expression = $@"UPDATE People SET Name = '{e.name}',
																Age = {e.age},
																Position = '{e.Position}',
																Grade = {e.Grade},
																Salary = {e.Salary},
																Department = {e.Dep.id}
																WHERE Id = {e.id}";
						SqlCommand upd = new SqlCommand(expression, connection);
						upd.ExecuteNonQuery();

					}

				}
				foreach (Employee e in deletedEmps)
				{
					e.Dep.EmployeeList.Remove(e);

					if (e.id != 0)
					{
						expression = $@"DELETE FROM People WHERE Id = {e.id}";
						SqlCommand add = new SqlCommand(expression, connection);
						add.ExecuteNonQuery();
					}
				}
			}
		}


		/// <summary>
		/// Загружает тестовые данные если списки работников и департаментов пусты и БД пуста
		/// </summary>
		public static void SetTestData()
		{

			using (SqlConnection connection = new SqlConnection(con))
			{
				connection.Open();

				int cnt = Convert.ToInt32(new SqlCommand(@"SELECT COUNT(id) FROM Departments", connection).ExecuteScalar());

				if (cnt == 0 && Deps.Count == 0)
					Deps = Department.SetTestData();

				cnt = Convert.ToInt32(new SqlCommand(@"SELECT COUNT(id) FROM People", connection).ExecuteScalar());

				if (cnt == 0 && Employees.Count == 0)
					foreach (Employee e in Employee.SetTestData())
					{
						Employees.Add(e);
					}


			}
		}

	}
}

