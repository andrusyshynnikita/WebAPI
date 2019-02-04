using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AudioToolbox;
using AVFoundation;
using Foundation;
using TestProject.Core.Interface;
using TestProject.Core.Models;
using UIKit;

namespace TestProject.IOS.Services
{
    public class AudioService :  IAudioService
    {
       private AVAudioSession _recordingSession;
       private AVAudioRecorder _audioRecorder;
        private AVAudioPlayer _audioPlayer;
        private AVPermissionGranted _permissionGranted;
        private NSUrl _url;
        private NSError _error;

        public Action OnRecordHandler { get; set; }
        public Action OnPlaydHandler { get ; set ; }

        public AudioService()
        {

        }

        public bool CheckAudioFile(int id)
        {
            return true;
        }

        public void DeleteNullFile()
        {
        }

        public void PlayRecording(int id)
        {
            var path = Path.Combine(System.Environment.
               GetFolderPath(System.Environment.
               SpecialFolder.Personal), "0" + TwitterUserId.Id_User + ".3gpp");

            if (File.Exists(path))
            {
                _url = NSUrl.FromFilename(path);
                _audioPlayer = new AVAudioPlayer(_url, ".3gpp", out _error);
                _audioPlayer.Play();
            }

        }

        public void StopPlayRecording()
        {
            _audioPlayer.Stop();
            _audioPlayer.Dispose();
        }

        public void RenameFile(int newName)
        {

        }

        public void StartRecording(int id)
        {
            //_recordingSession = AVAudioSession.SharedInstance();
            //_recordingSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
            //_recordingSession.RequestRecordPermission(delegate (bool granted) {
            //    Console.WriteLine("Audio Permission:" + granted);
            //});
            //_recordingSession.SetActive(true);

            var settings = new AudioSettings()
            {
                Format = AudioFormatType.LinearPCM,
                AudioQuality = AVAudioQuality.High,
                SampleRate = 44100f,
                NumberChannels = 1
            };
            var path  = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), "0" + TwitterUserId.Id_User + ".3gpp");
            _url = NSUrl.FromFilename(path);

             _audioRecorder = AVAudioRecorder.Create(_url, settings, out _error);
            _audioRecorder.PrepareToRecord();
            _audioRecorder.Record();
        }

        public void StopRecording()
        {
            _audioRecorder.Stop();
            _audioRecorder = null;
        }
    }

}