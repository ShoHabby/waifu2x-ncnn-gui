namespace Waifu2x.Core.Messages;

/// <summary>
/// Progress report message
/// </summary>
/// <param name="MaxValue">New progress maximum value</param>
public record ReportProgressMessage(int? MaxValue = null);
