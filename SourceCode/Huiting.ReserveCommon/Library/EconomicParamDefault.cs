using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Huiting.Common;

namespace ReserveCommon
{
    [Serializable]
    public class DefaultConfig
    {
        string xmlFile = "DefaultConfig.xml";
        private static DefaultConfig instance = new DefaultConfig();

        public static DefaultConfig Instance
        {
            get { return DefaultConfig.instance; }
        }

        internal DefaultConfig()
        {
            xmlFile = PublicMethods.GetAbsolutePath(xmlFile);
            ReadXmlFile();
        }

        public bool ReadXmlFile()
        {
            return ObjectSerializer.Instance.ReadObjectFromXmlFile<SerializableAttribute>(this, xmlFile);
        }

        public void WriteXmlFile()
        {
            ObjectSerializer.Instance.WriteObjectToXmlFile<SerializableAttribute>(this, xmlFile);
        }

        EconomicParamsDefault economicParams = new EconomicParamsDefault();

        public EconomicParamsDefault EconomicParams
        {
            get { return economicParams; }
            set { economicParams = value; }
        }

        EvaluationOptionsDefault evaluationOptions = new EvaluationOptionsDefault();

        public EvaluationOptionsDefault EvaluationOptions
        {
            get { return evaluationOptions; }
            set { evaluationOptions = value; }
        }

        QybDefault qybDefault = new QybDefault();

        public QybDefault QybDefault
        {
            get { return qybDefault; }
            set { qybDefault = value; }
        }

    }

    [Serializable]
    public class EvaluationOptionsDefault 
    {
        double nzxl = 0.1;

        public double Nzxl
        {
            get { return nzxl; }
            set { nzxl = value; }
        }


        double yfqcl = 10;

        public double YFqcl
        {
            get { return yfqcl; }
            set { yfqcl = value; }
        }


        double qfqcl = 100;

        public double QFqcl
        {
            get { return qfqcl; }
            set { qfqcl = value; }
        }

        int limitedTime = 100;

        public int LimitedTime
        {
            get { return limitedTime; }
            set { limitedTime = value; }
        }
    }

    [Serializable]
    public class EconomicParamsDefault
    {
        double yzzsl = 14.53;

        public double Yzzsl
        {
            get { return yzzsl; }
            set { yzzsl = value; }
        }

        double qzzsl = 11.5;

        public double Qzzsl
        {
            get { return qzzsl; }
            set { qzzsl = value; }
        }

        double zysl = 3.9;

        public double Zysl
        {
            get { return zysl; }
            set { zysl = value; }
        }

        double qt = 0;

        public double Qt
        {
            get { return qt; }
            set { qt = value; }
        }

        double hl = 0;

        public double Hl
        {
            get { return hl; }
            set { hl = value; }
        }

        double tbsyjsl=0;

        public double Tbsyjsl
        {
            get { return tbsyjsl; }
            set { tbsyjsl = value; }
        }

        double qj = 7.6;

        public double Qj
        {
            get { return qj; }
            set { qj = value; }
        }

        double yj = 40;

        public double Yj
        {
            get { return yj; }
            set { yj = value; }
        }
    }

    [Serializable]
    public class QybDefault
    {
        bool usedQYb = false;

        public bool UsedQYb
        {
            get { return usedQYb; }
            set { usedQYb = value; }
        }

        double monthsCount = 6;

        public double MonthsCount
        {
            get { return monthsCount; }
            set { monthsCount = value; }
        }
    }
}