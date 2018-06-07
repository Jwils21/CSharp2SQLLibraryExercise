using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SqlLibrary {
	public class UsersController {

		SqlConnection conn = null;
		SqlCommand cmd = new SqlCommand();
		static List<User> users = new List<User>();

		private void SetUpCommandObj (SqlConnection conn, string sql) {
			cmd.Connection = conn;
			cmd.CommandText = sql;
			cmd.Parameters.Clear();
		}
		/// <summary>
		/// This would be used to programatically set the parameters.
		/// <param name="user"></param>
		private void SetUpParams(User user) {
			Type type = typeof(User);
			PropertyInfo[] UsrProperties = type.GetProperties();
			foreach(PropertyInfo property in UsrProperties) {
				cmd.Parameters.Add(new SqlParameter("@" + property.Name, "<indexed>"));
			}
			}
			/// </summary>

			//- will return a list of all rowsSS
			public IEnumerable<User> List() {
			string sql = "Select * from [user]";
			SetUpCommandObj(conn, sql);
			SqlDataReader reader = cmd.ExecuteReader();
			while(reader.Read()) {
				// users.add(new User(reader));
				User user = new User(reader);
				users.Add(user);
			}
			reader.Close();
			return users;
		}
		//- will return 1 row(with the id that you pass in)
		public User Get(int id) {
			string sql = "Select * from [user] where Id=@id";
			SetUpCommandObj(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@id", id));
			SqlDataReader reader = cmd.ExecuteReader();
			if(reader.HasRows == false) {
				reader.Close();
				return null;
			}else {
				reader.Read();
				User user = new User(reader);
				reader.Close();
				return user;
			}
		}
		public bool Create(User user) {
			string sql = "Insert into [user]" +
						 " (Username, Password, Firstname, Lastname,Phone, Email, IsReviewer, IsAdmin)" +
						 "Values" +
						 " (@Username, @Password, @Firstname, @Lastname,@Phone,@Email,@IsReviewer,@IsAdmin)";
			SetUpCommandObj(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@Username", user.Username));
			cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
			cmd.Parameters.Add(new SqlParameter("@Firstname", user.FirstName));
			cmd.Parameters.Add(new SqlParameter("@Lastname", user.Lastname));
			cmd.Parameters.Add(new SqlParameter("@Phone", user.Phone));
			cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
			cmd.Parameters.Add(new SqlParameter("@IsReviewer", user.IsReviewer));
			cmd.Parameters.Add(new SqlParameter("@IsAdmin", user.IsAdmin));
			int recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
			
		}
		public bool Change(User user) {
			string sql = "Update [user]" +
						 " Set" +
						 " Username=@Username, Password=@Password, Firstname=@Firstname, Lastname=@Lastname," +
						 " Phone=@Phone, Email=@Email, IsReviewer=@IsReviewer, IsAdmin=@IsAdmin" +
						 " Where (Id = @Id);";
			SetUpCommandObj(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@Id", user.Id));
			cmd.Parameters.Add(new SqlParameter("@Username", user.Username));
			cmd.Parameters.Add(new SqlParameter("@Password", user.Password));
			cmd.Parameters.Add(new SqlParameter("@Firstname", user.FirstName));
			cmd.Parameters.Add(new SqlParameter("@Lastname", user.Lastname));
			cmd.Parameters.Add(new SqlParameter("@Phone", user.Phone));
			cmd.Parameters.Add(new SqlParameter("@Email", user.Email));
			cmd.Parameters.Add(new SqlParameter("@IsReviewer", user.IsReviewer));
			cmd.Parameters.Add(new SqlParameter("@IsAdmin", user.IsAdmin));
			int recsAffected = cmd.ExecuteNonQuery();


			return (recsAffected == 1);
		}
		public bool Remove(User user) {
			string sql = "Delete From [user]" +
						 " Where (Id = @Id);";
			SetUpCommandObj(conn, sql);
			cmd.Parameters.Add(new SqlParameter("@Id", user.Id));
			int recsAffected = cmd.ExecuteNonQuery();
			return (recsAffected == 1);
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
