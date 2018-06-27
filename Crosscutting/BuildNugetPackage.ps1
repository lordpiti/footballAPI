Remove-Item *.nupkg

dotnet pack --output .

$fileName = (Get-ChildItem *.nupkg)[0].Name;

nuget push $fileName -Source https://api.nuget.org/v3/index.json

Remove-Item *.nupkg


Write-Host "Press any key to continue ..."

$x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")