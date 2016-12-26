using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace RDIFramework.WebCommon.GenericSort
{
    public class ListSorter
    {
        public static List<T> SortList<T>(List<T> listToSort, List<string> sortExpression, List<SortDirection> sortDirection)
        {
            if (sortExpression.Count != sortDirection.Count ||
                sortExpression.Count == 0 ||
                sortDirection.Count == 0)
            {
                throw new Exception("Invalid sort arguments!");
            }

            Comparer<T> myComparer = new Comparer<T>();
            for (int i = 0; i < sortExpression.Count; i++)
            {
                SortClass sortClass = new SortClass(sortExpression[i], sortDirection[i]);
                myComparer.SortClasses.Add(sortClass);
            }

            listToSort.Sort(myComparer);
            return listToSort;
        }

        public static List<T> SortList<T>(List<T> listToSort, string sortExpression, SortDirection sortDirection)
        {
            if (string.IsNullOrEmpty(sortExpression))
                return listToSort;

            Comparer<T> myComparer = new Comparer<T>();
            myComparer.SortClasses.Add(new SortClass(sortExpression, sortDirection));
            listToSort.Sort(myComparer);
            return listToSort;
        }
    }
}
