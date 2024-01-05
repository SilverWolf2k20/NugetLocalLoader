# NugetLocalLoader

![coverage](https://img.shields.io/badge/version-0.2.0--alpha-blue)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/SilverWolf2k20/OkoloIt.Utilities.Logging/blob/master/LICENSE.md)

**NugetLocalLoader - ��� ��������� ��� �������� Nuget ������� � ��������� ����� �� ����� �������������.**

## �������������� ������ .NET

������ ����������� ����������� �������� �� .NET 8.0. ��� ������ � ���������� ���������� ���������� dotnet sdk 8.0.0.

## ���������

``` batch
dotnet tool install llnuget --global --add-source .\nupkg --version 0.2.0
```

## �������������

``` batch
:: ����� �������
llnuget find packages <package_name> -c <count>

:: ����� ������
llnuget find versions <package_name> -c <count>

:: ����� ������������
llnuget find deps <package_name> -v <version>

:: �������� ������
llnuget load package <package_name> -v <version> -p <path>

:: �������� ������ �� ����� �������������
llnuget load package <package_name> -v <version> -p <path> -�
```

## �������� �����

- [X] ����� ������
- [X] ����������� ���� ������ ������
- [X] �������� ������
- [X] ����������� Cli ����������
- [X] ����� ������������ ������
- [ ] �������� ���� ������������ ������
- [ ] ���������� ������������ �� ������ ������ ������������
- [ ] ������������ ������� ������������ �������
- [ ] ����������� GUI ����������

## ������

[Okolo IT](https://vk.com/okolo_it_govnokoding)

## ��������
>�� ������ ������������ � ������ ��������� [�����](https://github.com/SilverWolf2k20/NugetLocalLoader/blob/master/LICENSE.md)
���� ������ ��������� ��� ��������� **MIT**.
