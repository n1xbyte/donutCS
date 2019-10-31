# donutCS

.NET Core version of donut shellcode generator.  
https://vimeo.com/369739318  

Note: I simply glued a bunch of things together for a more personally useable version. TheWover and Odzhan did all the hard work, those dudes are god tier. (seriously if you saw the internals you'd understand)

## Install
Confirmed working on Linux, Mac and Windows  
[Kali Install Instructions](./docs/Install.md) 

## Usage

### Nuget Package (Preferred)
I have added the package to the root directory. (DonutCore.1.0.0.nupkg)  
Import instructions & short vid for time being can be found [here](./docs/Nuget.md)  

The package also now automatically generated when compiled inside the \bin\ directory.

It will be published on nuget.org (hopefully) eventually.  
(Name change due to Donut being taken on nuget.org)  

### Normal
Refer to https://github.com/TheWover/donut for full usage. Should be exactly the same.    
Basic usage can be found [here](./docs/KaliUse.md)  

From the root of the donut directory you can run ```dotnet run``` or ```dotnet run --configuration Release``` if you don't want to see the marshalling errors and debug prints.  

## Testing
Video on basic usage and quick example of automation: https://vimeo.com/369739318  

Template Project is an alteration of https://github.com/TheWover/donut/tree/master/DonutTest    

## Future
Create more seamless automation for final payload generation, automatic compilation on windows/linux.  
  
Upgrade to Core 3.0, I'm a derp and just did what I had.

## Whats broken until I fix
URL Delivery is not configured from the original project  
