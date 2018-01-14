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
    class ChannelDao
    {
        DbConnection dbcon;

        public ChannelDao(DbConnection myDbcon)
        {
            if (myDbcon == null)
                dbcon = new DbConnection();
            else
                dbcon = myDbcon;
        }

        public List<ChannelData> GetAll()
        {
            List<ChannelData> listChannel = new List<ChannelData>();

            string sql = "SELECT CHANNEL, NAME, BROADCAST_KIND, RIP_ID, VIDEO_RATE, VOICE_RATE, REMARK, CREATE_DATE, UPDATE_DATE FROM CHANNEL ";

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
                ChannelData data = new ChannelData();

                data.Channel = DbExportCommon.GetDbInt(reader, 0);
                data.Name = DbExportCommon.GetDbString(reader, 1);
                data.BroadcastKind = DbExportCommon.GetDbString(reader, 2);
                data.RipId = DbExportCommon.GetDbString(reader, 3);
                data.VideoRate = DbExportCommon.GetDbString(reader, 4);
                data.VoiceRate = DbExportCommon.GetDbString(reader, 5);
                data.Remark = DbExportCommon.GetDbString(reader, 6);
                data.CreateDate = DbExportCommon.GetDbDateTime(reader, 8);
                data.UpdateDate = DbExportCommon.GetDbDateTime(reader, 9);

                listChannel.Add(data);
            }

            return listChannel;
        }

    }
}
