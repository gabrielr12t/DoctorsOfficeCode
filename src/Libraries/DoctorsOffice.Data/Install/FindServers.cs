﻿using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace DoctorsOffice.Data.Install
{
    public class FindServers
    {
        public IEnumerable<string> GetSqlServersName()
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Microsoft SQL Server");
            string[] instances = (string[])rk.GetValue("InstalledInstances");
            if (instances.Length > 0)
            {
                foreach (string element in instances)
                {
                    if (element == "MSSQLSERVER")
                        yield return Environment.MachineName;
                    else
                        yield return Environment.MachineName + @"\" + element;
                }
            }
        }
    }
}
