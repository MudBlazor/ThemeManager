namespace MudBlazor.ThemeManager.Models.ThemeManagerTheme;

internal class ThemeManagerThemePalette
{
    public string Black { get; set; }
    public string White { get; set; }
    public string Primary { get; set; }
    public string PrimaryContrastText { get; set; }
    public string Secondary { get; set; }
    public string SecondaryContrastText { get; set; }
    public string Tertiary { get; set; }
    public string TertiaryContrastText { get; set; }
    public string Info { get; set; }
    public string InfoContrastText { get; set; }
    public string Success { get; set; }
    public string SuccessContrastText { get; set; }
    public string Warning { get; set; }
    public string WarningContrastText { get; set; }
    public string Error { get; set; }
    public string ErrorContrastText { get; set; }
    public string Dark { get; set; }
    public string DarkContrastText { get; set; }
    public string TextPrimary { get; set; }
    public string TextSecondary { get; set; }
    public string TextDisabled { get; set; }
    public string ActionDefault { get; set; }
    public string ActionDisabled { get; set; }
    public string ActionDisabledBackground { get; set; }
    public string Background { get; set; }
    public string BackgroundGrey { get; set; }
    public string Surface { get; set; }
    public string DrawerBackground { get; set; }
    public string DrawerText { get; set; }
    public string DrawerIcon { get; set; }
    public string AppbarText { get; set; }
    public string AppbarBackground { get; set; }
    public string LinesDefault { get; set; }
    public string LinesInputs { get; set; }
    public string TableLines { get; set; }
    public string TableStriped { get; set; }
    public string TableHover { get; set; }
    public string Divider { get; set; }
    public string DividerLight { get; set; }
    public string PrimaryDarken { get; set; }
    public string PrimaryLighten { get; set; }
    public string SecondaryDarken { get; set; }
    public string SecondaryLighten { get; set; }
    public string TertiaryDarken { get; set; }
    public string TertiaryLighten { get; set; }
    public string InfoDarken { get; set; }
    public string InfoLighten { get; set; }
    public string SuccessDarken { get; set; }
    public string SuccessLighten { get; set; }
    public string WarningDarken { get; set; }
    public string WarningLighten { get; set; }
    public string ErrorDarken { get; set; }
    public string ErrorLighten { get; set; }
    public string DarkDarken { get; set; }
    public string DarkLighten { get; set; }
    public string GrayDefault { get; set; }
    public string GrayLight { get; set; }
    public string GrayLighter { get; set; }
    public string GrayDark { get; set; }
    public string GrayDarker { get; set; }
    public string OverlayDark { get; set; }
    public string OverlayLight { get; set; }

    public void SetThemeManagerThemePalette(Palette palette)
    {
        Black = palette.Black.Value;
        White = palette.White.Value;
        Primary = palette.Primary.Value;
        PrimaryContrastText = palette.PrimaryContrastText.Value;
        Secondary = palette.Secondary.Value;
        SecondaryContrastText = palette.SecondaryContrastText.Value;
        Tertiary = palette.Tertiary.Value;
        TertiaryContrastText = palette.TertiaryContrastText.Value;
        Info = palette.Info.Value;
        InfoContrastText = palette.InfoContrastText.Value;
        Success = palette.Success.Value;
        SuccessContrastText = palette.SuccessContrastText.Value;
        Warning = palette.Warning.Value;
        WarningContrastText = palette.WarningContrastText.Value;
        Error = palette.Error.Value;
        ErrorContrastText = palette.ErrorContrastText.Value;
        Dark = palette.Dark.Value;
        DarkContrastText = palette.DarkContrastText.Value;
        TextPrimary = palette.TextPrimary.Value;
        TextSecondary = palette.TextSecondary.Value;
        TextDisabled = palette.TextDisabled.Value;
        ActionDefault = palette.ActionDefault.Value;
        ActionDisabled = palette.ActionDisabled.Value;
        ActionDisabledBackground = palette.ActionDisabledBackground.Value;
        Background = palette.Background.Value;
        BackgroundGrey = palette.BackgroundGrey.Value;
        Surface = palette.Surface.Value;
        DrawerBackground = palette.DrawerBackground.Value;
        DrawerText = palette.DrawerText.Value;
        DrawerIcon = palette.DrawerIcon.Value;
        AppbarText = palette.AppbarText.Value;
        AppbarBackground = palette.AppbarBackground.Value;
        LinesDefault = palette.LinesDefault.Value;
        LinesInputs = palette.LinesInputs.Value;
        TableLines = palette.TableLines.Value;
        TableStriped = palette.TableStriped.Value;
        TableHover = palette.TableHover.Value;
        Divider = palette.Divider.Value;
        DividerLight = palette.DividerLight.Value;
        PrimaryDarken = palette.PrimaryDarken;
        PrimaryLighten = palette.PrimaryLighten;
        SecondaryDarken = palette.SecondaryDarken;
        SecondaryLighten = palette.SecondaryLighten;
        TertiaryDarken = palette.TertiaryDarken;
        TertiaryLighten = palette.TertiaryLighten;
        InfoDarken = palette.InfoDarken;
        InfoLighten = palette.InfoLighten;
        SuccessDarken = palette.SuccessDarken;
        SuccessLighten = palette.SuccessLighten;
        WarningDarken = palette.WarningDarken;
        WarningLighten = palette.WarningLighten;
        ErrorDarken = palette.ErrorDarken;
        ErrorLighten = palette.ErrorLighten;
        DarkDarken = palette.DarkDarken;
        DarkLighten = palette.DarkLighten;
        GrayLight = palette.GrayLight;
        GrayLighter = palette.GrayLighter;
        GrayDark = palette.GrayDark;
        GrayDarker = palette.GrayDarker;
        OverlayDark = palette.OverlayDark;
        OverlayLight = palette.OverlayLight;
    }

    public Palette GetThemeManagerThemePalette()
    {
        var palette = new Palette
        {
            Black = Black,
            White = White,
            Primary = Primary,
            PrimaryContrastText = PrimaryContrastText,
            Secondary = Secondary,
            SecondaryContrastText = SecondaryContrastText,
            Tertiary = Tertiary,
            TertiaryContrastText = TertiaryContrastText,
            Info = Info,
            InfoContrastText = InfoContrastText,
            Success = Success,
            SuccessContrastText = SuccessContrastText,
            Warning = Warning,
            WarningContrastText = WarningContrastText,
            Error = Error,
            ErrorContrastText = ErrorContrastText,
            Dark = Dark,
            DarkContrastText = DarkContrastText,
            TextPrimary = TextPrimary,
            TextSecondary = TextSecondary,
            TextDisabled = TextDisabled,
            ActionDefault = ActionDefault,
            ActionDisabled = ActionDisabled,
            ActionDisabledBackground = ActionDisabledBackground,
            Background = Background,
            BackgroundGrey = BackgroundGrey,
            Surface = Surface,
            DrawerBackground = DrawerBackground,
            DrawerText = DrawerText,
            DrawerIcon = DrawerIcon,
            AppbarText = AppbarText,
            AppbarBackground = AppbarBackground,
            LinesDefault = LinesDefault,
            LinesInputs = LinesInputs,
            TableLines = TableLines,
            TableStriped = TableStriped,
            TableHover = TableHover,
            Divider = Divider,
            DividerLight = DividerLight,
            PrimaryDarken = PrimaryDarken,
            PrimaryLighten = PrimaryLighten,
            SecondaryDarken = SecondaryDarken,
            SecondaryLighten = SecondaryLighten,
            TertiaryDarken = TertiaryDarken,
            TertiaryLighten = TertiaryLighten,
            InfoDarken = InfoDarken,
            InfoLighten = InfoLighten,
            SuccessDarken = SuccessDarken,
            SuccessLighten = SuccessLighten,
            WarningDarken = WarningDarken,
            WarningLighten = WarningLighten,
            ErrorDarken = ErrorDarken
        };

        return palette;
    }
}