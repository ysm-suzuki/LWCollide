cd /d %~dp0
cd ..
C:\Windows\Microsoft.NET\Framework64\v3.5\csc /out:test_lwcollide.exe /reference:lib/Atagoal.dll /recurse:*.cs
test_lwcollide.exe
pause