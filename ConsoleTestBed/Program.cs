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

      
      Console.WriteLine(versioninfo.FileDescription  + " Version Number " + versioninfo.FileVersion +  " original File Name " + versioninfo.OriginalFilename);

        Console.ReadKey();
    }
  }
}
