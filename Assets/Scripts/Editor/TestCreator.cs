using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;


namespace AssetsMenu {
    public static class TestCreator {

        public static bool BRACKETS_SAME_INDENTENTATION = true;
        public static string PATH_SEGMENT_TO_REPLACE = "Scripts";
        public static string TEST_PATH_SEGMENT = PATH_SEGMENT_TO_REPLACE + "/Tests";

        [MenuItem("Assets/Generate UnityClient Test")]
        public static void GenerateTestFile() {
            var selected = Selection.activeObject;
            var originalFilePath = AssetDatabase.GetAssetPath(selected);

            if (!originalFilePath.EndsWith(".cs")) {
                return;
            }

            var testFilePath = GetTestFilePath(originalFilePath);

            var testFileInfo = new FileInfo(testFilePath);

            if (testFileInfo.Directory == null) {
                return;
            }

            var originalFileLines = File.ReadAllLines(originalFilePath);

            var className = GetClassName(originalFileLines);
            var namespaceName = GetNamespace(originalFileLines);

            var testFileContent = CreateFileContents(className, namespaceName);

            //ensure directory existing
            Directory.CreateDirectory(testFileInfo.Directory.FullName);

            File.WriteAllText(testFilePath, testFileContent);

            //open new file in editor in editor
            System.Diagnostics.Process.Start(Path.GetFullPath(testFilePath));
        }

        public static string GetClassName(string[] fileLines) {
            const string classPattern = @"class\s+(\w+)";

            return GetPatternMatch(fileLines, classPattern);
        }

        public static string GetNamespace(string[] fileLines) {
            const string namespacePattern = @"namespace\s+([\w\.]+)";

            return GetPatternMatch(fileLines, namespacePattern);
        }

        private static string GetPatternMatch(string[] fileLines, string pattern) {
            Regex classRegex = new Regex(pattern);

            for (var index = 0; index < fileLines.Length; index++) {
                string line = fileLines[index];

                int commentIndex = line.IndexOf(@"//");

                if (commentIndex >= 0) {
                    line = line.Substring(0, commentIndex);
                }

                var classMatch = classRegex.Match(line);
                if (classMatch.Success) {
                    return classMatch.Groups[1].Captures[0].Value;
                }
            }

            return null;
        }

        private static string GetTestFilePath(string originalFilePath) {
            var testFilePath = String.Empty;

            if (originalFilePath.Contains(PATH_SEGMENT_TO_REPLACE)) {
                testFilePath = originalFilePath.Replace(PATH_SEGMENT_TO_REPLACE, TEST_PATH_SEGMENT);
            }
            //else if (originalFilePath.Contains("Assets")){
            //    testFilePath = originalFilePath.Replace("Assets", "Assets/Tests/Editor/UnityClient");
            //}

            return testFilePath.Replace(".cs", "Test.cs");
        }

        private static string CreateFileContents(string originalClassName, string originalNamespaceName) {
            var testFileBuilder = new IndentedStringBuilder();

            testFileBuilder.AppendLine("using NUnit.Framework;");
            testFileBuilder.AppendLine();

            if (!string.IsNullOrEmpty(originalNamespaceName)) {
                testFileBuilder.AppendFormatLineWithBracket("namespace {0}", originalNamespaceName);
                testFileBuilder.AppendLine();
                testFileBuilder.IncreaseTabs();
            }

            //testFileBuilder.AppendFormatLine("[Category(\"UnityClient\")]");
            testFileBuilder.AppendFormatLineWithBracket("public class {0}Test", originalClassName);
            testFileBuilder.IncreaseTabs();

            testFileBuilder.AppendLine();

            AppendMethod(testFileBuilder, "SetUp", "SetUp");
            AppendMethod(testFileBuilder, "TearDown", "TearDown");
            AppendMethod(testFileBuilder, "Test", "t");

            testFileBuilder.DecreaseTabs();
            testFileBuilder.AppendLine("}");

            if (!string.IsNullOrEmpty(originalNamespaceName)) {
                testFileBuilder.DecreaseTabs();
                testFileBuilder.AppendLine("}");
            }

            return testFileBuilder.ToString();
        }

        private static void AppendMethod(IndentedStringBuilder builder, string tag, string name) {
            builder.AppendFormatLine("[{0}]", tag);
            builder.AppendFormatLineWithBracket("public void {0}()", name);
            builder.AppendLine("}");
            builder.AppendLine();
        }

        public static void AppendFormatLineWithBracket(this IndentedStringBuilder isb, String format, params object[] args)
        {
            if (BRACKETS_SAME_INDENTENTATION)
            {
                isb.AppendFormatLine(format, args);
                isb.AppendLine("{");
            }
            else
            {
                isb.AppendFormatLine(format + "{{", args);
            }
        }
    }
}
