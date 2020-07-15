using ChartJs.Blazor.ChartJS.Common;
using System;
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
		/// <returns>Returns an array where entry i is the cumulative winning total up through year i. Subtracts out buy-in</returns>
		public List<Point> GetNormalizedCumulativeWinnings(double normalizedTo)
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

				point.Y = point.Y * normalizedTo / finishes[i].YearNavigation.BuyIn;

				points.Add(point);
			}

			return points;
		}
	}
}
