using System;
using Gtk;

using Serpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		mainButton.Sensitive = false;
		
		ArticuloListView articuloListView = new ArticuloListView();
		CategoriaListView categoriaLisView = new CategoriaListView();
		
		notebook.AppendPage (new ArticuloListView(), new Label("Articulos"));
		notebook.AppendPage (new CategoriaListView(), new Label("Categorias"));
		
		notebook.SwitchPage += delegate {
			IEntityListView entityListView = (IEntityListView)notebook.CurrentPageWidget;
			mainButton.Sensitive = entityListView.HasSelected;
		};
		
		articuloListView.SelectedChanged += delegate {
			mainButton.Sensitive = articuloListView.HasSelected;
		};
		
		categoriaLisView.SelectedChanged += delegate {
			mainButton.Sensitive = categoriaLisView.HasSelected;
		};
		
		mainButton.Clicked += delegate {
			IEntityListView entityListView = (IEntityListView)notebook.CurrentPageWidget;
			entityListView.New();
		};
		
		
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
