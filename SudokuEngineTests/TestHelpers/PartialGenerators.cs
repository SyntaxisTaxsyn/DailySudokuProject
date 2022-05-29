using SudokuEngine;

public class PartialGenerators
{
    public SudokuGenerator generator;

    public PartialGenerators()
    {
        generator = new SudokuGenerator();
    }

    public void GenerateGrid(int[,] grid)
    {
        for (int y = 0; y < 9; y++)
        {
            for (int x = 0; x < 9; x++)
            {
                generator.grid[y,x].currentvalue = grid[y,x];
            }
        }
    }

    public void GenerateRow(int[] vals,int y){
        for (int i = 0; i < 9; i++)
        {
            generator.grid[y,i].currentvalue = vals[i];
        }
    }
    public void GenerateCol(int[] vals,int x){
        for (int i = 0; i < 9; i++)
        {
            generator.grid[i,x].currentvalue = vals[i];
        }
    }
    public void GenerateBox(int[,] vals,int _x,int _y)
    {

        int boxNo = generator.GetBoxNo(new Coords(){x = _x, y = _y, v = 1});

        for (int y = 0; y < 3; y++)
        {
            int by = GetYStart(boxNo);
            for (int x = 0; x < 3; x++)
            { 
                int bx = GetXStart(boxNo);
                generator.grid[by+y,bx+x].currentvalue = vals[y,x];
            }
        }

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