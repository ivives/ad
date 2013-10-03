using System;
using Gtk;
using MySql.Data.MySqlClient;

public partial class MainWindow: Gtk.Window
{	
	
	private MySqlConnection mySqlConnection;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		mySqlConnection = new MySqlConnection("Server=localhost;Database=dbprueba;" +
												"user id=root; Password=sistemas");
		mySqlConnection.Open();
		
		MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
			
			mySqlCommand.CommandText = "select * from articulo";
			
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
		
		int fieldCount = mySqlDataReader.FieldCount;
			for (int index=0; index < fieldCount; index++){
				string nombre = mySqlDataReader.GetName(index);
			
			treeView.AppendColumn(nombre, new CellRendererText(), "text", index);	
			
			}
		
//		treeView.AppendColumn("id" , new CellRendererText(), "text", 0);
//		treeView.AppendColumn("nombre" , new CellRendererText(), "text", 1);
//		treeView.AppendColumn("categoria" , new CellRendererText(), "text", 2);
//		treeView.AppendColumn("precio" , new CellRendererText(), "text", 3);
//		
		
		Type[] types = new Type[4];
		for (int index = 0; index < fieldCount; index++)
			types[index] = typeof(string);
		
//		ListStore listStore = new ListStore(typeof(string), typeof(string), typeof(string), typeof(string));
		ListStore listStore = new ListStore(types);
		
		while (mySqlDataReader.Read()) {
				string line = "";
				for(int index = 0; index < mySqlDataReader.FieldCount; index++){
					object value = mySqlDataReader.GetValue(index);
					if (value is DBNull)
						value = "null";
					line = line + value + "     ";
				}
		string[] values = new string[]{line};
		for (int index = 0; index < fieldCount; index++)
			values[index] = index.ToString();
		listStore.AppendValues(values);
			
		
		
		treeView.Model = listStore;
			
			
			
		}
		
//		listStore.AppendValues ("1", "uno", "1", "1.5");
//		string[] values = new string[]{"1", "uno", "1", "1.5"};
//		for (int index = 0; index < fieldCount; index++)
//			values[index] = index.ToString();
//		listStore.AppendValues(values);
//			
//		listStore.AppendValues ("2", "dos");
//		listStore.AppendValues ("3", "tres");
//		
//		treeView.Model = listStore;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
		
		mySqlConnection.Close();
	}
}
