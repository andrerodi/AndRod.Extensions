namespace Extensions;

public static class DoubleExtensions
{
    public static TimeSpan Days(this double number) => TimeSpan.FromDays(number);
    public static TimeSpan Hours(this double number) => TimeSpan.FromHours(number);
    public static TimeSpan Minutes(this double number) => TimeSpan.FromMinutes(number);
    public static TimeSpan Seconds(this double number) => TimeSpan.FromSeconds(number);
    public static TimeSpan Milliseconds(this double number) => TimeSpan.FromMilliseconds(number);
}
