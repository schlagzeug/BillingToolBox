// Type: System.Data.SqlClient.SqlDataReader
// Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Data.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace System.Data.SqlClient
{
    /// <summary>
    /// Provides a way of reading a forward-only stream of rows from a SQL Server database. This class cannot be inherited.
    /// </summary>
    /// <filterpriority>1</filterpriority>
    public class SqlDataReader : DbDataReader, IDataReader, IDisposable, IDataRecord
    {
        /// <summary>
        /// Closes the <see cref="T:System.Data.SqlClient.SqlDataReader"/> object.
        /// </summary>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override void Close();

        /// <summary>
        /// Gets a string representing the data type of the specified column.
        /// </summary>
        /// 
        /// <returns>
        /// The string representing the data type of the specified column.
        /// </returns>
        /// <param name="i">The zero-based ordinal position of the column to find.</param><filterpriority>2</filterpriority>
        public override string GetDataTypeName(int i);

        /// <summary>
        /// Returns an <see cref="T:System.Collections.IEnumerator"/> that iterates through the <see cref="T:System.Data.SqlClient.SqlDataReader"/>.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> for the <see cref="T:System.Data.SqlClient.SqlDataReader"/>.
        /// </returns>
        public override IEnumerator GetEnumerator();

        /// <summary>
        /// Gets the <see cref="T:System.Type"/> that is the data type of the object.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Type"/> that is the data type of the object. If the type does not exist on the client, in the case of a User-Defined Type (UDT) returned from the database, GetFieldType returns null.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority>
        public override Type GetFieldType(int i);

        /// <summary>
        /// Gets the name of the specified column.
        /// </summary>
        /// 
        /// <returns>
        /// The name of the specified column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/></PermissionSet>
        public override string GetName(int i);

        /// <summary>
        /// Gets an Object that is a representation of the underlying provider-specific field type.
        /// </summary>
        /// 
        /// <returns>
        /// Gets an <see cref="T:System.Object"/> that is a representation of the underlying provider-specific field type.
        /// </returns>
        /// <param name="i">An <see cref="T:System.Int32"/> representing the column ordinal. </param><filterpriority>1</filterpriority>
        public override Type GetProviderSpecificFieldType(int i);

        /// <summary>
        /// Gets the column ordinal, given the name of the column.
        /// </summary>
        /// 
        /// <returns>
        /// The zero-based column ordinal.
        /// </returns>
        /// <param name="name">The name of the column. </param><exception cref="T:System.IndexOutOfRangeException">The name specified is not a valid column name. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/></PermissionSet>
        public override int GetOrdinal(string name);

        /// <summary>
        /// Gets an Object that is a representation of the underlying provider specific value.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Object"/> that is a representation of the underlying provider specific value.
        /// </returns>
        /// <param name="i">An <see cref="T:System.Int32"/> representing the column ordinal. </param><filterpriority>2</filterpriority>
        public override object GetProviderSpecificValue(int i);

        /// <summary>
        /// Gets an array of objects that are a representation of the underlying provider specific values.
        /// </summary>
        /// 
        /// <returns>
        /// The array of objects that are a representation of the underlying provider specific values.
        /// </returns>
        /// <param name="values">An array of <see cref="T:System.Object"/> into which to copy the column values.</param><filterpriority>2</filterpriority>
        public override int GetProviderSpecificValues(object[] values);

        /// <summary>
        /// Returns a <see cref="T:System.Data.DataTable"/> that describes the column metadata of the <see cref="T:System.Data.SqlClient.SqlDataReader"/>.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Data.DataTable"/> that describes the column metadata.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Data.SqlClient.SqlDataReader"/> is closed. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence, ControlPolicy, ControlAppDomain"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Data.SqlClient.SqlClientPermission, System.Data, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override DataTable GetSchemaTable();

        /// <summary>
        /// Gets the value of the specified column as a Boolean.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override bool GetBoolean(int i);

        /// <summary>
        /// Retrieves data of type XML as an <see cref="T:System.Xml.XmlReader"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The returned object.
        /// </returns>
        /// <param name="i">The value of the specified column.</param><exception cref="T:System.InvalidOperationException">The connection drops or is closed during the data retrieval.The <see cref="T:System.Data.SqlClient.SqlDataReader"/> is closed during the data retrieval.There is no data ready to be read (for example, the first <see cref="M:System.Data.SqlClient.SqlDataReader.Read"/> hasn't been called, or returned false).Trying to read a previously read column in sequential mode.There was an asynchronous operation in progress. This applies to all Get* methods when running in sequential mode, as they could be called while reading a stream.</exception><exception cref="T:System.IndexOutOfRangeException">Trying to read a column that does not exist.</exception><exception cref="T:System.InvalidCastException">The returned type was not xml.</exception>
        public virtual XmlReader GetXmlReader(int i);

        /// <summary>
        /// Retrieves binary, image, varbinary, UDT, and variant data types as a <see cref="T:System.IO.Stream"/>.
        /// </summary>
        /// 
        /// <returns>
        /// A stream object.
        /// </returns>
        /// <param name="i">The zero-based column ordinal.</param><exception cref="T:System.InvalidOperationException">The connection drops or is closed during the data retrieval.The <see cref="T:System.Data.SqlClient.SqlDataReader"/> is closed during the data retrieval.There is no data ready to be read (for example, the first <see cref="M:System.Data.SqlClient.SqlDataReader.Read"/> hasn't been called, or returned false).Tried to read a previously-read column in sequential mode.There was an asynchronous operation in progress. This applies to all Get* methods when running in sequential mode, as they could be called while reading a stream.</exception><exception cref="T:System.IndexOutOfRangeException">Trying to read a column that does not exist.</exception><exception cref="T:System.InvalidCastException">The returned type was not one of the types below:binaryimagevarbinaryudt</exception>
        public override Stream GetStream(int i);

        /// <summary>
        /// Gets the value of the specified column as a byte.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column as a byte.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override byte GetByte(int i);

        /// <summary>
        /// Reads a stream of bytes from the specified column offset into the buffer an array starting at the given buffer offset.
        /// </summary>
        /// 
        /// <returns>
        /// The actual number of bytes read.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><param name="dataIndex">The index within the field from which to begin the read operation.</param><param name="buffer">The buffer into which to read the stream of bytes. </param><param name="bufferIndex">The index within the <paramref name="buffer"/> where the write operation is to start. </param><param name="length">The maximum length to copy into the buffer. </param><filterpriority>1</filterpriority>
        public override long GetBytes(int i, long dataIndex, byte[] buffer, int bufferIndex, int length);

        /// <summary>
        /// Retrieves Char, NChar, NText, NVarChar, text, varChar, and Variant data types as a <see cref="T:System.IO.TextReader"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The returned object.
        /// </returns>
        /// <param name="i">The column to be retrieved.</param><exception cref="T:System.InvalidOperationException">The connection drops or is closed during the data retrieval.The <see cref="T:System.Data.SqlClient.SqlDataReader"/> is closed during the data retrieval.There is no data ready to be read (for example, the first <see cref="M:System.Data.SqlClient.SqlDataReader.Read"/> hasn't been called, or returned false).Tried to read a previously-read column in sequential mode.There was an asynchronous operation in progress. This applies to all Get* methods when running in sequential mode, as they could be called while reading a stream.</exception><exception cref="T:System.IndexOutOfRangeException">Trying to read a column that does not exist.</exception><exception cref="T:System.InvalidCastException">The returned type was not one of the types below:charncharntextnvarchartextvarchar</exception>
        public override TextReader GetTextReader(int i);

        /// <summary>
        /// Gets the value of the specified column as a single character.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/></PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override char GetChar(int i);

        /// <summary>
        /// Reads a stream of characters from the specified column offset into the buffer as an array starting at the given buffer offset.
        /// </summary>
        /// 
        /// <returns>
        /// The actual number of characters read.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><param name="dataIndex">The index within the field from which to begin the read operation.</param><param name="buffer">The buffer into which to read the stream of bytes. </param><param name="bufferIndex">The index within the <paramref name="buffer"/> where the write operation is to start. </param><param name="length">The maximum length to copy into the buffer. </param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override long GetChars(int i, long dataIndex, char[] buffer, int bufferIndex, int length);

        /// <summary>
        /// Returns an <see cref="T:System.Data.IDataReader"/> for the specified column ordinal.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Data.IDataReader"/> instance for the specified column ordinal.
        /// </returns>
        /// <param name="i">A column ordinal.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        IDataReader IDataRecord.GetData(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.DateTime"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override DateTime GetDateTime(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Decimal"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override decimal GetDecimal(int i);

        /// <summary>
        /// Gets the value of the specified column as a double-precision floating point number.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override double GetDouble(int i);

        /// <summary>
        /// Gets the value of the specified column as a single-precision floating point number.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override float GetFloat(int i);

        /// <summary>
        /// Gets the value of the specified column as a globally unique identifier (GUID).
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception><filterpriority>1</filterpriority>
        public override Guid GetGuid(int i);

        /// <summary>
        /// Gets the value of the specified column as a 16-bit signed integer.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override short GetInt16(int i);

        /// <summary>
        /// Gets the value of the specified column as a 32-bit signed integer.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception><filterpriority>1</filterpriority>
        public override int GetInt32(int i);

        /// <summary>
        /// Gets the value of the specified column as a 64-bit signed integer.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override long GetInt64(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Data.SqlTypes.SqlBoolean"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual SqlBoolean GetSqlBoolean(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Data.SqlTypes.SqlBinary"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a <see cref="T:System.Data.SqlTypes.SqlBinary"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority>
        public virtual SqlBinary GetSqlBinary(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Data.SqlTypes.SqlByte"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a  <see cref="T:System.Data.SqlTypes.SqlByte"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual SqlByte GetSqlByte(int i);

        /// <summary>
        /// Gets the value of the specified column as <see cref="T:System.Data.SqlTypes.SqlBytes"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a <see cref="T:System.Data.SqlTypes.SqlBytes"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority>
        public virtual SqlBytes GetSqlBytes(int i);

        /// <summary>
        /// Gets the value of the specified column as <see cref="T:System.Data.SqlTypes.SqlChars"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a  <see cref="T:System.Data.SqlTypes.SqlChars"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual SqlChars GetSqlChars(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Data.SqlTypes.SqlDateTime"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a  <see cref="T:System.Data.SqlTypes.SqlDateTime"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual SqlDateTime GetSqlDateTime(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Data.SqlTypes.SqlDecimal"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a <see cref="T:System.Data.SqlTypes.SqlDecimal"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual SqlDecimal GetSqlDecimal(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Data.SqlTypes.SqlGuid"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a  <see cref="T:System.Data.SqlTypes.SqlGuid"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority>
        public virtual SqlGuid GetSqlGuid(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Data.SqlTypes.SqlDouble"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a  <see cref="T:System.Data.SqlTypes.SqlDouble"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual SqlDouble GetSqlDouble(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Data.SqlTypes.SqlInt16"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a <see cref="T:System.Data.SqlTypes.SqlInt16"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual SqlInt16 GetSqlInt16(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Data.SqlTypes.SqlInt32"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a <see cref="T:System.Data.SqlTypes.SqlInt32"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual SqlInt32 GetSqlInt32(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Data.SqlTypes.SqlInt64"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a <see cref="T:System.Data.SqlTypes.SqlInt64"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual SqlInt64 GetSqlInt64(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Data.SqlTypes.SqlMoney"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a <see cref="T:System.Data.SqlTypes.SqlMoney"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual SqlMoney GetSqlMoney(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Data.SqlTypes.SqlSingle"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a <see cref="T:System.Data.SqlTypes.SqlSingle"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual SqlSingle GetSqlSingle(int i);

        /// <summary>
        /// Gets the value of the specified column as a <see cref="T:System.Data.SqlTypes.SqlString"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a <see cref="T:System.Data.SqlTypes.SqlString"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public virtual SqlString GetSqlString(int i);

        /// <summary>
        /// Gets the value of the specified column as an XML value.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Data.SqlTypes.SqlXml"/> value that contains the XML stored within the corresponding field.
        /// </returns>
        /// <param name="i">The zero-based column ordinal.</param><exception cref="T:System.ArgumentOutOfRangeException">The index passed was outside the range of 0 to <see cref="P:System.Data.DataTableReader.FieldCount"/> - 1</exception><exception cref="T:System.InvalidOperationException">An attempt was made to read or access columns in a closed <see cref="T:System.Data.SqlClient.SqlDataReader"/>.</exception><exception cref="T:System.InvalidCastException">The retrieved data is not compatible with the <see cref="T:System.Data.SqlTypes.SqlXml"/> type.</exception><filterpriority>1</filterpriority>
        public virtual SqlXml GetSqlXml(int i);

        /// <summary>
        /// Returns the data value in the specified column as a SQL Server type.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the column expressed as a <see cref="T:System.Data.SqlDbType"/>.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>2</filterpriority>
        public virtual object GetSqlValue(int i);

        /// <summary>
        /// Fills an array of <see cref="T:System.Object"/> that contains the values for all the columns in the record, expressed as SQL Server types.
        /// </summary>
        /// 
        /// <returns>
        /// An integer indicating the number of columns copied.
        /// </returns>
        /// <param name="values">An array of <see cref="T:System.Object"/> into which to copy the values. The column values are expressed as SQL Server types.</param><exception cref="T:System.ArgumentNullException"><paramref name="values"/> is null. </exception><filterpriority>2</filterpriority>
        public virtual int GetSqlValues(object[] values);

        /// <summary>
        /// Gets the value of the specified column as a string.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override string GetString(int i);

        /// <summary>
        /// Synchronously gets the value of the specified column as a type. <see cref="M:System.Data.SqlClient.SqlDataReader.GetFieldValueAsync``1(System.Int32,System.Threading.CancellationToken)"/> is the asynchronous version of this method.
        /// </summary>
        /// 
        /// <returns>
        /// The returned type object.
        /// </returns>
        /// <param name="i">The column to be retrieved.</param><typeparam name="T">The type of the value to be returned. See the remarks section for more information.</typeparam><exception cref="T:System.InvalidOperationException">The connection drops or is closed during the data retrieval.The <see cref="T:System.Data.SqlClient.SqlDataReader"/> is closed during the data retrieval.There is no data ready to be read (for example, the first <see cref="M:System.Data.SqlClient.SqlDataReader.Read"/> hasn't been called, or returned false).Tried to read a previously-read column in sequential mode.There was an asynchronous operation in progress. This applies to all Get* methods when running in sequential mode, as they could be called while reading a stream.</exception><exception cref="T:System.IndexOutOfRangeException">Trying to read a column that does not exist.</exception><exception cref="T:System.Data.SqlTypes.SqlNullValueException">The value of the column was null (<see cref="M:System.Data.SqlClient.SqlDataReader.IsDBNull(System.Int32)"/> == true), retrieving a non-SQL type.</exception><exception cref="T:System.InvalidCastException"><paramref name="T"/> doesn’t match the type returned by SQL Server or cannot be cast.</exception>
        public override T GetFieldValue<T>(int i);

        /// <summary>
        /// Gets the value of the specified column in its native format.
        /// </summary>
        /// 
        /// <returns>
        /// This method returns <see cref="T:System.DBNull"/> for null database columns.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>1</filterpriority>
        public override object GetValue(int i);

        /// <summary>
        /// Retrieves the value of the specified column as a <see cref="T:System.TimeSpan"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception>
        public virtual TimeSpan GetTimeSpan(int i);

        /// <summary>
        /// Retrieves the value of the specified column as a <see cref="T:System.DateTimeOffset"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.InvalidCastException">The specified cast is not valid. </exception>
        public virtual DateTimeOffset GetDateTimeOffset(int i);

        /// <summary>
        /// Populates an array of objects with the column values of the current row.
        /// </summary>
        /// 
        /// <returns>
        /// The number of instances of <see cref="T:System.Object"/> in the array.
        /// </returns>
        /// <param name="values">An array of <see cref="T:System.Object"/> into which to copy the attribute columns. </param><filterpriority>1</filterpriority>
        public override int GetValues(object[] values);

        /// <summary>
        /// Gets a value that indicates whether the column contains non-existent or missing values.
        /// </summary>
        /// 
        /// <returns>
        /// true if the specified column value is equivalent to <see cref="T:System.DBNull"/>; otherwise false.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override bool IsDBNull(int i);

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Data.CommandBehavior"/> matches that of the <see cref="T:System.Data.SqlClient.SqlDataReader"/> .
        /// </summary>
        /// 
        /// <returns>
        /// true if the specified <see cref="T:System.Data.CommandBehavior"/> is true, false otherwise.
        /// </returns>
        /// <param name="condition">A <see cref="T:System.Data.CommandBehavior"/> enumeration.</param>
        protected internal bool IsCommandBehavior(CommandBehavior condition);

        /// <summary>
        /// Advances the data reader to the next result, when reading the results of batch Transact-SQL statements.
        /// </summary>
        /// 
        /// <returns>
        /// true if there are more result sets; otherwise false.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.ReflectionPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="MemberAccess"/><IPermission class="System.Security.Permissions.RegistryPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence, ControlPolicy, ControlAppDomain"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Data.SqlClient.SqlClientPermission, System.Data, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override bool NextResult();

        /// <summary>
        /// Advances the <see cref="T:System.Data.SqlClient.SqlDataReader"/> to the next record.
        /// </summary>
        /// 
        /// <returns>
        /// true if there are more rows; otherwise false.
        /// </returns>
        /// <exception cref="T:System.Data.SqlClient.SqlException">SQL Server returned an error while executing the command text.</exception><filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/></PermissionSet>
        public override bool Read();

        /// <summary>
        /// An asynchronous version of <see cref="M:System.Data.SqlClient.SqlDataReader.NextResult"/>, which advances the data reader to the next result, when reading the results of batch Transact-SQL statements.The cancellation token can be used to request that the operation be abandoned before the command timeout elapses.  Exceptions will be reported via the returned Task object.
        /// </summary>
        /// 
        /// <returns>
        /// A task representing the asynchronous operation.
        /// </returns>
        /// <param name="cancellationToken">The cancellation instruction.</param><exception cref="T:System.InvalidOperationException">Calling <see cref="M:System.Data.SqlClient.SqlDataReader.NextResultAsync(System.Threading.CancellationToken)"/> more than once for the same instance before task completion.Context Connection=true is specified in the connection string.</exception><exception cref="T:System.Data.SqlClient.SqlException">SQL Server returned an error while executing the command text.</exception>
        public override Task<bool> NextResultAsync(CancellationToken cancellationToken);

        /// <summary>
        /// An asynchronous version of <see cref="M:System.Data.SqlClient.SqlDataReader.Read"/>, which advances the <see cref="T:System.Data.SqlClient.SqlDataReader"/> to the next record.The cancellation token can be used to request that the operation be abandoned before the command timeout elapses. Exceptions will be reported via the returned Task object.
        /// </summary>
        /// 
        /// <returns>
        /// A task representing the asynchronous operation.
        /// </returns>
        /// <param name="cancellationToken">The cancellation instruction.</param><exception cref="T:System.InvalidOperationException">Calling <see cref="M:System.Data.SqlClient.SqlDataReader.ReadAsync(System.Threading.CancellationToken)"/> more than once for the same instance before task completion.Context Connection=true is specified in the connection string.</exception><exception cref="T:System.Data.SqlClient.SqlException">SQL Server returned an error while executing the command text.</exception>
        public override Task<bool> ReadAsync(CancellationToken cancellationToken);

        /// <summary>
        /// An asynchronous version of <see cref="M:System.Data.SqlClient.SqlDataReader.IsDBNull(System.Int32)"/>, which gets a value that indicates whether the column contains non-existent or missing values.The cancellation token can be used to request that the operation be abandoned before the command timeout elapses. Exceptions will be reported via the returned Task object.
        /// </summary>
        /// 
        /// <returns>
        /// true if the specified column value is equivalent to DBNull otherwise false.
        /// </returns>
        /// <param name="i">The zero-based column to be retrieved.</param><param name="cancellationToken">The cancellation instruction, which propagates a notification that operations should be canceled. This does not guarantee the cancellation. A setting of CancellationToken.None makes this method equivalent to <see cref="M:System.Data.SqlClient.SqlDataReader.IsDBNull(System.Int32)"/>. The returned task must be marked as cancelled.</param><exception cref="T:System.InvalidOperationException">The connection drops or is closed during the data retrieval.The <see cref="T:System.Data.SqlClient.SqlDataReader"/> is closed during the data retrieval.There is no data ready to be read (for example, the first <see cref="M:System.Data.SqlClient.SqlDataReader.Read"/> hasn't been called, or returned false).Trying to read a previously read column in sequential mode.There was an asynchronous operation in progress. This applies to all Get* methods when running in sequential mode, as they could be called while reading a stream.Context Connection=true is specified in the connection string.</exception><exception cref="T:System.IndexOutOfRangeException">Trying to read a column that does not exist.</exception>
        public override Task<bool> IsDBNullAsync(int i, CancellationToken cancellationToken);

        /// <summary>
        /// Asynchronously gets the value of the specified column as a type. <see cref="M:System.Data.SqlClient.SqlDataReader.GetFieldValue``1(System.Int32)"/> is the synchronous version of this method.
        /// </summary>
        /// 
        /// <returns>
        /// The returned type object.
        /// </returns>
        /// <param name="i">The column to be retrieved.</param><param name="cancellationToken">The cancellation instruction, which propagates a notification that operations should be canceled. This does not guarantee the cancellation. A setting of CancellationToken.None makes this method equivalent to <see cref="M:System.Data.SqlClient.SqlDataReader.IsDBNull(System.Int32)"/>. The returned task must be marked as cancelled.</param><typeparam name="T">The type of the value to be returned. See the remarks section for more information.</typeparam><exception cref="T:System.InvalidOperationException">The connection drops or is closed during the data retrieval.The <see cref="T:System.Data.SqlClient.SqlDataReader"/> is closed during the data retrieval.There is no data ready to be read (for example, the first <see cref="M:System.Data.SqlClient.SqlDataReader.Read"/> hasn't been called, or returned false).Tried to read a previously-read column in sequential mode.There was an asynchronous operation in progress. This applies to all Get* methods when running in sequential mode, as they could be called while reading a stream.Context Connection=true is specified in the connection string.</exception><exception cref="T:System.IndexOutOfRangeException">Trying to read a column that does not exist.</exception><exception cref="T:System.Data.SqlTypes.SqlNullValueException">The value of the column was null (<see cref="M:System.Data.SqlClient.SqlDataReader.IsDBNull(System.Int32)"/> == true), retrieving a non-SQL type.</exception><exception cref="T:System.InvalidCastException"><paramref name="T"/> doesn’t match the type returned by SQL Server or cannot be cast.</exception>
        public override Task<T> GetFieldValueAsync<T>(int i, CancellationToken cancellationToken);

        /// <summary>
        /// Gets the <see cref="T:System.Data.SqlClient.SqlConnection"/> associated with the <see cref="T:System.Data.SqlClient.SqlDataReader"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Data.SqlClient.SqlConnection"/> associated with the <see cref="T:System.Data.SqlClient.SqlDataReader"/>.
        /// </returns>
        protected SqlConnection Connection { get; }

        /// <summary>
        /// Gets a value that indicates the depth of nesting for the current row.
        /// </summary>
        /// 
        /// <returns>
        /// The depth of nesting for the current row.
        /// </returns>
        /// <filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/></PermissionSet>
        public override int Depth { get; }

        /// <summary>
        /// Gets the number of columns in the current row.
        /// </summary>
        /// 
        /// <returns>
        /// When not positioned in a valid recordset, 0; otherwise the number of columns in the current row. The default is -1.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">There is no current connection to an instance of SQL Server. </exception><filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/></PermissionSet>
        public override int FieldCount { get; }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="T:System.Data.SqlClient.SqlDataReader"/> contains one or more rows.
        /// </summary>
        /// 
        /// <returns>
        /// true if the <see cref="T:System.Data.SqlClient.SqlDataReader"/> contains one or more rows; otherwise false.
        /// </returns>
        /// <filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/></PermissionSet>
        public override bool HasRows { get; }

        /// <summary>
        /// Retrieves a Boolean value that indicates whether the specified <see cref="T:System.Data.SqlClient.SqlDataReader"/> instance has been closed.
        /// </summary>
        /// 
        /// <returns>
        /// true if the specified <see cref="T:System.Data.SqlClient.SqlDataReader"/> instance is closed; otherwise false.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public override bool IsClosed { get; }

        /// <summary>
        /// Gets the number of rows changed, inserted, or deleted by execution of the Transact-SQL statement.
        /// </summary>
        /// 
        /// <returns>
        /// The number of rows changed, inserted, or deleted; 0 if no rows were affected or the statement failed; and -1 for SELECT statements.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public override int RecordsAffected { get; }

        /// <summary>
        /// Gets the number of fields in the <see cref="T:System.Data.SqlClient.SqlDataReader"/> that are not hidden.
        /// </summary>
        /// 
        /// <returns>
        /// The number of fields that are not hidden.
        /// </returns>
        /// <filterpriority>2</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*"/></PermissionSet>
        public override int VisibleFieldCount { get; }

        /// <summary>
        /// Gets the value of the specified column in its native format given the column ordinal.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column in its native format.
        /// </returns>
        /// <param name="i">The zero-based column ordinal. </param><exception cref="T:System.IndexOutOfRangeException">The index passed was outside the range of 0 through <see cref="P:System.Data.IDataRecord.FieldCount"/>. </exception><filterpriority>1</filterpriority>
        public override object this[int i] { get; }

        /// <summary>
        /// Gets the value of the specified column in its native format given the column name.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the specified column in its native format.
        /// </returns>
        /// <param name="name">The column name. </param><exception cref="T:System.IndexOutOfRangeException">No column with the specified name was found. </exception><filterpriority>1</filterpriority>
        public override object this[string name] { get; }
    }
}
