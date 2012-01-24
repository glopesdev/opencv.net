﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using OpenCV.Net.Native;

namespace OpenCV.Net
{
    public static class Core
    {
        const string libName = "opencv_core231";

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRandArr(ref CvRNG rng, CvArr arr, CvRandDistribution dist_type, CvScalar param1, CvScalar param2);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetIdentity(CvArr mat, CvScalar value);

        public static void cvCalcCovarMatrix(CvArr[] vects, CvArr covMat, CvArr avg, CovarianceFlags flags)
        {
            var pImages = new IntPtr[vects.Length];
            for (int i = 0; i < vects.Length; i++)
            {
                pImages[i] = vects[i].DangerousGetHandle();
            }

            core.cvCalcCovarMatrix(pImages, pImages.Length, covMat, avg, flags);
        }

        public static void cvMatMulAdd(CvArr src1, CvArr src2, CvArr src3, CvArr dst)
        {
            cvGEMM(src1, src2, 1, src3, 1, dst, 0);
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGEMM(CvArr src1, CvArr src2, double alpha, CvArr src3, double beta, CvArr dst, int tABC);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCalcPCA(CvArr data, CvArr mean, CvArr eigenvals, CvArr eigenvects, PcaFlags flags);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double cvMahalanobis(CvArr vec1, CvArr vec2, CvArr mat);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvConvertScale(CvArr src, CvArr dst, double scale, double shift);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvGetRawData(CvArr arr, out IntPtr data, out int step, out CvSize roiSize);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAbsDiff(CvArr src1, CvArr src2, CvArr dst);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAdd(CvArr src1, CvArr src2, CvArr dst, CvArr mask);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAddS(CvArr src, CvScalar value, CvArr dst, CvArr mask);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAnd(CvArr src1, CvArr src2, CvArr dst, CvArr mask);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvNot(CvArr src, CvArr dst);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvInRangeS(CvArr src, CvScalar lower, CvScalar upper, CvArr dst);

        public static CvScalar cvAvg(CvArr arr)
        {
            return cvAvg(arr, CvArr.Null);
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar cvAvg(CvArr arr, CvArr mask);

        public static void cvAvgSdv(CvArr arr, out CvScalar mean, out CvScalar std_dev)
        {
            cvAvgSdv(arr, out mean, out std_dev, CvArr.Null);
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvAvgSdv(CvArr arr, out CvScalar mean, out CvScalar std_dev, CvArr mask);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMinMaxLoc(
            CvArr arr,
            out double min_val,
            out double max_val,
            out CvPoint min_loc, // = NULL
            out CvPoint max_loc, // = NULL
            CvArr mask); // = NULL

        public static void cvCopy(CvArr src, CvArr dst)
        {
            cvCopy(src, dst, CvArr.Null);
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCopy(CvArr src, CvArr dst, CvArr mask);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFlip(CvArr src, CvArr dst, FlipMode flipMode);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMerge(CvArr src0, CvArr src1, CvArr src2, CvArr src3, CvArr dst);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvMul(CvArr src1, CvArr src2, CvArr dst, double scale);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvPow(CvArr src, CvArr dst, double power);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSplit(CvArr src, CvArr dst0, CvArr dst1, CvArr dst2, CvArr dst3);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSub(CvArr src1, CvArr src2, CvArr dst, CvArr mask);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern CvScalar cvSum(CvArr arr);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvCountNonZero(CvArr arr);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCmpS(CvArr src, double value, CvArr dst, int cmp_op);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvCircle(
            CvArr img,
            CvPoint center,
            int radius,
            CvScalar color,
            int thickness, //=1
            int lineType, //=8
            int shift); //=0

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvClipLine(CvSize imgSize, ref CvPoint pt1, ref CvPoint pt2);

        public static void cvPolyLine(CvArr img, CvPoint[][] pts, int[] npts, int contours, int is_closed, CvScalar color, int thickness, int lineType, int shift)
        {
            var handles = Array.ConvertAll(pts, poly => GCHandle.Alloc(poly, GCHandleType.Pinned));
            try
            {
                var pPts = Array.ConvertAll(handles, handle => handle.AddrOfPinnedObject());
                core.cvPolyLine(img, pPts, npts, contours, is_closed, color, thickness, lineType, shift);
            }
            finally { Array.ForEach(handles, handle => handle.Free()); }
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void cvPutText(CvArr img, string text, CvPoint org, CvFont font, CvScalar color);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void cvGetTextSize(string text_string, CvFont font, out CvSize text_size, out int baseline);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvDrawContours(
            CvArr img,
            CvSeq contour,
            CvScalar external_color,
            CvScalar hole_color,
            int max_level,
            int thickness,// = 1
            int lineType,// = 8
            CvPoint offset);//= CvPoint(0,0)

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvFillConvexPoly(CvArr img, CvPoint[] pts, int npts, CvScalar color, int line_type, int shift);

        public static void cvFillPoly(CvArr img, CvPoint[][] pts, int[] npts, int contours, CvScalar color, int lineType, int shift)
        {
            var handles = Array.ConvertAll(pts, poly => GCHandle.Alloc(poly, GCHandleType.Pinned));
            try
            {
                var pPts = Array.ConvertAll(handles, handle => handle.AddrOfPinnedObject());
                core.cvFillPoly(img, pPts, npts, contours, color, lineType, shift);
            }
            finally { Array.ForEach(handles, handle => handle.Free()); }
        }

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvEllipse(
            CvArr img,
            CvPoint center,
            CvSize axes,
            double angle,
            double start_angle,
            double end_angle,
            CvScalar color,
            int thickness, // = 1
            int lineType, // = 8
            int shift); // = 0

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvLine(
            CvArr img,
            CvPoint pt1,
            CvPoint pt2,
            CvScalar color,
            int thickness,// = 1
            int lineType,// = 8
            int shift);// = 0

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvRectangle(
            CvArr img,
            CvPoint pt1,
            CvPoint pt2,
            CvScalar color,
            int thickness,// = 1
            int lineType,// = 8
            int shift);// = 0

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void cvSave(string filename, SafeHandle struct_ptr, string name, string comment, CvAttrList attributes);

        public static T cvLoad<T>(string filename, CvMemStorage storage, string name) where T : SafeHandle
        {
            string realName;
            return cvLoad<T>(filename, storage, name, out realName);
        }

        public static T cvLoad<T>(string filename, CvMemStorage storage, string name, out string realName) where T : SafeHandle
        {
            var handle = core.cvLoad(filename, storage, name, out realName);
            var result = (T)Activator.CreateInstance(
                typeof(T),
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic,
                null,
                new object[] { handle },
                null);
            return result;
        }
        
        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int cvGetErrStatus();

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetErrStatus(int status);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ErrorMode cvGetErrMode();

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ErrorMode cvSetErrMode(ErrorMode mode);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string cvErrorStr(int status);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        [return:MarshalAs(UnmanagedType.FunctionPtr)]
        public static extern CvErrorCallback cvRedirectError([MarshalAs(UnmanagedType.FunctionPtr)]CvErrorCallback error_handler, IntPtr userdata, out IntPtr prevUserdata);

        [DllImport(libName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void cvSetMemoryManager(
            [MarshalAs(UnmanagedType.FunctionPtr)]CvAllocFunc allocFunc,
            [MarshalAs(UnmanagedType.FunctionPtr)]CvFreeFunc freeFunc,
            IntPtr userdata);
    }
}
