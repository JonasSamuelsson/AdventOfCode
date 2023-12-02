var maxs = new Dictionary<string, int>
{
   { "red", 12 },
   { "green", 13 },
   { "blue", 14 }
};

var result = ReadGames()
   .Where(IsMatch)
   .Sum(x => x.Id);

Console.WriteLine(result);

IEnumerable<Game> ReadGames()
{
   var lines = File.ReadAllLines("input.txt");

   foreach (var line in lines)
   {
      var strings = line.Split(":");

      var game = new Game
      {
         Id = int.Parse(strings[0].Split(' ')[1]),
         Sets = new Dictionary<string, int>()
      };

      foreach (var s in strings[1].Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
      {
         strings = s.Split(" ");
         var count = int.Parse(strings[0]);
         var color = strings[1];
         if (game.Sets.TryGetValue(color, out var c) && c >= count) continue;
         game.Sets[color] = count;
      }

      yield return game;
   }
}

bool IsMatch(Game game)
{
   foreach (var kvp in maxs)
   {
      if (!game.Sets.TryGetValue(kvp.Key, out var count))
         continue;

      if (count <= kvp.Value)
         continue;

      return false;
   }

   return true;
}

class Game
{
   public int Id { get; set; }
   public Dictionary<string, int> Sets { get; set; }
}