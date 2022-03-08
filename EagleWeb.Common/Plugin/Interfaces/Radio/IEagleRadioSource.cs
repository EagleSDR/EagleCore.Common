using EagleWeb.Common.Radio;
using System;
using System.Collections.Generic;
using System.Text;

namespace EagleWeb.Common.Plugin.Interfaces.Radio
{
    public delegate void IEagleRadioSource_SampleRateChangedEventArgs(IEagleRadioSource source, float newSampleRate);
    public delegate void IEagleRadioSource_SamplesDroppedEventArgs(IEagleRadioSource source, long dropped);

    public interface IEagleRadioSource : IEagleObject, IEagleRadioModule
    {
        /// <summary>
        /// Opens the source, returning the output sample rate.
        /// </summary>
        /// <returns></returns>
        float Open(int bufferSize);

        /// <summary>
        /// Gets the current center frequency.
        /// </summary>
        long CenterFrequency { get; set; }

        /// <summary>
        /// Event raised when the device sample rate changes while it's streaming.
        /// </summary>
        event IEagleRadioSource_SampleRateChangedEventArgs OnSampleRateChanged;

        /// <summary>
        /// Event raised when samples are dropped because the radio can't keep up.
        /// </summary>
        event IEagleRadioSource_SamplesDroppedEventArgs OnSamplesDropped;

        /// <summary>
        /// Reads a block of samples from the source and returns the amount read.
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="count"></param>
        unsafe int Read(EagleComplex* ptr, int count);

        /// <summary>
        /// Closes this source.
        /// </summary>
        void Close();
    }
}
