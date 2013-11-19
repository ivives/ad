using Gtk;
using System;
using System.Data;

namespace Serpis.Ad
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class MyWidget : Gtk.Bin, IEntityListView
	{
		protected IDbConnection dbConnection;
		public MyWidget (IDbConnection dbConnection)
		{
			this.dbConnection = dbConnection;
			
			this.Build ();
			Visible = true;
			
//			treeView.AppendColumn("id", new CellRendererText(), "text", 0);
//			treeView.AppendColumn("nombre", new CellRendererText(), "text", 1);
//			
//			ListStore listStore = new ListStore(typeof(int), typeof(string));
//			listStore.AppendValues(1, "Elemento 1");
//			listStore.AppendValues(2, "Elemento 2");
//			
//			treeView.Model = listStore;
//			
//			treeView.Selection.Changed += delegate {
//				SelectedChanged(this, EventArgs.Empty);
//			};
			
			
			treeView.Selection.Changed += delegate {
				if (SelectedChanged != null)
					SelectedChanged(this, EventArgs.Empty);
			};
		}
		
		public TreeView TreeView {
			get {return treeView;}
		}
		
//		#region IEntityListView implementation
//		public abstract void New ();
//
//		public abstract void Edit ();
//
//		public abstract void Delete ();
//
//		public abstract void Refresh ();
//
//		public bool HasSelected {
//			get {
//				return treeView.Selection.CountSelectedRows() > 0;
//			}
//		}
//		
//		public event EventHandler SelectedChanged;
//		#endregion

		#region IEntityListView implementation
		public virtual void New (){
			Console.WriteLine("MyWidget.New()");
		}
		
		public virtual void Edit (){
			Console.WriteLine("MyWidget.Edit()");
		}
		
		public virtual void Delete (){
			Console.WriteLine("MyWidget.Delete()");
		}
		
		public bool HasSelected {
			get { return treeView.Selection.CountSelectedRows() > 0;}
		}
		
		public event EventHandler SelectedChanged;
		#endregion
	}
}


