# 🔍 Obsidian Search Examples

Obsidian har utrolig kraftfuld søgning! Her er nogle eksempler på hvad du kan gøre:

## 🎯 Basis Søgning

### Simple Searches
- `obsidian` - Find alle noter med ordet "obsidian"
- `"exact phrase"` - Find præcis denne sætning
- `API OR frontend` - Find noter med enten API eller frontend

### Wildcards
- `develop*` - Finder "development", "developer", "developing" etc.
- `*.cs` - Find alle C# filer (hvis du har dem som noter)

## 📁 Path og File Searches

### Path Searches
```
path:"Backend-API"
```
Finder alle noter i Backend-API mappen

```
path:"Frontend-Blazor" OR path:"Backend-API"
```
Finder noter i begge mapper

### File Properties
```
file:(empty)
```
Finder tomme filer

```
file:(outgoing-link)
```
Finder filer med udgående links

## 🏷️ Tag Searches

### Basic Tags
```
tag:#h2-projekt
```
Finder alle noter med dette tag

### Nested Tags
```
tag:#projekt/h2
```
Finder noter med nested tags

### Multiple Tags
```
tag:#api tag:#csharp
```
Finder noter med BEGGE tags

```
tag:#api OR tag:#frontend
```
Finder noter med ENTEN tag

## 📅 Date Searches

### Creation Date
```
created:2024-01-01
```
Finder noter oprettet på denne dato

```
created:>2024-01-01
```
Finder noter oprettet efter denne dato

### Modified Date
```
modified:today
```
Finder noter ændret i dag

```
modified:yesterday
```
Finder noter ændret i går

```
modified:>-7d
```
Finder noter ændret inden for de sidste 7 dage

## 🎨 Advanced Queries

### Kombinerede Searches
```
path:"Backend-API" tag:#csharp modified:>-30d
```
Finder C# noter i Backend-API mappen ændret i den sidste måned

### Content + Metadata
```
content:"WeatherForecast" tag:#api
```
Finder API noter der indeholder "WeatherForecast"

### Negative Searches
```
-tag:#archive
```
Finder alle noter UDEN archive tag

```
path:"Backend-API" -file:(empty)
```
Finder ikke-tomme filer i Backend-API

## 🔧 Regex Searches

Aktiver regex i search settings:

```
/\b\w+Service\b/
```
Finder alle ord der ender med "Service"

```
/TODO:.*$/
```
Finder alle TODO kommentarer

## 📊 Search Operators

| Operator | Beskrivelse | Eksempel |
|----------|-------------|----------|
| `AND` | Begge terms skal være til stede | `API AND documentation` |
| `OR` | En af terms skal være til stede | `frontend OR backend` |
| `-` | Exclude term | `-tag:#archive` |
| `"..."` | Exact phrase | `"Web API"` |
| `*` | Wildcard | `develop*` |
| `()` | Grouping | `(API OR service) tag:#backend` |

## 💡 Pro Tips

### Saved Searches
Gem ofte brugte søgninger som bookmarks i search pane.

### Search in Selection
- Marker tekst i en note
- Tryk `Ctrl+F` for at søge kun i selection

### Quick Switcher Advanced
`Ctrl+O` åbner Quick Switcher:
- Type noter navn for hurtig navigation
- Use `#` for tags: `#api`
- Use `/` for commands: `/search`

### Global Search Shortcuts
- `Ctrl+Shift+F` - Åbn global search
- `Enter` - Åbn første resultat
- `Ctrl+Enter` - Åbn i ny pane

---

> [!TIP] Øvelse gør mester
> Prøv disse searches på dine egne noter for at blive fortrolig med syntaksen!

**Tags:** #obsidian #search #tips #advanced
