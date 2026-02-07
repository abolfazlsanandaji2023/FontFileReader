using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media; // PresentationCore.dll

class Program
{
    static void Main()
    {
        string fontFileName = "uifonticons.ttf";
        var fontPath =Path.Combine( @"F:\MAUIFromXamarin\App1\Resources\Fonts\",  fontFileName );
        ;

        var glyph = new GlyphTypeface(new Uri(fontPath));

        var map = glyph.CharacterToGlyphMap;

        using var sw = new StreamWriter("icons.html");
        sw.WriteLine("<meta charset='utf-8'>");
        sw.WriteLine("<style>@font-face { font-family: 'icons'; src: url('"+fontFileName+"'); }");
        sw.WriteLine("span { font-family: 'icons'; font-size: 32px; padding: 5px; }</style>");

        foreach (var kv in map)
        {
            int unicode = kv.Key;
            string hex = unicode.ToString("X4");
            sw.WriteLine($"<span>&#x{hex};</span> U+{hex}<br>");
        }

    }
}
