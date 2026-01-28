## Aplikacja

Na potrzeby pracy stworzona została gra, która odwołuje się do klasycznej formuły znanej z pierwszych edycji "Super Mario" stworzonych przez firmę Nintendo. Zaprojektowana została dwuwymiarowa gra z wykorzystaniem silnika Unity. Umożliwia rozgrywkę na telefonach z systemem Android. Natomiast swoim stylem nawiązuje do retro-charakteru pierwszych wersji owej gry. Zadaniem gracza jest pokonywanie trudności, napotykanych w trakcie swojej podróży przez siedem poziomów, podążając przez różne krainy. System gry narzuca graczowi obowiązek przemierzania poziomu, poruszając się z lewej strony ekranu na prawą. Ta dynamiczna podróż wymaga od gracza nie tylko sprytu i refleksu, ale w niektórych sytuacjach również nieszablonowego myślenia. 

Opis poszczególnych funkcjonalności:

1. ### 'BlackHole'
  Pola grawitacyjne są obszarami, które w grze wizualnie przypominają czarne dziury obracające się wokół własnej osi i wywołujące silne siły grawitacyjne. Te obszary tworzą efekt wizualny i mechaniczny, który sprawia, że obiekty w grze zachowują się, jakby były przyciągane do środkowego punktu czarnej dziury.

2. ### 'BulletBehavior'
  Zachowywanie się (tworzenie, przemieszanie się, usuwanie) wystrzelowych kul przez przeciwników.
  
3. ### 'CameraController'
  Opisuje sposób działania głównej kamery podczas rozgrywki.
  
4. ### 'EnemyFollower' / 'FallingHead'
  Sposób funkcjonowania przeciwników.
  
5. ### 'Gravity'
	Na ostatnim poziomie gracz będzie miał również do czynienia z mechaniką obrócenia grawitacji. Obiekt zmieniający grawitację, który wyglądem przypomina wystrzeliwane kulki, został utworzony za pomocą Particle System. 

6. ### 'ItemCollector'
  Każda truskawka posiada ustawiony collider za pomocą użycia właściwości w komponencie Box Collider 2D oraz ustawiony wcześniej przygotowany tag obiektu, w tym przypadku o nazwie „Strawberry”. Po wykryciu kolizji gracza z obszarem obiektu oznaczonym kolizją przypominającym truskawkę, następuje wywołanie metody o nazwie OnTriggerEnter2D(Collider2D collision), która za argument przyjmuje informacje o obiekcie, który naruszył obszar kolizji.  Natomiast w samej metodzie następuje dodanie jednej truskawki do aktualnego stanu oraz zmieniany jest napis znajdujący w interfejsie rozgrywki.

7. ### 'PlayerData'
  Pobierane są dane, wymagające zapisu tj. ilość truskawek, poziom głośności muzyki oraz aktualny poziom rozgrywki. Ilość truskawek oraz aktualny poziom zapisane są podczas przejścia poziomu, natomiast głośność muzyki podczas zmiany w pasku intensywności muzyki. Dane przechowywane są w wcześniej przygotowanej klasie, podczas potrzeby zapisu, dane są serializowane za pomocą BinaryFormattera. Dzięki tej technice dane są nieczytelne dla człowieka, co pozwala uniknąć ingerencji oszustów w plik z zapisem stanu rozgrywki w celu ułatwienie sobie rozgrywki. 

## Instalacja i uruchomienie

Do przetestowania gry należy zainstalować Unity. Sama gra została napisana w wersji edytora o nazwie 2021.3.24f1 wydanego 8 marca 2022 roku posiadającego długoterminowe wsparcie. Przetestowanie gry możliwe jest na dwa sposoby:
  - przetestowanie gry w symulatorze Unity, za pomocą wybrania sceny startowej z katalogu „Scenes”, a następnie uruchomienie symulatora przyciskiem startu znajdującym się w górnej części programu,
  - zainstalowanie gry na prywatny telefon z systemem Android.

Aby umożliwić instalację gry na telefonie należy postępować zgodnie z poniższymi instrukcjami:
  1. Podłączenie telefonu za pomocą kabla USB do komputera.
  2. Wybranie w lewym górnym rogu opcji File, a następnie Build Settings. Bądź wciśnięcie skrótu klawiszowego CTRL + SHIFT + B.
  3. Wybranie platformy Andorid (jeżeli nie jest zainstalowana, zainstalować).
  4. Wciśnięcie przycisku Build and Run znajdujący się w prawym dolnym rogu okienka.
  5. Wybranie i potwierdzenie miejsca, w którym zbudować ma się aplikacja na komputerze.
  6. Potwierdzenie instalacji aplikacji za pomocą USB na telefonie.
  7. Testowanie gry.
