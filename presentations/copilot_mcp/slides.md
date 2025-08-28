---
marp: true
theme: gaia
---

# AI för utvecklare

- Kommer vi bli överflödiga?
---
# AI för utvecklare

- Kommer vi bli överflödiga?
- Antagligen inte
---
# AI för utvecklare

- Kommer vi bli överflödiga?
- Antagligen inte
- (eller?)
---

# Användningsfall: Kod

Generera, refaktorera och migrera kod. AI:n är bäst när den får arbeta med små, fokuserade kodstycken. Genom att ge tydliga instruktioner via signaturer och kommentarer kan du styra resultatet med hög precision.

> *Refaktorera den här funktionen så att den använder async/await istället för promises.*

---

# Användningsfall: Tester

Skapa enhetstester, scenariotester och testdata. AI kan snabbt generera boilerplate-kod och hjälpa dig att täcka olika edge-cases som du kanske inte tänkt på.

> *Generera ett enhetstest för `getUserById`-funktionen. Inkludera ett mock-objekt för `UserRepository` och testa fallet där användaren inte finns.*

---

# Användningsfall: Dokumentation

Skapa och uppdatera READMEs, API-dokumentation och release notes. Se till att ge AI:n källor (t.ex. kod, commit-historik) för att hålla informationen korrekt och relevant.

> *Skriv release notes för version 2.1 baserat på de senaste committarna i Git.*

---

# Användningsfall: Support & Q&A

Bygg en intern kunskapsbot (med RAG) som kan svara på frågor om er kodbas, dokumentation eller interna processer. Detta minskar tiden utvecklare lägger på att leta efter information.

> *Hur sätter jag upp ett nytt projekt enligt våra interna riktlinjer?*

---

# Användningsfall: Automation

Skapa skript för att automatisera återkommande uppgifter, t.ex. att generera databasmigreringar, konfigurationsfiler eller bygga och publicera artefakter.

> *Skriv ett shell-skript som bygger Docker-imagen, taggar den med nuvarande version från `package.json` och pushar den till vårt container-register.*

---

# Användningsfall: Datafrågor

Få hjälp med att formulera komplexa databasfrågor eller skapa sammanfattningar från stora datamängder. Kräv alltid källhänvisning för att kunna verifiera resultatet.

> *Ge mig en SQL-fråga som visar de fem mest sålda produkterna under Q2, joinat med kundens region.*

---

# Användningsfall: Modernisering

Planera och genomför migreringar mellan ramverk eller språk. AI kan skapa en stegvis plan, konvertera kod och hjälpa till med verifiering efter varje steg.

> *Skapa en plan för att migrera vår Express.js-app till Next.js. Börja med att konvertera `auth.js`-modulen.*

---

# Användningsfall: Kodsök & Insikt

Ställ frågor till stora och okända kodbaser för att snabbt få en överblick. AI kan hjälpa till att identifiera risker, kodduplicering eller potentiella buggar.

> *Finns det några funktioner i den här kodbasen som skriver direkt till `localStorage` utan validering? Peka ut var.*

---

# Chatta med AI:n

Vad ska man tänka på när man interagerar med AI:n?

---

# Princip: Sätt kontext och mål

> Jag vill lägga till en funktion i `user-service.ts`. Den ska hämta en användare via ID med `getUserById(id: string)`.

---

# Princip: Lista krav & edge-cases

> **Krav:**
> - Returnera `null` om användaren inte finns.
> - Kasta `BadRequestError` vid ogiltigt ID.
> - Använd `UserRepository` för databasen.

---

# Princip: Be om plan, sedan kod

> **Du:** Ge mig en plan för hur du implementerar detta.
>
> **AI:** *1. Validera ID. 2. Anropa repository. 3. Hantera null-svar.*
>
> **Du:** Bra, implementera steg 1 och 2.

---

# Princip: Håll diffar små

> Fokusera *enbart* på att lägga till `getUserById` i `user-service.ts`. Ändra inga andra filer eller funktioner just nu.



---

# Verifiering: Definiera outputformat

> Generera en lista över alla användare som en JSON-array. Varje objekt ska innehålla `id`, `name` och `email`.

---

# Verifiering: Kräv tester & reflektion

> Skapa enhetstester för funktionen. Täck fallet där användaren finns och inte finns. Reflektera över varför du valde den implementationen.

---

# Verifiering: Be om kontrollfrågor

> Vilka antaganden gör du om databasmodellen? Finns det några beroenden jag bör känna till innan du skriver koden?

---

# Parametrar: System-prompts & JSON-läge

> **System:** Du är en expert på TypeScript.
>
> **User:** Generera en funktion som validerar ett lösenord. Svara med ett JSON-objekt: `{ "isValid": boolean, "errors": string[] }`.

---

# GitHub Copilot – Editor & Chat

- Inline: signatur/kommentarer → bättre förslag.
- Chat: förklara kod, generera tests/docs, refaktorera.
- Markera relevant kod/fil för kontext.
- Be om alternativ + tradeoffs.
- Snabba iterationer: acceptera → kör tester.

---


# MCP: Vad är det?

Ett öppet protokoll som standardiserar hur AI-assistenter ansluter till och använder externa verktyg, datakällor och system.

Tänk "USB för AI": en gemensam kontakt som låter vilken AI som helst prata med vilket system som helst på ett säkert och förutsägbart sätt.

---

# MCP: Varför behövs det?

- **Standardisering:** Skapar ett gemensamt språk som undviker inlåsning till en specifik AI-leverantör.
- **Säkerhet:** Ger full kontroll över vilken data och vilka funktioner som exponeras. Känslig information lämnar aldrig din miljö.
- **Portabilitet:** Verktyg byggda för en AI-assistent kan enkelt återanvändas av en annan.

---

# MCP: Hur fungerar det?

1. **Provider (MCP-server):** Ett system exponerar en meny av `tools` (funktioner) och `resources` (data).
2. **Klient (AI-assistent):** AI:n ansluter till servern och lär sig vilka verktyg som finns.
3. **Anrop:** När användaren ber om något anropar AI:n rätt verktyg via protokollet och får tillbaka ett resultat.

---

# MCP: Exempel på verktyg

- **Kodsök:** *"Hitta alla funktioner som anropar 'calculatePrice' i vår kodbas."*
- **DevOps:** *"Skapa en ny bugg i Jira för det här felet."*
- **Interna API:er:** *"Hämta kunddata för ID 123 från vårt CRM-system."*
- **Databasfrågor:** *"Visa försäljningssiffror för Q2 från produkt-databasen."*

---

# MCP: Största fördelarna

- **Återanvändning:** Processer och verktyg kan delas i hela organisationen.
- **Effektivitet:** Utvecklare kan bygga kraftfulla, kontextmedvetna AI-flöden som är skräddarsydda för interna system.
- **Kontroll:** Företaget behåller full suveränitet över sin data och vilka operationer som är tillåtna.
