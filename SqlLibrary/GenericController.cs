using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SqlLibrary {
	class GenericController {
		/// This class is a test for a generic controller to dynamically query SQL database with whatever table you want
		//SqlConnection conn = null;
		//SqlCommand cmd = new SqlCommand();

		//private void SetUpCommandObj(SqlConnection conn, string sql) {
		//	cmd.Connection = conn;
		//	cmd.CommandText = sql;
		//	cmd.Parameters.Clear();
		//}

		//public IEnumerable<T> List() {
		//	string sql = $"Select * from {typeof(T)} ";
		//	SetUpCommandObj(conn, sql);
		//	SqlDataReader reader = cmd.ExecuteReader();
		//	while(reader.Read()) {
		//		// users.add(new User(reader));
		//		User user = new User(reader);
		//		users.Add(user);
		//	}
		//	reader.Close();
		//	return users;
		//}


	}
}
