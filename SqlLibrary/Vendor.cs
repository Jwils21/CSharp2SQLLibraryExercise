using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary {
	public class Vendor {
		public string Code { get; set; }
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Phone { get; set; }
		public string State { get; set; }
		public string Zip { get; set; }
		public string Email{ get; set; }
		public bool IsPreapproved { get; set; }
		public bool Active { get; set; }

		public Vendor(string code, int id, string name, string address, string city, string phone, string state, string zip, string email, bool ispreapproved, bool active) {
			Code = code;
			Id = id;
			Name = name;
			Address = address;
			City = city;
			Phone = phone;
			State = State;
			Zip = zip;
			Email = email;
			IsPreapproved = ispreapproved;
			Active = active;
		}

		public Vendor(SqlDataReader reader) {
			//find the column named id, and cast that to a C# int32
			Id = reader.GetInt32(reader.GetOrdinal("Id"));
			Code = reader.GetString(reader.GetOrdinal("Code"));
			Name = reader.GetString(reader.GetOrdinal("Name"));
			Address = reader.GetString(reader.GetOrdinal("Address"));
			City = reader.GetString(reader.GetOrdinal("City"));
			Phone = reader.GetString(reader.GetOrdinal("Phone"));
			Email = reader.GetString(reader.GetOrdinal("Email"));
			State = reader.GetString(reader.GetOrdinal("State"));
			Zip = reader.GetString(reader.GetOrdinal("Zip"));
			IsPreapproved = reader.GetBoolean(reader.GetOrdinal("IsPreapproved"));
			Active = reader.GetBoolean(reader.GetOrdinal("Active"));
		}


		public Vendor() {

		}

	}
}
