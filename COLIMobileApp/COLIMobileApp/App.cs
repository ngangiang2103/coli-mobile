using System;
using Service;
using Xamarin.Forms;

namespace COLIMobileApp
{
	public class App : Application
	{
		public static ColiServiceManager ServiceManager { get; private set; }

		public static ITextToSpeech Speech { get; set; }

		public App()
		{
			ServiceManager = new ColiServiceManager(new ColiService());
			MainPage = new NavigationPage(new COLIMobileAppPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
