using System;

using MySql.Data.MySqlClient;

using System.Collections.Generic; // List<string> columnNames = new List<string();>

namespace Serpis.Ad
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string connectionString =
				"Server=localhost;" +
				"Database=dbprueba;" +
				"User Id=root;" +
				"Password=sistemas";
			
			MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
				
			mySqlConnection.Open ();
			
			// select * from categoria
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
			
			mySqlCommand.CommandText = "select * from categoria";
			
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
			
//			int fieldCount = mySqlDataReader.FieldCount;
//			
//			for (int index=0; index < fieldCount; index++){
//				string nombre = mySqlDataReader.GetName(index);
//			
//				Console.Write(nombre + "  ");
//				Console.WriteLine();
//			}
	
			Console.WriteLine(string.Join( getColumnNames(mySqlDataReader)));
			
			
			mySqlDataReader.Close();
						
			mySqlConnection.Close ();
			
			Console.WriteLine("Ok"); //Console.Write();
					
		}
		
		private static string[] getColumnNames(MySqlDataReader mySqlDataReader) {
			//string[] columnNames = new string[mySqlDataReader.FieldCount];
			return new string[]{};
			
		}
	}
}
