using System;
using Gtk;

namespace Serpis.Ad
{
	public class CategoriaListView :EntityListView
	{
		public CategoriaListView ()
		{
			
			TreeViewHelper treeViewHelper = new TreeViewHelper(treeView, App.Instance.DbConnection, 
				"select id, nombre from categoria"
			);
			
			
			Gtk.Action refreshAction = new Gtk.Action("refreshAction", null , null , Stock.Refresh); 
			refreshAction.Activated += delegate {
				treeViewHelper.Refresh();
			};
					
			actionGroup.Add (refreshAction);
			
			
			Gtk.Action editAction = new Gtk.Action("editAction", null, null , Stock.Edit);
			editAction.Activated += delegate {
				Categoria categoria = Categoria.Load (treeViewHelper.Id);
//				Console.WriteLine("categoria.Id={0}, categoria.Nombre={1}", categoria.Id, categoria.Nombre);
								
				CategoriaView categoriaView = new CategoriaView();
				
				//CategoriaControler categoriaControler = 
													new CategoriaControler(categoria, categoriaView);
				
				categoriaView.Show();
				
				
			};
			
			actionGroup.Add (editAction);
		}
	}
}

