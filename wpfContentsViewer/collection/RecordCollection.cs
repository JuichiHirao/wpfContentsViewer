using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using wpfContentsViewer.data;
using wpfContentsViewer.service;

namespace wpfContentsViewer.collection
{
    public class RecordCollection
    {
        public List<Record> listContents;
        public ICollectionView collecion;

        List<int> SearchProgramIds = null;
        List<string> SearchFreeWords = null;
        string SearchChannel = null;

        public RecordCollection(List<Record> myRecordList)
        {
            listContents = myRecordList;
            collecion = CollectionViewSource.GetDefaultView(listContents);
            collecion.SortDescriptions.Clear();
            collecion.SortDescriptions.Add(new SortDescription("Id", ListSortDirection.Descending));
        }

        public void SetSearchText(string mySearchText)
        {
            string[] words = mySearchText.Split(' ');

            foreach(string w in words)
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
                else if (w.IndexOf("C") == 0)
                    SearchChannel = w.Substring(1);
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
                if (SearchChannel != null && SearchChannel.Length > 0)
                {
                    if (data.ProgramId != null && data.ProgramId.Length > 0)
                    {
                        if (data.ProgramId.IndexOf(SearchChannel) == 0)
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else if (IsFilterFreeWords || IsFilterProgramIds)
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
