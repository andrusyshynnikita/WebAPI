using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AVFoundation;
using Foundation;
using TestProject.Core.Interface;
using UIKit;

namespace TestProject.IOS.Services
{
    public class AudioService : IAudioService
    {
        AVAudioSession _recordingSession;
        AVAudioRecorder _audioRecorder;

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

        public Task PlayRecording(int id)
        {
            throw new NotImplementedException();
        }

        public void RenameFile(int newName)
        {
        }

        public void StartRecording(int id)
        {

        }

        public void StopPlayRecording()
        {
        }

        public void StopRecording()
        {
        }
    }
}