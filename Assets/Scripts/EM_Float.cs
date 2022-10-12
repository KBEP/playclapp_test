public static class EM_Float
{
	public static float Positivize (this float value) => float.IsFinite(value) && value >= 0.0f ? value : 0.0f;

	//вернёт число гарантированно находящееся между min и max
	public static float ForceClamp (this float value, float min, float max)
	{
		if (float.IsNaN(min)) min = default;
		if (float.IsNaN(max)) max = default;
		if (min > max)
		{
			float tmp = min;
			min = max;
			max = tmp;
		}
		if (float.IsNaN(value) || value < min) return min;
		else if (value > max) return max;
		else return value;
	}
}
