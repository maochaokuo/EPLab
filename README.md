# EPLab

## introduction
1. lab tool for EPL, hopefully


## EntityFramework Core tips
1. from existing database
```
Scaffold-DbContext "Server=.;Database=EPLlabDB;User Id=sa;Password=sa;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```
2. if Model directory already exist, use -Force
3. if Scaffold-DbContext not recognized, run:
```
Install-Package Microsoft.EntityFrameworkCore.Tools
```

## change log
### 2020/7/27
1. create database EPLlabDB
2. entity framework class library
3. sql server db project

### 2020/7/26
1. initial version
2. project structure
3. .net core web

