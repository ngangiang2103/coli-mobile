using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
	public interface IColiService
	{
		Task<List<Idioms>> RefreshIdiomsesAsync();
		Task SaveIdiomsAsync(Idioms idioms, bool isNewIdioms);
		Task DeleteIdiomsAsync(int id);
	}
}
