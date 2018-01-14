using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfContentsViewer.common;
using wpfContentsViewer.dao;
using wpfContentsViewer.data;

namespace wpfContentsViewer.service
{
    class ChannelService
    {
        ChannelDao dao;

        public ChannelService()
        {
            dao = new ChannelDao(null);
        }

        public ChannelService(DbConnection myDbCon)
        {
            dao = new ChannelDao(myDbCon);
        }

        public List<ChannelData> GetAll()
        {
            return dao.GetAll();
        }

    }
}
