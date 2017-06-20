<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="CMSWebForms.Azure" generation="1" functional="0" release="0" Id="2c67dd97-0dbb-48a6-8e5c-4f46acce164b" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="CMSWebForms.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="CMSWebForms:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/LB:CMSWebForms:Endpoint1" />
          </inToChannel>
        </inPort>
        <inPort name="CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/LB:CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inToChannel>
        </inPort>
        <inPort name="CMSWebForms:Microsoft.WindowsAzure.Plugins.WebDeploy.InputEndpoint" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/LB:CMSWebForms:Microsoft.WindowsAzure.Plugins.WebDeploy.InputEndpoint" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="Certificate|CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" defaultValue="">
          <maps>
            <mapMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/MapCertificate|CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </maps>
        </aCS>
        <aCS name="CMSWebForms:APPINSIGHTS_INSTRUMENTATIONKEY" defaultValue="">
          <maps>
            <mapMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/MapCMSWebForms:APPINSIGHTS_INSTRUMENTATIONKEY" />
          </maps>
        </aCS>
        <aCS name="CMSWebForms:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/MapCMSWebForms:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="">
          <maps>
            <mapMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/MapCMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </maps>
        </aCS>
        <aCS name="CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="">
          <maps>
            <mapMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/MapCMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </maps>
        </aCS>
        <aCS name="CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="">
          <maps>
            <mapMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/MapCMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </maps>
        </aCS>
        <aCS name="CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/MapCMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </maps>
        </aCS>
        <aCS name="CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="">
          <maps>
            <mapMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/MapCMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </maps>
        </aCS>
        <aCS name="CMSWebFormsInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/MapCMSWebFormsInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:CMSWebForms:Endpoint1">
          <toPorts>
            <inPortMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms/Endpoint1" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput">
          <toPorts>
            <inPortMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms/Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:CMSWebForms:Microsoft.WindowsAzure.Plugins.WebDeploy.InputEndpoint">
          <toPorts>
            <inPortMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms/Microsoft.WindowsAzure.Plugins.WebDeploy.InputEndpoint" />
          </toPorts>
        </lBChannel>
        <sFSwitchChannel name="SW:CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp">
          <toPorts>
            <inPortMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms/Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
          </toPorts>
        </sFSwitchChannel>
      </channels>
      <maps>
        <map name="MapCertificate|CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" kind="Identity">
          <certificate>
            <certificateMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
          </certificate>
        </map>
        <map name="MapCMSWebForms:APPINSIGHTS_INSTRUMENTATIONKEY" kind="Identity">
          <setting>
            <aCSMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms/APPINSIGHTS_INSTRUMENTATIONKEY" />
          </setting>
        </map>
        <map name="MapCMSWebForms:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapCMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" kind="Identity">
          <setting>
            <aCSMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" />
          </setting>
        </map>
        <map name="MapCMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" kind="Identity">
          <setting>
            <aCSMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" />
          </setting>
        </map>
        <map name="MapCMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" kind="Identity">
          <setting>
            <aCSMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms/Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" />
          </setting>
        </map>
        <map name="MapCMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms/Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" />
          </setting>
        </map>
        <map name="MapCMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" kind="Identity">
          <setting>
            <aCSMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms/Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" />
          </setting>
        </map>
        <map name="MapCMSWebFormsInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebFormsInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="CMSWebForms" generation="1" functional="0" release="0" software="C:\Users\Dwight\documents\visual studio 2015\Projects\CMSWebForms\CMSWebForms.Azure\csx\Release\roles\CMSWebForms" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaIISHost.exe " memIndex="-1" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" protocol="tcp" />
              <inPort name="Microsoft.WindowsAzure.Plugins.WebDeploy.InputEndpoint" protocol="tcp" portRanges="8172" />
              <inPort name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp" portRanges="3389" />
              <outPort name="CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" protocol="tcp">
                <outToChannel>
                  <sFSwitchChannelMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/SW:CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp" />
                </outToChannel>
              </outPort>
            </componentports>
            <settings>
              <aCS name="APPINSIGHTS_INSTRUMENTATIONKEY" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountEncryptedPassword" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountExpiration" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.AccountUsername" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteAccess.Enabled" defaultValue="" />
              <aCS name="Microsoft.WindowsAzure.Plugins.RemoteForwarder.Enabled" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;CMSWebForms&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;CMSWebForms&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteAccess.Rdp&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput&quot; /&gt;&lt;e name=&quot;Microsoft.WindowsAzure.Plugins.WebDeploy.InputEndpoint&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
            <storedcertificates>
              <storedCertificate name="Stored0Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" certificateStore="My" certificateLocation="System">
                <certificate>
                  <certificateMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms/Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
                </certificate>
              </storedCertificate>
            </storedcertificates>
            <certificates>
              <certificate name="Microsoft.WindowsAzure.Plugins.RemoteAccess.PasswordEncryption" />
            </certificates>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebFormsInstances" />
            <sCSPolicyUpdateDomainMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebFormsUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebFormsFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="CMSWebFormsUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="CMSWebFormsFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="CMSWebFormsInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="e8ebfbbf-03f0-4b00-b39c-06bf859e4ea8" ref="Microsoft.RedDog.Contract\ServiceContract\CMSWebForms.AzureContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="157f0fef-4199-4656-a96a-13ac6cce025f" ref="Microsoft.RedDog.Contract\Interface\CMSWebForms:Endpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms:Endpoint1" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="7476250c-1c3e-4eda-9cec-ea34bc72ca28" ref="Microsoft.RedDog.Contract\Interface\CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms:Microsoft.WindowsAzure.Plugins.RemoteForwarder.RdpInput" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="88f8e640-a2fa-4bf6-9d09-d235b08218cb" ref="Microsoft.RedDog.Contract\Interface\CMSWebForms:Microsoft.WindowsAzure.Plugins.WebDeploy.InputEndpoint@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/CMSWebForms.Azure/CMSWebForms.AzureGroup/CMSWebForms:Microsoft.WindowsAzure.Plugins.WebDeploy.InputEndpoint" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>