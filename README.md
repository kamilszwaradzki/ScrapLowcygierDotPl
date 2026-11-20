
# ScrapLowcygierDotPl
 
Mała aplikacja desktopowa w C# (WPF), która pobiera z [lowcygier.pl/darmowe](https://lowcygier.pl/darmowe/) listę gier aktualnie dostępnych za darmo na PC i wyświetla je jako przyciski. Kliknięcie otwiera stronę oferty w domyślnej przeglądarce.
 
Projekt hobbystyczny z 2021 roku, napisany jako pierwsze podejście do .NET i web scrapingu.
 
![Lista gier](https://i.imgur.com/Lpq0qlS.png)
 
## Funkcjonalności
 
- Pobranie strony z darmowymi grami i wyciągnięcie tytułów oraz linków (selektory CSS)
- Filtrowanie: wyświetlane są tylko oferty oznaczone jako PC
- Każda gra to przycisk w oknie; kliknięcie otwiera ofertę w przeglądarce
## Technologie
 
- C#, .NET Core 3.1
- WPF
- [HtmlAgilityPack](https://html-agility-pack.net/): pobieranie i parsowanie HTML
- [ScrapySharp](https://github.com/rflechner/ScrapySharp): selektory CSS na drzewie HtmlAgilityPack
## Uruchomienie
 
Wymagania: **Windows** (WPF działa tylko na Windows) oraz .NET Core 3.1 SDK albo nowszy SDK z ustawionym roll-forward.
 
```bash
git clone https://github.com/kamilszwaradzki/ScrapLowcygierDotPl.git
cd ScrapLowcygierDotPl
dotnet restore
dotnet run --project WpfApp1
```
 
Albo otwórz `WpfApp1.sln` w Visual Studio i uruchom projekt.
 
## Ograniczenia
 
- Strona jest pobierana synchronicznie w konstruktorze okna, więc przy wolnym łączu okno startuje z opóźnieniem.
- Przyciski są tworzone w code-behind (bez MVVM i bindingu).
- Scraper zależy od struktury HTML lowcygier.pl; zmiana szablonu strony go zepsuje.
- .NET Core 3.1 nie jest już wspierany.
## Możliwe usprawnienia
 
- [ ] Migracja na .NET 10
- [ ] Pobieranie asynchroniczne (`HttpClient` + `async/await`), żeby nie blokować UI
- [ ] Wzorzec MVVM: `ObservableCollection` + `ItemsControl` z bindingiem
- [ ] Obsługa błędów sieci i pustej listy
- [ ] Usunięcie nieużywanej zależności `CsvHelper`
 
