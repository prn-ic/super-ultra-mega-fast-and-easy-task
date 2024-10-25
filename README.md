# EffectiveMobileTests

ТЗ (которое непонятно от слова совсем):
- Необходимо разработать консольное приложение (по желанию можно WinForms
либо WebApi) для службы доставки, которое фильтрует заказы в зависимости от
количества обращений в конкретном районе города и времени обращения с и по.

## Как запустить и какие зависимости?
- никаких зависимостей нет, переходим в директорию с API, и пишем dotnet run
- есть только одна ручка на получение результата, данные в базу уже занесены, кстати вот они:

----
weight = 1;
city = city1;
district = district1;
street = street1;
houseNumber = 1d
дата хз
----

----
weight = 2;
city = Moskow;
district = Tereshkova;
street = Tereshkova;
houseNumber = 1
дата хз
----

----
weight = 3;
city = Moskow;
district = Tereshkova;
street = Tereshkova;
houseNumber = 2a
дата хз
----
