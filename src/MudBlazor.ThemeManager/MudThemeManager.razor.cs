using Microsoft.AspNetCore.Components;
using MudBlazor.ThemeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazor.ThemeManager
{
    public partial class MudThemeManager
    {
        /// <summary>
        /// Sets the opened state of Theme Manager.
        /// </summary>
        [Parameter] public bool Open { get; set; }

        /// <summary>
        /// Theme Managers drop shadow.
        /// </summary>
        [Parameter] public int Elevation { set; get; } = 1;

        /// <summary>
        /// Side from which the Theme Manager appears.
        /// </summary>
        [Parameter] public Anchor Anchor { get; set; } = Anchor.End;

        /// <summary>
        /// Disable overlay for Theme Manager.
        /// </summary>
        [Parameter] public bool DisableOverlay { get; set; } = true;

        [Parameter] public ThemeManagerTheme Theme { get; set; } = new ThemeManagerTheme();

        private bool _open
        {
            get => _open;
            set => _open = Open;
        }

        void Test()
        {
            Theme.Palette.GrayLight = "#fff";
            Theme.Typography.H4.FontSize = "2rem";
            Theme.Palette.Background = "#000";
        }
    }
}
