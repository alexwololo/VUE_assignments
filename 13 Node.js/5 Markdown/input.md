# Markdown

[Markdown](https://daringfireball.net/projects/markdown/syntax) är ett
textbaserat uppmärkningsspråk för att enkelt skapa formaterade dokument.

Markdown används ofta av utvecklare, och i kombination med till exempel GitHub.

## Konvertera en Markdown-fil till HTML

Markdown går att använda på flera sätt. Ett av dessa sätt är via
Node.js-terminalkommandot `npx` och NPM-paketet marked.

För att konvertera en Markdown-fil (till exempel `input.md`) till en HTML-fil
(till exempel `output.html`), så kan man använda växlarna `-i` (input) och `-o`
(output), till exempel så här: `npx marked -i input.md -o output.html`.

`npx` kör Node.js-program utan att de behöver installeras. `npx`-kommandon kan,
men måste inte, köras från en Node.js-projektmapp. Dock måste kommandot köras
från en mapp som innehåller en fil som matchar filnamnet i `-i`-växeln (till
exempel `input.md`).

## Vad som ska göras

Låt detta kodblock (denna uppgiftstext, alltså texten efter “Instruktioner” och
innan “Ladda upp din lösning”) ingå i en fil som heter `input.md`, och använd
sedan marked för att konvertera kodblocket till HTML. Ladda upp resultatet av
konverteringen som en fil döpt till `output.html`.

Kika också gärna på HTML-filens innehåll, och jämför det med detta kodblock.
