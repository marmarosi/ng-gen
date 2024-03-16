# ng-gen
Generates Angular files.

Usage:
```
  ng-gen [command] [options]
```
Options:
```
-c, --config <config>                   The name of the settings file without .json extension.
-o, --output-dir <output-dir>           The path of the directory where the files will be generated.
-x, --translate <translate> (REQUIRED)  The name of the translation (.json) file.
-p, --prefix <prefix>                   The HTML prefix of the Angular component. [default: app]
-t, --type <type>                       The type of the Angular component/service.
-i, --index <index>                     The name of the components in the module. [default: index]
--version                               Show version information
-?, -h, --help                          Show help and usage information
```
Commands:
```
m, module <name>       Generates a new module.
p, page <name>         Generates a new page.
c, component <name>    Generates a new component.
d, dialog <name>       Generates a new dialog.
s, service <name>      Generates a new service.
```
