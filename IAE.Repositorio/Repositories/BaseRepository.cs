using IAE.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repository.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		public int Add(T item)
		{
			return -1;
		}

		public IList<int> AddList(IEnumerable<T> itens)
		{
			throw new NotImplementedException();
		}

		public int Delete(int id)
		{
			return -1;
		}

		public int DeleteItens(IEnumerable<int> ids)
		{
			throw new NotImplementedException();
		}

		public IList<T> FindAll()
		{
			throw new NotImplementedException();
		}

		public T FindById(int key)
		{
			throw new NotImplementedException();
		}

		public IList<T> FindByIds(int[] keys)
		{
			throw new NotImplementedException();
		}

		public T Update(T item)
		{
			throw new NotImplementedException();
		}
	}
}
