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

Az alkalmazéás futtatásához az operációs rendszer egy folyamatot indít (process)
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
  