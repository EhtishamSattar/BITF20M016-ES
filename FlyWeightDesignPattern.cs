using System;
using System.Collections.Generic;

// Flyweight interface
interface ITextFormat
{
    void Apply(string text);
}

// Concrete Flyweight
class CharacterFormat : ITextFormat
{
    private readonly char _style;

    public CharacterFormat(char style)
    {
        _style = style;
    }

    public void Apply(string text)
    {
        Console.Write($"{_style}{text}{_style} ");
    }
}

// Flyweight Factory
class TextFormatFactory
{
    private readonly Dictionary<char, ITextFormat> _characterFormats = new Dictionary<char, ITextFormat>();

    public ITextFormat GetCharacterFormat(char style)
    {
        if (!_characterFormats.ContainsKey(style))
        {
            _characterFormats[style] = new CharacterFormat(style);
        }
        return _characterFormats[style];
    }
}

// Flyweight interface
interface IFontStyle
{
    void Apply(string text);
}

// Concrete Flyweight
class FontStyle : IFontStyle
{
    private readonly string _style;

    public FontStyle(string style)
    {
        _style = style;
    }

    public void Apply(string text)
    {
        Console.WriteLine($"{_style}{text}{_style}");
    }
}

// Flyweight Factory
class FontStyleFactory
{
    private readonly Dictionary<string, IFontStyle> _fontStyles = new Dictionary<string, IFontStyle>();

    public IFontStyle GetFontStyle(string style)
    {
        if (!_fontStyles.ContainsKey(style))
        {
            _fontStyles[style] = new FontStyle(style);
        }
        return _fontStyles[style];
    }
}
