using System;
using System.Reflection;
using NUnit.Framework;

namespace Serpis.Ad
{
	
	internal class ModelInfoFoo 
	{
		[Key]
		public int Id {get;set;}
		
		[Field]
		public string Nombre {get;set;}
		
	}

	
	internal class ModelInfoBar
	{
		[Key]
		public int Id {get;set;}
		
		[Field]
		public string Nombre {get;set;}
		
		[Field]
		public decimal Precio {get;set;}
		
	}
	
	
	[TestFixture]
	public class ModelInfoTest
	{
		[Test]
		public void TableName () {
			ModelInfo modelInfo = ModelInfoStore.Get(typeof(ModelInfoFoo));
			Assert.AreEqual ("modelinfofoo", modelInfo.TableName);
		}
				
		[Test]
		public void KeyPropertyInfo() {
			ModelInfo modelInfo = ModelInfoStore.Get(typeof(ModelInfoFoo));
			Assert.IsNotNull(modelInfo.KeyPropertyInfo);
			Assert.AreEqual("Id", modelInfo.KeyPropertyInfo.Name);
			
		}
		
		[Test]
		public void KeyName(){
			ModelInfo modelInfo = ModelInfoStore.Get(typeof(ModelInfoFoo));
			Assert.AreEqual ("id", modelInfo.KeyName);
		}
		
		[Test]
		public void FieldPropertyInfos(){
			ModelInfo modelInfo = ModelInfoStore.Get(typeof(ModelInfoFoo));
			PropertyInfo[] fieldPropertyInfos = modelInfo.FieldPropertyInfos;
			Assert.AreEqual(1, fieldPropertyInfos.Length);
						
			modelInfo = ModelInfoStore.Get(typeof(ModelInfoBar));
			fieldPropertyInfos = modelInfo.FieldPropertyInfos;
			Assert.AreEqual(2, fieldPropertyInfos.Length);
		}
		
		
		[Test]
		public void FieldNames(){
			ModelInfo modelInfo = ModelInfoStore.Get(typeof(ModelInfoFoo));
			string[] fieldNames = modelInfo.FieldNames;
			Assert.AreEqual(1, fieldNames.Length);
			Assert.Contains("nombre", fieldNames);
			
			modelInfo = ModelInfoStore.Get(typeof(ModelInfoBar));
			fieldNames = modelInfo.FieldNames;
			Assert.AreEqual(2, fieldNames.Length);
			Assert.Contains("nombre", fieldNames);
			Assert.Contains("precio", fieldNames);
		}
		
		
		[Test]
		public void UpdateText(){
			ModelInfo modelInfo = ModelInfoStore.Get(typeof(ModelInfoFoo));
			Assert.AreEqual("update modelinfofoo set nombre=@nombre where id=@id", modelInfo.UpdateText);
			
			modelInfo = ModelInfoStore.Get(typeof(ModelInfoBar));
			Assert.AreEqual("update modelinfobar set nombre=@nombre, precio=@precio where id=@id", modelInfo.UpdateText);
			
			
		}
		
		
		[Test]
		public void InsertText(){
			ModelInfo modelInfo = ModelInfoStore.Get(typeof(ModelInfoFoo));
			Assert.AreEqual("insert into modelinfofoo values nombre=@nombre", modelInfo.InsertText);
		}
		
	}
	
	
	
}

