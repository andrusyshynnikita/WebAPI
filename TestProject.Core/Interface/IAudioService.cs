using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Core.Interface
{
   public interface IAudioService
    {
        void StartRecording(int id);
        void StopRecording();
        void PlayRecording(int id); //android use return Task
        void StopPlayRecording();
        void RenameFile(int newName);
        Action OnRecordHandler { get; set; }
        bool CheckAudioFile(int id);
        void DeleteNullFile();
        Action OnPlaydHandler { get; set; }
    }
}
