# 🚀 Obsidian Funktioner Guide

Dette er en guide til nogle af de mest kraftfulde funktioner i Obsidian!

## 1. 🔗 Linking og Backlinking
Obsidian's styrke ligger i at forbinde noter:

- **Wikilinks**: [[Backend-API/C-Sharp Web API]] - linker til andre noter
- **Aliases**: [[Backend-API/C-Sharp Web API|API Dokumentation]] - custom link tekst
- **Headers**: [[#2. 📝 Tags og Organisation]] - link til specifikke sektioner
- **Blocks**: ^dette-er-et-block-id - reference specifikke afsnit

Når du linker til en note, opretter Obsidian automatisk backlinks - så du kan se hvilke noter der refererer til den aktuelle note.

## 2. 📝 Tags og Organisation

Tags hjælper med at organisere og finde noter:

#obsidian #guide #funktioner #h2-projekt

Du kan også lave nested tags:
#projekt/h2/backend
#projekt/h2/frontend
#læring/obsidian/advanced

## 3. 🔍 Queries og Søgning

Obsidian har kraftfuld søgning:

```query
tag:#obsidian
```

```query
path:"Backend-API" OR path:"Frontend-Blazor"
```

## 4. 📊 Dataview Plugin Eksempler

Hvis du aktiverer Dataview plugin, kan du lave dynamiske lister:

```dataview
LIST
FROM #h2-projekt
SORT file.mtime DESC
```

```dataview
TABLE file.mtime as "Sidst Ændret"
FROM "Backend-API" OR "Frontend-Blazor"
```

## 5. 🗂️ Templates

Templates spare tid ved at oprette konsistente noter. Se [[Templates/Møde Template]] for eksempel.

## 6. 📈 Graph View

Tryk `Ctrl+G` for at se graph view - en visual repræsentation af alle dine noter og deres forbindelser!

## 7. 🎨 Callouts

> [!NOTE] Information
> Dette er en note callout - perfekt til at fremhæve vigtig information

> [!TIP] Pro Tip
> Brug `Ctrl+P` til command palette for hurtig adgang til alle funktioner

> [!WARNING] Advarsel
> Pas på ikke at blive afhængig af for mange plugins - det kan gøre Obsidian langsom

> [!EXAMPLE] Kode Eksempel
> ```csharp
> public class WeatherForecast
> {
>     public DateTime Date { get; set; }
>     public int TemperatureC { get; set; }
> }
> ```

## 8. 🔄 Daily Notes

Aktiver Daily Notes plugin for automatisk daglige noter. Perfekt til journaling og daglig planlægning.

## 9. ⚡ Hotkeys du skal kende

- `Ctrl+N` - Ny note
- `Ctrl+O` - Åbn quick switcher
- `Ctrl+P` - Command palette
- `Ctrl+E` - Toggle edit/preview mode
- `Ctrl+G` - Graph view
- `Ctrl+Shift+F` - Global søgning
- `[[` - Start wikilink
- `Ctrl+K` - Insert link

## 10. 🧩 Plugin Anbefalinger

**Core plugins at aktivere:**
- Backlinks
- Graph view
- Page preview
- Quick switcher
- Search
- Tags view

**Community plugins at overveje:**
- Dataview - Queries og dynamisk indhold
- Calendar - Visual kalender view
- Kanban - Project management boards
- Advanced Tables - Bedre table editing
- Templater - Avancerede templates

---

^guide-footer

*Oprettet: {{date}} | Tags: #obsidian #guide*
