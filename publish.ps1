<#
.SYNOPSIS
    Publishes the MAUI app as a self-contained executable.
.DESCRIPTION
    Builds and publishes MultiLineStringFormatter.Maui as a self-contained
    Windows x64 application. The output is a single folder with all dependencies
    included — end users only need Windows 10 1809+ and the Windows App Runtime.
.PARAMETER OutputDir
    Custom output directory. Defaults to .\publish
.PARAMETER SingleFile
    If specified, produces a single-file executable.
#>
param(
    [string]$OutputDir = ".\publish",
    [switch]$SingleFile
)

$ErrorActionPreference = "Stop"

Write-Host "Publishing Multi-Line String Formatter (MAUI)..." -ForegroundColor Cyan

$publishArgs = @(
    "publish"
    "src\MultiLineStringFormatter.Maui"
    "-c", "Release"
    "-f", "net10.0-windows10.0.19041.0"
    "-r", "win-x64"
    "--self-contained"
    "-o", $OutputDir
)

if ($SingleFile) {
    $publishArgs += "-p:PublishSingleFile=true"
    Write-Host "  Mode: Single-file executable" -ForegroundColor Yellow
}

Write-Host "  Output: $OutputDir" -ForegroundColor Yellow

dotnet @publishArgs

if ($LASTEXITCODE -eq 0) {
    $exe = Get-ChildItem "$OutputDir\MultiLineStringFormatter.Maui.exe" -ErrorAction SilentlyContinue
    if ($exe) {
        Write-Host "`nPublish succeeded!" -ForegroundColor Green
        Write-Host "  Executable: $($exe.FullName)" -ForegroundColor Green
        Write-Host "  Size: $([math]::Round($exe.Length / 1MB, 1)) MB" -ForegroundColor Green
    }
} else {
    Write-Host "`nPublish failed." -ForegroundColor Red
    exit 1
}
