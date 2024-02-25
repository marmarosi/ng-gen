# ng-gen
Generates Angular files.

Usage:
```
  ng-gen [command] [options]
```
Options:
```
-o, --output-dir <output-dir>  The path of the directory where the files will be generated.
-x, --prefix <prefix>          The HTML prefix of the Angular element. [default: app]
-t, --type <type>              The file type of the Angular element.
--version                      Show version information
-?, -h, --help                 Show help and usage information
```
Commands:
```
m, module <name>       Generates a new module.
p, page <name>         Generates a new page.
c, component <name>    Generates a new component.
d, dialog <name>       Generates a new dialog.
s, service <name>      Generates a new service.
```
