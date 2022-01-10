﻿using ChartJs.Blazor.ChartJS.Common.Properties;
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
		private int pointRadius = 3;
		/// <summary>
		/// Go out to the database on load the cumulative winnings chart information
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		private List<ScatterDataset> GetCumulativeWinningDataSets(BigGameStatsContext context)
		{
			List<ScatterDataset> returner = new List<ScatterDataset>();

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
		private List<ScatterDataset> GetNormalizedCumulativeWinningDataSets(BigGameStatsContext context, double normalizedTo)
		{
			List<ScatterDataset> returner = new List<ScatterDataset>();
			var players = context.Players.Include(x => x.Finishes).ThenInclude(x => x.YearNavigation).ToList();

			foreach (Player player in players)
			{
				string color = ColorUtil.RandomColorString();
				ScatterDataset sds = new ScatterDataset
				{
					BackgroundColor = player.Color,
					BorderColor = player.Color,
					ShowLine = true,
					LineTension = 0,
					PointRadius = pointRadius,
					PointHitRadius = 5,
					PointHoverRadius = 8
				};
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
		private List<ScatterDataset> GetWinsDataSets(BigGameStatsContext context)
		{
			List<ScatterDataset> returner = new List<ScatterDataset>();
			var players = context.Players.Include(x => x.Finishes).ThenInclude(x => x.YearNavigation).ToList();

			foreach (Player player in players)
			{
				string color = ColorUtil.RandomColorString();
				ScatterDataset sds = new ScatterDataset
				{
					BackgroundColor = player.Color,
					BorderColor = player.Color,
					ShowLine = true,
					LineTension = 0,
					PointRadius = pointRadius,
					PointHitRadius = 5,
					PointHoverRadius = 8
				};
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
		private List<ScatterDataset> GetNormalizedCumulativeHoursDataSets(BigGameStatsContext context, double normalizedTo)
		{
			List<ScatterDataset> returner = new List<ScatterDataset>();
			var players = context.Players.Include(x => x.Finishes).ThenInclude(x => x.YearNavigation).ToList();

			foreach (Player player in players)
			{
				string color = ColorUtil.RandomColorString();
				ScatterDataset sds = new ScatterDataset
				{
					BackgroundColor = player.Color,
					BorderColor = player.Color,
					ShowLine = true,
					LineTension = 0,
					PointRadius = pointRadius,
					PointHitRadius = 5,
					PointHoverRadius = 8
				};
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
		private ScatterConfig LoadConfig(string title)
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
