Тестовое задание
MVC ASP.NET приложение
2 контроллера GetController и HomeController

Controllers
GetController предназначен для получения информации об архивах  в бд(по месяцам и по годам)
HomeController для основной страницы и загрузки новых архивов в бд

Models
классы для описания сущностей в бд
Месяц - Month
Год - Year
замер погоды - WeatherMeasurment
Класс для передачи данных в View - ResponseClass

Services
сервис для считывания данных из класса и создания из них объектов
сервис сохранения в бд
сервис получения данных из бд 

ApplicatioContext
класс для работы с бд