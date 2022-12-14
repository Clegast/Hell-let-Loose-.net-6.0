using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Threading;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;
using Hell_let_Loose;

namespace Main
{
  /// <summary>
  /// Interaktionslogik für MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    public MainWindow()
    {
      InitializeComponent();


      int[] settings = SaveSettings.createFiles();
      cBoxPosition.SelectedIndex = settings[0];
      cBoxTyp.SelectedIndex = settings[1];
      txtBoxMapnorth.Text = Convert.ToString(settings[2]);
      txtBoxRuntime.Text = Convert.ToString(settings[3]);
      txtBoxXPosition.Text = Convert.ToString(settings[4]);
      txtBoxYPosition.Text = Convert.ToString(settings[5]);
    }
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>


    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
      Coordinates ary = new Coordinates(Convert.ToInt32(txtBoxXPosition.Text), Convert.ToInt32(txtBoxYPosition.Text));
      int mapnorth = Convert.ToInt32(txtBoxMapnorth.Text);
      string faction = Main.GetValue.getAryTyp(cBoxTyp.SelectedIndex);
      int aryalignment = Main.GetValue.GetPosition(cBoxPosition.SelectedIndex);
      
      Thread.Sleep(2000);

      Stopwatch s = new Stopwatch();
      s.Start();
      while (s.Elapsed < TimeSpan.FromMinutes(Convert.ToInt32(txtBoxRuntime.Text)))
      {
                fastfix.Main(ary, mapnorth,faction,aryalignment);

      } 
    }

    private void SaveBtn_Click(object sender, RoutedEventArgs e)
    {
      string folder = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}";
      string specificFolder = folder + "/HLLMod";
      string jsonFile = specificFolder + "/Settings.json";
      SaveSettings.saveData(cBoxPosition.SelectedIndex, cBoxTyp.SelectedIndex, txtBoxMapnorth.Text, txtBoxRuntime.Text, txtBoxXPosition.Text, txtBoxYPosition.Text);
    }


    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
      Regex regex = new Regex("[^0-9]+");
      e.Handled = regex.IsMatch(e.Text);
    }

    /// <summary>
    /// function that redirects the user to the help website
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Button_Click_Help(object sender, RoutedEventArgs e)
    {
      System.Diagnostics.Process.Start(new ProcessStartInfo
      {
        FileName = "https://clegast.github.io/Hell-let-Loose-.net-6.0/",
        UseShellExecute = true
      });
    }
  }
}
