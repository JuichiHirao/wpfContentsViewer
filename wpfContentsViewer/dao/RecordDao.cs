using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfContentsViewer.common;
using wpfContentsViewer.data;

namespace wpfContentsViewer.dao
{
    class RecordDao
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        DbConnection dbcon;
        public RecordDao(DbConnection myDbcon)
        {
            if (myDbcon == null)
                dbcon = new DbConnection();
            else
                dbcon = myDbcon;
        }
        public List<Record> GetAll()
        {
            List<Record> listRecord = new List<Record>();

            string sql = "SELECT R.ID, R.DISK, R.SEQ, R.STATUS, R.ON_AIR_DATE, R.PROGRAM_ID, R.DURATION, R.DETAIL, R.CREATE_DATE, R.UPDATE_DATE, P.NAME "
                        + "FROM RECORD R "
                        + "  LEFT JOIN PROGRAM P "
                        + "    ON R.PROGRAM_ID = P.CHANNEL_ID ";

            dbcon.openConnection();

            SqlCommand command = new SqlCommand();

            command = new SqlCommand(sql, dbcon.getSqlConnection());

            SqlDataReader reader = dbcon.GetExecuteReader(sql);

            if (reader.IsClosed)
            {
                throw new Exception("arrear.TargetAccountDataの取得でreaderがクローズされています");
            }

            while (reader.Read())
            {
                Record data = new Record();

                data.Id = DbExportCommon.GetDbInt(reader, 0);
                data.Disk = DbExportCommon.GetDbString(reader, 1);
                data.Seq = DbExportCommon.GetDbString(reader, 2);
                data.RipStatus = DbExportCommon.GetDbString(reader, 3);
                data.OnAirDate = DbExportCommon.GetDbDateTime(reader, 4);
                data.ProgramId = DbExportCommon.GetDbString(reader, 5);
                data.Duration = DbExportCommon.GetDbString(reader, 6);
                data.Detail = DbExportCommon.GetDbString(reader, 7);
                data.CreateDate = DbExportCommon.GetDbDateTime(reader, 8);
                data.UpdateDate = DbExportCommon.GetDbDateTime(reader, 9);
                data.ProgramName = DbExportCommon.GetDbString(reader, 10);

                listRecord.Add(data);
            }

            return listRecord;
        }

    }
}
