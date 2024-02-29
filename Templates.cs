namespace ng_gen
{
    internal static class Templates
    {
        private static bool pathIsSet = false;
        private static string? templatePath = null;

        internal static async Task<string> GetRoutes()
        {
            return await GetContent(Files.Routes, "templates.routes.ts");
        }

        internal static async Task<string> GetModule()
        {
            return await GetContent(Files.Module, "templates.module.ts");
        }

        #region Components

        internal static async Task<string> GetComponentIndex()
        {
            return await GetContent(Files.ComponentIndex, "components\\index.ts");
        }

        internal static async Task<string> GetComponentCode()
        {
            return await GetContent(Files.ComponentCode, "components\\template\\template.component.ts");
        }

        internal static async Task<string> GetComponentTest()
        {
            return await GetContent(Files.ComponentTest, "components\\template\\template.component.spec.ts");
        }

        internal static async Task<string> GetComponentView()
        {
            return await GetContent(Files.ComponentView, "components\\template\\template.component.html");
        }

        internal static async Task<string> GetComponentText()
        {
            return await GetContent(Files.ComponentText, "components\\template\\template.component.text");
        }

        #endregion

        #region Dialogs

        internal static async Task<string> GetDialogIndex()
        {
            return await GetContent(Files.DialogIndex, "dialogs\\index.ts");
        }

        internal static async Task<string> GetDialogCode()
        {
            return await GetContent(Files.DialogCode, "dialogs\\template\\template.dialog.ts");
        }

        internal static async Task<string> GetDialogTest()
        {
            return await GetContent(Files.DialogTest, "dialogs\\template\\template.dialog.spec.ts");
        }

        internal static async Task<string> GetDialogView()
        {
            return await GetContent(Files.DialogView, "dialogs\\template\\template.dialog.html");
        }

        internal static async Task<string> GetDialogText()
        {
            return await GetContent(Files.DialogText, "dialogs\\template\\template.dialog.text");
        }

        #endregion

        #region Models

        internal static async Task<string> GetModelIndex()
        {
            return await GetContent(Files.ModelIndex, "models\\index.ts");
        }

        internal static async Task<string> GetActions()
        {
            return await GetContent(Files.Actions, "models\\actions.ts");
        }

        internal static async Task<string> GetDialogData()
        {
            return await GetContent(Files.DialogData, "models\\template.data.ts");
        }

        internal static async Task<string> GetModel()
        {
            return await GetContent(Files.Model, "models\\template.model.ts");
        }

        #endregion

        #region Pages

        internal static async Task<string> GetPageIndex()
        {
            return await GetContent(Files.PageIndex, "pages\\index.ts");
        }

        internal static async Task<string> GetPageCode()
        {
            return await GetContent(Files.PageCode, "pages\\template\\template.page.ts");
        }

        internal static async Task<string> GetPageTest()
        {
            return await GetContent(Files.PageTest, "pages\\template\\template.page.spec.ts");
        }

        internal static async Task<string> GetPageView()
        {
            return await GetContent(Files.PageView, "pages\\template\\template.page.html");
        }

        internal static async Task<string> GetPageText()
        {
            return await GetContent(Files.PageText, "pages\\template\\template.page.text");
        }

        #endregion

        #region Services

        internal static async Task<string> GetServiceIndex()
        {
            return await GetContent(Files.ServiceIndex, "services\\index.ts");
        }

        internal static async Task<string> GetServiceCode()
        {
            return await GetContent(Files.ServiceCode, "services\\template.service.ts");
        }

        internal static async Task<string> GetServiceTest()
        {
            return await GetContent(Files.ServiceTest, "services\\template.service.spec.ts");
        }

        internal static async Task<string> GetApiCode()
        {
            return await GetContent(Files.ApiCode, "services\\template.api.ts");
        }

        internal static async Task<string> GetApiTest()
        {
            return await GetContent(Files.ApiTest, "services\\template.api.spec.ts");
        }

        internal static async Task<string> GetNavigatorCode()
        {
            return await GetContent(Files.NavigatorCode, "services\\template.navigator.ts");
        }

        internal static async Task<string> GetNavigatorTest()
        {
            return await GetContent(Files.NavigatorTest, "services\\template.navigator.spec.ts");
        }

        #endregion

        #region Interfaces

        internal static async Task<string> GetInterfacesIndex()
        {
            return await GetContent(Files.InterfacesIndex, "services\\interfaces\\index.ts");
        }

        internal static async Task<string> GetModelDto()
        {
            return await GetContent(Files.ModelDto, "services\\interfaces\\template.dto.ts");
        }

        internal static async Task<string> GetModelListItemDto()
        {
            return await GetContent(Files.ModelListItemDto, "services\\interfaces\\template-list-item.dto.ts");
        }

        internal static async Task<string> GetModelViewDto()
        {
            return await GetContent(Files.ModelViewDto, "services\\interfaces\\template-view.dto.ts");
        }

        #endregion

        #region Helper methods

        private static async Task<string> GetContent(
            string defaultContent,
            string templateFilename
            )
        {
            SetTemplatePath();
            if (templatePath == null)
                return defaultContent;
            else
            {
                var content = await Helper.ReadFile(Path.Combine(templatePath, templateFilename));
                return string.IsNullOrWhiteSpace(content) ? defaultContent : content;
            }
        }

        private static void SetTemplatePath()
        {
            if (pathIsSet) return;
            if (string.IsNullOrWhiteSpace(Program.TemplatePath)) return;

            string currentDir = Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location
                );

            string templateDir = Program.TemplatePath.Trim();
            if (templateDir.StartsWith('.'))
            {
                templateDir = Path.Combine(currentDir!, templateDir);
            }
            if (Directory.Exists(templateDir))
            {
                var dirInfo = new DirectoryInfo(templateDir);
                templateDir = dirInfo.FullName;
            }
            else
                throw new DirectoryNotFoundException($"Template directory not found: {templateDir}");

            templatePath = templateDir;

            pathIsSet = true;
        }
    }

    #endregion
}
