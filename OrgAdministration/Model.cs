using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OrgAdministration
{
	static class Model
	{
		private const string con = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=demoDB;Integrated Security=True;Pooling=False";

		public static ObservableCollection<Employee> Employees { get; set; }
		public static ObservableCollection<Department> Deps { get; set; }

		public static HashSet<Employee> deletedEmps { get; set; }
		public static HashSet<Department> deletedDeps { get; set; }

		public static void LoadDepartments()
		{
			deletedDeps = new HashSet<Department>();
			Deps = new ObservableCollection<Department>();
			using (SqlConnection connection = new SqlConnection(con))
			{
				connection.Open();

				SqlCommand command;

				string getDeps = @"SELECT Id, Name FROM Departments";
				command = new SqlCommand(getDeps, connection);
				SqlDataReader dr = command.ExecuteReader();

				if (dr.HasRows)
				{
					while (dr.Read())
					{
						Deps.Add(new Department(dr.GetString(1), dr.GetInt32(0)));
					}
				}

			}

		}

		public static void LoadPeople()
		{
			deletedEmps = new HashSet<Employee>();
			Employees = new ObservableCollection<Employee>();
			using (SqlConnection connection = new SqlConnection(con))
			{
				connection.Open();

				SqlCommand command;

				string getPpl = @"SELECT Id, Name, Age, Position, Grade, Salary, Department FROM People";
				command = new SqlCommand(getPpl, connection);
				SqlDataReader dr = command.ExecuteReader();

				if (dr.HasRows)
				{
					while (dr.Read())
					{
						Employees.Add(new Employee(
							id: dr.GetInt32(0),
							name: dr.GetString(1),
							age: dr.GetInt32(2),
							position: dr.GetString(3),
							grade: dr.GetInt32(4),
							salary: dr.GetInt32(5),
							depId: dr.GetInt32(6)
							));
					}
				}

			}

		}

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

