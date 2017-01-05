using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
	public class ColiServiceManager
	{
		IColiService _coliService;

		public ColiServiceManager(IColiService coliService)
		{
			_coliService = coliService;
		}
		public Task<List<Idioms>> GetTaskIdiomAsync()
		{
			return _coliService.RefreshIdiomsesAsync();
		}
		public Task SaveTaskIdiomAsync(Idioms item, bool isNewItem = false)
		{
			return _coliService.SaveIdiomsAsync(item, isNewItem);
		}
		public Task DeleteTaskAsync(Idioms item) 
		{
			return _coliService.DeleteIdiomsAsync(item.Id);
		}

	}
}
