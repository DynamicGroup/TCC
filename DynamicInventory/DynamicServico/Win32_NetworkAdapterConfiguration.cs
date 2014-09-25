using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public UInt32 ForwardBufferMemory;
        public bool FullDNSRegistrationEnabled;
        public UInt16[] GatewayCostMetric;
        public byte IGMPLevel;
        public UInt32 Index;
        public UInt32 InterfaceIndex;
        public string[] IPAddress;
        public UInt32 IPConnectionMetric;
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
        public UInt32[] IPXFrameType;
        public UInt32 IPXMediaType;
        public string[] IPXNetworkNumber;
        public string IPXVirtualNetNumber;
        public UInt32 KeepAliveInterval;
        public UInt32 KeepAliveTime;
        public string MACAddress;
        public UInt32 MTU;
        public UInt32 NumForwardPackets;
        public bool PMTUBHDetectEnabled;
        public bool PMTUDiscoveryEnabled;
        public string ServiceName;
        public string SettingID;
        public UInt32 TcpipNetbiosOptions;
        public UInt32 TcpMaxConnectRetransmissions;
        public UInt32 TcpMaxDataRetransmissions;
        public UInt32 TcpNumConnections;
        public bool TcpUseRFC1122UrgentPointer;
        public UInt16 TcpWindowSize;
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
