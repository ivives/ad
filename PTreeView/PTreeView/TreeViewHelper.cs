using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Serpis.Ad
{
	public class TreeViewHelper
	{
		
		private TreeView treeView;
		private ListStore listStore;
		public TreeViewHelper (TreeView treeView, MySqlConnection mySqlConnection, string selectSql)
		{
			
			this.treeView = treeView;
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand ();
			mySqlCommand.CommandText = selectSql;
				
			MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
			
			string[] columnNames = getColumnNames(mySqlDataReader);
			
			appendColumns(columnNames);
			
			listStore = createListStore(mySqlDataReader.FieldCount);
	
			while (mySqlDataReader.Read ()) {
				List<string> values = new List<string>();
				for (int index = 0; index < mySqlDataReader.FieldCount; index++)
					values.Add ( mySqlDataReader.GetValue (index).ToString() );
				listStore.AppendValues(values.ToArray());
			}
			mySqlDataReader.Close ();
			
			treeView.Model = listStore;
			
		}
		
		public ListStore ListStore{
			get {return listStore;}
		}
		
		
		private string[] getColumnNames(MySqlDataReader mySqlDataReader) {
			List<string> columnNames = new List<string>();
			for (int index = 0; index < mySqlDataReader.FieldCount; index++)
				columnNames.Add (mySqlDataReader.GetName (index));
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

