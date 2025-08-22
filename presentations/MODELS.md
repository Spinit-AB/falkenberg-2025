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

- **Syfte**: Förstå skillnader mellan olika språkmodeller och när man ska välja vilken typ av modell.

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

## Andra faktorer

- **Context window**: hur många tokens _(1 token ≈ 3–5 tecken)_ modellen kan hantera samtidigt.
<!--
Alltså hur mycket text du kan skicka med i en fråga. Detta börjar spela roll om du t.ex. vill skicka med stora delar av en kodbas, loggar, dokumentation eller andra långa texter.

Idag så klarar de mest populära modellerna stora context windows. Claude 4 Sonnet och Gemini 2.5 Pro klarar t.ex. en miljon tokens vilket motsvarar ungefär 100 000 rader kod. GPT-5 klarar 400 000 tokens.
-->

- **Säkerhet**: var skickas din data?
<!--
Här är det egentligen inte modellen som spelar någon roll, utan det är vem som servear modellen till dig. Modellen är i stort sett bara ett enormt antal vektorer och utgör i sig ingen fara.

Så t.ex. är det säkert att använda kinesiska modeller bara den serveas utav en pålitlig leverantör som t.ex. Microsoft via Azure eller Amazon via AWS.
-->

- **Function/tool calling**: behöver du att modellen klarar av att använda externa verktyg?
<!--
Om du ska använda modellen i agenter så som t.ex. Copilot är detta ofta avgörande och det kan skilja väldigt mycket mellan olika modeller.
-->

---

## Tool calling

- **Vad är tool calling?** Modellen anropar definierade verktyg med strukturerade argument för att t.ex. söka/läsa/skriva filer, köra kommandon eller skicka ett meddelande i Slack.
<!--
I Copilot‑kodagenten i VS Code innebär det att modellen själv väljer när den ska använda t.ex. kodsökning, öppna/läsa/skriva filer, köra tester eller git‑kommandon. Du beskriver målet; modellen planerar och orkestrerar anropen.
-->

- Stor skillnad mellan modeller.
<!--
Claude-modellerna från Anthropic är väldigt bra på tool calling och att följa instruktioner, och har varit det ganska länge nu. Detta är anledningen till att Claude-modellerna är så populära att använda i agenter och kodgenereringsverktyg.

Men detta är något som alla har börjat fokusera mer på och prioritera när modellerna tränas, så många av de nyare modellerna är ganska bra på detta, och det spelar också väldigt stor roll hur modellerna promptas för tool calling.
-->

---

## Vad är en reasoning‑modell?

- Många av de nya modellerna idag är reasoning‑modeller.
<!--
Nästan alla flaggskeppsmodeller är idag reasoning‑modeller; Så som GPT-5, Gemini 2.5 Pro och Claude 4 Sonnet/Opus, även om både GPT-5 och Claude 4 Sonnet också har en non‑reasoning-variant.
-->

- Är tränade på att bryta ned problem i mindre delar och tänka stegvis.

- Resonerandet blir en del av modellens svar.
<!--
Att se hur modellen har resonerat på vägen till svaret kan ofta vara intressant. Tyvärr så döljer många providers detta, eller presenterar bara en summering av resonemanget.
-->

- Starkare på oklara, flerstegs‑ och öppna problem.

- Långsammare och dyrare.
<!--
Skillnaden i pris kan vara väldigt stor.

Att köra de benchmarks som ligger bakom rankingen jag visade tidigare kostar t.ex. sex gånger så mycket med reasoning-varianten av Claude 4 Sonnet som med non-reasoning-varianten.
-->

---

TODO ALLT NEDAN HÄR!

## När ska man välja reasoning?

- När uppgiften är flerstegs eller oklar: design, arkitektur, rotorsaker, nya domäner.

- När verktyg/agent‑flöden kräver planering över flera anrop.

- När kvalitet prioriteras över hastighet och kostnad.

---

## När välja icke‑reasoning / liten modell?

- Snabba ändringar nära markören: små kodfixar, docstrings, enklare frågor.
<!--
Du vill ha reaktivitet och låg latens i editorn.
-->

- Interaktiv IDE‑assist: completion, rename, enkla refactorings.
<!--
Uppgifterna är väldefinierade och lokala.
-->

- Kostnadskänsliga batcher: summera, extrahera, skanna loggar/diffar.
<!--
Volym viktigare än toppkvalitet per enskilt svar.
-->

---

## Sammanfattning

- Välj modell efter uppgift: balansera kvalitet, hastighet och kostnad.
<!--
Det finns ingen bästa modell – bara rätt modell för problemet.
-->

- Reasoning för komplexitet/planering; non‑reasoning för snabbhet.
<!--
Trade‑offen är kärnan: använd båda där de skiner.
-->
