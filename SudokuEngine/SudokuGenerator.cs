namespace SudokuEngine;
public class SudokuGenerator
    {
        public Square[,] grid;
        public SudokuGenerator()
        {
            grid = new Square[9,9];
            for(var y = 0;y<9;y++)
            {
                for(var x = 0;x<9;x++)
                {
                    grid[y,x] = new Square();
                }
            }
        }
        public bool CheckValid(Coords coords)
        {
            bool validRow, validCol, validBox, validCoord;

            validRow = CheckValidRow(coords);
            validCol = CheckValidCol(coords);
            validBox = CheckValidBox(coords);
            
            if (grid[coords.y,coords.x].currentvalue == 0){validCoord = true;}else{validCoord = false;}

            return (validRow && validCol && validBox && validCoord) ? true : false;

        }
        public bool CheckValidRow(Coords coords)
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
        public bool CheckValidCol(Coords coords)
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
        public bool CheckValidBox(Coords coords)
        {
            int boxNo = GetBoxNo(coords);
            //int xs = boxNo; // rework this logic the same as partial generator logic
            //int xe = boxNo + 3;
            //int ys = boxNo;
            //int ye = boxNo + 3;
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
        public Square()
        {
            numbers = new List<int>(){1,2,3,4,5,6,7,8,9};
        }
    }
