namespace ng_gen
{
    internal static class GenerateComponent
    {
        internal static async Task Run(
            string config,
            string dirPath,
            string name,
            string prefix,
            string type
            )
        {
            await FromModule(config, dirPath, name, prefix, type ?? "component");
        }

        internal static async Task FromModule(
            string config,
            string dirPath,
            string name,
            string prefix,
            string type,
            string? modulePath = null
            )
        {
            Program.ReadSettings(config);
            string outputPath = Helper.GetOutputPath(dirPath, name);
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
            string displayPath = modulePath ?? dashSingle;

            // subdirectory
            Directory.CreateDirectory(outputPath);

            // dashSingle/dashSingle.{type}.ts
            filePath = Path.Combine(outputPath, $"{dashSingle}.{type}.ts");
            content = (await Templates.GetComponentCode())
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle)
                .Replace("#dash-type#", dashType)
                .Replace("#PascalType#", pascalType)
                .Replace("#prefix#", prefix);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.{type}.ts");

            // dashSingle/dashSingle.{type}.spec.ts
            filePath = Path.Combine(outputPath, $"{dashSingle}.{type}.spec.ts");
            content = (await Templates.GetComponentTest())
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle)
                .Replace("#dash-type#", dashType)
                .Replace("#PascalType#", pascalType)
                .Replace("#camelType#", camelType);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.{type}.spec.ts");

            // dashSingle/dashSingle.{type}.scss
            filePath = Path.Combine(outputPath, $"{dashSingle}.{type}.scss");
            content = "";
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.{type}.scss");

            // dashSingle/dashSingle.{type}.html
            filePath = Path.Combine(outputPath, $"{dashSingle}.{type}.html");
            content = (await Templates.GetComponentView())
                .Replace("#dash-single#", dashSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.{type}.html");
        }
    }
}
