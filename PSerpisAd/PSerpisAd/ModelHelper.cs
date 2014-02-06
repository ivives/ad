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
		
		
		private static string formatParameter(string field){
		
			return string.Format("{0}=@{0}", field);
			
		}
		
		public static string GetUpdate(Type type){
		
			string KeyParameter = null;
			List<string> fieldParameters = new List<string>();
			foreach (PropertyInfo propertyInfo in type.GetProperties()){
			
				if (propertyInfo.IsDefined(typeof(KeyAttribute), true))
					KeyParameter = formatParameter(propertyInfo.Name.ToLower());
				else if (propertyInfo.IsDefined (typeof(FieldAttribute), true))
					fieldParameters.Add (formatParameter(propertyInfo.Name.ToLower()));
			}
			
			string tableName = type.Name.ToLower();
			
			return string.Format("update {0} set {1}  where {2}=",
			                     tableName, string.Join(", ", fieldParameters), KeyParameter);//comprobar
		}
		
		public static string GetInsert(Type type, string values){
			
//				string keyName = null;
			List<string> fieldNames = new List<string>();
			foreach (PropertyInfo propertyInfo in type.GetProperties()){
//				if(propertyInfo.IsDefined (typeof(KeyAttribute), true))
//					keyName = propertyInfo.Name.ToLower();
				//else 
					if (propertyInfo.IsDefined (typeof(FieldAttribute), true))
					fieldNames.Add (propertyInfo.Name.ToLower());
				
			}
			
			string tableName = type.Name.ToLower();
			
			return string.Format("insert into {0} ({1}) values ({2})", 
			                     tableName, string.Join(", ", fieldNames),  values );
		}
		
		
		
		public static object Load(Type type, string id){
			
			IDbCommand selectDbCommand = App.Instance.DbConnection.CreateCommand();
			selectDbCommand.CommandText = GetSelect(type) + id;
			IDataReader dataReader = selectDbCommand.ExecuteReader();
			dataReader.Read(); //lee el primero
			
			object obj = Activator.CreateInstance(type);
			foreach (PropertyInfo propertyInfo in type.GetProperties()){
				if(propertyInfo.IsDefined (typeof(KeyAttribute), true))
					propertyInfo.SetValue(obj, id, null);//falta convertir al tipo
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
		
		
		public static void Save(object obj){
			
			IDbCommand updateDbCommand = App.Instance.DbConnection.CreateCommand();
			Type type = obj.GetType();
			updateDbCommand.CommandText = GetUpdate(type);
			
			foreach (PropertyInfo propertyInfo in type.GetProperties()){
				if(propertyInfo.IsDefined (typeof(KeyAttribute), true)
					|| propertyInfo.IsDefined (typeof(FieldAttribute), true)){
					
					object value = propertyInfo.GetValue(obj, null);
					DbCommandUtil.AddParameter(updateDbCommand, propertyInfo.Name.ToLower(), value);
				}
				updateDbCommand.ExecuteNonQuery();
				
			}
			
		}
		
		
		public static void Insert(object obj){
			
			
			
		}
	
		
		
	}
}

