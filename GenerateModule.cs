namespace ng_gen
{
    internal static class GenerateModule
    {
        internal static async Task Run(
            string config,
            string dirPath,
            string name,
            string prefix,
            string index
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
            string dashIndex = index.ToLower();
            string pascalIndex = dashIndex.ToPascalCase();
            string camelIndex = pascalIndex.FirstCharToLowerCase();

            // dashPlural.routes.ts
            filePath = Path.Combine(outputPath, $"{dashPlural}.routes.ts");
            content = await Templates.GetRoutes();
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/{dashPlural}.routes.ts");

            // dashPlural.module.ts
            filePath = Path.Combine(outputPath, $"{dashPlural}.module.ts");
            content = (await Templates.GetModule())
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

            #region Components

            // components/index.ts
            filePath = Path.Combine(outputPath, $"components/index.ts");
            content = (await Templates.GetComponentIndex())
                .Replace("#dash-single#", dashIndex)
                .Replace("#PascalSingle#", pascalIndex);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/components/index.ts");

            // components/dashSingle/*
            string componentPath1 = string.Join("/", dashPlural, "components");
            string componentPath2 = Path.Combine(dirPath ?? "", componentPath1);
            await GenerateComponent.FromModule(config, componentPath2, index, prefix, "component", componentPath1);

            #endregion

            #region Dialogs

            // dialogs/index.ts
            filePath = Path.Combine(outputPath, $"dialogs/index.ts");
            content = (await Templates.GetDialogIndex())
                .Replace("#dash-single#", dashIndex)
                .Replace("#PascalSingle#", pascalIndex);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/dialogs/index.ts");

            // dialogs/dashSingle/*
            string dialogPath1 = string.Join("/", dashPlural, "dialogs");
            string dialogPath2 = Path.Combine(dirPath ?? "", dialogPath1);
            await GenerateDialog.FromModule(config, dialogPath2, index, dialogPath1);

            #endregion

            #region Models

            // models/index.ts
            filePath = Path.Combine(outputPath, $"models/index.ts");
            content = (await Templates.GetModelIndex())
                .Replace("#PascalIndex#", pascalIndex)
                .Replace("#dash-index#", dashIndex);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/models/index.ts");

            // models/actions.ts
            filePath = Path.Combine(outputPath, $"models/actions.ts");
            content = (await Templates.GetActions())
                .Replace("#PascalIndex#", pascalIndex);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/models/actions.ts");

            // models/dashIndex.data.ts
            filePath = Path.Combine(outputPath, $"models/{dashIndex}.data.ts");
            content = (await Templates.GetDialogData())
                .Replace("#PascalIndex#", pascalIndex);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/models/{dashIndex}.data.ts");

            // models/dashIndex.model.ts
            filePath = Path.Combine(outputPath, $"models/{dashIndex}.model.ts");
            content = (await Templates.GetModel())
                .Replace("#camelPlural#", camelPlural)
                .Replace("#camelIndex#", camelIndex)
                .Replace("#PascalIndex#", pascalIndex);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/models/{dashIndex}.model.ts");

            #endregion

            #region Pages

            // pages/index.ts
            filePath = Path.Combine(outputPath, $"pages/index.ts");
            content = (await Templates.GetPageIndex())
                .Replace("#dash-single#", dashIndex)
                .Replace("#PascalSingle#", pascalIndex);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/pages/index.ts");

            // pages/dashSingle/*
            string pagePath1 = string.Join("/", dashPlural, "pages");
            string pagePath2 = Path.Combine(dirPath ?? "", pagePath1);
            await GeneratePage.FromModule(config, pagePath2, index, pagePath1);

            #endregion

            #region Services

            // services/index.ts
            filePath = Path.Combine(outputPath, $"services/index.ts");
            content = (await Templates.GetServiceIndex())
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/services/index.ts");

            // services/dashSingle.api.ts
            // services/dashSingle.navigator.ts
            string servicePath1 = string.Join("/", dashPlural, "services");
            string servicePath2 = Path.Combine(dirPath ?? "", servicePath1);
            await GenerateService.FromModule(config, servicePath2, dashSingle, "api", servicePath1);
            await GenerateService.FromModule(config, servicePath2, dashSingle, "navigator", servicePath1);

            #endregion

            #region Interfaces

            // services/interfaces/index.ts
            filePath = Path.Combine(outputPath, $"services/interfaces/index.ts");
            content = (await Templates.GetInterfacesIndex())
                .Replace("#dash-single#", dashSingle)
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/services/interfaces/index.ts");

            // services/interfaces/dashSingle.dto.ts
            filePath = Path.Combine(outputPath, $"services/interfaces/{dashSingle}.dto.ts");
            content = (await Templates.GetModelDto())
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/services/interfaces/{dashSingle}.dto.ts");

            // services/interfaces/dashSingle-list-item.dto.ts
            filePath = Path.Combine(outputPath, $"services/interfaces/{dashSingle}-list-item.dto.ts");
            content = (await Templates.GetModelListItemDto())
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/services/interfaces/{dashSingle}-list-item.dto.ts");

            // services/interfaces/dashSingle-view.dto.ts
            filePath = Path.Combine(outputPath, $"services/interfaces/{dashSingle}-view.dto.ts");
            content = (await Templates.GetModelViewDto())
                .Replace("#PascalSingle#", pascalSingle);
            await Helper.WriteFile(filePath, content);
            Console.WriteLine($"{dashPlural}/services/interfaces/{dashSingle}-view.dto.ts"); 

            #endregion
        }
    }
}
