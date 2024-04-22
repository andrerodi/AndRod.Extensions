namespace Extensions;

public static class ExceptionExtensions
{
    /// <summary>
    /// Returns a flattened array of all exception messages, including inner exceptions.
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    public static string[] FlattenExceptionMessages(this Exception? ex)
        => ex.FlattenExceptionMessagesIterator().ToArray();

    /// <summary>
    /// The recursive iterator that flattens the exception messages.
    /// </summary>
    /// <param name="ex"></param>
    /// <returns></returns>
    private static IEnumerable<string> FlattenExceptionMessagesIterator(this Exception? ex)
    {
        if (ex is null || string.IsNullOrWhiteSpace(ex.Message))
        {
            yield break;
        }

        yield return ex.Message;

        foreach (var message in FlattenExceptionMessages(ex.InnerException))
        {
            yield return message;
        }
    }
}
