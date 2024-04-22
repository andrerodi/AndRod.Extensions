namespace Extensions;

public static class NumberTypeExtensions
{
    #region INT
    public static TimeSpan Days(this int number) => TimeSpan.FromDays(number);
    public static TimeSpan Hours(this int number) => TimeSpan.FromHours(number);
    public static TimeSpan Seconds(this int number) => TimeSpan.FromSeconds(number);
    public static TimeSpan Minutes(this int number) => TimeSpan.FromMinutes(number);
    public static TimeSpan Milliseconds(this int number) => TimeSpan.FromMilliseconds(number);
    #endregion

    #region DOUBLE
    public static TimeSpan Days(this double number) => TimeSpan.FromDays(number);
    public static TimeSpan Hours(this double number) => TimeSpan.FromHours(number);
    public static TimeSpan Seconds(this double number) => TimeSpan.FromSeconds(number);
    public static TimeSpan Minutes(this double number) => TimeSpan.FromMinutes(number);
    public static TimeSpan Milliseconds(this double number) => TimeSpan.FromMilliseconds(number);
    #endregion
}
