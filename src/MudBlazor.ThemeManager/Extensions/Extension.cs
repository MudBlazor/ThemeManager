using System.Text.Json;

namespace MudBlazor.ThemeManager.Extensions;

internal static class Extension
{
    private static readonly PaletteSerializerContext PaletteSerializerContext = new();
    private static readonly ThemeSerializerContext ThemeSerializerContext = new();

    public static MudTheme DeepClone(this MudTheme source)
    {
        // TODO: Needs this to be done https://github.com/MudBlazor/MudBlazor/pull/9434
        //var themeType = typeof(MudTheme);
        //var serializeStr = JsonSerializer.Serialize(source, themeType, ThemeSerializerContext);
        //var copyObj = (MudTheme?)JsonSerializer.Deserialize(serializeStr, themeType, ThemeSerializerContext);

        //return copyObj;

        // Code below is a workaround for the above issue

        return new MudTheme
        {
            PaletteDark = source.PaletteDark.DeepClone() ?? new PaletteDark(),
            PaletteLight = source.PaletteLight.DeepClone() ?? new PaletteLight(),
            Shadows = DeepCloneTheme(source.Shadows) ?? new Shadow(),
            LayoutProperties = DeepCloneTheme(source.LayoutProperties) ?? new LayoutProperties(),
            ZIndex = DeepCloneTheme(source.ZIndex) ?? new ZIndex(),
            PseudoCss = DeepCloneTheme(source.PseudoCss) ?? new PseudoCss(),
            // Exception case
            Typography = new Typography
            {
                Default = DeepCloneBaseTypography(source.Typography.Default),
                H1 = DeepCloneBaseTypography(source.Typography.H1),
                H2 = DeepCloneBaseTypography(source.Typography.H2),
                H3 = DeepCloneBaseTypography(source.Typography.H3),
                H4 = DeepCloneBaseTypography(source.Typography.H4),
                H5 = DeepCloneBaseTypography(source.Typography.H5),
                H6 = DeepCloneBaseTypography(source.Typography.H6),
                Subtitle1 = DeepCloneBaseTypography(source.Typography.Subtitle1),
                Subtitle2 = DeepCloneBaseTypography(source.Typography.Subtitle2),
                Body1 = DeepCloneBaseTypography(source.Typography.Body1),
                Body2 = DeepCloneBaseTypography(source.Typography.Body2),
                Input = DeepCloneBaseTypography(source.Typography.Input),
                Button = DeepCloneBaseTypography(source.Typography.Button),
                Caption = DeepCloneBaseTypography(source.Typography.Caption),
                Overline = DeepCloneBaseTypography(source.Typography.Overline)
            }
        };
    }

    public static PaletteDark? DeepClone(this PaletteDark source) => DeepClonePalette(source);

    public static PaletteLight? DeepClone(this PaletteLight source) => DeepClonePalette(source);

    private static T? DeepClonePalette<T>(T source) where T : Palette
    {
        var paletteType = typeof(T);
        var serializeStr = JsonSerializer.Serialize(source, paletteType, PaletteSerializerContext);
        var copyObj = (T?)JsonSerializer.Deserialize(serializeStr, paletteType, PaletteSerializerContext);

        return copyObj;
    }

    private static T? DeepCloneTheme<T>(T source) where T : class
    {
        var paletteType = typeof(T);
        var serializeStr = JsonSerializer.Serialize(source, paletteType, ThemeSerializerContext);
        var copyObj = (T?)JsonSerializer.Deserialize(serializeStr, paletteType, ThemeSerializerContext);

        return copyObj;
    }

    private static T DeepCloneBaseTypography<T>(T baseTypography) where T : BaseTypography, new()
    {
        string[] fontFamilyCloned = new string[baseTypography.FontFamily?.Length ?? 0];
        if (baseTypography.FontFamily is not null)
        {
            Array.Copy(baseTypography.FontFamily, fontFamilyCloned, baseTypography.FontFamily.Length);
        }

        var fontWeightCloned = baseTypography.FontWeight;
        var fontSizeCloned = baseTypography.FontSize;
        var lineHeightCloned = baseTypography.LineHeight;
        var letterSpacingCloned = baseTypography.LetterSpacing;
        var textTransformCloned = baseTypography.TextTransform;

        return new T
        {
            FontWeight = fontWeightCloned,
            FontFamily = fontFamilyCloned,
            FontSize = fontSizeCloned,
            LineHeight = lineHeightCloned,
            LetterSpacing = letterSpacingCloned,
            TextTransform = textTransformCloned,
        };
    }
}