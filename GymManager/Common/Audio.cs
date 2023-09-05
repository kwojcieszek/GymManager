using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicAudio;

namespace GymManager.Common
{
    public class Audio
    {
        private readonly Dictionary<string, string> _audioDirectory = new();

        public Audio()
        {
            _audioDirectory.Add("beep", $"{Path.ApplicationDirectory}\\Sounds\\Beep.wav");
            _audioDirectory.Add("entry", $"{Path.ApplicationDirectory}\\Sounds\\Entry.wav");
            _audioDirectory.Add("exit", $"{Path.ApplicationDirectory}\\Sounds\\Exit.wav");
            _audioDirectory.Add("warning", $"{Path.ApplicationDirectory}\\Sounds\\Warning.wav");
        }

        public void Play(params string[] wavesName)
        {
            Task.Factory.StartNew(() =>
            {
                foreach(var wave in wavesName)
                {
                    Play(wave, true);
                }
            });
        }

        public void Play(string waveName, bool wait = false)
        {
            try
            {
                Task.Factory.StartNew(() =>
                {
                    var fileName = _audioDirectory.GetValueOrDefault(waveName);

                    if(fileName == null)
                    {
                        return;
                    }

                    var audio = new AudioPlayer();
                    audio.Close();
                    audio.Filename = fileName;
                    audio.Play();

                    if(wait)
                    {
                        Task.Delay(audio.Milliseconds).Wait();
                    }
                });
            }
            catch(Exception ex)
            {
                Logger.Log.Error(ex);
            }
        }
    }
}