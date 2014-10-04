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
        public byte? DefaultTOS;
        public byte? DefaultTTL;
        public string Description;
        public bool DHCPEnabled;
        public DateTime? DHCPLeaseExpires;
        public DateTime? DHCPLeaseObtained;
        public string DHCPServer;
        public string DNSDomain;
        public string[] DNSDomainSuffixSearchOrder;
        public bool DNSEnabledForWINSResolution;
        public string DNSHostName;
        public string[] DNSServerSearchOrder;
        public bool DomainDNSRegistrationEnabled;
        public uint? ForwardBufferMemory;
        public bool FullDNSRegistrationEnabled;
        public ushort[] GatewayCostMetric;
        public byte? IGMPLevel;
        public uint? Index;
        public uint? InterfaceIndex;
        public string[] IPAddress;
        public uint? IPConnectionMetric;
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
        public uint[] IPXFrameType;
        public uint? IPXMediaType;
        public string[] IPXNetworkNumber;
        public string IPXVirtualNetNumber;
        public uint? KeepAliveInterval;
        public uint? KeepAliveTime;
        public string MACAddress;
        public uint? MTU;
        public uint? NumForwardPackets;
        public bool PMTUBHDetectEnabled;
        public bool PMTUDiscoveryEnabled;
        public string ServiceName;
        public string SettingID;
        public uint? TcpipNetbiosOptions;
        public uint? TcpMaxConnectRetransmissions;
        public uint? TcpMaxDataRetransmissions;
        public uint? TcpNumConnections;
        public bool TcpUseRFC1122UrgentPointer;
        public ushort? TcpWindowSize;
        public bool WINSEnableLMHostsLookup;
        public string WINSHostLookupFile;
        public string WINSPrimaryServer;
        public string WINSScopeID;
        public string WINSSecondaryServer;

        public string DeviceID;
        public string SerialNumber_Win32_ComputerSystem;

        public Win32_NetworkAdapterConfiguration()
        {

        }
    }
}
