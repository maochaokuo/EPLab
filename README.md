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
### 2020/8/9
1. query
2. expression and operator

### 2020/8/6
1. import done without bug
2. building query, lost field order (initial

### 2020/8/5
1. finally import DataTable to generic data first version done

### 2020/7/29
1. connection string from app setting json finally corrrect

### 2020/7/27
1. create database EPLlabDB
2. entity framework class library
3. sql server db project

### 2020/7/26
1. initial version
2. project structure
3. .net core web

