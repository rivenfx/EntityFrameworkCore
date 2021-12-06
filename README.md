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

**namespace:**

```c#
using Microsoft.EntityFrameworkCore.Extensions;
```

* **PostgreSQL**

DesignTimeDbContextFactory：

```csharp
var builder = new DbContextOptionsBuilder<AppDbContext>();

// sample
builder.UseNpgsql(
  "database connection string"
);
// OR
builder.UseNpgsql(
  "database connection string",
  (options)=>
  {

  }
);

return new AppDbContext(builder.Options);
```

AppDbContext OnModelCreating:

```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);


    // 写到最后
    modelBuilder.TableMappingToPostgreSQL((entityType) =>
    {
        // 校验是否处理此实体
        return true;
    });
}
```

* **Oracle**

DesignTimeDbContextFactory：

```csharp
var builder = new DbContextOptionsBuilder<AppDbContext>();

// Default SQLCompatibility V12
builder.UseOracle(
  "database connection string"
);
// OR
builder.UseOracle(
  "database connection string",
  (options)=>
  {
      //  SQLCompatibility V11
      //options.UseOracleSQLCompatibility(OracleSQLCompatibility.V11);
  }
);

return new AppDbContext(builder.Options);
```

AppDbContext OnModelCreating:

```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);


    // 写到最后
    modelBuilder.TableMappingToOracle((entityType) =>
    {
        // 校验是否处理此实体
        return true;
    });
}
```

* **Devart Oracle**

DesignTimeDbContextFactory：

```csharp
var builder = new DbContextOptionsBuilder<AppDbContext>();

var license = ""; // Devart license
// sample
builder.UseDevartOracle(
  "database connection string"，
  license
);
// OR
builder.UseDevartOracle(
  "database connection string",
  license,
  (options)=>
  {

  }
);
return new AppDbContext(builder.Options);
```

AppDbContext OnModelCreating:

```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);


    // 写到最后
    modelBuilder.TableMappingToDevartOracle((entityType) =>
    {
        // 校验是否处理此实体
        return true;
    });
}
```





## Demos

Demo Address: [link](/tests/EFCoreTestApp)



## Q&A
If you have any questions, you can go to  [Issues](https://github.com/rivenfx/EntityFrameworkCore/issues)  to ask them.

## Stargazers over time

[![Stargazers over time](https://starchart.cc/rivenfx/EntityFrameworkCore.svg)](https://starchart.cc/rivenfx/EntityFrameworkCore)