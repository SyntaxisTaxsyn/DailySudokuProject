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

    [TestMethod]
    public void IncrementTests()
    {
        generator = new SudokuGenerator();

        // general increment 1
        generator.XP = 0;
        generator.YP = 0;
        generator.Complete = false;
        generator.incrementPointer();
        Assert.IsTrue(generator.XP == 1);
        Assert.IsTrue(generator.YP == 0);
        Assert.IsFalse(generator.Complete);

        // general increment 2
        generator.XP = 3;
        generator.YP = 4;
        generator.Complete = false;
        generator.incrementPointer();
        Assert.IsTrue(generator.XP == 4);
        Assert.IsTrue(generator.YP == 4);
        Assert.IsFalse(generator.Complete);

        // x edge increment and wrap 1
        generator.XP = 8;
        generator.YP = 0;
        generator.Complete = false;
        generator.incrementPointer();
        Assert.IsTrue(generator.XP == 0);
        Assert.IsTrue(generator.YP == 1);
        Assert.IsFalse(generator.Complete);

        // x edge increment and wrap 2
        generator.XP = 8;
        generator.YP = 3;
        generator.Complete = false;
        generator.incrementPointer();
        Assert.IsTrue(generator.XP == 0);
        Assert.IsTrue(generator.YP == 4);
        Assert.IsFalse(generator.Complete);

        // x edge final wrap block and complete flag
        generator.XP = 8;
        generator.YP = 8;
        generator.Complete = false;
        generator.incrementPointer();
        Assert.IsTrue(generator.XP == 8);
        Assert.IsTrue(generator.YP == 8);
        Assert.IsTrue(generator.Complete);
        
    }

    [TestMethod]
    public void DecrementTests()
    {
        generator = new SudokuGenerator();

        // general decrement 1
        generator.XP = 4;
        generator.YP = 0;
        generator.Complete = false;
        generator.decrementPointer();
        Assert.IsTrue(generator.XP == 3);
        Assert.IsTrue(generator.YP == 0);
        Assert.IsFalse(generator.Complete);

        // general decrement 2
        generator.XP = 7;
        generator.YP = 3;
        generator.Complete = false;
        generator.decrementPointer();
        Assert.IsTrue(generator.XP == 6);
        Assert.IsTrue(generator.YP == 3);
        Assert.IsFalse(generator.Complete);

        // x edge decrement and wrap 1
        generator.XP = 0;
        generator.YP = 5;
        generator.Complete = false;
        generator.decrementPointer();
        Assert.IsTrue(generator.XP == 8);
        Assert.IsTrue(generator.YP == 4);
        Assert.IsFalse(generator.Complete);

        // x edge decrement and wrap 2
        generator.XP = 0;
        generator.YP = 7;
        generator.Complete = false;
        generator.decrementPointer();
        Assert.IsTrue(generator.XP == 8);
        Assert.IsTrue(generator.YP == 6);
        Assert.IsFalse(generator.Complete);

        // x edge decrement final wrap block
        generator.XP = 0;
        generator.YP = 0;
        generator.Complete = false;
        generator.decrementPointer();
        Assert.IsTrue(generator.XP == 0);
        Assert.IsTrue(generator.YP == 0);
        Assert.IsFalse(generator.Complete);

    }

    [TestMethod]
    public void GetRandomNumberFromSquareTests()
    {
        generator = new SudokuGenerator();
        Square testsquare = generator.grid[0,0];
        bool result;

        // Random number test 1
        result = generator.getNextRandomListElement(testsquare);
        Assert.IsTrue(testsquare.currentvalue > 0); // check the number is assigned
        Assert.IsTrue(testsquare.currentvalue < 10); // is inside the expected range
        Assert.IsFalse(testsquare.numbers.Contains(testsquare.currentvalue)); // and that it is removed from the list
        Assert.IsTrue(testsquare.numbers.Count == 8); // that the list is reduced by exactly 1 item
        Assert.IsTrue(result); // and that the function returned true when it completed succesfully

        // Random number test 2
        result = generator.getNextRandomListElement(testsquare);
        Assert.IsTrue(testsquare.currentvalue > 0); // check the number is assigned
        Assert.IsTrue(testsquare.currentvalue < 10); // is inside the expected range
        Assert.IsFalse(testsquare.numbers.Contains(testsquare.currentvalue)); // and that it is removed from the list
        Assert.IsTrue(testsquare.numbers.Count == 7); // that the list is reduced by exactly 1 item
        Assert.IsTrue(result); // and that the function returned true when it completed succesfully

        // Random number test 3
        result = generator.getNextRandomListElement(testsquare);
        Assert.IsTrue(testsquare.currentvalue > 0); // check the number is assigned
        Assert.IsTrue(testsquare.currentvalue < 10); // is inside the expected range
        Assert.IsFalse(testsquare.numbers.Contains(testsquare.currentvalue)); // and that it is removed from the list
        Assert.IsTrue(testsquare.numbers.Count == 6); // that the list is reduced by exactly 1 item
        Assert.IsTrue(result); // and that the function returned true when it completed succesfully

        // Random number test 4
        result = generator.getNextRandomListElement(testsquare);
        Assert.IsTrue(testsquare.currentvalue > 0); // check the number is assigned
        Assert.IsTrue(testsquare.currentvalue < 10); // is inside the expected range
        Assert.IsFalse(testsquare.numbers.Contains(testsquare.currentvalue)); // and that it is removed from the list
        Assert.IsTrue(testsquare.numbers.Count == 5); // that the list is reduced by exactly 1 item
        Assert.IsTrue(result); // and that the function returned true when it completed succesfully

        // Random number test 5
        result = generator.getNextRandomListElement(testsquare);
        Assert.IsTrue(testsquare.currentvalue > 0); // check the number is assigned
        Assert.IsTrue(testsquare.currentvalue < 10); // is inside the expected range
        Assert.IsFalse(testsquare.numbers.Contains(testsquare.currentvalue)); // and that it is removed from the list
        Assert.IsTrue(testsquare.numbers.Count == 4); // that the list is reduced by exactly 1 item
        Assert.IsTrue(result); // and that the function returned true when it completed succesfully

        // Random number test 6
        result = generator.getNextRandomListElement(testsquare);
        Assert.IsTrue(testsquare.currentvalue > 0); // check the number is assigned
        Assert.IsTrue(testsquare.currentvalue < 10); // is inside the expected range
        Assert.IsFalse(testsquare.numbers.Contains(testsquare.currentvalue)); // and that it is removed from the list
        Assert.IsTrue(testsquare.numbers.Count == 3); // that the list is reduced by exactly 1 item
        Assert.IsTrue(result); // and that the function returned true when it completed succesfully

        // Random number test 7
        result = generator.getNextRandomListElement(testsquare);
        Assert.IsTrue(testsquare.currentvalue > 0); // check the number is assigned
        Assert.IsTrue(testsquare.currentvalue < 10); // is inside the expected range
        Assert.IsFalse(testsquare.numbers.Contains(testsquare.currentvalue)); // and that it is removed from the list
        Assert.IsTrue(testsquare.numbers.Count == 2); // that the list is reduced by exactly 1 item
        Assert.IsTrue(result); // and that the function returned true when it completed succesfully

        // Random number test 8
        result = generator.getNextRandomListElement(testsquare);
        Assert.IsTrue(testsquare.currentvalue > 0); // check the number is assigned
        Assert.IsTrue(testsquare.currentvalue < 10); // is inside the expected range
        Assert.IsFalse(testsquare.numbers.Contains(testsquare.currentvalue)); // and that it is removed from the list
        Assert.IsTrue(testsquare.numbers.Count == 1); // that the list is reduced by exactly 1 item
        Assert.IsTrue(result); // and that the function returned true when it completed succesfully

        // Random number test 9
        result = generator.getNextRandomListElement(testsquare);
        Assert.IsTrue(testsquare.currentvalue > 0); // check the number is assigned
        Assert.IsTrue(testsquare.currentvalue < 10); // is inside the expected range
        Assert.IsFalse(testsquare.numbers.Contains(testsquare.currentvalue)); // and that it is removed from the list
        Assert.IsTrue(testsquare.numbers.Count == 0); // that the list is reduced by exactly 1 item
        Assert.IsTrue(result); // and that the function returned true when it completed succesfully

        // List is empty now, try to remove another item from the list and test the response
        result = generator.getNextRandomListElement(testsquare);
        Assert.IsTrue(testsquare.currentvalue == 0); // check a 0 value was assigned
        Assert.IsFalse(result); // and false was returned, list is empty, regenerate it

        Assert.IsTrue(generator.grid[0,0].numbers.Count == 0); // make sure the grid is empty
        generator.resetSquare(testsquare);
        Assert.IsTrue(testsquare.numbers.Count == 9); // check square number list was regenerated successfully
        Assert.IsTrue(testsquare.numbers.Contains(1)); // check that all numbers exist in the list 
        Assert.IsTrue(testsquare.numbers.Contains(2));
        Assert.IsTrue(testsquare.numbers.Contains(3));
        Assert.IsTrue(testsquare.numbers.Contains(4));
        Assert.IsTrue(testsquare.numbers.Contains(5));
        Assert.IsTrue(testsquare.numbers.Contains(6));
        Assert.IsTrue(testsquare.numbers.Contains(7));
        Assert.IsTrue(testsquare.numbers.Contains(8));
        Assert.IsTrue(testsquare.numbers.Contains(9));

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

    [TestMethod]
    public void CheckRowIgnoreTests_Row0()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateRow(new int[]{1,2,3,4,5,6,7,8,9},0);

        // check several positions on the row to ensure the ignore logic is working
        Assert.IsTrue(generator.CheckValidRow(new Coords(){x=0,y=0,v=1},true)); 
        Assert.IsTrue(generator.CheckValidRow(new Coords(){x=1,y=0,v=2},true));
        Assert.IsTrue(generator.CheckValidRow(new Coords(){x=7,y=0,v=8},true));
        Assert.IsTrue(generator.CheckValidRow(new Coords(){x=8,y=0,v=9},true));

        // check same tests fail when ignore option is turned off (logic behaves as previous)
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=0,y=0,v=1},false)); 
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=1,y=0,v=2},false));
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=7,y=0,v=8},false));
        Assert.IsFalse(generator.CheckValidRow(new Coords(){x=8,y=0,v=9},false)); 

    }

    [TestMethod]
    public void CheckColIgnoreTests_Col0()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateCol(new int[]{1,2,3,4,5,6,7,8,9},0);

        // check several positions on the col to ensure the ignore logic is working
        Assert.IsTrue(generator.CheckValidCol(new Coords(){x=0,y=0,v=1},true));
        Assert.IsTrue(generator.CheckValidCol(new Coords(){x=0,y=1,v=2},true));
        Assert.IsTrue(generator.CheckValidCol(new Coords(){x=0,y=7,v=8},true));
        Assert.IsTrue(generator.CheckValidCol(new Coords(){x=0,y=8,v=9},true));

        // check same tests fail when ignore option is turned off (logic behaves as previous)
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=0,y=0,v=1},false));
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=0,y=1,v=2},false));
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=0,y=7,v=8},false));
        Assert.IsFalse(generator.CheckValidCol(new Coords(){x=0,y=8,v=9},false));

    }

    [TestMethod]
    public void CheckBoxIgnoreTests_Box0()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateBox(new int[3,3]{{1,2,3},{4,5,6},{7,8,9}},0,0);

        // check several positions on the box to ensure the ignore logic is working
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=0,y=0,v=1},true));
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=2,y=0,v=3},true));
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=1,y=1,v=5},true));
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=0,y=2,v=7},true));
        Assert.IsTrue(generator.CheckValidBox(new Coords(){x=2,y=2,v=9},true));

        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=0,y=0,v=1},false));
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=2,y=0,v=3},false));
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=1,y=1,v=5},false));
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=0,y=2,v=7},false));
        Assert.IsFalse(generator.CheckValidBox(new Coords(){x=2,y=2,v=9},false));

    }

    [TestMethod]
    public void CheckValidGridTests1()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateGrid(new int[9,9]
        {
            {6,3,9,5,7,4,1,8,2},
            {5,4,1,8,2,9,3,7,6},
            {7,8,2,6,1,3,9,5,4},
            {1,9,8,4,6,7,5,2,3},
            {3,6,5,9,8,2,4,1,7},
            {4,2,7,1,3,5,8,6,9},
            {9,5,6,7,4,8,2,3,1},
            {8,1,3,2,9,6,7,4,5},
            {2,7,4,3,5,1,6,9,8}
        });

        Assert.IsTrue(generator.CheckGridComplete()); // default good check (if this passes, the grid is finished and valid)
        pgen.generator.grid[0,0].currentvalue = 3; // change 1 position and check the validation fails
        Assert.IsFalse(generator.CheckGridComplete());
        pgen.generator.grid[0,0].currentvalue = 6;
        Assert.IsTrue(generator.CheckGridComplete()); // change it back and ensure validation still passes
    }

    [TestMethod]
    public void CheckValidGridTests2()
    {
        pgen = new PartialGenerators();
        generator = pgen.generator;
        pgen.GenerateGrid(new int[9,9]
        {
            {1,2,4,5,6,7,8,9,3},
            {3,7,8,2,9,4,5,1,6},
            {6,5,9,8,3,1,7,4,2},
            {9,8,7,1,2,3,4,6,5},
            {2,3,1,4,5,6,9,7,8},
            {5,4,6,7,8,9,3,2,1},
            {8,6,3,9,7,2,1,5,4},
            {4,9,5,6,1,8,2,3,7},
            {7,1,2,3,4,5,6,8,9}
        });

        Assert.IsTrue(generator.CheckGridComplete()); // default good check (if this passes, the grid is finished and valid)
        pgen.generator.grid[0,0].currentvalue = 3; // change 1 position and check the validation fails
        Assert.IsFalse(generator.CheckGridComplete());
        pgen.generator.grid[0,0].currentvalue = 1;
        Assert.IsTrue(generator.CheckGridComplete()); // change it back and ensure validation still passes
    }
}