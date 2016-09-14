cd /d %~dp0
cd ..
C:\Windows\Microsoft.NET\Framework64\v3.5\csc /out:test_lwcollide.exe /recurse:*.cs /reference:lib/Atagoal.dll
test_lwcollide.exe