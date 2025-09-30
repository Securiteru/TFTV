# Terror from the Void (TFTV)

[![GitHub release (latest by date)](https://img.shields.io/github/v/release/Voland163/TFTV)](https://github.com/Voland163/TFTV/releases)
[![GitHub issues](https://img.shields.io/github/issues/Voland163/TFTV)](https://github.com/Voland163/TFTV/issues)
[![Discord](https://img.shields.io/discord/772851297649860628?label=discord)](https://discord.gg/Ypt5p5trNx)

Terror from the Void is a comprehensive overhaul mod for [Phoenix Point](https://phoenixpoint.info/) that completely reimagines the vanilla experience from the ground up.

## ⚠️ Requirements

- **ALL DLC REQUIRED** - This mod requires all Phoenix Point DLCs to function properly
- **Compatible with saves from Open Beta**

## 🚫 Compatibility Notes

- **DO NOT USE** Better Enemies or Better Vehicles mods - both are already integrated into TFTV
- **NOT COMPATIBLE** with most third-party mods (some may work, but compatibility is not guaranteed)
- If you encounter issues with other mods, consider checking compatibility on our [Discord](https://discord.gg/Ypt5p5trNx)

## 📦 Installation

### Step 1: Install Mod Enabler
1. Download the [Phoenix Point Mod Enabler](https://github.com/SnapshotGames/PPModEnabler/releases/download/v.1.0/PPModEnabler.zip)
2. Extract the contents into your Phoenix Point installation root folder

### Step 2: Install TFTV
1. Download the latest release from the [releases page](https://github.com/Voland163/TFTV/releases)
2. Extract `TFTV.zip` into a folder named `TFTV` in your Phoenix Point's `Mods` folder
3. Launch Phoenix Point
4. Navigate to `Mods` in the main menu
5. Activate and customize TFTV settings
6. Start a new game

### Troubleshooting Common Issues

- **No Mods tab**: If you've previously used Modnix, run it and click "Revert"
- **Error on activation**: Exit to desktop and relaunch the game
- **Still having problems?** Visit our [Discord](https://discord.gg/Ypt5p5trNx) for support!

## ✨ Features

### 🎭 Complete Campaign Rework
- New characters, story, events, and reports with integrated lore
- Revamped Oneiric Delirium system
- Written by and for sci-fi horror fans!

### ⚔️ Redesigned Classes
- Sharply defined fighting roles with strong class identities
- Removed and rebalanced overpowered vanilla synergies
- Each class has a unique and meaningful purpose

### 👻 Revenants System
- Fight nightmarish doubles of your deceased comrades!
- Revenants are special Pandoran forms with the consciousness of fallen heroes
- They will hunt you relentlessly throughout your campaign!

### ⚙️ Modular Campaign Settings
- **Story Mode**: Super easy difficulty for narrative-focused playthroughs
- **Etremes**: Impossibly hard difficulty for the ultimate challenge
- **20+ toggles** for fine-tuning your experience
- Rebalanced difficulties (Legend = very hard, Rookie = very easy)

### 🏛️ Legacy of the Ancients Overhaul
- Redesigned missions, automata, and ancient weapons
- Unique mechanics and reworked lore integration

### 🛒 Enhanced Kaos Engines
- Massively expanded marketplace
- Purchase faction research, rebalanced Kaos weaponry, and mercenary soldiers
- Vehicles and modules extensively redesigned with specialized roles

### 🎯 Additional Features
- **All DLCs rebalanced and reintegrated**
- **UI improvements**: Loadable soldier loadouts, helmet visibility toggles, and more
- **Reworked final mission** with new mechanics and faction-based support troops
- **Void Omens**: Semi-randomized strategic modifiers representing humanity's descent into madness
- **AI fixes, stealth overhaul, and 50+ vanilla bug fixes**

## 🎮 Gameplay Tips for New Players

- **First-time TFTV players**: If you're familiar with vanilla Phoenix Point and have beaten it on any difficulty, start one level below your usual difficulty
- **New to Phoenix Point?** Start on Rookie or Veteran difficulty
- **Custom difficulty**: Use the extensive options in New Game setup to personalize your experience
- Some options can only be set when starting a new game

## 🛠️ Technical Information

### Project Structure
```
TFTV/                    # Main mod code
├── Assets/             # Game assets and resources
├── Tactical/           # Tactical battle modifications
├── Vehicles/           # Vehicle-related modifications
├── VariousAdjustments/ # Miscellaneous tweaks
└── [100+ C# source files] # Core mod functionality

ModSDK/                 # Required modding libraries
Dist/                   # Build output (TFTV.dll)
```

### Technology Stack
- **Language**: C#
- **Framework**: .NET Framework 4.7.2
- **Modding Library**: Harmony (0Harmony.dll)
- **Build System**: Visual Studio 2017+

## 🔧 Development

### Prerequisites
- Visual Studio 2017 or later
- Phoenix Point game installed
- Phoenix Point Mod Enabler

### Building from Source
1. Clone the repository
2. Open `TFTV.sln` in Visual Studio
3. Ensure ModSDK dependencies are correctly referenced
4. Build the solution (output goes to `Dist/` folder)
5. Copy `Dist/TFTV.dll` to your Phoenix Point `Mods/TFTV/` folder

### Development Setup
- The project uses Harmony for runtime patching of Phoenix Point
- Most game modifications are in the `TFTV/` directory
- Assets are stored in the `Assets/` subdirectory
- Build output includes `TFTV.dll` and associated `.pdb` files

## 🤝 Contributing

We welcome contributions from the community! Here's how you can help:

### Ways to Contribute
- **Bug Reports**: Found a bug? Report it on [GitHub Issues](https://github.com/Voland163/TFTV/issues)
- **Feature Requests**: Have ideas for improvements? Create an issue on GitHub
- **Code Contributions**: Submit pull requests with bug fixes or new features
- **Localization**: Help translate TFTV into other languages
- **Documentation**: Improve this README or our [Wiki](http://wiki.phoenixpoint.com/Terror_from_the_Void)

### Development Guidelines
1. **Test thoroughly** - ensure your changes don't break existing functionality
2. **Follow existing code style** - match the formatting and patterns used in the codebase
3. **Document your changes** - add comments explaining complex logic
4. **Update related documentation** if your changes affect user-facing features

### Getting Help
- **Discord**: Join our [Discord server](https://discord.gg/Ypt5p5trNx) for real-time discussion
- **Wiki**: Check our [wiki](http://wiki.phoenixpoint.com/Terror_from_the_Void) for detailed information
- **Issues**: Use [GitHub Issues](https://github.com/Voland163/TFTV/issues) for bug reports and feature requests

## 📚 Resources

- **📺 Trailer**: [YouTube Trailer](https://youtu.be/C4zXqvap21U?si=N4q0mnOQZQYD8hT3)
- **💬 Discord**: [Join our community](https://discord.gg/Ypt5p5trNx)
- **📖 Wiki**: [Terror from the Void Wiki](http://wiki.phoenixpoint.com/Terror_from_the_Void)
- **🐛 Issues**: [Bug Reports & Features](https://github.com/Voland163/TFTV/issues)
- **☕ Support**: [Buy me a coffee](https://www.buymeacoffee.com/voland)

## 📄 License & Credits

This project includes icons from [Game-Icons.net](https://game-icons.net/) - many thanks to the authors!

---

**TERROR FROM THE VOID** is a true reimagining of the Phoenix Point experience, made by fans who love the game. Join our community and experience Phoenix Point like never before!
