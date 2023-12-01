var sum = File.ReadAllLines("input.txt")
   .Select(s => s.Trim())
   .Select(s => GetFirstDigit(s) + GetLastDigit(s))
   .Select(int.Parse)
   .Sum();

Console.WriteLine(sum);

string GetFirstDigit(string s)
{
   for (var i = 0; i < s.Length; i++)
   {
      if (!TryGetValue(s, i, out var value)) continue;
      return value;
   }

   throw new InvalidOperationException();
}

string GetLastDigit(string s)
{
   for (var i = s.Length - 1; i >= 0; i--)
   {
      if (!TryGetValue(s, i, out var value)) continue;
      return value;
   }

   throw new InvalidOperationException();
}

bool TryGetValue(string s, int index, out string value)
{
   value = "";

   foreach (var v in GetValues())
   {
      if (!s.Substring(index).StartsWith(v))
         continue;

      value = int.TryParse(v, out var i)
         ? i.ToString()
         : v switch
         {
            "one" => "1",
            "two" => "2",
            "three" => "3",
            "four" => "4",
            "five" => "5",
            "six" => "6",
            "seven" => "7",
            "eight" => "8",
            "nine" => "9",
            _ => throw new Exception(v)
         };

      return true;
   }

   return false;
}

string[] GetValues() => new[]
{
   "1",
   "2",
   "3",
   "4",
   "5",
   "6",
   "7",
   "8",
   "9",
   "one",
   "two",
   "three",
   "four",
   "five",
   "six",
   "seven",
   "eight",
   "nine"
};