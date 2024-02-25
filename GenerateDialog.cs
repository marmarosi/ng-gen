namespace ng_gen
{
    internal static class GenerateDialog
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

            // dashSingle/dashSingle.dialog.ts
            filePath = Path.Combine(outputPath, $"{dashSingle}.dialog.ts");
            content = Files.DialogCode
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.dialog.ts");

            // dashSingle/dashSingle.dialog.spec.ts
            filePath = Path.Combine(outputPath, $"{dashSingle}.dialog.spec.ts");
            content = Files.DialogTest
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.dialog.spec.ts");

            // dashSingle/dashSingle.dialog.scss
            filePath = Path.Combine(outputPath, $"{dashSingle}.dialog.scss");
            content = "";
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.dialog.scss");

            // dashSingle/dashSingle.v.html
            filePath = Path.Combine(outputPath, $"{dashSingle}.dialog.html");
            content = Files.DialogView
                .Replace("#dash-single#", dashSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashSingle}.dialog.html");
        }
    }
}