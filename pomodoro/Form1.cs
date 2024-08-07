using System;
using System.Windows.Forms;
using System.Media;
using Timer = System.Windows.Forms.Timer;

namespace pomodoro
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private int timeLeft;
        private bool isWorkTime;
        private int sessionCount;
        private SoundPlayer soundPlayer;

        private bool manualChange = true;

        private int focusTime = 25 * 60;
        private int shortBreakTime = 5 * 60;
        private int longBreakTime = 15 * 60;

        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            isWorkTime = true;
            timeLeft = focusTime;
            sessionCount = 0;

            Stream soundStream = Properties.Resources.alert;
            soundPlayer = new SoundPlayer(soundStream);

            lblSession.Text = $"{sessionCount + 1} of 4 sessions";

            progressBar.Maximum = focusTime;
            progressBar.Value = timeLeft;

            comboBoxSessionType.Items.AddRange(new string[] { "Focus", "Short Break", "Long Break" });
            comboBoxSessionType.SelectedIndex = 0;
            comboBoxSessionType.OnSelectedIndexChanged += comboBoxSessionType_OnSelectedIndexChanged;

            UpdateTimeDisplay();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                UpdateTimeDisplay();
                progressBar.Value = timeLeft;
            }
            else
            {
                timer.Stop();
                soundPlayer.Play();
                if (isWorkTime)
                {
                    if (sessionCount < 3)
                    {
                        MessageBox.Show("Work time is over! Take a short break.");
                        SwitchToShortBreak();
                    }
                    else
                    {
                        MessageBox.Show("Work time is over! Take a long break.");
                        SwitchToLongBreak();
                    }
                }
                else
                {
                    MessageBox.Show("Break time is over! Back to work.");
                    SwitchToFocus();
                }

                timer.Start();
            }
        }

        private void SwitchToShortBreak()
        {
            manualChange = false;
            comboBoxSessionType.SelectedIndex = 1;
            timeLeft = shortBreakTime;
            isWorkTime = false;
            progressBar.Maximum = timeLeft;
            progressBar.Value = timeLeft;
            UpdateTimeDisplay();
            manualChange = true;
        }

        private void SwitchToLongBreak()
        {
            manualChange = false;
            comboBoxSessionType.SelectedIndex = 2;
            timeLeft = longBreakTime;
            isWorkTime = false;
            sessionCount = -1;
            progressBar.Maximum = timeLeft;
            progressBar.Value = timeLeft;
            UpdateTimeDisplay();
            manualChange = true;
        }

        private void SwitchToFocus()
        {
            manualChange = false;
            comboBoxSessionType.SelectedIndex = 0;
            timeLeft = focusTime;
            isWorkTime = true;
            sessionCount++;
            progressBar.Maximum = timeLeft;
            progressBar.Value = timeLeft;
            lblSession.Text = $"{sessionCount + 1} of 4 sessions";
            UpdateTimeDisplay();
            manualChange = true;
        }

        private void UpdateTimeDisplay()
        {
            int minutes = timeLeft / 60;
            int seconds = timeLeft % 60;
            lblTimer.Text = $"{minutes:D2}:{seconds:D2}";
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
                btnPlayPause.Text = "Start";
            }
            else
            {
                timer.Start();
                btnPlayPause.Text = "Pause";
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            comboBoxSessionType.SelectedIndex = 0;
            timer.Stop();
            btnPlayPause.Text = "Start";
            isWorkTime = true;
            timeLeft = focusTime;
            sessionCount = 0;
            lblSession.Text = $"{sessionCount + 1} of 4 sessions";
            UpdateTimeDisplay();
            progressBar.Maximum = timeLeft;
            progressBar.Value = timeLeft;
        }

        private void comboBoxSessionType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (manualChange)
            {
                switch (comboBoxSessionType.SelectedItem.ToString())
                {
                    case "Focus":
                        timeLeft = focusTime;
                        isWorkTime = true;
                        break;
                    case "Short Break":
                        timeLeft = shortBreakTime;
                        isWorkTime = false;
                        break;
                    case "Long Break":
                        timeLeft = longBreakTime;
                        isWorkTime = false;
                        break;
                }
                progressBar.Maximum = timeLeft;
                progressBar.Value = timeLeft;
                UpdateTimeDisplay();
            }
        }
    }
}
