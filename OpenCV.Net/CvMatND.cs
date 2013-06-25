﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    /// <summary>
    /// Represents a multi-dimensional dense multi-channel array.
    /// </summary>
    public class CvMatND : CvArr
    {
        bool ownsData;
        readonly long bytesAllocated;

        internal CvMatND(IntPtr handle, bool ownsHandle)
            : base(ownsHandle)
        {
            SetHandle(handle);

            if (ownsHandle)
            {
                var dimSizes = new int[MatHelper.MaxDim];
                var dims = GetDims(dimSizes);
                bytesAllocated = ElementSize;
                for (int i = 0; i < dims; i++)
                {
                    bytesAllocated *= dimSizes[i];
                }
                GC.AddMemoryPressure(bytesAllocated);
                ownsData = true;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMatND"/> class with the
        /// specified dimension sizes, element bit <paramref name="depth"/> and
        /// <paramref name="channels"/> per element.
        /// </summary>
        /// <param name="dimSizes">The size of each of the multi-dimensional array dimensions.</param>
        /// <param name="depth">The bit depth of matrix elements.</param>
        /// <param name="channels">The number of channels per element.</param>
        public CvMatND(int[] dimSizes, CvMatDepth depth, int channels)
            : this(NativeMethods.cvCreateMatND(dimSizes.Length, dimSizes, MatHelper.GetMatType(depth, channels)), true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CvMatND"/> class with the
        /// specified dimension sizes, element bit <paramref name="depth"/> and
        /// <paramref name="channels"/> per element. A pointer to the matrix
        /// raw element <paramref name="data"/> is provided.
        /// </summary>
        /// <param name="dimSizes">The size of each of the multi-dimensional array dimensions.</param>
        /// <param name="depth">The bit depth of matrix elements.</param>
        /// <param name="channels">The number of channels per element.</param>
        /// <param name="data">A pointer to the matrix raw element data.</param>
        public CvMatND(int[] dimSizes, CvMatDepth depth, int channels, IntPtr data)
            : base(true)
        {
            var type = MatHelper.GetMatType(depth, channels);
            var pMat = NativeMethods.cvCreateMatNDHeader(dimSizes.Length, dimSizes, type);
            NativeMethods.cvInitMatNDHeader(pMat, dimSizes.Length, dimSizes, type, data);
            SetHandle(pMat);
        }

        /// <summary>
        /// Gets the bit depth of matrix elements.
        /// </summary>
        public CvMatDepth Depth
        {
            get
            {
                unsafe
                {
                    return MatHelper.GetMatDepth(((_CvMatND*)handle.ToPointer())->type);
                }
            }
        }

        /// <summary>
        /// Gets the number of channels per matrix element.
        /// </summary>
        public int Channels
        {
            get
            {
                unsafe
                {
                    return MatHelper.GetMatChannels(((_CvMatND*)handle.ToPointer())->type);
                }
            }
        }

        /// <summary>
        /// Gets the size of each matrix element channel in bytes.
        /// </summary>
        public int ElementSize
        {
            get
            {
                unsafe
                {
                    return MatHelper.GetElemSize(((_CvMatND*)handle.ToPointer())->type);
                }
            }
        }

        /// <summary>
        /// Creates a new <see cref="CvMatND"/> that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="CvMatND"/> that is a copy of this instance.
        /// </returns>
        public CvMatND Clone()
        {
            return new CvMatND(NativeMethods.cvCloneMatND(this), true);
        }

        /// <summary>
        /// Executes the code required to free the native <see cref="CvMatND"/> handle.
        /// </summary>
        /// <returns>
        /// <b>true</b> if the handle is released successfully; otherwise, in the event of a
        /// catastrophic failure, <b>false</b>.
        /// </returns>
        protected override bool ReleaseHandle()
        {
            var pMat = handle;
            if (ownsData)
            {
                GC.RemoveMemoryPressure(bytesAllocated);
            }

            NativeMethods.cvReleaseMat(ref pMat);
            return true;
        }
    }
}
