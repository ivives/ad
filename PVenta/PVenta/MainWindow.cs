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
		
		Console.WriteLine("Initial notebook.CurrentPage0{0}", notebook.CurrentPage);
		
		notebook.SwitchPage += delegate {
			Console.WriteLine("SwitchPage notebook.CurrentPage0{0}", notebook.CurrentPage);
		};
		
		notebook.PageRemoved += delegate {
			Console.WriteLine("PageRemoved notebook.CurrentPage0{0}", notebook.CurrentPage);	
		};
		foreach (string stockId in new string[]{Stock.Add, Stock.Close, Stock.Edit}){
		
			Button button = new Button(stockId);
			button.Visible = true;
			
			HBox hbox = new HBox();
			Label label = new Label ("Pestaña " + stockId);
			hbox.Add (label);
			label.Visible = true;
			Button buttonTap = new Button();
			buttonTap.Image = Image.NewFromIconName (Stock.Close, IconSize.Button);
			buttonTap.Visible = true;
			hbox.Add (buttonTap);
			notebook.AppendPage (button, hbox);
			
			buttonTap.Clicked += delegate {
				button.Destroy();	
			};
		}
		
				
		
	}
	
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
