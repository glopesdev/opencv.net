﻿using OpenCV.Net.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCV.Net
{
    public static partial class cv
    {
        #region Basic GUI functions

        /// <summary>
        /// Draws text on the specified image <paramref name="img"/> using the specific <paramref name="font"/>.
        /// </summary>
        /// <param name="img">Image where the text should be drawn.</param>
        /// <param name="text">Text to write on the image.</param>
        /// <param name="location">The point where the text should start on the image.</param>
        /// <param name="font">Font used to draw the text.</param>
        public static void AddText(CvArr img, string text, CvPoint location, CvFont font)
        {
            NativeMethods.cvAddText(img, text, location, font);
        }

        /// <summary>
        /// Creates and attaches a button to the shared control panel.
        /// </summary>
        /// <param name="buttonName">The name of the button.</param>
        /// <param name="onChange">
        /// The callback method that will be called every time the button changes state.
        /// </param>
        /// <param name="buttonType">The type of button to create.</param>
        /// <param name="initialButtonState">The initial state of the button.</param>
        /// <returns>
        /// <b>true</b> if the button was created successfully; otherwise, <b>false</b>.
        /// </returns>
        public static bool CreateButton(
            string buttonName = null,
            CvButtonCallback onChange = null,
            ButtonType buttonType = ButtonType.PushButton,
            bool initialButtonState = false)
        {
            _CvButtonCallback callback = onChange != null ? (state, userdata) => onChange(state > 0 ? true : false) : (_CvButtonCallback)null;
            return NativeMethods.cvCreateButton(buttonName, callback, IntPtr.Zero, buttonType, initialButtonState ? 1 : 0) > 0;
        }

        /// <summary>
        /// Loads an image from a file as an <see cref="IplImage"/>.
        /// </summary>
        /// <param name="fileName">Name of file to be loaded.</param>
        /// <param name="colorType">Specific color type of the loaded image.</param>
        /// <returns>The newly loaded image.</returns>
        public static IplImage LoadImage(string fileName, LoadImageFlags colorType)
        {
            return NativeMethods.cvLoadImage(fileName, colorType);
        }

        /// <summary>
        /// Loads an image from a file as a <see cref="CvMat"/>.
        /// </summary>
        /// <param name="fileName">Name of file to be loaded.</param>
        /// <param name="colorType">Specific color type of the loaded image.</param>
        /// <returns>The newly loaded image.</returns>
        public static CvMat LoadImageM(string fileName, LoadImageFlags colorType)
        {
            return NativeMethods.cvLoadImageM(fileName, colorType);
        }

        /// <summary>
        /// Saves an image to a specified file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="image">Image to be saved.</param>
        /// <param name="parameters">Optional image compression parameters.</param>
        /// <returns>
        /// <b>true</b> if the image was saved successfully; otherwise, <b>false</b>.
        /// </returns>
        public static bool SaveImage(string fileName, CvArr image, params int[] parameters)
        {
            return NativeMethods.cvSaveImage(fileName, image, parameters) > 0;
        }

        /// <summary>
        /// Reads an image from a buffer in memory as an <see cref="IplImage"/>.
        /// </summary>
        /// <param name="buf">Input array of bytes.</param>
        /// <param name="colorType">Specific color type of the loaded image.</param>
        /// <returns>The newly loaded image.</returns>
        public static IplImage DecodeImage(CvMat buf, LoadImageFlags colorType)
        {
            return NativeMethods.cvDecodeImage(buf, colorType);
        }

        /// <summary>
        /// Reads an image from a buffer in memory as a <see cref="CvMat"/>.
        /// </summary>
        /// <param name="buf">Input array of bytes.</param>
        /// <param name="colorType">Specific color type of the loaded image.</param>
        /// <returns>The newly loaded image.</returns>
        public static CvMat DecodeImageM(CvMat buf, LoadImageFlags colorType)
        {
            return NativeMethods.cvDecodeImageM(buf, colorType);
        }

        /// <summary>
        /// Encodes an image into a memory buffer.
        /// </summary>
        /// <param name="ext">File extension that defines the output format.</param>
        /// <param name="image">Image to be written.</param>
        /// <param name="parameters">Optional image compression parameters.</param>
        /// <returns>
        /// A newly created <see cref="CvMat"/> containing the encoded image bytes.
        /// </returns>
        public static CvMat EncodeImage(string ext, CvArr image, params int[] parameters)
        {
            return NativeMethods.cvEncodeImage(ext, image, parameters);
        }

        /// <summary>
        /// Converts one image to another with an optional vertical flip.
        /// </summary>
        /// <param name="src">Source image.</param>
        /// <param name="dst">Destination image.</param>
        /// <param name="flags">The operation flags.</param>
        public static void ConvertImage(CvArr src, CvArr dst, ConvertImageFlags flags = ConvertImageFlags.None)
        {
            NativeMethods.cvConvertImage(src, dst, flags);
        }

        /// <summary>
        /// Waits for a pressed key.
        /// </summary>
        /// <param name="delay">
        /// Maximum delay in milliseconds for which to wait for a key press.
        /// </param>
        /// <returns>
        /// The pressed key code or -1 if no key was pressed before the specified
        /// time had elapsed.
        /// </returns>
        public static int WaitKey(int delay = 0)
        {
            return NativeMethods.cvWaitKey(delay);
        }

        #endregion
    }
}