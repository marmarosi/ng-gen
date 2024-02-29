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

            // dashSingle/dashSingle.{dashType}.ts
            filePath = Path.Combine(outputPath, $"{dashSingle}.{dashType}.ts");
            content = (await Templates.GetComponentCode())
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle)
                .Replace("#dash-type#", dashType)
                .Replace("#PascalType#", pascalType)
                .Replace("#prefix#", prefix);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.{dashType}.ts");

            // dashSingle/dashSingle.{dashType}.spec.ts
            filePath = Path.Combine(outputPath, $"{dashSingle}.{dashType}.spec.ts");
            content = (await Templates.GetComponentTest())
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle)
                .Replace("#dash-type#", dashType)
                .Replace("#PascalType#", pascalType)
                .Replace("#camelType#", camelType);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.{dashType}.spec.ts");

            // dashSingle/dashSingle.{dashType}.scss
            filePath = Path.Combine(outputPath, $"{dashSingle}.{dashType}.scss");
            content = "";
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.{dashType}.scss");

            // dashSingle/dashSingle.{dashType}.html
            filePath = Path.Combine(outputPath, $"{dashSingle}.{dashType}.html");
            content = (await Templates.GetComponentView())
                .Replace("#dash-single#", dashSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.{dashType}.html");

            // dashSingle/dashSingle.{dashType}.text
            filePath = Path.Combine(outputPath, $"{dashSingle}.{dashType}.text");
            content = (await Templates.GetComponentText())
                .Replace("#camelSingle#", camelSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.{dashType}.text");
        }
    }
}
