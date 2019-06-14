# ExploreDependencyContext
.NET Core Console App printing-out various details of the Microsoft.Extensions.DependencyModel's DependencyContext.

Our company was using a 3rd-party framework that registered classes for dependency injection using the DependencyContext.Default.CompileLibraries.  I found that no classes were registered in release mode because the CompileLibraries property was null.

I created this project to look into the DependencyContext and what options we had to fix the issue.
