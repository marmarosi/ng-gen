namespace ng_gen
{
    internal static class GenerateDialog
    {
        internal static async Task Run(
            string config,
            string dirPath,
            string name
            )
        {
            await FromModule(config, dirPath, name);
        }

        internal static async Task FromModule(
            string config,
            string dirPath,
            string name,
            string? modulePath = null
            )
        {
            Program.ReadSettings(config);
            string filePath, content;
            string dashName = name.ToLower();
            string pascalName = dashName.ToPascalCase();
            string camelName = pascalName.FirstCharToLowerCase();
            string displayPath = modulePath ?? dashName;

            // subdirectory
            string outputPath = Helper.GetOutputPath(dirPath, dashName);
            Directory.CreateDirectory(outputPath);

            // dashName/dashName.dialog.ts
            filePath = Path.Combine(outputPath, $"{dashName}.dialog.ts");
            content = (await Templates.GetDialogCode())
                .Replace("#dash-name#", dashName)
                .Replace("#PascalName#", pascalName);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.dialog.ts");

            // dashName/dashName.dialog.spec.ts
            filePath = Path.Combine(outputPath, $"{dashName}.dialog.spec.ts");
            content = (await Templates.GetDialogTest())
                .Replace("#dash-name#", dashName)
                .Replace("#PascalName#", pascalName);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.dialog.spec.ts");

            // dashName/dashName.dialog.scss
            filePath = Path.Combine(outputPath, $"{dashName}.dialog.scss");
            content = "";
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.dialog.scss");

            // dashName/dashName.dialog.html
            filePath = Path.Combine(outputPath, $"{dashName}.dialog.html");
            content = (await Templates.GetDialogView())
                .Replace("#dash-name#", dashName);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.dialog.html");

            // dashName/dashName.dialog.text
            filePath = Path.Combine(outputPath, $"{dashName}.dialog.text");
            content = (await Templates.GetDialogText())
                .Replace("#camelName#", camelName);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.dialog.text");
        }
    }
}
