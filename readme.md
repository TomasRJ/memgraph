# Memgraph

## Indholdsfortegnelse

- [Ressourcer](#ressourcer)
- [Beskrivelse af databasen](#beskrivelse-af-databasen)
- [Fordele og Ulemper](#fordele-og-ulemper)
- [Demo](#demo)
- [Dokumentation](#dokumentation)
  - [Opsætningen / installation](#opsætningen--installation)
  - [C# projekt opsætning](#c-projekt-opsætning)

## Ressourcer

- [Use cases](https://memgraph.com/use-cases)
- [Recommendation engine](https://memgraph.com/recommendation-engine)
- [Faster recommendations with graph databases](https://memgraph.com/blog/faster-recommendations-with-graph-databases)

## Beskrivelse af databasen

- Generel beskrivelse af databasetypen.
- Typiske anvendelsescases og ind- [Indholdsfortegnelse](#indholdsfortegnelse)
- [Ressourcer](#ressourcer)
- [Beskrivelse af databasen](#beskrivelse-af-databasen)
- [Fordele og Ulemper](#fordele-og-ulemper)
- [Demo](#demo)
- [Dokumentation](#dokumentation)
  - [Opsætningen / installation](#opsætningen--installation)
  - [C# projekt opsætning](#c-projekt-opsætning)ustrielle anvendelser.
- Overblik over datamodellen og forespørgselsmekanismer.

## Fordele og Ulemper

- Identificer fordele ved at bruge den valgte databasetype.
  - Ulemper og eventuelle begrænsninger.

## Demo

**Gruppen skal skabe en simpel demo-applikation** eller datasæt for at vise databasens funktioner. Dette kan inkludere:

- Import/eksport af data.
- Eksempel på CRUD operationer (Create, Read, Update, Delete).
- En demonstration af specifikke forespørgsler eller transaktioner, som viser databasens styrker.

## Dokumentation

### Opsætningen / installation

**Krav:** Docker og Docker Compose

**Step 1:** Download [memgraph.yml](https://raw.githubusercontent.com/TomasRJ/memgraph/main/memgraph.yml)

**Step 2:** Åben en terminal og kør:

```sh
docker compose -f memgraph.yml up -d
```

**Sidste step:** Tillykke! Nu burde Memgraph køre i Docker. Gå til [localhost:3000](http://localhost:3000) for at arbejde med Memgraph.

### C# projekt opsætning

**Krav:** .NET 7

**Husk nu at Memgraph skal være kørende før det projekt vil virke.** Ellers så er det eneste du skal gøre er at åbne projektet i din favorit IDE og køre det, så burde du et `Hello World!` output i terminalen.
