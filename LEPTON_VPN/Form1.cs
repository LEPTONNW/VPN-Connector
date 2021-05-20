using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEPTON_VPN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static string HTMLSorce;
        private static string FolderPath => string.Concat(Directory.GetCurrentDirectory(),
            "\\VPN");


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                HttpWebRequest oRequest = (HttpWebRequest)WebRequest.Create("https://leptonnw.synology.me/vpn_stat.html");

                HttpWebResponse oGetResponse = (HttpWebResponse)oRequest.GetResponse();

                StreamReader oStreamReader = new StreamReader(oGetResponse.GetResponseStream());

                string strHtml = oStreamReader.ReadToEnd();

                HTMLSorce = strHtml;

                bool yn = HTMLSorce.Contains("OPEN");

                if (yn == true)
                {
                    SV_Stat_L.Text = "서버상태 : ON";
                }
                else if (yn == false)
                {
                    SV_Stat_L.Text = "서버상태 : OFF";
                }
            }
            catch
            {
                SV_Stat_L.Text = "서버상태 : OFF";
                MessageBox.Show("인터넷 연결이 원할하지 않거나, 서버상태가 좋지 않을 수 있습니다." + Environment.NewLine + "서버문제시 관리자에게 문의하세요");
            }


            // comboBox1.Items.Add("서버1");
            // comboBox1.Items.Add("서버2");
            comboBox1.SelectedIndex = 0;
        }

        protected override void WndProc(ref Message m) //폼 좌표이동
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }
            base.WndProc(ref m);
        }

        private void Connect_Btn_Click(object sender, EventArgs e)
        {
            if (Connect_Btn.Text == "연결")
            {
                if (!Directory.Exists(FolderPath))
                    Directory.CreateDirectory(FolderPath);

                var sb = new StringBuilder();
                sb.AppendLine("[LEPTON]");
                sb.AppendLine("Encoding=1");
                sb.AppendLine("PBVersion=5");
                sb.AppendLine("Type=2");
                sb.AppendLine("AutoLogon=0");
                sb.AppendLine("UseRasCredentials=1");
                sb.AppendLine("LowDateTime=1859224096");
                sb.AppendLine("HighDateTime=30798574");
                sb.AppendLine("DialParamsUID=34516296");
                sb.AppendLine("Guid=4997E7B1AEA9FE4793CDB86A2FA35ABD");
                sb.AppendLine("VpnStrategy=1");
                sb.AppendLine("ExcludedProtocols=0");
                sb.AppendLine("LcpExtensions=1");
                sb.AppendLine("DataEncryption=8");
                sb.AppendLine("SwCompression=0");
                sb.AppendLine("NegotiateMultilinkAlways=0");
                sb.AppendLine("SkipDoubleDialDialog=0");
                sb.AppendLine("DialMode=0");
                sb.AppendLine("OverridePref=15");
                sb.AppendLine("RedialAttempts=3");
                sb.AppendLine("RedialSeconds=60");
                sb.AppendLine("IdleDisconnectSeconds=0");
                sb.AppendLine("RedialOnLinkFailure=1");
                sb.AppendLine("CallbackMode=0");
                sb.AppendLine("CustomDialDll=");
                sb.AppendLine("CustomDialFunc=");
                sb.AppendLine("CustomRasDialDll=");
                sb.AppendLine("ForceSecureCompartment=0");
                sb.AppendLine("DisableIKENameEkuCheck=0");
                sb.AppendLine("AuthenticateServer=0");
                sb.AppendLine("ShareMsFilePrint=1");
                sb.AppendLine("BindMsNetClient=1");
                sb.AppendLine("SharedPhoneNumbers=0");
                sb.AppendLine("GlobalDeviceSettings=0");
                sb.AppendLine("PrerequisiteEntry=");
                sb.AppendLine("PrerequisitePbk=");
                sb.AppendLine("PreferredPort=VPN1-0");
                sb.AppendLine("PreferredDevice=WAN Miniport (SSTP)");
                sb.AppendLine("PreferredBps=0");
                sb.AppendLine("PreferredHwFlow=0");
                sb.AppendLine("PreferredProtocol=0");
                sb.AppendLine("PreferredCompression=0");
                sb.AppendLine("PreferredSpeaker=0");
                sb.AppendLine("PreferredMdmProtocol=0");
                sb.AppendLine("PreviewUserPw=1");
                sb.AppendLine("PreviewDomain=1");
                sb.AppendLine("PreviewPhoneNumber=0");
                sb.AppendLine("ShowDialingProgress=1");
                sb.AppendLine("ShowMonitorIconInTaskBar=0");
                sb.AppendLine("CustomAuthKey=0");
                sb.AppendLine("AuthRestrictions=512");
                sb.AppendLine("IpPrioritizeRemote=1");
                sb.AppendLine("IpInterfaceMetric=0");
                sb.AppendLine("IpHeaderCompression=0");
                sb.AppendLine("IpAddress=0.0.0.0");
                sb.AppendLine("IpDnsAddress=0.0.0.0");
                sb.AppendLine("IpDns2Address=0.0.0.0");
                sb.AppendLine("IpWinsAddress=0.0.0.0");
                sb.AppendLine("IpWins2Address=0.0.0.0");
                sb.AppendLine("IpAssign=1");
                sb.AppendLine("IpNameAssign=1");
                sb.AppendLine("IpDnsFlags=0");
                sb.AppendLine("IpNBTFlags=1");
                sb.AppendLine("TcpWindowSize=0");
                sb.AppendLine("UseFlags=2");
                sb.AppendLine("IpSecFlags=0");
                sb.AppendLine("IpDnsSuffix=");
                sb.AppendLine("Ipv6Assign=1");
                sb.AppendLine("Ipv6Address=::");
                sb.AppendLine("Ipv6PrefixLength=0");
                sb.AppendLine("Ipv6PrioritizeRemote=1");
                sb.AppendLine("Ipv6InterfaceMetric=0");
                sb.AppendLine("Ipv6NameAssign=1");
                sb.AppendLine("Ipv6DnsAddress=::");
                sb.AppendLine("Ipv6Dns2Address =::");
                sb.AppendLine("Ipv6Prefix=0000000000000000");
                sb.AppendLine("Ipv6InterfaceId=0000000000000000");
                sb.AppendLine("DisableClassBasedDefaultRoute=0");
                sb.AppendLine("DisableMobility=0");
                sb.AppendLine("NetworkOutageTime=0");
                sb.AppendLine("IDI=");
                sb.AppendLine("IDR=");
                sb.AppendLine("ImsConfig=0");
                sb.AppendLine("IdiType=0");
                sb.AppendLine("IdrType=0");
                sb.AppendLine("ProvisionType=0");
                sb.AppendLine("PreSharedKey=");
                sb.AppendLine("CacheCredentials=1");
                sb.AppendLine("NumCustomPolicy=0");
                sb.AppendLine("NumEku=0");
                sb.AppendLine("UseMachineRootCert=0");
                sb.AppendLine("Disable_IKEv2_Fragmentation=0");
                sb.AppendLine("NumServers=0");
                sb.AppendLine("RouteVersion=1");
                sb.AppendLine("NumRoutes=0");
                sb.AppendLine("NumNrptRules=0");
                sb.AppendLine("AutoTiggerCapable=0");
                sb.AppendLine("NumAppIds=0");
                sb.AppendLine("NumClassicAppIds=0");
                sb.AppendLine("SecurityDescriptor=");
                sb.AppendLine("ApnInfoProviderId=");
                sb.AppendLine("ApnInfoUsername=");
                sb.AppendLine("ApnInfoPassword=");
                sb.AppendLine("ApnInfoAccessPoint=");
                sb.AppendLine("ApnInfoAuthentication=1");
                sb.AppendLine("ApnInfoCompression=0");
                sb.AppendLine("DeviceComplianceEnabled=0");
                sb.AppendLine("DeviceComplianceSsoEnabled=0");
                sb.AppendLine("DeviceComplianceSsoEku=");
                sb.AppendLine("DeviceComplianceSsoIssuer=");
                sb.AppendLine("FlagsSet=0");
                sb.AppendLine("Options=0");
                sb.AppendLine("DisableDefaultDnsSuffixes=0");
                sb.AppendLine("NumTrustedNetworks=0");
                sb.AppendLine("NumDnsSearchSuffixes=0");
                sb.AppendLine("PowershellCreatedProfile=0");
                sb.AppendLine("ProxyFlags=0");
                sb.AppendLine("ProxySettingsModified=0");
                sb.AppendLine("ProvisioningAuthority=");
                sb.AppendLine("AuthTypeOTP=0");
                sb.AppendLine("GREKeyDefined=0");
                sb.AppendLine("NumPerAppTrafficFilters=0");
                sb.AppendLine("AlwaysOnCapable=0");
                sb.AppendLine("DeviceTunnel=0");
                sb.AppendLine("PrivateNetwork=0");


                sb.AppendLine("NETCOMPONENTS=");
                sb.AppendLine("ms_msclient=1");
                sb.AppendLine("ms_server=1");


                sb.AppendLine("MEDIA=rastapi");
                sb.AppendLine("Port=VPN1-0");
                sb.AppendLine("Device=WAN Miniport (SSTP)");


                sb.AppendLine("DEVICE=vpn");
                sb.AppendLine("PhoneNumber=leptonnw.synology.me");
                sb.AppendLine("AreaCode=");
                sb.AppendLine("CountryCode=0");
                sb.AppendLine("CountryID=0");
                sb.AppendLine("UseDialingRules=0");
                sb.AppendLine("Comment=");
                sb.AppendLine("FriendlyName=");
                sb.AppendLine("LastSelectedPhone=0");
                sb.AppendLine("PromoteAlternates=0");
                sb.AppendLine("TryNextAlternateOnFail=1");


                File.WriteAllText(FolderPath + "\\VpnConnection.pbk", sb.ToString());
                //MessageBox.Show(FolderPath.ToString());
                if (comboBox1.Text == "서버1")
                {
                    sb = new StringBuilder();
                    //sb.AppendLine("rasdial:" + "VPN_G1 !Wkdtjsgh2795" + "/phonebook:\\" + FolderPath + "\\VpnConnection.pbk");

                    sb.AppendLine("rasdial LEPTON " + "VPN_G1 !Wkdtjsgh2795" + " /PHONEBOOK:" + FolderPath +
              @"\VpnConnection.pbk");

                    File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());
                }

                else if (comboBox1.Text == "서버2")
                {
                    sb.AppendLine("rasdial LEPTON " + "VPN_G2 !Wkdtjsgh2795" + " /PHONEBOOK:" + FolderPath +
              @"\VpnConnection.pbk");

                    File.WriteAllText(FolderPath + "\\VpnConnection.bat", sb.ToString());
                }

                var newProcess = new Process
                {
                    StartInfo =
                {
                    FileName = FolderPath + "\\VpnConnection.bat",
                    WindowStyle = ProcessWindowStyle.Normal
                }
                };

                newProcess.Start();
                newProcess.WaitForExit();

                Connect_Btn.Text = "연결해제";
            }
            else
            {
                File.WriteAllText(FolderPath + "\\VpnDisconnect.bat", "rasdial /d");

                var newProcess = new Process
                {
                    StartInfo =
                {
                    FileName = FolderPath + "\\VpnDisconnect.bat",
                    WindowStyle = ProcessWindowStyle.Normal
                }
                };

                newProcess.Start();
                newProcess.WaitForExit();

                Connect_Btn.Text = "연결";
            }

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(FolderPath + "\\VpnDisconnect.bat", "rasdial /d");

                var newProcess = new Process
                {
                    StartInfo =
                {
                    FileName = FolderPath + "\\VpnDisconnect.bat",
                    WindowStyle = ProcessWindowStyle.Normal
                }
                };

                newProcess.Start();
                newProcess.WaitForExit();

                Application.ExitThread();
                Application.Exit();
                Process.GetCurrentProcess().Kill();
                this.Close();
            }
            catch
            { }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.WriteAllText(FolderPath + "\\VpnDisconnect.bat", "rasdial /d");

                var newProcess = new Process
                {
                    StartInfo =
                {
                    FileName = FolderPath + "\\VpnDisconnect.bat",
                    WindowStyle = ProcessWindowStyle.Normal
                }
                };

                newProcess.Start();
                newProcess.WaitForExit();
            }
            catch { }
        }
    }
}
