# NugetLocalLoader

![coverage](https://img.shields.io/badge/version-0.2.0--alpha-blue)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/SilverWolf2k20/OkoloIt.Utilities.Logging/blob/master/LICENSE.md)

**NugetLocalLoader - это программа для загрузки Nuget пакетов в локальную папку со всеми зависимостями.**

## Поддерживаемые версии .NET

Данное программное обеспечение работает на .NET 8.0. Для работы с программой необходимо установить dotnet sdk 8.0.0.

## Установка

``` batch
dotnet tool install llnuget --global --add-source .\nupkg --version 0.2.0
```

## Использование

``` batch
:: Поиск пакетов
llnuget find packages <package_name> -c <count>

:: Поиск версий
llnuget find versions <package_name> -c <count>

:: Поиск зависимостей
llnuget find deps <package_name> -v <version>

:: Загрузка пакета
llnuget load package <package_name> -v <version> -p <path>

:: Загрузка пакета со всеми зависимостями
llnuget load package <package_name> -v <version> -p <path> -с
```

## Дорожная карта

- [X] Поиск пакета
- [X] Отображение всех версий пакета
- [X] Загрузка пакета
- [X] Полноценное Cli приложение
- [X] Поиск зависимостей пакета
- [X] Загрузка всех зависимостей пакета
- [ ] Фильтрация зависимостей на основе списка существующих
- [ ] Геренераторы списков существующих пакетов
- [ ] Полноценное GUI приложение

## Авторы

[Okolo IT](https://vk.com/okolo_it_govnokoding)

## Лицензия
>Вы можете ознакомиться с полной лицензией [здесь](https://github.com/SilverWolf2k20/NugetLocalLoader/blob/master/LICENSE.md)
Этот проект находится под лицензией **MIT**.
