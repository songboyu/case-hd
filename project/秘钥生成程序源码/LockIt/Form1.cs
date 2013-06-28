using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;

namespace LockIt
{
    public partial class Form1 : Form
    {
        private String MachineID = "";
        const string privateKeyStrings = "RUNTMiAAAABgvqwAm9/Dr7SI/2GB87OJX2hbiVh2e3fRi1D0XYodU9X5ZoMzw6Yi4v1Nq45mO1WcKiVTp8Y+WzTWgK1cxKGUPmDMRMYdezdcBTVxSIxB+ACnleSQzzq/yPYE3Ghfws8=";
        byte[] privateKeyBytes;
        TextBox[] bigNums = new TextBox[8];
        public Form1()
        {
            InitializeComponent();

            skinEngine1.SkinFile = "Emerald.ssk";
            skinEngine1.SkinAllForm = false;
            bigNums[0] = BigNumText1;
            bigNums[1] = BigNumText2;
            bigNums[2] = BigNumText3;
            bigNums[3] = BigNumText4;
            bigNums[4] = BigNumText5;
            bigNums[5] = BigNumText6;
            bigNums[6] = BigNumText7;
            bigNums[7] = BigNumText8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            privateKeyBytes = Convert.FromBase64String(privateKeyStrings);
            CngKey cngKey = CngKey.Import(privateKeyBytes, CngKeyBlobFormat.EccPrivateBlob);

            MachineID = textBox1.Text;
            byte[] data = new byte[8];

            for (int i = 0; i < 8; i++)
            {
                data[i] = Byte.Parse(MachineID[i].ToString());
            }

            using (ECDsaCng dsa = new ECDsaCng(cngKey))
            {
                dsa.HashAlgorithm = CngAlgorithm.MD5;
                byte[] signature = dsa.SignData(data);
                dsa.Clear();
                ulong[] signatureUlong = CodeConverter.ToInt64Array(signature);
                for (int i = 0; i < 8; i++)
                {
                    bigNums[i].Text = signatureUlong[i].ToString();
                    bigNums[i].ReadOnly = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process process = Process.GetCurrentProcess();
            process.CloseMainWindow();
            process.Kill();
        }
    }

    class CodeConverter
    {
        public static ulong[] ToInt64Array(byte[] data)
        {
            ulong[] a = new ulong[data.Length / 8];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = BitConverter.ToUInt64(data, i * 8);
            }
            return a;
        }
    }
}
