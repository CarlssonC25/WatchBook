namespace WatchBook.Services;
using Microsoft.Extensions.Configuration;

public static class MyService
{
	private static IConfiguration _configuration;

	public static void Initialize(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public static string DbPath()
	{
		var dbPath = _configuration["DbConnectionStrings:DefaultConnection"];
		if (!File.Exists(dbPath))
		{
			dbPath = _configuration["DbConnectionStrings:TestConnection"];
		}
		return "Data Source=" + dbPath;
	}
}
