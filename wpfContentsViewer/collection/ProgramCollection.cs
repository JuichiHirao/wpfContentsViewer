using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using wpfContentsViewer.data;

namespace wpfContentsViewer.collection
{
    class ProgramCollection
    {
        public List<Program> listContents;
        public ICollectionView collecion;

        List<string> SearchFreeWords = null;

        public ProgramCollection(List<Program> myProgramList)
        {
            listContents = myProgramList;
            collecion = CollectionViewSource.GetDefaultView(listContents);
            collecion.SortDescriptions.Clear();
            collecion.SortDescriptions.Add(new SortDescription("ChannelId", ListSortDirection.Ascending));
        }

        public void SetSearchText(string mySearchText)
        {
            SearchFreeWords = null;
            string[] words = mySearchText.Split(' ');

            foreach (string w in words)
            {
                if (SearchFreeWords == null)
                    SearchFreeWords = new List<string>();
                SearchFreeWords.Add(w);
            }
        }

        public void Execute()
        {
            collecion.Filter = null;
            bool IsFilterFreeWords = false;

            if (SearchFreeWords != null)
                IsFilterFreeWords = true;

            collecion.Filter = delegate (object o)
            {
                Program data = o as Program;
                if (IsFilterFreeWords)
                {
                    int m = 0;
                    foreach (string s in SearchFreeWords)
                    {
                        if (data.Name.IndexOf(s) >= 0)
                            m++;
                    }
                    if (m >= SearchFreeWords.Count)
                        return true;
                }

                return false;
            };
        }
    }
}
