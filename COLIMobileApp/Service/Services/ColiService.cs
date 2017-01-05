using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Service
{
	public class ColiService : IColiService
	{
		HttpClient client;
		public List<Idioms> Items { get; private set;}

		public ColiService()
		{
			var authData = string.Format("{0}:{1}", Constant.Username, Constant.Password);
			var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));
			client = new HttpClient();
			client.MaxResponseContentBufferSize = Constant.BufferSize;
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
		}

		public async Task<List<Idioms>> RefreshIdiomsesAsync()
		{
			Items = new List<Idioms>();
			var uri = new Uri(string.Format(Constant.IdiomsesUrl, string.Empty));
			try
			{
				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					Items = JsonConvert.DeserializeObject<List<Idioms>>(content);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"trongan93-Error: {0}", ex.Message);
			}
			return Items;
		}

		public async Task DeleteIdiomsAsync(int id)
		{
			var uri = new Uri(string.Format("{0}/{1}", Constant.RemoveIdiomsUrl, id));
			try
			{
				var response = await client.DeleteAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"trongan93 - Sucessfully Delete");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"trongan93-ERROR {0}", ex.Message);
			}
		}

		public async Task SaveIdiomsAsync(Idioms idioms, bool isNewIdioms)
		{
				var uri = new Uri(string.Format("{0}/{1}", Constant.AddIdiomsUrl, idioms.Id));
			try
			{
				var json = JsonConvert.SerializeObject(idioms);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage response = null;
				if (isNewIdioms)
				{
					response = await client.PostAsync(uri, content);
				}
				else 
				{
					response = await client.PutAsync(uri, content);
				}
				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"trongan93-  Sucessfully Saved");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"trongan93-Error: {0}", ex.Message);
			}
		}
	}
}
