using Gtk;
using System;

namespace Serpis.Ad
{
	[System.ComponentModel.ToolboxItem(true)]
	public abstract partial class MyWidget : Gtk.Bin, IEntityListView
	{
		public MyWidget ()
		{
			this.Build ();
			Visible = true;
			
			treeView.AppendColumn("id", new CellRendererText(), "text", 0);
			treeView.AppendColumn("nombre", new CellRendererText(), "text", 1);
			
			ListStore listStore = new ListStore(typeof(int), typeof(string));
			listStore.AppendValues(1, "Elemento 1");
			listStore.AppendValues(2, "Elemento 2");
			
			treeView.Model = listStore;
			
			treeView.Selection.Changed += delegate {
				SelectedChanged
			};
		}
		
		public TreeView TreeView{
			get {return TreeView;}
		}
		
		#region IEntityListView implementation
		public abstract void New ();
		

		public abstract void Edit ();
		

		public abstract void Delete ();
		

		public abstract void Refresh ();
		
		
		public bool HasSelected {
			get {
				return treeView.Selection.CountSelectedRows() > 0;
			}
		}
		
		public event EventHandler SelectedChanged;
		#endregion
		
	}
}

