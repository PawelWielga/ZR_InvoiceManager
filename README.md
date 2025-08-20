# InvoiceManager

Aplikacja demonstracyjna do zarządzania klientami i fakturami. Projekt składa się z warstw, które współpracują ze sobą w celu obsługi danych i prezentacji interfejsu użytkownika.

## Struktura projektu
- **InvoiceManager** – aplikacja Windows Forms z interfejsem DevExpress.
  - `Data` – kontekst EF Core i repozytoria.
  - `Infrastructure` – klasy pomocnicze i konfiguracja DI.
  - `Models` – encje domenowe (klienci, faktury).
  - `Services` – logika biznesowa i usługi aplikacyjne.
  - `Utils` – narzędzia, m.in. eksport raportów.
  - `ViewModels` – modele widoków dla interfejsu.
  - `Views` – formularze i kontrolki.
- **InvoiceManager.Tests** – zestaw testów jednostkowych (NUnit/Moq).

## Wykorzystane narzędzia i biblioteki
Projekt bazuje na platformie **.NET 8.0** i wykorzystuje m.in.:
- **Windows Forms** i komponenty **DevExpress** do budowy interfejsu.
- **Entity Framework Core** z bazą **SQL Server** do dostępu do danych.
- **Microsoft.Extensions.DependencyInjection** do konfiguracji usług.
- **Bogus** do generowania danych przykładowych.

## Uruchomienie
1. Zainstaluj [.NET SDK](https://dotnet.microsoft.com/).
2. Przywróć i zbuduj rozwiązanie:
   ```bash
   dotnet build
   ```
3. Uruchom aplikację:
   ```bash
   dotnet run --project InvoiceManager
   ```
4. Testy jednostkowe można uruchomić poleceniem:
   ```bash
   dotnet test
   ```
