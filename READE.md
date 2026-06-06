# Talajnedvesség elemző

Minimalista C# ASP.NET, vanilla HTML, CSS és Javascript full-stack projekt Bootstrap használatával.

[Feladat leírás forrás](https://github.com/siposm/oktatas-fullstack/blob/181cb9f3ac1ac93d80546aed1007e0e260172734/semester-project/semester-project.md#%EF%B8%8F-talajnedvess%C3%A9g-elemz%C5%91)

### 🌧️ Talajnedvesség elemző

Készítsen egy rendszert, amely 3 bemeneti mátrixot feldolgozva kiszámolja, hogy egy adott hektárnyi területen mennyire nedves a talaj. Ehhez különböző eszközök méréseit megkapja, ezek a bemeneti adatok. A mátrixok sorai vesszővel vannak elválasztva egymástól, ezeket három külön textarea-kból küldje a kliens a backend API-nak. A bemeneti mátrixok bármekkorák lehetnek, de mindig négyzetesek és a három mátrix mérete mindig megegyezik.

Egy lehetséges példa 5x5 mátrixok esetén:

```txt
A mátrix:
  Sós,Tőzeges,Lúgos,Vályogos,Szerves
  Vályogos,Savanyú,Vályogos,Sós,Homokos
  Agyagos,Agyagos,Tőzeges,Lúgos,Lúgos
  Tőzeges,Szerves,Szerves,Savanyú,Tőzeges
  Savanyú,Lúgos,Homokos,Szerves,Agyagos
  Lúgos,Sós,Sós,Tőzeges,Sós
  Szerves,Vályogos,Savanyú,Homokos,Vályogos
  Homokos,Homokos,Agyagos,Agyagos,Savanyú

B mátrix:
  0.616555682,0.640437434,0.394921648,0.989150841,0.094593963
  0.73640787,0.533786646,0.010040263,0.103582895,0.822426946
  0.482072405,0.307524409,0.554290788,0.34809631,0.050875698
  0.030366978,0.029007159,0.684912003,0.15174959,0.169129819
  0.801127784,0.378496264,0.028311732,0.819583358,0.258000695

C mátrix:
  326.8790814,142.532508,451.0244456,492.2147514,9.854457502
  196.8179513,254.0216116,135.4596622,871.5870911,885.1868424
  552.9238429,388.6590505,877.9482358,693.8786444,255.2241038
  927.5234866,358.335735,359.6940165,240.604347,508.8106815
  611.5528772,937.5820018,131.415368,40.17513664,401.7750407
```

A szerver a megkapott mátrixokat dolgozza fel és adjon vissza egy aggregált eredménymátrixot, amelyet aztán a kliens jelenítsen meg. Az aggregáció eredménye egy víztérkép, amely a talaj vizességét jelenti a hektárnyi területen belül. A kliens feladata ebből egy táblázattal grafikusan megjeleníteni, hogy mennyire nedves a talaj adott mérési zónákban. Ehhez a táblázat celláit színezze ki saját skálázás alapján. Ahol nem nedves a talaj ott legyen barna a szín és ahogy nedvesedik a talaj, úgy legyen egyre kékesebb.

A talajok vízelvezető képessége így néz ki:

- Agyagos talaj: 0.319
- Tőzeges talaj: 0.380
- Szerves talaj: 0.391
- Sós talaj: 0.563
- Lúgos talaj: 0.669
- Vályogos talaj: 0.727
- Homokos talaj: 0.785

A végső víztérkép mátrixot úgy állítjuk elő, hogy:

- normalizálni kell a C mátrix értékeit 0-1 közé
- a B és normalizált C mátrix értékeit összeszorozzuk, ez legyen az X kimeneti mátrix
- majd elosztjuk az X mátrix értékeit az A mátrix értékeivel, megfeleltetve azokat a fentebbi listában található értékeknek
