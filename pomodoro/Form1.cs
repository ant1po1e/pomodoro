using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using Timer = System.Windows.Forms.Timer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pomodoro
{
    public partial class Form1 : Form
    {
        private Timer timer;
        private int timeLeft;
        private bool isWorkTime;
        private int sessionCount;
        private SoundPlayer soundPlayer;

        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            isWorkTime = true;
            timeLeft = 25 * 60;
            sessionCount = 0;

            Stream soundStream = Properties.Resources.alert;
            soundPlayer = new SoundPlayer(soundStream);

            lblSession.Text = $"{sessionCount + 1} of 4 sessions";

            progressBar.Maximum = 25 * 60;
            progressBar.Value = timeLeft;

            comboBoxSessionType.Items.AddRange(new string[] { "Focus", "Short Break", "Long Break" });
            comboBoxSessionType.SelectedIndex = 0;
            comboBoxSessionType.OnSelectedIndexChanged += comboBoxSessionType_OnSelectedIndexChanged;
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
                        comboBoxSessionType.SelectedIndex = 1;
                        timeLeft = 5 * 60;
                    }
                    else
                    {
                        MessageBox.Show("Work time is over! Take a long break.");
                        comboBoxSessionType.SelectedIndex = 2;
                        timeLeft = 15 * 60;
                        sessionCount = -1;
                    }
                    sessionCount++;
                    lblSession.Text = $"{sessionCount + 1} of 4 sessions";
                }
                else
                {
                    MessageBox.Show("Break time is over! Back to work.");
                    timeLeft = 25 * 60;
                }
                isWorkTime = !isWorkTime;
                progressBar.Maximum = timeLeft;
                progressBar.Value = timeLeft;
                timer.Start();
            }
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
                btnPlayPause.BackColor = System.Drawing.Color.Wheat;
            }
            else
            {
                timer.Start();
                btnPlayPause.Text = "Pause";
                btnPlayPause.BackColor = System.Drawing.Color.Khaki;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer.Stop();
            isWorkTime = true;
            timeLeft = 25 * 60;
            sessionCount = 0;
            lblSession.Text = $"{sessionCount + 1} of 4 sessions";
            UpdateTimeDisplay();
            progressBar.Maximum = timeLeft;
            progressBar.Value = timeLeft;
            btnPlayPause.Text = "Start";
            btnPlayPause.BackColor = System.Drawing.Color.Wheat;
        }

        private void comboBoxSessionType_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSessionType.SelectedItem.ToString())
            {
                case "Focus":
                    timeLeft = 25 * 60;
                    isWorkTime = true;
                    btnPlayPause.BackColor = System.Drawing.Color.Wheat;
                    break;
                case "Short Break":
                    timeLeft = 5 * 60;
                    isWorkTime = false;
                    btnPlayPause.BackColor = System.Drawing.Color.Wheat;
                    break;
                case "Long Break":
                    timeLeft = 15 * 60;
                    isWorkTime = false;
                    btnPlayPause.BackColor = System.Drawing.Color.Wheat;
                    break;
            }
            progressBar.Maximum = timeLeft;
            progressBar.Value = timeLeft;
            UpdateTimeDisplay();
        }
    }
}
