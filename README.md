# Rekrutacja

1.	Coin magnet – po wykryciu gracza w pobliżu monety lecą w jego kierunku. Opcje da się włączyć za pomocą boola w komponencie Coin:

2.	Waza:
-do obsługi menu: po rozbiciu zmienia scenę
-do spawnowania monet: po rozbiciu tworzy randomową liczbę monet od 1 do maksymalnej ustawionej wartości
-jej funkcjonalność wybiera się za pomocą boola w komponencie Vase:

3.	Różne rodzaje patrolowania terenu przez wrogów:
-From Edge to Edge: przeciwnik patroluje teren dopóki ma po czym chodzić.
-From point to point: możliwość ustawienia punktów patrolowania. Jeśli chcemy aby przeciwnik po drodze wskakiwał na platformy to trzeba mu ustawić specjalny OverPoint (prefab), w którym ustawiamy triggery skoku.
-Rotation patrol: wróg stoi w miejscu i się rozgląda.
-Gdy nie ma wybranego żadnego patrolu przeciwnik po prostu stoi w miejscu
 
4.	Audio manager
Po odniesieniu do niego i wywołaniu metody Play(„nazwa utworu”) grany jest dany dźwięk. 
 
5.	Paski życia przeciwników
Po otrzymaniu 1 hita nad przeciwnikiem pojawia się pasek informujący o pozostałym jego życiu.
 
6.	Panel pauzy/przegranej

7.	Prosty system zapisu monet i życia gracza przy przełączaniu pomiędzy scenami oparty na Scriptable Object.
