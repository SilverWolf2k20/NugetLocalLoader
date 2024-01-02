# =============================================================================
# Скрипт сборки проекта.
# Проек собирается для версии NET core.
# =============================================================================

# Конфигурация.
$project = "..\NugetLocalLoader.sln";
$tagretProject = "..\src\OkoloIt.NugetLocalLoader.Cli";

# Определение имени файла проекта.
$projectFile = Get-ChildItem -Path $tagretProject -Filter *.csproj | % {$_.FullName}

# Получение данных проекта.
[xml]$projectContents = Get-Content -Path $projectFile;
$version = "{0}".Trim() -f $projectContents.Project.PropertyGroup.Version;
$product = "{0}".Trim() -f $projectContents.Project.PropertyGroup.ToolCommandName;

Write-Host Целевой проект $tagretProject      -ForegroundColor Green;

Write-Host Продукт        $product            -ForegroundColor Green;
Write-Host Версия сборки  $version            -ForegroundColor Green;
Write-Host Имя сборки     "$product $version" -ForegroundColor Green;

# Cборка проекта
cd ..\

dotnet clean
dotnet build -c Release
dotnet pack -c Release

Read-Host -Prompt "Press any key to continue"