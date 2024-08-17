namespace Eunis.Helpers {
    public static class StringExtension {
        public static TEnum TryParseEnum<TEnum>(this string item) where TEnum : struct
            => Enum.TryParse(item, true, out TEnum tEnumResult) ? tEnumResult : default;
    }
}
