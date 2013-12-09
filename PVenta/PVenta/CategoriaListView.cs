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



			Gtk.Action refreshAction = new Gtk.Action("refreshAction", null, null, Stock.Refresh);

			refreshAction.Activated += delegate {
				treeViewHelper.Refresh();
			};
			actionGroup.Add(refreshAction);



			Gtk.Action editAction = new Gtk.Action ("editaction", null, null, Stock.Edit);

			editAction.Activated += delegate {
					
			};
			actionGroup.Add (editAction);


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

		private static void addAction (ActionGroup actionGroup, Gtk.Action action){

		}
	}
}

