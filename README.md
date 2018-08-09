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

## Feladatok
- [X] Ubuntu linux telepítés véglegesítése
  elindítjuk a konzolt, megkérdezi a super user nevét és jelszavát, majd elvégzi a szükséges beállításokat.
  ```shell
    Installing, this may take a few minutes...
    Please create a default UNIX user account. The username does not need to match your Windows username.
    For more information visit: https://aka.ms/wslusers
    Enter new UNIX username: gplesz
    Enter new UNIX password:
    Retype new UNIX password:
    passwd: password updated successfully
    Installation successful!
    To run a command as administrator (user "root"), use "sudo <command>".
    See "man sudo_root" for details.
  ```
  lekérdezzük az ubuntu verziószámát, 
  ```shell
    gplesz@windows10:~$ lsb_release -a
    No LSB modules are available.
    Distributor ID: Ubuntu
    Description:    Ubuntu 18.04 LTS
    Release:        18.04
    Codename:       bionic
  ```

  ellenőrizzük git meglétét, létrehozunk egy könyvtárat, majd lemásoljuk a kódtárunkat az ubuntu rendszerbe:
  ```shell
    gplesz@windows10:~$ git --version
    git version 2.17.0
    gplesz@windows10:~$ mkdir repos
    gplesz@windows10:~$ cd repos/
    gplesz@windows10:~/repos$ git clone https://github.com/gplesz/CSharpAlapok201807.git
    Cloning into 'CSharpAlapok201807'...
    remote: Counting objects: 65, done.
    remote: Compressing objects: 100% (44/44), done.
    remote: Total 65 (delta 20), reused 55 (delta 14), pack-reused 0
    Unpacking objects: 100% (65/65), done.
    gplesz@windows10:~/repos$
  ```

- [X] DotNet telepítése [innen](https://www.microsoft.com/net/learn/get-started-with-dotnet-tutorial)
  A következő négy parancsot kell kiadni a .NET környezet telepítéséhez Ubuntu-n:

  két paranccsal telepítjük a szükséges kulcsot (egy gépen csak egyszer kell ezt elvégezni)
  ```
    wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
  ```
  
  lefuttatjuk a csomagok frissítését az Ubuntu-n, mielőtt telepítjük a dotnet SDK-t:
  ```
    sudo apt-get install apt-transport-https
    sudo apt-get update
  ```

  majd ezzel telepítjük végül a dotnet sdk-t:
  ```
    sudo apt-get install dotnet-sdk-2.1
  ```


  végükl a **dotnet --info** paranccsal ellenőrizzük a dotnet sdk meglétét:
  ```
    gplesz@windows10:~/repos$ dotnet --info
    .NET Core SDK (reflecting any global.json):
     Version:   2.1.302
     Commit:    9048955601

    Runtime Environment:
     OS Name:     ubuntu
     OS Version:  18.04
     OS Platform: Linux
     RID:         ubuntu.18.04-x64
     Base Path:   /usr/share/dotnet/sdk/2.1.302/

    Host (useful for support):
      Version: 2.1.2
      Commit:  811c3ce6c0

    .NET Core SDKs installed:
      2.1.302 [/usr/share/dotnet/sdk]

    .NET Core runtimes installed:
      Microsoft.AspNetCore.All 2.1.2 [/usr/share/dotnet/shared/Microsoft.AspNetCore.All]
      Microsoft.AspNetCore.App 2.1.2 [/usr/share/dotnet/shared/Microsoft.AspNetCore.App]
      Microsoft.NETCore.App 2.1.2 [/usr/share/dotnet/shared/Microsoft.NETCore.App]

    To install additional .NET Core runtimes or SDKs:
      https://aka.ms/dotnet-download
  ```

## a .NET keretrendszer rövid története
- a teljes (full) .NET framework CSAK windows-on fut
- az erre épülő ASP.NET keretrendszer csak windows-on fut (és csak IIS szervert képes használni)

ezért az ASP.NET fejlesztői a teljes újraírás mellett döntöttek
- elindult az ASP.NET Core fejlesztése az alapoktól azzal céllal, hogy Linux-on is képes legyen működni
- mivel ez nem lehetséges a teljes .NET-tel, így elindult a .NET újraírása is .NET Core néven

A Microsoft tanácsa a következő:
- ha új fejlesztésbe kezd az ember, és NEM desktop, akkor használjon .NET Core/ASP.NET Core környezetet, mert ez már alkalmas produkciós fejlesztésre
- ha meglévő fejlesztése van, vagy speciális Windows fejlesztésről van szó, vagy Desktop fejlesztésről, vagy olyan nuget csomagot kell felhasználnunk, aminek nincs .NET Core támogatása, akkor használjunk teljes .NET-et
- ha desktop multiplatformot akarunk, akkor érdemes elgondolkodni a Xamarin környezeten, wagy valamilyen kliens oldali webes környezeten (ionic, angular, react, stb.)



## Feladatok
- [X] Az előző alkalom kódjának futtatása Ubuntu-n
  - [X] mivel az a kód .NET Framework (teljes környezet) környezetre készült, ezért nem fut linuxon
  - [X] készítünk egy .NET Core (multiplatform környezet) alkalmazást, amibe átmásoljuk a teljes kódot
  - [X] commit+push segítségével felküldjük a GitHub kódtárba
  - [X] (Clone és) pull segítségével letöltjük az ubuntura
  - [X] **dotnet run** paranccsal futtatjuk:

```
                                                                     GitHub
                                                           +--------------------------------------------+
                                                           |                                            |
                                                           |                                            |
                              +------------------------->  |                                            |
                              |                            |                                            |
                              |                            |                                            |
                              |   1. Commit                |                                            |
                              |   2. Push                  +------------------------------------------+-+
                              |                                                                       |
                              |                                                                       | 1. Clone (lemásoltuk
     Számítógép (Local)       |                                                                       | a teljes kódtárat)
+---------------------------------------------------------------------------------------------------------------------------+
|                             +                                                                       |                     |
|                                                                                                     | 2. Pull (a          |
|                Kódtár (repository)                                                                  | legfrissebb kód     |
|               +----------------------+                                                              v letöltése)          |
|               |                      |                                                 Ubuntu                             |
|               |                      |                                               +--------------------------+         |
|               |                      |                                               |                          |         |
|               |                      |                                               |                          |         |
|               |                      |                                               |                          |         |
|               |                      |                                               |                          |         |
|               +----------------------+                                               |                          |         |
|                                                                                      |                          |         |
|                                                                                      |                          |         |
|                                                                                      |                          |         |
|                                                                                      +--------------------------+         |
|                                                                                                                           |
+---------------------------------------------------------------------------------------------------------------------------+
```

```shell
    gplesz@windows10:~/repos/CSharpAlapok201807/01Nap$ cd ../02Nap/
    gplesz@windows10:~/repos/CSharpAlapok201807/02Nap$ ls
    01ValtozokCore
    gplesz@windows10:~/repos/CSharpAlapok201807/02Nap$ cd 01ValtozokCore/
    gplesz@windows10:~/repos/CSharpAlapok201807/02Nap/01ValtozokCore$ dotnet run
    ertek1: 10, ertek2: 10
    ertek1: 20, ertek2: 10
    referencia1.ertek: 10, referencia2.ertek: 10
    referencia1.ertek: 20, referencia2.ertek: 20
    tomb1: 10, tomb2: 10
    tomb1: 20, tomb2: 20
    szoveg1: 10, szoveg2: 10
    szoveg1: 20, szoveg2: 10
    sajatertek1.ertek: 10, sajatertek2.ertek: 10
    sajatertek1.referencia.ertek: 10, sajatertek2.referencia.ertek: 10
    sajatertek1.ertek: 20, sajatertek2.ertek: 10
    sajatertek1.referencia.ertek: 20, sajatertek2.referencia.ertek: 20
```

## Feladatok
- [X] olyan alkalmazás készítése, ahol különböző síkidomok területét ki tudjuk számolni
  - [X] négyzet
  - [X] háromszög
  - [X] kör
- [X] olyan algoritmus kidolgozása, ami a különböző síkidomok területeit képes összeadni
  - [X] hogy lehet a kör területét (*double* típus egyformán kezelni az *int* típusokkal)? két lehetőség
    - "lebutítjuk" a kör területét *int*-re, 
    - "felokosítjuk" a többit *double*-ra
- [X] érmefeldobás osztály segítségével szimulálni az érmék feldobását
- [X] hamis érmét gyártani, ami mindig csak fejre esik.

Ha a leszármaztatott osztályt az ősosztály felületén keresztül szólítom, a hívás nem fog elmenni
a leszármaztatott osztályig, a C# (leszármaztatási) osztályhierarhia nem "hamisítható".

```
                  +------------------------------+                                 +--------------------------+               +
                  | FakeCoin                     |                                 | Coin                     |               |
+                 +------------------------------+                                 +--------------------------+               |
|                 |                              |                                 |                          |               |
|                 |                              |                                 |                          |               |
|                 |                              | +---------------------------->  |                          |               |
|                 |                              |                                 |                          |               |
|                 |                              |                                 |                          |               |
|                 +-----------+                  |                                 |                          |               |
+------------->   | Collect() | +------------------------------------------------> |  Collect()               |  <------------++
                  +-----------+ <------------------------------------------------+ |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  | new Collect()                |                                 |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  |                              |                                 |                          |
                  +------------------------------+                                 +--------------------------+

```


Ahhoz, hogy hamísítani lehessen, az ősosztályban a felülírható dolgokat **virtual** kulcsszóval kell ellátni.

```
+------------------------------+                                 +--------------------------+               +
| FakeCoin                     |                                 | Coin                     |               |
+------------------------------+                                 +--------------------------+               |
|                              |                                 |                          |               |
|                              |                                 |                          |               |
|                              |                                 |                          |               |
|                              |                                 |                          |               |
|                              |                                 |                          |               |
|                              |                                 |                          |               |
| override Collect()           |  <--------------------------+   | virtual Collect()        |  <------------++
|                              |                                 |                          |
|                              |  +-------------------------->   |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
|                              |                                 |                          |
+------------------------------+                                 +--------------------------+
```


## 2. Házi feladat
- "felokosítani" minden Area() függvényt *double* visszadott értékre
- a területszámítást ne felülettel, hanem ősosztállyal oldjuk meg

A függvényhíváskori implizit típuskonverzió:
```
   var coin = new FakeCoin();   DoCollects(coin);
             +                       +
             |                       |
             |                       |
             v                       v

+-----------------------------+------------+
|                             |            |
| FakeCoin                    | Coin       |
|                             |            |
|                             |            |
|                             |            |
|                             |            |
|                             |            |
|                             |            |
|                             |            |
|                             |            |
|                             +------------+
|                             |
|                             |
|                             |
|                             |
|                             |
|                             |
|                             |
+-----------------------------+
```

Az abstract ősosztállyal megoldott területszámítás a következő módon működik:

```
+----------------------------------+                                                                                              |
|                                  |                                                                                              |
| Square                           |                                                                                              |
|                                  |                                                                                              |
|  public override double Area();  |  +-------------->                                                                            |
|                                  |                 |                                                                            |
|                                  |                 |                                                                            |
|                                  |                 |                                                                            v
+----------------------------------+                 |
                                                     |          +----------------------------------+            +-----------------------------+
                                                     |          |                                  |            |                             |
+----------------------------------+                 |          | abstract class Plane             |            | IPlane                      |
|                                  |                 |          |                                  |            |                             |
| Circle                           |                 |          |                                  |            |                             |
|                                  |                 |          |  public abstract double Area();  |  +------>  |  double Area();             |
|  public override double Area();  | +-------------> +--------> |                                  |            |                             |
|                                  |                 |          |                          <--------------------------------+  ^              |
|                                  |                 |          |                                  |            |              |              |
|                                  |                 |          |                                  |            |              |              |
+----------------------------------+                 |          |                                  |            |              |              |
                                                     |          |                                  |            |              |              |
                                                     |          +----------------------------------+            +-----------------------------+
                                                     |                                                                         |
+----------------------------------+                 |                                                                         |
|                                  |                 |                                                                         |
| Triangle                         |                 +                                                                         |
|                                  | +-------------->                                                                          +
|  public override double Area();  |                                                                        planes.Sum(x => x.Area())
|                                  |
+----------------------------------+
```

## Feladatok
- [X] Absztrakt osztály tulajdonságainak tisztázása
- [X] Mi a különbség az absztrakt osztály (abstract class) és a felület (interface) között?


### Absztrakt osztályok tulajdonságai
- absztrakt függvény csak absztrakt osztályban lehet
- absztrakt osztálynak lehet nem absztrakt függvényei, tulajdonságai és mezői
- nem lehet példányosítani, vagyis, csak leszármaztatott osztály ősosztályaként jön létre belőle példány

### Mi a különbség az absztrakt osztály és a felület között?
- A felület nem tartalmaz implementációt
- Az absztrakt osztály tartalmazHAT implementációt
- Amikor leszármaztatunk, csak egy ősosztályunk lehet, viszont több felületünk is.

## Feladatok
- [ ] Objektumorientált programozás fogalmai
- [ ] Objektumorientált elmélet
- [ ] Függvények, függvények paraméterei

### Objektumorientált programozás fogalmai
- Objektum (osztálypéldány)
  - azonosítható (indentity)
  - van állapota (state)
    - az objektum valamennyi tulajdonságához tartozó értékek halmaza az adott pillanatban
    - időben változhat
  - van viselkedése (behaviour)
    - függyvényekkel implementáljuk

- Osztály
  - objektum tervrajza, ennek alapján hozza létre a példányokat az alkalmazás
  - azonos típusú objektumok gyűjtője

### Objektumorientált elmélet fogalmai
- Elvonatkoztatás (Abstraction)
- Egységbezárás (Encapsulation)
- Modularitás (Modularity)
- Hierarchia (Hierarchy)

### Feladatok
- Objektumok életciklusa
  - [X] Létrehozó (Constructor)

```
+---------------------+          +---------------------+       +----------------------+
|  Third              |          |  Middle             |       |  Base                |
+---------------------+          +---------------------+       +----------------------+
|                     |          |                     |       |                      |
|                     | +----->  |                     | +---> |  Name                |
|                     |          |                     |       |  Email               |
|                     |          |                     |       |                      |
|                     |          |                     |       |                      |
+---------------------+          +---------------------+       +----------------------+

```

  - [X] Véglegesítő (Finalizer)
    - az objektumok életciklusa akkor ér véget, ha már "nincs rájuk szükség"
    - ez akkor történik, ha nincs már rájuk egyetlen élő hivatkozás sem a kódban
    - ekkor egy idő után jön a .NET keretrendszer szemétgyűjtője, és törli a memóriából
    - abban az esetben, ha takarítanivalónk van, ez nem jó megoldás
    - ilyen esetekre való a véglegesítő függvény
    - Csak ha abszolút fontos, és teljességgel tudjuk, hogy mit csinálunk, akkor használjunk véglegesítőt
    - Debug üzemmódban a debugger máshogy kezeli a memóriát, a példakódunk nem fog úgy futni, ahogy szeretnénk
    - Ezért ezt a példakódot Release konfigurációval futtassuk
    - és magától nem tudjuk, hogy a szemétgyűjtés mikor fut, így nekünk kell ezt kézzel kikényszeríteni - kizárólag demonstrációs célból.
- .NET memóriakezelése
  - [X] Szemétgyűjtő (Garbage Collector, GC)

### Szemétgyűjtő működése
```
             Értéktípusok                                Referenciatípusok


       +------------------+                     +---------------------------------------+
       | Verem (STACK)    |                     | Halom (HEAP)                          |
       +------------------+                     +---------------------------------------+
       |                  |                     |                                       |
       |  adat            |                     |                                       |
       |  adat            |                     |                                       |
       |  adat            |                     |                                       |
+----> |  adat            |                     |                                       |
       |  adat            |                     |                                       |
       |  adat            |                     |                                       |
       |                  |                     +---------------------------------------+ <---------------+ a HEAP foglalás teteje
       |                  |                     |hhhhhhhhhhhhhhh|iiiiiiiiiiiiii|jjjjjjjj|
       |  hivatkozás  +------------------>      |hhhhhhhhhhhhhhh|iiiiiiiiiiiiii|jjjjjjjj|
       |                  |              |      +---------------------------------------+
       |  hivatkozás      |              |      |eeeeeeeeeeeeeeeeeeeee|fffffffffff|ggggg|
       |                  |              |      +---------------------------------------+ 
       |                  |              v----> |aaaaaaaaaaaaaaaa|bbbbbbb|cccc|ddddddddd|
       +------------------+                     +---------------------------------------+

```

#### ROOT
innen indulva keressük meg az élő referenciákat

- hívási verem változói (függvény paraméterek is)
- lokális változók
- statikus osztály property-k és mezők
- finalizer queue
  azok az élő objektumok, amiknek van finalizer függvényük  
- f-reachable queue
  azok a garbage objektumok, amiknek van finalizer függvényük


#### Szemétgyűjtő (GC: Garbage Collector)
A szemétgyűjtés időről időre lefut, és takarít a következő módon:

0. minden adatot megjelöl szemétnek a heap memórián
1. A ROOT-ból elindulva végig tudunk menni valamennyi hivatkozáson és elérünk minden olyan osztálypéldányt, amire van érvényes és élő referencia. Ezeket megjelöli nem szemétnek.
2. A maradét a szemét (Garbage) ezt kell kitakarítani
3. A szemétgyűjtő minden érvényes adatot áthelyez hézagmentesre és frissíti a referenciákat úgy, hogy az adatok új helyére mutassanak
```
             Értéktípusok                                Referenciatípusok


       +------------------+                     +---------------------------------------+
       | Verem (STACK)    |                     | Halom (HEAP)                          |
       +------------------+                     +---------------------------------------+
       |                  |                     |                                       |
       |  adat            |                     |                                       |
       |  adat            |                     |                                       |
       |  adat            |                     |                                       |
+----> |  adat            |                     |                                       |
       |  adat            |                     |                                       |
       |  adat            |                     |                                       |
       |                  |                     |                                       |
       |                  |                     +------------------------------+  <------------------+  a HEAP foglalás teteje
       |  hivatkozás  +------------------>      |hhhhhhhhhhhh|jjjjjjjjjjjjjjjjj|        |
       |                  |              |      +---------------------------------------+
       |  hivatkozás      |              |      |eeeeeeeeeeeeee|ggggg|hhhhhhhhhhhhhhhhhh|
       |                  |              |      +---------------------------------------+
       |                  |              v----> |aaaaaaaaaaaaaaaa|cccc|ddddddddd|eeeeeee|
       +------------------+                     +---------------------------------------+

``` 

Ez gyakorlatilag egy szemétgyűjtési ciklus, ami az alkalmazások szempontjából a háttérben, észrevétlenül zajlik.

A korosítás azért van, hogy a szemétgyűjtés hatékonyabb legyen:
a 0. generációra fut a leggyakrabban a szemétgyújtés
az 1. ritkábban és legritkábban a 2. generációra fut.

#### Korosítás
A szemétgyűjtés alkalmával minden objektumnak lesz egy "kora".
- 0. szint: (gyerek) amire még nem futott a szemétgyűjtés
- 1. szint: (szülő) amire már egyszer futott a szemétgyűjtés
- 2. szint: (nagyszülő) amire már kétszer futott a szemétgyűjtés

A halom tetején vannak a legfiatalabbak (0. szint), 
majd öket követik amire már egyszer futott a szemétgyűjtés (1. szint) 
végül a halom legalján a legidősebb objektumok vannak (2. szint.)

A véglegesítő függvények a következő bonyodalmakat okozzák:

- 1. lépés (mínusz 1): amikor az objektum példányosodik, ha van van véglegesítő függvénye, akkor bekerül egy mutató erre az objektumra a finalizer queue-ba. 
     Ezért a szemétgyűjtéskor ezt az objektumot majd nem minősíti szemétnek a GC.

- 2/3. szemétgyűjtéskor a hivatkozást áthelyezi a szemétgyűtő az f-reachable queue-ba, 
     vagyis jelzi, hogy az objektum már nem és, de a finalizer még nem futott (igy bár "garbage", nem törölhető a heap-ről )


- Egy teljesen más folyamatban, egyszer, valamikor, nem meghatározható időpontban az f-reachable queuban lévő hivatkozások végén lévő objektumokra lefut a finalizer függvény, és kikerül az f-reachable queue-ból

- a következő szemétgyűjtéskor (mivel már a root-ból nem elérhető) garbage-nek minősül és törlődik a memóriából.


vagyis, 
- a véglegesítő függvény nem tudjuk, hogy mikor fut
- legalább két ciklus szemétgyűjtés kell, hogy a memóriából kitakarítódjanak.



### Házi feladat
- minden projektet futtatni linuxon
- Dockert telepíteni és elérni, hogy fusson (docker info működik)
- az elmélet elmélyítése és annak végiggondolása, hogy ha egy osztály olyan függőséget tartalmaz, amit takarítani kell, akkor mi a jó megoldás?
 