using System.Linq;

namespace SudokuEngine;
public class SudokuGenerator
    {
        public Square[,] grid;
        int _xP; // x pointer
        int _yP; // y pointer
        bool _cmp; // complete is true when x and y pointers = 8

        /// <summary>Used to store the original values of the generated grid for checking against iterative solver outputs</summary>
        int[,] setGrid = new int[9,9];

        /// <summary>
        /// Sets the quantity of squares to remove from the grid after generation is complete
        /// </summary>
        /// <value></value>
        public int removalQty {get;set;}

        public int XP {
            get{
                return _xP;
            }
            set{
                _xP = value;
            }
        }

        public int YP {
            get{
                return _yP;
            }
            set{
                _yP = value;
            }
        }

        public bool Complete {
            get{
                return _cmp;
            }
            set{
                _cmp = value;
            }
        }


        public SudokuGenerator()
        {
            grid = new Square[9,9];
            for(var y = 0;y<9;y++)
            {
                for(var x = 0;x<9;x++)
                {
                    grid[y,x] = new Square();
                    grid[y,x].xref = x;
                    grid[y,x].yref = y;
                }
            }
        }

        public void Remove1RandomSquare(){
            Random rnd = new Random();
            int x = rnd.Next(0,9);
            int y = rnd.Next(0,9);
            grid[y,x].currentvalue = 0;
            grid[y,x].isSet = false;
            grid[y,x].reset();

        }
        
        /// <summary>
        /// Main method to generate a new random valid sudoku grid, remove random positions from the grid and
        /// Check the continued validity of the puzzle at each step
        /// </summary>
        public void GenerateGrid() // 
        {
            // Generation occurs using a brute force backtracking algorithm
            // The general sequence of events here will be thus
            // start at square 0,0 (squares will be advanced through from 0,0 to 0,8 then 1,0 to 1,8 and so on)
            // for each square pick a random number from the list of av available numbers for that square
            // if the nummber passes all valid checks, then insert and move to the next square
            // contine until a square is found where no valid numbers are found
            // reset current square and backtrack the pointer to the previous square
            // resume picking from the list available at this square
            // either find another number and proceed, or find nothing and backtrack again
            // sequence is complete when all squares have a number
            // run the checkgridcomplete method at the end to test if the entire grid is compatible

            _xP = 0;
            _yP = 0;
            _cmp = false;

            // Main loop to generate grid, will terminate upon increment pointer function detecting the end of the grid and
            // setting the _cmp (complete) flag to true
            do
            {
                bool result = grid[_yP,_xP].getNextRandomListElement();
                if (result)
                {
                    Coords c = new Coords()
                    {
                        x = _xP,
                        y = _yP,
                        v = grid[_yP,_xP].currentvalue
                    };

                    if (CheckValid(c,true))
                    {
                        incrementPointer();
                    }  
                } 
                else
                {
                    grid[_yP,_xP].reset();
                    decrementPointer();
                }

            } while (_cmp == false);

            // Sets all squares to isSet = true, this is used to indicate that a valid value has been found for this cell 
            // Later in the algorithm we use it to unset cells so we can Refind the solution and check 2 things
            // 1) a solution still exists for the given unset cells
            // 2) only 1 solution exists
            foreach (var sq in grid)
            {
                sq.isSet = true;
            }

            // retain the original grid settings
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    setGrid[y,x] = grid[y,x].currentvalue;
                }
            }
            
            for (int i = 0; i < removalQty; i++)
            {
                Remove1RandomSquare();
            }
            

            //Console.WriteLine("Whoopee"); // if im here then the algorithm has worked :)
        }

        // takes an input element of type square, selects a random element from the list
        // removes this element from the list, and sets this value as the current square value
        // if no elements are in the list to select, then this function returns false
        // indicating that a decrement pointer operation is required, and also a square reset

        public void resetSquare(Square sq)
        {
            sq.reset();
        }

        public void incrementPointer()
        {
            _xP += 1;
            if(_xP == 9){
                _yP += 1;
                _xP = 0;
            }
            if (_yP == 9)
            {
                _cmp = true;
                _xP = 8;
                _yP = 8;
            }
        }

        public void decrementPointer()
        {
            _xP -= 1;
            if (_xP < 0)
            {
                _yP -= 1;
                _xP = 8;
            }
            if (_yP == -1)
            {
                _yP = 0;
                _xP = 0;
            }
        }

        public bool CheckGridComplete() // tests the entire grid for valid values in every cell (is the game over basically)
        {
            bool retval = true;

            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    Coords testcoords = new Coords()
                    {
                        x = x,
                        y = y,
                        v = grid[y,x].currentvalue
                    };
                    if (!CheckValid(testcoords,true))
                    {
                        retval = false;
                    }
                }
            }

            return retval;
        }

        public bool CheckValid(Coords coords,bool ignore) // tests a specific position for a supplied value if it passes all the rules
        {
            bool validRow, validCol, validBox;

            validRow = CheckValidRow(coords,ignore);
            validCol = CheckValidCol(coords,ignore);
            validBox = CheckValidBox(coords,ignore);

            return (validRow && validCol && validBox) ? true : false;

        }

        public bool CheckValid(Coords coords) // tests a specific position for a supplied value if it passes all the rules
        {
            bool validRow, validCol, validBox, validCoord;

            validRow = CheckValidRow(coords);
            validCol = CheckValidCol(coords);
            validBox = CheckValidBox(coords);
            
            //if (grid[coords.y,coords.x].currentvalue == 0){validCoord = true;}else{validCoord = false;}
            validCoord = true;

            return (validRow && validCol && validBox && validCoord) ? true : false;

        }
        public bool CheckValidRow(Coords coords) // check a specific row passes the rules
        {
            bool MatchFound = false;

            for(int i = 0;i<9;i++)
            {
                if(grid[coords.y,i].currentvalue == coords.v){
                    MatchFound = true;
                }
            }

            return MatchFound ? false : true;
        }

        // Use ignore to avoid comparing the current position against the test value (for checking completed grids and not testing insertion values)
        public bool CheckValidRow(Coords coords,bool ignore) // check a specific row passes the rules
        {
            bool MatchFound = false;

            for(int i = 0;i<9;i++)
            {
                if (ignore)
                {
                    if (i != coords.x)
                    {
                        if(grid[coords.y,i].currentvalue == coords.v){
                            MatchFound = true;
                        }
                    }
                }
                else 
                {
                    if(grid[coords.y,i].currentvalue == coords.v){
                        MatchFound = true;
                    }
                }
                
            }

            return MatchFound ? false : true;
        }
        public bool CheckValidCol(Coords coords) // check a specific col passes the rules
        {
            bool MatchFound = false;

            for(int i = 0;i<9;i++)
            {
                if(grid[i,coords.x].currentvalue == coords.v){
                    MatchFound = true;
                }
            }

            return MatchFound ? false : true;
        }

        public bool CheckValidCol(Coords coords,bool ignore) // check a specific col passes the rules
        {

            bool MatchFound = false;

            for(int i = 0;i<9;i++)
            {
                if (ignore)
                {
                    if (i != coords.y)
                    {
                        if(grid[i,coords.x].currentvalue == coords.v){
                            MatchFound = true;
                        }
                    }
                }
                else 
                {
                    if(grid[i,coords.x].currentvalue == coords.v){
                        MatchFound = true;
                    }
                }
                
            }

            return MatchFound ? false : true;
        }

        public bool CheckValidBox(Coords coords) // check a specific box passes the rules
        {
            int boxNo = GetBoxNo(coords);
            bool MatchFound = false;

            for (int y = 0; y < 3; y++)
            {
                int by = GetYStart(boxNo);
                for (int x = 0; x < 3; x++)
                {
                    int bx = GetXStart(boxNo);
                    if(grid[by + y,bx + x].currentvalue == coords.v)
                    {
                        MatchFound = true;
                    }
                }
            }

            return MatchFound ? false : true;

        }

        public bool CheckValidBox(Coords coords,bool ignore) // check a specific box passes the rules
        {
            int boxNo = GetBoxNo(coords);
            bool MatchFound = false;

            for (int y = 0; y < 3; y++)
            {
                int by = GetYStart(boxNo);
                for (int x = 0; x < 3; x++)
                {
                    int bx = GetXStart(boxNo);
                    if(grid[by + y,bx + x].currentvalue == coords.v)
                    {
                        if (ignore)
                        {
                            if (by + y != coords.y && bx + x != coords.x)
                            {
                                MatchFound = true;
                            }
                        } else {
                            MatchFound = true;
                        }
                        
                    }
                }
            }

            return MatchFound ? false : true;

        }

        public int GetBoxNo(Coords coords)
        {
            int x = coords.x;
            int y = coords.y;
            int boxno = -1;

            switch (true)
            {
                case true when x < 3 && y < 3:
                    boxno = 0;
                    break;
                case true when x > 2 && x < 6 && y < 3:
                    boxno = 1;
                    break;   
                case true when x > 5 && x < 9 && y < 3:
                    boxno = 2;
                    break;
                case true when x < 3 && y > 2 && y < 6:
                    boxno = 3;
                    break;
                case true when x > 2 && x < 6 && y > 2 && y < 6:
                    boxno = 4;
                    break;
                case true when x > 5 && x < 9 && y > 2 && y < 6:
                    boxno = 5;
                    break;
                case true when x < 3 && y > 5 && y < 9:
                    boxno = 6;
                    break;
                case true when x > 2 && x < 6 && y > 5 && y < 9:
                    boxno = 7;
                    break;
                case true when x > 5 && x < 9 && y > 5 && y < 9:
                    boxno = 8;
                    break;    
                default:
                    boxno = 0; // just supply 0 value to not break the calling algorithm
                    break;
            }

            return boxno;
        }

        public int GetYStart(int boxNo)
        {
            switch (boxNo)
            {
                case 0:
                    return 0;
                case 1:
                    return 0;
                case 2:
                    return 0;
                case 3:
                    return 3;
                case 4:
                    return 3;
                case 5:
                    return 3;
                case 6:
                    return 6;
                case 7:
                    return 6;
                case 8:
                    return 6;
                default:
                    return 0;
            }
        }

        public int GetXStart(int boxNo)
        {
            switch (boxNo)
            {
                case 0:
                    return 0;
                case 1:
                    return 3;
                case 2:
                    return 6;
                case 3:
                    return 0;
                case 4:
                    return 3;
                case 5:
                    return 6;
                case 6:
                    return 0;
                case 7:
                    return 3;
                case 8:
                    return 6;
                default:
                    return 0;
            }
        }

    }

    public class Coords
    {
        public int x; // aka col
        public int y; // aka row
        public int v; // check value
    }

    public class Square
    {
        public List<int> numbers;
        public int currentvalue = 0;
        public bool isSet;
        public int xref;
        public int yref;
        public Square()
        {
            numbers = new List<int>(){1,2,3,4,5,6,7,8,9};
            currentvalue = 0;
        }

        public bool getNextRandomListElement()
        {
            bool retval = true;
            Random rnd = new Random();

            if (numbers.Count > 0)
            {
                int i = (int)rnd.NextInt64(0,numbers.Count); // index
                int s = numbers[i]; // selection
                numbers.Remove(s);
                currentvalue = s;
            }
            else
            {
                currentvalue = 0;
                retval = false;
            }

            return retval;
            
        }

        /// <summary>
        /// resets the number list without newupping the entire object, we dont want to lose the reference in code
        /// </summary>
        public void reset()
        {
            numbers = new List<int>(){1,2,3,4,5,6,7,8,9};
            currentvalue = 0;
        }
    }
