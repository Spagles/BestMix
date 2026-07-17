# Copilot Instructions for Best Mix (Continued)

## Mod Overview and Purpose

**Mod Name:** Best Mix (Continued)  
**Author:** pelador  
**PackageId:** Mlie.BestMix  

The Best Mix mod is a Quality of Life enhancement for RimWorld that allows variances in how crafting workbenches select their ingredients. By providing users with a gizmo interface on workbenches, it offers alternative criteria for ingredient selection beyond the default distance-based search used by the Vanilla game. This mod is particularly beneficial for players who wish to utilize specific properties of materials for different production purposes.

## Key Features and Systems

- **Ingredient Selection Criteria:** The mod introduces multiple criteria for ingredient selection at workbenches, such as Beauty (Prettiest/Ugliest), Insulation (Cold/Heat), Flammability, Durability, and more.
- **Individual Best Mix Settings:** Customize settings for each bill, defaulting to the gizmo value if none are set.
- **Compatibility with Other Mods:** Features compatibility with mods like Combat Extended and provides native multiplayer support.
- **Mod Options:** Global settings to control the functionality across the game, including toggling the mod on/off and limiting functionality to specific benches like stoves or campfires.

## Coding Patterns and Conventions

- **Well-Structured C# Code:** The mod is organized into multiple C# files, focusing on different components like the main controller (`Controller.cs`), component properties (`CompProperties_BestMix.cs`), and Harmony patches.
- **Modular Architecture:** Use of components and properties pattern (`CompBestMix`, `CompProperties_BestMix`) to enable flexibility and reusability.
- **Consistency:** Follows standard C# naming conventions and RimWorld's mod development guidelines for readability and maintenance.

## XML Integration

- Although there are currently no XML definition files, the mod's architecture allows easy integration of XML for future features or translations.
- XML can be used in the future for defining new item types, language translations, or mod settings.

## Harmony Patching

- **Harmony Library:** The mod uses Harmony for core functionality, allowing modifications to RimWorld's original methods without altering the source code.
- **Transpiler Usage:** Features Harmony's Transpiler method for intricate patches, particularly in files like `BillStack_DoListing.cs` and `Bill_DoInterface.cs`.
- **Collaborative Development:** Contributions from developers like Taranchuk for code maintainability and Madeline for developing harmony transpiler work.

## Suggestions for Copilot

1. **Transpiler Enhancements:** Improve or assist with complex transpiler methods to provide efficient and error-free functionality.
2. **XML File Generation:** Suggest XML snippets for future translation files or configurable settings.
3. **Refactoring Suggestions:** Propose code refactoring for better performance and readability.
4. **Debugging Assistance:** Offer solutions for potential runtime errors and assist in debugging harmony patches.
5. **Documentation and Comments:** Automatically generate detailed comments and documentation for each method and class, maintaining consistency and clarity.

## Compatibility and Known Issues

- The mod is mostly compatible with other mods, though subject to issues if the mod order is incorrect.
- To diagnose mod conflicts, enable only this mod and its dependencies first, then gradually add others.
- If errors occur, use the RimWorld Log Uploader and report issues via the Discord channel, rather than starting new discussion threads.

## Credits and Acknowledgments

- **Madeline:** For her key role in developing harmony transpiler work.
- **Taranchuk and Kayedon:** For contributions to code maintainability and commissioning of work.
- **LWM and KV:** For assistance in testing and augmenting functionality.
- **Translators:** NB and NBurger500 for Chinese translation contributions.
- **Rebecca:** For French translation.

Maintained under CC BY-NC-SA 4.0 license. For best support, utilize the provided community resources like Discord and RimSort for mod sorting.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).

