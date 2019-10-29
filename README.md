# donutCS

.NET Core version of donut shellcode generator.

## Install
Confirmed working on Kali and Windows  
[Kali Install Instructions](./docs/Install.md) 

## Usage
Refer to https://github.com/TheWover/donut for full usage. Should be exactly the same.  
Passing parameters to dotnet build (if your are building from kali) explained [here](.docs/KaliUse.md)  

## Testing
https://github.com/TheWover/donut/tree/master/DonutTest  
Take your base64'ed output and apply it to shellcode in Program.cs

## Future
Thinking of adding an API to just supply a parameters and a file/filestream? for C2 integrations.  
Will document it when done  
  
Upgrade to Core 3.0, I'm a derp and just did what I had. (Currently supports 2.1)  

## Whats broken until I fix

URL Delivery is not configured from the original project  

File output currently works fine but code is ugly and I'll straighten it out as I figure out how I want to do
