using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using wpfContentsViewer.data;

namespace wpfContentsViewer.common
{
    class FilenameGenerate
    {
        public static string GetFilename(ChannelData myChannel, Program myProgram, Record myRecord, string myTarget, string myDuration, string myPath, string myExtension)
        {
            string message = "";
            string filename = "";

            if (myChannel == null)
                message = "一致するチャンネル「" + myProgram.ChannelId +  "」が存在しません";

            if (myProgram == null)
                message = message + "、一致する番組「" + myRecord.ProgramId + "」が存在しません";

            if (message.Length > 0)
            {
                return message;
            }
            else
            {
                string name = (myProgram.AbbreviationName.Length > 0) ? myProgram.AbbreviationName : myProgram.Name;

                if (myTarget != null)
                {
                    Regex regex = new Regex(".*「.*」.*");
                    if (regex.Match(myTarget).Success)
                    {
                        string artist = myTarget.Substring(0, myTarget.IndexOf("「"));
                        string songname = myTarget.Substring(myTarget.IndexOf("「")+1).Replace("」", "");
                        filename = artist + "{" + myRecord.OnAirDate.ToString("yyyyMMdd") + "}" + " － " + songname + "（" + name + "[" + myChannel.RipId + " " + FilenameGenerate.GetDuration(myDuration) + "]）";
                    }
                    else
                    {
                        message = message + "、Target Artist「Song」の入力がありません";
                    }
                }
                else
                {
                    filename = "" + "{" + myRecord.OnAirDate.ToString("yyyyMMdd") + "}" + " － " + "（" + name + "[" + myChannel.RipId + " " + FilenameGenerate.GetDuration(myDuration) + "]）";
                }
            }

            if (filename.Length > 0)
            {
                if (myExtension != null && myExtension.Length > 0)
                    filename = filename + "." + myExtension;
                if (myPath != null && myPath.Length > 0)
                    filename = System.IO.Path.Combine(myPath, filename);
            }

            return filename;
        }

        public static string GetFilenameProgram(ChannelData myChannel, Program myProgram, Record myRecord, string myTarget, string myDuration, string myProgramPrefix)
        {
            string message = "";
            string filename = "";

            if (myChannel == null)
                message = "一致するチャンネル「" + myProgram.ChannelId + "」が存在しません";

            if (myProgram == null)
                message = message + "、一致する番組「" + myRecord.ProgramId + "」が存在しません";

            if (message.Length > 0)
            {
                return message;
            }
            else
            {
                string name = (myProgram.AbbreviationName.Length > 0) ? myProgram.AbbreviationName : myProgram.Name;

                // [LIVE]｛20070929｝スーパーライブ 中島美嘉（[H0001 89m59s]）
                // [番組]｛20070504｝ダウンタウンDX － 相田翔子、乙葉、要潤、島田洋七、的場浩司（[H0001 45m59s]）
                // [番組]AKB 0じ59ふん｛20080707｝#本物を的チューせよ(本物のヤンキーを当てろ)#（[H221101 18m43s]）
                // [番組]HEY!HEY!HEY!｛20080526｝大塚愛、BoA、鈴木雅之、菊池桃子、ET-KING（[H212101 33m23s]）
                filename = "[" + myProgramPrefix + "] " + name + "{" + myRecord.OnAirDate.ToString("yyyyMMdd") + "}" + " " + myRecord.Detail + "（" + "[" + myChannel.RipId + " " + FilenameGenerate.GetDuration(myDuration) + "]）";
            }

            return filename;
        }

        public static string GetDuration(string myDuration)
        {
            string times = "0m0s";

            if (myDuration == null)
                return times;

            if (myDuration.IndexOf(".") >= 0)
            {
                string[] time = myDuration.Split('.');

                if (time.Length > 2)
                    times = time[0] + "h" + time[1] + "m" + time[2] + "s";
                else if (time.Length == 2)
                    times = time[0] + "m" + time[1] + "s";
                else if (time.Length == 1)
                    times = time[0] + "s";

            }

            return times;
        }
    }
}
