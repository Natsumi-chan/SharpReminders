using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpReminders
{
    class Reminder
    {
        public enum RepeatValue
        {
            Never,
            Daily,
            Weekly,
            Monthly,
            Yearly
        }
        private string ReminderName;
        private DateTime ReminderDateTime;
        private RepeatValue ReminderRepeat;
        private DateTime ReminderAlertTime;

        public Reminder(string name, DateTime time, RepeatValue repeat)
        {
            this.ReminderName = name;
            this.ReminderDateTime = time;
            this.ReminderRepeat = repeat;
        }

        public Reminder(string name, DateTime time, RepeatValue repeat, DateTime alert)
        {
            this.ReminderName = name;
            this.ReminderDateTime = time;
            this.ReminderRepeat = repeat;
            this.ReminderAlertTime = alert;
        }

        #region 得るのメソッド

        public string GetName()
        {
            return this.ReminderName;
        }

        public DateTime GetReminderDateTime()
        {
            return this.ReminderDateTime;
        }

        public RepeatValue GetRepeat()
        {
            return this.ReminderRepeat;
        }

        public DateTime GetAlertDateTime()
        {
            return this.ReminderAlertTime;
        }

        #endregion

        #region 入るのメソッド

        public void SetReminderName(string name)
        {
            this.ReminderName = name;
        }

        public void SetReminderDateTime(DateTime dt)
        {
            this.ReminderDateTime = dt;
        }

        public void SetRepeat(RepeatValue repeat)
        {
            this.ReminderRepeat = repeat;
        }

        public void SetAlertDateTime(DateTime dt)
        {
            this.ReminderAlertTime = dt;
        }

        #endregion
    }
}
