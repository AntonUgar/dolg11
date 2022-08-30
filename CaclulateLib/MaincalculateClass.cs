using System;
using System.Collections.Generic;
using System.Text;

namespace CaclulateLib
{
    public class MaincalculateClass
    {
        public double VelValue;
        public int E;

       
        public double[] X = new double[5] { 1000, 3000, 5000, 10000, 15000 };
        public double[] u = new double[4] { 1, 2, 4, 6 };
        public double[] Y = new double[5] { 100, 200, 300, 400, 500 };

        private double nValue;
        private double dValue;
        private double XmValue;
        private double umValue;
        private double fValue;
        public double CalcAverVel(double V, double D) 
        {
            return Math.Round(4 * (V / 3600) / (3.14 * Math.Pow(D, 2)), 4);
        }
        public double MixVol(double V, double D) 
        {

            return Math.Round(3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4, 0);
        }

        public double DustCalc(double V, double D, double Zo)
        {

            return Math.Round(Zo * (3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4), 1);
        }
        public double f_Coiff(double V, double D, double H, double Tr, double Ta)
        {

            return Math.Round((D * (Math.Pow((4 * (V / 3600) / (3.14 * Math.Pow(D, 2))), 2) * 1000)) / (Math.Pow(H, 2) * (Tr - Ta)), 3);
        }
        public double m_Coiff(double V, double D, double H, double Tr, double Ta) 
        {

            return Math.Round(Math.Pow(0.67 + 0.1 * Math.Sqrt(((D * (Math.Pow((4 * (V / 3600) / (3.14 * Math.Pow(D, 2))), 2) * 1000)) / (Math.Pow(H, 2) * (Tr - Ta)))) + 0.34 * Math.Sqrt(((D * (Math.Pow((4 * (V / 3600) / (3.14 * Math.Pow(D, 2))), 2) * 1000)) / (Math.Pow(H, 2) * (Tr - Ta)))), -1), 2);
        }
        public double Vm_Coiff(double V, double D, double H, double Tr, double Ta) 
        {

            return Math.Round((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0)), 2);
        }
        public double n_Coiff(double V, double D, double H, double Tr, double Ta) 
        {
            if ((0.65 * Math.Pow(3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4 * (Tr - Ta) / H, 1.0 / 3.0)) <= 0.3)
            {
                nValue = 3;
            }
            if ((0.65 * Math.Pow(3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4 * (Tr - Ta) / H, 1.0 / 3.0)) > 0.3 & (0.65 * Math.Pow(3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4 * (Tr - Ta) / H, 1.0 / 3.0)) <= 2)
            {
                nValue = (3 - Math.Sqrt(((0.65 * Math.Pow(3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4 * (Tr - Ta) / H, 1.0 / 3.0)) - 0.3) * (4.36 - (0.65 * Math.Pow(3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4 * (Tr - Ta) / H, 1.0 / 3.0)))));
            }
            if ((0.65 * Math.Pow(3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4 * (Tr - Ta) / H, 1.0 / 3.0)) > 2)
            {
                nValue = 1;
            }
            return nValue;
        }
        public double F_Coiff(double E, double nu) 
        {
            if (E == 1)
            {
                fValue = 1;
            }
            if (E == 0 && nu >= 90)
            {
                fValue = 2;
            }
            if (E == 0 && nu < 75)
            {
                fValue = 3;
            }
            if (E == 0 && nu >= 75 && nu < 90)
            {
                fValue = 2.5;
            }
            return fValue;
        }

        public double Cm_MaxPollutConcent(double A, double V, double D, double Zo, double E, double nu, double Tr, double Ta, double H) 
        {
            return Math.Round((A * (Zo * (3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4)) * F_Coiff(E, nu) * (Math.Pow(0.67 + 0.1 * Math.Sqrt(((D * (Math.Pow((4 * (V / 3600) / (3.14 * Math.Pow(D, 2))), 2) * 1000)) / (Math.Pow(H, 2) * (Tr - Ta)))) + 0.34 * Math.Sqrt(((D * (Math.Pow((4 * (V / 3600) / (3.14 * Math.Pow(D, 2))), 2) * 1000)) / (Math.Pow(H, 2) * (Tr - Ta)))), -1)) * n_Coiff(V, D, H, Tr, Ta)) / (Math.Pow(H, 2) * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta), 1.0 / 3.0)), 2);
        }




        public double d_Coiff(double V, double D, double H, double Tr, double Ta, double Zo) 
        {
            if (((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0))) <= 2)
            {
                dValue = 4.95 * ((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0))) * (1 + 0.28 * Math.Pow(((D * (Math.Pow((4 * (V / 3600) / (3.14 * Math.Pow(D, 2))), 2) * 1000)) / (Math.Pow(H, 2) * (Tr - Ta))), 1.0 / 3.0));
            }
            if (((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0))) > 2)
            {
                dValue = 7 * Math.Sqrt(((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0)))) * (1 + 0.28 * Math.Pow(((D * (Math.Pow((4 * (V / 3600) / (3.14 * Math.Pow(D, 2))), 2) * 1000)) / (Math.Pow(H, 2) * (Tr - Ta))), 1.0 / 3.0));
            }
            return Math.Round(dValue, 2);
        }
        public double Xm_TorchRange(double E, double nu, double V, double D, double H, double Tr, double Ta, double Zo) 
        {
            if (((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0))) >= 2)
            {
                XmValue = H * d_Coiff(V, D, H, Tr, Ta, Zo) * ((5 - F_Coiff(E, nu)) / 4);
            }
            if (((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0))) < 2)
            {
                XmValue = H * d_Coiff(V, D, H, Tr, Ta, Zo);
            }
            return XmValue;
        }



        public double um_DangerousBreezeSpeed(double V, double D, double H, double Tr, double Ta) 
        {

            if (((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0))) > 2)
            {
                umValue = Math.Round(((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0))) * (1 + 0.12 * Math.Sqrt(((D * (Math.Pow((4 * (V / 3600) / (3.14 * Math.Pow(D, 2))), 2) * 1000)) / (Math.Pow(H, 2) * (Tr - Ta))))), 2);
            }
            if (((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0))) > 0.5 & ((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0))) <= 2)
            {
                umValue = ((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0)));
            }
            if (((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0))) <= 0.5)
            {
                umValue = Math.Round(0.5 * ((0.65 * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta) / H, 1.0 / 3.0))), 2);
            }
            return umValue;
        }
        public double[] r_Coiff = new double[4]; 
        public double[] r_CoiffCount(double V, double D, double H, double Tr, double Ta)
        {
            for (int i = 0; i < r_Coiff.Length; i++)
            {
                if ((u[i] / um_DangerousBreezeSpeed(V, D, H, Tr, Ta)) < 1)
                {
                    r_Coiff[i] = Math.Round(0.67 * (u[i] / um_DangerousBreezeSpeed(V, D, H, Tr, Ta)) + 1.67 * Math.Pow(u[i] / um_DangerousBreezeSpeed(V, D, H, Tr, Ta), 2) - 1.34 * Math.Pow(u[i] / um_DangerousBreezeSpeed(V, D, H, Tr, Ta), 3), 3);
                }
                if ((u[i] / um_DangerousBreezeSpeed(V, D, H, Tr, Ta)) > 1)
                {
                    r_Coiff[i] = Math.Round(3 * (u[i] / um_DangerousBreezeSpeed(V, D, H, Tr, Ta)) / (2 * Math.Pow((u[i] / um_DangerousBreezeSpeed(V, D, H, Tr, Ta)), 2) - (u[i] / um_DangerousBreezeSpeed(V, D, H, Tr, Ta)) + 2), 3);
                }
            }
            return r_Coiff;
        }



        public double[] Cmv_MaxPollutConcetSpeedSolid = new double[4]; 
        public double[] Cmv_MaxPollutConcetSpeedSolidCount(double V, double D, double H, double Tr, double Ta, double Zo, double A, double E, double nu)
        {
            for (int i = 0; i < Cmv_MaxPollutConcetSpeedSolid.Length; i++)
            {
                Cmv_MaxPollutConcetSpeedSolid[i] = Math.Round(r_CoiffCount(V, D, H, Tr, Ta)[i] * ((A * (Zo * (3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4)) * F_Coiff(E, nu) * (Math.Pow(0.67 + 0.1 * Math.Sqrt(((D * (Math.Pow((4 * (V / 3600) / (3.14 * Math.Pow(D, 2))), 2) * 1000)) / (Math.Pow(H, 2) * (Tr - Ta)))) + 0.34 * Math.Sqrt(((D * (Math.Pow((4 * (V / 3600) / (3.14 * Math.Pow(D, 2))), 2) * 1000)) / (Math.Pow(H, 2) * (Tr - Ta)))), -1)) * n_Coiff(V, D, H, Tr, Ta)) / (Math.Pow(H, 2) * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta), 1.0 / 3.0))), 4);
            }
            return Cmv_MaxPollutConcetSpeedSolid;
        }



        public double[] Xmu_MaxConcentFarSolid = new double[4]; 
        public double[] Xmu_MaxConcentFarSolidCount(double E, double nu, double V, double D, double H, double Tr, double Ta, double Zo)
        {
            for (int i = 0; i < Xmu_MaxConcentFarSolid.Length; i++)
            {
                if ((u[i] / umValue) < 0.25)
                {
                    Xmu_MaxConcentFarSolid[i] = Math.Round(3 * Xm_TorchRange(E, nu, V, D, H, Tr, Ta, Zo), 0);
                }
                if ((u[i] / umValue) < 1 && (u[i] / umValue) >= 0.25)
                {
                    Xmu_MaxConcentFarSolid[i] = Math.Round((8.43 * Math.Pow(1 - (u[i] / um_DangerousBreezeSpeed(V, D, H, Tr, Ta)), 5) + 1) * Xm_TorchRange(E, nu, V, D, H, Tr, Ta, Zo), 0);
                }
                if ((u[i] / umValue) > 1)
                {
                    Xmu_MaxConcentFarSolid[i] = Math.Round((0.32 * (u[i] / um_DangerousBreezeSpeed(V, D, H, Tr, Ta)) + 0.68) * Xm_TorchRange(E, nu, V, D, H, Tr, Ta, Zo), 0);
                }
            }
            return Xmu_MaxConcentFarSolid;
        }
        public double[] S1_CoiffSolid = new double[5];
        public double[] S1_CoiffCount(double E, double nu, double V, double D, double H, double Tr, double Ta, double Zo)
        {
            for (int i = 0; i < S1_CoiffSolid.Length; i++)
            {
                if ((X[i] / Xm_TorchRange(E, nu, V, D, H, Tr, Ta, Zo)) <= 1)
                {
                    S1_CoiffSolid[i] = (3 * Math.Pow((X[i] / Xm_TorchRange(E, nu, V, D, H, Tr, Ta, Zo)), 4) - 8 * Math.Pow((X[i] / Xm_TorchRange(E, nu, V, D, H, Tr, Ta, Zo)), 3) + 6 * Math.Pow((X[i] / Xm_TorchRange(E, nu, V, D, H, Tr, Ta, Zo)), 2));
                }
                if ((X[i] / Xm_TorchRange(E, nu, V, D, H, Tr, Ta, Zo)) <= 8 && (X[i] / Xm_TorchRange(E, nu, V, D, H, Tr, Ta, Zo)) > 1)
                {
                    S1_CoiffSolid[i] = (1.13 / (0.13 * Math.Pow((X[i] / Xm_TorchRange(E, nu, V, D, H, Tr, Ta, Zo)), 2) + 1));
                }
                if ((X[i] / Xm_TorchRange(E, nu, V, D, H, Tr, Ta, Zo)) > 8)
                {
                    S1_CoiffSolid[i] = (Math.Pow(0.1 * Math.Pow((X[i] / Xm_TorchRange(E, nu, V, D, H, Tr, Ta, Zo)), 2) + 2.47 * (X[i] / Xm_TorchRange(E, nu, V, D, H, Tr, Ta, Zo)) - 17.8, -1));
                }

            }
            return S1_CoiffSolid;
        }
        public double[] Cx_ConcentCountRangeSolid = new double[5]; 
        public double[] Cx_ConcentCountRangeSolidCount(double E, double nu, double V, double D, double H, double Tr, double Ta, double Zo, double A)
        {
            for (int i = 0; i < Cx_ConcentCountRangeSolid.Length; i++)
            {
                Cx_ConcentCountRangeSolid[i] = (S1_CoiffCount(E, nu, V, D, H, Tr, Ta, Zo)[i] * ((A * (Zo * (3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4)) * F_Coiff(E, nu) * (Math.Pow(0.67 + 0.1 * Math.Sqrt(((D * (Math.Pow((4 * (V / 3600) / (3.14 * Math.Pow(D, 2))), 2) * 1000)) / (Math.Pow(H, 2) * (Tr - Ta)))) + 0.34 * Math.Sqrt(((D * (Math.Pow((4 * (V / 3600) / (3.14 * Math.Pow(D, 2))), 2) * 1000)) / (Math.Pow(H, 2) * (Tr - Ta)))), -1)) * n_Coiff(V, D, H, Tr, Ta)) / (Math.Pow(H, 2) * Math.Pow((3.14 * Math.Pow(D, 2) * (4 * (V / 3600) / (3.14 * Math.Pow(D, 2))) / 4) * (Tr - Ta), 1.0 / 3.0))));
            }
            return Cx_ConcentCountRangeSolid;
        }
        public double[,] S2_CoiffSolid = new double[5, 5]; 

        public double[,] S2_CoiffCount(double Speed)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    S2_CoiffSolid[i, j] = Math.Pow((1d + 8.4d * Speed * Math.Pow((Y[i] / X[j]), 2)) * (1d + 28.2d * Math.Pow(u[0], 2) * Math.Pow((Y[i] / X[j]), 4)), -1);
                }
            }
            return S2_CoiffSolid;
        }

        public double[,] Cy_ConcentCountRangeSolid = new double[5, 5]; 
        public double[,] Cy_ConcentCountRangeCount(double E, double nu, double V, double D, double H, double Tr, double Ta, double Zo, double A)
        {

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Cy_ConcentCountRangeSolid[j, i] = (S2_CoiffCount(VelValue)[i, j] * Cx_ConcentCountRangeSolidCount(E, nu, V, D, H, Tr, Ta, Zo, A)[j]);
                }
            }
            return Cy_ConcentCountRangeSolid;
        }
    }
}
