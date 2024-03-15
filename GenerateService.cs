namespace ng_gen
{
    internal static class GenerateService
    {
        internal static async Task Run(
            string config,
            string dirPath,
            string name,
            string type
            )
        {
            await FromModule(config, dirPath, name, type ?? "service");
        }

        internal static async Task FromModule(
            string config,
            string dirPath,
            string name,
            string type,
            string? modulePath = null
            )
        {
            Program.ReadSettings(config);
            string outputPath = Helper.GetOutputPath(dirPath, "");
            string filePath, content;
            string dashName = name.ToLower();
            string pascalName = dashName.ToPascalCase();
            string camelName = pascalName.FirstCharToLowerCase();
            string dashType = type;
            string pascalType = type.ToPascalCase();
            string camelType = pascalType.FirstCharToLowerCase();
            string displayPath = modulePath is null ? "" : modulePath + "/";

            // dashName.{type}.ts
            filePath = Path.Combine(outputPath, $"{dashName}.{dashType}.ts");
            switch (type.ToLower())
            {
                case "api":
                    content = (await Templates.GetApiCode())
                        .Replace("#PascalName#", pascalName)
                        .Replace("#PascalType#", pascalType)
                        .Replace("#camelName#", camelName);
                    break;
                case "navigator":
                    content = (await Templates.GetNavigatorCode())
                        .Replace("#PascalName#", pascalName)
                        .Replace("#dash-name#", dashName);
                    break;
                default:
                    content = (await Templates.GetServiceCode())
                        .Replace("#PascalName#", pascalName)
                        .Replace("#PascalType#", pascalType);
                    break;
            }
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}{dashName}.{dashType}.ts");

            // dashName.{type}.spec.ts
            filePath = Path.Combine(outputPath, $"{dashName}.{dashType}.spec.ts");
            switch (type.ToLower())
            {
                case "api":
                    content = (await Templates.GetApiTest())
                        .Replace("#PascalName#", pascalName)
                        .Replace("#dash-name#", dashName);
                    break;
                case "navigator":
                    content = (await Templates.GetNavigatorTest())
                        .Replace("#PascalName#", pascalName)
                        .Replace("#dash-name#", dashName)
                        .Replace("#camelName#", camelName);
                    break;
                default:
                    content = (await Templates.GetServiceTest())
                        .Replace("#dash-name#", dashName)
                        .Replace("#PascalName#", pascalName)
                        .Replace("#dash-type#", dashType)
                        .Replace("#PascalType#", pascalType)
                        .Replace("#camelType#", camelType);
                    break;
            }
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}{dashName}.{dashType}.spec.ts");
        }
    }
}
