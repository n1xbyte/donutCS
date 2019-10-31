# Nuget Package
https://vimeo.com/369965334

## Installation (Visual Studio)
This applies only to VS but same concept applies errrrywhere  

Compiling Donut should now output a Nuget Package which you can import directly to your project and utilize.  

The output directory \bin\ from Donut's root directory and ends with .nupkg (Likely DonutCore.1.0.X.X.nupkg)  

Then go to your project that you wish to import DonutCore, right click project->Manage NuGet Packages  

![image](https://user-images.githubusercontent.com/18420902/67906797-5a693f80-fb3b-11e9-9acf-0bf193f1cede.png)

Click the Cog for settings -> Add package source  

![image](https://user-images.githubusercontent.com/18420902/67907450-85ed2980-fb3d-11e9-980d-cd6f3b9c3f83.png)

Name unimportant, point it to folder with the plugin  

![image](https://user-images.githubusercontent.com/18420902/67906946-d82d4b00-fb3b-11e9-80a5-6a242ed7c23e.png)

Then when browsing, it should register as DonutCore -> Install it  

![image](https://user-images.githubusercontent.com/18420902/67906985-fb57fa80-fb3b-11e9-9f6c-6f9093575e21.png)

## Usage

You must import Donut and generate a DonutConfig (which was changed from generic ```Config``` in video)  
```DonutConfig config = new DonutConfig();```  

You can then assign all your arguments to this struct.  
Required args: Arch, Bypass, InputFile (Arch and Bypass can default to 3 if you're unsure)  

Available args:  
	Arch  
	Bypass  
	Domain  
	Class  
	Method  
	Args  
	InputFile  
	Runtime  
	Payload  
	URL (not supported yet and Donut will yell at you if you use)  

Donut_Create returns an int which can be passed to GetError() to print a string for verbose errors. See code below.  

## Example Code
This can be used as an example code for generation:  
```
using System;

using Donut;
using Donut.Structs;

namespace NugutTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DonutConfig config = new DonutConfig();
            config.Arch = 3;
            config.Bypass = 3;
            config.InputFile = @"C:\Users\splda3\Desktop\GIT\donut-master\DemoCreateProcess\bin\Debug\DemoCreateProcess.dll";
            config.Class = "TestClass";
            config.Method = "RunProcess";
            config.Args = "notepad.exe,calc.exe";
            config.Payload = @"C:\Users\splda3\Desktop\demdonuts\Donut\bin\NugetTest.bin";
            int ret = Generator.Donut_Create(ref config);
            Console.WriteLine(Helper.GetError(ret));
        }
    }
}
```