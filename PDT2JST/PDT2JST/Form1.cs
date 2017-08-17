using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDT2JST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private TimeZoneInfo PDT = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        private TimeZoneInfo JST = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

        private static DateTime adjustDateTime(DateTime rawTarget)
        {
            return new DateTime(rawTarget.Year, rawTarget.Month, rawTarget.Day, rawTarget.Hour, 0, 0);
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            var r = TimeZoneInfo.ConvertTime(adjustDateTime(dateTimePicker1.Value), PDT, JST).ToString();
            var s = $"PDT {dateTimePicker1.Value.ToString()} → JST {r.ToString()}";
            Clipboard.Clear();
            Clipboard.SetText(s);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = TimeZoneInfo.ConvertTime(adjustDateTime(DateTime.Now), PDT, JST);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            labelResult.Text = TimeZoneInfo.ConvertTime(adjustDateTime(dateTimePicker1.Value), PDT, JST).ToString("yyyyMMdd HH");
        }
    }
}
