using Gtk;
using System;
using System.Data;

namespace Serpis.Ad
{
	public class ArticuloListView : MyWidget
	{
		public ArticuloListView (IDbConnection dbConnection) : base(dbConnection)
		{
			
			TreeView.AppendColumn("id", new CellRendererText(), "text", 0);
			TreeView.AppendColumn("nombre", new CellRendererText(), "text", 1);
			TreeView.AppendColumn("categoria", new CellRendererText(), "text", 2);
			TreeView.AppendColumn("precio", new CellRendererText(), "text", 3);
			ListStore listStore = new ListStore(typeof(int), typeof(string));
			TreeView.Model = listStore;
			listStore.AppendValues (1, "Articulo 1", "Cat. 1", 1); 
			listStore.AppendValues (2, "Articulo 2", "Cat. 2", 2);
		}
		
		public override void New ()
		{
			
			Console.WriteLine("ArticuloListView.New()");
		}
			
			
		
//		#region implemented abstract members of Serpis.Ad.MyWidget
//		public override void New ()
//		{
//			Console.WriteLine("ArticuloListView.New");
//		}
//
//		public override void Edit ()
//		{
//			Console.WriteLine("ArticuloListView.Edit");
//		}
//
//		public override void Delete ()
//		{
//			throw new NotImplementedException ();
//		}
//
//		public override void Refresh ()
//		{
//			throw new NotImplementedException ();
//		}
//		#endregion
	}
}

