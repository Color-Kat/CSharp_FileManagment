using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileManagment
{
    internal class Sorting<T>
    {
        public List<T> InsertingSort(List<T> items)
        {
            for(int i = 0; i < items.Count; i++) 
            {
                T currentItem = items[i];

                int j = i - 1;

                while (j >= 0 && CompareItems(items[j], currentItem) > 0) {
                    items[j + 1] = items[j];
                    j--;
                }

                items[j + 1] = currentItem;
            }

            return items;
        }

        protected virtual int CompareItems(T itemA, T itemB)
        {
            return -1;
        }
    }
}
