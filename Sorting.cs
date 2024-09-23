using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFileManagment
{
    internal abstract class Sorting<T>
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

        public int BinarySearch(List<T> items, T targetItem, TextBox err)
        {

            int left = 0;
            int right = items.Count;

            while(left <= right)
            {

                int middle = (left + right) / 2;


                // string currentKey = GenerateSearchKeyFromRecord(items[middle]);

                // int comparisonResult = string.Compare(currentKey, searchString, StringComparison.OrdinalIgnoreCase)
                int comparisonResult = CompareItems(items[middle], targetItem);

                if(comparisonResult == 0)
                {
                    return middle; // Founded
                }
                else if(comparisonResult < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return -1;
        }

        public int BinarySearchSubstring(List<T> items, string searchString, TextBox err)
        {

            int left = 0;
            int right = items.Count;

            try
            {
                while (left <= right)
                {
                    int middle = (left + right) / 2;

                    string currentKey = GenerateSearchKeyFromRecord(items[middle]);

                    // Founded
                    if (currentKey.Contains(searchString)) return middle;

                    int comparisonResult = string.Compare(currentKey, searchString, StringComparison.OrdinalIgnoreCase);

                    if (comparisonResult == 0)
                    {
                        return middle; // Founded
                    }
                    else if (comparisonResult < 0)
                    {
                        left = middle + 1;
                    }
                    else
                    {
                        right = middle - 1;
                    }
                }
            } catch (Exception e)
            {
                return -1;
            }

            return -1;
        }

        protected virtual string GenerateSearchKeyFromRecord(T item)
        {
            return "";
        }
    }
}
