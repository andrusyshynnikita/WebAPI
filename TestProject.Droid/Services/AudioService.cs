using System;
using System.IO;
using System.Threading.Tasks;
using Android;
using Android.Content;
using Android.Content.PM;
using Android.Media;
using Android.Support.V4.App;
using Android.Views;
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
        Context _context;
        private bool _checkAudioFile;
        static readonly int REQUEST_STORAGE = 0;
        private View _layout;



        public AudioService()
        {
            _recorder = new MediaRecorder();
            _player = new MediaPlayer();

            _player.Completion += (sender, e) =>
            {
                _player.Reset();
            };
        }

        public void PermissionsRecording()
        {
            if (ActivityCompat.CheckSelfPermission(_context, Manifest.Permission.RecordAudio) == (int)Permission.Granted)
            {
            }
        }

        public void StartRecording(int id)
        {
                path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), "0" + TwitterUserId.Id_User + ".3gpp");
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
                SpecialFolder.Personal), "0" + TwitterUserId.Id_User + ".3gpp");

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

                if (File.Exists(path))
                {
                    Java.IO.File file1 = new Java.IO.File(path);
                    Java.IO.FileInputStream fis1 = new Java.IO.FileInputStream(file1);
                    await _player.SetDataSourceAsync(fis1.FD);
                    _player.Prepare();
                    _player.Start();
                    _player.Completion += PlayCompletion;
                }

                else
                {
                    path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), id.ToString() + TwitterUserId.Id_User + ".3gpp");

                    Java.IO.File file2 = new Java.IO.File(path);
                    Java.IO.FileInputStream fis2 = new Java.IO.FileInputStream(file2);
                    await _player.SetDataSourceAsync(fis2.FD);
                    _player.Prepare();
                    _player.Start();

                    _player.Completion += PlayCompletion;
                }
                
            }

            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }

        }

        private void PlayCompletion(object sender, EventArgs e)
        {
            OnPlaydHandler();
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
            path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), "0" + TwitterUserId.Id_User + ".3gpp");

            File.Move(path, Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), id.ToString() + TwitterUserId.Id_User + ".3gpp"));

            File.Delete(path);
        }

        public void DeleteNullFile()
        {
            path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                SpecialFolder.Personal), "0" + TwitterUserId.Id_User + ".3gpp");

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

        public Action OnPlaydHandler
        {
            get; set;
        }

        public Action OnRecordHandler
        {
            get; set;
        }
    }
}