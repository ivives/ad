using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

using Serpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	private MySqlConnection mySqlConnection;
	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		mySqlConnection = new MySqlConnection("Server=localhost;Database=dbprueba;User Id=root;Password=sistemas");
		mySqlConnection.Open ();
		
		
		string selectSql ="select a.id, a.nombre, c.nombre as categoria, a.precio from articulo a left join categoria c " +
			"on a.categoria = c.id ";
		
		TreeViewHelper treeViewHelper = new TreeViewHelper(treeView, mySqlConnection, selectSql);
				
		ListStore listStore = treeViewHelper.ListStore;
		
		editAction.Sensitive = false;
		deleteAction.Sensitive =false;
		
		
		editAction.Activated += delegate {
			//Cuando entra hay algun elemento seleccionado
			if (treeView.Selection.CountSelectedRows() == 0)
				return;
			
			TreeIter treeIter; //Para mostrar la informacion de la linea seleccionada para editar
			treeView.Selection.GetSelected(out treeIter);
			object id = listStore.GetValue (treeIter, 0);
			object nombre = listStore.GetValue (treeIter, 1);
			
			MessageDialog md = new MessageDialog (this, 
                                    DialogFlags.DestroyWithParent,
	                              	MessageType.Info, 
                                    ButtonsType.Ok, 
			                        "Seleccionado Id= {0} Nombre= {1} ", id, nombre);
			md.Title = "Editar elemento";
			md.Run ();
			md.Destroy();			
		};
		
		
		deleteAction.Activated += delegate {
			if (treeView.Selection.CountSelectedRows() == 0)
				return;
			
			TreeIter treeIter; //Para mostrar la informacion de la linea seleccionada para borrar
			treeView.Selection.GetSelected(out treeIter);
			object id = listStore.GetValue (treeIter, 0);
			
			MessageDialog md = new MessageDialog (this, 
                                    DialogFlags.DestroyWithParent,
	                              	MessageType.Question, 
                                    ButtonsType.YesNo, 
			                        "¿Quieres eliminar el elemento seleccionado?");
			md.Title = "Eliminar elemento";
			ResponseType response = (ResponseType) md.Run ();
			if (response == ResponseType.Yes) {
				MySqlCommand deleteMySqlCommand = mySqlConnection.CreateCommand();
				deleteMySqlCommand.CommandText = "delete from articulo where id=" + id;
				deleteMySqlCommand.ExecuteNonQuery();
			}
			md.Destroy();		
		};
			
		
		treeView.Selection.Changed += delegate { //Activa el boton cuando alguna fila esta seleccionada
			bool hasSelectedRows = treeView.Selection.CountSelectedRows() >0;
			editAction.Sensitive = hasSelectedRows;
			deleteAction.Sensitive = hasSelectedRows;
		};
		

	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
		
		mySqlConnection.Close ();
	}
}

