@echo off
set /p var=确定安装“RDIFramework.NET ━ .NET快速信息化系统开发框架”SOA服务吗？(y/n):
if "%var%" == "y" (goto install) else (goto batexit)

:install
copy %WinDir%\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe  InstallUtil.exe /Y
call InstallUtil.exe RDIFramework.WinService.exe
pause

:batexit
exit