using System;
using System.Diagnostics;
using Service;
using Xamarin.Forms;

namespace COLIMobileApp
{
	public partial class COLIMobileAppPage : ContentPage
	{
		bool alertShown = false;
		public COLIMobileAppPage()
		{
			InitializeComponent();
		}
		protected async override void OnAppearing()
		{
			base.OnAppearing();
			if (Service.Constant.RestUrl.Contains("http://api.dealbinhdinh.com/api/"))
			{
				if (!alertShown)
				{
					await DisplayAlert("Hosted Back-end", "This app is running against trongan93's Service.", "OK");
					alertShown = true;
				}
			}
			listView.ItemsSource = await App.ServiceManager.GetTaskIdiomAsync();
		}

		void OnAddItemClicked(object sender, EventArgs e)
		{
			var idioms = new Idioms()
			{
				Id = Guid.NewGuid().ToString()
			};
			//Blank and open Item View 
			//::TODO:: - noted by trongan93
		}
		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var idiomsItem = e.SelectedItem as Idioms;
			//Blank and open Item View 
			//::TODO:: - noted by trongan93
		}
	}
}
