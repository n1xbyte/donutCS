Passing arguments to dotnet build is as simple as adding -- *before* the parameters.  
  
Example:  
`dotnet run -- -f DemoCreateProcess.dll -c TestClass -m RunProcess -p notepad.exe,calc.exe`  
  
will output:  
```
root@ronin:/opt/donutCS# dotnet run -- -f DemoCreateProcess.dll -c TestClass -m RunProcess -p notepad.exe,calc.exe
[DEBUG] Starting Donut
[DEBUG] Parsing Arguements:
[DEBUG] 	File:	 DemoCreateProcess.dll
[DEBUG] 	Outfile: payload.bin
[DEBUG] 	Arch:	 3
[DEBUG] 	Bypass:	 3
[DEBUG] 	Class:	 TestClass
[DEBUG] 	Method:	 RunProcess
[DEBUG] 	Args:	 notepad.exe,calc.exe
[DEBUG] Entering Donut_Create()
[DEBUG] Entering ParseConfig()
[DEBUG] Checking for Arch Mismatch
[DEBUG] Validating Bypass Option
[DEBUG] Entering ParseInputFile()
[DEBUG] File extension is: .dll
[DEBUG] Parsing PE file
[DEBUG] COM Descriptor found, .NET selected
[DEBUG] Runtime found in Metadata Header: v4.0.30319
[DEBUG] Entering CreateModule()
	[+] Domain:	XTHXYW9M
	[+] Class:	TestClass
	[+] Method:	RunProcess
	[+] Runtime:	v4.0.30319
[DEBUG] Total Module Size: 10016
[DEBUG] Entering CreateInstance()
[DEBUG] Adding module size 10016 to instance size
[DEBUG] Instance CTR:	885C5D14BE3AFB2A96A83B3E716FC458
[DEBUG] Instance MK :	D9CA2098898B0D3D26A93ABAC7559BA8
[DEBUG] Module CTR:	EE055BE8E5313787AD41C69172F66416
[DEBUG] Module MK :	45DEBE92880CC279975AB9FF5F668D0C
[DEBUG] Decryption Verfier String: 7RXC7RCH
[DEBUG] IV for Maru Hash:	EE055BE8E5313787AD41C69172F6641645DEBE92880CC279975AB9FF5F668D0C
[DEBUG] Generating API Hashes
[DEBUG] kernel32.dll	LoadLibraryA	BE6B0F4C6E90041
[DEBUG] kernel32.dll	GetProcAddress	D2775FB3795B6E99
[DEBUG] kernel32.dll	GetModuleHandleA	CFB133733371945
[DEBUG] kernel32.dll	VirtualAlloc	175BE0138048F366
[DEBUG] kernel32.dll	VirtualFree	112370AF401B9002
[DEBUG] kernel32.dll	VirtualQuery	E615AA1DF528913D
[DEBUG] kernel32.dll	VirtualProtect	4FACA074826AE3E2
[DEBUG] kernel32.dll	Sleep	F29E5437BEE67E02
[DEBUG] kernel32.dll	MultiByteToWideChar	692289BAD205B11
[DEBUG] kernel32.dll	GetUserDefaultLCID	192E5FAA8EA61F10
[DEBUG] oleaut32.dll	SafeArrayCreate	4464C62DE15E4E39
[DEBUG] oleaut32.dll	SafeArrayCreateVector	2C50A8844E9DE165
[DEBUG] oleaut32.dll	SafeArrayPutElement	7A171A4C65762C27
[DEBUG] oleaut32.dll	SafeArrayDestroy	4F87BBADC931FD68
[DEBUG] oleaut32.dll	SafeArrayGetLBound	B767EED9AAA297E7
[DEBUG] oleaut32.dll	SafeArrayGetUBound	F37F234E0CB20B8E
[DEBUG] oleaut32.dll	SysAllocString	683B41D349587B76
[DEBUG] oleaut32.dll	SysFreeString	FED67AF370E23D0E
[DEBUG] oleaut32.dll	LoadTypeLib	5591ECCE0C537E8
[DEBUG] wininet.dll	InternetCrackUrlA	A2772CA0F35E74D5
[DEBUG] wininet.dll	InternetOpenA	34E94F6ECD82F654
[DEBUG] wininet.dll	InternetConnectA	93A04855DAC0EE21
[DEBUG] wininet.dll	InternetSetOptionA	7196165EA4B21B38
[DEBUG] wininet.dll	InternetReadFile	13DDFACDAD0D2BF5
[DEBUG] wininet.dll	InternetCloseHandle	9E9A771689145B5E
[DEBUG] wininet.dll	HttpOpenRequestA	5FD9F730C799B598
[DEBUG] wininet.dll	HttpSendRequestA	18B72A4DD980A766
[DEBUG] wininet.dll	HttpQueryInfoA	C55D89A239214C22
[DEBUG] mscoree.dll	CorBindToRuntime	35B99E290C59D93D
[DEBUG] mscoree.dll	CLRCreateInstance	AB5992B840F45FAE
[DEBUG] ole32.dll	CoInitializeEx	967191D52A839261
[DEBUG] ole32.dll	CoCreateInstance	9631416AE79A8016
[DEBUG] ole32.dll	CoUninitialize	6287FDA6D15EFD30
[DEBUG] DLL Count: 4
[DEBUG] API Count: 33
[DEBUG] Copying PIC module data to instance
[DEBUG] Encrypting Instance
[DEBUG] Wrote raw instance to disk
[DEBUG] Entering Shellcode()
[DEBUG] PIC Size: 34954
[DEBUG] Copying 16554 bytes of x64/x86 shellcode
[DEBUG] Donut_Create() finished with: [*] Success
[DEBUG] Wrote raw payload to payload.bin
[DEBUG] Wrote Base64'd payload to payload.bin.b64
```
  
To test the results you can use Wover's DonutTest app.  
https://github.com/TheWover/donut/tree/master/DonutTest  
Take your base64'ed output and replace the appropriate shellcode in Program.cs

### Using Donut  
Refer to the donut main project for uses.  
  
Odzhan's blog post (about the generator): https://modexp.wordpress.com/2019/05/10/dotnet-loader-shellcode/  
  
TheWover's blog post (detailed walkthrough, and about how donut affects tradecraft): https://thewover.github.io/Introducing-Donut/  
  
v0.9.2 release blog post: https://thewover.github.io/Bear-Claw/  
  


