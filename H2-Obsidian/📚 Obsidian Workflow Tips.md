# 📚 Obsidian Workflow Tips

## 🎯 Effektive Workflows

### 1. 📝 Note-Taking Workflow
1. **Inbox note** - Skriv hurtige tanker her først
2. **Process** - Flyt information til relevante permanent notes
3. **Link** - Forbind til eksisterende noter
4. **Tag** - Tilføj relevante tags for senere søgning

### 2. 🔄 Daily Review Workflow
- Åbn daily note (`Ctrl+T` hvis Daily Notes er aktiveret)
- Review igår's action items
- Planlæg dagens opgaver
- Link til relevante projekt noter

### 3. 📊 Project Management
```
Projekter/
├── H2-Projekt/
│   ├── 📋 Project Overview.md
│   ├── ✅ Tasks.md
│   ├── 📅 Timeline.md
│   └── 📝 Meeting Notes/
```

### 4. 🧠 Zettelkasten Method
- **Permanent notes** - Ét koncept per note
- **Literature notes** - Resumé af kilder
- **Fleeting notes** - Hurtige tanker
- **Index notes** - Oversigt over emner

## 🔧 Avancerede Teknikker

### Canvas Feature
Brug Canvas til at:
- Visualisere projekt flows
- Brainstorm sessions
- Mind mapping
- System diagrammer

### MOCs (Maps of Content)
Opret "hub" notes der linker til relaterede emner:

```markdown
# H2 Projekt MOC

## Backend
- [[Backend-API/C-Sharp Web API]]
- [[Database Design]]
- [[API Testing]]

## Frontend  
- [[Frontend-Blazor/Blazor WASM]]
- [[UI Components]]
- [[User Experience]]

## DevOps
- [[Docker Setup]]
- [[CI/CD Pipeline]]
```

### Smart Searches
Gem ofte brugte søgninger:
```
path:"H2-Projekt" (file.mtime > date(today) - dur(7 days))
```

### Folder Structure Tips
```
📁 00-Inbox/          # Nye, uorganiserede noter
📁 01-Projects/        # Aktive projekter
📁 02-Areas/          # Løbende ansvar
📁 03-Resources/      # Reference materiale  
📁 04-Archive/        # Afsluttede ting
```

## 🎨 Customization

### CSS Snippets
Tilføj custom styling i `.obsidian/snippets/`:

```css
/* Bedre heading styling */
.markdown-preview-view h1 {
    border-bottom: 2px solid var(--accent-color);
    padding-bottom: 5px;
}

/* Highlight tags */
.tag {
    background: var(--accent-color);
    color: white;
    padding: 2px 6px;
    border-radius: 12px;
}
```

### Hotkey Customization
Sæt dine egne shortcuts op under Settings > Hotkeys

---

> [!TIP] Pro Tip
> Start simpelt og byg complexity over tid. Obsidian er kraftfuldt, men kan blive overvældende hvis du prøver alt på én gang!

**Tags:** #obsidian #workflow #productivity #tips
