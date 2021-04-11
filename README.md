# donutCS

.NET Core version of donut shellcode generator.  
https://vimeo.com/369739318  

Note: I simply glued a bunch of things together. TheWover and Odzhan did all the hard work.

## Install
Confirmed working on Linux, Mac and Windows  
[Kali Install Instructions](./docs/Install.md) 

## Usage

### Nuget Package (Preferred)
Download and add from nuget repo : https://www.nuget.org/packages/DonutCore/  
See usage [here](./docs/Nuget.md#Usage)  

or  

I have added the package to the root directory. (DonutCore.1.0.1.nupkg)  
Import instructions & short vid for time being can be found [here](./docs/Nuget.md)  

The package also now automatically generated when compiled inside the \bin\ directory.  

### Normal
Refer to https://github.com/TheWover/donut for full usage. Should be exactly the same.    
Basic usage can be found [here](./docs/KaliUse.md)  

From the root of the donut directory you can run ```dotnet run``` or ```dotnet run --configuration Release``` if you don't want to see the marshalling errors and debug prints.  

## Testing
Video on basic usage and quick example of automation: https://vimeo.com/369739318  

Template Project is an alteration of https://github.com/TheWover/donut/tree/master/DonutTest    

## Whats broken until I fix
URL Delivery is not configured from the original project  
