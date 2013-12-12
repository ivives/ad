using Gtk;
using System;
using System.Collections.Generic;
using System.Data;

namespace Serpis.Ad
{
	public class TreeViewHelper
	{
		private TreeView treeView;
		private ListStore listStore;
		private IDbCommand dbCommand;
		
		public TreeViewHelper (TreeView treeView, IDbConnection dbConnection, string selectSql){
			this.treeView = treeView;
			dbCommand = dbConnection.CreateCommand ();
			dbCommand.CommandText = selectSql;
			IDataReader dataReader = dbCommand.ExecuteReader();
			string[] columnNames = getColumnNames(dataReader);
			appendColumns(columnNames);
			listStore = createListStore(dataReader.FieldCount);
			fillListStore (dataReader);
			dataReader.Close ();
			treeView.Model = listStore;
		}
		
		public ListStore ListStore {
			get {return listStore;}
		}
		
		//relleno el listStore
		private void fillListStore(IDataReader dataReader){
			while (dataReader.Read ()) {
				List<string> values = new List<string>();
				for (int index = 0; index < dataReader.FieldCount; index++)
					values.Add ( dataReader.GetValue (index).ToString() );
				listStore.AppendValues(values.ToArray());
			}
		}
		
		public void Refresh(){
			listStore.Clear();

			IDataReader dataReader = dbCommand.ExecuteReader();
			fillListStore (dataReader);
			
			dataReader.Close ();
								
		}
		
		
//		private int idColumnIndex = 0;
//		public int IdColumnIndex {
//			get {return idColumnIndex;}
//			set {idColumnIndex = value;}
//		}
		
		/// <summary>
		/// Devuelve el Id del registro seleccionado o string.Empty si no hay ninguno seleccionado
		/// Nota: suponemos que esta en la column de index 0.
		/// </summary>
				
		public string Id {
			get{
				TreeIter treeIter ;
				if (treeView.Selection.GetSelected(out treeIter)){
					return	listStore.GetValue(treeIter, 0).ToString(); //Id suponemos que la column 0
				}return string.Empty;
			}
		}
		
		public bool HasSelected{
			get{
				//TODO implementar
				throw new NotImplementedException();
			}
		}
		
		//TODO imlementar
		public event EventHandler Changed;
		
		
		
		private string[] getColumnNames(IDataReader dataReader) {
			List<string> columnNames = new List<string>();
			for (int index = 0; index < dataReader.FieldCount; index++)
				columnNames.Add (dataReader.GetName (index));
			return columnNames.ToArray ();
		}
	
		private void appendColumns(string[] columnNames) {
			int index = 0;
			foreach (string columnName in columnNames) 
				treeView.AppendColumn (columnName, new CellRendererText(), "text", index++);
		}
		
		private ListStore createListStore(int fieldCount) {
			Type[] types = new Type[fieldCount];
			for (int index = 0; index < fieldCount; index++)
				types[index] = typeof(string);
			return new ListStore(types);
		}
	}
}

