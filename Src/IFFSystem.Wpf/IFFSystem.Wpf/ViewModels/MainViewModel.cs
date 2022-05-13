﻿using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFFSystem.Wpf.ViewModels
{
    public class MainViewModel : Prism.Mvvm.BindableBase
    {
        public MainViewModel()
        {
            AdsDataCollection = new ObservableCollection<AdsbData>();
            for (int i = 0; i < 100; i++)
            {
                AdsDataCollection.Add(new AdsbData());
            }

        }
        public ObservableCollection<AdsbData> AdsDataCollection { get; set; }

        private DateTime data = DateTime.Now;
        public DateTime Date
        {
            get { return data; }
            set{  SetProperty(ref data, value);}
        }

        private DateTime time = DateTime.Now;
        public DateTime Time {
            get { return time; }
            set { SetProperty(ref time, value); }
        }
    }

    public class AdsbData : Prism.Mvvm.BindableBase
    {
        private string timeMark = "2022-05-10 17:35:48";
        public string TimeMark
        {
            get { return timeMark; }
            set { SetProperty(ref timeMark, value); }
        }

        private double freq = 1090;
        public double Frequency
        {
            get { return freq; }
            set { SetProperty(ref freq, value); }
        }

        private string icao = "780AEE";
        public string ICAO
        {
            get { return icao; }
            set { SetProperty(ref icao, value); }
        }

        private string taiNum = "B-5689";
        public string TailNumber
        {
            get { return taiNum; }
            set { SetProperty(ref taiNum, value); }
        }

        private string country = "中国";
        public string Country
        {
            get { return country; }
            set { SetProperty(ref country, value); }
        }

        private string flightNumber = "CSC4512";
        public string FlightNumber
        {
            get { return flightNumber; }
            set { SetProperty(ref flightNumber, value); }
        }

        private string airproperty = "重型>=3000磅";
        public string PlaneProperty
        {
            get { return airproperty; }
            set { SetProperty(ref airproperty, value); }
        }

        private double lnt = 103.689;
        public double Lnt
        {
            get { return lnt; }
            set { SetProperty(ref lnt, value); }
        }

        private double lat = 30.348;
        public double Lat
        {
            get { return lat; }
            set { SetProperty(ref lat, value); }
        }

        private double height = 8000;
        public double Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }

        private double airSpend = 400;
        public double AirSpend
        {
            get { return airSpend; }
            set { SetProperty(ref airSpend, value); }
        }

        private double airDiection = 65;
        public double AirDirection
        {
            get { return airDiection; }
            set { SetProperty(ref airDiection, value); }
        }

        private string modeData = "78-0A-EE-34-5D-23-2E-7A-12-78-56-78-14-7E-5D";
        public string ModeData
        {
            get { return modeData; }
            set { SetProperty(ref modeData, value); }
        }
    }
}
