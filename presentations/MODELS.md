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

- **Syfte**: Förstå skillnader mellan modeller, tokens och priser, vad reasoning innebär, samt när man väljer vilken modell.

---

![bg 95%](./images/aa_intelligence_index.png)

<!--
Idag finns det väldigt många språkmodeller att välja mellan, och det är inte helt enkelt att välja mellan dem.

Här ser ni de idag högst presterande modellerna när man har evaluerat dem mot åtta olika benchmarks som testar  allt ifrån modellarnas förmåga att följa instruktioner och skriva kod, till biologi och kemi.
-->

---

![bg 95%](./images/aa_coding_index.png)

<!--
Om man istället bara kollar på resultatet från de två kod-benchmarksen så ser resultatet istället ut såhär.

Här kan man se att GPT-5 som tidigare låg på en första plats har tappat ganska mycket, och att den mest populära modellen för kodagenter, Claude 4 Sonnet, ligger ganska långt ifrån toppen.
-->

---

## Att välja modell

- Benchmarks säger någonting, men långt ifrån allt.
<!--
Resultaten från såna här evalueringar används ofta i marknadsföringssyfte och det finns risk för att företagen har anpassat sina modeller för att bättre klara av frågor som är väldigt lika dem i dessa tester, eller att de exakta frågorna har funnits med i träningsdatan.
-->
- Det finns ingen modell som är bäst på allt.
<!--
Olika användningsområden kräver olika modeller.

Du kommer inte vilja använda samma modell för att göra en snabb kodändring över ett par markerade rader, som den du använder för att rådfråga om en komplex arkitektursfråga.
-->

- Svarskvalitet är inte det enda att ta hänsyn till, även hastighet och kostnad spelar roll.
<!--
Det är alltid en balansgång mellan dessa faktorer.

Om du startar en agent som arbetar i bakgrunden medan du själv jobbar med något annat, så bryr du dig förmodligen inte om hastigheten, kvaliteten är viktigast. Men om det är en ändring på koden du sitter med just nu så spelar det större roll.
-->

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
