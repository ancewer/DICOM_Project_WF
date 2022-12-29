using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVH_Project_WF
{
    internal class ConsoleTextWriter: TextWriter
    {
        TextBox textBox;
        delegate void WriteFunc(string value);
        WriteFunc write;
        WriteFunc writeLine;

        public ConsoleTextWriter(TextBox textBox)
        {
            this.textBox = textBox;
            write = Write;
            writeLine = WriteLine;
        }

        /// <summary>
        /// 编码转换-UTF8
        /// </summary>
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
            //get { return Encoding.Unicode; }
        }

        /// <summary>
        /// 最低限度需要重写的方法
        /// </summary>
        public override void Write(string value)
        {
            if (textBox.InvokeRequired)
            {
                textBox.BeginInvoke(write, value);
            }
            else
            {
                textBox.AppendText(value);
            }
        }

        /// <summary>
        /// 为提高效率直接处理一行的输出
        /// </summary>
        public override void WriteLine(string value)
        {
            if (textBox.InvokeRequired)
            {
                textBox.BeginInvoke(writeLine, value);
            }
            else
            {
                textBox.AppendText(value);
                textBox.AppendText(this.NewLine);
            }

        }
    }
}
