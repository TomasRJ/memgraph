# Memgraph

## Indholdsfortegnelse

- [Memgraph](#memgraph)
  - [Indholdsfortegnelse](#indholdsfortegnelse)
  - [Beskrivelse af databasen](#beskrivelse-af-databasen)
  - [Fordele og Ulemper](#fordele-og-ulemper)
  - [Demo](#demo)
  - [Dokumentation](#dokumentation)
    - [Opæstningen / installation](#opæstningen--installation)

## Beskrivelse af databasen

- Generel beskrivelse af databasetypen.
- Typiske anvendelsescases og industrielle anvendelser.
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

### Opæstningen / installation

**Krav:** Docker og Docker Compose

**Step 1:** Download [memgraph.yml](https://raw.githubusercontent.com/TomasRJ/memgraph/main/memgraph.yml)

**Step 2:** Åben en terminal og kør:

```sh
docker compose -f memgraph.yml -p graph up -d
```

**Sidste step:** Tillykke! Nu burde Memgraph køre i Docker. Gå til [localhost:3000](http://localhost:3000) for at arbejde med Memgraph.
