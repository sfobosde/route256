namespace Task2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Проверка даты.
			using var input = new StreamReader(Console.OpenStandardInput());
			using var output = new StreamWriter(Console.OpenStandardOutput());

			int[] days_of_month = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

			// Проверка, является год високосным. Используем анонимную функцию, чтобы все было в рамках static void Main.
			var is_leap = (int year) => {
				return year % 4 == 0
					&& year % 100 != 0
					|| year % 400 == 0;
			};

			// Проверка на корретность.
			var is_correct = (int day, int month, int year) =>
			{
				// Дополнительный день в високосном году.
				var additional_day = is_leap(year) ? 1 : 0;

				//Получаем количество дней в месяце.
				var max_days_in_month = days_of_month[month];

				//Если это февраль то добавляем ему значение доп дня для високосного года.
				max_days_in_month += (month == 1) ? additional_day : 0;

				return day <= max_days_in_month;
			};


			var count = Convert.ToInt32(input.ReadLine());
			var response = "";

			for (var i = 0; i < count; i++)
			{
				var data  = input.ReadLine().Split();

				var day = int.Parse(data[0]);
				var month = int.Parse(data[1]) - 1;
				var year = int.Parse(data[2]);

				response += (response.Length == 0 ? "" : "\n") + (is_correct(day, month, year) ? "YES" : "NO");
			}

			output.Write(response);
		}
	}
}