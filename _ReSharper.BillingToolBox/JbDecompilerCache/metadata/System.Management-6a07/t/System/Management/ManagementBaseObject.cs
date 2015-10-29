// Type: System.Management.ManagementBaseObject
// Assembly: System.Management, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Management.dll

using System;
using System.ComponentModel;
using System.Runtime;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace System.Management
{
    /// <summary>
    /// Contains the basic elements of a management object. It serves as a base class to more specific management object classes.
    /// </summary>
    [ToolboxItem(false)]
    [Serializable]
    public class ManagementBaseObject : Component, ICloneable, ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Management.ManagementBaseObject"/> class that is serializable.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data.</param><param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/> ) for this serialization.</param>
        protected ManagementBaseObject(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// Provides the internal WMI object represented by a <see cref="T:System.Management.ManagementObject"/>.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.IntPtr"/> representing the internal WMI object.
        /// </returns>
        /// <param name="managementObject">The <see cref="T:System.Management.ManagementBaseObject"/> that references the requested WMI object.</param><PermissionSet><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public static explicit operator IntPtr(ManagementBaseObject managementObject);

        public new void Dispose();

        /// <summary>
        /// Implements the <see cref="T:System.Runtime.Serialization.ISerializable"/> interface and returns the data needed to serialize the <see cref="T:System.Management.ManagementBaseObject"/>.
        /// </summary>
        /// <param name="info">A <see cref="T:System.Runtime.Serialization.SerializationInfo"/> containing the information required to serialize the <see cref="T:System.Management.ManagementBaseObject"/>.</param><param name="context">A <see cref="T:System.Runtime.Serialization.StreamingContext"/> containing the source and destination of the serialized stream associated with the <see cref="T:System.Management.ManagementBaseObject"/>.</param><exception cref="T:System.ArgumentNullException"><paramref name="info"/> is null.</exception>
        [SecurityPermission(SecurityAction.LinkDemand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/> with the data necessary to deserialize the field represented by this instance.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data.</param><param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/> ) for this serialization.</param>
        protected virtual void GetObjectData(SerializationInfo info, StreamingContext context);

        /// <summary>
        /// Returns a copy of the object.
        /// </summary>
        /// 
        /// <returns>
        /// The new cloned object.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public virtual object Clone();

        /// <summary>
        /// Gets an equivalent accessor to a property's value.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified property.
        /// </returns>
        /// <param name="propertyName">The name of the property of interest. </param><PermissionSet><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public object GetPropertyValue(string propertyName);

        /// <summary>
        /// Gets the value of the specified qualifier.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified qualifier.
        /// </returns>
        /// <param name="qualifierName">The name of the qualifier of interest. </param><PermissionSet><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public object GetQualifierValue(string qualifierName);

        /// <summary>
        /// Sets the value of the named qualifier.
        /// </summary>
        /// <param name="qualifierName">The name of the qualifier to set. This parameter cannot be null.</param><param name="qualifierValue">The value to set.</param><PermissionSet><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public void SetQualifierValue(string qualifierName, object qualifierValue);

        /// <summary>
        /// Returns the value of the specified property qualifier.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified qualifier.
        /// </returns>
        /// <param name="propertyName">The name of the property to which the qualifier belongs. </param><param name="qualifierName">The name of the property qualifier of interest. </param><PermissionSet><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public object GetPropertyQualifierValue(string propertyName, string qualifierName);

        /// <summary>
        /// Sets the value of the specified property qualifier.
        /// </summary>
        /// <param name="propertyName">The name of the property to which the qualifier belongs.</param><param name="qualifierName">The name of the property qualifier of interest.</param><param name="qualifierValue">The new value for the qualifier.</param><PermissionSet><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public void SetPropertyQualifierValue(string propertyName, string qualifierName, object qualifierValue);

        /// <summary>
        /// Returns a textual representation of the object in the specified format.
        /// </summary>
        /// 
        /// <returns>
        /// The textual representation of the object in the specified format.
        /// </returns>
        /// <param name="format">The requested textual format. </param><PermissionSet><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public string GetText(TextFormat format);

        /// <summary>
        /// Compares two management objects.
        /// </summary>
        /// 
        /// <returns>
        /// true if this is an instance of <see cref="T:System.Management.ManagementBaseObject"/> and represents the same object as this instance; otherwise, false.
        /// </returns>
        /// <param name="obj">An object to compare with this instance.</param><PermissionSet><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public override bool Equals(object obj);

        /// <summary>
        /// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// 
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public override int GetHashCode();

        /// <summary>
        /// Compares this object to another, based on specified options.
        /// </summary>
        /// 
        /// <returns>
        /// true if the objects compared are equal according to the given options; otherwise, false.
        /// </returns>
        /// <param name="otherObject">The object to which to compare this object. </param><param name="settings">Options on how to compare the objects. </param><PermissionSet><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public bool CompareTo(ManagementBaseObject otherObject, ComparisonSettings settings);

        /// <summary>
        /// Sets the value of the named property.
        /// </summary>
        /// <param name="propertyName">The name of the property to be changed.</param><param name="propertyValue">The new value for this property.</param><PermissionSet><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public void SetPropertyValue(string propertyName, object propertyValue);

        /// <summary>
        /// Gets a collection of <see cref="T:System.Management.PropertyData"/> objects describing the properties of the management object.
        /// </summary>
        /// 
        /// <returns>
        /// Returns a <see cref="T:System.Management.PropertyDataCollection"/> that holds the properties for the management object.
        /// </returns>
        public virtual PropertyDataCollection Properties { get; }

        /// <summary>
        /// Gets  the collection of WMI system properties of the management object (for example, the class name, server, and namespace). WMI system property names begin with "__".
        /// </summary>
        /// 
        /// <returns>
        /// Returns a <see cref="T:System.Management.PropertyDataCollection"/> that contains the system properties for a management object.
        /// </returns>
        public virtual PropertyDataCollection SystemProperties { get; }

        /// <summary>
        /// Gets the collection of <see cref="T:System.Management.QualifierData"/> objects defined on the management object. Each element in the collection holds information such as the qualifier name, value, and flavor.
        /// </summary>
        /// 
        /// <returns>
        /// Returns a <see cref="T:System.Management.QualifierDataCollection"/> that holds the qualifiers for the management object.
        /// </returns>
        public virtual QualifierDataCollection Qualifiers { get; }

        /// <summary>
        /// Gets the path to the management object's class.
        /// </summary>
        /// 
        /// <returns>
        /// Returns a <see cref="T:System.Management.ManagementPath"/> that contains the class path to the management object's class.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public virtual ManagementPath ClassPath { get; }

        /// <summary>
        /// Gets access to property values through [] notation. This property is the indexer for the <see cref="T:System.Management.ManagementBaseObject"/> class. You can use the default indexed properties defined by a type, but you cannot explicitly define your own. However, specifying the expando attribute on a class automatically provides a default indexed property whose type is Object and whose index type is String.
        /// </summary>
        /// 
        /// <returns>
        /// Returns an <see cref="T:System.Object"/> value that contains the management object for a specific class property.
        /// </returns>
        /// <param name="propertyName">The name of the property of interest. </param><PermissionSet><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public object this[string propertyName] { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; set; }
    }
}
