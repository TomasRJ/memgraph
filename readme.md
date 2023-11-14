# Memgraph

## Indholdsfortegnelse

- [Memgraph](#memgraph)
  - [Indholdsfortegnelse](#indholdsfortegnelse)
  - [Beskrivelse af databasen](#beskrivelse-af-databasen)
  - [Fordele og Ulemper](#fordele-og-ulemper)
  - [Demo](#demo)
  - [Dokumentation](#dokumentation)
    - [Opsætningen / installation](#opsætningen--installation)
    - [C# projekt opsætning](#c-projekt-opsætning)
    - [Memgraph filmanbefaling opsætning](#memgraph-filmanbefaling-opsætning)
      - [Filmanbefalingssystemet](#filmanbefalingssystemet)
      - [Hvordan fungerer denne forespørgsel?](#hvordan-fungerer-denne-forespørgsel)
  - [Litteraturliste](#litteraturliste)

## Beskrivelse af databasen

Memgraph er en såkaldt grafdatabase som i grundprincip database der er en samling af noder som har forhold med hinanden. En typisk anvendelse af denne slags database er til sociale medier som f.eks. Facebook eller Twitter (X), men mere generelt vil man bruge grafdatabaser til data som har mange relationer med hinanden.

Til Memgraph bruger man Cypher som query language, som originalt blev udviklet til Neo4j. Her er et eksempel på hvordan man kan oprette to noder med et forhold til hinanden:

```cypher
CREATE (:Person {name: 'Tom'})-[:LIKES]->(:Food {name: 'Pizza'})
```

Man kan så tilføje flere et nyt slags mad til den samme person således:

```cypher
MATCH (p:Person {name: 'Tom'})
CREATE (p)-[:LIKES]->(:Food {name: 'Ice cream'})
```

På den måde kan lige så stille begynde at lave et netværk.

Derudover så har man også igennem Memgraph Lab mulighed for download eksterne dataset, her bruger vi MovieLens datasættet til at lave et anbefalingssystem i vores [demo](#demo).

## Fordele og Ulemper

Fordele:

- Grafdatabase er meget fleksible og det kan blive brugt til at gemme struktureret, semi- struktureret og ustruktureret data. Det gør dem rigtig god til hvis man skal gemme kompliceret data som ikke passer godt ind i en almindelig rationel database.

- Grafdatabaser er designet til at håndtere komplicerede forespørgsler og store mængde data. Det kan blive brugt til at vise komplicerede forhold mellem forskellige noder.

- Grafdatabase er gode til at skalere og kan håndtere store mængde af data.

Ulemper:

- Grafdatabaser er ny og speciel teknologi som kun få personer har stor erfaring med. Det kan betyde for firmaer kan blive svært at finde nogle specialister.

- Der ikke en standard forespørgselssprog endnu, ligesom SQL i den rationelle database verden, og det betyder at man bliver hårdt koblet med den grafdatabase man vælger.

- Grafdatabaser er lavet til store mængde data som har mange forhold og derfor ikke brug bare til små hjemmesider eller applikationer.

## Demo

Vi har lavet et lille [Hello World eksempel i C#](https://github.com/TomasRJ/memgraph/tree/main/memgraph-c-sharp) som arbejder direkte med en memgraph database. Den laver en node som vil blive gemt i databasen og som bliver printet ud i terminalen.

Vores andet eksempel er noget vi laver i selve Memgraph Lab. Det er et filmanbefalingssystem, hvor vi bruger MovieLens datasættet og ny bruger med deres egne filmbedømmelser til at anbefale nye film til dem. Selve opsætning af dette filmanbefalingssystem er [her i vores dokumentation](#memgraph-filmanbefaling-opsætning).

## Dokumentation

### Opsætningen / installation

**Krav:** Docker og Docker Compose

**Step 1:** Download [memgraph.yml](https://raw.githubusercontent.com/TomasRJ/memgraph/main/memgraph.yml)

**Step 2:** Åben en terminal og kør:

```sh
docker compose -f memgraph.yml -p database up -d
```

**Sidste step:** Tillykke! Nu burde Memgraph køre i Docker. Gå til [localhost:3000](http://localhost:3000) for at arbejde med Memgraph.

### C# projekt opsætning

**Krav:** .NET 7

**Husk nu at Memgraph skal være kørende før det projekt vil virke.** Ellers så er det eneste du skal gøre er at åbne projektet i din favorit IDE og køre det, så burde du et `Hello World!` output i terminalen.

### Memgraph filmanbefaling opsætning

1. Gå til [localhost:3000](http://localhost:3000) for at bruge Memgraph Lab. Naviger til [Datasets](http://localhost:3000/lab/overview?component=datasets) og find og download MovieLens datasættet.
2. Opret en ny bruger som skal have nogle nye bedømmelser:

```cypher
CREATE (:User {id:1000});
```

3. Tjek om den nye bruger er oprettet:

```cypher
MATCH (user:User{id:1000})
RETURN user;
```

4. Opret nogle nye bedømmelser for den nye bruger:

```cypher
MATCH (u:User {id:1000}), (m:Movie {title:"2 Guns (2013)"})
MERGE (u)-[:RATED {rating:3.0}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"21 Jump Street (2012)"})
MERGE (u)-[:RATED {rating:3.0}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"Toy Story (1995)"})
MERGE (u)-[:RATED {rating:3.5}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"Lion King, The (1994)"})
MERGE (u)-[:RATED {rating:4.0}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"Dark Knight, The (2008)"})
MERGE (u)-[:RATED {rating:4.5}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"Star Wars: Episode VI - Return of the Jedi (1983)"})
MERGE (u)-[:RATED {rating:4.5}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"Godfather, The (1972)"})
MERGE (u)-[:RATED {rating:5.0}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"Lord of the Rings: The Return of the King, The (2003)"})
MERGE (u)-[:RATED {rating:4.0}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"Aladdin (1992)"})
MERGE (u)-[:RATED {rating:4.0}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"Pirates of the Caribbean: The Curse of the Black Pearl (2003)"})
MERGE (u)-[:RATED {rating:4.5}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"Departed, The (2006)"})
MERGE (u)-[:RATED {rating:4.0}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"Texas Rangers (2001)"})
MERGE (u)-[:RATED {rating:2.0}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"Eve of Destruction (1991)"})
MERGE (u)-[:RATED {rating:1.0}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"Sharkwater (2006)"})
MERGE (u)-[:RATED {rating:2.0}]->(m);
MATCH (u:User {id:1000}), (m:Movie {title:"Extreme Days (2001)"})
MERGE (u)-[:RATED {rating:1.5}]->(m);
```

Returner en liste af alle de film som brugeren med `id = 1000` har bedømt:

```cypher
MATCH (user:User {id:1000})-[rating:RATED]->(movie:Movie)
RETURN user, movie, rating
```

#### Filmanbefalingssystemet

Ideen er at implementere noget der hedder [memory based collaborative
filtrering](https://en.wikipedia.org/wiki/Collaborative_filtering).

Lad os anbefale nogle film til brugeren med `id = 1000`:

```cypher
MATCH (u:User {id:1000})-[r:RATED]-(m:Movie)
      -[other_r:RATED]-(other:User)
WITH other.id AS other_id,
     avg(abs(r.rating-other_r.rating)) AS similarity,
     count(*) AS same_movies_rated
WHERE same_movies_rated > 2
WITH other_id
ORDER BY similarity
LIMIT 10
WITH collect(other_id) AS similar_user_set
MATCH (some_movie:Movie)-[fellow_rate:RATED]-(fellow_user:User)
WHERE fellow_user.id IN similar_user_set
WITH some_movie, avg(fellow_rate.rating) AS prediction_rating
RETURN some_movie.title AS Title, prediction_rating
ORDER BY prediction_rating DESC;
```

#### Hvordan fungerer denne forespørgsel?

Denne forespørgsel har to dele:

- At finde lignende brugere
- Forudsigelse af bedømmelse for en film (anbefaling)

I den første del leder vi efter lignende brugere. Først skal vi definere
lignende brugere: To brugere betragtes som ens, hvis de har tendens til at give lignende
bedømmelser til de samme film. For målbrugeren og en anden bruger vi
søger efter de samme film:

```cypher
MATCH (u:User {id:1000})-[r:RATED]-(m:Movie)-[other_r:RATED]-(other:User)
RETURN *;
```

Hvis man prøver at udføre forespørgslen ovenfor med `RETURN`, får du alle de
potentielle lignende brugere og film de har bedømt.
Men dette er ikke nok til at finde lignende brugere. Vi skal vælge brugere med
de samme film og lignende bedømmelser:

```cypher
WITH other.id AS other_id,
     avg(abs(r.rating-other_r.rating)) AS similarity,
     count(*) AS same_movies_rated
WHERE same_movies_rated > 2
WITH other_id
ORDER BY similarity
LIMIT 10;
WITH collect(other_id) AS similar_user_set
```

Her beregner vi ligheder som den gennemsnitlige afstand mellem en målbrugerbedømmelse
og nogle andre brugerbedømmelser på det samme sæt af film. Der er to parametre:
"same_movies_rated" definerer antallet af samme film (mere end 3), som målbrugeren og andre brugere har bedømt sammen, og "similar_user_set" repræsenterer de brugere, der gav en lignende bedømmelse til de film, som målbrugeren har bedømt. Disse parametre gør det muligt at udtrække de bedste brugere til filmanbefalinger.

Nu har vi et lignende brugersæt. Vi vil bruge disse brugere til at beregne en gennemsnitlig
klassificeringsværdi for alle de film de har bedømt i databasen som en variabel "prediction_rating". Vi returner de bedst bedømte film i rækkefølge efter variablen "prediction_rating".

```cypher
MATCH (some_movie: Movie)-[fellow_rate:RATED]-(fellow_user:User)
WHERE fellow_user.id IN similar_user_set
WITH some_movie, avg(fellow_rate.rating) AS prediction_rating
RETURN some_movie.title AS title, prediction_rating
ORDER BY prediction_rating DESC;
```

## Litteraturliste

- [Use cases](https://memgraph.com/use-cases)
- [Recommendation engine](https://memgraph.com/recommendation-engine)
- [Faster recommendations with graph databases](https://memgraph.com/blog/faster-recommendations-with-graph-databases)
- [Graph Query Language - Wikipedia](https://en.wikipedia.org/wiki/Graph_Query_Language#Standardisation_process)
- [Movie recommendation system - Memgraph docs](https://memgraph.com/docs/querying/exploring-datasets/movie-recommendation)
