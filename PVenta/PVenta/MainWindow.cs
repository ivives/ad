using System;
using Gtk;
using Serpis.Ad;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{	
//	private MySqlConnection mySqlConnection;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
				
		Build ();
		
//		mySqlConnection = new MySqlConnection
//			("Server=localhost;Database=dbprueba;User Id=root;Password=sistemas");
//		mySqlConnection.Open ();
//		
//		
//		string selectSql ="select * from articulo ";
//		
//		TreeViewHelper treeViewHelper = new TreeViewHelper(treeViewArticulo, mySqlConnection, selectSql);
//				
//		ListStore listStore = treeViewHelper.ListStore;
		
		
		
//		foreach (string stockId in new string[]{Stock.Add, Stock.Apply, Stock.Cancel, Stock.Edit}){
//		
//			Button button = new Button(stockId);
//			button.Visible = true;
//			vbox1.Add (button);
//		}
		
		foreach (string stockId in new string[]{Stock.Add, Stock.Close, Stock.Edit}){
		
			Button button = new Button(stockId);
			button.Visible = true;
			notebook.AppendPage (button, new Label("Pestaña " + stockId));
		}
		
		notebook.ChangeCurrentPage += delegate {
				
		};
		
	}
	
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
