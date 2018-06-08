using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlLibrary;

namespace CSharp2SqlLibrary {
	class Program {

		static void ActnUsr() {

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

		static void ActnVendor() {
			//Returns all 
			VendorsController VendorCtrl = new VendorsController(@"STUDENT50\SQLEXPRESS", "prssql");
			IEnumerable<Vendor> vendor = VendorCtrl.List();
			foreach(Vendor Vendor1 in vendor) {
				Console.WriteLine($"{Vendor1.Code} {Vendor1.Name} {Vendor1.Address}");
			}

			Vendor Amzn = VendorCtrl.Get(1);
			if(Amzn == null) {
				Console.WriteLine("Vendor not found");
			} else {
				Console.WriteLine($"{Amzn.Code} {Amzn.Name} {Amzn.Address}");
			}

			Amzn = VendorCtrl.Get(999);
			if(Amzn == null) {
				Console.WriteLine("User not found");
			} else {
				Console.WriteLine($"{Amzn.Code} {Amzn.Name} {Amzn.Address}");
			}

			Vendor newVendor = new Vendor() {
				Code = "Walm",
				Address = "564 Walmart way",
				Name = "Walmart",
				City = "Walmartville",
				State = "GA",
				Zip = "98123",
				Email = "orders@walmart.com",
				Phone = "987-456-1203",
				Active = true,
				IsPreapproved = true
			};
			//bool success = VendorCtrl.Create(newVendor);

			Vendor vendorWal = VendorCtrl.Get(5);
			vendorWal.Code = "WAL";
			//bool success = VendorCtrl.Change(vendorWal);


			bool success = VendorCtrl.Remove(vendorWal);

			VendorCtrl.CloseConnection();
		}


		static void Main(string[] args) {
			ActnVendor();


		}
	}
}
