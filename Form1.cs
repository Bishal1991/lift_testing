
using Timer = System.Windows.Forms.Timer;

namespace lift_testing
{
    public partial class Form1 : Form
    {
        enum DoorState
        {
            Close,
            Open,
            Opening,
            Closing
        }
        private DoorState doorState = DoorState.Close;
        private Timer doorTimer = new Timer();
        private int speed = 5;
        private int leftdoorstart;
        private int rightdoorstart;

        public Form1()
        {
            InitializeComponent();

            doorTimer.Interval = 10;
            doorTimer.Tick += DoorTimer_Tick;

            leftdoorstart = pictureBox2.Left;
            rightdoorstart = pictureBox3.Left;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (doorState == DoorState.Close)
            {
                doorState = DoorState.Opening;
                doorTimer.Start();
            }
            else if (doorState == DoorState.Open)
            {
                doorState = DoorState.Closing;
                doorTimer.Start();

            }
            
        }

        private void DoorTimer_Tick(object sender, EventArgs e)
        {
            switch (doorState)
            {
                case DoorState.Opening:

                    pictureBox2.Left -= speed;
                    pictureBox3.Left += speed;

                    if (pictureBox2.Right <= panel1.ClientSize.Width &&
                        pictureBox3.Left >= panel1.ClientSize.Width)
                    {
                        doorTimer.Stop();
                        doorState = DoorState.Open;
                    }

                    break;

                case DoorState.Closing:

                    pictureBox2.Left += speed;
                    pictureBox3.Left -= speed;

                    if (pictureBox2.Left >= leftdoorstart &&
                        pictureBox3.Left <= rightdoorstart)
                    {
                        pictureBox2.Left = leftdoorstart;
                        pictureBox3.Left = rightdoorstart;

                        doorTimer.Stop();
                        doorState = DoorState.Close;
                    }

                    break;
            }
        }
    }
}