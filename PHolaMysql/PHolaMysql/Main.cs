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
			
			mySqlCommand.CommandText = "select * from articulo";
			
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
			
//			int fieldCount = mySqlDataReader.FieldCount;
//			for (int index=0; index < fieldCount; index++){
//				string nombre = mySqlDataReader.GetName(index);
//			
//				Console.Write(nombre + "  ");
//				Console.WriteLine();
//			}
	
			Console.WriteLine(string.Join("    ", getColumnNames3(mySqlDataReader)));
			
			//visualizar datos
//			while (mySqlDataReader.Read()) {
//				int fieldCount = mySqlDataReader.FieldCount;
//				for(int index = 0; index < fieldCount; index++){
//					object value = mySqlDataReader.GetValue(index);
//					if (value is DBNull)
//						value = "null";
//				
//					Console.Write(value + "     ");
//					if (index == fieldCount -1)
//						Console.WriteLine();
//				}
//			}
			
			while (mySqlDataReader.Read()) {
//				string line = "";
//				for(int index = 0; index < mySqlDataReader.FieldCount; index++){
//					object value = mySqlDataReader.GetValue(index);
//					if (value is DBNull)
//						value = "null";
//					line = line + value + "     ";
//				}
//					Console.WriteLine(line);

					Console.WriteLine (getLine(mySqlDataReader));  //esta sera la llamada al metodo			
				}
				
				
			mySqlDataReader.Close();
			mySqlConnection.Close ();
			Console.WriteLine("Ok"); //Console.Write();
					
		}
		
		private static string[] getColumnNames(MySqlDataReader mySqlDataReader) {
			
			int fieldCount = mySqlDataReader.FieldCount;
			string[] columnNames = new string[fieldCount];
			for (int index = 0; index < fieldCount; index++)
				columnNames[index] = mySqlDataReader.GetName (index);
			return columnNames;
			
		}
		
		private static string[] getColumnNames2(MySqlDataReader mySqlDataReader) {
			
			int fieldCount = mySqlDataReader.FieldCount;
			List<string> columnNames = new List<string>();
			for (int index = 0; index < fieldCount; index++)
				columnNames.Add (mySqlDataReader.GetName(index));
			return columnNames.ToArray();
			
		}
		
		private static IEnumerable<string> getColumnNames3(MySqlDataReader mySqlDataReader) {
			
			int fieldCount = mySqlDataReader.FieldCount;
			List<string> columnNames = new List<string>();
			for (int index = 0; index < fieldCount; index++)
				columnNames.Add (mySqlDataReader.GetName(index));
			return columnNames;
			
		}
		
		private static string getLine (MySqlDataReader mySqlDataReader){
			
			string line = "";
			for(int index = 0; index < mySqlDataReader.FieldCount; index++){
				object value = mySqlDataReader.GetValue(index);
				if (value is DBNull)
					value = "null";
				line = line + value + "     ";
			}
			return line;	
			
			
		}
		
	}
}
