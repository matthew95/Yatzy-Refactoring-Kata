using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy1;
public class YatzyCategoryScorer1
{
    private List<int> _dice = [];

    public YatzyCategoryScorer1 SetDice(List<int> dice)
    {
        if (dice is not { Count: 5 })
        {
            throw new Exception("just play with five dice");
        }
        
        _dice = dice;
        
        return this;
    }
    
    public int Chance(int d1, int d2, int d3, int d4, int d5)
    {
        var total = 0;
        total += d1;
        total += d2;
        total += d3;
        total += d4;
        total += d5;
        return total;
    }
    public int yatzy(params int[] dice)
    {
        var counts = new int[6];
        foreach (var die in dice)
            counts[die - 1]++;
        for (var i = 0; i != 6; i++)
            if (counts[i] == 5)
                return 50;
        return 0;
    }

    private static int Ns(int n, List<int> dice)
    {
        return dice.Where(die => die == n).Sum();
    }

    private static int NOfKind(int n, List<int> dice)
    {
        return KindCount(dice)
            .Where(item => item.Value >= n) // where item occurs at least n times
            .OrderByDescending(item => item.Key)
            .Select(item => item.Key)
            .FirstOrDefault() * n;
    }

    private static Dictionary<int, int> KindCount(List<int> dice)
    {
        Dictionary<int, int> dict = new();
        for (var i = 1; i <= 6; i++)
        {
            dict[i] = 0;
        }

        dice.ForEach(d => dict[d]++);
        return dict;
    }
    
    private static int Straight(List<int> dice)
    {
        var diceCopy = new List<int>(dice);
        diceCopy.Sort();
        
        List<int> smallStraight = [1, 2, 3, 4, 5];
        List<int> largeStraight = [2, 3, 4, 5, 6];
        
        if (diceCopy.SequenceEqual(smallStraight) || 
            diceCopy.SequenceEqual(largeStraight))
        {
            return diceCopy.Sum();
        }

        return 0;
    }
    
    public int Ones()
    {
        return Ns(1, _dice);
    }
    
    public int Twos()
    {
        return Ns(2, _dice);
    }
    public int Threes()
    {
        return Ns(3, _dice);
    }
    
    public int Fours()
    {
        return Ns(4, _dice);
    }
    public int Fives()
    {
        return Ns(5, _dice);
    }
    public int Sixes()
    {
        return Ns(6, _dice);
    }
    
    public int ScorePair(int d1, int d2, int d3, int d4, int d5)
    {
        var counts = new int[6];
        counts[d1 - 1]++;
        counts[d2 - 1]++;
        counts[d3 - 1]++;
        counts[d4 - 1]++;
        counts[d5 - 1]++;
        int at;
        for (at = 0; at != 6; at++)
            if (counts[6 - at - 1] >= 2)
                return (6 - at) * 2;
        return 0;
    }
    public int TwoPair(int d1, int d2, int d3, int d4, int d5)
    {
        var counts = new int[6];
        counts[d1 - 1]++;
        counts[d2 - 1]++;
        counts[d3 - 1]++;
        counts[d4 - 1]++;
        counts[d5 - 1]++;
        var n = 0;
        var score = 0;
        for (var i = 0; i < 6; i += 1)
            if (counts[6 - i - 1] >= 2)
            {
                n++;
                score += 6 - i;
            }

        if (n == 2)
            return score * 2;
        return 0;
    }
    public int FourOfAKind()
    {
        return NOfKind(4, _dice);
    }
    
    public int ThreeOfAKind()
    {
        return NOfKind(3, _dice);
    }
    
    public int SmallStraight()
    {
        return Straight(_dice);
    }
    
    public int LargeStraight()
    {
        return Straight(_dice);
    }
    public int FullHouse()
    {
       return KindCount(_dice)// create cartesian product with select many so that we can filter pairs where the kindcounts are 2 and 3.
           .SelectMany(x => KindCount(_dice), (first, second) => new { First = first, Second = second})
           .Where( x => 
                        x.First.Key != x.Second.Key &&
                        (
                            x.First.Value == 2 && x.Second.Value == 3 ||
                            x.First.Value == 3 && x.Second.Value == 2
                        ))
           .Select(x => x.First.Key * x.First.Value + x.Second.Key * x.Second.Value)
           .FirstOrDefault();
    }
}
