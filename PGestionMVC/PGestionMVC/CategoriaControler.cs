using System;
using System.Reflection;

namespace Serpis.Ad
{
	public class CategoriaControler
	{
//		private Categoria categoria;
//		private CategoriaView categoriaView;
		
		public CategoriaControler (Categoria categoria, CategoriaView categoriaView)
		{
			
			
//			Type type = categoriaView.GetType(); // devuelve lo mismo que typeof(CategoriaView);
//			PropertyInfo propertyInfo = type.GetProperty ("Nombre");
//			propertyInfo.SetValue(categoriaView, "El valor que quieras asignar con SetValue", null);
						
			categoriaView.Nombre = categoria.Nombre;
						
			categoriaView.SaveActionDelegate = delegate {
				categoria.Nombre = categoriaView.Nombre;
				Categoria.Save(categoria);
			};
		

		}
		
		public static void SetView (object view, object model){
			Type viewType = view.GetType();
			Type modelType = model.GetType();
			
			foreach (PropertyInfo viewPropertyInfo in viewType.GetProperties()){
				if (viewPropertyInfo.IsDefined(typeof(ModelAttribute), true)){
					PropertyInfo modelPropertyInfo = modelType.GetProperty(viewPropertyInfo.Name);
					object value = modelPropertyInfo.GetValue(model, null);
					viewPropertyInfo.SetValue(view, value, null);
				}
			}
			
		}
		
		
	}
	
	public class ModelAttribute : Attribute{
	}
	
}

