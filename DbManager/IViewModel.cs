
using System.Collections.Generic;


namespace DbManager
{
    public interface IViewModel<K>
    {
        IEnumerable<K> ViewModelList();
    }

    

  
}
