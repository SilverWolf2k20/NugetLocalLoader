# NugetLocalLoader

![coverage](https://img.shields.io/badge/version-0.0.2--pre--alpha-blue)
<!--![coverage](https://img.shields.io/badge/-Okolo%20IT-orange)-->
<!--![alt text](https://github.com/open-telemetry/opentelemetry-dotnet/actions/workflows/linux-ci.yml/badge.svg?branch=main)-->
<!--![alt text](https://github.com/open-telemetry/opentelemetry-dotnet/actions/workflows/windows-ci.yml/badge.svg?branch=main)-->
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/SilverWolf2k20/OkoloIt.Utilities.Logging/blob/master/LICENSE.md)

**NugetLocalLoader - это программа для загрузки Nuget пакетов в локальную папку со всеми зависимостями.**

## Поддерживаемые версии .NET

Данное программное обеспечение работает на .NET 8.0

## Использование

``` Python
# Поиск пакетов
llnuget find packages <package_name> -c <count>

# Поиск версий
llnuget find versions <package_name> -c <count>

# Загрузка пакета
llnuget load package <package_name> -v <version> -p <path>
```

## Дорожная карта

- [X] Поиск пакета
- [X] Отображение всех версий пакета
- [X] Загрузка пакета
- [ ] Поиск зависимостей пакета
- [ ] Загрузка всех зависимостей пакета
- [ ] Фильтрация пакета на основе списка существующих
- [ ] Геренераторы списков существующих пакетов
- [ ] Полноценное Cli приложение
- [ ] Полноценное GUI приложение

## Авторы

[Okolo IT](https://vk.com/okolo_it_govnokoding)

## Лицензия
>Вы можете ознакомиться с полной лицензией [здесь](https://github.com/SilverWolf2k20/NugetLocalLoader/blob/master/LICENSE.md)
Этот проект находится под лицензией **MIT**.
