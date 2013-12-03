using System;
using Gtk;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		Console.WriteLine("Initial notebook.CurrentPage={0}", notebook.CurrentPage);
		
		notebook.SwitchPage += delegate {
			Console.WriteLine("SwitchPage notebook.CurrentPage={0}", notebook.CurrentPage);
		};
		
		notebook.PageRemoved += delegate {
			Console.WriteLine("PageRemoved notebook.CurrentPage={0}", notebook.CurrentPage);
			
		};
		
		foreach (string stockId in new string[]{Stock.Add, Stock.Close, Stock.Edit}) {
			Button button = new Button(stockId);
			button.Visible = true;
			
			HBox hBox = new HBox();
			Label label = new Label("Pestaña " + stockId);
			hBox.Add (label);
			label.Visible = true;
			Button buttonTap = new Button();
			buttonTap.Image = Image.NewFromIconName (Stock.Close, IconSize.Button);
			buttonTap.Visible = true;
			hBox.Add (buttonTap);
			notebook.AppendPage (button, hBox);
			
			buttonTap.Clicked += delegate {
				button.Destroy();
			};
		}
		
		mainButton.Clicked += delegate {
			Console.WriteLine("Current notebook.CurrentPage={0}", notebook.CurrentPage);
			
		};
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
