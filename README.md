# **LogisticsApp**

**LogisticsApp** je aplikacija za upravljanje i praćenje pošiljki, razvijena u .NET tehnologijama. Projekat je podeljen na **Backend** (Web API) i **Frontend** (Blazor aplikaciju), koji zajedno omogućavaju sveobuhvatan sistem za praćenje statusa i detalja pošiljki.

---

## **Karakteristike**

1. **Backend**:

   - Implementiran kao ASP.NET Core Web API.
   - Svi Minimal Endpointi API-se nalaze u .API/Endpoinst/ShipmentEnpoints.cs
   - Mock baze je i implementirana unutar .Infrastrucure/Persistence projekta i čuva podatke unutar HashMape
   - Komuniciranje između mock baze implementirano je preko repository patterna i implementacija repository-ja se nalazi u .Infrastucture/Repositories
   - Komuniciranje sa korisnicima api-ja implementirano je kroz DTO objekte koji se nalaze u .Application/Dtos
   - Za mappiranje Entitata mock baze i DTO objekata korišćen je AutoMapper i kofiguracija profila nalazi se u .Application/Profiles
   - Validacija je implementirana FluentValidation paketom kao što je navedeno u specifikaciji Validatori se mogu naći u .Application/Validators dok se sam filter za minimal API Endpoint-e nalazi u .API/Filters
   - Svaki API request je obmotan ErrorHandling Middleware-om čija implementacija se može naći u .API/Middlewares
   - Loggovanje je implementirano Serilog-om i Log Faljovi se kreiraju unutar .API/Logs foldera pored samog terminala

2. **Frontend**:

   - Komunikacija između API ja je implementirana kroz servis koji se nalazi unutar .Blazor/Services
   - Mock Logging sistem koji samo prikazuje diamički interfejs implementiran je unutar .Blazor/Services i njegova korišćenje se može videti unutar Layout/NavMenu.razor stranice
   - Prikazivanje validacije je implementirano direktno sa API strana prilikom Bad Requesta(400) i njegova implementacija se nalazi unutar Samog API servisa pri POST-Create i PUT-Update pozivima ka API-ju
   - Od spoljnih paketa koišćeni su google font i google icons

3. **Tehnologije**:
   - **Backend**: .NET 8, ASP.NET Core.
   - **Frontend**: Blazor, C#.
   - **Docker** podrška za lako pokretanje aplikacije.

---

## **Kako pokrenuti projekat**

1. **Kloniranje repozitorijuma**  
   Otvorite terminal i klonirajte projekat:

   ```PowerShell
   git clone <url>
   cd LogisticsApp
   ```

2. **Obnavljanje paketa i izgradnja projekta**  
   Pokrenite komande za obnavljanje i izgradnju svih projekata:

   ```PowerShell
   dotnet restore
   dotnet build
   ```

3. **Pokretanje Backend-a (Web API)**  
   Otvorite jedan terminal i pokrenite komande:

   ```PowerShell
   cd src\Backend\LogisticsApp.API\
   dotnet run
   ```

   ili, ako želite automatsko ponovno pokretanje pri promenama:

   ```PowerShell
   dotnet watch
   ```

4. **Pokretanje Frontend-a (Blazor aplikacija)**  
   Otvorite drugi terminal i pokrenite komande:
   ```PowerShell
   cd src\Frontend\LogisticApp.Blazor\
   dotnet run
   ```
   ili uz automatsko ponovno pokretanje:
   ```PowerShell
   dotnet watch
   ```

---

## **Napomene**

- Web API po defaultu radi na portu `http://localhost:5029`.
- Blazor aplikacija radi na portu `http://localhost:5189`.

---
