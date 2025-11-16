# CustomResolution – Ultrawide Fix for Verho

A BepInEx plugin that unlocks proper ultrawide resolution support and correct UI scaling for **Verho**.  
This mod forces the game to run at your monitor’s native resolution and fixes the stretched UI that appears on 21:9, 32:9, and other ultrawide setups.

---

## Features
- Forces the game to use the monitor’s native resolution  
- Fixes stretched or misaligned UI  
- Corrects CanvasScaler behavior for all resolutions  
- Works with any ultrawide or non-standard aspect ratio  
- Safe to use and does not modify game files  
- Compatible with all save files  

---

## Requirements
You must have **BepInEx 5.x (x64)** installed.

Download BepInEx here:  
https://github.com/BepInEx/BepInEx/releases

Use the x64 version

---

## Installation
1. Install BepInEx into the Verho game folder  
   (you should end up with a `BepInEx` directory and a `winhttp.dll` next to the game’s executable)

2. Download the latest release of **CustomResolution.dll**

3. Place it into:

<VerhoFolder>/BepInEx/plugins/


Create the folder if it does not exist.

4. Start the game.  
The mod will automatically apply the resolution and UI fixes.

---

## How It Works

### 1. Fixes the Resolution System
Verho uses a hardcoded, misspelled resolution function (`SetResotution`).  
The mod intercepts this call and forces Unity to apply the monitor’s real resolution:

Screen.currentResolution.width
Screen.currentResolution.height


This works even if the game does not list the resolution in its settings menu.

### 2. Fixes UI Stretching
The Unity UI in Verho is designed for 16:9 and stretches on ultrawide monitors.

The mod adjusts every root CanvasScaler by:
- Switching to `ScaleWithScreenSize`
- Setting the reference resolution to the physical screen resolution
- Matching width so the UI stays correctly proportioned

This produces stable UI across all aspect ratios.

---

## Uninstalling
Delete:

<VerhoFolder>/BepInEx/plugins/CustomResolution.dll


The game will revert to its default behavior.

---

## License
MIT License. Free to modify, fork, or include in modpacks.
