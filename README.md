# NugetLocalLoader

![coverage](https://img.shields.io/badge/version-1.1.0-blue)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/SilverWolf2k20/OkoloIt.Utilities.Logging/blob/master/LICENSE.md)

**NugetLocalLoader - это программа для загрузки Nuget пакетов в локальную папку со всеми зависимостями.**

## Поддерживаемые версии .NET

Данное программное обеспечение работает на .NET 8.0. Для работы с программой необходимо установить dotnet sdk 8.0.0.

## Установка

``` batch
dotnet tool install llnuget --global --prerelease --add-source .\nupkg --version 1.0.0
```

## Использование

### Команда `find`

Выполняет поиск данных о пакетах.

Подкоманда `packages` выполняет поиск пакетов.

``` batch
:: -c, --count <count>  Количество выводимых записей в консоль (По умолчанию 10).
llnuget find packages <package_name>
```
Подкоманда `versions` выполняет поиск версий пакета.

``` batch
:: -c, --count <count>  Количество выводимых записей в консоль (По умолчанию 10).
llnuget find versions <package_name>
```

Подкоманда `deps` выполняет поиск зависимостей пакета.

``` batch
:: -v, --version <version>  Версия пакета.
llnuget find deps <package_name>
```

Подкоманда `storage` выполняет поиск сущесвующих пакетов в указанной директории.

``` batch
:: -c, --count <count>  Количество выводимых записей в консоль (По умолчанию 10).
:: -s, --save-to-file <save-to-file> Сохраняет список в файл.
llnuget find storage <package_folder>
```

### Команда `load`

Выполняет загрузку пакетов.

Подкоманда `package` выполняет загрузку пакета.

``` batch
:: -c, --can-load-dependencies Флаг загрузки зависимостей пакета.
:: -i, --can-ignore-existing Флаг игнорирования существующих пакетов.
:: -v, --version <version> Версия пакета.
:: -p, --package-folder <package-folder> Директория с пакетами.
:: -e, --existing-package-list <existing-package-list> Файл со списком существующих пакетов.
llnuget load package <package_name>
```

## Дорожная карта

- [X] Поиск пакета
- [X] Отображение всех версий пакета
- [X] Загрузка пакета
- [X] Полноценное Cli приложение
- [X] Поиск зависимостей пакета
- [X] Загрузка всех зависимостей пакета
- [X] Фильтрация зависимостей на основе списка существующих
- [X] Геренераторы списков существующих пакетов
- [X] Написание тестов и исправление вылетов
- [ ] Полноценное GUI приложение

## Авторы

[Okolo IT](https://vk.com/okolo_it_govnokoding)

## Лицензия
>Вы можете ознакомиться с полной лицензией [здесь](https://github.com/SilverWolf2k20/NugetLocalLoader/blob/master/LICENSE.md)
Этот проект находится под лицензией **MIT**.
