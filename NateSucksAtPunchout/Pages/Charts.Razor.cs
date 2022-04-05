using ChartJs.Blazor.ChartJS.Common.Properties;
using ChartJs.Blazor.ChartJS.ScatterChart;
using ChartJs.Blazor.Charts;
using ChartJs.Blazor.Util;

using Microsoft.EntityFrameworkCore;

using NateSucksAtPunchout.DataModel;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NateSucksAtPunchout.Pages
{
	public partial class Charts
	{
		/// <summary>
		/// Go out to the database on load the cumulative winnings chart information
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		private static List<ScatterDataset> GetCumulativeWinningDataSets(BigGameStatsContext context)
		{
			List<ScatterDataset> returner = new();

			var players = context.Players.Include(x => x.Finishes).ThenInclude(x => x.YearNavigation).ToList();

			foreach (Player player in players)
			{
				ScatterDataset sds = player.GetScatterDataSet();
				returner.Add(sds);
			}

			return returner;
		}

		/// <summary>
		/// Go out to the database on load the normal winnings chart information
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		private static List<ScatterDataset> GetNormalizedCumulativeWinningDataSets(BigGameStatsContext context, double normalizedTo)
		{
			List<ScatterDataset> returner = new();
			var players = context.Players.Include(x => x.Finishes).ThenInclude(x => x.YearNavigation).ToList();

			foreach (Player player in players)
			{
				string color = ColorUtil.RandomColorString();
				ScatterDataset sds = player.GetScatterDataSet();
				sds.Label = player.FirstName;
				sds.Data = player.GetNormalizedCumulativeWinnings(normalizedTo);
				returner.Add(sds);
			}

			return returner;
		}

		/// <summary>
		/// Go out to the database on load the wins chart information
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		private static List<ScatterDataset> GetWinsDataSets(BigGameStatsContext context)
		{
			List<ScatterDataset> returner = new();
			var players = context.Players.Include(x => x.Finishes).ThenInclude(x => x.YearNavigation).ToList();

			foreach (Player player in players)
			{
				string color = ColorUtil.RandomColorString();
				ScatterDataset sds = player.GetScatterDataSet();
				sds.Label = player.FirstName;
				sds.Data = player.GetWins();
				returner.Add(sds);
			}

			return returner;
		}

		/// <summary>
		/// Go out to the database on load the normal winnings chart information
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		private static List<ScatterDataset> GetNormalizedCumulativeHoursDataSets(BigGameStatsContext context, double normalizedTo)
		{
			List<ScatterDataset> returner = new();
			var players = context.Players.Include(x => x.Finishes).ThenInclude(x => x.YearNavigation).ToList();

			foreach (Player player in players)
			{
				string color = ColorUtil.RandomColorString();
				ScatterDataset sds = player.GetScatterDataSet();
				sds.Label = player.FirstName;
				sds.Data = player.GetNormalizedCumulativeHours(normalizedTo);
				returner.Add(sds);
			}

			return returner;
		}

		/// <summary>
		/// Chart configuration for the cumulative winnings chart
		/// </summary>
		/// <returns>Returns scatterconfig for the scatter chart</returns>
		private static ScatterConfig LoadConfig(string title)
		{
			return new ScatterConfig
			{
				Options = new ScatterOptions
				{
					Title = new OptionsTitle
					{
						Text = title,
						Display = true
					},

					Scales = new ScatterScales
					{
						XAxes = new List<ScatterAxis>
{
							new ScatterAxis
							{
								Type = "linear"
							}
						}
					}
				}
			};
		}
	}
}
