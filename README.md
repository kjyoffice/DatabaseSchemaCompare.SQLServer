# DatabaseSchemaCompare.SQLServer

양쪽의 SQL Server 데이터베이스 스키마를 비교하는 도구

## 빌드 환경

- .NET 10

- VisualStudio 2026
  
  OR

- VisualStudio Code with C# Extension

## 빌드

- Repository 클론

### VisualStudio

- VisualStudio에서 솔루션 파일을 열고 빌드

### Console

- Repository를 클론한 디렉토리로 이동 후 빌드

```bash
dotnet build
```
OR
```bash
dotnet build -c Release
```

### 빌드 후 실행 프로그램

`SOLUTION_DIRECTORY` > `DatabaseSchemaCompare.SQLServer` > `bin` > `Debug`

OR

`SOLUTION_DIRECTORY` > `DatabaseSchemaCompare.SQLServer` > `bin` > `Release`

### 실행

```bash
DatabaseSchemaCompare.SQLServer.exe <Source_ConnectionString> <Target_ConnectionString> 
```

```bash
DatabaseSchemaCompare.SQLServer.exe <Source_ConnectionString> <Target_ConnectionString> 
<ReportDirectory>
```

### 실행 샘플 데이터베이스

- Source
    - Server : `192.168.1.101`
    - Database : `SourceDB`
    - ID : `hello`
    - Password : `worldpwd`

- Source
    - Server : `192.168.1.102`
    - Database : `TargetDB`
    - ID : `hello`
    - Password : `worldpwd`

- Source ConnectionString

    - Server=`192.168.1.101`; Database=`SourceDB`; User Id=`hello`; Password=`worldpwd`; TrustServerCertificate=true;

- Target ConnectionString

    - Server=`192.168.1.102`; Database=`TargetDB`; User Id=`hello`; Password=`worldpwd`; TrustServerCertificate=true;

### 실행 샘플

```bash
DatabaseSchemaCompare.SQLServer.exe "Server=192.168.1.101; Database=SourceDB; User Id=hello; Password=worldpwd; TrustServerCertificate=true;" "Server=192.168.1.102; Database=TargetDB; User Id=hello; Password=worldpwd; TrustServerCertificate=true;"
```

```bash
DatabaseSchemaCompare.SQLServer.exe "Server=192.168.1.101; Database=SourceDB; User Id=hello; Password=worldpwd; TrustServerCertificate=true;" "Server=192.168.1.102; Database=TargetDB; User Id=hello; Password=worldpwd; TrustServerCertificate=true;" "C:\HelloReportXYZ"
```


