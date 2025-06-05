# QuizApp – opis projektu

QuizApp to nowoczesna aplikacja quizowa stworzona w technologii **Blazor** (.NET 9), umożliwiająca użytkownikom rozwiązywanie testów wiedzy z różnych kategorii tematycznych. Projekt wykorzystuje architekturę komponentową Blazora, co pozwala na dynamiczne i interaktywne budowanie interfejsu użytkownika bez konieczności przeładowywania strony. Całość działa w trybie serwerowym (Blazor Server), zapewniając szybkie reakcje na działania użytkownika i efektywne zarządzanie stanem aplikacji.

Podstawą przechowywania danych jest relacyjna baza danych obsługiwana przez **Entity Framework Core**. Struktura bazy obejmuje tabele dla użytkowników, kategorii, pytań, opcji odpowiedzi oraz wyników quizów. Dzięki migracjom EF Core, struktura bazy może być łatwo rozwijana i dostosowywana do nowych wymagań. W projekcie zaimplementowano również mechanizm seedowania danych, który automatycznie wypełnia bazę przykładowymi kategoriami, pytaniami i użytkownikami przy pierwszym uruchomieniu.

Aplikacja pozwala użytkownikowi na wybór lub utworzenie profilu, wybór kategorii quizu, a następnie rozwiązanie krótkiego testu składającego się z losowych pytań. Po zakończeniu quizu wynik jest zapisywany w bazie, a użytkownik otrzymuje podsumowanie oraz może porównać swój rezultat z innymi na tablicy wyników (leaderboard) z podziałem na kategorie. Interfejs jest responsywny i oparty o Bootstrap, co zapewnia wygodę korzystania zarówno na komputerach, jak i urządzeniach mobilnych.

Projekt został zaprojektowany z myślą o łatwej rozbudowie – zarówno pod kątem nowych kategorii i pytań, jak i dodatkowych funkcjonalności, takich jak rozbudowane statystyki czy tryby gry. Dzięki wykorzystaniu Blazora i Entity Framework Core, aplikacja jest nowoczesna, wydajna i łatwa w utrzymaniu.





## Home.razor

**Opis:**  
Strona startowa aplikacji QuizApp. Prezentuje powitalny ekran z krótkim opisem oraz przyciskiem przejścia do wyboru użytkownika.

**Funkcjonalność:**
- Wyświetla nazwę i opis aplikacji.
- Zawiera przycisk "Go next", który przekierowuje użytkownika do strony wyboru użytkownika (`/userselection`).

**Zależności:**
- `NavigationManager` – do obsługi nawigacji po kliknięciu przycisku.

**Parametry:**  
Brak parametrów wejściowych.

---

## UserSelection.razor

**Opis:**  
Strona umożliwiająca wybór istniejącego użytkownika z bazy lub utworzenie nowego profilu użytkownika.

**Funkcjonalność:**
- Pobiera i wyświetla listę użytkowników z bazy danych.
- Pozwala wybrać istniejącego użytkownika i przejść dalej.
- Umożliwia utworzenie nowego użytkownika poprzez formularz (wymagane: imię, płeć, wiek).
- Waliduje dane nowego użytkownika (unikalność imienia, wymagane pola, wiek > 0).
- Po wyborze lub utworzeniu użytkownika przekierowuje do strony wyboru kategorii (`/categoryselection?userId={id}`).

**Zależności:**
- `AppDbContext` – do pobierania i zapisywania użytkowników.
- `NavigationManager` – do nawigacji po wyborze/utworzeniu użytkownika.

**Parametry:**  
Brak parametrów wejściowych.

---


## QuizPage.razor

**Opis:**  
Strona realizująca główną funkcjonalność quizu. Użytkownik odpowiada na 3 losowo wybrane pytania z wybranej kategorii (lub ze wszystkich, jeśli wybrano kategorię "general"). Każde pytanie prezentowane jest wraz z możliwymi odpowiedziami, a postęp quizu wizualizuje pasek postępu.

**Funkcjonalność:**
- Pobiera 3 losowe pytania z wybranej kategorii (lub ze wszystkich, jeśli "general").
- Wyświetla pytania i możliwe odpowiedzi w formie przycisków.
- Pozwala przechodzić między pytaniami (przyciski "Previous", "Next", "Finish").
- Pokazuje pasek postępu (progress bar) z aktualnym pytaniem.
- Po zakończeniu quizu:
  - Oblicza wynik (liczba poprawnych odpowiedzi, czas rozwiązania, punkty).
  - Zapisuje wynik do bazy danych (jeśli użytkownik jest zalogowany).
  - Przekierowuje do strony z podsumowaniem quizu.

**Zależności:**
- `AppDbContext` – do pobierania pytań i zapisywania wyników.
- `NavigationManager` – do nawigacji po zakończeniu quizu.
- `QuizState` – do przechowywania wyniku i czasu quizu.

**Parametry:**
- `CategoryId` (z trasy) – identyfikator wybranej kategorii.
- `userId` (opcjonalny, z query string) – identyfikator użytkownika.

---

## QuizSummary.razor

**Opis:**  
Strona podsumowania quizu. Wyświetla szczegóły ukończonego quizu oraz tabelę najlepszych wyników (leaderboard) w wybranej kategorii.

**Funkcjonalność:**
- Pokazuje podsumowanie quizu: nazwę kategorii, liczbę poprawnych odpowiedzi, czas rozwiązania oraz zdobyte punkty.
- Jeśli quiz nie został ukończony, informuje użytkownika i umożliwia powrót na stronę główną.
- Wyświetla leaderboard (top 10 wyników) dla danej kategorii, zawierający: imię, wiek, płeć, wynik, czas, punkty i datę.
- Umożliwia powrót do strony głównej.

**Zależności:**
- `QuizState` – do pobierania informacji o bieżącym quizie.
- `AppDbContext` – do pobierania danych o kategorii i wynikach użytkowników.
- `NavigationManager` – do nawigacji.

**Parametry:**  
Brak parametrów wejściowych.

---

## Leaderboard.razor

**Opis:**  
Strona prezentująca tablicę wyników (leaderboard) z podziałem na kategorie. Użytkownik może wybrać kategorię quizu i zobaczyć najlepsze wyniki dla tej kategorii.

**Funkcjonalność:**
- Dostępna z poziomu sidebaru nawigacyjnego.
- Pozwala wybrać kategorię quizu z listy rozwijanej.
- Wyświetla tabelę z najlepszymi wynikami (top 10) dla wybranej kategorii:
  - Imię użytkownika
  - Wynik (liczba poprawnych odpowiedzi)
  - Czas rozwiązania quizu
  - Punkty (łączna punktacja)
  - Data uzyskania wyniku
- Przycisk umożliwiający powrót do wyboru kategorii.

**Zależności:**
- `AppDbContext` – do pobierania kategorii i wyników użytkowników.
- `NavigationManager` – do nawigacji.

**Parametry:**  
Brak parametrów wejściowych.

---

-----------------------INNE W FOLDERZE COMPONENTS--------------------------------

## App.razor

**Opis:**  
Główny plik startowy aplikacji Blazor, odpowiedzialny za ładowanie stylów, favicony oraz konfigurację routingu.

**Funkcjonalność:**
- Ustawia podstawowe meta tagi (`charset`, `viewport`, `base`).
- Ładuje style aplikacji:
  - Bootstrap (`lib/bootstrap/dist/css/bootstrap.min.css`)
  - Style globalne aplikacji (`app.css`)
  - Style generowane przez Blazora (`babis.styles.css`)
- Ustawia faviconę (`favicon.png`).
- Wstawia mapę importów (`<ImportMap />`) oraz obsługę nagłówka (`<HeadOutlet />`).
- Renderuje główny router aplikacji (`<Routes />`).
- Dołącza skrypt uruchamiający Blazora (`_framework/blazor.web.js`).

**Uwagi:**
- Plik ten jest odpowiednikiem głównego pliku HTML w klasycznych aplikacjach SPA.
- Wszystkie style i favicon są ładowane globalnie dla całej aplikacji.

---

## Routes.razor

**Opis:**  
Plik odpowiedzialny za konfigurację routingu w aplikacji Blazor. Określa, jak komponenty są ładowane na podstawie adresu URL.

**Funkcjonalność:**
- Używa komponentu `<Router>`, który automatycznie wykrywa wszystkie strony (`@page`) w głównym zestawie aplikacji (`AppAssembly="typeof(Program).Assembly"`).
- Dla znalezionych tras renderuje odpowiedni komponent w domyślnym układzie (`MainLayout`).
- Po każdej nawigacji automatycznie ustawia fokus na pierwszy nagłówek (`<h1>`) na stronie dzięki komponentowi `<FocusOnNavigate>`.

**Uwagi:**
- Wszystkie strony korzystają domyślnie z układu `MainLayout`, chyba że zadeklarowano inaczej w danym komponencie.
- Plik ten jest kluczowy dla działania nawigacji i obsługi tras w aplikacji Blazor.

---

-----------------------FOLDER DATA------------------


## AppDbContext.cs

**Opis:**  
Główny kontekst bazy danych aplikacji, oparty o Entity Framework Core. Odpowiada za mapowanie modeli domenowych na tabele w relacyjnej bazie danych oraz konfigurację relacji między encjami.

**Funkcjonalność:**
- Udostępnia zbiory (`DbSet`) dla głównych encji aplikacji:
  - `Categories` – kategorie quizów
  - `Questions` – pytania
  - `QuestionOptions` – możliwe odpowiedzi do pytań
  - `Quizzes` – quizy (zestawy pytań)
  - `Users` – użytkownicy
  - `UserQuizResults` – wyniki użytkowników
- Konfiguruje relacje i zachowania encji:
  - Konwersja typu `Gender` na string w bazie.
  - Relacje jeden-do-wielu (np. kategoria → pytania, quiz → pytania, pytanie → opcje, użytkownik → wyniki).
  - Ustawia kaskadowe usuwanie powiązanych rekordów.
  - Domyślna wartość daty (`Date`) dla wyników quizu to aktualny czas UTC.
- Pozwala na dalszą konfigurację modeli w metodzie `OnModelCreating`.

**Zależności:**
- Entity Framework Core (`DbContext`)
- Modele domenowe z przestrzeni nazw `babis.Models`

**Uwagi:**
- Plik ten jest centralnym miejscem konfiguracji bazy danych i relacji w aplikacji.
- Wszelkie migracje i zmiany w strukturze bazy powinny być odzwierciedlane w tym pliku.

---


## DbSeeder.cs

**Opis:**  
Statyczna klasa pomocnicza służąca do inicjalizacji bazy danych przykładowymi danymi (seed). Umożliwia szybkie uruchomienie aplikacji z gotowymi kategoriami, pytaniami, opcjami odpowiedzi oraz przykładowymi użytkownikami.

**Funkcjonalność:**
- `SeedCategories(AppDbContext context)`  
  Dodaje domyślne kategorie quizów, jeśli nie istnieją w bazie (np. "geography", "actors/movies", "music", "math/physic", "fauna/flora", "general").
- `SeedQuestions(AppDbContext context)`  
  Dodaje przykładowe pytania do każdej kategorii wraz z opcjami odpowiedzi i indeksem poprawnej odpowiedzi. Tworzy powiązane encje `Question` i `QuestionOption`.
- `SeedUsers(AppDbContext context)`  
  Dodaje kilku przykładowych użytkowników, jeśli baza jest pusta.

**Szczegóły implementacji:**
- Kategorie, pytania i użytkownicy są dodawani tylko, jeśli nie istnieją już w bazie.
- Pytania są powiązane z kategoriami na podstawie nazwy.
- Każde pytanie otrzymuje zestaw opcji (`QuestionOption`) oraz indeks poprawnej odpowiedzi.
- Funkcje należy wywołać ręcznie (np. podczas startu aplikacji lub migracji bazy).

**Zastosowanie:**
- Ułatwia testowanie i prezentację aplikacji bez konieczności ręcznego wprowadzania danych.
- Może być używany w środowisku deweloperskim lub demo.

**Uwagi:**
- Klasa nie obsługuje usuwania ani aktualizacji istniejących danych.
- W przypadku zmian w modelach lub strukturze bazy należy zaktualizować również seeder.

---


## QuizState.cs

**Opis:**  
Klasa służąca do przechowywania bieżącego stanu rozgrywanego quizu w aplikacji Blazor. Umożliwia przekazywanie informacji o aktualnym quizie pomiędzy różnymi komponentami (np. QuizPage, QuizSummary).

**Funkcjonalność:**
- Przechowuje podstawowe dane dotyczące aktualnej sesji quizu:
  - `CategoryId` – identyfikator wybranej kategorii quizu
  - `Score` – liczba poprawnych odpowiedzi użytkownika
  - `TimeTakenSeconds` – czas rozwiązania quizu w sekundach
  - `TotalPoints` – łączna liczba zdobytych punktów (np. za poprawność i czas)
  - `Completed` – flaga informująca, czy quiz został ukończony

**Zastosowanie:**
- Wstrzykiwana jako serwis (`@inject QuizState State`) do komponentów, które muszą znać lub modyfikować stan quizu.
- Umożliwia łatwe przekazywanie wyniku i szczegółów quizu między stronami (np. z QuizPage do QuizSummary).

**Uwagi:**
- Klasa nie implementuje powiadamiania o zmianach stanu (brak eventów/INotifyPropertyChanged).
- Stan jest utrzymywany w pamięci na czas życia serwisu (zwykle `Scoped`).

---



