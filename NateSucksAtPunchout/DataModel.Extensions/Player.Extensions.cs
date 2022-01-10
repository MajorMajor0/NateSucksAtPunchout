using ChartJs.Blazor.ChartJS.Common;

using System.Collections.Generic;
using System.Linq;

namespace NateSucksAtPunchout.DataModel
{
	public partial class Player
	{

		/// <summary>
		/// Add up all winnings through year 
		/// </summary>
		/// <returns>Returns an array where entry i is teh cumulative winning total up through year i. Subtracts out buy-in</returns>
		public List<Point> GetCumulativeWinnings()
		{
			int n = Finishes.Count;

			var finishes = Finishes.ToArray();

			List<Point> points = new List<Point>();

			for (int i = 0; i < n; i++)
			{
				Point point = new Point { X = finishes[i].Year };

				for (int j = 0; j <= i; j++)
				{
					point.Y += finishes[j].Amount - finishes[j].YearNavigation.BuyIn;
				}
				points.Add(point);
			}

			return points;
		}

		/// <summary>
		/// Add up all winnings through year normalized to some number
		/// </summary>
		/// <param name="normalizedTo">Number to normalize to</param>
		/// <returns>Returns an array where entry i is the cumulative winning total up through year i. Subtracts out buy-in</returns>
		public List<Point> GetNormalizedCumulativeWinnings(double normalizedTo)
		{
			int n = Finishes.Count;

			var finishes = Finishes.ToArray();

			List<Point> points = new List<Point>();

			// Calculate normalized total for each year
			for (int i = 0; i < n; i++)
			{
				// X axis is the year
				Point point = new Point { X = finishes[i].Year };

				// Run over years up to and including year i
				for (int j = 0; j <= i; j++)
				{
					// Add the winnings in each year, normalized to the amount provided
					point.Y += (finishes[j].Amount - finishes[j].YearNavigation.BuyIn)
						* normalizedTo / finishes[j].YearNavigation.BuyIn;
				}

				points.Add(point);
			}

			return points;
		}

		/// <summary>
		/// Add up all cumulative wins to year
		/// </summary>
		/// <returns>Returns an array where entry i is the cumulative number of wins up through year i. Subtracts out buy-in</returns>
		public List<Point> GetWins()
		{
			int n = Finishes.Count;

			var finishes = Finishes.ToArray();

			List<Point> points = new List<Point>();

			// Calculate normalized total for each year
			for (int i = 0; i < n; i++)
			{
				// X axis is the year
				Point point = new Point { X = finishes[i].Year };

				// Run over years up to and including year i
				for (int j = 0; j <= i; j++)
				{
					// Add the winnings in each year, normalized to the amount provided
					if (finishes[j].Place == 1)
					{
						point.Y++;
					}
				}

				points.Add(point);
			}

			return points;
		}

		/// <summary>
		/// Add up all hours played through year normalized to some number
		/// </summary>
		/// <param name="normalizedTo">Number to normalize to</param>
		/// <returns>Returns an array where entry i is the cumulative winning total up through year i. Subtracts out buy-in</returns>
		public List<Point> GetNormalizedCumulativeHours(double normalizedTo)
		{
			int n = Finishes.Count;

			var finishes = Finishes.ToArray();

			List<Point> points = new List<Point>();

			// Calculate normalized total for each year
			for (int i = 0; i < n; i++)
			{
				// X axis is the year
				Point point = new Point { X = finishes[i].Year };

				// Run over years up to and including year i
				for (int j = 0; j <= i; j++)
				{
					// Add the winnings in each year, normalized to the amount provided
					point.Y += finishes[j].Time * normalizedTo / finishes[j].YearNavigation.Length;
				}

				points.Add(point);
			}

			return points;
		}
	}
}
