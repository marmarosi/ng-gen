namespace ng_gen
{
    internal static class GenerateComponent
    {
        internal static async Task Run(
            string config,
            string dirPath,
            string name,
            string xlate,
            string module,
            string prefix,
            string type
            )
        {
            string? modulePath = null;
            if (module != null)
            {
                modulePath = string.Join("/", module, "components");
                dirPath = dirPath == null ? modulePath : string.Join("/", dirPath, modulePath);
            }
            await FromModule(config, dirPath, name, xlate, prefix, type ?? "component", modulePath);
        }

        internal static async Task FromModule(
            string config,
            string dirPath,
            string name,
            string xlate,
            string prefix,
            string type,
            string? modulePath = null
            )
        {
            Program.ReadSettings(config);
            string filePath, content;
            string dashName = name.ToLower();
            string pascalName = dashName.ToPascalCase();
            string camelName = pascalName.FirstCharToLowerCase();
            string dashType = type;
            string pascalType = type.ToPascalCase();
            string camelType = pascalType.FirstCharToLowerCase();
            string camelXlate = xlate.ToLower().ToPascalCase('/').FirstCharToLowerCase('/');
            string displayPath = modulePath ?? dashName;

            // subdirectory
            string outputPath = Helper.GetOutputPath(dirPath, dashName);
            Directory.CreateDirectory(outputPath);

            // dashName/dashName.{dashType}.ts
            filePath = Path.Combine(outputPath, $"{dashName}.{dashType}.ts");
            content = (await Templates.GetComponentCode())
                .Replace("#dash-name#", dashName)
                .Replace("#PascalName#", pascalName)
                .Replace("#dash-type#", dashType)
                .Replace("#PascalType#", pascalType)
                .Replace("#prefix#", prefix);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.{dashType}.ts");

            // dashName/dashName.{dashType}.spec.ts
            filePath = Path.Combine(outputPath, $"{dashName}.{dashType}.spec.ts");
            content = (await Templates.GetComponentTest())
                .Replace("#dash-name#", dashName)
                .Replace("#PascalName#", pascalName)
                .Replace("#dash-type#", dashType)
                .Replace("#PascalType#", pascalType)
                .Replace("#camelType#", camelType);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.{dashType}.spec.ts");

            // dashName/dashName.{dashType}.scss
            filePath = Path.Combine(outputPath, $"{dashName}.{dashType}.scss");
            content = "";
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.{dashType}.scss");

            // dashName/dashName.{dashType}.html
            filePath = Path.Combine(outputPath, $"{dashName}.{dashType}.html");
            content = (await Templates.GetComponentView())
                .Replace("#camelXlate#", camelXlate)
                .Replace("#camelName#", camelName);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.{dashType}.html");

            // dashName/dashName.{dashType}.text
            filePath = Path.Combine(outputPath, $"{dashName}.{dashType}.text");
            content = (await Templates.GetComponentText())
                .Replace("#camelXlate#", camelXlate)
                .Replace("#camelName#", camelName)
                .Replace("#PascalName#", pascalName)
                .Replace("#dash-name#", dashName);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.{dashType}.text");
        }
    }
}
