namespace DnsUpdater.Core
{
	public static class StringExtensions
	{
		public static string SafeToUpper(this string value)
		{
			if (string.IsNullOrWhiteSpace(value))
				return value;
			return value.ToUpper();
		}
	}
}
