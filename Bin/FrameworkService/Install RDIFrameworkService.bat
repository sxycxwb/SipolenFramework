@echo off
set /p var=ȷ����װ��RDIFramework.NET �� .NET������Ϣ��ϵͳ������ܡ�SOA������(y/n):
if "%var%" == "y" (goto install) else (goto batexit)

:install
copy %WinDir%\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe  InstallUtil.exe /Y
call InstallUtil.exe RDIFramework.WinService.exe
pause

:batexit
exit