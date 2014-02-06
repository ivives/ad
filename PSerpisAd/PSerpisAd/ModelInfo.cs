using System;
using System.Collections.Generic;
using System.Reflection;

namespace Serpis.Ad
{
	public class ModelInfo
	{
		
		private Type type;
		public ModelInfo (Type type){
			this.type = type;
			tableName = type.Name.ToLower();
			
			fieldPropertyInfos = new List<PropertyInfo>();
			fieldNames = new List<string>();
			
			foreach (PropertyInfo propertyInfo in type.GetProperties())
				if(propertyInfo.IsDefined (typeof(KeyAttribute), true)){
					keyPropertyInfo = propertyInfo;
					keyName = propertyInfo.Name.ToLower();
				
				}else if (propertyInfo.IsDefined(typeof(FieldAttribute), true)){
					fieldPropertyInfos.Add(propertyInfo);
					fieldNames.Add(propertyInfo.Name.ToLower());
				}
		}
		
		
		private string tableName;
		public string TableName {get {return tableName;}}
				
		private PropertyInfo keyPropertyInfo;
		public PropertyInfo KeyPropertyInfo {get {return keyPropertyInfo;}}
		
		private string keyName;
		public string KeyName {get {return keyName;}}
		
		private List<PropertyInfo> fieldPropertyInfos;
		public PropertyInfo[] FieldPropertyInfos {get {return fieldPropertyInfos.ToArray();}}
		
		private List<string> fieldNames;
		public string[] FieldNames {get {return fieldNames.ToArray();}}
		
	}
}

