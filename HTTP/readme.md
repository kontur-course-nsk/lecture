HTTP
====

## Теория

В первой части занятия стедунтам рассказывает про механику HTTP.
[Презентация](https://github.com/kontur-course-nsk/lecture/blob/master/HTTP/http.pptx)

## Практика

Оставшееся время студенты проходят [HTTP квест](https://github.com/kontur-course-nsk/lecture/tree/master/HTTP/HttpQuest).

>> Запускаем приложение в локальной сети и даем студентам endpoint. Их задача пройти все этапы с помощью CURL.

## Заментки

Студенты плохо владеют консолью. Нужно переработать примеры использования curl, чтобы ребята не впадали в ступор.

>> Например, на одном этапе нужно отправить запрос по адресу с двумя query-параметрами (вроде ...?key1=value1&key2=value2) - терминал вопринимает символ `&` служебным и пытается выполнить две команды. Ребята самостоятельно не понимают что происходит, нужно подсказать взять URL в ковычки.
