@echo off
cls

.paket\paket.bootstrapper.exe --max-file-age=480 
if errorlevel 1 (
  exit /b %errorlevel%
)

.paket\paket.exe restore 
if errorlevel 1 (
  exit /b %errorlevel%
)

packages\FAKE\tools\FAKE.exe build.fsx %* 
if errorlevel 1 (
  exit /b %errorlevel%
)

