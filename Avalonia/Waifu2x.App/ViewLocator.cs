using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Waifu2x.Core.ViewModels;
using Waifu2x.ViewsModels;

namespace Waifu2x;

public class ViewLocator : IDataTemplate
{
    public Control? Build(object? param)
    {
        Type? paramType = param?.GetType();
        if (paramType?.FullName is null) return null;

        ReadOnlySpan<char> fullTypeSpan = paramType.FullName;
        if (fullTypeSpan.EndsWith("ViewModel", StringComparison.Ordinal))
        {
            fullTypeSpan = fullTypeSpan[..^9];
        }

        string fullTypeName = fullTypeSpan.ToString();
        Type? type = Type.GetType(fullTypeName) ?? Type.GetType(fullTypeName + "View");
        if (type is not null)
        {
            return Activator.CreateInstance(type) as Control;
        }

        return new TextBlock { Text = "Not Found: " + fullTypeName };
    }

    public bool Match(object? data) => data is ViewModelBase;
}
