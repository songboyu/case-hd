using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace Case05_4
{
    public partial class LockClient : Form
    {
        byte[] signature;
        private ulong[] signatureULong = new ulong[8];
        TextBox[] bigNums = new TextBox[8];
        /**
         * LockClient的构造函数
         **/
        public LockClient()
        {
            InitializeComponent();

            skinEngine1.SkinFile = "Emerald.ssk";
            skinEngine1.SkinAllForm = false;
            textBox1.Text = MachineID.ComputeEasyMachineIDToString();
            textBox1.ReadOnly = true;
            bigNums[0] = BigNumText1;
            bigNums[1] = BigNumText2;
            bigNums[2] = BigNumText3;
            bigNums[3] = BigNumText4;
            bigNums[4] = BigNumText5;
            bigNums[5] = BigNumText6;
            bigNums[6] = BigNumText7;
            bigNums[7] = BigNumText8;
        }

        /**
         * 验证签名button的触发事件
         * @function：验证数字签名
         **/
        private void button5_Click(object sender, EventArgs e)
        {
            ECDsaCng dsa = getECDsaCng();
            signatureULong = getSignatureUlong();
            signature = getSignatureToBytes(signatureULong);
            try
            {
                if (dsa.VerifyData(MachineID.ComputeEasyMachineID(), signature))
                {
                    saveSignatureToBase64(signature);
                    MessageBox.Show("验证成功，欢迎您使用正版软件", "视频采集系统");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("验证失败，请检查您的输入是否有误", "视频采集系统");
                    //this.Close();
                    //Process process = Process.GetCurrentProcess();
                    //process.CloseMainWindow();
                    //process.Kill();
                    //System.Diagnostics.Process.Start("shutdown", @"/r");
                }
                dsa.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序不能安装在C盘，请重新安装", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



          /**
         * 获得signature的64位无符号整数的数组形式(将覆盖已有文件)
         **/
        private ulong[] getSignatureUlong()
        {
            ulong[] signatureULongTemp = new ulong[8];
            for (int i = 0; i < 8; i++)
            {
                if (bigNums[i].Text.Length > 0)
                {
                    try
                    {
                        signatureULongTemp[i] = Convert.ToUInt64(bigNums[i].Text);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("第" + (i + 1) + "行的签名不是纯数字，请重新输入", "图像采集系统");
                    }
                }
                else
                {
                    MessageBox.Show("第" + (i+1) +"行没有填写数字，请重新输入","视频采集系统");
                }
            }
            return signatureULongTemp;
        }

        /**
         * 获得signature的8位无符号整数的Bytes数组形式(将覆盖已有文件)
         **/
        private byte[] getSignatureToBytes(ulong[] codeList)
        {
            byte[] a = new byte[codeList.Length * 8];
            for (int i = 0; i < codeList.Length; i++)
            {
                BitConverter.GetBytes(codeList[i]).CopyTo(a, i * 8);
            }
            return a;
        }

        /**
         * 创建并写入signature的Base64编码的等效字符串(将覆盖已有文件)
         **/
        private void saveSignatureToBase64(byte[] signature)
        {
            //创建并写入(将覆signature盖已有文件)
            using (StreamWriter sw = File.CreateText("signature.txt"))
            {
                sw.WriteLine(Convert.ToBase64String(signature));
            }
        }

        /**
         * 获取publicKeyBytes的值
         **/
        public static ECDsaCng getECDsaCng()
        {
            const string publicKeyString = "RUNTMSAAAABgvqwAm9/Dr7SI/2GB87OJX2hbiVh2e3fRi1D0XYodU9X5ZoMzw6Yi4v1Nq45mO1WcKiVTp8Y+WzTWgK1cxKGU";
            byte[] publicKeyBytes = Convert.FromBase64String(publicKeyString);
            CngKey cngKey = CngKey.Import(publicKeyBytes, CngKeyBlobFormat.EccPublicBlob);
            ECDsaCng dsa = new ECDsaCng(cngKey);
            dsa.HashAlgorithm = CngAlgorithm.MD5;
            return dsa;
        }

        /**
         * 取消button的触发事件
         * @function 在这里杀死进程
         **/
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("请支持正版!", "视频采集系统");
            this.Close();
            Process process = Process.GetCurrentProcess();
            process.CloseMainWindow();
            process.Kill();
        }

        /**
         * 关闭窗口的触发事件
         * @function 在这里杀死进程
         **/
        private void LockClient_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("请支持正版,谢谢使用!","视频采集系统");
            Process process = Process.GetCurrentProcess();
            process.CloseMainWindow();
            process.Kill();
        }
    }
}