

using System.Diagnostics;

Process process = new Process();
process.StartInfo.FileName = "cmd.exe"; // Указываем исполняемый файл (командный интерпретатор)
process.StartInfo.Arguments = "Add-Migration Migration1"; // Указываем аргументы команды

