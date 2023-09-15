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
cd mtg-companion
Zbuduj i zainstaluj aplikację za pomocą .NET CLI:

Skopiuj kod:
dotnet build
dotnet install
Uruchamianie na emulatorze Androida
Aby uruchomić aplikację na emulatorze Androida, wykonaj następujące kroki:

Upewnij się, że masz zainstalowany emulator Androida i jesteś w stanie go uruchomić.

Otwórz terminal i przejdź do katalogu projektu:

Skopiuj kod:
cd mtg-companion
Uruchom aplikację na emulatorze Androida za pomocą następującego polecenia:

Skopiuj kod:
dotnet maui android -e
Aplikacja zostanie zbudowana i uruchomi się na emulatorze Androida.

Funkcje
Aplikacja Magic: The Gathering Helper oferuje szereg przydatnych funkcji, w tym:

Odliczanie życia poszczególnych graczy.
Losowanie pierwszego gracza.
Symulacja rzutu różnymi typami kości w różnej ilość np. 2xd6, 4xd12,1xd20.
Konfiguracja ilości graczy, ich kolorów, zmiana ilości życia, personalizacja widoczności elementów gry.
Wyszukiwanie wszystkich dostępnych rozszerzeń z gry Magic The Gathering.
Wyszukiwanie kart z wybranego rozszerzenia.
Struktura projektu
Struktura projektu jest oparta na wzorcu MVVM i zawiera następujące główne katalogi:

Models: Klasyczne modele danych.
ViewModels: Klasy ViewModel, które zarządzają danymi i logiką biznesową.
Pages: Interfejsy użytkownika, pliki XAML.
Helpers: Pomocnicze klasy i narzędzia.
Resources: Zasoby, takie jak obrazy i ikony.
Controls: Utworzone kontrolki na potrzeby aplikacji.
Platforms: Konfiguracje dla poszczególnych platform w MAUI.
Wzorzec projektowy MVVM
Aplikacja Magic: The Gathering Helper wykorzystuje wzorzec projektowy MVVM, co oznacza, że ​​oddziela warstwę prezentacji od logiki biznesowej. Model reprezentuje dane, ViewModel obsługuje logikę biznesową, a View jest odpowiedzialne za interfejs użytkownika. To podejście ułatwia testowanie, skalowanie i utrzymanie aplikacji.

Technologia MAUI .NET 7
Aplikacja została napisana w technologii MAUI .NET 7, co oznacza, że ​​jest wieloplatformowa i może działać na różnych systemach operacyjnych, takich jak Windows, macOS i Linux. MAUI .NET 7 umożliwia tworzenie natywnych aplikacji przy użyciu jednego zestawu kodu źródłowego.
