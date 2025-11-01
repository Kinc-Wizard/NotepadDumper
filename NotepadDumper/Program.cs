using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NotepadDumper
{
    internal class Program
    {
        // path : Packages\Microsoft.WindowsNotepad_8wekyb3d8bbwe\LocalState\TabState
        static string appDataRoot = Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        static string notepadFile = Path.Combine(appDataRoot, "Local\\" +
            "Packages\\Microsoft.WindowsNotepad_8wekyb3d8bbwe\\LocalState\\TabState");

        static readonly UTF8Encoding Utf8NoBomStrict = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false,
                                                                     throwOnInvalidBytes: true);

        static void FindNotepadFile()
        {
            var dir = new DirectoryInfo(notepadFile);
            FileInfo[] files = dir.GetFiles();

            foreach (var file in files)
            {
                Console.WriteLine("**** " + file.Name + " *****");
                string v = File.ReadAllText(file.FullName, Utf8NoBomStrict);
                Console.WriteLine(v);
                Console.WriteLine("\n");
            }

        }

        static void Main(string[] args)
        {
            FindNotepadFile();
        }
    }
}
