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
        private string _path;

        public Action OnRecordHandler { get; set; }
        public Action OnPlaydHandler { get ; set ; }

        public AudioService()
        {
        }

        public bool CheckAudioFile(int id)
        {
            var path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), id.ToString() + TwitterUserId.Id_User + ".3gpp");
            var result = File.Exists(path);

            return result;
        }

        public void DeleteNullFile()
        {
            _path = Path.Combine(System.Environment.
               GetFolderPath(System.Environment.
               SpecialFolder.Personal), "0" + TwitterUserId.Id_User + ".3gpp");

            File.Delete(_path);
        }

        public void PlayRecording(int id)
        {
            if (_audioPlayer != null)
            {
                _audioPlayer.Dispose();
            }

            var path = Path.Combine(System.Environment.
               GetFolderPath(System.Environment.
               SpecialFolder.Personal), "0" + TwitterUserId.Id_User + ".3gpp");

            if (File.Exists(path))
            {
                _url = NSUrl.FromFilename(path);
                _audioPlayer =  AVAudioPlayer.FromUrl(_url, out _error);
                _audioPlayer.Play();
                _audioPlayer.FinishedPlaying += PlayCompletion;
            }

            else
            {
                path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), id.ToString() + TwitterUserId.Id_User + ".3gpp");
                _url = NSUrl.FromFilename(path);
                _audioPlayer = AVAudioPlayer.FromUrl(_url, out _error);
                _audioPlayer.Play();
                _audioPlayer.FinishedPlaying += PlayCompletion;

            }

        }

        private void PlayCompletion(object sender, AVStatusEventArgs e)
        {
            OnPlaydHandler();
        }

        public void StopPlayRecording()
        {
            if ((_audioPlayer != null))
            {
                if (_audioPlayer.Playing)
                {
                    _audioPlayer.Stop();
                }
               
                _audioPlayer = null;
               // _audioPlayer.Dispose();
            }
        }

        public void RenameFile(int id)
        {
            _path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), "0" + TwitterUserId.Id_User + ".3gpp");

            File.Move(_path, Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), id.ToString() + TwitterUserId.Id_User + ".3gpp"));

            File.Delete(_path);
        }

        public void StartRecording(int id)
        {
            if (File.Exists(_path))
                File.Delete(_path);

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
            OnRecordHandler();
        }

    }

}