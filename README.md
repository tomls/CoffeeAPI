# CoffeeAPI

Prerequisites

.NET Framework 4.5.2 or later 

.NET Core 2.1 SDK or later 

Visual Studio Code 

C# for Visual Studio Code 


Open root folder with Visual studio code. 

You should be promted with a popup: "Required assets to build and debug are missing from CoffeeAPI. Add them?", select "yes"

From menu select Debug -> Start Debuging (F5). 

This should start debuger as well as open a default browser's windows with "http://localhost:5000" URL.


If you navigate to "http://localhost:5000/api/coffee" you will get a list of avaiable elements.

Note: This list is saved in in-memory DB. It always initializes when it is empty. It resets if application is restarted
