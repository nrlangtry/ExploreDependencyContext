# ExploreDependencyContext
.NET Core Console App printing-out various details of the Microsoft.Extensions.DependencyModel's DependencyContext.

Our company was using a 3rd-party framework that registered classes for dependency injection using the DependencyContext.Default.CompileLibraries.  I found that no classes were registered after publishing to windows because the CompileLibraries property was empty.  I created this project to reproduce the specific issue & to look into the DependencyContext and what options we had to fix the issue.

To reproduce:
1. Publish to a folder with a target runtime of "win-x64".
2. Run the dll ("dotnet ExploreDependencyContext.dll") or the exe (ExploreDependencyContext.exe).  Use the "-c" argument to only print the DependencyContext's CompileLibraries.

This is not an issue when:
1. You run the dll in the the Release directory (not publish or win-x64)
2. The Publish's Target Runtime is Portable.
