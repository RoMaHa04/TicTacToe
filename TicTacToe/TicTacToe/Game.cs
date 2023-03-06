using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Game
    {
        public string CurentPlayer { get; set; } = X;
        private const string X = "X";
        private const string O = "O";
        private string[,] Board = new string[3,3];
        public void SetNexPlayer()
        {
            if (CurentPlayer == X) CurentPlayer = O;
            else CurentPlayer = X;
        }

        public bool CheckPlayerWins()
        {

            for (int i = 0; i < 3; i++)
            {
                if (!String.IsNullOrWhiteSpace(Board[i, 0]))
                {
                    if (Board[i, 0] == Board[i, 1] && Board[i, 0] == Board[i, 2]) return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (!String.IsNullOrWhiteSpace(Board[0, i]))
                {
                    if (Board[0, i] == Board[1, i] && Board[0, i] == Board[2, i]) return true;
                }                 
            }

            if (!String.IsNullOrWhiteSpace(Board[1, 1]))
            {
                if (Board[0, 0] == Board[1, 1] && Board[0, 0] == Board[2, 2]) return true;
                if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0]) return true;
            }

            return false;
        }

        internal void UpdateBoard(Possition buttonPosition, string value) => Board[buttonPosition.x, buttonPosition.y] = value;
    }
}
