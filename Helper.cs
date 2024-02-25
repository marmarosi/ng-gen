using System.Text.RegularExpressions;

namespace ng_gen
{
    internal static class Helper
    {
        internal static string GetOutputPath(
            string dirPath,
            string name
            )
        {
            string outputPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            outputPath = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(dirPath))
            {
                outputPath = Path.Combine(outputPath!, dirPath);
                DirectoryInfo dirInfo;
                if (!Directory.Exists(outputPath))
                    dirInfo = Directory.CreateDirectory(outputPath);
                else
                    dirInfo = new DirectoryInfo(outputPath);
                outputPath = dirInfo.FullName;
            }
            outputPath = Path.Combine(outputPath!, name.ToLower());
            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);
            return outputPath!;
        }

        internal static async Task WriteFile(
            string filePath,
            string content
            )
        {
            using (StreamWriter outputFile = new StreamWriter(filePath))
                await outputFile.WriteAsync(content);
        }

        internal static string ToPascalCase(
            this string input
            )
        {
            return string.Join('.', input.Split('.').Select(x => ConvertToPascalCase(x)));
        }

        internal static string ConvertToPascalCase(
            string input
            )
        {
            Regex invalidCharsRgx = new Regex(@"[^_a-zA-Z0-9]");
            //Regex whiteSpace = new Regex(@"(?<=\s)");
            Regex dash = new Regex(@"(?<=\-)");
            Regex startsWithLowerCaseChar = new Regex("^[a-z]");
            Regex firstCharFollowedByUpperCasesOnly = new Regex("(?<=[A-Z])[A-Z0-9]+$");
            Regex lowerCaseNextToNumber = new Regex("(?<=[0-9])[a-z]");
            Regex upperCaseInside = new Regex("(?<=[A-Z])[A-Z]+?((?=[A-Z][a-z])|(?=[0-9]))");

            // replace white spaces with undescore, then replace all invalid chars with empty string
            var pascalCase = invalidCharsRgx.Replace(dash.Replace(input, "_"), string.Empty)
                // split by underscores
                .Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries)
                // set first letter to uppercase
                .Select(w => startsWithLowerCaseChar.Replace(w, m => m.Value.ToUpper()))
                // replace second and all following upper case letters to lower if there is no next lower (ABC -> Abc)
                .Select(w => firstCharFollowedByUpperCasesOnly.Replace(w, m => m.Value.ToLower()))
                // set upper case the first lower case following a number (Ab9cd -> Ab9Cd)
                .Select(w => lowerCaseNextToNumber.Replace(w, m => m.Value.ToUpper()))
                // lower second and next upper case letters except the last if it follows by any lower (ABcDEf -> AbcDef)
                .Select(w => upperCaseInside.Replace(w, m => m.Value.ToLower()));

            return string.Concat(pascalCase);
        }

        internal static string ToSingle(
            this string input
            )
        {
            if (input.EndsWith("ies"))
                return input.Substring(0, input.Length - 3) + "y";
            else if (input.EndsWith('s'))
                return input.Substring(0, input.Length - 1);
            else
                return input;
        }

        public static string? FirstCharToLowerCase(
            this string? input
            )
        {
            if (char.IsUpper(input[0]))
                return input.Length == 1 ? char.ToLower(input[0]).ToString() : char.ToLower(input[0]) + input[1..];
            return input;
        }
    }
}
