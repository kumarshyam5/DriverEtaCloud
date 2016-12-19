<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="DriverETACloud.CloudService" generation="1" functional="0" release="0" Id="b06676d3-41a4-4afb-b10a-bc79df91adac" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="DriverETACloud.CloudServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="DriverETACloud.Service:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/DriverETACloud.CloudService/DriverETACloud.CloudServiceGroup/LB:DriverETACloud.Service:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="DriverETACloud.Service:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/DriverETACloud.CloudService/DriverETACloud.CloudServiceGroup/MapDriverETACloud.Service:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="DriverETACloud.ServiceInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/DriverETACloud.CloudService/DriverETACloud.CloudServiceGroup/MapDriverETACloud.ServiceInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:DriverETACloud.Service:Endpoint1">
          <toPorts>
            <inPortMoniker name="/DriverETACloud.CloudService/DriverETACloud.CloudServiceGroup/DriverETACloud.Service/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapDriverETACloud.Service:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/DriverETACloud.CloudService/DriverETACloud.CloudServiceGroup/DriverETACloud.Service/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapDriverETACloud.ServiceInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/DriverETACloud.CloudService/DriverETACloud.CloudServiceGroup/DriverETACloud.ServiceInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="DriverETACloud.Service" generation="1" functional="0" release="0" software="C:\Users\u23298\Documents\Visual Studio 2017\Projects\DriverETACloud\DriverETACloud.CloudService\csx\Debug\roles\DriverETACloud.Service" entryPoint="base\x86\WaHostBootstrapper.exe" parameters="base\x86\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;DriverETACloud.Service&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;DriverETACloud.Service&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/DriverETACloud.CloudService/DriverETACloud.CloudServiceGroup/DriverETACloud.ServiceInstances" />
            <sCSPolicyUpdateDomainMoniker name="/DriverETACloud.CloudService/DriverETACloud.CloudServiceGroup/DriverETACloud.ServiceUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/DriverETACloud.CloudService/DriverETACloud.CloudServiceGroup/DriverETACloud.ServiceFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="DriverETACloud.ServiceUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="DriverETACloud.ServiceFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="DriverETACloud.ServiceInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="70937910-2832-4d4b-b6f4-1499ef1d30df" ref="Microsoft.RedDog.Contract\ServiceContract\DriverETACloud.CloudServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="f3036661-d891-4994-bbf2-ba29a0f0a609" ref="Microsoft.RedDog.Contract\Interface\DriverETACloud.Service:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/DriverETACloud.CloudService/DriverETACloud.CloudServiceGroup/DriverETACloud.Service:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>