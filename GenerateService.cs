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

            // dashSingle.{type}.ts
            filePath = Path.Combine(outputPath, $"{dashSingle}.{type}.ts");
            switch (type.ToLower())
            {
                case "api":
                    content = Files.ApiCode
                        .Replace("#PascalSingle#", pascalSingle)
                        .Replace("#PascalType#", pascalType)
                        .Replace("#camelSingle#", camelSingle);
                    break;
                case "navigator":
                    content = Files.NavigatorCode
                        .Replace("#PascalSingle#", pascalSingle)
                        .Replace("#dash-single#", dashSingle);
                    break;
                default:
                    content = Files.ServiceCode
                        .Replace("#PascalSingle#", pascalSingle)
                        .Replace("#PascalType#", pascalType);
                    break;
            }
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}{dashSingle}.{type}.ts");

            // dashSingle.{type}.spec.ts
            filePath = Path.Combine(outputPath, $"{dashSingle}.{type}.spec.ts");
            switch (type.ToLower())
            {
                case "api":
                    content = Files.ApiTest
                        .Replace("#PascalSingle#", pascalSingle)
                        .Replace("#dash-single#", dashSingle);
                    break;
                case "navigator":
                    content = Files.NavigatorTest
                        .Replace("#PascalSingle#", pascalSingle)
                        .Replace("#dash-single#", dashSingle)
                        .Replace("#camelSingle#", camelSingle);
                    break;
                default:
                    content = Files.ServiceTest
                        .Replace("#dash-single#", dashSingle)
                        .Replace("#PascalSingle#", pascalSingle)
                        .Replace("#dash-type#", dashType)
                        .Replace("#PascalType#", pascalType)
                        .Replace("#camelType#", camelType);
                    break;
            }
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}{dashSingle}.{type}.spec.ts");
        }
    }
}
