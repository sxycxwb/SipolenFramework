@echo off
set /p var=确定卸载“RDIFramework.NET ━ .NET快速信息化系统开发框架”SOA服务吗？(y/n):
if "%var%" == "y" (goto uninstall) else (goto batexit)

:uninstall
copy %WinDir%\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe  InstallUtil.exe /Y
call InstallUtil.exe /u RDIFramework.WinService.exe
pause

:batexit
exit