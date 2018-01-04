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

        List<int> SearchProgramIds = null;
        List<string> SearchFreeWords = null;

        public ProgramCollection(List<Program> myProgramList)
        {
            listContents = myProgramList;
            collecion = CollectionViewSource.GetDefaultView(listContents);
            collecion.SortDescriptions.Clear();
            collecion.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Descending));
        }

        public void SetSearchText(string mySearchText)
        {
            string[] words = mySearchText.Split(' ');

            int SearchDisk = -1;

            foreach (string w in words)
            {
                if (w.IndexOf("P") == 0)
                {
                    SearchProgramIds = new List<int>();
                    string[] ids = w.Substring(1).Split(',');

                    if (ids != null && ids.Length > 0)
                    {
                        foreach (string i in ids)
                        {
                            try
                            {
                                SearchProgramIds.Add(Convert.ToInt32(i));
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                }
                else
                {
                    if (SearchFreeWords == null)
                        SearchFreeWords = new List<string>();
                    SearchFreeWords.Add(w);
                }
            }
        }

        public void Execute()
        {
            bool IsFilterFreeWords = false;
            bool IsFilterProgramIds = false;

            if (SearchFreeWords != null)
                IsFilterFreeWords = true;
            if (SearchProgramIds != null)
                IsFilterProgramIds = true;

            collecion.Filter = delegate (object o)
            {
                Record data = o as Record;
                if (IsFilterFreeWords || IsFilterProgramIds)
                {
                    if (IsFilterFreeWords)
                    {
                        bool r = false;
                        foreach (string s in SearchFreeWords)
                        {
                            if (data.Detail.IndexOf(s) >= 0)
                                r = true;
                        }
                        if (r == false)
                            return r;
                    }
                    if (IsFilterProgramIds)
                    {
                        bool r = false;
                        int pid = 0;
                        if (data.ProgramId != null && data.ProgramId.Length > 0)
                        {
                            pid = Convert.ToInt32(data.ProgramId);
                        }
                        foreach (int id in SearchProgramIds)
                        {
                            if (pid == id)
                                r = true;
                        }
                        if (r == false)
                            return r;
                    }
                }

                return true;
            };
        }
    }
}
