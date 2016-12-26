using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace RDIFramework.WebCommon.GenericSort
{
    public class Comparer<T>: IComparer<T>
    {
        private List<SortClass> _sortClasses;
        public List<SortClass> SortClasses
        {
            get { return _sortClasses; }
        }

        public Comparer()
        {
            _sortClasses = new List<SortClass>();
        }

        public Comparer(List<SortClass> list)
        {
            _sortClasses = list;
        }

        public Comparer(string sortProperty, SortDirection sortDirection)
        {
            _sortClasses = new List<SortClass>();
            _sortClasses.Add(new SortClass(sortProperty, sortDirection));
        }

        public int Compare(T x, T y)
        {
            if (SortClasses.Count == 0)
                return 0;
            return CheckSort(0, x, y);
        }

        private int CheckSort(int sortLevel, T x, T y)
        {
            int returnVal = 0;
            if (SortClasses.Count - 1 == sortLevel)
            {
                Object valueOf1 = x.GetType().GetProperty(SortClasses[sortLevel].SortProperty).GetValue(x, null);
                Object valueOf2 = y.GetType().GetProperty(SortClasses[sortLevel].SortProperty).GetValue(y, null);

                if (SortClasses[sortLevel].SortDirection == SortDirection.Ascending)
                {
                    returnVal = ((IComparable)valueOf1).CompareTo((IComparable)valueOf2);
                }
                else
                {
                    returnVal = ((IComparable)valueOf2).CompareTo((IComparable)valueOf1);
                }

                if (returnVal == 0)
                {
                    returnVal = CheckSort(sortLevel + 1, x, y);
                }
            }

            return returnVal;
        }
    }
}
