using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace GroupeCinema
{
    public class Logger
    {

        public AlertMode AlertMode { get; set; }
        public LogMode LogMode { get; set; }

        public Logger()
        {

        }
        public Logger(LogMode logMode, AlertMode alertMode)
        {
            this.LogMode = logMode;
            this.AlertMode = alertMode;
        }

        public void Log(String toLog, String msg = null, String userDirectory = null)
        {
            if(msg == null)
            {
                msg = toLog;
            }
            if(userDirectory == null)
            {
                userDirectory = Path.GetTempPath() + "\\" + Application.Current.ToString().Split('.')[0];
            }
            switch (this.LogMode)
            {
                case LogMode.NONE:
                    break;
                case LogMode.CONSOLE:
                    Console.WriteLine(toLog);
                    break;
                case LogMode.EXTERNAL:
                    Directory.CreateDirectory(userDirectory);
                    TextWriter file2 = new StreamWriter(
                        userDirectory + "\\current_logs", true, UTF8Encoding.UTF8);
                    file2.WriteLine(toLog);
                    file2.Close();
                    break;
                case LogMode.CURRENT_FOLDER:
                    TextWriter file = new StreamWriter(
                        AppDomain.CurrentDomain.BaseDirectory + 
                        "\\current_logs", true, UTF8Encoding.UTF8);
                    file.WriteLine(toLog);
                    file.Close();
                    break;
                case LogMode.TEMP_FOLDER:
                    String directory = Path.GetTempPath() + "\\" + Application.Current.ToString().Split('.')[0];
                    Directory.CreateDirectory(directory);
                    TextWriter file1 = new StreamWriter(
                        directory + "\\current_logs", true, UTF8Encoding.UTF8);
                    file1.WriteLine(toLog);
                    file1.Close();
                    break;
                default:
                    break;
            }
            switch (this.AlertMode)
            {
                case AlertMode.NONE:
                    break;
                case AlertMode.CONSOLE:
                    Console.WriteLine(msg);
                    break;
                case AlertMode.MESSAGE_BOX:
                    //MessageBox.Show(msg);
                    MessageBoxResult result = MessageBox.Show(msg, "Attention", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if(result == MessageBoxResult.Yes)
                    {
                        this.AlertMode = AlertMode.NONE;
                        LogMode temp = this.LogMode;
                        this.LogMode = LogMode.CURRENT_FOLDER;
                        this.Log(toLog);
                        this.AlertMode = AlertMode.MESSAGE_BOX;
                        this.LogMode = temp;
                    }
                    break;
                case AlertMode.TOAST:
                    break;
                case AlertMode.OVERLAY:
                    break;
                default:
                    break;
            }
        }
        public void Log(Exception toLog, String msg = null)
        {
            if (msg == null)
            {
                msg = toLog.Message;
            }          
        }

    }
}
