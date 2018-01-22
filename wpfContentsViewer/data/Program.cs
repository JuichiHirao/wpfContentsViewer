using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfContentsViewer.data
{
    class Program
    {
        public Program()
        {
            Remark = "";
        }

        public int GetChannel()
        {
            if (ChannelId.Length > 0)
            {
                int cid = Convert.ToInt32(ChannelId);
                return cid / 1000;
            }

            return -1;
        }

        public string ChannelId { get; set; }

        public string Name { get; set; }

        public string AbbreviationName { get; set; }

        public string Kind { get; set; }

        public string DateKind { get; set; }

        public string RelationId { get; set; }

        public DateTime OnAirStart { get; set; }

        public DateTime OnAirEnd { get; set; }

        public string Detail { get; set; }

        public string Remark { get; set; }

        public void SetOnAirStart(string myDate)
        {
            try
            {
                OnAirStart = Convert.ToDateTime(myDate);
            }
            catch (Exception)
            {
                OnAirStart = new DateTime(1900, 1, 1);
                Remark = Remark + "    Error : " + myDate;
            }
        }

        public void SetOnAirEnd(string myDate)
        {
            try
            {
                OnAirEnd = Convert.ToDateTime(myDate);
            }
            catch (Exception)
            {
                OnAirEnd = new DateTime(1900, 1, 1);
                Remark = Remark + "    Error : " + myDate;
            }
        }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}
