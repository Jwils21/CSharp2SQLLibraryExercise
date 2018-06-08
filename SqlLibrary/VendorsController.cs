using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary {
	public class VendorsController {


		SqlConnection conn = null;
		SqlCommand cmd = new SqlCommand();
		static List<Vendor> vendors = new List<Vendor>();

		private void SetUpCommandObj(SqlConnection conn, string sql) {
			cmd.Connection = conn;
			cmd.CommandText = sql;
			cmd.Parameters.Clear();
		}


		//- will return a list of all rowsSS
		public IEnumerable<Vendor> List() {
			string sql = "Select * from [vendor]";
			SetUpCommandObj(conn, sql);
			SqlDataReader reader = cmd.ExecuteReader();
			while(reader.Read()) {
				// users.add(new User(reader));
				Vendor vendor = new Vendor(reader);
				vendors.Add(vendor);
			}
			reader.Close();
			return vendors;
		}
		//- will return 1 row(with the id that you pass in)
		public Vendor Get(int id) {
			string sql = "Select * from [vendor] where id=@id";
			SetUpCommandObj(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@id", id));
			SqlDataReader reader = cmd.ExecuteReader();
			if(reader.HasRows == false) {
				reader.Close();
				return null;
			} else {
				reader.Read();
				Vendor vendor = new Vendor(reader);
				reader.Close();
				return vendor;
			}
		}
		public bool Create(Vendor vendor) {
			string sql = "Insert into [vendor]" +
						 " (Code, Name, Address, City, Phone, State, Zip, Email, IsPreApproved)" +
						 "Values" +
						 " (@Code, @Name, @Address, @City,@Phone,@State,@Zip,@Email, @IsPreApproved)";
			SetUpCommandObj(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@Code", vendor.Code));
			cmd.Parameters.Add(new SqlParameter("@Name", vendor.Name));
			cmd.Parameters.Add(new SqlParameter("@Address", vendor.Address));
			cmd.Parameters.Add(new SqlParameter("@City", vendor.City));
			cmd.Parameters.Add(new SqlParameter("@Phone", vendor.Phone));
			cmd.Parameters.Add(new SqlParameter("@State", vendor.State));
			cmd.Parameters.Add(new SqlParameter("@Zip", vendor.Zip));
			cmd.Parameters.Add(new SqlParameter("@Email", vendor.Email));
			cmd.Parameters.Add(new SqlParameter("@IsPreApproved", vendor.IsPreapproved));
			int recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);

		}
		public bool Change(Vendor vendor) {
			string sql = "Update [vendor]" +
						 " Set" +
						 " Code=@Code, Name=@Name, Address=@Address, City=@City," +
						 " Phone=@Phone, Email=@Email, State=@State, Zip=@Zip, IsPreApproved=@IsPreApproved" +
						 " Where (Id = @Id);";
			SetUpCommandObj(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@Id", vendor.Id));
			cmd.Parameters.Add(new SqlParameter("@Code", vendor.Code));
			cmd.Parameters.Add(new SqlParameter("@Name", vendor.Name));
			cmd.Parameters.Add(new SqlParameter("@Address", vendor.Address));
			cmd.Parameters.Add(new SqlParameter("@City", vendor.City));
			cmd.Parameters.Add(new SqlParameter("@Phone", vendor.Phone));
			cmd.Parameters.Add(new SqlParameter("@State", vendor.State));
			cmd.Parameters.Add(new SqlParameter("@Zip", vendor.Zip));
			cmd.Parameters.Add(new SqlParameter("@Email", vendor.Email));
			cmd.Parameters.Add(new SqlParameter("@IsPreApproved", vendor.IsPreapproved));
			int recsAffected = cmd.ExecuteNonQuery();

			return (recsAffected == 1);
		}
		public bool Remove(Vendor vendor) {
			string sql = "Delete From [vendor]" +
						 " Where (Id = @Id);";
			SetUpCommandObj(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@Id", vendor.Id));
			int recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
		}

		private SqlConnection CreateAndOpenConnection(string server, string database) {
			String connstr = $"server={server};database={database};Trusted_Connection=true;";
			SqlConnection conn = new SqlConnection(connstr);
			conn.Open();
			if(conn.State != System.Data.ConnectionState.Open) {
				throw new ApplicationException("SQL connection did not open.");
			}
			return conn;
		}

		public void CloseConnection() {
			if(conn != null && conn.State == System.Data.ConnectionState.Closed)
				conn.Close();
		}

		public VendorsController(string server, string database) {
			conn = CreateAndOpenConnection(server, database);
		}


		public VendorsController() {



		}
	}
}
