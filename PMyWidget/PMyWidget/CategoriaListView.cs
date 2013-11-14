using Gtk;
using System;

namespace Serpis.Ad
{
	public class CategoriaListView : MyWidget
	{
		public CategoriaListView ()
		{
			
			TreeView.AppendColumn("id", new CellRendererText(), "text", 0);
			TreeView.AppendColumn("nombre", new CellRendererText(), "text", 1);
			TreeView.Model = new ListStore(typeof(int), typeof(string));
			
		}
		
		public override void New ()
		{
			Console.WriteLine("CategoriaListView.New()");
		}
		
//		#region implemented abstract members of Serpis.Ad.MyWidget
//		public override void New ()
//		{
//			Console.WriteLine("CategoriaListView.New");
//		}
//
//		public override void Edit ()
//		{
//			Console.WriteLine("CategoriaListView.Edit");
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

