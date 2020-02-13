"Uninstalling service: AfraidService"

$service = Get-Service -Name AfraidService;
if ($service)
{
	"Service AfraidService already exists. Removing..."
	if ($service.Status -eq "Running")
	{
		$service.Stop();
	}

	#delete the existing service
	$serviceWmi = Get-WmiObject -Class Win32_Service -Filter "Name='AfraidService'";
	$serviceWmi.delete();

	foreach ($prop in $serviceWmi.Properties)
	{
		if ($prop.Name -eq "PathName")
		{
			$dir = [System.IO.Path]::GetDirectoryName($prop.Value);
			$segments = $dir.Split("\");
			Push-Location $dir.Replace($segments[$segments.Length - 1], "");
			Remove-Item $dir -Recurse
			"Directory removed! $dir"
			break;
		}
	}
	Pop-Location
	"Service removed. Finished!";
}
else {
	"Service doesn't exist. Finished!";
}