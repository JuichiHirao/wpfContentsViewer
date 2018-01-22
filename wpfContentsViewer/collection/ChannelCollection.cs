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
    class ChannelCollection
    {
        public List<ChannelData> listContents;
        public ICollectionView collecion;

        public ChannelCollection(List<ChannelData> myChannelList)
        {
            listContents = myChannelList;
            collecion = CollectionViewSource.GetDefaultView(listContents);
            collecion.SortDescriptions.Clear();
            collecion.SortDescriptions.Add(new SortDescription("Channel", ListSortDirection.Ascending));
        }

        public ChannelData GetByChannel(int myId)
        {
            foreach (ChannelData c in listContents)
            {
                if (c.Channel == myId)
                    return c;
            }

            return null;
        }

    }
}
