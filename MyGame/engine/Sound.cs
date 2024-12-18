using System;
using System.IO;
using NAudio.Wave;

public class Sound {
    private IWavePlayer waveOut;
    private AudioFileReader audioFileReader;

    public Sound(string filePath) {
        if (File.Exists(filePath)) {
            waveOut = new WaveOutEvent();
            audioFileReader = new AudioFileReader(filePath);
            waveOut.Init(audioFileReader);
        } else {
            Console.WriteLine($"Error: El archivo de sonido no existe: {filePath}");
        }
    }

    public void Play() {
        if (waveOut != null && audioFileReader != null) {
            audioFileReader.Position = 0;
            waveOut.Play();
        }
    }

    public void PlayLooping() {
        if (waveOut != null) {
            waveOut.PlaybackStopped += (sender, e) => {
                audioFileReader.Position = 0;
                waveOut.Play();
            };
            waveOut.Play();
        }
    }

    public void Stop() {
        waveOut?.Stop();
    }
}
