using System;
using Gtk;
using MySql.Data.MySqlClient;

namespace Serpis.Ad
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
			int i = default(int);
//			int i = (int)Convert.ChangeType("123", typeof(int));
			Console.WriteLine ("i={0}", i);
			
			Categoria categoria = (Categoria) Categoria.Load (typeof(Categoria), "");
			Console.WriteLine ("categoria.Nombre");
			return;
			
			App.Instance.DbConnection = new MySqlConnection 
				("Server = localhost; Database = dbprueba;User Id = root; Password = sistemas");
			
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}
	}
}
