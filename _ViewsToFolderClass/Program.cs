Console.WriteLine("Views Folder to Class");
var projectName = "CRMSBI";
try
{
    var curDir = Environment.CurrentDirectory;
    var path = curDir.Replace("_ViewsToFolderClass\\bin\\Debug\\net6.0", projectName + "\\Views\\");

    string temp = "";
    if (!path.Substring(path.Length - 1, 1).Equals("\\"))
    {
        path = path + "\\";
    }

    string[] y = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
    List<string> allfiles = new List<string>();
    foreach (string x in y)
    {
        allfiles.Add(x.Replace(path, ""));
    }
    foreach (string file in allfiles)
    {
        if (file.Equals("Web.config") || file.Equals("_ViewStart.cshtml"))
        {
            continue;
        }
        string variableName = file.Replace("\\", "_").Replace(".cshtml", "").Replace(".", "_");
        string variableValue = "\"../" + file.Replace("\\", "/").Replace(".cshtml", "") + "\";";
        temp += "   public const string " + variableName + " = " + variableValue + Environment.NewLine;
    }
    string result = "";
    result += "namespace CRMSBI.Data" + Environment.NewLine;
    result += "{" + Environment.NewLine;

    result += " public partial class Views" + Environment.NewLine;
    result += " {" + Environment.NewLine;
    result += temp;
    result += " }" + Environment.NewLine;

    result += "}" + Environment.NewLine;
    Console.WriteLine(result);
    string filePath = Environment.CurrentDirectory.Replace("_ViewsToFolderClass\\bin\\Debug\\net6.0", projectName + "\\Helper\\Views.cs");
    if (File.Exists(filePath))
    {
        File.Delete(filePath);
    }
    using (StreamWriter sw = File.CreateText(filePath))
    {
        sw.WriteLine(result);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}