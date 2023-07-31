using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAE.Repository.Interfaces
{
	public interface IBaseRepository<T> where T : class
	{
		IList<T> FindAll();
		T FindById(int key);
		IList<T> FindByIds(int[] keys);

		int Add(T item);
		IList<int> AddList(IEnumerable<T> itens);

		T Update(T item);

		int Delete (int id);
		int DeleteItens(IEnumerable<int> ids);
	}
}
