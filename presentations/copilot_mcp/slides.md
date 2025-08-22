---
marp: true
theme: gaia
---

# AI – Use cases (1/2)

- Kod: generera/refaktorera/migrera – små diffar, signaturer/kommentarer styr.
- Tester: skapa enhets-/scenario‑tester, testdata och mocks.
- Dokumentation: README, API‑docs, release notes; håll källor/länkar.
- Support/Q&A: intern kunskapsbot (RAG) mot dokument/kod.

---

# AI – Use cases (2/2)

- Automation: skapa skript/CLI:er, generera migrations/konfigurationer.
- Datafrågor: SQL‑förslag, rapporter/sammanfattningar med källhänvisning.
- Modernisering: ramverks‑/språkmigreringar med stegvis plan + verifiering.
- Kodsök/insikt: fråga stora kodbaser; peka ut risker/duplicering.

---

# Chatta med AI – Principer

- Sätt kontext + mål; filnamn/scope.
- Lista krav/constraints + edge‑cases.
- Be om plan → be om kod; iterera med feedback.
- Håll diffar små; en fil/funktion åt gången.
- Länka till källor/issue/story för sammanhang.

---

# Chatta med AI – Verifiering & parametrar

- Definiera outputformat (JSON/MD/kodfil).
- Kräv tests/reflektion/källor för verifierbarhet.
- Be om kontrollfrågor/antaganden i slutet.
- Temperatur låg för determinism.
- System/roll‑instruktioner och JSON‑läge vid behov.

---

# GitHub Copilot – Editor & Chat

- Inline: signatur/kommentarer → bättre förslag.
- Chat: förklara kod, generera tests/docs, refaktorera.
- Markera relevant kod/fil för kontext.
- Be om alternativ + tradeoffs.
- Snabba iterationer: acceptera → kör tester.

---

# MCP

- Vad: öppet protokoll som kopplar AI ↔ verktyg/data/system.
- Varför: standard, säkerhet, portabilitet.
- Hur: MCP‑server exponerar tools/resources/prompts; klient ansluter.
- Exempel: kodsök, DevOps/Jira/GitHub, interna API:er, DB‑läsning.
- Fördelar: återanvändning av processer och effektivitet.
