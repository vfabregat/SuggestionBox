@echo Executing psake build with default.ps1 configuration
@echo off

rem powershell -NoProfile -ExecutionPolicy Bypass -Command "& {Import-Module '%~dp0\Build\psake.psm1'; invoke-psake %~dp0\Build\default.ps1  }"
powershell -NoProfile -ExecutionPolicy Bypass -Command "& '%~dp0\build\build.ps1' %*; if ($psake.build_success -eq $false) { exit 1 } else { exit 0 }"
rem goto :eof

pause