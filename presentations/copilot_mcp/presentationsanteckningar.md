# Presentationsanteckningar – AI för utvecklare

Denna fil ger fördjupning och talarstöd till varje slide i `slides.md`.

---

## AI – Use cases (1/2)

- Kod
  - Taktik: skriv funktion‑signaturer och kommentarer först; be om liten diff; jämför 2–3 alternativ.
  - Exempel: “Refaktorera metoden X för läsbarhet och O(n log n); behåll API kontrakt; föreslå tester.”
  - Mätning: se diffstorlek, testtäckning, felrapporter efter merge.
- Tester
  - Taktik: be om enhetstester (happy + edge), generera fixtures/mocks; håll AAA‑struktur.
  - Exempel: “Skapa xUnit‑tester för Y med boundary‑värden; lägg Given/When/Then‑kommentarer.”
  - Mätning: antal nya tester, täckning, körtid.
- Dokumentation
  - Taktik: generera README/API‑docs från kodkommentarer/attribut; kräv länkade källor.
  - Exempel: “Generera endpoint‑översikt med exempelförfrågningar och curl‑kommandon.”
  - Mätning: PR‑reviewtid, supportfrågor, docs‑aktualitet.
- Support/Q&A (RAG)
  - Taktik: indexera interna dokument/kod; be om svar med citat och fil/commit‑referenser.
  - Exempel: “Hur konfigurerar vi auth i Stage? Citera källor.”
  - Mätning: lösningstid, eskalationer, nöjdhet.

---

## AI – Use cases (2/2)

- Automation
  - Taktik: generera skript/CLI, YAML, migrations; specificera idempotens och rollback.
  - Exempel: “Skapa PowerShell‑skript som rensar UAT‑databaser äldre än 30 dagar; torrkörningsläge.”
  - Mätning: sparad tid, fel per körning, antal manuella steg ersatta.
- Datafrågor/analys
  - Taktik: be om SQL/KQL‑frågor och förklaringar; kräv parameterisering och index‑tips.
  - Exempel: “Föreslå KQL för topp 10 latency‑endpoints med percentiler; motivera index.”
  - Mätning: query‑latens, korrekthet, incidentupptäckt.
- Modernisering
  - Taktik: be om migreringsplan med risker, MVP‑steg och verifiering; generera kodstommar.
  - Exempel: “Migrera .NET 6 → 8 för modul Z; lista brytande ändringar och fixplan.”
  - Mätning: ledtid, regressionsfrekvens, prestanda före/efter.
- Kodsök/insikt
  - Taktik: använd semantisk sök; be om beroende‑grafer, duplicering, komplexitet.
  - Exempel: “Hitta alla synkrona DB‑anrop i webblagret och föreslå async‑refaktorering.”
  - Mätning: buggar kopplade till kodlukt, minskad cyklomatisk komplexitet.

---

## Chatta med AI – Principer

- Kontext + mål: vilka filer, moduler, branch; vad ska levereras (ex. patch/PR/text/JSON).
- Krav/constraints: språkversioner, ramverk, kodstil, performance/security‑krav.
- Plan → kod: be om stegplan först; låt modellen generera diff/kod i små steg.
- Små diffar: lätt att granska och återställa; bättre träffsäkerhet.
- Källor/sammanhang: länk till issue/story/design‑dokument.

---

## Chatta med AI – Verifiering & parametrar

- Outputformat: be om strikt JSON/MD/kodfiler för enkel automatisering.
- Verifiering: 
  - Tests: be modellen skriva/uppdatera tester; kör dem.
  - Reflektion: be modellen lista risker/antaganden och hur de verifieras.
  - Källor: be om citat/paths till filer/stycken.
- Parametrar:
  - Temperatur: lägre = mer deterministiskt; höj vid brainstorming.
  - System/roll: sätt stil och begränsningar; JSON‑läge för schema‑bundna svar.

---

## GitHub Copilot – Editor & Chat

- Inline tips:
  - Kommentarer/signaturer styr kvalitet; bryt ner uppgifter; använd accepteringskriterier.
- Chat‑användning:
  - Förklara komplex kod; generera tests/docs; föreslå refaktoreringar/migreringar.
  - Markera relevant kod/fil för bättre kontext i svaret.
- Arbetsmetodik:
  - Be om 2–3 alternativ och trade‑offs; jämför innan du väljer.
  - Kör tester direkt efter varje antagen förändring.

---

## MCP

- Vad: Model Context Protocol — öppet protokoll som standardiserar hur AI‑klienter ansluter till verktyg/data.
- Varför: Portabelt, säkert, återbrukbart; isolerar hemligheter och minskar skräddarsydd glue‑code.
- Hur:
  - MCP‑server (C#/Node/Python) exponerar tools/resources/prompts.
  - Klient (VS Code/Visual Studio/Chat) ansluter via stdio/WebSocket/SSE.
- Exempel:
  - Kodsök i repo; Jira/GitHub‑frågor; interna API:er; databassök.
- Best practices:
  - Tydliga tool‑kontrakt (schema), idempotens, auth, rate limits, logging.
  - Audit‑spår: vem gjorde vad, när, via vilket verktyg.

---

## Tips för demo/övning (valfritt)

- Visa en RAG‑kedja: fråga → retrieval (top‑k) → svar med källor.
- Låt Copilot generera ett enhetstest, kör det och refaktorera koden.
- Koppla en enkel MCP‑server som läser en lokal fil och svarar via Chat‑klient.

---

## Länkar

- Model Context Protocol: https://modelcontextprotocol.io
- Prompting patterns: https://www.promptingguide.ai
- Vector search basics: (valfri artikel/sammanfattning)
- GitHub Copilot docs: https://docs.github.com/copilot
