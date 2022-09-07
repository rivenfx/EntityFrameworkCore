# V0.8.14
- 重新添加 Riven.EntityFrameworkCore.Oracle 对 .NET5 的支持


# V0.8.13
- 修改原有Oracle扩展类名与文件名： RivenOracleModelBuilderExtenions -> RivenOracleDbContextModelBuilderExtensions
- 新增 `RivenOracleAnnotationCodeGenerator` 与  `RivenOracleDesignTimeServices`，修复迁移 Designer 文件主键调用扩展函数冲突的问题
- 移除 Riven.EntityFrameworkCore.Oracle 对 .NET5 的支持