using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfContentsViewer.data
{
    public class Record
    {
        public int Id { get; set; }
        public string Disk { get; set; }

        public string Seq { get; set; }

        public string RipStatus { get; set; }

        public DateTime OnAirDate { get; set; }

        public string BeforeRip { get; set; }

        public string Kind { get; set; }

        public string Channel { get; set; }

        private string _ProgramId;
        public string ProgramId
        {
            get
            {
                return _ProgramId;
            }
            set
            {
                int p = 0;
                try
                {
                    p = Convert.ToInt32(value);
                }
                catch(Exception)
                {
                }
                _ProgramId = p.ToString("000000");
            }
        }

        public string ProgramName { get; set; }

        public string ProgramDisplay { get; set; }

        public string Detail { get; set; }

        public string StartTime { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public void SetOnAirDate(string myDate, string myTime)
        {
            string dt = "";
            try
            {
                if (myTime.Length > 0)
                {
                    dt = myDate + " " + myTime + ":00";
                    OnAirDate = Convert.ToDateTime(dt);
                }
                else
                    OnAirDate = Convert.ToDateTime(myDate);
            }
            catch (Exception)
            {
                OnAirDate = new DateTime(1900, 1, 1);
            }
        }

        public void SetOnAirDate(string myDate)
        {
            try
            {
                OnAirDate = Convert.ToDateTime(myDate);
            }
            catch (Exception)
            {
                OnAirDate = new DateTime(1900, 1, 1);
            }
        }

        public string Duration { get; set; }
    }
}
