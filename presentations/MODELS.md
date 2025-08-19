---
marp: true
theme: gaia
_class: lead
paginate: true
backgroundColor: #fff
backgroundImage: url('https://marp.app/assets/hero-background.svg')
header: "Språkmodeller för utvecklare"
footer: "Falkenberg 2025"
---

# Språkmodeller för utvecklare

- **Syfte**: Förstå skillnader mellan modelltyper, tokens och priser, vad reasoning innebär, samt när man väljer vilken modell.

---

## Agenda

- Tokens, kontext och kostnader (input vs output)
- Modelltyper: non‑reasoning vs reasoning, storlek, multimodalitet
- När väljer man vad? Beslutsguide och tumregler
- Verktyg: function calling, RAG, finetuning
- Parametrar, latens och skalning
- Kvalitet, utvärdering och säkerhet

---

## Tokens 101

- En token ≈ 3–5 tecken, ofta ~0,7–1,3 ord beroende på språk och texttyp.
- Allt räknas som tokens: systemprompt, användarinput, verktygssvar och modellens output.
- Tokenbudget = max antal tokens per anrop ("kontextfönster"). Långa indata kan behöva sammanfattas eller chunkas.
- Praktiskt: Håll prompts och exempel snåla, återanvänd via variabler, streama output när möjligt.

---

## Kontextfönster

- Storleken avgör hur mycket indata modellen kan överväga samtidigt.
- Stort fönster ≠ perfekt minne; relevans minskar ofta med avstånd.
- Långa dokument: använd RAG (retrieval) eller externa minnen istället för att klistra in allt.

---

## Prissättning: input vs output

- De flesta leverantörer tar betalt per token, separat för input och output.
- Outputtokens är ofta dyrare än inputtokens.
- Enkel kostnadsformel: \(\text{kostnad} = \text{tokens}_{in} \times pris_{in} + \text{tokens}_{out} \times pris_{out}\).
- Exempel (hypotetiskt): 800 in + 200 ut, pris_in = $0.5/1k, pris_out = $2/1k → kostnad ≈ $0.8 × $0.5 + $0.2 × $2 = $0.4 + $0.4 = $0.8.
- Tips: Begränsa max outputtokens, använd sammanfattningar och strukturera svar för förutsägbar längd.

---

## Modelltyper (översikt)

- **Icke‑resonerande ("snabba")**: Optimerade för latens och pris. Bra på direktuppgifter: omskrivning, extraktion, enklare kod, chat.
- **Resonerande**: Har intern "tankeprocess". Dyrare och långsammare men bättre på komplex problemlösning, planering, flerstegsuppgifter.
- **Storlek**: Mindre (billigare, snabbare) vs större (bättre allmänt, robustare). Välj minsta som klarar kraven.
- **Multimodala**: Tar text + bild/ljud/video. Praktiskt för kvitton, grafer, skärmdumpar, UI-förståelse.
- **Öppen källkod vs sluten**: Självhosta för kontroll/sekretess; molnmodeller för toppkvalitet och enkelhet.

---

## Reasoning vs non‑reasoning

- **Non‑reasoning**: Låg latens, låg kostnad, förutsägbara svar. Tappar kvalitet vid lång kedja av beroenden.
- **Reasoning**: Producerar/optimerar intern kedja av resonemang. Högre noggrannhet i komplexa stegvis-uppgifter, men dyrare och långsammare.
- Vanliga symptom: reasoning-modeller kan "tänka längre" och är robustare mot små promptvariationer.

---

## När välja reasoning?

- Flerstegslogik, formella bevis/beräkningar, icke-trivial felsökning.
- Planering över längre horisonter (jobbförslag, roadmap, pipeline-design).
- Strikt verktygsorkestrering: välja rätt verktyg i rätt ordning.
- När A/B visar för stor kvalitetsförlust med billigare modell.

---

## När välja icke‑reasoning / liten modell?

- Texttransformationer: översättning, sammanfattning, tonläge, formatering.
- Informationsutvinning: nyckelfält ur kvitton/loggar, korta Q&A över känd fakta.
- Enklare kodassistans (små diffar, boilerplate), generering av testfall från mall.
- Hög volym, hårda SLO:er för latens och kostnad.

---

## Multimodalitet (kort)

- Bild→text: OCR, UI-analys, diagramextraktion.
- Text→tal / tal→text: röstgränssnitt, callcenter.
- Video: scenbeskrivningar, innehållspolicy.
- Kostnad och latens kan öka kraftigt — använd selektivt och nedskalat (t.ex. tumregler, crops, sampling).

---

## Verktygskall och RAG

- **Function calling / verktyg**: Beskriv API-schema; modellen väljer funktion och argument. Bra för databasanrop, sök, kalkyl.
- **RAG (Retrieval‑Augmented Generation)**: Hämta relevanta bitar från din kunskapsbas och ge modellen som kontext. Minskar hallucinationer.
- Bästa praxis: semantisk sök, chunkning med metadata, citat i svar, cachea retrieval.

---

## Finetuning vs prompting

- **Prompting**: Snabbt, billigt, lätt att iterera. Räcker långt med bra exempel och format.
- **Finetuning**: Lönar sig när samma smala uppgift återkommer och kräver konsekvent stil/format.
- Undvik finetuning för rena fakta – använd RAG. Finetuna för stil, klassificering, extraktion.

---

## Parametrar som påverkar beteende

- **temperature**: slumpmässighet (0–0.2 deterministiskt, 0.7+ kreativt).
- **top_p / top_k**: begränsar urval ur sannolikhetsmassa/antal kandidater.
- **stop‑tokens**: kontrollera när svaret ska avslutas.
- **max_tokens**: hårt tak på outputlängd.
- Ange önskat format (t.ex. strikt JSON) för robustare integration.

---

## Latens och skalning

- Streama svar för tidig feedback till användare.
- Batching och parallellisering där det går (oberoende delproblem).
- Cache: resultat per prompt, retrieval-cache, mellanresultat.
- Spekulativ decoding och distillering kan sänka latens (stöd varierar per leverantör).

---

## Kvalitet och utvärdering

- Skapa en guldmängd (inputs + förväntade outputs) tidigt.
- Mät: precision/recall, strukturell korrekthet (JSON-schema), kostnad/latens.
- Automatiserade jämförelser (A/B) mellan modeller och prompts.
- Var försiktig med att bedöma "resonemang" — fokusera på korrekta slutresultat.

---

## Säkerhet och efterlevnad

- Prompt‑injektion: sanera källor och isolera modellens åtkomst.
- PII/sekretess: undvik att skicka känsliga data till tredjepart; anonymisera eller självhosta.
- Policyer: systemprompt + guardrails (validering, post‑processing, allowlist).
- Loggning: logga prompts/outputs med tokenräkning, men respektera dataskydd.

---

## Beslutsguide (tumregler)

- Börja med snabb/billig modell. Byt upp dig bara om kvaliteten inte når målen.
- Om uppgiften kräver flerstegsresonemang eller planering → pröva reasoning‑modell.
- Om volymen är hög och formatet är strikt → överväg finetuning av liten modell.
- Multimodalt? Använd multimodal endast där signalen behövs, annars extrahera först med specialiserade verktyg.

---

## Checklista vid implementation

- Definiera input/output‑schema och max tokens.
- Sätt temperatur, stop‑tokens och JSON‑format.
- Lägg till återförsök med jitter och idempotens.
- Mät och logga: tokens_in, tokens_out, latens, fel.
- Utvärdera regelbundet mot guldmängd och kostnadsbudget.

---

## Exempel: Kostnad och outputkontroll

- Kostnadsestimat per anrop:
  - \(C = T*{in} \cdot P*{in} + T*{out} \cdot P*{out}\)
- Sänk kostnad:
  - Komprimera kontext (sammanfatta, hämta top‑k med RAG)
  - Sätt `max_tokens` lågt och be om punktlistor
  - Återanvänd tidigare beräknade svar via cache

---

## Exempel: Strukturerad output (JSON)

```
System: Du är en noggrann extraktor. Svara ENDAST med giltig JSON enligt schema.
Användare: Plocka ut {namn, belopp, valuta, datum} ur texten. Missing → null.
Outputformat: {"namn": string|null, "belopp": number|null, "valuta": string|null, "datum": string|null}
Text: ...
```

- Validera mot schema; avvisa ogiltiga svar och återförsök.

---

## Sammanfattning

- Tokens styr både kontext och kostnad — räkna på dem.
- Välj minsta modell som klarar kraven; reasoning för verkligt komplexa kedjor.
- Använd verktyg/RAG för fakta och integrationer; finetuna för snäva, återkommande format.
- Mät kvalitet, kostnad och latens kontinuerligt och iterera.

---

## Vidare läsning

- Tokenisering och räknare: dokumentation från din leverantör och öppna bibliotek (t.ex. tiktoken‑kloner).
- RAG‑mönster och vektordatabaser (semantisk sök, chunkning, citationer).
- Säkerhet: prompt‑injektion, PII‑hantering, guardrails.
