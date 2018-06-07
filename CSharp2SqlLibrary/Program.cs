using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLibrary;

namespace CSharp2SqlLibrary {
	class Program {
		static void Main(string[] args) {

			//Returns all 
			UsersController Userctrl = new UsersController(@"STUDENT50\SQLEXPRESS", "prssql");
			IEnumerable<User> users = Userctrl.List();
			foreach(User user1 in users) {
				Console.WriteLine($"{user1.FirstName} {user1.Lastname}");
			}

			User Jon = Userctrl.Get(1);
			if(Jon == null) {
				Console.WriteLine("User not found");
			} else {
				Console.WriteLine($"{Jon.FirstName} {Jon.Lastname}");
			}

			Jon = Userctrl.Get(999);
			if(Jon == null) {
				Console.WriteLine("User not found");
			} else {
				Console.WriteLine($"{Jon.FirstName} {Jon.Lastname}");
			}

			User newUser = new User() {
				Username = "NewUser",
				FirstName = "New",
				Lastname = "User",
				Email = "User@email.com",
				Password = "password",
				Phone = "197-846-1530",
				IsAdmin = false,
				IsReviewer = false
			};
			//bool success = Userctrl.Create(newUser);

			User user = Userctrl.Get(6);
			user.FirstName = "Kimmie";
			//bool success = Userctrl.Change(user);
			

			bool success = Userctrl.Remove(user);

			Userctrl.CloseConnection();


		}
	}
}
