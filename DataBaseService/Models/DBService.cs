using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DataBaseService.Models
{
	public class DBService
	{
		private const string con = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=demoDB;Integrated Security=True;Pooling=False";

		public static List<Employee> Employees { get; set; }
		public static List<Department> Deps { get; set; }

		public static HashSet<Employee> deletedEmps { get; set; }
		public static HashSet<Department> deletedDeps { get; set; }


		/// <summary>
		/// Загружает список департаментов из локальной бд
		/// </summary>
		public static void LoadDepartments()
		{
			deletedDeps = new HashSet<Department>();
			Deps = new List<Department>();
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
						Deps.Add(new Department( dr.GetInt32(0), dr.GetString(1)));
					}
				}

			}

		}

		/// <summary>
		///  Загружает список работников из локальной БД
		/// </summary>
		public static void LoadPeople()
		{
			deletedEmps = new HashSet<Employee>();
			Employees = new List<Employee>();
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


		public DBObj GetDBObj { get; set; }
	}
}