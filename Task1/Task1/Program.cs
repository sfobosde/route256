namespace Task1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using var input = new StreamReader(Console.OpenStandardInput());
			using var output = new StreamWriter(Console.OpenStandardOutput());

			const string expected = "4 3 3 2 2 2 1 1 1 1";

			var count = Convert.ToInt32(input.ReadLine());
			var response = "";

			for (var i = 0; i < count; i++)
			{
				var ships = input.ReadLine().Split().ToList();

				ships.Sort((a, b) => a.CompareTo(b) * -1);

				response += (response.Length == 0 ? "" : "\n") + (String.Join(" ", ships.ToArray()) == expected ? "YES" : "NO");
			}

			output.Write(response);
		}
	}
}