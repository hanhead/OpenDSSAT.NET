using System;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace DssatBridgeTest
{
    class Program
    {
        const string EngineExeName = "DSCSM048.EXE";
        const string SampleFile = "UFGA7801.SBX";
        const string SampleDir = "Soybean";

        static readonly string[] ConfigFiles = { "DSSATPRO.v48", "DETAIL.CDE", "PEST.CDE", "SOIL.CDE" };

        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        static extern uint GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, uint cchBuffer);

        static void Main(string[] args)
        {
            string sandboxPath = @"C:\Temp\DssatRun";
            string dssatInstallPath = @"C:\DSSAT48";

            Console.WriteLine("==================================================");
            Console.WriteLine("      DSSAT C# Bridge - Official Config (V22)     ");
            Console.WriteLine("==================================================");

            if (!Directory.Exists(dssatInstallPath))
            {
                Console.WriteLine($"[Error] DSSAT not found at {dssatInstallPath}");
                return;
            }

            try
            {
                if (Directory.Exists(sandboxPath)) Directory.Delete(sandboxPath, true);
                Directory.CreateDirectory(sandboxPath);

                File.Copy(Path.Combine(dssatInstallPath, EngineExeName), Path.Combine(sandboxPath, EngineExeName), true);
                Console.WriteLine($"[Info] Engine copied: {EngineExeName}");

                string sourceSbx = Path.Combine(dssatInstallPath, SampleDir, SampleFile);
                if (File.Exists(sourceSbx))
                {
                    File.Copy(sourceSbx, Path.Combine(sandboxPath, SampleFile), true);
                    Console.WriteLine($"[Info] Sample copied: {SampleFile}");
                }
                else
                {
                    Console.WriteLine("[Error] Sample file missing.");
                    return;
                }

                foreach (string configFile in ConfigFiles)
                {
                    string src = Path.Combine(dssatInstallPath, configFile);
                    if (File.Exists(src))
                    {
                        File.Copy(src, Path.Combine(sandboxPath, configFile), true);
                        Console.WriteLine($"[Info] Config copied: {configFile}");
                    }
                    else
                    {
                        Console.WriteLine($"[Warning] Config missing: {configFile}");
                    }
                }

                Directory.SetCurrentDirectory(sandboxPath);
                Console.WriteLine($"[Action] Running DSSAT...");

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = Path.Combine(sandboxPath, EngineExeName);

                psi.Arguments = "C " + SampleFile + " 1";

                Console.WriteLine($"[Command] {EngineExeName} {psi.Arguments}");

                psi.WorkingDirectory = sandboxPath;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;
                psi.RedirectStandardOutput = true;
                psi.RedirectStandardError = true;

                using (Process proc = Process.Start(psi))
                {
                    string output = proc.StandardOutput.ReadToEnd();
                    string error = proc.StandardError.ReadToEnd();
                    proc.WaitForExit();

                    Console.WriteLine("[Exit Code] " + proc.ExitCode);
                    if (!string.IsNullOrWhiteSpace(output)) Console.WriteLine("[StdOut] " + output);
                    if (!string.IsNullOrWhiteSpace(error)) Console.WriteLine("[StdErr] " + error);
                }

                string overviewPath = Path.Combine(sandboxPath, "OVERVIEW.OUT");
                if (File.Exists(overviewPath))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n[SUCCESS] OVERVIEW.OUT created!");
                    Console.WriteLine("Phase 1 Complete. You are ready for Phase 2.");
                    Console.ResetColor();

                    Console.WriteLine("\n--- Result Preview ---");
                    string[] lines = File.ReadAllLines(overviewPath);
                    int count = 0;
                    bool print = false;
                    foreach (var line in lines)
                    {
                        if (line.Contains("*MAIN") || line.Contains("Simulated")) print = true;
                        if (print && count < 20)
                        {
                            Console.WriteLine(line);
                            count++;
                        }
                    }
                    Console.WriteLine("...");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n[Fail] OVERVIEW.OUT not found.");
                    if (File.Exists(Path.Combine(sandboxPath, "WARNING.OUT")))
                    {
                        Console.WriteLine("--- WARNING.OUT ---");
                        Console.WriteLine(File.ReadAllText(Path.Combine(sandboxPath, "WARNING.OUT")));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Exception] {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}