using Xunit;
using Yatzy1;

namespace Yatzy.Test;

public class Yatzy1Test
{
    private static YatzyCategoryScorer1 CategoryScorer()
    {
        return new YatzyCategoryScorer1();
    }
    
    [Fact]
    public void Test_Chance()
    {
        Assert.Equal(15, CategoryScorer().Chance(2, 3, 4, 5, 1));
        Assert.Equal(16, CategoryScorer().Chance(3, 3, 4, 5, 1));
    }

    [Fact]
    public void Test_Ones()
    {
        Assert.Equal(1, CategoryScorer().SetDice([1, 2, 3, 4, 5]).Ones());
        Assert.Equal(2, CategoryScorer().SetDice([1, 2, 1, 4, 5]).Ones());
        Assert.Equal(0, CategoryScorer().SetDice([6, 2, 2, 4, 5]).Ones());
        Assert.Equal(4, CategoryScorer().SetDice([1, 2, 1, 1, 1]).Ones());
    }

    [Fact]
    public void Test_Twos()
    {
        Assert.Equal(4, CategoryScorer().SetDice([1, 2, 3, 2, 6]).Twos());
        Assert.Equal(10, CategoryScorer().SetDice([2, 2, 2, 2, 2]).Twos());
    }

    [Fact]
    public void Test_Threes()
    {
        Assert.Equal(6, CategoryScorer().SetDice([1, 2, 3, 2, 3]).Threes());
        Assert.Equal(12, CategoryScorer().SetDice([2, 3, 3, 3, 3]).Threes());
    }
    
    [Fact]
    public void Test_Fours()
    {
        Assert.Equal(12, CategoryScorer().SetDice([4, 4, 4, 5, 5]).Fours());
        Assert.Equal(8, CategoryScorer().SetDice([4, 4, 5, 5, 5]).Fours());
        Assert.Equal(4, CategoryScorer().SetDice([4, 5, 5, 5, 5]).Fours());
    }

    [Fact]
    public void Test_Fives()
    {
        Assert.Equal(10, CategoryScorer().SetDice([4, 4, 4, 5, 5]).Fives());
        Assert.Equal(15, CategoryScorer().SetDice([4, 4, 5, 5, 5]).Fives());
        Assert.Equal(20, CategoryScorer().SetDice([4, 5, 5, 5, 5]).Fives());
    }
    
    [Fact]
    public void Test_Sixes()
    {
        Assert.Equal(0, CategoryScorer().SetDice([4, 4, 4, 5, 5]).Sixes());
        Assert.Equal(6, CategoryScorer().SetDice([4, 4, 6, 5, 5]).Sixes());
        Assert.Equal(18, CategoryScorer().SetDice([6, 5, 6, 6, 5]).Sixes());
    }

    [Fact]
    public void Test_FourOfAKind()
    {
        Assert.Equal(12, CategoryScorer().SetDice([3, 3, 3, 3, 5]).FourOfAKind());
        Assert.Equal(20, CategoryScorer().SetDice([5, 5, 5, 4, 5]).FourOfAKind());
        Assert.Equal(12, CategoryScorer().SetDice([3, 3, 3, 3, 3]).FourOfAKind());
    }

    [Fact]
    public void fullHouse()
    {
        Assert.Equal(18, CategoryScorer().SetDice([6, 2, 2, 2, 6]).FullHouse());
        Assert.Equal(0, CategoryScorer().SetDice([2, 3, 4, 5, 6]).FullHouse());
    }

    [Fact]
    public void largeStraight()
    {
        Assert.Equal(20, CategoryScorer().SetDice([6, 2, 3, 4, 5]).LargeStraight());
        Assert.Equal(20, CategoryScorer().SetDice([2, 3, 4, 5, 6]).LargeStraight());
        Assert.Equal(0, CategoryScorer().SetDice([1, 2, 2, 4, 5]).LargeStraight());
    }

    [Fact]
    public void one_pair()
    {
        Assert.Equal(6, CategoryScorer().ScorePair(3, 4, 3, 5, 6));
        Assert.Equal(10, CategoryScorer().ScorePair(5, 3, 3, 3, 5));
        Assert.Equal(12, CategoryScorer().ScorePair(5, 3, 6, 6, 5));
    }
    
    [Fact]
    public void smallStraight()
    {
        Assert.Equal(15, CategoryScorer().SetDice([1, 2, 3, 4, 5]).SmallStraight());
        Assert.Equal(15, CategoryScorer().SetDice([2, 3, 4, 5, 1]).SmallStraight());
        Assert.Equal(0, CategoryScorer().SetDice([1, 2, 2, 4, 5]).SmallStraight());
    }

    [Fact]
    public void three_of_a_kind()
    {
        Assert.Equal(9, CategoryScorer().SetDice([3, 3, 3, 4, 5]).ThreeOfAKind());
        Assert.Equal(15, CategoryScorer().SetDice([5, 3, 5, 4, 5]).ThreeOfAKind());
        Assert.Equal(9, CategoryScorer().SetDice([3, 3, 3, 3, 5]).ThreeOfAKind());
    }

    [Fact]
    public void two_Pair()
    {
        Assert.Equal(16, CategoryScorer().TwoPair(3, 3, 5, 4, 5));
        Assert.Equal(16, CategoryScorer().TwoPair(3, 3, 5, 5, 5));
    }

    [Fact]
    public void Yatzy_scores_50()
    {
        var expected = 50;
        var actual = CategoryScorer().yatzy(4, 4, 4, 4, 4);
        Assert.Equal(expected, actual);
        Assert.Equal(50, CategoryScorer().yatzy(6, 6, 6, 6, 6));
        Assert.Equal(0, CategoryScorer().yatzy(6, 6, 6, 6, 3));
    }
}
