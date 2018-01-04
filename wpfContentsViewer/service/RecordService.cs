using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfContentsViewer.collection;
using wpfContentsViewer.common;
using wpfContentsViewer.dao;
using wpfContentsViewer.data;

namespace wpfContentsViewer.service
{
    public class RecordService
    {
        RecordDao dao;

        public RecordService()
        {
            dao = new RecordDao(null);
        }

        public  RecordService(DbConnection myDbCon)
        {
            dao = new RecordDao(myDbCon);
        }

        public List<Record> GetAll()
        {
            return dao.GetAll();
        }
    }
}
