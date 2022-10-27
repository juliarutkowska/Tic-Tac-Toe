using kółko_i_krzyżyk;

var board = new string[3,3];
var inputHelper = new InputHelper();
var winChecker = new WinChecker();

for(var row=0; row<3; row++)
{
    for(var column=0; column<3; column++)
    {
        board[row,column] = " ";
    }
}

var symbol = "o";
var turns = 0;
while(true)
{
    var move = inputHelper.GetUsersMove(symbol);

    Console.WriteLine($"You put your '{symbol}' here: {move.Row} {move.Column}.");

    if(board[move.Row,move.Column].Equals("o")||board[move.Row,move.Column].Equals("x"))
    {
        Console.WriteLine("This spot is taken. Please choose another one.");
        continue;
    }

    board[move.Row,move.Column]=symbol;
    Print(board);
    turns++;

    if (winChecker.CheckWinner(board, symbol))
    {
        Console.WriteLine($"You won \"{symbol}\". Congrats!");
        return;
    }
    
    if(symbol == "o")
    {
        symbol = "x";
    }
    else
    {
        symbol = "o";
    }
    

    if(turns == 9)
    {
        Console.WriteLine("It's a draw.");
        break;
    }
}


//write a board
void Print(string[,] board)
{
    Console.WriteLine();
    for(var row=0; row<3; row++)
    {
        Console.WriteLine($"{board[row,0]}|{board[row,1]}|{board[row,2]}");
        if(row != 2)
        {
            Console.WriteLine("-+-+-");
        }
    }
    Console.WriteLine();
}
