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
      SaveSettings savesettings = new SaveSettings();

      int[] settings = savesettings.createFiles();
      cBoxPosition.SelectedIndex = settings[0];
      cBoxTyp.SelectedIndex = settings[1];
      txtBoxMapnorth.Text = Convert.ToString(settings[2]);

    }
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>


    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
      
      Formula formula = new Formula();
      Action action = new Action();
      Coordinates ary = new Coordinates(545, 514);
      int mapnorth = 0;
      int aryalingment = 90;
      string faction = "Us";
      Thread.Sleep(2000);
      do
      {
        action.OpenMap();
        Coordinates target = Detection.GetTarget();

        double distance = formula.GetHypotenuse(target, ary);
        int mil = 0;
        switch (faction)
        {
          case "Us":
            mil = (int)Math.Round(formula.usMetersToMill(distance));
            break;
          case "Gr":
            mil = (int)Math.Round(formula.usMetersToMill(distance));
            break;
          case "Ru":
            mil = (int)Math.Round(formula.ruMetersToMill(distance));
            break;

        } int angel = (int)formula.angleCalculation(target, ary, mapnorth, aryalingment);
        action.OpenMap();

        Thread.Sleep(1000);

       
        int MilonScreen = Detection.Imgtotxt(1800, 945, 50, 20, 622);
        int lastMil = MilonScreen;

        while (MilonScreen != mil)
        {
          lastMil = new Int32();
          lastMil = MilonScreen;
          if (MilonScreen > mil)
          {
            action.TurnDown();
          }
          if (MilonScreen < mil)
          {
            action.TurnUp();
          }
          
          MilonScreen = Detection.Imgtotxt(1800, 945, 50, 20, lastMil);
          System.GC.Collect();
          if (MilonScreen == mil - 1)
          {
            break;
          }
          else if(MilonScreen == mil + 1)
          {
            break;
          }
          
        }
        
        int AngelonScreen = Detection.Imgtotxt(1033, 960, 22, 12, 0)-47;
        int lastAngel = AngelonScreen;
        if (AngelonScreen < 0)
        {
          AngelonScreen += 360;
        }
        action.SwitchSeatTo(1);
        while (AngelonScreen != angel)
        {
          lastAngel = AngelonScreen;
          if (AngelonScreen > angel)
          {
            action.TurnLeft();
          }
          if (AngelonScreen-47 < angel)
          {
            action.TurnRight();
          }
          AngelonScreen = Detection.Imgtotxt(1033, 960, 22, 12, lastAngel)-47;
          if (AngelonScreen < 0)
          {
            AngelonScreen += 360;
          }
        }
        action.SwitchSeatTo(0);

      } while (true);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      
      Formula formula = new Formula();
      Action action = new Action();
      Coordinates ary = new Coordinates(545, 514);
      int mapnorth = 0;
      int aryalingment = 90;
      string faction = "Us";
      Thread.Sleep(2000);
        Coordinates target = Detection.GetTarget();
      double temp = target.xcordinate;
      Console.WriteLine(temp);
      temp = target.ycordinate;
      Console.WriteLine(temp);

      double distance = formula.GetHypotenuse(target, ary);
      int mil = 0;
      switch (faction)
      {
        case "Us":
          mil = (int)Math.Round(formula.usMetersToMill(distance));
          break;
        case "Gr":
          mil = (int)Math.Round(formula.usMetersToMill(distance));
          break;
        case "Ru":
          mil = (int)Math.Round(formula.ruMetersToMill(distance));
          break;

      }
      Console.WriteLine(mil);
      int angel = (int)formula.angleCalculation(target, ary, mapnorth, aryalingment);
      Console.WriteLine(angel);



    }
    private void btn4_Click(object sender, RoutedEventArgs e)
    {
      string folder = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}";
      string specificFolder = folder + "/HLLMod";
      string jsonFile = specificFolder + "/Settings.json";
      SaveSettings savesettings = new SaveSettings();


      savesettings.saveData(cBoxPosition.SelectedIndex, cBoxTyp.SelectedIndex, txtBoxMapnorth.Text);
    }
  }
}
