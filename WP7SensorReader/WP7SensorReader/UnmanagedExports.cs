using System;
using RGiesecke.DllExport;
using Microsoft.WindowsAPICodePack.Sensors;
using System.Runtime.InteropServices;

namespace WP7SensorReader
{
   internal static class UnmanagedExports
   {
       private static float x, y, z;


       [DllExport("Initialize", CallingConvention = CallingConvention.StdCall)]
       static void Initialize()
       {
           SensorManager.SensorsChanged += SensorManagerSensorsChanged;
           UpdateSensorsList();
       }

       static void SensorManagerSensorsChanged(SensorsChangedEventArgs change)
       {
           System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((System.Threading.ThreadStart)(UpdateSensorsList));
       }

       static void UpdateSensorsList()
       {
           foreach (var sensor in SensorManager.GetSensorsByTypeId<Accelerometer3D>())
           {
               sensor.DataReportChanged +=
                   delegate(Sensor sender, EventArgs e)
                   {
                       System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke((System.Threading.ThreadStart)(
                           delegate
                           {
                               x = ((Accelerometer3D)sender).CurrentAcceleration[AccelerationAxis.X];
                               y = ((Accelerometer3D)sender).CurrentAcceleration[AccelerationAxis.Y];
                               z = ((Accelerometer3D)sender).CurrentAcceleration[AccelerationAxis.Z];
                           }));
                   };
           }
       }


       [DllExport("GetX", CallingConvention = CallingConvention.StdCall)]
       [return: MarshalAs(UnmanagedType.R4)]
       static float GetX()
       {
           return x;
       }

       [DllExport("GetY", CallingConvention = CallingConvention.StdCall)]
       [return: MarshalAs(UnmanagedType.R4)]
       static float GetY()
       {
           return y;
       }

       [DllExport("GetZ", CallingConvention = CallingConvention.StdCall)]
       [return: MarshalAs(UnmanagedType.R4)]
       static float GetZ()
       {
           return z;
       }
   }
}
