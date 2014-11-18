using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpReminders
{
    public partial class Menu : Form
    {
        public static List<Reminder> reminderList = new List<Reminder>();
        private Timer time = new Timer();

        public Menu()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icon;
            this.Text = Program.programName + " " + Program.programVersion + " by " + Program.programAuthor;
            SetupTimer();
            SetupNotifyIcon();
        }

        private void SetupNotifyIcon()
        {
            NotifyIconMain.Icon = Properties.Resources.icon;
            NotifyIconMain.Text = Program.programName;
            NotifyIconMain.BalloonTipTitle = Program.programName;
            NotifyIconMain.BalloonTipIcon = ToolTipIcon.Info;
        }

        private void SetupTimer()
        {
            time.Interval = 1000;
            time.Tick += new EventHandler(time_Tick);
            time.Start();
        }

        private void time_Tick(object sender, EventArgs e)
        {
            CheckForReminders();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
        }

        private string GetCurrentDateTime()
        {
            return DateTime.Now.ToString();
        }

        private void CheckForReminders()
        {
            if (reminderList.Count == 0)
                return;
            foreach (Reminder r in reminderList.ToList<Reminder>()) {
                if (r.GetReminderDateTime().ToString() == GetCurrentDateTime()) {
                    NotifyReminder(r);
                }
                if (r.GetAlertDateTime().ToString() == GetCurrentDateTime()) {
                    NotifyAlert(r);
                }
            }
        }

        private void NotifyReminder(Reminder reminder)
        {
            string text = reminder.GetReminderName() + " now at " + reminder.GetReminderDateTime().ToShortTimeString() + "!";
            if (reminder.GetRepeat() != Reminder.RepeatValue.Never) {
                string nl = Environment.NewLine;
                switch (reminder.GetRepeat()) {
                    case Reminder.RepeatValue.Daily:
                        text += nl + "This will happen again tomorrow.";
                        break;
                    case Reminder.RepeatValue.Weekly:
                        text += nl + "This will happen again next week.";
                        break;
                    case Reminder.RepeatValue.Monthly:
                        text += nl + "This will happen again next month.";
                        break;
                    case Reminder.RepeatValue.Yearly:
                        text += nl + "This will happen again next year.";
                        break;
                }
            }
            Popup(text);
        }

        private void NotifyAlert(Reminder reminder)
        {
            string text = "Reminder: " + reminder.GetReminderName() + " at " + reminder.GetReminderDateTime().ToShortTimeString() + ".";
            if (reminder.GetRepeat() != Reminder.RepeatValue.Never) {
                string nl = Environment.NewLine;
                switch (reminder.GetRepeat()) {
                    case Reminder.RepeatValue.Daily:
                        text += nl + "This will happen again tomorrow.";
                        break;
                    case Reminder.RepeatValue.Weekly:
                        text += nl + "This will happen again next week.";
                        break;
                    case Reminder.RepeatValue.Monthly:
                        text += nl + "This will happen again next month.";
                        break;
                    case Reminder.RepeatValue.Yearly:
                        text += nl + "This will happen again next year.";
                        break;
                }
            }
            Popup(text);
        }

        private void Popup(string text)
        {
            NotifyIconMain.ShowBalloonTip(5000, Program.programName, text, ToolTipIcon.Info);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 試し
            try {
                reminderList.Add(new Reminder(new Random().Next(16).ToString(), DateTime.Now.AddSeconds(30), Reminder.RepeatValue.Never, DateTime.Now.AddSeconds(15)));
            }
            catch (Exception ex) {
                MessageBox.Show(ex + Environment.NewLine + ex.Message);
            }
        }
    }
}
