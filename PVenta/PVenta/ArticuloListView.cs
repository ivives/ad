using Gtk;
using System;

namespace Serpis.Ad
{
	public class ArticuloListView : EntityListView
	{
		public ArticuloListView ()
		{

			App.Instance.DbConnection = new MySqlConnection(
				"Server=localhost;Database=dbprueba;User Id=root; Password=sistemas");

			TreeViewHelper treeViewHelper = new TreeViewHelper(treeView, App.Instance.DbConnection, 
				"select id, nombre from articulo"
			);


			Gtk.Action addAction = new Gtk.Action("addAction", null, null, Stock.Add);

			addAction.Activated += delegate {
				executeNonQuery (string.Format ("insert into articulo"));
			};
			actionGroup.Add(addAction);


			Gtk.Action removeAction = new Gtk.Action("removeAction", null, null, Stock.Remove);

			removeAction.Activated += delegate {
				executeNonQuery (string.Format ("delete from articulo where id={0}", treeViewHelper.Id));
			};
			actionGroup.Add(removeAction);


			Gtk.Action refreshAction = new Gtk.Action("refreshAction", null, null, Stock.Refresh);

			refreshAction.Activated += delegate {
				treeViewHelper.Refresh();
			};
			actionGroup.Add(refreshAction);


			Gtk.Action editAction = new Gtk.Action ("editAction", null, null, Stock.Edit);

			editAction.Activated += delegate {

			};
			actionGroup.Add (editAction);



			editAction.Sensitive = false;

			treeView.Selection.Changed += delegate {
				editAction.Sensitive = treeView.Selection.CountSelectedRows() > 0;
			};

		}

	}
}
