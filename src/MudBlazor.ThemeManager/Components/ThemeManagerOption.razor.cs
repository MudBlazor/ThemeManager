using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MudBlazor.ThemeManager.Components
{
    public partial class ThemeManagerOption
    {
        /// <summary>
        /// If specified, title of the themeing option
        /// </summary>
        [Parameter] public string Title { set; get; }
    }
}
