using UnityEngine;

public static class VibrationManager
{
    public enum EVibrationIntensity
    {
        Light,
        Medium,
        Heavy
    }

    public static void Vibrate(EVibrationIntensity intensity)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        if (SystemInfo.supportsVibration)
        {
            AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");

            long[] pattern;
            switch (intensity)
            {
                case EVibrationIntensity.Light:
                    pattern = new long[] { 0, 30, 100, 30 };
                    break;
                case EVibrationIntensity.Medium:
                    pattern = new long[] { 0, 30, 100, 30, 100, 30, 100, 30 };
                    break;
                case EVibrationIntensity.Heavy:
                    pattern = new long[] { 0, 200, 100, 200, 100, 200, 100, 200, 100, 200, 100, 200, 100, 200, 100, 200, 100, 200, 100 };
                    break;
                default:
                    pattern = new long[] { 0 };
                    break;
            }

            vibrator.Call("vibrate", pattern, -1);
        }
#elif UNITY_IOS && !UNITY_EDITOR
        switch (intensity)
        {
            case EVibrationIntensity.Light:
                if (UnityEngine.iOS.Device.generation >= UnityEngine.iOS.DeviceGeneration.iPhone6S)
                {
                    UnityEngine.iOS.Device.Vibrate();
                }
                break;
            case EVibrationIntensity.Medium:
                if (UnityEngine.iOS.Device.generation >= UnityEngine.iOS.DeviceGeneration.iPhone7)
                {
                    UnityEngine.iOS.Device.Vibrate();
                    UnityEngine.iOS.Device.Vibrate();
                    UnityEngine.iOS.Device.Vibrate();
                }
                break;
            case EVibrationIntensity.Heavy:
                if (UnityEngine.iOS.Device.generation >= UnityEngine.iOS.DeviceGeneration.iPhone7)
                {
                    UnityEngine.iOS.Device.Vibrate();
                    UnityEngine.iOS.Device.Vibrate();
                    UnityEngine.iOS.Device.Vibrate();
                    UnityEngine.iOS.Device.Vibrate();
                    UnityEngine.iOS.Device.Vibrate();
                    UnityEngine.iOS.Device.Vibrate();
                    UnityEngine.iOS.Device.Vibrate();
                    UnityEngine.iOS.Device.Vibrate();
                    UnityEngine.iOS.Device.Vibrate();
                    UnityEngine.iOS.Device.Vibrate();
                }
                break;
            default:
                break;
        }
#endif
    }
}

