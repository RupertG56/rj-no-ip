$dPath = [System.IO.Path]::GetDirectoryName($PSScriptRoot);
$pfPath = ${env:ProgramFiles}
$pfServicePath = $dPath;

$service = Get-Service -Name AfraidService
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
    "Service removed";
}

if (!$PSScriptRoot.Contains("Program Files"))
{
    #copy the contents of this and the outer directory to program files
    $pfServicePath = "$pfPath\AfraidService";
    if (Test-Path -Path $pfServicePath)
    {
        Remove-Item $pfServicePath -Recurse;
    }

    "Install script is being run from a `"TemporaryLocation`". Files will be copied to $pfServicePath and installation will continue.";
    Copy-Item "$dPath\*" $pfServicePath;
}

New-Service -Name DnsService -BinaryPathName "$pfServicePath\DnsUpdater.exe" -DisplayName "Dynamic Dns Updater Service" -Description "Updates dynamic dns providers with the current external IP address.";
Start-Service DnsService;