using Gtk;
using System;

namespace Serpis.Ad
{
	public class ArticuloListView : MyWidget
	{
		public ArticuloListView ()
		{
			
			TreeView.AppendColumn("id", new CellRendererText(), "text", 0);
			TreeView.AppendColumn("nombre", new CellRendererText(), "text", 1);
			TreeView.AppendColumn("categoria", new CellRendererText(), "text", 2);
			TreeView.AppendColumn("precio", new CellRendererText(), "text", 3);
			TreeView.Model = new ListStore(typeof(int), typeof(string));
			
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

