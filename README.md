# BotOfScreenShots short documentation

Aplikacja BotOfScreenShots umożliwia autonomizację czynność zaprogramowanych przez użytkownika.
Środowisko, w którym powstała aplikacja to IDE Visual Studio 2019 wersja 16.8.3, .NET Framework 3.8.04084, WinForms(Framework).

#Opis działania

Przy pierwszym włączeniu, wygenerowany zostanie nowy profil. Profile służą do przechowywania własnych konfiguracji działań do różnych potrzeb, istnieje również możliwość tworzenia, usuwania oraz zmieniania ich nazwy. Z profilem ściśle powiązane są pliki przechowywane w folderze '.\Files\<Nazwa_Profilu>', znajdują się tam zdjęcia w formacie '.png', które wykorzystywane są podczas wykonywania kodu. Każdy utworzony profil zostaje wyposażony w unikatowe ID na skale całej aplikacji. Koljenym powiązanym elementem jest kod C# zaprojektowany przez użytkownika w celu zautonomizowania czynności. Jeżeli mowa o kodzie C# potrzebne są również biblioteki, które są dołączane w liście po prawej stronie UI - dzięki nim można zwiększyć zakres działań apliakcji. Ostatnim wyróżniającym się elementem jest obszar roboczy, który można wyznaczyć własnoręcznie klikając na przycisk 'Work area', na podobnej zasadzie działa wykonywanie zrzutów ekranu, które zapisują się we wcześniej wspomnianym folderze należącym do profilu.

#Przykład

W folderze z plikiem wykonywalnym '.exe' generowany jest plik z zapisami profili - 'Profiles.xml' oraz folder z plikami do profili - 'Files'. W przypadku ręcznego wgrywania danych należy umieścij je w tym miejscu, aby zostały zczytane przez program. Przykładowy profil znaduje się w folderze 'Samples' na GitHub'ie.

#Kodowanie

W aplikacji w obszarze kodowania obowiązuje nomenklatura języka C#, dostępne są również nastepujące właściwości oraz metody:

*SimilarImage.SimilarityPercent*

- wartość procentowa (od 0 do 100) podobieństwa wyszukiwanego zdjęcia na obszarze roboczym

*MouseClick()*

- metoda wywołująca event kliknięcia lewego przycisku myszy w punkcie, w którym się znajduje

*SameImage.Find(Bitmap toFind)* oraz *SameImage.Find(Bitmap toFind, Rectangle newWorkArea)*

- metoda wyszukująca wskazanego zdjęcia w argumencie 'toFind' na obszarze roboczym, może zostać przeciążana ze wskazaniem nowego obszaru roboczego

*SimilarImage.Find(Bitmap toFind)* oraz *SimilarImage.Find(Bitmap toFind, Rectangle newWorkArea)*

- metoda wyszukująca wskazanego podobnego zdjęcia w argumencie 'toFind' na obszarze roboczym, przy czym stopień podobieństwa jest określony przez statyczną wartość *SimilarImage.SimilarityPercent*, może zostać przeciążana ze wskazaniem nowego obszaru roboczego

#Algorytmy

https://github.com/wiQ1999/ImageSearchAlgorithm/blob/master/Analiza-Przeszukiwanie_obrazu.pdf
