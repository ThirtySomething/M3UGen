Name "M3UGen Installer"
OutFile "M3UGen_Setup.exe"
InstallDir "$PROGRAMFILES\M3UGen"
DirText "Select directory to install M3UGen"
BrandingText " "
ShowInstDetails show
Section
    SetShellVarContext all
    SetOutPath $INSTDIR
    File M3UGen.jar
    File M3UGen.exe
    File Readme.md
    WriteUninstaller $INSTDIR\uninstaller.exe
    CreateDirectory "$SMPROGRAMS\M3UGen"
    CreateShortcut  "$SMPROGRAMS\M3UGen\M3UGen.jar.lnk" "$INSTDIR\M3UGen.jar"
    CreateShortcut  "$SMPROGRAMS\M3UGen\M3UGen.exe.lnk" "$INSTDIR\M3UGen.exe"
    CreateShortcut  "$SMPROGRAMS\M3UGen\Readme.md.lnk" "$INSTDIR\Readme.md"
    CreateShortcut  "$SMPROGRAMS\M3UGen\Uninstall.lnk" "$INSTDIR\uninstaller.exe"
SectionEnd
Section "Uninstall"
    SetShellVarContext all
    RMDir /R /REBOOTOK $INSTDIR
    RMDir /R /REBOOTOK "$SMPROGRAMS\M3UGen"
SectionEnd
