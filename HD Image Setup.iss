#define MyAppName "内镜诊断系统"
#define MyAppVersion "1.0"
#define MyAppPublisher "scrawlor"
#define MyAppExeName "login.exe"

[Setup]
AppId={{3C36934B-F1B9-4159-B65A-F98C58053F56}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
OutputBaseFilename=setup
Compression=lzma
SolidCompression=yes

[Languages]
Name: "chinesesimp"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked; OnlyBelowVersion: 0,6.1
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "E:\project\Case05_4\Case05_4\bin\Debug\login.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\project\Case05_4\Case05_4\bin\Debug\Case05_4.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\project\Case05_4\Case05_4\bin\Debug\Case05_4.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\project\Case05_4\Case05_4\bin\Debug\login.exe"; DestDir: "{app}"; Flags: ignoreversion
; 注意: 不要在任何共享系统文件上使用“Flags: ignoreversion”

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: quicklaunchicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

