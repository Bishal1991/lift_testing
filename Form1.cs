
using Timer = System.Windows.Forms.Timer;

namespace lift_testing
{
    public partial class Form1 : Form
    {
        private Timer doorTimer = new Timer();
        private int speed = 5;

        public Form1()
        {
            InitializeComponent();

            doorTimer.Interval = 20;
            doorTimer.Tick += DoorTimer_Tick;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            doorTimer.Start();
        }

        private void DoorTimer_Tick(object sender, EventArgs e)
        {
            // Left door moves left
            pictureBox1.Left -= speed;

            // Right door moves right
            pictureBox2.Left += speed;

            // Stop when both doors are outside the form
            if (pictureBox1.Right <= 0 &&
                pictureBox2.Left >= this.ClientSize.Width)
            {
                doorTimer.Stop();
            }
        }
    }
}
