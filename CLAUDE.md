# CLAUDE.md — unity-game-poc

## Wiki Rules

This project uses a curated wiki at `wiki/`. Always follow these rules:

### On session start
Read `wiki/INDEX.md` before doing anything else. It lists every page and what it covers.

### Before any task
Read the wiki pages relevant to the current task before doing any external research or
implementation. The index describes each page in one line — use it to decide which pages
apply. For example:
- Working on scripts or physics → read `wiki/scripts.md`
- Setting up the scene or editor → read `wiki/scene-setup.md`
- Input not working → read `wiki/input-system.md`
- Anything about paths or syncing files → read `wiki/project-layout.md`
- Bugs or known limitations → read `wiki/known-issues.md`

### After learning something new
Update the appropriate wiki page with any new facts discovered. If a new topic emerges that
has no page, create one and add it to the index in `wiki/INDEX.md`.

### Curation rules
- Each page covers one topic. Don't spread the same fact across multiple pages.
- Lead entries with the date `<!-- YYYY-MM-DD -->` so staleness is visible.
- Write facts, not intentions. Record what is true now, not what was tried.
- If a fact changes (e.g. a bug is fixed, a path changes), update the page — don't append
  a contradicting note below the old one.
- Keep the INDEX.md description column to one line per page.

## Project Notes

- Unity 6 LTS (6000.0.74f1), URP, Personal license (no batch mode).
- Active project path: `D:\claude projects\unity-game-poc`
  Editor currently opens from: `C:\Temp\unity-game-poc` (see `wiki/project-layout.md`)
- Use `wiki/` as the source of truth before searching the web or the Unity docs.
