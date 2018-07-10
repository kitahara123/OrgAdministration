namespace DataBaseService.Models
{
	public class Employee:DBObj
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public string Position { get; set; }
		public int Grade { get; set; }
		public int Salary { get; set; }
		public int DepId { get; set; }


		public Employee(int id, string name, int age, string position, int grade, int salary, int depId) : base(id)
		{
			Name = name;
			Age = age;
			Salary = salary;
			Grade = grade;
			Position = position;
			DepId = depId;
		}
		
		public Employee()
		{

		}

	}
}