using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Serpis.Ad
{


	public class ModelInfo
	{
		public string TableName { 
			get {return tableName;} 
		}
		private Type type;
		internal ModelInfo (Type type)
		{
			this.type = type;
			tableName = type.Name.ToLower ();
			fieldPropertyInfos=new List<PropertyInfo>();
			fieldNames=new List<string>();
			fieldNamesUpdate=new List<string>();
			fieldNamesSelect=new List<string>();
			fieldNamesInsert=new List<string>();
			

			foreach (PropertyInfo propertyInfo in type.GetProperties()) {
				if (propertyInfo.IsDefined (typeof(KeyAttribute), true)) {
					Console.WriteLine ( propertyInfo.Name);
					keyPropertyInfo = propertyInfo;
					keyName = propertyInfo.Name.ToLower ();
				} else if (propertyInfo.IsDefined (typeof(FieldAttribute), true)) {
					fieldPropertyInfos.Add (propertyInfo);
					fieldNames.Add (propertyInfo.Name.ToLower());
					fieldNamesUpdate.Add (formatparameter(propertyInfo.Name.ToLower()));
					fieldNamesInsert.Add (formatparameterSelect(propertyInfo.Name.ToLower()));
					fieldNamesSelect.Add (propertyInfo.Name.ToLower());
				}
			}
			insert = String.Format("insert into {0} ({1}) values ( {2} ) ",
			                       tableName,
			                       String.Join(", ",fieldNames),
			                       String.Join(", ",fieldNamesInsert));
			select = String.Format ("select {0} from {1} where {2}",
			                        String.Join(", ",fieldNamesSelect),
			                        tableName,
			                        formatparameter (keyName));
			update = String.Format("update {0} set {1} where {2}",
			                       tableName,
			                       String.Join(", ",fieldNamesUpdate),
			                       formatparameter (keyName));
		}

		internal ModelInfo(Type type, string id, string[]fields){

			this.type = type;
			tableName = type.Name.ToLower ();
			fieldPropertyInfos=new List<PropertyInfo>();
			fieldNames=new List<string>();
			fieldNamesUpdate=new List<string>();
			fieldNamesSelect=new List<string>();
			fieldNamesInsert=new List<string>();

			foreach (PropertyInfo propertyInfo in type.GetProperties()) {
				if (propertyInfo.Name.ToLower().Equals(id)) {
					Console.WriteLine ( propertyInfo.Name);
					keyPropertyInfo = propertyInfo;
					keyName = propertyInfo.Name.ToLower ();
				} 
				else
					for (int i = 0; i < fields.Length; i++) {
						if (propertyInfo.Name.ToLower().Equals (fields[i])) {
							fieldPropertyInfos.Add (propertyInfo);
							fieldNames.Add (propertyInfo.Name.ToLower());
							fieldNamesUpdate.Add (formatparameter(propertyInfo.Name.ToLower()));
							fieldNamesInsert.Add (formatparameterSelect(propertyInfo.Name.ToLower()));
							fieldNamesSelect.Add (propertyInfo.Name.ToLower());
						}
					}
			}

			insert = String.Format("insert into {0} ({1}) values ( {2} ) ",
			                     tableName,
			                     String.Join(", ",fieldNames),
			                     String.Join(", ",fieldNamesInsert));
			select = String.Format ("select {0} from {1} where {2}",
			                        string.Join(", ",fieldNamesSelect),
			                        tableName,
			                        formatparameter (keyName));
			update = String.Format("update {0} set {1} where {2}",
			                     tableName,
			                     String.Join(", ",fieldNamesUpdate),
			                     formatparameter (keyName));

		}

		private string tableName;
		private List<PropertyInfo> fieldPropertyInfos;
		private List<string> fieldNames;
		
		private List<string> fieldNamesUpdate;
		private List<string> fieldNamesSelect;
		private List<string> fieldNamesInsert;
		private string keyName;
		private PropertyInfo keyPropertyInfo;
		public PropertyInfo KeyPropertyInfo { get { return keyPropertyInfo; } }
		public string KeyName { get {return keyName;}}
		public PropertyInfo[] FieldPropertyInfos {get {return fieldPropertyInfos.ToArray();}}
		public string[] FieldNames {get {return fieldNames.ToArray();}}

		private string insert;
		public string InsertText{ 
			get { return insert; } 
		}
		private string update;
		public string UpdateText{ 
			get { return update; } 
		}
		private string select;
		public string SelectText{ 
			get { return select; } 
		}

		private static string formatparameter (string fiel){
			return string.Format("{0}=@{0}",fiel);
		}

		private static string formatparameterSelect (string fiel){
			return string.Format("@{0}",fiel);
		}
	}
}
