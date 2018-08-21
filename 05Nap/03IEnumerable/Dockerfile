# két fázisban dolgozunk, egy a buildhez és egy a csomagoláshoz.
# 1. BUILD
# A kiindulási docker konténer, a microsoft dotnet sdk-ja, ami kell a buildhez.
FROM microsoft/dotnet:sdk AS buildenv

#a konténerben ez a kiindulási könyvtár
WORKDIR /app

# átmásoljuk a projekt fájl-t a konténerbe
# a widcard segítségével általános Dockerfile-t gyártunk!
# első paraméter: windows-os forráskód
# második paraméter: konténeres app könyvtár
COPY *.csproj ./

# lefuttatjuk rá a dotnet restore-t (így csak ami projektünk függőségeit telepítjük, ez az optimális, javasolt megoldás)
# (ez a konténerben fut)
RUN dotnet restore

# átmásoljuk a forráskódot a konténerbe
# első paraméter: windows-os forráskód
# második paraméter: konténeres app könyvtár
COPY . ./

# elkészítjük a futtatható végeredményt
# ez a konténerben fut
# ezzel előállítjuk azt a könyvtárat amire szükségünk van
RUN dotnet publish -c Release -o out

# 2. RUNTIME IMAGE
# ez a futtatókörnyezet, ami egy második konténer!
FROM microsoft/dotnet:aspnetcore-runtime

#a konténerben ez a kiindulási könyvtár
WORKDIR /app

#átmásoljuk ez első konténerből a másodikba a dolgokat
COPY --from=buildenv /app/out .

#alkalmazás indítása
ENTRYPOINT ["dotnet", "03IEnumerable.dll"]
