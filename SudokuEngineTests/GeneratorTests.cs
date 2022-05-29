using SudokuEngine;

namespace SudokuEngineTests;

[TestClass]
public class CalculationTests
{
    SudokuGenerator generator;
    [TestMethod]
    public void GetBoxTests()
    {
        // Boxes are laid out like this
        // 0|1|2
        // -----
        // 3|4|5
        // -----
        // 6|7|8

        // Each box is made up of a 3x3 grid like this (y,x)
        // 0,0|0,1|0,2
        // -----------
        // 1,0|1,1|1,2
        // -----------
        // 2,0|2,1|2,2

        generator = new SudokuGenerator();
        // test the 4 corners of each box for boundary logic

        // Box 0
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 0,y = 0,v = 0}) == 0);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 2,y = 0,v = 0}) == 0);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 0,y = 2,v = 0}) == 0);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 2,y = 2,v = 0}) == 0);

        // Box 1
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 3,y = 0,v = 0}) == 1);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 5,y = 0,v = 0}) == 1);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 3,y = 2,v = 0}) == 1);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 5,y = 2,v = 0}) == 1);

        // Box 2
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 6,y = 0,v = 0}) == 2);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 8,y = 0,v = 0}) == 2);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 6,y = 2,v = 0}) == 2);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 8,y = 2,v = 0}) == 2);

        // Box 3
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 0,y = 3,v = 0}) == 3);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 2,y = 3,v = 0}) == 3);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 0,y = 5,v = 0}) == 3);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 2,y = 5,v = 0}) == 3);

        // Box 4
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 3,y = 3,v = 0}) == 4);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 5,y = 3,v = 0}) == 4);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 3,y = 5,v = 0}) == 4);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 5,y = 5,v = 0}) == 4);

        // Box 5
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 6,y = 3,v = 0}) == 5);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 8,y = 3,v = 0}) == 5);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 6,y = 5,v = 0}) == 5);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 8,y = 5,v = 0}) == 5);

        // Box 6
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 0,y = 6,v = 0}) == 6);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 2,y = 6,v = 0}) == 6);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 0,y = 8,v = 0}) == 6);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 2,y = 8,v = 0}) == 6);

        // Box 7
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 3,y = 6,v = 0}) == 7);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 5,y = 6,v = 0}) == 7);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 3,y = 8,v = 0}) == 7);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 5,y = 8,v = 0}) == 7);

        // Box 8
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 6,y = 6,v = 0}) == 8);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 8,y = 6,v = 0}) == 8);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 6,y = 8,v = 0}) == 8);
        Assert.IsTrue(generator.GetBoxNo(new Coords(){x = 8,y = 8,v = 0}) == 8);

    }
}

[TestClass]
public class LogicTests
{
    SudokuGenerator generator;
    PartialGenerators pgen;

    [TestMethod]
    public void CheckRowTests_Row0()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateRow(new int[]{1,2,3,0,0,0,7,8,9},0);
        Assert.IsTrue(generator.CheckValidRow(new Coords(){x=0,y=0,v=4})); // default good check
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=0,v=3})); // false anywhere
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=0,v=1})); // false array start
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=0,v=9})); // false array end

    }

    [TestMethod]
    public void CheckRowTests_Row1()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateRow(new int[]{9,8,7,0,0,0,3,2,1},1);
        Assert.IsTrue(generator.CheckValidRow(new Coords(){x=0,y=1,v=4})); // default good check
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=1,v=3})); // false anywhere
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=1,v=1})); // false array extreme 1
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=1,v=9})); // false array extreme 2

    }

    [TestMethod]
    public void CheckRowTests_Row4()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateRow(new int[]{5,1,2,0,3,4,0,0,6},4);
        Assert.IsTrue(generator.CheckValidRow(new Coords(){x=0,y=4,v=7})); // default good check
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=4,v=3})); // false anywhere
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=4,v=5})); // false array extreme 1
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=4,v=6})); // false array extreme 2

    }

      [TestMethod]
    public void CheckRowTests_Row7()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateRow(new int[]{7,8,9,0,0,0,1,2,3},7);
        Assert.IsTrue(generator.CheckValidRow(new Coords(){x=0,y=7,v=4})); // default good check
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=7,v=8})); // false anywhere
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=7,v=7})); // false array extreme 1
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=7,v=3})); // false array extreme 2

    }

      [TestMethod]
    public void CheckRowTests_Row8()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateRow(new int[]{5,4,3,2,0,0,0,1,6},8);
        Assert.IsTrue(generator.CheckValidRow(new Coords(){x=0,y=8,v=7})); // default good check
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=8,v=3})); // false anywhere
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=8,v=5})); // false array extreme 1
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=8,v=6})); // false array extreme 2

    }

    [TestMethod]
    public void CheckColTests_Col0()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateCol(new int[]{1,2,3,0,0,0,7,8,9},0);
        Assert.IsTrue(generator.CheckValidCol(new Coords(){x=0,y=0,v=4})); // default good check
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=0,y=0,v=3})); // false anywhere
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=0,y=0,v=1})); // false array start
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=0,y=0,v=9})); // false array end

    }

       [TestMethod]
    public void CheckColTests_Col1()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateCol(new int[]{9,8,7,0,0,0,3,2,1},1);
        Assert.IsTrue(generator.CheckValidCol(new Coords(){x=1,y=0,v=4})); // default good check
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=1,y=0,v=3})); // false anywhere
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=1,y=0,v=1})); // false array start
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=1,y=0,v=9})); // false array end

    }

    [TestMethod]
    public void CheckColTests_Col5()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateCol(new int[]{5,1,2,0,3,4,0,0,6},5);
        Assert.IsTrue(generator.CheckValidCol(new Coords(){x=5,y=0,v=7})); // default good check
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=5,y=0,v=3})); // false anywhere
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=5,y=0,v=5})); // false array start
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=5,y=0,v=6})); // false array end

    }

    [TestMethod]
    public void CheckColTests_Col7()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateCol(new int[]{7,8,9,0,0,0,1,2,3},7);
        Assert.IsTrue(generator.CheckValidCol(new Coords(){x=7,y=0,v=5})); // default good check
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=7,y=0,v=2})); // false anywhere
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=7,y=0,v=7})); // false array start
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=7,y=0,v=3})); // false array end

    }

    [TestMethod]
    public void CheckColTests_Col8()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateCol(new int[]{5,1,2,0,3,4,0,0,6},8);
        Assert.IsTrue(generator.CheckValidCol(new Coords(){x=8,y=0,v=7})); // default good check
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=8,y=0,v=3})); // false anywhere
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=8,y=0,v=5})); // false array start
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=8,y=0,v=6})); // false array end

    }

    [TestMethod]
    public void CheckBoxTests_Box0()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateBox(new int[3,3]{{1,2,3},{0,0,0},{6,7,8}},0,0);
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=0,y=0,v=4})); // default good check
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=1,y=1,v=7})); // false anywhere
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=2,y=2,v=1})); // false top left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=0,y=0,v=3})); // false top right
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=1,y=1,v=6})); // false bottom left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=2,y=2,v=8})); // false bottom right

    }

    [TestMethod]
    public void CheckBoxTests_Box1()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateBox(new int[3,3]{{3,2,1},{4,0,6},{9,8,7}},3,0);
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=3,y=0,v=5})); // default good check
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=4,y=1,v=2})); // false anywhere
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=5,y=2,v=3})); // false top left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=3,y=0,v=1})); // false top right
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=4,y=1,v=9})); // false bottom left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=5,y=2,v=7})); // false bottom right
        
    }

    [TestMethod]
    public void CheckBoxTests_Box2()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateBox(new int[3,3]{{1,2,3},{4,5,6},{7,0,9}},6,0);
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=6,y=0,v=8})); // default good check
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=7,y=1,v=5})); // false anywhere
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=8,y=2,v=1})); // false top left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=6,y=0,v=3})); // false top right
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=7,y=1,v=7})); // false bottom left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=8,y=2,v=9})); // false bottom right
        
    }

    [TestMethod]
    public void CheckBoxTests_Box3()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateBox(new int[3,3]{{1,2,3},{0,0,0},{6,7,8}},0,3);
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=0,y=3,v=5})); // default good check
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=1,y=4,v=7})); // false anywhere
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=2,y=5,v=1})); // false top left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=0,y=3,v=3})); // false top right
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=1,y=4,v=6})); // false bottom left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=2,y=5,v=8})); // false bottom right

    }

    [TestMethod]
    public void CheckBoxTests_Box4()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateBox(new int[3,3]{{3,2,1},{4,0,6},{9,8,7}},3,3);
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=3,y=3,v=5})); // default good check
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=4,y=4,v=2})); // false anywhere
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=5,y=5,v=3})); // false top left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=3,y=3,v=1})); // false top right
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=4,y=4,v=9})); // false bottom left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=5,y=5,v=7})); // false bottom right
        
    }

    [TestMethod]
    public void CheckBoxTests_Box5()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateBox(new int[3,3]{{1,2,3},{4,5,6},{7,0,9}},6,3);
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=6,y=3,v=8})); // default good check
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=7,y=4,v=5})); // false anywhere
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=8,y=5,v=1})); // false top left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=6,y=3,v=3})); // false top right
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=7,y=4,v=7})); // false bottom left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=8,y=5,v=9})); // false bottom right
        
    }

    [TestMethod]
    public void CheckBoxTests_Box6()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateBox(new int[3,3]{{1,2,3},{0,0,0},{6,7,8}},0,6);
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=0,y=6,v=5})); // default good check
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=1,y=7,v=7})); // false anywhere
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=2,y=8,v=1})); // false top left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=0,y=6,v=3})); // false top right
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=1,y=7,v=6})); // false bottom left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=2,y=8,v=8})); // false bottom right

    }

    [TestMethod]
    public void CheckBoxTests_Box7()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateBox(new int[3,3]{{3,2,1},{4,0,6},{9,8,7}},3,6);
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=3,y=6,v=5})); // default good check
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=4,y=7,v=2})); // false anywhere
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=5,y=8,v=3})); // false top left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=3,y=6,v=1})); // false top right
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=4,y=7,v=9})); // false bottom left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=5,y=8,v=7})); // false bottom right
        
    }

    [TestMethod]
    public void CheckBoxTests_Box8()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateBox(new int[3,3]{{1,2,3},{4,5,6},{7,0,9}},6,6);
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=6,y=6,v=8})); // default good check
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=7,y=7,v=5})); // false anywhere
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=8,y=8,v=1})); // false top left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=6,y=6,v=3})); // false top right
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=7,y=7,v=7})); // false bottom left
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=8,y=8,v=9})); // false bottom right
        
    }

    [TestMethod]
    public void CheckValidTests_Test1()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateRow(new int[9]{1,0,3,0,2,0,7,8,9},0);
        pgen.GenerateCol(new int[9]{1,4,7,2,3,8,9,0,0},0);
        pgen.GenerateBox(new int[3,3]{{1,2,3},{0,0,0},{7,0,9}},0,0);
        Assert.IsTrue(generator.CheckValid(new Coords(){x=0,y=1,v=4})); // default good check
        Assert.IsFalse(generator.CheckValid(new Coords(){x=0,y=1,v=8})); // false anywhere
        Assert.IsFalse(generator.CheckValid(new Coords(){x=0,y=0,v=4})); // false position filled 1 
        Assert.IsFalse(generator.CheckValid(new Coords(){x=2,y=2,v=4})); // false position filled 2
        Assert.IsFalse(generator.CheckValid(new Coords(){x=1,y=0,v=7})); // false row
        Assert.IsFalse(generator.CheckValid(new Coords(){x=1,y=0,v=8})); // false column
        Assert.IsFalse(generator.CheckValid(new Coords(){x=2,y=1,v=9})); // false box
    }
}