# MTGHelper
<h2>Spis treści</h2
<p style="font-weight:bold">Opis</p>
<p style="font-weight:bold">Wymagania systemowe</p>
<p style="font-weight:bold">Instalacja</p>
<p style="font-weight:bold">Uruchamianie na emulatorze Androida</p>
<p style="font-weight:bold">Funkcje</p>
<p style="font-weight:bold">Struktura projektu</p>
<p style="font-weight:bold">Wzorzec projektowy MVVM</p>
<p style="font-weight:bold">Technologia MAUI .NET 7</p>
<br/>
<h2>Opis</h2>
Aplikacja Magic: The Gathering Helper została stworzona w celu ułatwienia graczy w zarządzaniu kartami i życiem podczas gry w Magic: The Gathering. Aplikacja wykorzystuje wzorzec projektowy MVVM (Model-View-ViewModel) do oddzielenia warstwy prezentacji od logiki biznesowej, co czyni ją bardziej skalowalną i łatwą do utrzymania. Aplikacja została napisana w technologii MAUI .NET 7, co oznacza, że jest wieloplatformowa i działa na różnych systemach operacyjnych.

<h2Wymagania systemowe</h2>
<p>Przed rozpoczęciem korzystania z aplikacji na emulatorze Androida upewnij się, że spełniasz następujące wymagania systemowe:</p>

<p>System operacyjny: Windows 10, macOS, Linux
.NET SDK 7.0 lub nowszy</p>
<p>MAUI .NET 7 SDK</p>
<p>Android Emulator (zainstalowany i skonfigurowany)</p>
<h2>Instalacja</h2>
Aby zainstalować aplikację Magic: The Gathering Helper, wykonaj następujące kroki:

<p>Sklonuj repozytorium z kodem źródłowym:</p>

Skopiuj kod:
git clone https://github.com/twoj-repozytorium/mtg-companion.git
Przejdź do katalogu projektu:

Skopiuj kod:
```
cd mtg-companion
```
<p>Zbuduj i zainstaluj aplikację za pomocą .NET CLI:</p>

<p>Skopiuj kod:</p>

```
dotnet build
```

```
dotnet install
```
<p>Uruchamianie na emulatorze Androida</p>
<p>Aby uruchomić aplikację na emulatorze Androida, wykonaj następujące kroki:</p>

<p>Upewnij się, że masz zainstalowany emulator Androida i jesteś w stanie go uruchomić.</p>

Otwórz terminal i przejdź do katalogu projektu:

Skopiuj kod:
```
cd MTGHelper
```
<p>Uruchom aplikację na emulatorze Androida za pomocą następującego polecenia:</p>

Skopiuj kod:
```
dotnet maui android -e
```
<p>Aplikacja zostanie zbudowana i uruchomi się na emulatorze Androida.</p>

<h2>Funkcje</h2>
<p>Aplikacja Magic: The Gathering Helper oferuje szereg przydatnych funkcji, w tym:</p>
<ul>
  <li>Odliczanie życia poszczególnych graczy.</li>
  <li>Losowanie pierwszego gracza.</li>
  <li>Symulacja rzutu różnymi typami kości w różnej ilość np. 2xd6, 4xd12,1xd20.</li>
  <li>Konfiguracja ilości graczy, ich kolorów, zmiana ilości życia, personalizacja widoczności elementów gry.</li>
  <li>Wyszukiwanie wszystkich dostępnych rozszerzeń z gry Magic The Gathering.</li>
  <li>Wyszukiwanie kart z wybranego rozszerzenia.</li>
</ul>
<h2>Struktura projektu</h2>
<p>Struktura projektu jest oparta na wzorcu MVVM i zawiera następujące główne katalogi:</p>
<ul>
  <li>Models: Klasyczne modele danych.</li>
  <li>ViewModels: Klasy ViewModel, które zarządzają danymi i logiką biznesową.</li>
  <li>Pages: Interfejsy użytkownika, pliki XAML.</li>
  <li>Helpers: Pomocnicze klasy i narzędzia.</li>
  <li>Resources: Zasoby, takie jak obrazy i ikony.</li>
  <li>Controls: Utworzone kontrolki na potrzeby aplikacji.</li>
  <li>Platforms: Konfiguracje dla poszczególnych platform w MAUI.</li>
</ul>
<h2>Wzorzec projektowy MVVM</h2>
<p>Aplikacja Magic: The Gathering Helper wykorzystuje wzorzec projektowy MVVM, co oznacza, że ​​oddziela warstwę prezentacji od logiki biznesowej. Model reprezentuje dane, ViewModel obsługuje logikę biznesową, a View jest odpowiedzialne za interfejs użytkownika. To podejście ułatwia testowanie, skalowanie i utrzymanie aplikacji.</p>

<h2>Technologia MAUI .NET 7</h2>
<p>Aplikacja została napisana w technologii MAUI .NET 7, co oznacza, że ​​jest wieloplatformowa i może działać na różnych systemach operacyjnych, takich jak Windows, macOS i Linux. MAUI .NET 7 umożliwia tworzenie natywnych aplikacji przy użyciu jednego zestawu kodu źródłowego.</p>
