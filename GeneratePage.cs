namespace ng_gen
{
    internal static class GeneratePage
    {
        internal static async Task Run(
            string config,
            string dirPath,
            string name,
            string xlate
            )
        {
            await FromModule(config, dirPath, name, xlate);
        }

        internal static async Task FromModule(
            string config,
            string dirPath,
            string name,
            string xlate,
            string? modulePath = null
            )
        {
            Program.ReadSettings(config);
            string filePath, content;
            string dashName = name.ToLower();
            string pascalName = dashName.ToPascalCase();
            string camelName = pascalName.FirstCharToLowerCase();
            string displayPath = modulePath ?? dashName;
            string camelXlate = xlate.ToLower().ToPascalCase('/').FirstCharToLowerCase('/');

            // subdirectory
            string outputPath = Helper.GetOutputPath(dirPath, dashName);
            Directory.CreateDirectory(outputPath);

            // dashName/dashName.page.ts
            filePath = Path.Combine(outputPath, $"{dashName}.page.ts");
            content = (await Templates.GetPageCode())
                .Replace("#dash-name#", dashName)
                .Replace("#PascalName#", pascalName);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.page.ts");

            // dashName/dashName.page.spec.ts
            filePath = Path.Combine(outputPath, $"{dashName}.page.spec.ts");
            content = (await Templates.GetPageTest())
                .Replace("#dash-name#", dashName)
                .Replace("#PascalName#", pascalName);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.page.spec.ts");

            // dashName/dashName.page.scss
            filePath = Path.Combine(outputPath, $"{dashName}.page.scss");
            content = "";
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.page.scss");

            // dashName/dashName.page.html
            filePath = Path.Combine(outputPath, $"{dashName}.page.html");
            content = (await Templates.GetPageView())
                .Replace("#camelXlate#", camelXlate)
                .Replace("#camelName#", camelName);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.page.html");

            // dashName/dashName.page.text
            filePath = Path.Combine(outputPath, $"{dashName}.page.text");
            content = (await Templates.GetPageText())
                .Replace("#camelXlate#", camelXlate)
                .Replace("#camelName#", camelName)
                .Replace("#PascalName#", pascalName)
                .Replace("#dash-name#", dashName);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.page.text");
        }
    }
}
