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
      //while (s.Elapsed < TimeSpan.FromMinutes(Convert.ToInt32(txtBoxRuntime.Text)))
      { 
        Action.OpenMap();
                Thread.Sleep(1000);
        Coordinates target = Detection.GetTarget();

        double distance = Formula.GetHypotenuse(target, ary);
        int mil = 0;
        switch (faction)
        {
          case "Us":
            mil = (int)Math.Round(Formula.usMetersToMill(distance));
            break;
          case "Gr":
            mil = (int)Math.Round(Formula.usMetersToMill(distance));
            break;
          case "Ru":
            mil = (int)Math.Round(Formula.ruMetersToMill(distance));
            break;

        }
        int angel = (int)Formula.angleCalculation(target, ary, mapnorth, aryalignment);
        Action.OpenMap();

        Thread.Sleep(1000);


        int MilonScreen = Detection.Imgtotxt(new Coordinates(1800, 945), 50, 20, 622);
        int lastMil = MilonScreen;

        while (MilonScreen != mil)
        {
          lastMil = new Int32();
          lastMil = MilonScreen;
          if (MilonScreen > mil)
          {
            Action.TurnDown();
          }
          if (MilonScreen < mil)
          {
            Action.TurnUp();
          }

          MilonScreen = Detection.Imgtotxt(new Coordinates(1800, 945), 50, 20, lastMil);
          System.GC.Collect();
          if (MilonScreen == mil - 1)
          {
            break;
          }
          else if (MilonScreen == mil + 1)
          {
            break;
          }

        }

       
        
                int angleloder = angel - 47;
                if (angleloder < 0) angleloder += 360;
        
        Action.SwitchSeatTo(1);
                Action.Reload();
                ShepSoulution.AngelAlingh();
        Action.SwitchSeatTo(0);
                for(int i = 0; i < 3; i++)
                {
                    Action.Fire();
                    Action.SwitchSeatTo(1);
                    Action.Reload();
                    Action.SwitchSeatTo(0);
                }

      } 
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
            Thread.Sleep(2000);
            ShepSoulution.AngelAlingh();



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
