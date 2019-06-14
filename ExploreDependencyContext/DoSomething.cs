using Microsoft.Extensions.DependencyModel;
using System;

namespace ExploreDependencyContext
{
    public interface IDoSomething
    {
        void PrintExecutingAssemblyDetails();

        void PrintDependencyContextDetails(bool onlyCompileLibraries = false);
    }

    public class DoSomething : IDoSomething
    {
        public void PrintExecutingAssemblyDetails()
        {
            var executingAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            Console.WriteLine("---ReferencedAssemblies--");
            var referencedAssemblies = executingAssembly.GetReferencedAssemblies();
            foreach (var assembly in referencedAssemblies)
            {
                Console.WriteLine(assembly.Name);
            }

            Console.WriteLine();
        }

        public void PrintDependencyContextDetails(bool onlyCompileLibraries = false)
        {
            Console.WriteLine();
            Console.WriteLine("---DependencyContext Details:---");
            Console.WriteLine();
            Console.WriteLine($"TargetFramework: {DependencyContext.Default.Target.Framework}");
            Console.WriteLine($"IsPortable: {DependencyContext.Default.Target.IsPortable}");
            Console.WriteLine($"Runtime: {DependencyContext.Default.Target.Runtime}");
            Console.WriteLine($"RuntimeSignature: {DependencyContext.Default.Target.RuntimeSignature}");

            Console.WriteLine();
            Console.WriteLine("---CompileLibraries--");

            if (DependencyContext.Default.CompileLibraries.Count == 0)
                Logger.Error("No CompileLibraries", new Exception());

            foreach (var compilationLibrary in DependencyContext.Default.CompileLibraries)
            {
                Console.WriteLine(compilationLibrary.Name);
            }

            if (onlyCompileLibraries)
                return;


            Console.WriteLine();
            Console.WriteLine("---RuntimeLibraries--");

            foreach (var runtimeLinbrary in DependencyContext.Default.RuntimeLibraries)
            {
                Console.WriteLine(runtimeLinbrary.Name);
            }

            Console.WriteLine();
            Console.WriteLine("---DefaultAssemblies--");

            var defaultAssemblyNames = DependencyContext.Default.GetDefaultAssemblyNames();
            foreach (var assemblyName in defaultAssemblyNames)
            {
                Console.WriteLine(assemblyName);
            }

            Console.WriteLine();
        }
    }
}
