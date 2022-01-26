using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using DiscordRPC;

namespace TyporaRPC
{
	public class App
	{
		private static readonly string _clientId = "935996568845312020";
		private static DiscordRpcClient _client;

		public static void Main(string[] args)
		{
			var processes = Process.GetProcesses();
			if (!processes.Any(p => p.MainWindowTitle.Contains("Typora")))
			{
				return;
			}

			_client = new DiscordRpcClient(_clientId);
			_client.OnReady += (sender, e) =>
			{
				Console.WriteLine("Ready! Make sure Typora is running and check your Discord status ", e.User.Username);
			};

			_client.Initialize();

			while (true)
			{
				Process typoraProcess = GetTyporaProcess();
				if (typoraProcess is null)
				{
					_client.ClearPresence();
					Thread.Sleep(5000);
					continue;
				}

				string rpcDetails = "";
				if (typoraProcess.MainWindowTitle.Replace(" - Typora", "").Replace("Typora", "").Replace("•", "") == "")
				{
					rpcDetails = "Not editing a file";
				}
				else
				{
					rpcDetails = $"Editing: {typoraProcess.MainWindowTitle.Replace(" - Typora", "")}";
				}

				string smallImage = "saved";
				if (rpcDetails.Contains("•"))
				{
					smallImage = "unsaved";
					rpcDetails = rpcDetails.Replace("•", "");
				}

				_client.SetPresence(new RichPresence()
				{
					Details = rpcDetails,
					State = "TyporaRPC by Myuuiii",
					Assets = new Assets()
					{
						LargeImageKey = "typora",
						SmallImageKey = smallImage,
						SmallImageText = smallImage
					}
				});
				Thread.Sleep(1000);
			}
		}

		private static Process GetTyporaProcess()
		{
			IEnumerable<Process> processes = Process.GetProcesses().Where(p => p.ProcessName.Contains("Typora") && !Regex.Match(p.MainWindowTitle, "[A-Z]:.*").Success);
			if (processes.Any(p => p.ProcessName.Contains("Typora")))
				return processes.First(p => p.ProcessName.Contains("Typora"));
			return null;
		}
	}
}