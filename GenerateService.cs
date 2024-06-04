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
            string dashPlural = name.ToLower();
            string pascalPlural = dashPlural.ToPascalCase();
            string camelPlural = pascalPlural.FirstCharToLowerCase();
            string dashSingle = dashPlural.ToSingle();
            string pascalSingle = pascalPlural.ToSingle();
            string camelSingle = pascalSingle.FirstCharToLowerCase();
            string dashType = type;
            string pascalType = type.ToPascalCase();
            string camelType = pascalType.FirstCharToLowerCase();
            string displayPath = modulePath is null ? "" : modulePath + "/";

            // dashPlural.{type}.ts
            filePath = Path.Combine(outputPath, $"{dashPlural}.{dashType}.ts");
            switch (type.ToLower())
            {
                case "api":
                    content = (await Templates.GetApiCode())
                        .Replace("#PascalSingle#", pascalSingle)
                        .Replace("#dash-single#", dashSingle)
                        .Replace("#camelSingle#", camelSingle);
                    break;
                case "navigator":
                    content = (await Templates.GetNavigatorCode())
                        .Replace("#PascalSingle#", pascalSingle)
                        .Replace("#dash-single#", dashSingle);
                    break;
                default:
                    content = (await Templates.GetServiceCode())
                        .Replace("#PascalSingle#", pascalSingle)
                        .Replace("#PascalType#", pascalType);
                    break;
            }
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}{dashPlural}.{dashType}.ts");

            // dashPlural.{type}.spec.ts
            filePath = Path.Combine(outputPath, $"{dashPlural}.{dashType}.spec.ts");
            switch (type.ToLower())
            {
                case "api":
                    content = (await Templates.GetApiTest())
                        .Replace("#PascalSingle#", pascalSingle)
                        .Replace("#dash-single#", dashSingle);
                    break;
                case "navigator":
                    content = (await Templates.GetNavigatorTest())
                        .Replace("#PascalSingle#", pascalSingle)
                        .Replace("#dash-single#", dashSingle);
                    break;
                default:
                    content = (await Templates.GetServiceTest())
                        .Replace("#PascalSingle#", pascalSingle)
                        .Replace("#dash-single#", dashSingle)
                        .Replace("#PascalType#", pascalType)
                        .Replace("#dash-type#", dashType)
                        .Replace("#camelType#", camelType);
                    break;
            }
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}{dashPlural}.{dashType}.spec.ts");
        }
    }
}
