using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using Gevlee.WinRadioTray.Player.Core;
using NAudio.Wave;

namespace Gevlee.WinRadioTray.Player
{
	public class PlayerService : IPlayerService
	{
		private Stream ms = new MemoryStream();

		public void SwitchRadiostation(string url)
		{
			var playThread = new Thread(timeout => PlayMp3FromUrl(url));
			playThread.IsBackground = true;
			playThread.Start();
		}

		public void PlayMp3FromUrl(string url)
		{
			new Thread(delegate (object o)
			{
				var response = WebRequest.Create(url).GetResponse();
				using (var stream = response.GetResponseStream())
				{
					byte[] buffer = new byte[65536]; // 64KB chunks
					int read;
					while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
					{
						var pos = ms.Position;
						ms.Position = ms.Length;
						ms.Write(buffer, 0, read);
						ms.Position = pos;
					}
				}
			}).Start();

			// Pre-buffering some data to allow NAudio to start playing
			while (ms.Length < 65536 * 10)
				Thread.Sleep(1000);

			ms.Position = 0;
			using (WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms))))
			{
				using (WaveOut waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
				{
					waveOut.Init(blockAlignedStream);
					waveOut.Play();
					while (waveOut.PlaybackState == PlaybackState.Playing)
					{
						System.Threading.Thread.Sleep(100);
					}
				}
			}
		}
	}
}