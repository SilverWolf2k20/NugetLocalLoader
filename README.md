# NugetLocalLoader

![coverage](https://img.shields.io/badge/version-0.0.3--pre--alpha-blue)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/SilverWolf2k20/OkoloIt.Utilities.Logging/blob/master/LICENSE.md)

**NugetLocalLoader - это программа для загрузки Nuget пакетов в локальную папку со всеми зависимостями.**

## Поддерживаемые версии .NET

Данное программное обеспечение работает на .NET 8.0. Для работы с программой необходимо установить dotnet sdk 8.0.0.

## Установка

```batch
dotnet tool install --global --add-source .\nupkg llnuget --varsion 0.0.3
```

## Использование

```batch
:: Поиск пакетов
llnuget find packages <package_name> -c <count>

:: Поиск версий
llnuget find versions <package_name> -c <count>

:: Загрузка пакета
llnuget load package <package_name> -v <version> -p <path>
```

## Дорожная карта

- [X] Поиск пакета
- [X] Отображение всех версий пакета
- [X] Загрузка пакета
- [X] Полноценное Cli приложение
- [ ] Поиск зависимостей пакета
- [ ] Загрузка всех зависимостей пакета
- [ ] Фильтрация пакета на основе списка существующих
- [ ] Геренераторы списков существующих пакетов
- [ ] Полноценное GUI приложение

## Авторы

[Okolo IT](https://vk.com/okolo_it_govnokoding)

## Лицензия
>Вы можете ознакомиться с полной лицензией [здесь](https://github.com/SilverWolf2k20/NugetLocalLoader/blob/master/LICENSE.md)
Этот проект находится под лицензией **MIT**.
