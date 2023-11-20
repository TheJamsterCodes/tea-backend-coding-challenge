namespace TEABackEndCodingChallenge;

public class Challenge2
{
   private readonly string _alphabet = "abcdefghijklmnopqrstuvwxyz";

   public int MaxDistance(string input)
   {
        var distances = new List<int>();

        for (int b = 0; b < input.Length; b++)
        {            
            int startingIndex = b + 1;

            for (int c = startingIndex; c < input.Length; c++)
            {
                if (input[b] < input[c])
                {
                    int distance = FindDistance(input[b], input[c]);
                    distances.Add(distance);
                }
            }
        }

        int maxDistance = distances.Count > 0 ? distances.Max() : 0;

        return maxDistance;
   }

   private int FindDistance(char char1, char char2)
   {
        int char1Index = _alphabet.IndexOf(char1) + 1;
        int char2Index = _alphabet.IndexOf(char2);
        int difference = char2Index - char1Index;
        return difference;
   }
}