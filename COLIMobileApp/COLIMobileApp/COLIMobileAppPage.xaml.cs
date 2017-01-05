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
		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (Service.Constant.RestUrl.Contains("http://api.dealbinhdinh.com/api/"))
			{
				if (!alertShown)
				{
					//await DisplayAlert("Hosted Back-end", "This app is running against trongan93's Service.", "OK");
					alertShown = true;
				}
			}
			listView.ItemsSource = await 
		}
	}
}
