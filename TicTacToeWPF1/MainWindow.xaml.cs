using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToeWPF
{
    public partial class MainWindow : Window
    {
        private string[,] board = new string[3, 3]; // Pelilauta
        private string currentPlayer = "X"; // Alkuperäinen pelaaja

        public MainWindow()
        {
            InitializeComponent();
            ResetBoard();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int row = Grid.GetRow(clickedButton);
            int col = Grid.GetColumn(clickedButton);

            // Jos ruutu on tyhjä, aseta merkki ja vaihda vuoroa
            if (string.IsNullOrEmpty(board[row, col]))
            {
                board[row, col] = currentPlayer;
                clickedButton.Content = currentPlayer;
                if (CheckForWinner())
                {
                    MessageBox.Show(currentPlayer + " voitti!");
                    ResetBoard();
                }
                else
                {
                    currentPlayer = (currentPlayer == "X") ? "O" : "X"; // Vaihda pelaajaa
                }
            }
        }

        private bool CheckForWinner()
        {
            // Tarkistetaan kaikki rivit, sarakkeet ja diagonaalit voittajan löytymiseksi
            for (int i = 0; i < 3; i++)
            {
                // Tarkista rivit ja sarakkeet
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && !string.IsNullOrEmpty(board[i, 0])) return true;
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i] && !string.IsNullOrEmpty(board[0, i])) return true;
            }
            // Tarkista diagonaalit
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && !string.IsNullOrEmpty(board[0, 0])) return true;
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && !string.IsNullOrEmpty(board[0, 2])) return true;

            return false;
        }

        private void ResetBoard()
        {
            // Tyhjennetään pelilauta ja nollataan kaikki napit
            Array.Clear(board, 0, board.Length);

            // Varmistetaan, että napit löytyvät ja nollataan niiden sisältö
            Btn00.Content = Btn01.Content = Btn02.Content = Btn10.Content = Btn11.Content = Btn12.Content = Btn20.Content = Btn21.Content = Btn22.Content = "";

            currentPlayer = "X"; // Alkuperäinen pelaaja
        }

    }
}
