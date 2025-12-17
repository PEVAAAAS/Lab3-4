namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Game game;
        public Form1()
        {
            InitializeComponent();
            ClientSize = new Size(13 * Settings.Size, 14 * Settings.Size);
            game = new Game(ClientSize.Width, ClientSize.Height);
            game.LoadLevel("Map1.txt");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.A || e.KeyCode == Keys.D || e.KeyCode == Keys.S)
            {
                Direction direction;
                if (e.KeyCode == Keys.W)
                {
                    direction = Direction.North;
                }
                else if (e.KeyCode == Keys.A)
                {
                    direction = Direction.West;
                }
                else if (e.KeyCode == Keys.D)
                {
                    direction = Direction.East;
                }
                else
                {
                    direction = Direction.South;
                }
                game.MovePlayer(direction);
                Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            if(random.Next(6)== 3)
            {
                PowerUp powerUp = (PowerUp)random.Next(6);
                game.SpawnPowerUp(powerUp);
                Invalidate();
            }
        }
    }
}
