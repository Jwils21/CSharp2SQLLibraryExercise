using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlLibrary {
	public class UsersController {

		SqlConnection conn = null;
		SqlCommand cmd = new SqlCommand();
		static List<User> users = new List<User>();

		//- will return a list of all rowsSS
		public IEnumerable<User> List() {
			string sql = "Select * from [user]";
			cmd.Connection = conn;
			cmd.CommandText = sql;
			SqlDataReader reader = cmd.ExecuteReader();
			while(reader.Read()) {
				// users.add(new User(reader));
				User user = new User(reader);
				users.Add(user);
			}
			return users;
		}
		//- will return 1 row(with the id that you pass in)
		public User Get(int id) {
			return null;
		}
		public bool Create(User user) {
			return true;
		}
		public bool Change(User user) {
			int recsAffected = cmd.ExecuteNonQuery();
			if(recsAffected != 1) {
				return false;
			} else {
				return true;
			}
		}
		public bool Remove(User user) {
			return false;
		}

		private SqlConnection CreateAndOpenConnection(string server, string database) {
			String connstr = $"server={server};database={database};Trusted_Connection=true;";
			SqlConnection conn = new SqlConnection(connstr);
			conn.Open();
			if (conn.State != System.Data.ConnectionState.Open) {
				throw new ApplicationException("SQL connection did not open.");
			}
			return conn;
		}

		public void CloseConnection() {
			if (conn != null && conn.State == System.Data.ConnectionState.Closed )
			conn.Close();
		}

		public UsersController(string server, string database) {
			conn = CreateAndOpenConnection(server, database);
		}


		public UsersController() {

		}

	}
}
