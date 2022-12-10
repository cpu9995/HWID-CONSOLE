using Microsoft.Win32;
using System;
using System.Management;
using System.Threading;

namespace HWID_CONSOLE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Title = "HARDWARE ID";
            MainMenu();
        }



        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) CPU");
            Console.WriteLine("2) UUID");
            Console.WriteLine("3) HWID");
            Console.WriteLine("4) MOTHERBOARD");
            Console.WriteLine("5) MAC ADDRESS");
            Console.WriteLine("6) BIOS");
            Console.WriteLine("7) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    CPU();
                    Console.Title = "CPU";
                    return true;
                case "2":
                    Console.Clear();
                    UUID();
                    Console.Title = "UUID";
                    return true;
                case "3":
                    Console.Clear();
                    HWID();
                    Console.Title = "HWID";
                    return true;
                case "4":
                    Console.Clear();
                    MOTHERBOARD();
                    Console.Title = "MOTHERBOARD";
                    return true;
                case "5":
                    Console.Clear();
                    MAC();
                    Console.Title = "MAC";
                    return true;
                case "6":
                    Console.Clear();
                    BIOS();
                    Console.Title = "BIOS";
                    return true;
                case "7":
                    ConsoleClose();
                    Console.Title = "EXIT";
                    return true;
                default:
                    return true;
            }
        }

        private static void CPU()
        {
            ManagementObjectSearcher searcherWin32_Processor = new ManagementObjectSearcher("SELECT Name, SystemName, ProcessorId, SerialNumber FROM Win32_Processor");
            ManagementObjectSearcher searcherWin32_CsProduct = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct");
            ManagementObjectSearcher searcherWin32_OperatingSystem = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcherWin32_DiskDrive = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive");
            ManagementObjectSearcher searcherWin32_LogicalDisk = new ManagementObjectSearcher("SELECT VolumeSerialNumber, Name FROM Win32_LogicalDisk");
            ManagementObjectSearcher searcherWin32_BaseBoard = new ManagementObjectSearcher("SELECT SerialNumber, Product, Version FROM Win32_BaseBoard");
            ManagementObjectSearcher searcherWin32_NetworkAdapter = new ManagementObjectSearcher("SELECT Name, MACAddress FROM Win32_NetworkAdapter");
            ManagementObjectSearcher searcherWin32_BIOS = new ManagementObjectSearcher("SELECT Name, Version, SerialNumber FROM Win32_BIOS");

            foreach (ManagementObject info in searcherWin32_Processor.Get())
            {
                Console.WriteLine(info["Name"].ToString());
                Console.Write("[+] Press Enter To Return To Main Menu");
                Console.ReadLine();
                MainMenu();
            }
        }

        private static void UUID()
        {
            ManagementObjectSearcher searcherWin32_Processor = new ManagementObjectSearcher("SELECT Name, SystemName, ProcessorId, SerialNumber FROM Win32_Processor");
            ManagementObjectSearcher searcherWin32_CsProduct = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct");
            ManagementObjectSearcher searcherWin32_OperatingSystem = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcherWin32_DiskDrive = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive");
            ManagementObjectSearcher searcherWin32_LogicalDisk = new ManagementObjectSearcher("SELECT VolumeSerialNumber, Name FROM Win32_LogicalDisk");
            ManagementObjectSearcher searcherWin32_BaseBoard = new ManagementObjectSearcher("SELECT SerialNumber, Product, Version FROM Win32_BaseBoard");
            ManagementObjectSearcher searcherWin32_NetworkAdapter = new ManagementObjectSearcher("SELECT Name, MACAddress FROM Win32_NetworkAdapter");
            ManagementObjectSearcher searcherWin32_BIOS = new ManagementObjectSearcher("SELECT Name, Version, SerialNumber FROM Win32_BIOS");

            foreach (ManagementObject info in searcherWin32_CsProduct.Get())
            {
                Console.WriteLine(info["UUID"].ToString());
                Console.Write("[+] Press Enter To Return To Main Menu");
                Console.ReadLine();
                MainMenu();
            }
        }

        private static void HWID()
        {
            ManagementObjectSearcher searcherWin32_Processor = new ManagementObjectSearcher("SELECT Name, SystemName, ProcessorId, SerialNumber FROM Win32_Processor");
            ManagementObjectSearcher searcherWin32_CsProduct = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct");
            ManagementObjectSearcher searcherWin32_OperatingSystem = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcherWin32_DiskDrive = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive");
            ManagementObjectSearcher searcherWin32_LogicalDisk = new ManagementObjectSearcher("SELECT VolumeSerialNumber, Name FROM Win32_LogicalDisk");
            ManagementObjectSearcher searcherWin32_BaseBoard = new ManagementObjectSearcher("SELECT SerialNumber, Product, Version FROM Win32_BaseBoard");
            ManagementObjectSearcher searcherWin32_NetworkAdapter = new ManagementObjectSearcher("SELECT Name, MACAddress FROM Win32_NetworkAdapter");
            ManagementObjectSearcher searcherWin32_BIOS = new ManagementObjectSearcher("SELECT Name, Version, SerialNumber FROM Win32_BIOS");

            RegistryKey keyBaseX64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey keyBaseX86 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            RegistryKey keyX64 = keyBaseX64.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography", RegistryKeyPermissionCheck.ReadSubTree);
            RegistryKey keyX86 = keyBaseX86.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography", RegistryKeyPermissionCheck.ReadSubTree);
            object resultObjX64 = keyX64.GetValue("MachineGuid", (object)"default");
            object resultObjX86 = keyX86.GetValue("MachineGuid", (object)"default");


            if (resultObjX64 != null && resultObjX64.ToString() != "default")
            {
                Console.WriteLine(resultObjX64.ToString());
                Console.Write("[+] Press Enter To Return To Main Menu");
                Console.ReadLine();
                MainMenu();
            }
            if (resultObjX86 != null && resultObjX86.ToString() != "default")
            {
                Console.WriteLine(resultObjX86.ToString());
                Console.Write("[+] Press Enter To Return To Main Menu");
                Console.ReadLine();
                MainMenu();
            }
        }

        private static void MOTHERBOARD()
        {
            ManagementObjectSearcher searcherWin32_Processor = new ManagementObjectSearcher("SELECT Name, SystemName, ProcessorId, SerialNumber FROM Win32_Processor");
            ManagementObjectSearcher searcherWin32_CsProduct = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct");
            ManagementObjectSearcher searcherWin32_OperatingSystem = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcherWin32_DiskDrive = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive");
            ManagementObjectSearcher searcherWin32_LogicalDisk = new ManagementObjectSearcher("SELECT VolumeSerialNumber, Name FROM Win32_LogicalDisk");
            ManagementObjectSearcher searcherWin32_BaseBoard = new ManagementObjectSearcher("SELECT SerialNumber, Product, Version FROM Win32_BaseBoard");
            ManagementObjectSearcher searcherWin32_NetworkAdapter = new ManagementObjectSearcher("SELECT Name, MACAddress FROM Win32_NetworkAdapter");
            ManagementObjectSearcher searcherWin32_BIOS = new ManagementObjectSearcher("SELECT Name, Version, SerialNumber FROM Win32_BIOS");

            foreach (ManagementObject info in searcherWin32_BaseBoard.Get())
            {
                Console.WriteLine(info["Product"].ToString());
                Console.Write("[+] Press Enter To Return To Main Menu");
                Console.ReadLine();
                MainMenu();
            }
        }

        private static void MAC()
        {
            ManagementObjectSearcher searcherWin32_Processor = new ManagementObjectSearcher("SELECT Name, SystemName, ProcessorId, SerialNumber FROM Win32_Processor");
            ManagementObjectSearcher searcherWin32_CsProduct = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct");
            ManagementObjectSearcher searcherWin32_OperatingSystem = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcherWin32_DiskDrive = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive");
            ManagementObjectSearcher searcherWin32_LogicalDisk = new ManagementObjectSearcher("SELECT VolumeSerialNumber, Name FROM Win32_LogicalDisk");
            ManagementObjectSearcher searcherWin32_BaseBoard = new ManagementObjectSearcher("SELECT SerialNumber, Product, Version FROM Win32_BaseBoard");
            ManagementObjectSearcher searcherWin32_NetworkAdapter = new ManagementObjectSearcher("SELECT Name, MACAddress FROM Win32_NetworkAdapter");
            ManagementObjectSearcher searcherWin32_BIOS = new ManagementObjectSearcher("SELECT Name, Version, SerialNumber FROM Win32_BIOS");

            foreach (ManagementObject info in searcherWin32_NetworkAdapter.Get())
            {
                object macNA = info["MACAddress"];
                if (!(macNA == null))
                {
                    string[] nameNA = info["Name"].ToString().Split(new Char[] { '\n' });
                    Console.WriteLine($"{macNA} \n");
                    Console.Write("[+] Press Enter To Return To Main Menu");
                    Console.ReadLine();
                    MainMenu();
                }
            }
        }

        private static void BIOS()
        {
            ManagementObjectSearcher searcherWin32_Processor = new ManagementObjectSearcher("SELECT Name, SystemName, ProcessorId, SerialNumber FROM Win32_Processor");
            ManagementObjectSearcher searcherWin32_CsProduct = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct");
            ManagementObjectSearcher searcherWin32_OperatingSystem = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcherWin32_DiskDrive = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive");
            ManagementObjectSearcher searcherWin32_LogicalDisk = new ManagementObjectSearcher("SELECT VolumeSerialNumber, Name FROM Win32_LogicalDisk");
            ManagementObjectSearcher searcherWin32_BaseBoard = new ManagementObjectSearcher("SELECT SerialNumber, Product, Version FROM Win32_BaseBoard");
            ManagementObjectSearcher searcherWin32_NetworkAdapter = new ManagementObjectSearcher("SELECT Name, MACAddress FROM Win32_NetworkAdapter");
            ManagementObjectSearcher searcherWin32_BIOS = new ManagementObjectSearcher("SELECT Name, Version, SerialNumber FROM Win32_BIOS");

            foreach (ManagementObject info in searcherWin32_BIOS.Get())
            {
                Console.WriteLine(info["Name"].ToString());
                Console.Write("[+] Press Enter To Return To Main Menu");
                Console.ReadLine();
                MainMenu();
            }
        }

        private static void ConsoleClose()
        {
            Console.Clear();
            Console.Write("[+] Press enter to close...");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
