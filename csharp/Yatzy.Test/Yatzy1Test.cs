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
        public void Fact_Twos()
        {
            Assert.Equal(4, Twos([1, 2, 3, 2, 6]));
            Assert.Equal(10, Twos([2, 2, 2, 2, 2]));
        }

        [Fact]
        public void Fact_Threes()
        {
            Assert.Equal(6, Threes([1, 2, 3, 2, 3]));
            Assert.Equal(12, Threes([2, 3, 3, 3, 3]));
        }
        
        [Fact]
        public void Fact_Fours()
        {
            Assert.Equal(12, Fours([4, 4, 4, 5, 5]));
            Assert.Equal(8, Fours([4, 4, 5, 5, 5]));
            Assert.Equal(4, Fours([4, 5, 5, 5, 5]));
        }

        [Fact]
        public void Fact_Fives()
        {
            Assert.Equal(10, Fives([4, 4, 4, 5, 5]));
            Assert.Equal(15, Fives([4, 4, 5, 5, 5]));
            Assert.Equal(20, Fives([4, 5, 5, 5, 5]));
        }
        
        [Fact]
        public void Fact_Sixes()
        {
            Assert.Equal(0, Sixes([4, 4, 4, 5, 5]));
            Assert.Equal(6, Sixes([4, 4, 6, 5, 5]));
            Assert.Equal(18, Sixes([6, 5, 6, 6, 5]));
        }

        [Fact]
        public void four_of_a_knd()
        {
            Assert.Equal(12, FourOfAKind(3, 3, 3, 3, 5));
            Assert.Equal(20, FourOfAKind(5, 5, 5, 4, 5));
            Assert.Equal(12, FourOfAKind(3, 3, 3, 3, 3));
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