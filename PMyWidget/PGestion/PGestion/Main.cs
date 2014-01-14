using System;
using Gtk;
using MySql.Data.MySqlClient;


namespace Serpis.Ad
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Conexion a la base de datos
			App.Instance.DbConnection = new MySqlConnection 
				("Server = localhost; Database = dbprueba;User Id = root; Password = sistemas");
			
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
