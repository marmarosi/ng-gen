namespace ng_gen
{
    internal static class GeneratePage
    {
        internal static async Task Run(
            string dirPath,
            string name
            )
        {
            await FromModule(dirPath, name);
        }

        internal static async Task FromModule(
            string dirPath,
            string name,
            string? modulePath = null
            )
        {
            string outputPath = Helper.GetOutputPath(dirPath, name);
            string filePath, content;
            string dashPlural = name.ToLower();
            string pascalPlural = dashPlural.ToPascalCase();
            string camelPlural = pascalPlural.FirstCharToLowerCase();
            string dashSingle = dashPlural.ToSingle();
            string pascalSingle = pascalPlural.ToSingle();
            string camelSingle = pascalSingle.FirstCharToLowerCase();
            string displayPath = modulePath ?? dashSingle;

            // subdirectory
            Directory.CreateDirectory(outputPath);

            // dashSingle/dashSingle.page.ts
            filePath = Path.Combine(outputPath, $"{dashSingle}.page.ts");
            content = Files.PageCode
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.page.ts");

            // dashSingle/dashSingle.page.spec.ts
            filePath = Path.Combine(outputPath, $"{dashSingle}.page.spec.ts");
            content = Files.PageTest
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.page.spec.ts");

            // dashSingle/dashSingle.page.scss
            filePath = Path.Combine(outputPath, $"{dashSingle}.page.scss");
            content = "";
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.page.scss");

            // dashSingle/dashSingle.page.html
            filePath = Path.Combine(outputPath, $"{dashSingle}.page.html");
            content = Files.PageView
                .Replace("#dash-single#", dashSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.page.html");
        }
    }
}
