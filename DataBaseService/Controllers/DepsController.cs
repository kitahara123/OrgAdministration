using DataBaseService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataBaseService.Controllers
{
	public class DepsController : ApiController
	{

		public List<Department> GetDeps()
		{
			DBService.LoadDepartments();

			return DBService.Deps;
		}

	}
}
