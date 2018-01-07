rd .\BuildResults /S /Q
md .\BuildResults
rd .\MyProject\Bin\Release  /S /Q

REM set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v3.5
set msBuildDir=%WINDIR%\Microsoft.NET\Framework\v4.0.30319
call %msBuildDir%\msbuild.exe  ToyMovingSimulator.sln /p:Configuration=Release /l:FileLogger,Microsoft.Build.Engine;logfile=Manual_MSBuild_ReleaseVersion_LOG.log
set msBuildDir=

XCOPY .\ToyMovingSimulator\Bin\Release\*.* .\BuildResults\