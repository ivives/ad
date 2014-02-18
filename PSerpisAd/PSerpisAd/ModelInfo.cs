using System;
using System.Collections.Generic;
using System.Reflection;

namespace Serpis.Ad
{
	public class ModelInfo
	{
		
		private Type type;
		internal ModelInfo (Type type){
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
			
			setUpdateText();
			
			setInsertText();
			
			setSelectText();
			
		}
		
		private void setUpdateText(){
			
			List<string> fieldParameters = new List<string>();
			foreach (string fieldName in fieldNames)
				fieldParameters.Add(fieldName + "=@" + fieldName);
			
			updateText = string.Format( "update {0} set {1} where {2}", 
			                           tableName, 
			                           string.Join(", ", fieldNames), 
			                           keyName +  "=@" + keyName);
		}
		
		private void setInsertText(){
			
			List<string> fieldParameters = new List<string>();
			foreach (string fieldName in fieldNames)
				fieldParameters.Add(fieldName);
			
			insertText = string.Format("insert into {0} ({1}) values ({2})",
			                           tableName,
			                           string.Join(", ", fieldNames),
			                           string.Join(", ", fieldParameters));
		}
		
		private void setSelectText(){
			
			List<string> fieldParameters = new List<string>();
			foreach (string fieldName in fieldNames)
				fieldParameters.Add(fieldName);
			
			selectText = string.Format("select {0} from {1} where {2}=",
			                           string.Join(", ", fieldNames), 
			                           tableName, 
			                           keyName +  "=@" + keyName);
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
		
		private string updateText;
		public string UpdateText {get {return updateText;}}
		
		private string insertText;
		public string InsertText {get {return insertText;}}
		
		// insert into articulo (nombre, precio, categoria) values (@nombre, @precio, @categoria)
		
		private string selectText;
		public string SelectText {get {return selectText;}}
	}
}

