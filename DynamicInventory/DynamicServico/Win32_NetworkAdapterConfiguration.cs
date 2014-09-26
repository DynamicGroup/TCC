using System;

namespace DynamicService
{
    class Win32_NetworkAdapterConfiguration
    {
        public bool ArpAlwaysSourceRoute;
        public bool ArpUseEtherSNAP;
        public string Caption;
        public string DatabasePath;
        public bool DeadGWDetectEnabled;
        public string[] DefaultIPGateway;
        public byte DefaultTOS;
        public byte DefaultTTL;
        public string Description;
        public bool DHCPEnabled;
        public DateTime DHCPLeaseExpires;
        public DateTime DHCPLeaseObtained;
        public string DHCPServer;
        public string DNSDomain;
        public string[] DNSDomainSuffixSearchOrder;
        public bool DNSEnabledForWINSResolution;
        public string DNSHostName;
        public string[] DNSServerSearchOrder;
        public bool DomainDNSRegistrationEnabled;
        public int ForwardBufferMemory;
        public bool FullDNSRegistrationEnabled;
        public short[] GatewayCostMetric;
        public byte IGMPLevel;
        public int Index;
        public int InterfaceIndex;
        public string[] IPAddress;
        public int IPConnectionMetric;
        public bool IPEnabled;
        public bool IPFilterSecurityEnabled;
        public bool IPPortSecurityEnabled;
        public string[] IPSecPermitIPProtocols;
        public string[] IPSecPermitTCPPorts;
        public string[] IPSecPermitUDPPorts;
        public string[] IPSubnet;
        public bool IPUseZeroBroadcast;
        public string IPXAddress;
        public bool IPXEnabled;
        public int[] IPXFrameType;
        public int IPXMediaType;
        public string[] IPXNetworkNumber;
        public string IPXVirtualNetNumber;
        public int KeepAliveInterval;
        public int KeepAliveTime;
        public string MACAddress;
        public int MTU;
        public int NumForwardPackets;
        public bool PMTUBHDetectEnabled;
        public bool PMTUDiscoveryEnabled;
        public string ServiceName;
        public string SettingID;
        public int TcpipNetbiosOptions;
        public int TcpMaxConnectRetransmissions;
        public int TcpMaxDataRetransmissions;
        public int TcpNumConnections;
        public bool TcpUseRFC1122UrgentPointer;
        public short TcpWindowSize;
        public bool WINSEnableLMHostsLookup;
        public string WINSHostLookupFile;
        public string WINSPrimaryServer;
        public string WINSScopeID;
        public string WINSSecondaryServer;


        public Win32_NetworkAdapterConfiguration()
        {

        }
    }
}
