using System;
using System.Collections.Generic;

namespace Minimum_Jumps_to_Reach_Home
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }
  }
  public class Solution
  {
    // Time - O(2N), where N is the no of state and each state can be forward or backward
    // Space - O(N)
    public int MinimumJumps(int[] forbidden, int a, int b, int x)
    {
      // BFS can be use to solve this, as question has asked to return the min no of jumps
      // this kind of problem can be solved using BFS, DP, Binary Search
      // will use BFS as it is easy to code
      var set = new HashSet<int>(forbidden);
      Queue<(int, bool)> q = new Queue<(int, bool)>();
      // why enqueued 0 and false
      // o as we are strting from 0th index and false to mark is it a backward move ?
      q.Enqueue((0, false));
      var visited = new HashSet<(int, bool)>();
      visited.Add((0, false));
      int jumps = 0;
      while (q.Count > 0)
      {
        int size = q.Count;
        while (size-- > 0)
        {
          var (currentPosition, isBackward) = q.Dequeue();
          if (currentPosition == x) return jumps;

          // forward jump
          int nextPosition = currentPosition + a;
          if (nextPosition >= 0 && nextPosition < 6000 && !set.Contains(nextPosition) && !visited.Contains((nextPosition, false)))
          {
            q.Enqueue((nextPosition, false));
            visited.Add((nextPosition, false));
          }

          // backward jump
          // we are not allowed to take back to back backward jumps
          int backPosition = currentPosition - b;
          if (!isBackward && backPosition >= 0 && backPosition < 6000 && !set.Contains(backPosition) && !visited.Contains((backPosition, true)))
          {
            q.Enqueue((backPosition, true));
            visited.Add((backPosition, true));
          }
        }

        jumps += 1;
      }

      return -1;
    }
  }
}
