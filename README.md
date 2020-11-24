# EntityFrameworkCore Extensions
EntityFramework Core database-driven extension


## LICENSES
![GitHub](https://img.shields.io/github/license/rivenfx/EntityFrameworkCore?color=brightgreen)
[![Badge](https://img.shields.io/badge/link-996.icu-%23FF4D5B.svg?style=flat-square)](https://996.icu/#/zh_CN)
[![LICENSE](https://img.shields.io/badge/license-Anti%20996-blue.svg?style=flat-square)](https://github.com/996icu/996.ICU/blob/master/LICENSE)

Please note: once the use of the open source projects as well as the reference for the project or containing the project code for violating labor laws (including but not limited the illegal layoffs, overtime labor, child labor, etc.) in any legal action against the project, the author has the right to punish the project fee, or directly are not allowed to use any contains the source code of this project!

## Build Status
[![Build Status](https://dev.azure.com/rivenfx/RivenFx/_apis/build/status/rivenfx.EntityFrameworkCore?branchName=master)](https://dev.azure.com/rivenfx/RivenFx/_build/latest?definitionId=7&branchName=master)


## Nuget Packages

|Package|Status|Downloads|
|:------|:-----:|:-----:|
|Riven.EntityFrameworkCore.PostgreSQL|[![NuGet version](https://img.shields.io/nuget/v/Riven.EntityFrameworkCore.PostgreSQL?color=brightgreen)](https://www.nuget.org/packages/Riven.EntityFrameworkCore.PostgreSQL/)|[![Nuget](https://img.shields.io/nuget/dt/Riven.EntityFrameworkCore.PostgreSQL?color=brightgreen)](https://www.nuget.org/packages/Riven.EntityFrameworkCore.PostgreSQL/)|
|Riven.EntityFrameworkCore.Oracle|[![NuGet version](https://img.shields.io/nuget/v/Riven.EntityFrameworkCore.Oracle?color=brightgreen)](https://www.nuget.org/packages/Riven.EntityFrameworkCore.Oracle/)|[![Nuget](https://img.shields.io/nuget/dt/Riven.EntityFrameworkCore.Oracle?color=brightgreen)](https://www.nuget.org/packages/Riven.EntityFrameworkCore.Oracle/)|
|Riven.EntityFrameworkCore.DevartOracle|[![NuGet version](https://img.shields.io/nuget/v/Riven.EntityFrameworkCore.DevartOracle?color=brightgreen)](https://www.nuget.org/packages/Riven.EntityFrameworkCore.DevartOracle/)|[![Nuget](https://img.shields.io/nuget/dt/Riven.EntityFrameworkCore.DevartOracle?color=brightgreen)](https://www.nuget.org/packages/Riven.EntityFrameworkCore.DevartOracle/)|


## Quick start
1. PostgreSQL
```csharp
builder.UseRivenPostgreSQL(
  "database connection string"
);

builder.UseRivenPostgreSQL(
  "database connection string",
  (options)=>
  {

  }
);
```
2. Oracle
```csharp
// Default SQLCompatibility V11
builder.UseRivenOracle(
  "database connection string"
);

builder.UseRivenOracle(
  "database connection string",
  (options)=>
  {
      //  SQLCompatibility V12
      //options.UseOracleSQLCompatibility(OracleSQLCompatibility.V12)
  }
);
```

3. Devart Oracle
```csharp
var license = ""; // Devart license
builder.UseRivenDevartOracle(
  "database connection string"，
  license
);

builder.UseRivenDevartOracle(
  "database connection string",
  license,
  (options)=>
  {

  }
);
```


## Demos
Demo Address: [link](/tests/EFCoreTestApp)



## Q&A
If you have any questions, you can go to  [Issues](https://github.com/rivenfx/EntityFrameworkCore/issues)  to ask them.

## Stargazers over time

[![Stargazers over time](https://starchart.cc/rivenfx/EntityFrameworkCore.svg)](https://starchart.cc/rivenfx/EntityFrameworkCore)