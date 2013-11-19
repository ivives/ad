using System;
using Gtk;

using Serpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		Console.WriteLine("App.Instance.DbConnection ={0}", App.Instance.DbConnection);
		
		
		CategoriaListView categoriaListView = new CategoriaListView(App.Instance.DbConnection);
		ArticuloListView articuloListView = new ArticuloListView(App.Instance.DbConnection);
		notebook.AppendPage ( articuloListView, new Label("Articulos"));
		notebook.AppendPage ( categoriaListView, new Label("Categorias"));
		
		articuloListView.SelectedChanged += delegate {
			refreshActions();
		};
		
		categoriaListView.SelectedChanged += delegate {
			refreshActions();
		};
		
		
		
//		newAction.Activated += delegate {
//			if(!(notebook.CurrentPageWidget is IEntityListView))
//				return;
//			IEntityListView entityListView = (IEntityListView)notebook.CurrentPageWidget;
//			Console.WriteLine("entityListView.GetType()={0}", entityListView.GetType());
//			entityListView.New();
//		};
		
		newAction.Activated += delegate {
			IEntityListView entityListView = notebook.CurrentPageWidget as IEntityListView;
			if (entityListView == null)
				return;
			Console.WriteLine("entityListView.GetType()={0}", entityListView.GetType());
			entityListView.New();
		};
				
		editAction.Activated += delegate {
			Console.WriteLine("editAction.Activated");
		};
		
		deleteAction.Activated += delegate {
			Console.WriteLine("deletaAction.Activated");
		};
		
		notebook.SwitchPage += delegate {
			refreshActions();
		};	
		
		refreshActions();
		
//		mainButton.Sensitive = false;
//
//		ArticuloListView articuloListView = new ArticuloListView();
//		CategoriaListView categoriaListView = new CategoriaListView();
//		
//		notebook.AppendPage ( articuloListView, new Label("Articulos"));
//		notebook.AppendPage ( categoriaListView, new Label("Categorias"));
//		
//		notebook.SwitchPage += delegate {
//			IEntityListView entityListView = (IEntityListView)notebook.CurrentPageWidget;
//			mainButton.Sensitive = entityListView.HasSelected;
//		};
//		
//		articuloListView.SelectedChanged += delegate {
//			mainButton.Sensitive = articuloListView.HasSelected;
//		};
//		
//		categoriaListView.SelectedChanged += delegate {
//			mainButton.Sensitive = categoriaListView.HasSelected;
//		};
//		
//		mainButton.Clicked += delegate {
//			IEntityListView entityListView = (IEntityListView)notebook.CurrentPageWidget;
//			entityListView.Edit ();
//		};
	}
	
	private void refreshActions(){
		IEntityListView entityListView = notebook.CurrentPageWidget as IEntityListView;	
		newAction.Sensitive = entityListView != null;
		editAction.Sensitive = entityListView != null && entityListView.HasSelected;
		deleteAction.Sensitive = entityListView != null && entityListView.HasSelected;
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
