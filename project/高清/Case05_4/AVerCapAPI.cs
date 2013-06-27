/////////////////////////////////////////////////////////////////////////////
// (c) Copyright AVerMedia Technologies, Inc. 2011. All Rights Reserved.
//
//  Module:
//
//    AVerCapAPI.cs
//
//  Date:
//
//	  9/13/2011
//
//  Abstract:
//
//    Header file for AVerCapAPI.DLL
//
/////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Case05_4
{
    // error code
    public enum ERRORCODE
    {
        CAP_EC_SUCCESS = 0,
        CAP_EC_INIT_DEVICE_FAILED = -1,
        CAP_EC_DEVICE_IN_USE = -2,
        CAP_EC_NOT_SUPPORTED = -3,
        CAP_EC_INVALID_PARAM = -4,
        CAP_EC_TIMEOUT = -5,
        CAP_EC_NOT_ENOUGH_MEMORY = -6,
        CAP_EC_UNKNOWN_ERROR = -7,
        CAP_EC_ERROR_STATE = -8
    }

    //CARDTYPE
    public enum CARDTYPE
    {
        CARDTYPE_NULL = 0,
        CARDTYPE_C727 = 1,
        CARDTYPE_C729 = 2,
        CARDTYPE_C199 = 3,
        CARDTYPE_C199X = 4,
        CARDTYPE_C874 = 5,
        CARDTYPE_V1A8 = 6,
        CARDTYPE_C039 = 7,
        CARDTYPE_C725 = 8,
        CARDTYPE_C129 = 9,
        CARDTYPE_C968 = 10
    }

    //device type
    public enum DEVICETYPE
    {
        DEVICETYPE_SD = 1,
        DEVICETYPE_HD = 2,
        DEVICETYPE_ALL = 3
    }

    // video input source
    public enum VIDEOSOURCE
    {
        VIDEOSOURCE_COMPOSITE = 0,
        VIDEOSOURCE_SVIDEO = 1,
        VIDEOSOURCE_COMPONENT = 2,
        VIDEOSOURCE_HDMI = 3,
        VIDEOSOURCE_VGA = 4
    }

    // video format
    public enum VIDEOFORMAT
    {
        VIDEOFORMAT_NTSC = 0,
        VIDEOFORMAT_PAL = 1
    }

    // video resolution
    public enum VIDEORESOLUTION
    {
        VIDEORESOLUTION_640X480 = 0,
        VIDEORESOLUTION_704X576 = 1,
        VIDEORESOLUTION_720X480 = 2,
        VIDEORESOLUTION_720X480P = 3,
        VIDEORESOLUTION_720X576 = 4,
        VIDEORESOLUTION_720X576P = 5,
        VIDEORESOLUTION_1280X720P = 6,
        VIDEORESOLUTION_1920X1080 = 7,
        VIDEORESOLUTION_1024X768P = 8,
        VIDEORESOLUTION_1280X800P = 9,
        VIDEORESOLUTION_1280X1024P = 10,
        VIDEORESOLUTION_1440X900P = 11,
        VIDEORESOLUTION_1600X1200P = 12,
        VIDEORESOLUTION_1680X1050P = 13,
        VIDEORESOLUTION_1920X1080P = 14,
        VIDEORESOLUTION_1920X1080P_24FPS = 15,
        VIDEORESOLUTION_640X480P = 16,
        VIDEORESOLUTION_800X600P = 17,
        VIDEORESOLUTION_1280X768P = 18,
        VIDEORESOLUTION_1360X768P = 19,
        VIDEORESOLUTION_160X120 = 20,   // SD
        VIDEORESOLUTION_176X144 = 21,
        VIDEORESOLUTION_240X176 = 22,
        VIDEORESOLUTION_240X180 = 23,
        VIDEORESOLUTION_320X240 = 24,
        VIDEORESOLUTION_352X240 = 25,
        VIDEORESOLUTION_352X288 = 26,
        VIDEORESOLUTION_640X240 = 27,
        VIDEORESOLUTION_640X288 = 28,
        VIDEORESOLUTION_720X240 = 29,
        VIDEORESOLUTION_720X288 = 30,
        VIDEORESOLUTION_80X60 = 31,
        VIDEORESOLUTION_88X72 = 32,
        VIDEORESOLUTION_128X96 = 33,
        VIDEORESOLUTION_640X576 = 34,
        VIDEORESOLUTION_1152X864P = 35,
        VIDEORESOLUTION_1280X960P = 36,
        VIDEORESOLUTION_180X120 = 37,
        VIDEORESOLUTION_180X144 = 38,
        VIDEORESOLUTION_360X240 = 39,
        VIDEORESOLUTION_360X288 = 40
    }

    // video adjustment property
    public enum VIDEOPROCAMPPROPERTY
    {
        VIDEOPROCAMPPROPERTY_BRIGHTNESS = 0,
        VIDEOPROCAMPPROPERTY_CONTRAST = 1,
        VIDEOPROCAMPPROPERTY_HUE = 2,
        VIDEOPROCAMPPROPERTY_SATURATION = 3
    }

    // deinterlace mode
    public enum DEINTERLACEMODE
    {
        DEINTERLACE_NONE = 0,
        DEINTERLACE_WEAVE = 1,
        DEINTERLACE_BOB = 2,
        DEINTERLACE_BLEND = 3
    }

    // downscale mode
    public enum DOWNSCALEMODE
    {
        DSMODE_NONE = 0,
        DSMODE_HALFHEIGHT = 1,
        DSMODE_HALFWIDTH = 2,
        DSMODE_HALFBOTH = 3,
        DSMODE_CUSTOM = 5
    }

    // overlay settings
    public enum OVERLAYSETTINGS
    {
        OVERLAY_TEXT = 0,
        OVERLAY_TIME = 1,
        OVERLAY_IMAGE = 2
    }

    public enum FONTSIZE
    {
        FONTSIZE_SMALL = 0,
        FONTSIZE_BIG = 1
    }

    public enum TIMEFORMAT
    {
        FORMAT_TIMEONLY = 0,
        FORMAT_DATEANDTIME = 1
    }

    public enum ALIGNMENT
    {
        ALIGNMENT_LEFT = 0,
        ALIGNMENT_CENTER = 1,
        ALIGNMENT_RIGHT = 2
    }

    // video frame/field capture settings
    public enum CT_SEQUENCE
    {
        CT_SEQUENCE_FIELD = 0,
        CT_SEQUENCE_FRAME = 1
    }

    public enum SAVETYPE
    {
        ST_BMP = 0,
        ST_JPG = 1,
        ST_AVI = 2,
        ST_CALLBACK = 3,
        ST_WAV = 4,
        ST_WMV = 5,
        ST_PNG = 6,
        ST_MPG = 7,
        ST_MP4 = 8,
        ST_TIFF = 9,
        ST_CALLBACK_RGB24 = 10,
        ST_CALLBACK_ARGB = 11
    }

    public enum VIDEOENHANCE
    {
        VIDEOENHANCE_NONE = 0,
        VIDEOENHANCE_NORMAL = 1,
        VIDEOENHANCE_SPLIT = 2,
        VIDEOENHANCE_COMPARE = 3
    }

    public enum VIDEOMIRROR
    {
        VIDEOMIRROR_NONE = 0,
        VIDEOMIRROR_HORIZONTAL = 1,
        VIDEOMIRROR_VERTICAL = 2,
        VIDEOMIRROR_BOTH = 3
    }

    public enum DURATIONMODE
    {
        DURATION_TIME = 1,
        DURATION_COUNT = 2
    }

    public enum AUDIOBITRATE
    {
        AUDIOBITRATE_96 = 0,
        AUDIOBITRATE_112 = 1,
        AUDIOBITRATE_128 = 2,
        AUDIOBITRATE_144 = 3,
        AUDIOBITRATE_160 = 4,
        AUDIOBITRATE_176 = 5,
        AUDIOBITRATE_192 = 6,
        AUDIOBITRATE_224 = 7,
        AUDIOBITRATE_256 = 8,
        AUDIOBITRATE_288 = 9,
        AUDIOBITRATE_320 = 10,
        AUDIOBITRATE_352 = 11,
        AUDIOBITRATE_384 = 12,
        AUDIOBITRATE_64 = 13
    }

    public enum VIDEOROTATE
    {
        VIDEOROTATE_NONE = 0,
        VIDEOROTATE_CW90 = 1,
        VIDEOROTATE_CCW90 = 2
    }

    public enum ENCODERTYPE
    {
        ENCODERTYPE_MPEGAUDIO = 0x00000001,
        ENCODERTYPE_H264 = 0x00000002
    }

    public enum RCMODE
    {
        RCMODE_CBR = 1,
        RCMODE_VBR = 2
    }

    //Capture type
    public enum CT
    {
        CT_CALLBACK_MPEGAUDIO = 0x00000001,
        CT_CALLBACK_H264 = 0x00000002,
        CT_CALLBACK_TS = 0x00000004,
        CT_FILE_TS = 0x01000000,
        CT_FILE_MP4 = 0x02000000
    }

    //Sample type
    public enum SAMPLETYPE
    {
        SAMPLETYPE_NULL = 0,
        SAMPLETYPE_RAWVIDEO = 0x01,
        SAMPLETYPE_PCMAUDIO = 0x02,
        SAMPLETYPE_TS = 0x10,
        SAMPLETYPE_ES_H264 = 0x20,
        SAMPLETYPE_ES_MPEG4AAC = 0x30,
        SAMPLETYPE_ES_MPEGAUDIO = 0x31,
    }

    // video renderer
    public enum VIDEORENDERER
    {
        VIDEORENDERER_DEFAULT = 0,//VMR9
        VIDEORENDERER_VMR7 = 1,
        VIDEORENDERER_VMR9 = 2,
        VIDEORENDERER_EVR = 3//vista, win7, server 2008
    }

    public enum IMAGEQUALITY
    {
        IMAGEQUALITY_BEST = 0,
        IMAGEQUALITY_NORMAL = 1,
        IMAGEQUALITY_LOW = 2
    }

    public enum HWVA
    {
        HWVA_ENCODER_H264 = 0x01
    }

    public struct OVERLAY_POSITION
    {
        public uint dwXPos;
        public uint dwYPos;
        public uint dwAlignment;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OVERLAY_IMAGE_INFO
    {
        public string lpFileName;
        public uint dwImageType;//obsolete
    }

    public struct OVERLAY_INFO
    {
        public int bEnableOverlay;
        public uint dwFontSize;
        public uint dwFontColor;
        public uint dwTransparency;
        public OVERLAY_POSITION WindowPosition;
    }

    public struct VIDEO_SAMPLE_INFO
    {
        public uint dwWidth;
        public uint dwHeight;
        public uint dwStride;
        public uint dwPixelFormat;
    }

    public delegate int VIDEOCAPTURECALLBACK(VIDEO_SAMPLE_INFO VideoInfo, IntPtr pbData, int lLength, long tRefTime, int lUserData);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct VIDEO_CAPTURE_INFO
    {
        public uint dwCaptureType;
        public uint dwSaveType;
        public int bOverlayMix;
        public uint dwDurationMode;
        public uint dwDuration;
        public string lpFileName;
        public VIDEOCAPTURECALLBACK lpCallback;
        public int lCallbackUserData;
    }

    // audio sample capture settings
    public struct AUDIO_SAMPLE_INFO
    {
        public uint dwChannels;
        public uint dwBitsPerSample;
        public uint dwSamplingRate;
    }

    public delegate int AUDIOCAPTURECALLBACK(AUDIO_SAMPLE_INFO AudioInfo, IntPtr pbData, int lLength, long tRefTime, int lUserData);

    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct VIDEO_COMPRESSOR_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public char[] szName;
        public int bPropertyPageSupported;
        public int bQualitySupported;
        public int bPropertyPageVisabled;
        public uint dwQuality;
    }

    public struct AUDIO_SAMPLE_FORMAT
    {
        public uint dwChannels;
        public uint dwBitsPerSample;
        public uint dwSamplingRate;
        public uint dwAvgBytesPerSec;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AUDIO_COMPRESSOR_INFO
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public char[] szName;
        public AUDIO_SAMPLE_FORMAT AudioSampleFormat;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AUDIO_CAPTURE_INFO
    {
        public uint dwSaveType;
        public string lpFileName;
        public AUDIOCAPTURECALLBACK lpCallback;
        public int lCallbackUserData;
        public int lReserved;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct BITMAPFILEHEADER
    {
        public ushort bfType;
        public uint bfSize;
        public ushort bfReserved1;
        public ushort bfReserved2;
        public uint bfOffBits;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFOHEADER
    {
        public uint biSize;
        public int biWidth;
        public int biHeight;
        public ushort biPlanes;
        public ushort biBitCount;
        public uint biCompression;
        public uint biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public uint biClrUsed;
        public uint biClrImportant;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct VIDEO_STREAM_INFO
    {
        public int bEnableMix;
        public uint dwWidth;
        public uint dwHeight;
        public uint dwPixelFormat;
        public RECT rcMixPosition;
        public uint dwTransparency;
        public uint dwReserved1;
        public uint dwReserved2;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WMV_VIDEOENCODER_INFO
    {
        public uint dwBitrate;
        public uint dwQuality;
        public uint dwReserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WMV_AUDIOENCODER_INFO
    {
        public uint dwChannels;
        public uint dwBitsPerSample;
        public uint dwSamplingRate;
        public uint dwBitrate;
        public uint dwReserved;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct WAKEUP_TIME
    {
        public uint dwYear;
        public uint dwMonth;
        public uint dwDay;
        public uint dwHour;
        public uint dwMinute;
        public uint dwSecond;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MPEG2_VIDEOENCODER_INFO
    {
        public uint dwVersion;
        public uint dwBitrate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MPEG2_AUDIOENCODER_INFO
    {
        public uint dwVersion;
        public uint dwBitrate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MPEG4_VIDEOENCODER_INFO
    {
        public uint dwVersion;//must set to 2
        public uint dwBitrate;
        public uint dwGOPLength;
        public int bHardwareAcceleration;
        public uint dwQuality;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MPEG4_AUDIOENCODER_INFO
    {
        public uint dwVersion;
        public uint dwBitrate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT_VIDEO_INFO
    {
        public uint dwVersion;
        public uint dwWidth;
        public uint dwHeight;
        public int bProgressive;
        public uint dwFormat;
        public uint dwFramerate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HW_VIDEOENCODER_INFO
    {
        public uint dwVersion;
        public uint dwEncoderType;
        public uint dwRcMode;
        public uint dwBitrate;
        public uint dwMinBitrate;
        public uint dwMaxBitrate;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HW_AUDIOENCODER_INFO
    {
        public uint dwVersion;
        public uint dwEncoderType;
        public uint dwBitrate;
        public uint dwSamplingRate;  //Must be set to 0 (default)
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SAMPLE_INFO
    {
        public uint dwSampleType;
        public IntPtr lpSampleInfo;
    }

    public delegate int CAPTURECALLBACK(SAMPLE_INFO SampleInfo, IntPtr pbData, int lLength, long tRefTime, IntPtr lpUserData);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct HW_STREAM_CAPTURE_INFO
    {
        public uint dwVersion;
        public uint dwCaptureType;
        public CAPTURECALLBACK lpMainCallback;
        public CAPTURECALLBACK lpSecondaryCallback;
        public string lpFileName;
        public IntPtr lpMainCallbackUserData;
        public IntPtr lpSecondaryCallbackUserData;
    }

    //third audio capture
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AUDIOCAPTURESOURCE_INFO
    {
        public uint dwVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] szName;
        public uint dwIndex;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AUDIOCAPTURESOURCE_INPUTTYPE_INFO
    {
        public uint dwVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] szName;
        public uint dwIndex;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct AUDIOCAPTURESOURCE_FORMAT_INFO
    {
        public uint dwVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public char[] szName;
        public uint dwIndex;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct AUDIOCAPTURESOURCE_SETTING
    {
        public uint dwVersion;
        public uint dwCapSourceIndex;
        public uint dwInputTypeIndex;
        public uint dwFormatIndex;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OVERLAY_CONTENT_INFO
    {
        public uint dwVersion;
        public uint dwContentType;
        public IntPtr lpContent;
        public uint dwDuration;
        public uint dwID;
        public uint dwPriority;
        public OVERLAY_INFO OverlayInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct OVERLAY_DC_INFO
    {
        public uint dwVersion;
        public int bClear;
        public IntPtr hDC;
        public uint dwDCWidth;
        public uint dwDCHeight;
        public uint dwBkColor;
        public uint dwBkTransparency;
        public OVERLAY_POSITION WindowPosition;
    }

    static class AVerCapAPI
    {

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetDeviceNum(ref uint pDeviceNum);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerGetDeviceName(uint nDeviceIndex, StringBuilder szDeviceName);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerCreateCaptureObject(uint nDeviceIndex, IntPtr hWnd, ref IntPtr phCaptureObject);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerCreateCaptureObjectEx(uint dwDeviceIndex, uint dwType, IntPtr hWnd, ref IntPtr phCaptureObject);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerDeleteCaptureObject(IntPtr hCaptureObject);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoWindowPosition(IntPtr hCaptureObject, RECT rectVideoWnd);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerRepaintVideo(IntPtr hCaptureObject);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoRenderer(IntPtr hCaptureObject, uint dwVideoRenderer);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoRenderer(IntPtr hCaptureObject, ref uint pdwVideoRenderer);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetMaintainAspectRatioEnabled(IntPtr hCaptureObject, int bEnabled);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetMaintainAspectRatioEnabled(IntPtr hCaptureObject, ref int pbEnabled);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetAspectRatio(IntPtr hCaptureObject, ref uint pdwAspectRatioX, ref uint pdwAspectRatioY);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoSource(IntPtr hCaptureObject, uint dwVideoSource);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoSource(IntPtr hCaptureObject, ref uint pdwVideoSource);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoFormat(IntPtr hCaptureObject, uint dwVideoFormat);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoFormat(IntPtr hCaptureObject, ref uint pdwVideoFormat);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoResolution(IntPtr hCaptureObject, uint dwVideoResolution);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoResolution(IntPtr hCaptureObject, ref uint pdwVideoResolution);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoInputFrameRate(IntPtr hCaptureObject, uint dwFrameRate);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoInputFrameRate(IntPtr hCaptureObject, ref uint pdwFrameRate);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetAudioSamplingRate(IntPtr hCaptureObject, uint dwSamplingRate);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetAudioSamplingRate(IntPtr hCaptureObject, ref uint pdwSamplingRate);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerStartStreaming(IntPtr hCaptureObject);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerStopStreaming(IntPtr hCaptureObject);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoProcAmp(IntPtr hCaptureObject, uint dwVideoProcAmpProperty, uint dwPropertyValue);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoProcAmp(IntPtr hCaptureObject, uint dwVideoProcAmpProperty, ref uint pdwPropertyValue);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetDeinterlaceMode(IntPtr hCaptureObject, uint dwMode);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetDeinterlaceMode(IntPtr hCaptureObject, ref uint pdwMode);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoDownscaleMode(IntPtr hCaptureObject, uint dwMode, uint dwWidth, uint dwHeight);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoDownscaleMode(IntPtr hCaptureObject, ref uint pdwMode, ref uint pdwWidth, ref uint pdwHeight);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerCaptureAudioSampleStart(IntPtr hCaptureObject, AUDIOCAPTURECALLBACK lpCallback, int lCallbackUserData);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerCaptureAudioSampleStartEx(IntPtr hCaptureObject, AUDIO_CAPTURE_INFO CaptureInfo);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerCaptureAudioSampleStop(IntPtr hCaptureObject);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerCaptureSingleImageToBuffer(IntPtr hCaptureObject, byte[] lpBmpData, ref int plBufferSize, int bOverlayMix, uint dwTimeout);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetOverlayProperty(IntPtr hCaptureObject, uint dwContentType, OVERLAY_INFO OverlayInfo);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetOverlayProperty(IntPtr hCaptureObject, uint dwContentType, ref OVERLAY_INFO pOverlayInfo);

        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerOverlayText(IntPtr hCaptureObject, string lpText, uint dwDuration);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerOverlayTime(IntPtr hCaptureObject, uint dwFormat, uint dwDuration);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerOverlayImage(IntPtr hCaptureObject, OVERLAY_IMAGE_INFO ImageInfo, uint dwDuration);

        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerOverlayMediaContent(IntPtr hCaptureObject, ref OVERLAY_CONTENT_INFO pContentInfo);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerOverlayDC(IntPtr hCaptureObject, ref OVERLAY_DC_INFO pOverlayDCInfo);

        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerCaptureVideoSequenceStart(IntPtr hCaptureObject, VIDEO_CAPTURE_INFO CaptureInfo);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerCaptureVideoSequenceStop(IntPtr hCaptureObject);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetHDMIVideoInfo(IntPtr hCaptureObject, ref uint pdwWidth, ref uint pdwHeight, ref int pbProgressive, ref uint pdwVideoFormat);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetHDMIAudioInfo(IntPtr hCaptureObject, ref uint pdwSamplingRate);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoInfo(IntPtr hCaptureObject, ref INPUT_VIDEO_INFO pVideoInfo);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetComponentVideoInfo(IntPtr hCaptureObject, ref uint pdwWidth, ref uint pdwHeight, ref int pbProgressive, ref uint pdwVideoFormat);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetMacroVisionMode(IntPtr hCaptureObject, ref uint pdwMode);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetSignalPresence(IntPtr hCaptureObject, ref int pbSignalPresence);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetNoiseReductionEnabled(IntPtr hCaptureObject, int bEnabled);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetNoiseReductionEnabled(IntPtr hCaptureObject, ref int pbEnabled);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoOutputFrameRate(IntPtr hCaptureObject, uint dwFrameRate);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoOutputFrameRate(IntPtr hCaptureObject, ref uint pdwFrameRate);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoPreviewEnabled(IntPtr hCaptureObject, int bEnabled);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoPreviewEnabled(IntPtr hCaptureObject, ref int pbEnabled);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetAudioPreviewEnabled(IntPtr hCaptureObject, int bEnabled);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetAudioPreviewEnabled(IntPtr hCaptureObject, ref int pbEnabled);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetAudioRecordEnabled(IntPtr hCaptureObject, int bEnabled);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetAudioRecordEnabled(IntPtr hCaptureObject, ref int pbEnabled);

        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerEnumVideoCompressor(IntPtr hCaptureObject, IntPtr pVideoCompressorInfo, ref uint pdwNum);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerSetVideoCompressorInfo(IntPtr hCaptureObject, IntPtr pVideoCompressorInfo);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerGetVideoCompressorInfo(IntPtr hCaptureObject, ref VIDEO_COMPRESSOR_INFO pVideoCompressorInfo);

        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerEnumAudioCompressor(IntPtr hCaptureObject, IntPtr pAudioCompressorInfo, ref uint pdwNum);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerSetAudioCompressorInfo(IntPtr hCaptureObject, IntPtr pAudioCompressorInfo);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerGetAudioCompressorInfo(IntPtr hCaptureObject, ref AUDIO_COMPRESSOR_INFO pAudioCompressorInfo);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerEnumSupportedAudioSampleFormat(IntPtr hCaptureObject, ref AUDIO_COMPRESSOR_INFO pAudioCompressorInfo, IntPtr pAudioSampleInfo, ref uint pdwNum);

        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerSetVideoStreamMixingProperty(IntPtr hCaptureObject, uint dwStreamID, VIDEO_STREAM_INFO VideoStreamInfo);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerGetVideoStreamMixingProperty(IntPtr hCaptureObject, uint dwStreamID, ref VIDEO_STREAM_INFO pVideoStreamInfo);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerMixVideoStream(IntPtr hCaptureObject, uint dwStreamID, byte[] pData, uint dwStride, int lLength, Int64 tRefTime, uint dwOptions);

        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerSetWMVVideoEncoderInfo(IntPtr hCaptureObject, WMV_VIDEOENCODER_INFO VideoEncoderInfo);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerGetWMVVideoEncoderInfo(IntPtr hCaptureObject, ref WMV_VIDEOENCODER_INFO pVideoEncoderInfo);

        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerSetWMVAudioEncoderInfo(IntPtr hCaptureObject, WMV_AUDIOENCODER_INFO AudioEncoderInfo);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerGetWMVAudioEncoderInfo(IntPtr hCaptureObject, ref WMV_AUDIOENCODER_INFO pAudioEncoderInfo);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoEnhanceMode(IntPtr hCaptureObject, uint dwMode);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoEnhanceMode(IntPtr hCaptureObject, ref uint pdwMode);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoClippingRect(IntPtr hCaptureObject, RECT rcClippingRect);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoClippingRect(IntPtr hCaptureObject, ref RECT prcClippingRect);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoMirrorMode(IntPtr hCaptureObject, uint dwMode);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoMirrorMode(IntPtr hCaptureObject, ref uint pdwMode);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetS5WakeUpTime(IntPtr hCaptureObject, WAKEUP_TIME WakeUpTime);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetS5WakeUpTime(IntPtr hCaptureObject, ref WAKEUP_TIME pWakeUpTime);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetMpeg2VideoEncoderInfo(IntPtr hCaptureObject, ref MPEG2_VIDEOENCODER_INFO pVideoEncoderInfo);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetMpeg2VideoEncoderInfo(IntPtr hCaptureObject, ref MPEG2_VIDEOENCODER_INFO pVideoEncoderInfo);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetMpeg2AudioEncoderInfo(IntPtr hCaptureObject, ref MPEG2_AUDIOENCODER_INFO pAudioEncoderInfo);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetMpeg2AudioEncoderInfo(IntPtr hCaptureObject, ref MPEG2_AUDIOENCODER_INFO pAudioEncoderInfo);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetMpeg4VideoEncoderInfo(IntPtr hCaptureObject, ref MPEG4_VIDEOENCODER_INFO pVideoEncoderInfo);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetMpeg4VideoEncoderInfo(IntPtr hCaptureObject, ref MPEG4_VIDEOENCODER_INFO pVideoEncoderInfo);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetMpeg4AudioEncoderInfo(IntPtr hCaptureObject, ref MPEG4_AUDIOENCODER_INFO pAudioEncoderInfo);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetMpeg4AudioEncoderInfo(IntPtr hCaptureObject, ref MPEG4_AUDIOENCODER_INFO pAudioEncoderInfo);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoRotateMode(IntPtr hCaptureObject, uint dwMode);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoRotateMode(IntPtr hCaptureObject, ref uint pdwMode);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetVideoUpscaleBlackRect(IntPtr hCaptureObject, RECT rcUpscaleRect);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetVideoUpscaleBlackRect(IntPtr hCaptureObject, ref RECT prcUpscaleRect);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerHwSetVideoEncoderInfo(IntPtr hCaptureObject, ref HW_VIDEOENCODER_INFO pVideoEncoderInfo);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerHwGetVideoEncoderInfo(IntPtr hCaptureObject, ref HW_VIDEOENCODER_INFO pVideoEncoderInfo);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerHwSetAudioEncoderInfo(IntPtr hCaptureObject, ref HW_AUDIOENCODER_INFO pAudioEncoderInfo);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerHwGetAudioEncoderInfo(IntPtr hCaptureObject, ref HW_AUDIOENCODER_INFO pAudioEncoderInfo);

        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerHwCaptureStreamStart(IntPtr hCaptureObject, ref HW_STREAM_CAPTURE_INFO pCaptureInfo);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerHwCaptureStreamStop(IntPtr hCaptureObject);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerHwSetVolume(IntPtr hCaptureObject, uint dwVolume);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerHwGetVolume(IntPtr hCaptureObject, ref uint pdwVolume);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerHwGetVolumeRange(IntPtr hCaptureObject, ref uint pdwMinVolume, ref uint pdwMaxVolume, ref uint pdwDefVolume);

        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerEnumThirdPartyAudioCapSource(IntPtr hCaptureObject, IntPtr pAudioCapSourceInfo, ref uint pdwNum);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerEnumThirdPartyAudioCapSourceInputType(IntPtr hCaptureObject, uint dwCapIndex, IntPtr pInputTypeInfo, ref uint pdwNum);
        [DllImport("AVerCapAPI.dll", CharSet = CharSet.Unicode)]
        public static extern int AVerEnumThirdPartyAudioCapSourceSampleFormat(IntPtr hCaptureObject, uint dwCapIndex, IntPtr pFormatInfo, ref uint pdwNum);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerSetThirdPartyAudioCapSource(IntPtr hCaptureObject, ref AUDIOCAPTURESOURCE_SETTING pAudioCapSourceSetting);
        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetThirdPartyAudioCapSource(IntPtr hCaptureObject, ref AUDIOCAPTURESOURCE_SETTING pAudioCapSourceSetting);

        [DllImport("AVerCapAPI.dll")]
        public static extern int AVerGetHardwareVideoAccelerationCapabilities(IntPtr hCaptureObject, ref uint pdwCapabilities);
    }
}
