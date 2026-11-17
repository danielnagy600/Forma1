# Forma 1 webalkalmazás

## Az alkalmazás lényege

Forma 1-es csapatok nyilvántartására szolgáló ASP.NET Core MVC webalkalmazás.

- **Nyilvános főoldal:** bárki megtekintheti a csapatok listáját (név, alapítás éve, megnyert világbajnokságok száma, nevezési díj megléte).
- **Csapatok kezelése (bejelentkezés után):** új csapat létrehozása, meglévő szerkesztése és törlése.
- **Bejelentkezés / kijelentkezés:** a módosító műveletek csak hitelesített felhasználó számára érhetők el.

Alapértelmezett felhasználó (induláskor jön létre):

| Felhasználónév | Jelszó       |
|----------------|--------------|
| `admin`        | `f1test2018` |

> Az adatbázis memóriában fut, így az alkalmazás újraindításakor minden módosítás elvész, és a kezdő adatok újra betöltődnek.

## Technikai megvalósítás

- **Keretrendszer:** .NET 10, ASP.NET Core MVC (Model–View–Controller).
- **Rétegek:**
  - `Controllers/` – `HomeController` (nyilvános lista, hibaoldal), `TeamsController` (CRUD, osztályszintű `[Authorize]`), `AccountController` (be- és kijelentkezés).
  - `Data/` – `Forma1Context` (EF Core `IdentityDbContext`), `ITeamRepository` / `TeamRepository` (repository minta, aszinkron LINQ lekérdezések), `TeamSeeder` (kezdő adatok és admin felhasználó).
  - `Data/Entities/` – adatbázis-entitások (`Team`, `StoreUser`).
  - `ViewModels/` – a nézetek modelljei, az entitásoktól elkülönítve, validációs attribútumokkal (`TeamViewModel`, `LoginViewModel`, `ErrorViewModel`).
  - `Views/` – Razor nézetek tag helperekkel; a létrehozó és szerkesztő űrlap közös `_TeamForm` partial nézetet használ.
- **Adatbázis:** Entity Framework Core Code First, SQLite in-memory módban. A kapcsolat az alkalmazás teljes élettartama alatt nyitva marad, az adatbázist indításkor az `EnsureCreated` hozza létre.
- **Hitelesítés:** ASP.NET Core Identity cookie-alapú bejelentkezéssel; a bejelentkezés `returnUrl`-t kezel, a kijelentkezés POST kéréssel történik.
- **Validáció:** szerveroldalon Data Annotations attribútumokkal, kliensoldalon jQuery Validation (unobtrusive) segítségével.
- **Biztonság:** anti-forgery token minden POST műveleten, csak helyi átirányítás bejelentkezés után, HTTPS-átirányítás és HSTS éles környezetben.
- **Felület:** Bootstrap 5, reszponzív navigációs sávval.

## Csomagok

### NuGet

| Csomag | Verzió | Szerep |
|--------|--------|--------|
| `Microsoft.AspNetCore.Identity.EntityFrameworkCore` | 10.0.15 | Felhasználókezelés és hitelesítés EF Core tárolóval |
| `Microsoft.EntityFrameworkCore.Sqlite` | 10.0.15 | EF Core SQLite adatbázis-szolgáltató |

### Kliensoldali könyvtárak (`wwwroot/lib`)

| Könyvtár | Verzió | Szerep |
|----------|--------|--------|
| Bootstrap | 5.3.9 | Megjelenés, elrendezés |
| jQuery | 3.7.1 | A validációs könyvtárak függősége |
| jQuery Validation | 1.22.1 | Kliensoldali űrlapvalidáció |
| jQuery Validation Unobtrusive | 4.0.0 | A szerveroldali validációs szabályok átvétele a kliensre |

## Futtatás

```bash
cd Forma1WebApp
dotnet run
```

Vagy Visual Studióban a `Forma1WebApp.sln` megnyitásával.
