Пример работы веб апи с пайплайном.

Контроллер для проверки - PipeLineExampleController

Get - не делает ничего.
Post - имитирует работу и сохраняет определенную инфу в файл.

Пример Post json`а:

{
	"InputString":"asdas wqrasf wrwrsaf wr",
	"SenderName":"Ne Alesha"
}

InputString - Список слов. ***разделение будет идти через пробел (в этой версии)***
SenderName - Имя отправителя

***Важно***
В настройках appsettings.json есть

  "SaveWordsToFileOptions": {
    "FilePath": "Information.txt",
    "DelayTime": 10
  },
  "SeparateWordsOptions": {
    "DelayTime": 10,
    "BadWords": ["Word1", "Word2"]
  }

FilePath - путь к файлу, в который будет записываться инфа
DelayTime - время для имитации задержки (в секундах)
BadWords - список "запрещенных" слов

Это лишь прототип, еще нужно многое доработать.