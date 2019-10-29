# donutCS

.NET Core version of donut shellcode generator.

## Install
Confirmed working on Kali (see docs folder for install) and Windows

## Usage
Refer to https://github.com/TheWover/donut for usage. Should be exactly the same.

## Testing
https://github.com/TheWover/donut/tree/master/DonutTest
Take your base64'ed output and apply it to shellcode in Program.cs

## Future
Thinking of adding an API to just supply a parameters and a file/filestream? for C2 integrations.  
Will document it when done

Upgrade to Core 3.0, I'm a derp and just did what I had.

## Whats broken until I fix

URL Delivery is not configured from the original project  

File output currently works fine but code is ugly and I'll straighten it out as I figure out how I want to do