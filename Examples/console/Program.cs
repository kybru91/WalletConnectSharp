﻿using System;
using System.Security.Cryptography;
using WalletConnectSharp.Examples.Examples;

namespace WalletConnectSharp.Examples;

class Program
{
    private static readonly IExample[] Examples = new IExample[]
    {
            new NEthereumSendTransactionExample(),
            new SignTypedDataExample(),
            new BasicExample()
    };

    private static void ShowHelp()
    {
        Console.WriteLine("Please specify which example to run");
        foreach (var e in Examples)
        {
            Console.WriteLine("    - " + e.Name);
        }
    }

    public static async Task Main(string[] args)
    {
        if (args.Length == 0)
        {
            ShowHelp();
            return;
        }

        var name = args[0];
        var exampleArgs = args.Skip(1).ToArray();

        var example = Examples.FirstOrDefault(e => e.Name.ToLower() == name);

        if (example == null)
        {
            ShowHelp();
            return;
        }

        await example.Execute(exampleArgs);
    }
}
