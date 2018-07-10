namespace DataBaseService.Models
{
	public class Department:DBObj
	{
		public string Name { get; set; }

		public Department(int id, string name):base(id)
		{
			Name = name;
		}

		public Department()
		{

		}

	}
}