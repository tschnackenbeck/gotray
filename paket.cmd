@echo off
cls
.paket\paket.exe %*
if errorlevel 1 (
  exit /b %errorlevel%
)
