var sum = File.ReadAllLines("input.txt")
   .Select(s => s.Trim())
   .Select(s => GetDigit(s) + GetDigit(string.Join("", s.Reverse())))
   .Select(int.Parse)
   .Sum();

Console.WriteLine(sum);

string GetDigit(string s)
{
   for (var i = 0; i < s.Length; i++)
   {
      var c = s[i];
      if (!char.IsDigit(c)) continue;
      return c.ToString();
   }

   throw new InvalidOperationException();
}