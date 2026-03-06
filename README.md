📚 LibraryAPI / Библиотечный API

DE: Eine REST API für ein Bibliotheksverwaltungssystem, entwickelt mit ASP.NET Core und MySQL.
RU: REST API для системы управления библиотекой, разработанная на ASP.NET Core и MySQL.


🛠 Technologien / Технологии
Technologie / ТехнологияVersion.NET9.0ASP.NET Core Web API9.0Entity Framework Core9.0Pomelo MySQL Driver9.0MySQL (XAMPP)8.xSwagger / OpenAPI10.x

📋 Funktionen / Функции
DE:

✅ Bücher verwalten (erstellen, lesen, aktualisieren, löschen)
✅ Autoren verwalten mit Beziehungen zu Büchern
✅ Mitglieder (Bibliotheksnutzer) verwalten
✅ Buchausleihe und -rückgabe mit automatischer Verfügbarkeitsprüfung
✅ Suche und Filterung von Büchern
✅ Globale Fehlerbehandlung

RU:

✅ Управление книгами (создание, чтение, обновление, удаление)
✅ Управление авторами со связями к книгам
✅ Управление читателями библиотеки
✅ Выдача и возврат книг с автоматической проверкой доступности
✅ Поиск и фильтрация книг
✅ Глобальная обработка ошибок


🗄 Datenbankstruktur / Структура базы данных
Authors (Авторы)
│
└── Books (Книги)
        │
        └── Loans (Выдачи)
                │
Members ────────┘
(Читатели)
Tabellen / Таблицы
Tabelle / ТаблицаBeschreibung / ОписаниеAuthorsAutoren der Bücher / Авторы книгBooksBücher mit Verfügbarkeit / Книги с доступностьюMembersBibliotheksnutzer / Читатели библиотекиLoansBuchausleihen / Выдачи книг

🚀 Installation / Установка
DE: Voraussetzungen: .NET 9.0 SDK, XAMPP (MySQL), Git
RU: Требования: .NET 9.0 SDK, XAMPP (MySQL), Git
bash# 1. Repository klonen / Клонировать репозиторий
git clone https://github.com/gwinplane/LibraryAPI.git
cd LibraryAPI

# 2. Pakete wiederherstellen / Восстановить пакеты
dotnet restore

# 3. MySQL starten (XAMPP) / Запустить MySQL (XAMPP)
# Starten Sie XAMPP und aktivieren Sie MySQL
# Запустите XAMPP и включите MySQL

# 4. Datenbank migrieren / Применить миграции
dotnet ef database update

# 5. Anwendung starten / Запустить приложение
dotnet run

🌐 API Endpunkte / Эндпоинты API
📖 Bücher / Книги
MethodeEndpunktBeschreibung / ОписаниеGET/api/booksAlle Bücher / Все книгиGET/api/books?title=войнаSuche nach Titel / Поиск по названиюGET/api/books?available=trueNur verfügbare / Только доступныеGET/api/books/{id}Buch nach ID / Книга по IDPOST/api/booksNeues Buch / Новая книгаPUT/api/books/{id}Buch aktualisieren / Обновить книгуDELETE/api/books/{id}Buch löschen / Удалить книгу
✍️ Autoren / Авторы
MethodeEndpunktBeschreibung / ОписаниеGET/api/authorsAlle Autoren / Все авторыGET/api/authors/{id}Autor mit Büchern / Автор с книгамиPOST/api/authorsNeuer Autor / Новый авторDELETE/api/authors/{id}Autor löschen / Удалить автора
👤 Mitglieder / Читатели
MethodeEndpunktBeschreibung / ОписаниеGET/api/membersAlle Mitglieder / Все читателиGET/api/members/{id}Mitglied mit Ausleihen / Читатель с выдачамиPOST/api/membersNeues Mitglied / Новый читательDELETE/api/members/{id}Mitglied löschen / Удалить читателя
📋 Ausleihen / Выдачи
MethodeEndpunktBeschreibung / ОписаниеGET/api/loansAlle Ausleihen / Все выдачиGET/api/loans/overdueÜberfällige Ausleihen / Просроченные выдачиPOST/api/loansBuch ausleihen / Выдать книгуPUT/api/loans/{id}/returnBuch zurückgeben / Вернуть книгу

📝 Beispiele / Примеры
Buch ausleihen / Выдать книгу
jsonPOST /api/loans
{
    "bookId": 1,
    "memberId": 1
}
Neues Mitglied / Новый читатель
jsonPOST /api/members
{
    "fullName": "Юлия Марин",
    "email": "julia@example.com",
    "phone": "+49123456789"
}

📖 Swagger Dokumentation / Документация Swagger
DE: Nach dem Start der Anwendung ist die Swagger UI verfügbar unter:
RU: После запуска приложения Swagger UI доступен по адресу:
http://localhost:5094/swagger

👩‍💻 Autorin / Автор
Юлия Марин — C# / .NET Entwicklerin in Ausbildung

Entwickelt als Lernprojekt / Разработано как учебный проект 🎓