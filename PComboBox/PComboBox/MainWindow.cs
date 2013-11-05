using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;


public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		IDbConnection dbConnection = new MySqlConnection(
			"Server = localhost;" +
			"Database = dbprueba;" +
			"User Id = root; " +
			"Password = sistemas");
		
		dbConnection.Open();
		
//		comboBox.AppendText("Uno");
//		comboBox.AppendText("Dos");
//		comboBox.AppendText("Tres");
		
		int initialId = 0;
		
		CellRendererText cellRendererText = new CellRendererText();
		comboBox.PackStart(cellRendererText, false);
		comboBox.AddAttribute(cellRendererText, "text", 1);
				
		ListStore listStore = new ListStore (typeof(int), typeof(string));
		
//		listStore.AppendValues(0, "<sin asignar>");
                                                                                                                                                                 		TreeIter initialTreeIter = listStore.AppendValues(0, "<sin asignar>");
//		TreeIter initialTreeIter = TreeIter.Zero;
			
		IDbCommand dbCommand = dbConnection.CreateCommand ();
//		dbCommand.CommandText = "select * from categoria";
		dbCommand.CommandText = "select id, nombre from categoria";
		IDataReader dataReader = dbCommand.ExecuteReader ();
		
		while (dataReader.Read ()) {
			int id = (int)dataReader["id"];
			string nombre = (string)dataReader["nombre"];
			TreeIter treeIter = listStore.AppendValues(id, nombre);	
			if (id == initialId)
				initialTreeIter = treeIter;
		}
		dataReader.Close ();
		
//		listStore.AppendValues(1, "Elemento uno");
//		listStore.AppendValues(2, "Elemento dos");
//		listStore.AppendValues(4, "Elemento cuatro");
		
		comboBox.Model = listStore;
//		if (!initialTreeIter.Equals(TreeIter.Zero))
			comboBox.SetActiveIter(initialTreeIter);
		
		comboBox.Changed += delegate{
			TreeIter treeIter;
			comboBox.GetActiveIter(out treeIter);
			int id = (int)listStore.GetValue (treeIter, 0);
			
			Console.WriteLine("comboBox.Changed id = {0}", id);
		};
		
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
