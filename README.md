Opis Projektu
CarMechanic to aplikacja desktopowa stworzona w technologii WPF (Windows Presentation Foundation) z wykorzystaniem Entity Framework Core do zarządzania bazą danych SQLite. Aplikacja pozwala na zarządzanie użytkownikami, samochodami, naprawami oraz częściami. Główne funkcje aplikacji obejmują dodawanie, edytowanie, usuwanie i przeglądanie danych.

Technologie
C#
WPF (Windows Presentation Foundation)
Entity Framework Core
SQLite
Uruchomienie Projektu
Wymagania wstępne:

Visual Studio 2019 lub nowszy
.NET Core SDK
SQLite
Klonowanie Repozytorium:
Skopiuj repozytorium na swój lokalny komputer:

git clone https://github.com/TwojeRepozytorium/CarMechanic.git

Otwórz Projekt w Visual Studio:
Otwórz plik rozwiązania CarMechanic.sln w Visual Studio.

Przywrócenie Pakietów NuGet:
Visual Studio automatycznie przywróci wszystkie pakiety NuGet po otwarciu projektu. W razie potrzeby możesz ręcznie przywrócić pakiety:

dotnet restore
Migracje bazy danych:
Jeśli projekt nie zawiera zaktualizowanej bazy danych, wykonaj migracje:

dotnet ef migrations add InitialCreate
dotnet ef database update

Uruchomienie aplikacji:
Uruchom aplikację, naciskając klawisz F5 lub klikając Start w Visual Studio.

Opis Głównych Funkcji

1. Zarządzanie Użytkownikami
Dodawanie Użytkownika: Pozwala na dodanie nowego użytkownika do systemu poprzez formularz.
Edytowanie Użytkownika: Umożliwia edycję istniejącego użytkownika.
Usuwanie Użytkownika: Usuwa wybranego użytkownika z systemu.
Przeglądanie Szczegółów Użytkownika: Wyświetla szczegółowe informacje o wybranym użytkowniku.

2. Zarządzanie Samochodami
Dodawanie Samochodu: Pozwala na dodanie nowego samochodu do systemu poprzez formularz.
Edytowanie Samochodu: Umożliwia edycję istniejącego samochodu.
Usuwanie Samochodu: Usuwa wybrany samochód z systemu.
Przeglądanie Szczegółów Samochodu: Wyświetla szczegółowe informacje o wybranym samochodzi

3. Zarządzanie Naprawami
Dodawanie Naprawy: Pozwala na dodanie nowej naprawy do systemu poprzez formularz.
Edytowanie Naprawy: Umożliwia edycję istniejącej naprawy.
Usuwanie Naprawy: Usuwa wybraną naprawę z systemu.
Przeglądanie Szczegółów Naprawy: Wyświetla szczegółowe informacje o wybranej naprawie.

4. Zarządzanie Częściami
Dodawanie Części: Pozwala na dodanie nowej części do systemu poprzez formularz.
Edytowanie Części: Umożliwia edycję istniejącej części.
Usuwanie Części: Usuwa wybraną część z systemu.
Przeglądanie Szczegółów Części: Wyświetla szczegółowe informacje o wybranej części.

Struktura Projektu

CarMechanic: Główna przestrzeń nazw zawierająca logikę aplikacji.
CarMechanic.Data: Zawiera kontekst bazy danych oraz konfiguracje modeli Entity Framework Core.
CarMechanic.Models: Definiuje modele danych, takie jak User, Car, Repair, Part.
CarMechanic.UserForm: Formularze i okna dialogowe związane z użytkownikami.
CarMechanic.CarForm: Formularze i okna dialogowe związane z samochodami.
CarMechanic.RepairForm: Formularze i okna dialogowe związane z naprawami.
CarMechanic.PartForm: Formularze i okna dialogowe związane z częściami.
