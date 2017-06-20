<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="CMSUsersAndRoles.Azure" generation="1" functional="0" release="0" Id="82e41cc9-f506-4110-a68e-568f74a81b86" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="CMSUsersAndRoles.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="CMSUsersAndRoles:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/LB:CMSUsersAndRoles:Endpoint1" />
          </inToChannel>
        </inPort>
        <inPort name="CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/LB:CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Certificate|CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" defaultValue="">
          <maps>
            <mapMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/MapCertificate|CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </maps>
        </aCS>
        <aCS name="CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/MapCMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="">
          <maps>
            <mapMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/MapCMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </maps>
        </aCS>
        <aCS name="CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="">
          <maps>
            <mapMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/MapCMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </maps>
        </aCS>
        <aCS name="CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="">
          <maps>
            <mapMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/MapCMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </maps>
        </aCS>
        <aCS name="CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/MapCMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </maps>
        </aCS>
        <aCS name="CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/MapCMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </maps>
        </aCS>
        <aCS name="CMSUsersAndRolesInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/MapCMSUsersAndRolesInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:CMSUsersAndRoles:Endpoint1">
          <toPorts>
            <inPortMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRoles/Endpoint1" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput">
          <toPorts>
            <inPortMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRoles/Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </toPorts>
        </lBChannel>
        <sFSwitchChannel name="SW:CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp">
          <toPorts>
            <inPortMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRoles/Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
          </toPorts>
        </sFSwitchChannel>
      </channels>
      <maps>
        <map name="MapCertificate|CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" kind="Identity">
          <certificate>
            <certificateMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRoles/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </certificate>
        </map>
        <map name="MapCMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRoles/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapCMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" kind="Identity">
          <setting>
            <aCSMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRoles/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </setting>
        </map>
        <map name="MapCMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" kind="Identity">
          <setting>
            <aCSMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRoles/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </setting>
        </map>
        <map name="MapCMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" kind="Identity">
          <setting>
            <aCSMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRoles/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </setting>
        </map>
        <map name="MapCMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRoles/Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </setting>
        </map>
        <map name="MapCMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRoles/Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </setting>
        </map>
        <map name="MapCMSUsersAndRolesInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRolesInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="CMSUsersAndRoles" generation="1" functional="0" release="0" software="C:\Users\Dwight\Documents\Visual Studio 2015\Projects\CMSWebForms\CMSUsersAndRoles.Azure\csx\Debug\roles\CMSUsersAndRoles" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp" portRanges="3389" />
              <outPort name="CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/SW:CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;CMSUsersAndRoles&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;CMSUsersAndRoles&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
            <storedcertificates>
              <storedCertificate name="Stored0Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" certificateStore="My" certificateLocation="System">
                <certificate>
                  <certificateMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRoles/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
                </certificate>
              </storedCertificate>
            </storedcertificates>
            <certificates>
              <certificate name="Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
            </certificates>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRolesInstances" />
            <sCSPolicyUpdateDomainMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRolesUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRolesFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="CMSUsersAndRolesUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="CMSUsersAndRolesFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="CMSUsersAndRolesInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="ff1f449f-97cf-4c0e-805d-4dccc5042d2d" ref="Microsoft.RedDog.Contract\ServiceContract\CMSUsersAndRoles.AzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="f4286d6f-124d-4258-a6f2-b3cda1d4a450" ref="Microsoft.RedDog.Contract\Interface\CMSUsersAndRoles:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRoles:Endpoint1" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="52e0ed10-5dab-473c-a0bf-60ef7cbc784e" ref="Microsoft.RedDog.Contract\Interface\CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/CMSUsersAndRoles.Azure/CMSUsersAndRoles.AzureGroup/CMSUsersAndRoles:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>