using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace Main
{
  internal static class SaveSettings
  {

    public static int[] createFiles()
    {
      string folder = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}";
      string specificFolder = folder + "/HLLMod";
      string jsonFile = specificFolder + "/Settings.json";

      if (!Directory.Exists(specificFolder))
      {
        Directory.CreateDirectory(specificFolder);
      }
      if (!File.Exists(jsonFile))
      {
        File.Create(jsonFile);
      }
      else
      {
        string text = File.ReadAllText(jsonFile);
        if (new FileInfo(jsonFile).Length != 0)
        {
          int[]? settings = JsonSerializer.Deserialize<int[]>(text);
          return settings;
        }
      }
      int[] i = {0, 0, 0};
      return i;
    }

    public static void saveData(int boxPosition, int boxTyp, string mapNorth)
    {
      string folder = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}";
      string specificFolder = folder + "/HLLMod";
      string jsonFile = specificFolder + "/Settings.json";

      List<int> settingList = new List<int>();
      settingList.Add(boxPosition);
      settingList.Add(boxTyp);
      settingList.Add(Convert.ToInt32(mapNorth));

      string json = JsonSerializer.Serialize(settingList);
      File.WriteAllText(jsonFile, json);
    }
    /*/public int[] getData()
    {
      string folder = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}";
      string specificFolder = folder + "/HLLMod";
      string jsonFile = specificFolder + "/Settings.json";
      
      string text = File.ReadAllText(jsonFile);

      int[] settings = JsonSerializer.Deserialize<int[]>(text);

      return settings;
    }
    /*/
  }
}
