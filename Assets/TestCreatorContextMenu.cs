using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;
namespace Test.Namespace
{
    public class TestCreatorContextMenu
    {

        [MenuItem("Assets/Generate Test")]
        private static void LoadAdditiveScene()
        {
            var selected = Selection.activeObject;
            var projectPath = AssetDatabase.GetAssetPath(selected);

            var newPath = projectPath.Replace("Assets", "Assets/Tests");
            newPath = newPath.Replace(".cs", "Test.cs");

            //AssetDatabase.CreateAsset(string.Empty, newPath);

            string[] lines = System.IO.File.ReadAllLines(projectPath);

            string classPattern = @"class\s+(\w+)";
            string namespacePattern = @"namespace\s+([\w\.]+)";

            Regex classRegex = new Regex(classPattern);
            Regex namespaceRegex = new Regex(namespacePattern);

            string className = string.Empty;
            string namespaceName = string.Empty;

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(className))
                {
                    var classMatch = classRegex.Match(line);
                    if (classMatch.Success)
                    {
                        className = classMatch.Groups[1].Captures[0].Value;
                    }
                }

                if (string.IsNullOrEmpty(namespaceName))
                {
                    var namespaceMatch = namespaceRegex.Match(line);
                    if (namespaceMatch.Success)
                    {
                        namespaceName = namespaceMatch.Groups[1].Captures[0].Value;
                    }
                }

                if (!string.IsNullOrEmpty(className) && !string.IsNullOrEmpty(namespaceName))
                {
                    break;
                }
            }

            StringBuilder testFile = new StringBuilder();

            int tabs = 0;
            testFile.AppendLine("using NUnit.Framework;");
            testFile.AppendLine();

            if (!string.IsNullOrEmpty(namespaceName))
            {
                testFile.AppendFormat("namespace {0} {{", namespaceName);
                testFile.AppendLine();
                tabs++;
            }

            testFile.AppendFormat("{0}public class {1}Test {{", AddTabs(string.Empty, tabs), className);
            testFile.AppendLine();
            tabs++;
            testFile.AppendLine(AddTabs("[Test]", tabs));
            testFile.AppendLine(AddTabs("public void t(){", tabs));
            testFile.AppendLine(AddTabs("}", tabs));
            tabs--;
            testFile.AppendLine(AddTabs("}", tabs));

            if (!string.IsNullOrEmpty(namespaceName))
            {
                testFile.AppendLine("}");
            }

            System.IO.File.WriteAllText(newPath, testFile.ToString());
            System.Diagnostics.Process.Start(Path.GetFullPath(newPath));
        }

        public static string AddTabs(string value, int numberTabs, bool useSpaces = false)
        {
            string tab;

            if (useSpaces)
            {
                tab = "    ";
            }
            else
            {
                tab = "\t";
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numberTabs; i++)
            {
                sb.Append(tab);
            }
            sb.Append(value);

            return sb.ToString();
        }
    }
}