using System;
using MySql.Data.MySqlClient;
using Gtk;

namespace Serpis.Ad
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			App.Instance.DbConnection = new MySqlConnection 
				("Server = localhost; Database = dbprueba;User Id = root; Password = sistemas");
			
			
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
