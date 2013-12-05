using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Serpis.Ad
{
	public class CategoriaListView : EntityListView
	{
		public CategoriaListView ()
		{
			App.Instance.DbConnection = new MySqlConnection(
				"Server=localhost;Database=dbprueba;User Id=root; Password=sistemas");
			
			TreeViewHelper treeViewHelper = new TreeViewHelper(treeView, App.Instance.DbConnection, 
				"select id, nombre from categoria"
				);
					
			
			Gtk.Action addAction = new Gtk.Action("addAction", null, null, Stock.Add);
			
			addAction.Activated += delegate {
				executeNonQuery (string.Format ("insert into categoria (nombre) values ('{0}')", DateTime.Now));
			};
			actionGroup.Add(addAction);
					
			
			Gtk.Action removeAction = new Gtk.Action("removeAction", null, null, Stock.Remove);
			
			removeAction.Activated += delegate {
				executeNonQuery (string.Format ("delete from categoria where id={0}", treeViewHelper.Id));
			};
			actionGroup.Add(removeAction);
						
			
			Gtk.Action refreshAction = new Gtk.Action("refreshAction", null, null, Stock.Refresh);
				
			refreshAction.Activated += delegate {
				treeViewHelper.Refresh();
			};
			actionGroup.Add(refreshAction);
			
			
			treeView.Selection.Changed += delegate {
				Console.WriteLine("treeViewHelper.Id='{0}'", treeViewHelper.Id);
				removeAction.Sensitive = treeView.Selection.CountSelectedRows() > 0;
			};
			
			removeAction.Sensitive = false;
		}
		
		private static void executeNonQuery(string sql){
			executeNonQuery (App.Instance.DbConnection, sql);			
		}
		private static void executeNonQuery(IDbConnection dbConnection, string sql){
			IDbCommand dbCommand = dbConnection.CreateCommand();
			dbCommand.CommandText = sql;
			dbCommand.ExecuteNonQuery();
		}
	}
}

