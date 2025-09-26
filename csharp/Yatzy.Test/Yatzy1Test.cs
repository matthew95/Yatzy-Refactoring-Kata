using Xunit;
using static Yatzy1.Yatzy1;

namespace Yatzy.Test
{
    public class Yatzy1Test
    {
        [Fact]
        public void Chance_scores_sum_of_all_dice()
        {
            var expected = 15;
            var actual = Chance(2, 3, 4, 5, 1);
            Assert.Equal(expected, actual);
            Assert.Equal(16, Chance(3, 3, 4, 5, 1));
        }

        [Fact]
        public void Fact_Ones()
        {
            Assert.Equal(1, Ones([1, 2, 3, 4, 5]));
            Assert.Equal(2, Ones([1, 2, 1, 4, 5]));
            Assert.Equal(0, Ones([6, 2, 2, 4, 5]));
            Assert.Equal(4, Ones([1, 2, 1, 1, 1]));
        }

        [Fact]
        public void Fact_2s()
        {
            Assert.Equal(4, Twos(1, 2, 3, 2, 6));
            Assert.Equal(10, Twos(2, 2, 2, 2, 2));
        }

        [Fact]
        public void Fact_threes()
        {
            Assert.Equal(6, Threes(1, 2, 3, 2, 3));
            Assert.Equal(12, Threes(2, 3, 3, 3, 3));
        }

        [Fact]
        public void fives()
        {
            Assert.Equal(10, new Yatzy1.Yatzy1(4, 4, 4, 5, 5).Fives());
            Assert.Equal(15, new Yatzy1.Yatzy1(4, 4, 5, 5, 5).Fives());
            Assert.Equal(20, new Yatzy1.Yatzy1(4, 5, 5, 5, 5).Fives());
        }

        [Fact]
        public void four_of_a_knd()
        {
            Assert.Equal(12, FourOfAKind(3, 3, 3, 3, 5));
            Assert.Equal(20, FourOfAKind(5, 5, 5, 4, 5));
            Assert.Equal(12, FourOfAKind(3, 3, 3, 3, 3));
        }

        [Fact]
        public void fours_Fact()
        {
            Assert.Equal(12, new Yatzy1.Yatzy1(4, 4, 4, 5, 5).Fours());
            Assert.Equal(8, new Yatzy1.Yatzy1(4, 4, 5, 5, 5).Fours());
            Assert.Equal(4, new Yatzy1.Yatzy1(4, 5, 5, 5, 5).Fours());
        }

        [Fact]
        public void fullHouse()
        {
            Assert.Equal(18, FullHouse(6, 2, 2, 2, 6));
            Assert.Equal(0, FullHouse(2, 3, 4, 5, 6));
        }

        [Fact]
        public void largeStraight()
        {
            Assert.Equal(20, LargeStraight(6, 2, 3, 4, 5));
            Assert.Equal(20, LargeStraight(2, 3, 4, 5, 6));
            Assert.Equal(0, LargeStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void one_pair()
        {
            Assert.Equal(6, new Yatzy1.Yatzy1().ScorePair(3, 4, 3, 5, 6));
            Assert.Equal(10, new Yatzy1.Yatzy1().ScorePair(5, 3, 3, 3, 5));
            Assert.Equal(12, new Yatzy1.Yatzy1().ScorePair(5, 3, 6, 6, 5));
        }

        [Fact]
        public void sixes_Fact()
        {
            Assert.Equal(0, new Yatzy1.Yatzy1(4, 4, 4, 5, 5).sixes());
            Assert.Equal(6, new Yatzy1.Yatzy1(4, 4, 6, 5, 5).sixes());
            Assert.Equal(18, new Yatzy1.Yatzy1(6, 5, 6, 6, 5).sixes());
        }

        [Fact]
        public void smallStraight()
        {
            Assert.Equal(15, SmallStraight(1, 2, 3, 4, 5));
            Assert.Equal(15, SmallStraight(2, 3, 4, 5, 1));
            Assert.Equal(0, SmallStraight(1, 2, 2, 4, 5));
        }

        [Fact]
        public void three_of_a_kind()
        {
            Assert.Equal(9, ThreeOfAKind(3, 3, 3, 4, 5));
            Assert.Equal(15, ThreeOfAKind(5, 3, 5, 4, 5));
            Assert.Equal(9, ThreeOfAKind(3, 3, 3, 3, 5));
        }

        [Fact]
        public void two_Pair()
        {
            Assert.Equal(16, TwoPair(3, 3, 5, 4, 5));
            Assert.Equal(16, TwoPair(3, 3, 5, 5, 5));
        }

        [Fact]
        public void Yatzy_scores_50()
        {
            var expected = 50;
            var actual = yatzy(4, 4, 4, 4, 4);
            Assert.Equal(expected, actual);
            Assert.Equal(50, yatzy(6, 6, 6, 6, 6));
            Assert.Equal(0, yatzy(6, 6, 6, 6, 3));
        }
    }
}