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