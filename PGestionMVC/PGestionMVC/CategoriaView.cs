using System;
using Gtk;

namespace Serpis.Ad
{
		
	public partial class CategoriaView : Gtk.Window
	{
		
		private System.Action saveActionDelegate;
		
		public CategoriaView () : 
				base(Gtk.WindowType.Toplevel)
		{
			this.Build ();
			
			saveAction.Activated += delegate {
				saveActionDelegate();
				Destroy ();
			};
		}
		
			
//		public Entry EntryNombre {
//			get {return entryNombre;}
//		}

		
		public string Nombre {
			get {return entryNombre.Text;}
			set {entryNombre.Text = value;}
		}
				
		
//		public Gtk.Action SaveAction {
//			get {return saveAction;}
//		}
		
		public System.Action SaveActionDelegate {
			set {saveActionDelegate = value;}	
		}
		
	}
	
}


