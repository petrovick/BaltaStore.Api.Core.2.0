## Create new Project (API)

```
dotnet new webapi
```

## Create new Project (Classlib)

```
dotnet new classlib
```

### Create Solution
```
dotnet new sln
```

## Add to Solution
```
dotnet sln add ./BaltaStore.Tests/BaltaStore.Tests.csproj
```

## Add Reference to project
```
dotnet add reference ../BaltaStore.Domain/BaltaStore.Domain.csproj 
```

## Restore Packages
```
dotnet restore
```

### Dominios Ricos
Utiliza a orientacao a objetos para fazer o core da aplicacao ao inves do modelo anemico
Possui regras de negocios