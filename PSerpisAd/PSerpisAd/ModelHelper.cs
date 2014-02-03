using System;
using System.Collections.Generic;
using System.Reflection;
using System.Data;

namespace Serpis.Ad
{
	public class ModelHelper
	{
		public static string GetSelect(Type type){
			
			string keyName = null;
			List<string> fieldNames = new List<string>();
			foreach (PropertyInfo propertyInfo in type.GetProperties()){
				if(propertyInfo.IsDefined (typeof(KeyAttribute), true))
					keyName = propertyInfo.Name.ToLower();
				else if (propertyInfo.IsDefined (typeof(FieldAttribute), true))
					fieldNames.Add (propertyInfo.Name.ToLower());
				
			}
			
			string tableName = type.Name.ToLower();
			
			return string.Format("select {0} from {1} where {2}=", 
			                     string.Join(", ", fieldNames), tableName, keyName );
		
		}
		
		
		public static object Load(Type type, string id){
			
			IDbCommand selectDbCommand = App.Instance.DbConnection.CreateCommand();
			selectDbCommand.CommandText = GetSelect(type) + id;
			IDataReader dataReader = selectDbCommand.ExecuteReader();
			dataReader.Read(); //lee el primero
			
			
			object obj = Activator.CreateInstance(type);
			foreach (PropertyInfo propertyInfo in type.GetProperties()){
				if(propertyInfo.IsDefined (typeof(KeyAttribute), true))
					propertyInfo.SetValue(obj, id, null);
				else if (propertyInfo.IsDefined (typeof(FieldAttribute), true))
					propertyInfo.SetValue(obj, dataReader[propertyInfo.Name.ToLower()], null);
				
			}
			
			
			dataReader.Close();
//			Categoria categoria = new Categoria();
//			categoria.Id = int.Parse(id);
//			categoria.nombre = dataReader["nombre"].ToString();
//			dataReader.Close();
//			return categoria;
			return obj;
		}
		
		public static object Save(Type type, string id){
			
			IDbCommand selectDbCommand = App.Instance.DbConnection.CreateCommand();
			selectDbCommand.CommandText = GetSelect(type) + id;
			IDataReader dataReader = selectDbCommand.ExecuteReader();
			dataReader.Read(); //lee el primero
			
			
			object obj = Activator.CreateInstance(type);
			foreach (PropertyInfo propertyInfo in type.GetProperties()){
				if(propertyInfo.IsDefined (typeof(KeyAttribute), true))
					propertyInfo.SetValue(obj, id, null);
				else if (propertyInfo.IsDefined (typeof(FieldAttribute), true))
					propertyInfo.SetValue(obj, dataReader[propertyInfo.Name.ToLower()], null);
				
			}
			
			
			dataReader.Close();
//			Categoria categoria = new Categoria();
//			categoria.Id = int.Parse(id);
//			categoria.nombre = dataReader["nombre"].ToString();
//			dataReader.Close();
//			return categoria;
			return obj;
		}
		
	}
}

