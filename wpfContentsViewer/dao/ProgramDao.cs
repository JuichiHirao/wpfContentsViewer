using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpfContentsViewer.common;
using wpfContentsViewer.data;

namespace wpfContentsViewer.dao
{
    class ProgramDao
    {
        DbConnection dbcon;

        public ProgramDao(DbConnection myDbcon)
        {
            if (myDbcon == null)
                dbcon = new DbConnection();
            else
                dbcon = myDbcon;
        }

        public List<Program> GetAll()
        {
            List<Program> listProgram = new List<Program>();

            string sql = "SELECT CHANNEL_ID, NAME, ABBREVIATION_NAME, RELATION_ID, ON_AIR_START, ON_AIR_END, DETAIL, REMARK, CREATE_DATE, UPDATE_DATE FROM PROGRAM ";

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
                Program data = new Program();

                data.ChannelId = DbExportCommon.GetDbString(reader, 0);
                data.Name = DbExportCommon.GetDbString(reader, 1);
                data.AbbreviationName = DbExportCommon.GetDbString(reader, 2);
                data.RelationId = DbExportCommon.GetDbString(reader, 3);
                data.OnAirStart = DbExportCommon.GetDbDateTime(reader, 4);
                data.OnAirEnd = DbExportCommon.GetDbDateTime(reader, 5);
                data.Detail = DbExportCommon.GetDbString(reader, 7);
                data.CreateDate = DbExportCommon.GetDbDateTime(reader, 8);
                data.UpdateDate = DbExportCommon.GetDbDateTime(reader, 9);

                listProgram.Add(data);
            }

            return listProgram;
        }

    }
}
