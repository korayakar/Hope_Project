using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;
using System.Collections;
using System.IO;

public class VoiceRecorder : MonoBehaviour
{
    private bool isRecording = false;
    private string outputFileName;
    private string microphoneDevice;
    private AudioClip recordedClip;

    private void Start()
    {
        // Initialize Oculus Integration XR plugin
        XRGeneralSettings.Instance.Manager.InitializeLoaderSync();

        // Get the microphone device for recording
        microphoneDevice = Microphone.devices[0]; // Assuming the first device, you can change it accordingly
    }

    public void StartRecording()
    {
        if (isRecording)
        {
            Debug.Log("Already recording...");
            return;
        }

        // Start recording
        outputFileName = Path.Combine("C:\\Users\\evrim\\Desktop\\VoiceRecord\\", "recording.wav");
        recordedClip = Microphone.Start(microphoneDevice, false, 20, AudioSettings.outputSampleRate);

        Debug.Log("Recording started...");
        isRecording = true;
    }

    public void StopRecording()
    {
        if (!isRecording)
        {
            Debug.Log("Not currently recording...");
            return;
        }

        // Stop recording
        Microphone.End(microphoneDevice);
        Debug.Log("Recording stopped...");

        // Save the recorded audio as a WAV file
        SaveWav(outputFileName, recordedClip);

        Debug.Log("Recording saved to: " + outputFileName);

        isRecording = false;
    }

    private void SaveWav(string filePath, AudioClip clip)
    {
        // Get the audio data from the AudioClip
        float[] data = new float[clip.samples];
        clip.GetData(data, 0);

        // Convert the audio data to byte array
        byte[] byteArray = new byte[data.Length * 2];
        for (int i = 0; i < data.Length; i++)
        {
            short shortData = (short)(data[i] * 32767);
            byteArray[i * 2] = (byte)(shortData & 0xff);
            byteArray[i * 2 + 1] = (byte)((shortData >> 8) & 0xff);
        }

        // Create the WAV file header
        byte[] header = CreateWavHeader(clip.channels, clip.frequency, 16, byteArray.Length);

        // Write the WAV file
        using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
        {
            fileStream.Write(header, 0, header.Length);
            fileStream.Write(byteArray, 0, byteArray.Length);
        }
    }

    private byte[] CreateWavHeader(int channels, int sampleRate, int bitsPerSample, int dataLength)
    {
        int headerLength = 44;
        byte[] header = new byte[headerLength];

        // ChunkID
        header[0] = (byte)'R';
        header[1] = (byte)'I';
        header[2] = (byte)'F';
        header[3] = (byte)'F';

        // ChunkSize
        int totalLength = dataLength + headerLength - 8;
        header[4] = (byte)(totalLength & 0xff);
        header[5] = (byte)((totalLength >> 8) & 0xff);
        header[6] = (byte)((totalLength >> 16) & 0xff);
        header[7] = (byte)((totalLength >> 24) & 0xff);

        // Format
        header[8] = (byte)'W';
        header[9] = (byte)'A';
        header[10] = (byte)'V';
        header[11] = (byte)'E';

        // Subchunk1ID
        header[12] = (byte)'f';
        header[13] = (byte)'m';
        header[14] = (byte)'t';
        header[15] = (byte)' ';

        // Subchunk1Size
        header[16] = 16;
        header[17] = 0;
        header[18] = 0;
        header[19] = 0;

        // AudioFormat
        header[20] = 1;
        header[21] = 0;

        // NumChannels
        header[22] = (byte)channels;
        header[23] = 0;

        // SampleRate
        header[24] = (byte)(sampleRate & 0xff);
        header[25] = (byte)((sampleRate >> 8) & 0xff);
        header[26] = (byte)((sampleRate >> 16) & 0xff);
        header[27] = (byte)((sampleRate >> 24) & 0xff);

        // ByteRate
        int byteRate = sampleRate * channels * bitsPerSample / 8;
        header[28] = (byte)(byteRate & 0xff);
        header[29] = (byte)((byteRate >> 8) & 0xff);
        header[30] = (byte)((byteRate >> 16) & 0xff);
        header[31] = (byte)((byteRate >> 24) & 0xff);

        // BlockAlign
        int blockAlign = channels * bitsPerSample / 8;
        header[32] = (byte)(blockAlign & 0xff);
        header[33] = (byte)((blockAlign >> 8) & 0xff);

        // BitsPerSample
        header[34] = (byte)bitsPerSample;
        header[35] = 0;

        // Subchunk2ID
        header[36] = (byte)'d';
        header[37] = (byte)'a';
        header[38] = (byte)'t';
        header[39] = (byte)'a';

        // Subchunk2Size
        header[40] = (byte)(dataLength & 0xff);
        header[41] = (byte)((dataLength >> 8) & 0xff);
        header[42] = (byte)((dataLength >> 16) & 0xff);
        header[43] = (byte)((dataLength >> 24) & 0xff);

        return header;
    }
}
