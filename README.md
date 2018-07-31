# CSharpAlapok201807
A NetAcademia "C# alapok 2018: a multiplatform C#" című tanfolyamának kódtára


## C#, .NET fogalmai

### Programnyelvek
A magas szinten megfolgalmazott feladataikat és megoldásaikat áttranszformáljuk olyan nyelvre, amit a processzor megért.

- Fordított (Basic, C, C++)
  A forráskódot egy fordító környezet átalakítja a processzor által fogyasztható, végrehajtható formába. Ezután történik a végrehajtás.
  Előny: optimalizáld kódot képes az adott processzorkörnyezetre készíteni.
  Hátrány: a lefordított kód csak egy adott környezeten képes futni.


- Értelmezett (JavasSript)
  A forráskódot közvetlenül értelmezi a futtatókörnyezet, majd (általában soronként) fordítja át végrehajtható formába. 
  Előny: ha van futattókörnyezete, akkor bárhol képes futni. (hordozható)
  Hátrány: nem optimalizált a kód


- Köztes nyelvet használó nyelvek
  Java (bytecode)
  Két lépés
  Forráskód -> bytecode -> futtatható gépi kód


```
+---------+
|         |
| C#      |
|         | +-------------------->
|         |                      |
+---------+                      |
                                 |
                                 |    +------------+
                                 |    |            |
+---------+                      +--> |Intermediate|               +-------------+                +-------------+
|         |                           |Language    |               | MSIL program|                | MSIL program|
| VB.NET  | +-----------------------> |            |               |             |                |             |
|         |                           |IL vagy     |               +-------------+                +-------------+
|         |                           |MSIL        |           +---------------------+         +--------------------+
+---------+                           |            |           | .NET keretrendszer  |         | .NET Framework     |
                                 ^--> |            |           |                     |         | (MONO)             |
                                 |    |            |           +---------------------+         +--------------------+
+---------+                      |    +------------+        +---------------------------+   +---------------------------+
|         |                      |                          |                           |   |                           |
| PHP     | +-------------------->                          |                           |   |                           |
|         |                                                 |     Windows               |   |  Linux                    |
|         |                                                 |                           |   |                           |
+---------+                                                 |                           |   |                           |
                                                            +---------------------------+   +---------------------------+

```


## .NET keretrendszer
### CLR (Common Language Runtime)
- futtatási környezet, az MSIL nyelvű programokat az adott környezetben futtatni tudja
- futás közben optimalizál
- memóriakezelésben levesz egy csomó problémát a programozó válláról
- a kódunk sandbox-ban fut, így sok biztonsági pproblémát a .NET keretrendszer kiszűr

### Osztálykönyvtár
- Az operációs rendszer funkcióinak egy egységes programozási felületet ad.
- Rengeteg előre megírt megoldást tartalmaz


## Alkalmazás futtatás modellje

Alkalmazás => folyamat (process) -> szálak (thread) -> verem (stack)

Az alkalmazás futtatásához az operációs rendszer egy folyamatot indít (process)
A programozási alapegység a szál, egy szálon történő lépéseket programozunk általában.

## Az alkamazás által használt memóriák
- HEAP (halom)
- STACK (verem)

## Változótípusok
- értéktípus
- referenciatípus


```
+-----------------------------------------+              +-----------------------------------------------+
|                                         |              |                                               |
|   +----------+        +----------+      |              |        +------------------+                   |
|   |          |        |          |      |              |        |                  |                   |
|   | ertek1   |        | ertek2   |      |              |        | referencia1      |   <---+           |
|   |          |        |          |      |              |        |                  |       |           |
|   +----------+        +----------+      |              |        +------------------+       |           |
|                                         |              |                                   |           |
|      ^                     ^            |              |            ^                      |           |
|      |                     |            |              |            |                      |           |
|      |                     |            |              |            |                      |           |
|      |                     |            |              |            |                      |           |
|      |                     |            |              |            |                      |           |
|      |                     |            |              |            |                      |           |
|      |                     |            |              |            |                      |           |
|      |                     |            |              |            |                      |           |
|      |                     |            |              |            |                      |           |
|      |                     |            |              |            |                      |           |
|      |                     |            |              |            |                      |           |
+-----------------------------------------+              +-----------------------------------------------+
       +                     +                                        +                      +

    ertek1                ertek2                                 referencia1            referencia2

```
 
Saját értéktípuson (struct) belüli referenciatípus viselkedése

```
                SajatErtek
               +---------------------+
               |                     |
               |    ertek=10         |
               |                     |
sajatertek1    |                     |
               |    referencia +-------------------------+          SajatReferencia
   +           |                     |                   |        +------------------------------+
   |           |                     |                   |        |                              |
   +-------->  |                     |                   |        |                              |
               |                     |                   |        |   ertek=10                   |
               +---------------------+                   |        |                              |
                                                         <----->  |                              |
                SajatErtek                               |        |                              |
               +---------------------+                   |        |                              |
               |                     |                   |        |                              |
               |    ertek=10         |                   |        |                              |
               |                     |                   |        |                              |
sajatertek2    |                     |                   |        +------------------------------+
   +           |    referencia +-------------------------+
   |           |                     |
   +-------->  |                     |
               |                     |
               |                     |
               +---------------------+

                                    var sajatertek2 = sajatertek1;

```

### Példa
Gondolatkísérlet: Egy webkamera képét szeretnénk megjeleníteni egy ablakban. A kamerakép mozgókép, ez azt jelenti, 
hogy mondjuk 20 fps (másodpercenként 20 képkocka) sebességgel el kell kérni az aktuális képet (mondjuk bitmap) a kamerától,
és meg kell jelenítenünk a képernyőn. Utána nincs szükség erre a képre, tehát ez csak egy átmeneti tárolás.

Mi történik, ha
- referenciatípusként
- értéktípusként gondolunk a képre?

#### Referenciatípus esetén
nem jön létre új példány, a kamerától elkért referenciát a képrenyő kiolvassa és kész.

#### Értéktípus esetén
minden egyes alkalommal létrejön egy új példány. (HD kép esetény 1024x768x8 a mérete a tárterületnek, 
másodpercenkén 20x, ez 786432x20 byte másodpercenként, ami 15.728.640 byte/sec ami kb 15GB/sec).

Ez azt jelenti, hogy nagyon komoly memória karbantartó infrastruktúrát kell kiépítenem, 
vagy néhány másodpercen belül lefagy a gépem.

#### Előnyök/hátrányok
- a referenciatípus
  - spórol a memóriával
  - viszont többszörös hivatkozás esetén vigyázni kell, mert egyik hivatkozás átirhatja az összes többi
    hivatkozás által nyilvántartott értékekeket.
- az értéktípus
  - nem okoz "áthallást", minden változó önmagáért felel
  - viszont a túlzott használata teljesétmény és memóriakérdéseket vet föl


## Tennivalók, telepítendők
- [Linux subsystem for Windows](https://docs.microsoft.com/en-us/windows/wsl/install-win10)
	
- [Docker for Windows használata](https://www.docker.com/docker-windows)



## 1. Házi feladat
- karakterekből álló tömb viselkedését kipróbálni 

	```csharp
	var szoveg = new char[] {'1', '0' };
	```

- értéktípuson (struct) belüli értéktípus (struct) mező viselkedését kipróbálni

