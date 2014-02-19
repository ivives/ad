using NUnit.Framework;
using System;
using System.Reflection;

namespace Serpis.Ad
{
	[TestFixture ()]
	internal class ModelInfoFoo
	{

		public ModelInfoFoo(int id, string nombre){
			this.Id = id;
			this.Nombre = nombre;
		}

		public ModelInfoFoo(){
		}

		[Key]
		public int Id {get;set;}

		[Field]
		public string Nombre {get;set;}
	}

	[TestFixture ()]
	internal class ModelInfoBar

	{
		public ModelInfoBar(int id, string nombre, decimal precio){
			this.Id = id;
			this.Nombre = nombre;
			this.Precio = precio;
		}

		public ModelInfoBar(){
		}

		[Key]
		public int Id {get;set;}

		[Field]
		public string Nombre {get;set;}

		[Field]
		public decimal Precio {get;set;}
	}

	[TestFixture ()]
	public class ModelInfoTest
	{
		[Test ()]
		public void TableName ()
		{
			ModelInfo modelInfo = ModelInfoStore.Get (typeof(ModelInfoFoo));
			Assert.AreEqual ("modelinfofoo", modelInfo.TableName);
		}

		[Test ()]
		public void KeyPropertyInfo(){
			ModelInfo modelInfo =  ModelInfoStore.Get (typeof(ModelInfoFoo));
			Assert.IsNotNull (modelInfo.KeyPropertyInfo);
			Assert.AreEqual ("Id", modelInfo.KeyPropertyInfo.Name);
		}

		[Test()]
		public void KeyName(){
			ModelInfo modelInfo =  ModelInfoStore.Get (typeof(ModelInfoFoo));
			Assert.AreEqual ("id", modelInfo.KeyName);
		}

		[Test()]
		public void FieldpropertyInfos(){
			ModelInfo modelInfo =  ModelInfoStore.Get (typeof(ModelInfoFoo)); 
			PropertyInfo[] fieldPropertyInfo = modelInfo.FieldPropertyInfos;
			Assert.AreEqual (1, fieldPropertyInfo.Length);

			modelInfo =  ModelInfoStore.Get (typeof(ModelInfoBar));
			PropertyInfo[] fieldPropertyInfo2 = modelInfo.FieldPropertyInfos;
			Assert.AreEqual (2, fieldPropertyInfo2.Length);
		}

		[Test()]
		public void FieldNames(){
			ModelInfo modelInfo = ModelInfoStore.Get (typeof(ModelInfoFoo)); 
			string[] fieldName = modelInfo.FieldNames;
			Assert.Contains ("nombre", fieldName);
			Assert.AreEqual (1, fieldName.Length);

		}

		[Test()]
		public void InsertText(){
			ModelInfo modelInfo =  ModelInfoStore.Get (typeof(ModelInfoFoo)); 
			
			Assert.AreEqual ("insert into modelinfofoo (nombre) values ( @nombre ) ",modelInfo.InsertText);
			modelInfo =  ModelInfoStore.Get (typeof(ModelInfoBar)); 
			
			Assert.AreEqual ("insert into modelinfobar (nombre, precio) values ( @nombre, @precio ) ",modelInfo.InsertText);

		}

		[Test()]
		public void UpdateText(){
			ModelInfo modelInfo =  ModelInfoStore.Get (typeof(ModelInfoFoo)); 
			
			Assert.AreEqual ("update modelinfofoo set nombre=@nombre where id=@id",modelInfo.UpdateText);
			modelInfo =  ModelInfoStore.Get (typeof(ModelInfoBar)); 
			
			Assert.AreEqual ("update modelinfobar set nombre=@nombre, precio=@precio where id=@id",modelInfo.UpdateText);

		}

		[Test()]
		public void SelectText(){
			ModelInfo modelInfo =  ModelInfoStore.Get (typeof(ModelInfoFoo)); 
			
			Assert.AreEqual ("select nombre from modelinfofoo where id=@id",modelInfo.SelectText);
			modelInfo =  ModelInfoStore.Get (typeof(ModelInfoBar)); 
			
			Assert.AreEqual ("select nombre, precio from modelinfobar where id=@id",modelInfo.SelectText);

		}


	}
}