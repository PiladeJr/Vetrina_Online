namespace WebApp.EnumFolder
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this string value, T defaultValue)
            where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            return Enum.TryParse(value, true, out T result)
                ? result : defaultValue;
        }
        public static bool IsEnumValueValid<T>(this T value)
            where T : struct
        {
            return Enum.IsDefined(typeof(T), value);
        }
        public static List<T> ToList<T>()
            where T : struct
        {
            return new List<T>((T[])Enum.GetValues(typeof(T)));
        }
    }
}
