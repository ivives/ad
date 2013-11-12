using System;

namespace Serpis.Ad
{
	public class CategoriaListView : MyWidget
	{
		public CategoriaListView ()
		{
		}

		#region implemented abstract members of Serpis.Ad.MyWidget
		public override void New ()
		{
			Console.WriteLine("CategoriaListView.New");
		}

		public override void Edit ()
		{
			Console.WriteLine("CategoriaListView.Edit");
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

