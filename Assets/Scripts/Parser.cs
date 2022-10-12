using System.Globalization;

public static class Parser
{
	public static bool TryParse (string text, out float result)
	{
		return float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out result);
	}
}
