using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfContentsViewer.common;
using wpfContentsViewer.dao;
using wpfContentsViewer.data;

namespace wpfContentsViewer.service
{
    class ProgramService
    {
        ProgramDao dao;

        public ProgramService()
        {
            dao = new ProgramDao(null);
        }

        public ProgramService(DbConnection myDbCon)
        {
            dao = new ProgramDao(myDbCon);
        }

        public List<Program> GetAll()
        {
            return dao.GetAll();
        }
    }
}
