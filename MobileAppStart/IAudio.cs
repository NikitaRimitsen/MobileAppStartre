using System;
using System.Collections.Generic;
using System.Text;

namespace MobileAppStart
{
    public interface IAudio
    {
        void PlayAudioFile(string fileName);
        void Stop(string fileName);
        //void StopAudioFile(string fileName);
    }
}
