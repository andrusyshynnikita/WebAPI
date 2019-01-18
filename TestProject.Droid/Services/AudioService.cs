using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using TestProject.Core.Interface;
using TestProject.Core.Models;

namespace TestProject.Droid.Services
{
    public class AudioService : IAudioService
    {
        static long Time { get; set; }
        MediaRecorder _recorder;
        MediaPlayer _player;
        string path;
        private bool _checkAudioFile;



        public AudioService()
        {
            _recorder = new MediaRecorder();
            _player = new MediaPlayer();

            _player.Completion += (sender, e) =>
            {
                _player.Reset();
            };
        }

        public void StartRecording(int id)
        {
            path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), id.ToString() + TwitterUserId.Id_User + ".3gpp");
            try
            {
                if (File.Exists(path))
                    File.Delete(path);

                _recorder.SetAudioSource(AudioSource.Mic);
                _recorder.SetOutputFormat(OutputFormat.ThreeGpp);
                _recorder.SetAudioEncoder(AudioEncoder.AmrNb);
                _recorder.SetOutputFile(path);
                _recorder.Prepare();
                _recorder.Start();
            }

            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }
        }

        public void StopRecording()
        {
            try
            {
                _recorder.Stop();
                _recorder.Reset();
                //  _player.SetDataSource(path);
                OnRecordHandler();
            }
            catch (Exception e)
            {
                var str = e.Message;
            }
        }

        public async Task PlayRecording(int id)
        {
            path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), id.ToString() + TwitterUserId.Id_User + ".3gpp");

            try
            {
                if (_player == null)
                {
                    _player = new MediaPlayer();
                }
                else
                {
                    _player.Reset();
                }

                Java.IO.File file = new Java.IO.File(path);
                Java.IO.FileInputStream fis = new Java.IO.FileInputStream(file);
               await  _player.SetDataSourceAsync(fis.FD);
                _player.Prepare();
                _player.Start();
            }

            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }

        }

        public void StopPlayRecording()
        {
            if ((_player != null))
            {
                if (_player.IsPlaying)
                {
                    _player.Stop();
                }
                _player.Release();
                _player = null;
            }
        }

        public void RenameFile(int id)
        {
            File.Move(path, Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), id.ToString() + TwitterUserId.Id_User + ".3gpp"));

            File.Delete(path);
        }

        public bool CheckAudioFile(int id)
        {
          var  path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), id.ToString() + TwitterUserId.Id_User + ".3gpp");
          var result = File.Exists(path);

            return result;

        }
        public Action OnRecordHandler
        {
            get; set;
        }
    }
}