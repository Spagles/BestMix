# GitHub Copilot Instructions for Best Mix (Continued) Mod

## Mod Overview and Purpose

Best Mix (Continued) is a quality-of-life mod for RimWorld that enhances the way benches select ingredients for crafting tasks. In addition to the vanilla behavior of searching for the nearest ingredients, this mod introduces a variety of filters that allow users to choose ingredients based on different criteria, such as beauty, insulation properties, cost, and more. These filters can be applied globally via a gizmo on workbenches or overridden on a per-bill basis where necessary.

## Key Features and Systems

- **Ingredient Selection Filters**: A set of filters for selecting ingredients based on various criteria, such as:
  - Beauty (Prettiest/Ugliest)
  - Insulation (Cold/Heat)
  - Item Conditions (Ignition, Damaged, Expiry, Robust)
  - Mass (Heaviest/Lightest)
  - Temperature (Coldest/Warmest)
  - Value (Cheapest/Expensive)
  - Weapon Damage (Bluntest/Sharpest)
  - Stock (Fraction, Least, Most)
  - Default (Nearest, Random)

- **Individual Bill Settings**: Customize ingredient selection per bill.
- **Wide Compatibility**: Compatibility with RimWorld Vanilla, Combat Extended, and Multiplayer.
- **Customization Options**: Options to enable or disable mod features, specify applicable benches, and set custom behaviors for stock selection types.
- **Translation Support**: Includes Chinese language support.

## Coding Patterns and Conventions

- **Project Structure**: Organized in a modular way, separating utility functions (`BestMixUtility`), component logic (`CompBestMix`), settings (`Settings`), and Harmony patches (`HarmonyPatching`).
- **Consistency**: Adhere to C# conventions such as PascalCase for class and method names.
- **Modular Design**: Use static classes and internal visibility where necessary to encapsulate functionality appropriately.

## XML Integration

- While this mod's logic is primarily C# based, XML files are used for defining translations and potentially other configurations. It is crucial to ensure that XML keys are consistent with the C# codebase.

## Harmony Patching

- **Harmony Usage**: This mod uses Harmony to override existing game behavior without directly modifying vanilla code. Ensure patches are established and removed correctly.
- **Patch Techniques**: Focus on using prefix and postfix patches. Be cautious with transpiler patches unless absolutely necessary, due to their complexity and potential for errors.

## Suggestions for Copilot

- **Helper Methods**: Recommend the creation of helper methods to keep code DRY (Don't Repeat Yourself) and maintain clean, maintainable patches.
- **Error Handling**: Implement robust error handling to catch exceptions that might arise from mod conflicts or user interactions.
- **Debug Toggles**: Facilitate debug toggling in the `CompBestMix` class with `ToggleDebug(bool flag)` for easier development and troubleshooting.
- **Unit Testing**: Suggest adding unit tests for critical logic components, especially those involved in ingredient selection and Harmony patching.

By adhering to these guidelines and implementing the provided suggestions, contributors can effectively maintain and improve the Best Mix mod, ensuring compatibility with future RimWorld updates and other mods.
