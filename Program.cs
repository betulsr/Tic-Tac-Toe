using System;
using static System.Console;

namespace Problem2
{
	static class TicTacToe
	{
		// board for tic-tac-toe game
		// 0 is an empty cell
		// 1 is an X 
		// 2 is an O
		static int[,] board = new int[3,3]{
			{0,0,0},
			{0,0,0},
			{0,0,0}
			};
			
		// Method for adding Symbol to the board. 
		// If move is possible, returns true. 
		// If move is not possible, returne false
		// symbole is 1 for X, 2 for O
		public static bool AddSymbol(int row, int col, int playerSymbol)
		{
			if (board[row,col] == 0)
			{
				board[row, col] = playerSymbol;
				return true;
			}
			else
			{
				return false;
			}
		}
	
		
		
		// Checks if a player has won.
		// Player symbol is specified by integer argument, which
		// is 1 for X player
		// is 2 for O player
		public static bool HasPlayerWon(int playerSymbol)
		{
			// Check if there is a full column of symbol
			bool columnCheck = false;
			
			for(int col = 0; col < board.GetLength(1); col ++)
			{
				int numOfSymbolsInColumn = 0;
				for(int row = 0; row < board.GetLength(0); row ++)
				{
					if (board[row, col] == playerSymbol)
					{
						numOfSymbolsInColumn ++;
						
					}
				}
				
				if (numOfSymbolsInColumn == 3)
				{
					columnCheck = true;
				}
			}
			
			
			// Check if there is a full row of symbol
			bool rowCheck = false;
			
			for(int row = 0; row < board.GetLength(0); row ++)
			{
				int numOfSymbolsInRow = 0;
				for(int col = 0; col < board.GetLength(1); col ++)
				{
					if (board[row, col] == playerSymbol)
					{
						numOfSymbolsInRow ++;
						
					}
				}
				
				if (numOfSymbolsInRow == 3)
				{
					rowCheck = true;
				}
			}
			
			// Check if there is a full diagonal of symbol
			bool diagCheck = board[0,0] == playerSymbol && 
							 board[1,1] == playerSymbol &&
							 board[2,2] == playerSymbol  ;

			
			
			// Check if there is full anti diagonal of symbol
			bool antiDiagCheck = board[2,0] == playerSymbol && 
								 board[1,1] == playerSymbol &&
							     board[0,2] == playerSymbol  ;
			
			
			return columnCheck | rowCheck | diagCheck | antiDiagCheck;
			
		}
		
		
		// Checks if there is a draw,
		// which is defined as no zeros left.
		public static bool IsItADraw()
		{
			int numOfZeros = 0;
			for(int row = 0; row < board.GetLength(0); row ++)
			{
				for(int col = 0; col < board.GetLength(0); col ++)
				{
					if (board[row,col] == 0)
					{
						numOfZeros ++;
					}
				}
			}
			
			return numOfZeros == 0;
		}
		
		
		// Method for displaying the board
		public static void PrintBoard( )
		{
			Console.Clear();
			WriteLine( "    0   1   2 " );
			WriteLine( "  +---+---+---+" );
			WriteLine( "0 |{0}|{1}|{2}|", Mark( board[ 0, 0 ]), Mark( board[ 0, 1 ]), Mark( board[ 0, 2 ]) );
			WriteLine( "  +---+---+---+" );
			WriteLine( "1 |{0}|{1}|{2}|", Mark( board[ 1, 0 ]), Mark( board[ 1, 1 ]), Mark( board[ 1, 2 ]) );
			WriteLine( "  +---+---+---+" );
			WriteLine( "2 |{0}|{1}|{2}|", Mark( board[ 2, 0 ]), Mark( board[ 2, 1 ]), Mark( board[ 2, 2 ] ));
			WriteLine( "  +---+---+---+" );
		}
		static string Mark( int boardValue )
		{
			if( boardValue == 1 ) return " X ";
			if( boardValue == 2 ) return " O ";
			return "   ";
		}

		
	}
	
	
    class Program
    {
        static void Main(string[] args)
        {
			
			// Variables for tracking turn number and state of game
            int turn = 0;
            bool gameRunning = true;
            
            // Show the empty board at start
            TicTacToe.PrintBoard();
            
            // Loop that repeats for game
            while(gameRunning)
            {
								

				
				// Tell user which turn it is
				WriteLine("Turn {0}",turn);

	
				// Tell the user whose turn it is
				if(turn % 2 == 0)
				{
					WriteLine("It is X-Player's turn");
				}
				else
				{
					WriteLine("It is O-Player's turn");
				}
				
				// Inform the user of instructions
				WriteLine("Please enter coordinates of cell you would like to enter your symbol");
				WriteLine("Coordinates are to be input as a code ab, where");
				WriteLine("a denotes the row in index 0 and");
				WriteLine("b denotes the column in index 0.");
				WriteLine("Example: 12");
				
				
				// Tell the user whose turn it is
				if(turn % 2 == 0)
				{
					// Code for x player
					// Get code from user
					Write("Enter code for X: ");
					string codeFromPlayer = ReadLine();
					
					int rowFromCode = int.Parse(codeFromPlayer[0].ToString());
					int colFromCode = int.Parse(codeFromPlayer[1].ToString());
					
					bool validMove = TicTacToe.AddSymbol(rowFromCode, colFromCode,1);
					while(!validMove)
					{
						WriteLine("Invalid move.");
						Write("Enter code for X: ");
						codeFromPlayer = ReadLine();
					
						rowFromCode = int.Parse(codeFromPlayer[0].ToString());
						colFromCode = int.Parse(codeFromPlayer[1].ToString());
						
						validMove = TicTacToe.AddSymbol(rowFromCode, colFromCode,1);
					}
				}
				else
				{
					// Code for O player
					// Get code from user
					Write("Enter code for O: ");
					string codeFromPlayer = ReadLine();
					
					int rowFromCode = int.Parse(codeFromPlayer[0].ToString());
					int colFromCode = int.Parse(codeFromPlayer[1].ToString());
					
					bool validMove = TicTacToe.AddSymbol(rowFromCode, colFromCode,2);
					while(!validMove)
					{
						WriteLine("Invalid move.");
						Write("Enter code for O: ");
						codeFromPlayer = ReadLine();
					
						rowFromCode = int.Parse(codeFromPlayer[0].ToString());
						colFromCode = int.Parse(codeFromPlayer[1].ToString());
						
						validMove = TicTacToe.AddSymbol(rowFromCode, colFromCode,2);
					}
				}

						
				
				// Print the current state of the board
				TicTacToe.PrintBoard();
				bool hasXWon = TicTacToe.HasPlayerWon(1);
				bool hasOWon = TicTacToe.HasPlayerWon(2);
				bool isDraw = TicTacToe.IsItADraw();
				
				if(hasXWon)
				{
					WriteLine("X-Player has won!");
				}
				else if (hasOWon)
				{
					WriteLine("O-Player has won!");
				}
				else if (isDraw)
				{
					WriteLine("It is a draw!");
				}
				
				
				gameRunning = ! (hasXWon | hasOWon | isDraw);
				// Increment turn counter
				turn += 1;

			}
        }
    }
}
