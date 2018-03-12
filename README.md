# automapper-debugger
Some debugging helpers for Automapper

## How to use
1. Add the NuGet package to your project
2. Set your data
3. Call the function you need

### static functions
You can call several functions directly from your code since they are static. They all need an IMapper instance as a parameter.

ie: TypeMap[] maps = automapper-debugger.GetAllMappedTypes(mapper);

### non static functions
For testing your mappings on the go you will need to create an instance of the Debugger class.
Imagine you have an Origin class and a Destination class, and a map definition from Origin to Destination. If you want to test the mapping for specific values of Origin you have to follow these steps:
1. Edit the DebuggerTestObjects.cs file and add an instance of your Origin class in the DebuggerTestObjects() constructor.
2. Set the property values as you want.
3. Call The TestMapping() function from your code passing as a parameter an instance of your IMapper as follows:

Destination destination = new Debugger<Origin, Destination>().TestMapping(mapper);
