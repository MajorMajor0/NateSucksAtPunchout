using ChartJs.Blazor.ChartJS.ScatterChart;

using System.Collections.Generic;

namespace NateSucksAtPunchout.DataModel;

public partial class Player
{
    public Player()
    {
        Finishes = new HashSet<Finish>();
        KillKilledNavigations = new HashSet<Kill>();
        KillKillerNavigations = new HashSet<Kill>();
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Color { get; set; }

    public ScatterDataset GetScatterDataSet()
    {
        ScatterDataset sds = new()
        {
            BackgroundColor = Color,
            BorderColor = Color,
            ShowLine = true,
            LineTension = 0,
            PointRadius = 2,
            PointHitRadius = 3,
            PointHoverRadius = 4,
            Label = FirstName
        };
        sds.Data = GetCumulativeWinnings();
        return sds;
    }

    public virtual ICollection<Finish> Finishes { get; set; }
    public virtual ICollection<Kill> KillKilledNavigations { get; set; }
    public virtual ICollection<Kill> KillKillerNavigations { get; set; }
}
