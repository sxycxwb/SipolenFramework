@echo off
set /p var=ȷ��ж�ء�RDIFramework.NET �� .NET������Ϣ��ϵͳ������ܡ�SOA������(y/n):
if "%var%" == "y" (goto uninstall) else (goto batexit)

:uninstall
copy %WinDir%\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe  InstallUtil.exe /Y
call InstallUtil.exe /u RDIFramework.WinService.exe
pause

:batexit
exit