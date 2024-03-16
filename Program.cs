using System.CommandLine;
using Microsoft.Extensions.Configuration;

namespace ng_gen;

static class Program
{
    private static bool hasConfig = false;
    internal static string? OutputDirectory { get; set; }
    internal static string? TemplatePath { get; set; }

    static async Task<int> Main(string[] args)
    {
        // Define options

        var configOption = new Option<string>(
            name: "--config",
            description: "The name of the settings file without .json extension.");
        configOption.AddAlias("-c");

        var dirPathOption = new Option<string>(
            name: "--output-dir",
            description: "The path of the directory where the files will be generated.");
        dirPathOption.AddAlias("-o");

        var prefixOption = new Option<string>(
            name: "--prefix",
            description: "The HTML prefix of the Angular component.",
            getDefaultValue: () => "app");
        prefixOption.AddAlias("-p");

        var typeOption = new Option<string>(
            name: "--type",
            description: "The type of the Angular component/service.");
        typeOption.AddAlias("-t");

        var indexOption = new Option<string>(
            name: "--index",
            description: "The name of the components in the module.",
            getDefaultValue: () => "index");
        indexOption.AddAlias("-i");

        var xlateOption = new Option<string>(
            name: "--translate",
            description: "The name of the translation (.json) file.");
        xlateOption.AddAlias("-x");
        xlateOption.IsRequired = true;

        var xlateOption2 = new Option<string>(
            name: "--translate",
            description: "The name of the translation (.json) file.");
        xlateOption2.AddAlias("-x");

        // Define arguments

        var nameArgument = new Argument<string>(
            name: "name",
            description: "The name of the Angular element.");

        // Define module command

        var moduleCommand = new Command("module", "Generates a new module.");
        moduleCommand.AddAlias("m");
        moduleCommand.AddArgument(nameArgument);
        moduleCommand.AddOption(xlateOption2);
        moduleCommand.AddOption(prefixOption);
        moduleCommand.AddOption(indexOption);

        moduleCommand.SetHandler(async (config, dirPath, name, xlate, prefix, index) =>
            {
                await GenerateModule.Run(config, dirPath, name, xlate, prefix, index);
            },
            configOption, dirPathOption, nameArgument, xlateOption2, prefixOption, indexOption);

        // Define page command

        var pageCommand = new Command("page", "Generates a new page.");
        pageCommand.AddAlias("p");
        pageCommand.AddArgument(nameArgument);
        pageCommand.AddOption(xlateOption);

        pageCommand.SetHandler(async (config, dirPath, name, xlate) =>
            {
                await GeneratePage.Run(config, dirPath, name, xlate);
            },
            configOption, dirPathOption, nameArgument, xlateOption);

        // Define component command

        var componentCommand = new Command("component", "Generates a new component.");
        componentCommand.AddAlias("c");
        componentCommand.AddArgument(nameArgument);
        componentCommand.AddOption(xlateOption);
        componentCommand.AddOption(prefixOption);
        componentCommand.AddOption(typeOption);

        componentCommand.SetHandler(async (config, dirPath, name, xlate, prefix, type) =>
            {
                await GenerateComponent.Run(config, dirPath, name, xlate, prefix, type);
            },
           configOption, dirPathOption, nameArgument, xlateOption, prefixOption, typeOption);

        // Define dialog command

        var dialogCommand = new Command("dialog", "Generates a new dialog.");
        dialogCommand.AddAlias("d");
        dialogCommand.AddArgument(nameArgument);
        dialogCommand.AddOption(xlateOption);

        dialogCommand.SetHandler(async (config, dirPath, name, xlate) =>
            {
                await GenerateDialog.Run(config, dirPath, name, xlate);
            },
            configOption, dirPathOption, nameArgument, xlateOption);

        // Define service command

        var serviceCommand = new Command("service", "Generates a new service.");
        serviceCommand.AddAlias("s");
        serviceCommand.AddArgument(nameArgument);
        serviceCommand.AddOption(typeOption);

        serviceCommand.SetHandler(async (config, dirPath, name, type) =>
            {
                await GenerateService.Run(config, dirPath, name, type);
            },
            configOption, dirPathOption, nameArgument, typeOption);

        // Define root command

        var rootCommand = new RootCommand("Generates Angular files.");

        rootCommand.AddCommand(moduleCommand);
        rootCommand.AddCommand(pageCommand);
        rootCommand.AddCommand(componentCommand);
        rootCommand.AddCommand(dialogCommand);
        rootCommand.AddCommand(serviceCommand);

        rootCommand.AddGlobalOption(configOption);
        rootCommand.AddGlobalOption(dirPathOption);

        rootCommand.AddOption(xlateOption);
        rootCommand.AddOption(prefixOption);
        rootCommand.AddOption(typeOption);
        rootCommand.AddOption(indexOption);

        return await rootCommand.InvokeAsync(args);
    }

    internal static void ReadSettings(
        string configName
        )
    {
        if (hasConfig) return;

        var settingsName = string.IsNullOrWhiteSpace(configName) ? "appsettings" : configName;
        var builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile($"{settingsName}.json", optional: false, reloadOnChange: true);

        IConfiguration config = builder.Build();
        OutputDirectory = config["OutputDirectory"];
        TemplatePath = config["TemplatePath"];

        hasConfig = true;
    }
}
