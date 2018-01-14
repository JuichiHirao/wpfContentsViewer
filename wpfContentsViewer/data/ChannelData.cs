using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfContentsViewer.data
{
    public class ChannelData
    {
        public int Channel { get; set; }

        public string Name { get; set; }

        public string BroadcastKind { get; set; }

        public string RipId { get; set; }

        public string VideoRate { get; set; }

        public string VoiceRate { get; set; }

        public string Remark { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

    }
}
