using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLibrary;

namespace CSharp2SqlLibrary {
	class Program {
		static void Main(string[] args) {

		UsersController Userctrl = new UsersController(@"STUDENT50\SQLEXPRESS","prssql");
			IEnumerable<User> users = Userctrl.List();
			foreach(User user in users) {
				Console.WriteLine($"{user.FirstName} {user.Lastname}");
			}

			Userctrl.CloseConnection();


		}
	}
}
