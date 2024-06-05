namespace ng_gen
{
    internal static class GenerateDialog
    {
        internal static async Task Run(
            string config,
            string dirPath,
            string name,
            string xlate,
            string module
            )
        {
            string? modulePath = null;
            if (module != null)
            {
                modulePath = string.Join("/", module, "dialogs");
                dirPath = dirPath == null ? modulePath : string.Join("/", dirPath, modulePath);
            }
            await FromModule(config, dirPath, name, xlate, modulePath);
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
                .Replace("#camelXlate#", camelXlate)
                .Replace("#camelName#", camelName);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.dialog.html");

            // dashName/dashName.dialog.text
            filePath = Path.Combine(outputPath, $"{dashName}.dialog.text");
            content = (await Templates.GetDialogText())
                .Replace("#camelXlate#", camelXlate)
                .Replace("#camelName#", camelName);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{displayPath}/{dashName}.dialog.text");
        }
    }
}
