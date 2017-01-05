using System;
namespace Service
{
	public static class Constant
	{
		//URL of REST Service 
		public static string RestUrl = "http://api.dealbinhdinh.com/api/";
		public static string IdiomsesUrl = string.Format("{0}Idiomese", RestUrl);
		public static string AddIdiomsUrl = string.Format("{0}Idioms/Add/", RestUrl);
		public static string RemoveIdiomsUrl = string.Format("{0}Idioms/Remove", RestUrl);

		//Credentials that are hard coded into the REST service 
		public static string Username = "trongan93";
		public static string Password = "Abcd1234%";
		public static int BufferSize = 256000;
	}
}
