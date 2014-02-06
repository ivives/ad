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
			ModelInfo modelInfo = new ModelInfo(typeof(ModelInfoFoo));
			Assert.AreEqual ("modelinfofoo", modelInfo.TableName);
		}
				
		[Test]
		public void KeyPropertyInfo() {
			ModelInfo modelInfo = new ModelInfo(typeof(ModelInfoFoo));
			Assert.IsNotNull(modelInfo.KeyPropertyInfo);
			Assert.AreEqual("Id", modelInfo.KeyPropertyInfo.Name);
			
		}
		
		[Test]
		public void KeyName(){
			ModelInfo modelInfo = new ModelInfo(typeof(ModelInfoFoo));
			Assert.AreEqual ("id", modelInfo.KeyName);
		}
		
		[Test]
		public void FieldPropertyInfos(){
			ModelInfo modelInfo = new ModelInfo(typeof(ModelInfoFoo));
			PropertyInfo[] fieldPropertyInfos = modelInfo.FieldPropertyInfos;
			Assert.AreEqual(1, fieldPropertyInfos.Length);
						
			modelInfo = new ModelInfo(typeof(ModelInfoBar));
			fieldPropertyInfos = modelInfo.FieldPropertyInfos;
			Assert.AreEqual(2, fieldPropertyInfos.Length);
		}
		
		
		[Test]
		public void FieldNames(){
			ModelInfo modelInfo = new ModelInfo(typeof(ModelInfoFoo));
			string[] fieldNames = modelInfo.FieldNames;
			Assert.AreEqual(1, fieldNames.Length);
			Assert.Contains("nombre", fieldNames);
			
			modelInfo = new ModelInfo(typeof(ModelInfoBar));
			fieldNames = modelInfo.FieldNames;
			Assert.AreEqual(2, fieldNames.Length);
			Assert.Contains("nombre", fieldNames);
			Assert.Contains("precio", fieldNames);
		}
		
	}
	
	
	
}

