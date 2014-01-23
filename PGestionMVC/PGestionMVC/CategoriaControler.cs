using System;

namespace Serpis.Ad
{
	public class CategoriaControler
	{
//		private Categoria categoria;
//		private CategoriaView categoriaView;
		
		public CategoriaControler (Categoria categoria, CategoriaView categoriaView)
		{
//			this.categoria = categoria;
//			this.categoriaView = categoriaView;
			
			categoriaView.Nombre = categoria.Nombre;
			
//			categoriaView.SaveActionDelegate = saveActionHandler;
			
			
			categoriaView.SaveActionDelegate = delegate {
				categoria.Nombre = categoriaView.Nombre;
				Categoria.Save(categoria);
			};
		

		}
		
//		private void saveActionHandler(){
//			categoria.Nombre = categoriaView.Nombre;
//			Categoria.Save(categoria);
//		}
		
		
	}
}

