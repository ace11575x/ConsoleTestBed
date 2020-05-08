using System;
using System.Diagnostics;
using System.Net;

namespace ConsoleTestBed
{
  class Program
  {
    static void Main(string[] args)
    {
      using (WebClient client = new WebClient())
      {
        client.DownloadFile("https://downloads.malwarebytes.com/file/adwcleaner", @"C:\Code Testing\ADW.exe");
      }

      var versioninfo = FileVersionInfo.GetVersionInfo(@"C:\Code Testing\ADW.exe");
      string version = versioninfo.FileVersion;


      //Console.WriteLine(versioninfo.FileDescription + " Version Number " + versioninfo.FileVersion + " original File Name " + versioninfo.OriginalFilename);

      Console.WriteLine("File Description: {0}, Version Number: {1}, Original File Name: {2}",versioninfo.FileDescription, versioninfo.FileVersion, versioninfo.OriginalFilename);

      Console.WriteLine("Would you like to run the application {0}? press 0 for No press 1 for yes", versioninfo.OriginalFilename);

      ConsoleKeyInfo input = Console.ReadKey();

      if(input.KeyChar == '0')
      {
        Console.WriteLine("Terminating application Press any key to close.");
        Console.ReadKey();
        Environment.Exit(0);
      }
      else
      {
        Console.WriteLine("Running application");
        LaunchApplication();
      }

      Console.ReadKey();
    }

    static void LaunchApplication()
    {
      try
      {
        ProcessStartInfo info = new ProcessStartInfo(@"C:\Code Testing\ADW.exe");
        info.UseShellExecute = true;
        info.Verb = "runas";
        Process.Start(info);
      }
      catch(Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
