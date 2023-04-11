namespace Lab1_X_0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[,] buttons;
        int n = 3;
        int roundNumber = 1;
        private void Form1_Load(object sender, EventArgs e)
        {
            int size = pictureBox1.Height / 3;
            buttons = new Button[3, 3];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Button button = new Button();
                    button.Parent = pictureBox1;
                    button.Size = new Size(size, size);
                    button.Location = new Point(j * size, i * size);
                    button.Font = new Font("Times New Roman", 30);
                    button.BackColor = Color.DarkMagenta;
                    button.Click += pictureBox1_Click;


                    buttons[i, j] = button;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.Enabled = false;
            if (roundNumber % 2 != 0)
                button.Text = "X";
            else
                button.Text = "O";

            if (GameIsWon())
            {
                MessageBox.Show($"Player {button.Text} has won!", "GAME OVER");
                DisableAllButtons();
            }
            if (GameOver())
            {
                MessageBox.Show("It's a draw!", "Game over!");
            }

            roundNumber++;

        }
        private bool GameIsWon()
        {
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (buttons[i, j].Text == "X")
                        matrix[i, j] = 1;
                    else if (buttons[i, j].Text == "O")
                        matrix[i, j] = 10;
                }
            }
            /*   int suma1 = matrix[0,0] + matrix[0,1] + matrix[0,2];
               int suma2 = matrix[1,0] + matrix[1,1] + matrix[1,2];
               int suma3 = matrix[2,0] + matrix[2,1] + matrix[2,2];

               int suma4 = matrix[0,0] + matrix[1,0] + matrix[2,0];
               int suma5 = matrix[0,1] + matrix[1,1] + matrix[2,1];
               int suma6 = matrix[0,2] + matrix[1,2] + matrix[2,2];

               int suma7 = matrix[0,0] + matrix[1,1] + matrix[2,2];
               int suma8 = matrix[0,2] + matrix[1,1] + matrix[2,0];

               if (suma1 == 3 || suma1 == 30 ||
                   suma2 == 3 || suma1 == 30 ||
                   suma3 == 3 || suma1 == 30 ||
                   suma4 == 3 || suma1 == 30 ||
                   suma5 == 3 || suma1 == 30 ||
                   suma6 == 3 || suma1 == 30 ||
                   suma7 == 3 || suma1 == 30 ||
                   suma8 == 3 || suma1 == 30)
                   return true; */


            int sumaPrincipala = 0, sumaSecundara = 0;
            for (int i = 0; i < n; i++)
            {
                int sumaLinie = 0;
                int sumaColoana = 0;

                for (int j = 0; j < n; j++)
                {
                    sumaLinie += matrix[i, j];
                    sumaColoana += matrix[j, i];
                }

                if (sumaLinie == 3 || sumaLinie == 30 ||
                    sumaColoana == 3 || sumaColoana == 30)
                {
                    return true;
                }
                sumaPrincipala += matrix[i, i];
                sumaSecundara += matrix[i, n - i - 1];

            }
            if (sumaPrincipala == 3 || sumaPrincipala == 30 ||
                    sumaSecundara == 3 || sumaSecundara == 30)
                return true;

            return false;
        }

        private bool GameOver()
        {
            if (roundNumber == 9)
                return true;
            return false;
        }

        private void DisableAllButtons()
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    buttons[i, j].Enabled = false;
        }
        private void EnabledAllButtons(bool isEnabled)
        {
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    buttons[i, j].Enabled = isEnabled;
        }

        private void BUTTON(object sender, EventArgs e)
        {
            EnabledAllButtons(true);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    buttons[i, j].Text = string.Empty;
        }
    }
}