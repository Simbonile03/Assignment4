namespace Assignment4
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");

            // Initialize the game board
            char[,] board = {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };

            int currentPlayer = 1; // Player 1 starts

            do
            {
                // Display the current board
                RenderBoard(board);

                // Get the current player's move
                int move = GetPlayerMove(currentPlayer, board);

                // Update the board with the player's move
                UpdateBoard(board, move, currentPlayer);

                // Check for a winner or a tie
                if (IsWinner(board, currentPlayer))
                {
                    RenderBoard(board);
                    Console.WriteLine($"Player {currentPlayer} wins!");
                    break;
                }
                else if (IsBoardFull(board))
                {
                    RenderBoard(board);
                    Console.WriteLine("It's a tie!");
                    break;
                }

                // Switch to the other player
                currentPlayer = 3 - currentPlayer; // Toggle between 1 and 2
            } while (true);
        }

        static void RenderBoard(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static int GetPlayerMove(int currentPlayer, char[,] board)
        {
            int move;
            while (true)
            {
                Console.Write($"Player {currentPlayer}, enter your move (1-9): ");
                if (int.TryParse(Console.ReadLine(), out move))
                {
                    if (IsValidMove(move, board))
                    {
                        return move;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Please enter a number between 1 and 9 and ensure the cell is not occupied.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        static bool IsValidMove(int move, char[,] board)
        {
            int row = (move - 1) / 3;
            int col = (move - 1) % 3;

            return move >= 1 && move <= 9 && board[row, col] != 'X' && board[row, col] != 'O';
        }

        static void UpdateBoard(char[,] board, int move, int currentPlayer)
        {
            char symbol = (currentPlayer == 1) ? 'X' : 'O';

            int row = (move - 1) / 3;
            int col = (move - 1) % 3;

            board[row, col] = symbol;
        }

        static bool IsWinner(char[,] board, int currentPlayer)
        {
            char symbol = (currentPlayer == 1) ? 'X' : 'O';

            // Check rows, columns, and diagonals for a win
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == symbol && board[i, 1] == symbol && board[i, 2] == symbol) ||
                    (board[0, i] == symbol && board[1, i] == symbol && board[2, i] == symbol))
                {
                    return true;
                }
            }

            if ((board[0, 0] == symbol && board[1, 1] == symbol && board[2, 2] == symbol) ||
                (board[0, 2] == symbol && board[1, 1] == symbol && board[2, 0] == symbol))
            {
                return true;
            }

            return false;
        }

        static bool IsBoardFull(char[,] board)
        {
            foreach (var cell in board)
            {
                if (cell != 'X' && cell != 'O')
                {
                    return false;
                }
            }
            return true;
        }
    }



}
   
