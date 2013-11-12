using System;

namespace Serpis.Ad
{
	public class ArticuloListView : MyWidget
	{
		public ArticuloListView ()
		{
			
			
		}

		#region implemented abstract members of Serpis.Ad.MyWidget
		public override void New ()
		{
			Console.WriteLine("ArticuloListView.New");
		}

		public override void Edit ()
		{
			Console.WriteLine("ArticuloListView.Edit");
		}

		public override void Delete ()
		{
			throw new NotImplementedException ();
		}

		public override void Refresh ()
		{
			throw new NotImplementedException ();
		}
		#endregion
	}
}

