// Type: System.ServiceProcess.ServiceController
// Assembly: System.ServiceProcess, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.ServiceProcess.dll

using System;
using System.ComponentModel;
using System.Runtime;
using System.Runtime.InteropServices;
using System.ServiceProcess.Design;

namespace System.ServiceProcess
{
    /// <summary>
    /// Represents a Windows service and allows you to connect to a running or stopped service, manipulate it, or get information about it.
    /// </summary>
    [Designer("System.ServiceProcess.Design.ServiceControllerDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [ServiceProcessDescription("ServiceControllerDesc")]
    public class ServiceController : Component
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ServiceProcess.ServiceController"/> class that is not associated with a specific service.
        /// </summary>
        public ServiceController();

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ServiceProcess.ServiceController"/> class that is associated with an existing service on the local computer.
        /// </summary>
        /// <param name="name">The name that identifies the service to the system. This can also be the display name for the service.</param><exception cref="T:System.ArgumentException"><paramref name="name"/> is invalid. </exception>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public ServiceController(string name);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.ServiceProcess.ServiceController"/> class that is associated with an existing service on the specified computer.
        /// </summary>
        /// <param name="name">The name that identifies the service to the system. This can also be the display name for the service.</param><param name="machineName">The computer on which the service resides. </param><exception cref="T:System.ArgumentException"><paramref name="name"/> is invalid.-or- <paramref name="machineName"/> is invalid. </exception>
        public ServiceController(string name, string machineName);

        /// <summary>
        /// Disconnects this <see cref="T:System.ServiceProcess.ServiceController"/> instance from the service and frees all the resources that the instance allocated.
        /// </summary>
        public void Close();

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.ServiceProcess.ServiceController"/> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing);

        /// <summary>
        /// Retrieves the device driver services on the local computer.
        /// </summary>
        /// 
        /// <returns>
        /// An array of type <see cref="T:System.ServiceProcess.ServiceController"/> in which each element is associated with a device driver service on the local computer.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static ServiceController[] GetDevices();

        /// <summary>
        /// Retrieves the device driver services on the specified computer.
        /// </summary>
        /// 
        /// <returns>
        /// An array of type <see cref="T:System.ServiceProcess.ServiceController"/> in which each element is associated with a device driver service on the specified computer.
        /// </returns>
        /// <param name="machineName">The computer from which to retrieve the device driver services. </param><exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.ArgumentException">The <paramref name="machineName"/> parameter has invalid syntax. </exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static ServiceController[] GetDevices(string machineName);

        /// <summary>
        /// Retrieves all the services on the local computer, except for the device driver services.
        /// </summary>
        /// 
        /// <returns>
        /// An array of type <see cref="T:System.ServiceProcess.ServiceController"/> in which each element is associated with a service on the local computer.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static ServiceController[] GetServices();

        /// <summary>
        /// Retrieves all the services on the specified computer, except for the device driver services.
        /// </summary>
        /// 
        /// <returns>
        /// An array of type <see cref="T:System.ServiceProcess.ServiceController"/> in which each element is associated with a service on the specified computer.
        /// </returns>
        /// <param name="machineName">The computer from which to retrieve the services. </param><exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.ArgumentException">The <paramref name="machineName"/> parameter has invalid syntax. </exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static ServiceController[] GetServices(string machineName);

        /// <summary>
        /// Suspends a service's operation.
        /// </summary>
        /// <exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service was not found. </exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        public void Pause();

        /// <summary>
        /// Continues a service after it has been paused.
        /// </summary>
        /// <exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service was not found. </exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        public void Continue();

        /// <summary>
        /// Executes a custom command on the service.
        /// </summary>
        /// <param name="command">An application-defined command flag that indicates which custom command to execute. The value must be between 128 and 256, inclusive.</param><exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service was not found. </exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        public void ExecuteCommand(int command);

        /// <summary>
        /// Refreshes property values by resetting the properties to their current values.
        /// </summary>
        public void Refresh();

        /// <summary>
        /// Starts the service, passing no arguments.
        /// </summary>
        /// <exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service was not found.</exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        public void Start();

        /// <summary>
        /// Starts a service, passing the specified arguments.
        /// </summary>
        /// <param name="args">An array of arguments to pass to the service when it starts. </param><exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service cannot be started. </exception><exception cref="T:System.ArgumentNullException"><paramref name="args"/> is null.-or-A member of the array is null.</exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        public void Start(string[] args);

        /// <summary>
        /// Stops this service and any services that are dependent on this service.
        /// </summary>
        /// <exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service was not found. </exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        public void Stop();

        /// <summary>
        /// Infinitely waits for the service to reach the specified status.
        /// </summary>
        /// <param name="desiredStatus">The status to wait for. </param><exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The <paramref name="desiredStatus"/> parameter is not any of the values defined in the <see cref="T:System.ServiceProcess.ServiceControllerStatus"/> enumeration. </exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        public void WaitForStatus(ServiceControllerStatus desiredStatus);

        /// <summary>
        /// Waits for the service to reach the specified status or for the specified time-out to expire.
        /// </summary>
        /// <param name="desiredStatus">The status to wait for. </param><param name="timeout">A <see cref="T:System.TimeSpan"/> object specifying the amount of time to wait for the service to reach the specified status. </param><exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The <paramref name="desiredStatus"/> parameter is not any of the values defined in the <see cref="T:System.ServiceProcess.ServiceControllerStatus"/> enumeration. </exception><exception cref="T:System.ServiceProcess.TimeoutException">The value specified for the <paramref name="timeout"/> parameter expires. </exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        public void WaitForStatus(ServiceControllerStatus desiredStatus, TimeSpan timeout);

        /// <summary>
        /// Gets a value indicating whether the service can be paused and resumed.
        /// </summary>
        /// 
        /// <returns>
        /// true if the service can be paused; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service was not found.</exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        [ServiceProcessDescription("SPCanPauseAndContinue")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CanPauseAndContinue { get; }

        /// <summary>
        /// Gets a value indicating whether the service should be notified when the system is shutting down.
        /// </summary>
        /// 
        /// <returns>
        /// true if the service should be notified when the system is shutting down; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service was not found.</exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        [ServiceProcessDescription("SPCanShutdown")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CanShutdown { get; }

        /// <summary>
        /// Gets a value indicating whether the service can be stopped after it has started.
        /// </summary>
        /// 
        /// <returns>
        /// true if the service can be stopped and the <see cref="M:System.ServiceProcess.ServiceBase.OnStop"/> method called; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service was not found.</exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [ServiceProcessDescription("SPCanStop")]
        public bool CanStop { get; }

        /// <summary>
        /// Gets or sets a friendly name for the service.
        /// </summary>
        /// 
        /// <returns>
        /// The friendly name of the service, which can be used to identify the service.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.ServiceProcess.ServiceController.DisplayName"/> is null. </exception><exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service was not found.</exception><PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/></PermissionSet>
        [ReadOnly(true)]
        [ServiceProcessDescription("SPDisplayName")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets the set of services that depends on the service associated with this <see cref="T:System.ServiceProcess.ServiceController"/> instance.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.ServiceProcess.ServiceController"/> instances, each of which is associated with a service that depends on this service.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service was not found.</exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [ServiceProcessDescription("SPDependentServices")]
        public ServiceController[] DependentServices { get; }

        /// <summary>
        /// Gets or sets the name of the computer on which this service resides.
        /// </summary>
        /// 
        /// <returns>
        /// The name of the computer that is running the service associated with this <see cref="T:System.ServiceProcess.ServiceController"/> instance. The default is the local computer (".").
        /// </returns>
        /// <exception cref="T:System.ArgumentException">The <see cref="P:System.ServiceProcess.ServiceController.MachineName"/> syntax is invalid. </exception>
        [ServiceProcessDescription("SPMachineName")]
        [SettingsBindable(true)]
        [Browsable(false)]
        [DefaultValue(".")]
        public string MachineName { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; set; }

        /// <summary>
        /// Gets or sets the name that identifies the service that this instance references.
        /// </summary>
        /// 
        /// <returns>
        /// The name that identifies the service that this <see cref="T:System.ServiceProcess.ServiceController"/> instance references. The default is an empty string ("").
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The <see cref="P:System.ServiceProcess.ServiceController.ServiceName"/> is null. </exception><exception cref="T:System.ArgumentException">The syntax of the <see cref="P:System.ServiceProcess.ServiceController.ServiceName"/> property is invalid. </exception><exception cref="T:System.InvalidOperationException">The service was not found.</exception><PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/></PermissionSet>
        [DefaultValue("")]
        [ServiceProcessDescription("SPServiceName")]
        [SettingsBindable(true)]
        [TypeConverter(typeof (ServiceNameConverter))]
        [ReadOnly(true)]
        public string ServiceName { get; set; }

        /// <summary>
        /// The set of services that this service depends on.
        /// </summary>
        /// 
        /// <returns>
        /// An array of <see cref="T:System.ServiceProcess.ServiceController"/> instances, each of which is associated with a service that must be running for this service to run.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service was not found.</exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [ServiceProcessDescription("SPServicesDependedOn")]
        public ServiceController[] ServicesDependedOn { get; }

        /// <summary>
        /// Gets the handle for the service.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Runtime.InteropServices.SafeHandle"/> that contains the handle for the service.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The service was not found.</exception>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SafeHandle ServiceHandle { get; }

        /// <summary>
        /// Gets the status of the service that is referenced by this instance.
        /// </summary>
        /// 
        /// <returns>
        /// One of the <see cref="T:System.ServiceProcess.ServiceControllerStatus"/> values that indicates whether the service is running, stopped, or paused, or whether a start, stop, pause, or continue command is pending.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service was not found.</exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [ServiceProcessDescription("SPStatus")]
        public ServiceControllerStatus Status { get; }

        /// <summary>
        /// Gets the type of service that this object references.
        /// </summary>
        /// 
        /// <returns>
        /// One of the <see cref="T:System.ServiceProcess.ServiceType"/> values, used to indicate the network service type.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Win32Exception">An error occurred when accessing a system API. </exception><exception cref="T:System.InvalidOperationException">The service was not found.</exception><PermissionSet><IPermission class="System.ServiceProcess.ServiceControllerPermission, System.ServiceProcess, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" version="1" Unrestricted="true"/></PermissionSet>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [ServiceProcessDescription("SPServiceType")]
        public ServiceType ServiceType { get; }
    }
}
