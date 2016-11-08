using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace CarTest
{
    [Serializable]
    public class IMUData
    {

        public static string DeviceCode = "RT2500 Initial++";

        public RoadPoint rpnow = new RoadPoint();

        public int AzimuthRadian = 0;
        public int rtkStatus = 0;
        public int navStatus = 0;
        public int CollectionSatellitesNumber = 0;//卫星数

        //速度定义
        public int AngularRateZRadian, NorthSpeedOld, UpSpeedOld, EastSpeedOld;
        public double NorthSpeed, UpSpeed, EastSpeed, Speed, SpeedKM, ax, ay, az;

        private const int rtkStatusCheck = 68;//RTK状态处在的字节位置
        private const int SatellitesNumberCheck = 67;//卫星数处在的字节位置
        private const int navStatusCheck = 21;

        public const double Pi = 3.1415926535898;

        public IMUData()
        {
        }

        public void Init()
        {
            #region UDP
            IPEndPoint e = new IPEndPoint(IPAddress.Any, 3000);
            UdpClient udp = new UdpClient(e);
            UdpState s = new UdpState();
            s.e = e;
            s.u = udp;
            udp.BeginReceive(new AsyncCallback(UDPReceive), s);

            #endregion

        }

        #region Receive

        public void UDPReceive(IAsyncResult ar)
        {
            try
            {
                UdpClient u = (UdpClient)((UdpState)(ar.AsyncState)).u;
                IPEndPoint e = (IPEndPoint)((UdpState)(ar.AsyncState)).e;
                Byte[] receiveBytes = u.EndReceive(ar, ref e);
                UdpState s = new UdpState();
                s.e = e;
                s.u = u;
                if (receiveBytes.Length == 72)
                {
                    Decompose(receiveBytes);
                }
                u.BeginReceive(new AsyncCallback(UDPReceive), s);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Decompose

        public void Decompose(Byte[] receiveBytes)
        {
            RoadPoint rp = new RoadPoint();

            navStatus = (int)receiveBytes[navStatusCheck];
            rtkStatus = (int)receiveBytes[rtkStatusCheck];//保存RTK的状态
            CollectionSatellitesNumber = (int)receiveBytes[SatellitesNumberCheck];

            rp.Lat = 180 / Pi * (BitConverter.ToDouble(receiveBytes, 23));//计算纬度
            rp.Lon = 180 / Pi * (BitConverter.ToDouble(receiveBytes, 31));//计算经度

            if ((rp.Lat > 10.0) && (rp.Lat < 60) && (navStatus == 4))
            {
                #region 航向角解析
                AzimuthRadian = receiveBytes[52] + (receiveBytes[53] << 8) + (receiveBytes[54] << 16);
                if (AzimuthRadian >= (1 << 23))
                {
                    AzimuthRadian -= (1 << 24);
                    rp.Azimuth = (AzimuthRadian * 1.0 / 1000000) / Pi * 180 + 360;
                }
                else
                {
                    rp.Azimuth = (AzimuthRadian * 1.0 / 1000000) / Pi * 180;
                }


                AngularRateZRadian = receiveBytes[18] + (receiveBytes[19] << 8) + (receiveBytes[20] << 16);
                if (AngularRateZRadian >= (1 << 23))
                {
                    AngularRateZRadian -= (1 << 24);
                    rp.AngularRateZ = (AngularRateZRadian * 1.0 / 100000) / Pi * 180;
                }
                else
                {
                    rp.AngularRateZ = (AngularRateZRadian * 1.0 / 100000) / Pi * 180;
                }
                #endregion

                #region 速度解析
                NorthSpeedOld = receiveBytes[43] + (receiveBytes[44] << 8) + (receiveBytes[45] << 16);
                if (NorthSpeedOld >= (1 << 23))
                {
                    NorthSpeedOld -= (1 << 24);
                    NorthSpeed = NorthSpeedOld * 1.0 / 10000;
                }
                else
                {
                    NorthSpeed = NorthSpeedOld * 1.0 / 10000;
                }

                EastSpeedOld = receiveBytes[46] + (receiveBytes[47] << 8) + (receiveBytes[48] << 16);
                if (EastSpeedOld >= (1 << 23))
                {
                    EastSpeedOld -= (1 << 24);
                    EastSpeed = EastSpeedOld * 1.0 / 10000;
                }
                else
                {
                    EastSpeed = EastSpeedOld * 1.0 / 10000;
                }

                UpSpeedOld = receiveBytes[49] + (receiveBytes[50] << 8) + (receiveBytes[51] << 16);
                if (UpSpeedOld >= (1 << 23))
                {
                    UpSpeedOld -= (1 << 24);
                    UpSpeed = UpSpeedOld * 1.0 / 10000;
                }
                else
                {
                    UpSpeed = UpSpeedOld * 1.0 / 10000;
                }

                Speed = Math.Sqrt(NorthSpeed * NorthSpeed + EastSpeed * EastSpeed);// + UpSpeed * UpSpeed);// + UpSpeed * UpSpeed);
                rp.SpeedKM = Speed * 3.6;
                rp.SpeedNorth = NorthSpeed;
                rp.SpeedEast = EastSpeed;
                #endregion

                #region 加速度解析
                //ax
                ax = receiveBytes[3] + (receiveBytes[4] << 8) + (receiveBytes[5] << 16);
                if (ax >= (1 << 23))
                {
                    ax -= (1 << 24);
                    ax = ax * 1.0 / 10000;
                }
                else
                {
                    ax = ax * 1.0 / 10000;
                }

                ay = receiveBytes[6] + (receiveBytes[7] << 8) + (receiveBytes[8] << 16);
                if (ay >= (1 << 23))
                {
                    ay -= (1 << 24);
                    ay = ay * 1.0 / 10000;
                }
                else
                {
                    ay = ay * 1.0 / 10000;
                }

                az = receiveBytes[9] + (receiveBytes[10] << 8) + (receiveBytes[11] << 16);
                if (az >= (1 << 23))
                {
                    az -= (1 << 24);
                    az = az * 1.0 / 10000;
                }
                else
                {
                    az = az * 1.0 / 10000;
                }
                #endregion

                rp.valid = true;
            }
            else
                rp.valid = false;

            lock (rpnow)
                rpnow = rp;
        }

        #endregion
    }

    [Serializable]
    public class RoadPoint
    {
        public bool valid;
        public double x, y;
        public double Lat;// 纬度
        public double Lon;// 经度
        public double Azimuth;//航向角
        public byte Mode1;//属性1
        public byte Mode2;//属性2
        public int rtkStatus;//
        public int nvaStatus;//惯导状态
        public double AngularRateZ; //Z轴角速度
        public double SpeedKM;

        public double SpeedEast, SpeedNorth;

        //构造函数
        public RoadPoint()
        {
            valid = false;
            Lat = 0;
            Lon = 0;
            Mode1 = 0;//
            Mode2 = 0;
            rtkStatus = 0;
            AngularRateZ = 0;
            SpeedKM = 0;
            SpeedEast = SpeedNorth = 0;
        }

        public RoadPoint(double _x, double _y)
        {
            x = _x; y = _y;
        }

        public RoadPoint(double _x, double _y, byte m1, byte m2)
        {
            x = _x; y = _y;
            Mode1 = m1; Mode2 = m2;
        }

    }

    #region UDP
    public class UdpState
    {
        public UdpClient u;
        public IPEndPoint e;
    }
    #endregion
}
