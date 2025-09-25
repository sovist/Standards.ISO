using System.Reflection;

[assembly: AssemblyCompany("Oleksandr Semeniuk")]
[assembly: AssemblyCopyright("Copyright (c) 2025 Oleksandr Semeniuk")]

[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/sovist/Standards.ISO")]

[assembly: AssemblyVersion(ThisAssembly.Git.BaseTag)]

[assembly: AssemblyFileVersion(ThisAssembly.Git.BaseTag)]

[assembly: AssemblyInformationalVersion(
    ThisAssembly.Git.BaseTag + "+" +
    ThisAssembly.Git.Branch + "+" +
    ThisAssembly.Git.Commit)]