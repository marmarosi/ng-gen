namespace ng_gen
{
    internal static class GenerateModule
    {
        internal static async Task Run(
            string dirPath,
            string name,
            string prefix
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

            // dashPlural.routes.ts
            filePath = Path.Combine(outputPath, $"{dashPlural}.routes.ts");
            content = Files.Routes;
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/{dashPlural}.routes.ts");

            // dashPlural.module.ts
            filePath = Path.Combine(outputPath, $"{dashPlural}.module.ts");
            content = Files.Module
                .Replace("#dash-plural#", dashPlural)
                .Replace("#PascalPlural#", pascalPlural);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/{dashPlural}.module.ts");

            // subdirectories
            Directory.CreateDirectory(Path.Combine(outputPath, "components"));
            Directory.CreateDirectory(Path.Combine(outputPath, "dialogs"));
            Directory.CreateDirectory(Path.Combine(outputPath, "models"));
            Directory.CreateDirectory(Path.Combine(outputPath, "pages"));
            Directory.CreateDirectory(Path.Combine(outputPath, "services"));
            Directory.CreateDirectory(Path.Combine(outputPath, "services/interfaces"));

            // components/index.ts
            filePath = Path.Combine(outputPath, $"components/index.ts");
            content = Files.ComponentIndex
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/components/index.ts");

            // components/dashSingle/*
            string componentPath1 = string.Join("/", dashPlural, "components");
            string componentPath2 = Path.Combine(dirPath ?? "", componentPath1);
            await GenerateComponent.FromModule(componentPath2, dashSingle, prefix, "component", componentPath1);

            // dialogs/index.ts
            filePath = Path.Combine(outputPath, $"dialogs/index.ts");
            content = Files.DialogIndex
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/dialogs/index.ts");

            // dialogs/dashSingle/*
            string dialogPath1 = string.Join("/", dashPlural, "dialogs");
            string dialogPath2 = Path.Combine(dirPath ?? "", dialogPath1);
            await GenerateDialog.FromModule(dialogPath2, dashSingle, dialogPath1);

            // models/index.ts
            filePath = Path.Combine(outputPath, $"models/index.ts");
            content = Files.ModelIndex
                .Replace("#PascalSingle#", pascalSingle)
                .Replace("#dash-single#", dashSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/models/index.ts");

            // models/actions.ts
            filePath = Path.Combine(outputPath, $"models/actions.ts");
            content = Files.Actions
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/models/actions.ts");

            // models/dialog.data.ts
            filePath = Path.Combine(outputPath, $"models/{dashSingle}.data.ts");
            content = Files.DialogData
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/models/{dashSingle}.data.ts");

            // models/dashSingle.ts
            filePath = Path.Combine(outputPath, $"models/{dashSingle}.ts");
            content = Files.Model
                .Replace("#camelPlural#", camelPlural)
                .Replace("#camelSingle#", camelSingle)
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/models/{dashSingle}.ts");

            // pages/index.ts
            filePath = Path.Combine(outputPath, $"pages/index.ts");
            content = Files.PageIndex
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/pages/index.ts");

            // pages/dashSingle/*
            string pagePath1 = string.Join("/", dashPlural, "pages");
            string pagePath2 = Path.Combine(dirPath ?? "", pagePath1);
            await GeneratePage.FromModule(pagePath2, dashSingle, pagePath1);

            // services/index.ts
            filePath = Path.Combine(outputPath, $"services/index.ts");
            content = Files.ServiceIndex
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/services/index.ts");

            // services/dashSingle.api.ts
            // services/dashSingle.navigator.ts
            string servicePath1 = string.Join("/", dashPlural, "services");
            string servicePath2 = Path.Combine(dirPath ?? "", servicePath1);
            await GenerateService.FromModule(servicePath2, dashSingle, "api", servicePath1);
            await GenerateService.FromModule(servicePath2, dashSingle, "navigator", servicePath1);

            // services/interfaces/index.ts
            filePath = Path.Combine(outputPath, $"services/interfaces/index.ts");
            content = Files.InterfacesIndex
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/services/interfaces/index.ts");

            // services/interfaces/dashSingle.ts
            filePath = Path.Combine(outputPath, $"services/interfaces/{dashSingle}.ts");
            content = Files.ModelDto
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/services/interfaces/{dashSingle}.ts");

            // services/interfaces/dashSingle-list-item.ts
            filePath = Path.Combine(outputPath, $"services/interfaces/{dashSingle}-list-item.ts");
            content = Files.ModelListItemDto
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/services/interfaces/{dashSingle}-list-item.ts");

            // services/interfaces/dashSingle-view.ts
            filePath = Path.Combine(outputPath, $"services/interfaces/{dashSingle}-view.ts");
            content = Files.ModelViewDto
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/services/interfaces/{dashSingle}-view.ts");
        }
    }
}
