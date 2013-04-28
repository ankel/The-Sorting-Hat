using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSortingHat {
    public interface ISortable<T> where T:IComparable<T> {
        void Sort ( T[] arr ); 
    }
}
