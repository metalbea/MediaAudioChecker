class AudioPlayChecker
    {
        public static MMDevice currentDevice = GetDefaultRenderDevice();
        // Gets the default device for the system
        private static MMDevice GetDefaultRenderDevice()
        {
            using (var enumerator = new MMDeviceEnumerator())
            {
                return enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
            }
        }

        // Checks if audio is playing on a certain device
        public static bool IsAudioPlaying()
        {
            using (var meter = AudioMeterInformation.FromDevice(currentDevice))
            {
                return meter.PeakValue > 0;
            }
        }

        public static void toggleAudio()
        {
            bool status = IsAudioPlaying();
            
            InputSimulator inputSimulator = new InputSimulator();
            inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.MEDIA_PLAY_PAUSE);
            while (status == IsAudioPlaying())
            {
                //while loop is to make sure that the audio started before the end of the function
            }
            
        }

        public static void playAudio()
        {
            //bool status = IsAudioPlaying();
            //if(!status)
            //{
            //    InputSimulator inputSimulator = new InputSimulator();
            //    inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.MEDIA_PLAY_PAUSE);
            //}

            InputSimulator inputSimulator = new InputSimulator();
            inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.MEDIA_PLAY_PAUSE);
        }

        public static void pauseAudio()
        {
            //bool status = IsAudioPlaying();
            //if(status)
            //{
            //    InputSimulator inputSimulator = new InputSimulator();
            //    inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.MEDIA_PLAY_PAUSE);
            //}

            InputSimulator inputSimulator = new InputSimulator();
            inputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.MEDIA_PLAY_PAUSE);
        }
    }
