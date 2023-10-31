using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTimePicker_control
{
    public partial class DateTimePickerForm : Form
    {
        public DateTimePickerForm()
        {
            InitializeComponent();
        }

        private void dropOffDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime dropOffDate = dropOffDateTimePicker.Value;

            if (dropOffDate.DayOfWeek == DayOfWeek.Friday ||
                dropOffDate.DayOfWeek == DayOfWeek.Saturday ||
                dropOffDate.DayOfWeek == DayOfWeek.Sunday)
            {
                outputLabel.Text = dropOffDate.AddDays(3).ToLongDateString();
            }
            else
            {
                outputLabel.Text = dropOffDate.AddDays(2).ToLongDateString();
            }
        }

        private void DateTimePickerForm_Load(object sender, EventArgs e)
        {
            dropOffDateTimePicker.MinDate = DateTime.Today;

            dropOffDateTimePicker.MaxDate = DateTime.Today.AddYears(1);
        }
    }
}
