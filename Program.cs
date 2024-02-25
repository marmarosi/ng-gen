using ng_gen;
using System.CommandLine;

namespace scl;

static class Program
{
    static async Task<int> Main(string[] args)
    {
        // Define options

        var dirPathOption = new Option<string>(
            name: "--output-dir",
            description: "The path of the directory where the files will be generated.");
        dirPathOption.AddAlias("-o");

        var prefixOption = new Option<string>(
            name: "--prefix",
            description: "The HTML prefix of the Angular component.",
            getDefaultValue: () => "app");
        prefixOption.AddAlias("-x");

        var typeOption = new Option<string>(
            name: "--type",
            description: "The type of the Angular component/service.");
        typeOption.AddAlias("-t");

        // Define arguments

        var nameArgument = new Argument<string>(
            name: "name",
            description: "The name of the Angular element.");

        // Define module command

        var moduleCommand = new Command("module", "Generates a new module.");
        moduleCommand.AddAlias("m");
        moduleCommand.AddArgument(nameArgument);
        moduleCommand.AddOption(prefixOption);

        moduleCommand.SetHandler(async (dirPath, name, prefix) =>
            {
                await GenerateModule.Run(dirPath, name, prefix);
            },
            dirPathOption, nameArgument, prefixOption);

        // Define page command

        var pageCommand = new Command("page", "Generates a new page.");
        pageCommand.AddAlias("p");
        pageCommand.AddArgument(nameArgument);

        pageCommand.SetHandler(async (dirPath, name) =>
            {
                await GeneratePage.Run(dirPath, name);
            },
            dirPathOption, nameArgument);

        // Define component command

        var componentCommand = new Command("component", "Generates a new component.");
        componentCommand.AddAlias("c");
        componentCommand.AddArgument(nameArgument);
        componentCommand.AddOption(prefixOption);
        componentCommand.AddOption(typeOption);

        componentCommand.SetHandler(async (dirPath, name, prefix, type) =>
            {
                await GenerateComponent.Run(dirPath, name, prefix, type);
            },
            dirPathOption, nameArgument, prefixOption, typeOption);

        // Define dialog command

        var dialogCommand = new Command("dialog", "Generates a new dialog.");
        dialogCommand.AddAlias("d");
        dialogCommand.AddArgument(nameArgument);

        dialogCommand.SetHandler(async (dirPath, name) =>
            {
                await GenerateDialog.Run(dirPath, name);
            },
            dirPathOption, nameArgument);

        // Define dialog command

        var serviceCommand = new Command("service", "Generates a new service.");
        serviceCommand.AddAlias("s");
        serviceCommand.AddArgument(nameArgument);
        serviceCommand.AddOption(typeOption);

        serviceCommand.SetHandler(async (dirPath, name, type) =>
            {
                await GenerateService.Run(dirPath, name, type);
            },
            dirPathOption, nameArgument, typeOption);

        // Define root command

        var rootCommand = new RootCommand("Generates Angular files.");

        rootCommand.AddCommand(moduleCommand);
        rootCommand.AddCommand(pageCommand);
        rootCommand.AddCommand(componentCommand);
        rootCommand.AddCommand(dialogCommand);
        rootCommand.AddCommand(serviceCommand);

        rootCommand.AddGlobalOption(dirPathOption);
        rootCommand.AddOption(prefixOption);
        rootCommand.AddOption(typeOption);

        return await rootCommand.InvokeAsync(args);
    }

}
