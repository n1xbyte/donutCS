# donutCS

.NET Core version of donut shellcode generator.  
https://vimeo.com/369739318 

## Install
Confirmed working on Kali and Windows  
[Kali Install Instructions](./docs/Install.md) 

## Usage
Refer to https://github.com/TheWover/donut for full usage. Should be exactly the same.  
Passing parameters to dotnet build (if your are building from Kali) explained [here](./docs/KaliUse.md)  

From the root of the donut directory you can run "dotnet run" or "dotnet run --configuration Release" if you don't want to see the marshalling errors and debug prints.

## Testing
Video on basic usage and quick example of automation: https://vimeo.com/369739318  
Template file is an alteration of https://github.com/TheWover/donut/tree/master/DonutTest  
The donut generator will automatically drop the base64 shellcode into the Template loader as long as "{COCONUT}" follows the variable.  

Alternatively, the base64'ed and raw payload will still be saved in the directory.  

You need to edit the lines 44, 53, and 57 to programs that fit your needs depending on the payload.  

Currently, Helper.EditTemplate() is a simple find and replace, can twist and use however you like.  

## Future
Create more seamless automation for final payload generation, automatic compilation on windows/linux.  

Create a new class to generate a Config struct to pass to Donut_Create()
  
Upgrade to Core 3.0, I'm a derp and just did what I had.

## Whats broken until I fix
URL Delivery is not configured from the original project  
