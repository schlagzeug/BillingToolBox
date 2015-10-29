// Type: System.Windows.Window
// Assembly: PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\WPF\PresentationFramework.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Security;
using System.Security.Permissions;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shell;

namespace System.Windows
{
    /// <summary>
    /// Provides the ability to create, configure, show, and manage the lifetime of windows and dialog boxes.
    /// </summary>
    [Localizability(LocalizationCategory.Ignore)]
    [UIPermission(SecurityAction.InheritanceDemand, Window = UIPermissionWindow.AllWindows)]
    public class Window : ContentControl, IWindowService
    {
        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.TaskbarItemInfo"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="P:System.Windows.Window.TaskbarItemInfo"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty TaskbarItemInfoProperty;

        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.AllowsTransparency"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The identifier for the <see cref="P:System.Windows.Window.AllowsTransparency"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty AllowsTransparencyProperty;

        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.Title"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The identifier for the <see cref="P:System.Windows.Window.Title"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty TitleProperty;

        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.Icon"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The identifier for the <see cref="P:System.Windows.Window.Icon"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty IconProperty;

        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.SizeToContent"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The identifier for the <see cref="P:System.Windows.Window.SizeToContent"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty SizeToContentProperty;

        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.Top"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The identifier for the <see cref="P:System.Windows.Window.Top"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty TopProperty;

        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.Left"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The identifier for the <see cref="P:System.Windows.Window.Left"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty LeftProperty;

        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.ShowInTaskbar"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The identifier for the <see cref="P:System.Windows.Window.ShowInTaskbar"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty ShowInTaskbarProperty;

        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.IsActive"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The identifier for the <see cref="P:System.Windows.Window.IsActive"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty IsActiveProperty;

        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.WindowStyle"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The identifier for the <see cref="P:System.Windows.Window.WindowStyle"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty WindowStyleProperty;

        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.WindowState"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The identifier for the <see cref="P:System.Windows.Window.WindowState"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty WindowStateProperty;

        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.ResizeMode"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The identifier for the <see cref="P:System.Windows.Window.ResizeMode"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty ResizeModeProperty;

        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.Topmost"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The identifier for the <see cref="P:System.Windows.Window.Topmost"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty TopmostProperty;

        /// <summary>
        /// Identifies the <see cref="P:System.Windows.Window.ShowActivated"/> dependency property.
        /// </summary>
        /// 
        /// <returns>
        /// The identifier for the <see cref="P:System.Windows.Window.ShowActivated"/> dependency property.
        /// </returns>
        public static readonly DependencyProperty ShowActivatedProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Windows.Window"/> class.
        /// </summary>
        [SecurityCritical]
        public Window();

        /// <summary>
        /// Opens a window and returns without waiting for the newly opened window to close.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException"><see cref="M:System.Windows.Window.Show"/> is called on a window that is closing (<see cref="E:System.Windows.Window.Closing"/>) or has been closed (<see cref="E:System.Windows.Window.Closed"/>).</exception>
        public void Show();

        /// <summary>
        /// Makes a window invisible.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException"><see cref="M:System.Windows.Window.Hide"/> is called on a window that is closing (<see cref="E:System.Windows.Window.Closing"/>) or has been closed (<see cref="E:System.Windows.Window.Closed"/>).</exception>
        public void Hide();

        /// <summary>
        /// Manually closes a <see cref="T:System.Windows.Window"/>.
        /// </summary>
        [SecurityCritical]
        public void Close();

        /// <summary>
        /// Allows a window to be dragged by a mouse with its left button down over an exposed area of the window's client area.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">The left mouse button is not down.</exception>
        [SecurityCritical]
        public void DragMove();

        /// <summary>
        /// Opens a window and returns only when the newly opened window is closed.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Nullable`1"/> value of type <see cref="T:System.Boolean"/> that specifies whether the activity was accepted (true) or canceled (false). The return value is the value of the <see cref="P:System.Windows.Window.DialogResult"/> property before a window closes.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException"><see cref="M:System.Windows.Window.ShowDialog"/> is called on a <see cref="T:System.Windows.Window"/> that is visible-or-<see cref="M:System.Windows.Window.ShowDialog"/> is called on a visible <see cref="T:System.Windows.Window"/> that was opened by calling <see cref="M:System.Windows.Window.ShowDialog"/>.</exception><exception cref="T:System.InvalidOperationException"><see cref="M:System.Windows.Window.ShowDialog"/> is called on a window that is closing (<see cref="E:System.Windows.Window.Closing"/>) or has been closed (<see cref="E:System.Windows.Window.Closed"/>).</exception>
        [SecurityCritical]
        public bool? ShowDialog();

        /// <summary>
        /// Attempts to bring the window to the foreground and activates it.
        /// </summary>
        /// 
        /// <returns>
        /// true if the <see cref="T:System.Windows.Window"/> was successfully activated; otherwise, false.
        /// </returns>
        [SecurityCritical]
        public bool Activate();

        /// <summary>
        /// Returns a reference to the <see cref="T:System.Windows.Window"/> object that hosts the content tree within which the dependency object is located.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.Window"/> reference to the host window.
        /// </returns>
        /// <param name="dependencyObject">The dependency object.</param><exception cref="T:System.ArgumentNullException"><paramref name="dependencyObject"/> is null.</exception>
        public static Window GetWindow(DependencyObject dependencyObject);

        /// <summary>
        /// Creates and returns a <see cref="T:System.Windows.Automation.Peers.WindowAutomationPeer"/> object for this <see cref="T:System.Windows.Window"/>.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.Automation.Peers.WindowAutomationPeer"/> object for this <see cref="T:System.Windows.Window"/>.
        /// </returns>
        protected override AutomationPeer OnCreateAutomationPeer();

        /// <summary>
        /// Called when the parent of the window is changed.
        /// </summary>
        /// <param name="oldParent">The previous parent. Set to null if the <see cref="T:System.Windows.DependencyObject"/> did not have a previous parent.</param>
        protected internal override sealed void OnVisualParentChanged(DependencyObject oldParent);

        /// <summary>
        /// Override this method to measure the size of a window.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.Size"/> that reflects the size that this window determines it needs during layout, based on its calculations of children's sizes.
        /// </returns>
        /// <param name="availableSize">A <see cref="T:System.Windows.Size"/> that reflects the available size that this window can give to the child. Infinity can be given as a value to indicate that the window will size to whatever content is available.</param>
        protected override Size MeasureOverride(Size availableSize);

        /// <summary>
        /// Override this method to arrange and size a window and its child elements.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.Size"/> that reflects the actual size that was used.
        /// </returns>
        /// <param name="arrangeBounds">A <see cref="T:System.Windows.Size"/> that reflects the final size that the window should use to arrange itself and its children.</param>
        protected override Size ArrangeOverride(Size arrangeBounds);

        /// <summary>
        /// Called when the <see cref="P:System.Windows.Controls.ContentControl.Content"/> property changes.
        /// </summary>
        /// <param name="oldContent">A reference to the root of the old content tree.</param><param name="newContent">A reference to the root of the new content tree.</param>
        protected override void OnContentChanged(object oldContent, object newContent);

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.SourceInitialized"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected virtual void OnSourceInitialized(EventArgs e);

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.Activated"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected virtual void OnActivated(EventArgs e);

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.Deactivated"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected virtual void OnDeactivated(EventArgs e);

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.StateChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected virtual void OnStateChanged(EventArgs e);

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.LocationChanged"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected virtual void OnLocationChanged(EventArgs e);

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.Closing"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"/> that contains the event data.</param>
        protected virtual void OnClosing(CancelEventArgs e);

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.Closed"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected virtual void OnClosed(EventArgs e);

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Window.ContentRendered"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected virtual void OnContentRendered(EventArgs e);

        /// <summary>
        /// Called when the <see cref="E:System.Windows.UIElement.ManipulationBoundaryFeedback"/> event occurs.
        /// </summary>
        /// <param name="e">The data for the event. </param>
        protected override void OnManipulationBoundaryFeedback(ManipulationBoundaryFeedbackEventArgs e);

        /// <summary>
        /// Gets an enumerator for a window's logical child elements.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> a window's logical child elements.
        /// </returns>
        protected internal override IEnumerator LogicalChildren { get; }

        /// <summary>
        /// Gets or sets the Windows 7 taskbar thumbnail for the <see cref="T:System.Windows.Window"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The Windows 7 taskbar thumbnail for the <see cref="T:System.Windows.Window"/>.
        /// </returns>
        public TaskbarItemInfo TaskbarItemInfo { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether a window's client area supports transparency.
        /// </summary>
        /// 
        /// <returns>
        /// true if the window supports transparency; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:System.Windows.Window.AllowsTransparency"/> is changed after a window has been shown.</exception><exception cref="T:System.InvalidOperationException">A window that has a <see cref="P:System.Windows.Window.WindowStyle"/> value of anything other than <see cref="F:System.Windows.WindowStyle.None"/>.</exception>
        public bool AllowsTransparency { get; set; }

        /// <summary>
        /// Gets or sets a window's title.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.String"/> that contains the window's title.
        /// </returns>
        [Localizability(LocalizationCategory.Title)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a window's icon.
        /// </summary>
        /// 
        /// <returns>
        /// An <see cref="T:System.Windows.Media.ImageSource"/> object that represents the icon.
        /// </returns>
        public ImageSource Icon { get; [SecurityCritical]
        set; }

        /// <summary>
        /// Gets or sets a value that indicates whether a window will automatically size itself to fit the size of its content.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.SizeToContent"/> value. The default is <see cref="F:System.Windows.SizeToContent.Manual"/>.
        /// </returns>
        public SizeToContent SizeToContent { get; set; }

        /// <summary>
        /// Gets or sets the position of the window's top edge, in relation to the desktop.
        /// </summary>
        /// 
        /// <returns>
        /// The position of the window's top, in logical units (1/96").
        /// </returns>
        [TypeConverter("System.Windows.LengthConverter, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
        public double Top { get; set; }

        /// <summary>
        /// Gets or sets the position of the window's left edge, in relation to the desktop.
        /// </summary>
        /// 
        /// <returns>
        /// The position of the window's left edge, in logical units (1/96th of an inch).
        /// </returns>
        [TypeConverter("System.Windows.LengthConverter, PresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35, Custom=null")]
        public double Left { get; set; }

        /// <summary>
        /// Gets the size and location of a window before being either minimized or maximized.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.Rect"/> that specifies the size and location of a window before being either minimized or maximized.
        /// </returns>
        public Rect RestoreBounds { [SecurityCritical]
        get; }

        /// <summary>
        /// Gets or sets the position of the window when first shown.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.WindowStartupLocation"/> value that specifies the top/left position of a window when first shown. The default is <see cref="F:System.Windows.WindowStartupLocation.Manual"/>.
        /// </returns>
        [DefaultValue(WindowStartupLocation.Manual)]
        public WindowStartupLocation WindowStartupLocation { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether the window has a task bar button.
        /// </summary>
        /// 
        /// <returns>
        /// true if the window has a task bar button; otherwise, false. Does not apply when the window is hosted in a browser.
        /// </returns>
        public bool ShowInTaskbar { get; set; }

        /// <summary>
        /// Gets a value that indicates whether the window is active.
        /// </summary>
        /// 
        /// <returns>
        /// true if the window is active; otherwise, false. The default is false.
        /// </returns>
        public bool IsActive { get; }

        /// <summary>
        /// Gets or sets the <see cref="T:System.Windows.Window"/> that owns this <see cref="T:System.Windows.Window"/>.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.Window"/> object that represents the owner of this <see cref="T:System.Windows.Window"/>.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">A window tries to own itself-or-Two windows try to own each other.</exception><exception cref="T:System.InvalidOperationException">The <see cref="P:System.Windows.Window.Owner"/> property is set on a visible window shown using <see cref="M:System.Windows.Window.ShowDialog"/>-or-The <see cref="P:System.Windows.Window.Owner"/> property is set with a window that has not been previously shown.</exception>
        [DefaultValue(null)]
        public Window Owner { [SecurityCritical]
        get; [SecurityCritical]
        set; }

        /// <summary>
        /// Gets a collection of windows for which this window is the owner.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.WindowCollection"/> that contains references to the windows for which this window is the owner.
        /// </returns>
        public WindowCollection OwnedWindows { get; }

        /// <summary>
        /// Gets or sets the dialog result value, which is the value that is returned from the <see cref="M:System.Windows.Window.ShowDialog"/> method.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Nullable`1"/> value of type <see cref="T:System.Boolean"/>. The default is false.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:System.Windows.Window.DialogResult"/> is set before a window is opened by calling <see cref="M:System.Windows.Window.ShowDialog"/>. -or-<see cref="P:System.Windows.Window.DialogResult"/> is set on a window that is opened by calling <see cref="M:System.Windows.Window.Show"/>.</exception>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [TypeConverter(typeof (DialogResultConverter))]
        public bool? DialogResult { get; set; }

        /// <summary>
        /// Gets or sets a window's border style.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.WindowStyle"/> that specifies a window's border style. The default is <see cref="F:System.Windows.WindowStyle.SingleBorderWindow"/>.
        /// </returns>
        public WindowStyle WindowStyle { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether a window is restored, minimized, or maximized.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.WindowState"/> that determines whether a window is restored, minimized, or maximized. The default is <see cref="F:System.Windows.WindowState.Normal"/> (restored).
        /// </returns>
        public WindowState WindowState { get; set; }

        /// <summary>
        /// Gets or sets the resize mode.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Windows.ResizeMode"/> value specifying the resize mode.
        /// </returns>
        public ResizeMode ResizeMode { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether a window appears in the topmost z-order.
        /// </summary>
        /// 
        /// <returns>
        /// true if the window is topmost; otherwise, false.
        /// </returns>
        public bool Topmost { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates whether a window is activated when first shown.
        /// </summary>
        /// 
        /// <returns>
        /// true if a window is activated when first shown; otherwise, false. The default is true.
        /// </returns>
        public bool ShowActivated { get; set; }

        /// <summary>
        /// This event is raised to support interoperation with Win32. See <see cref="T:System.Windows.Interop.HwndSource"/>.
        /// </summary>
        public event EventHandler SourceInitialized;

        /// <summary>
        /// Occurs when a window becomes the foreground window.
        /// </summary>
        public event EventHandler Activated;

        /// <summary>
        /// Occurs when a window becomes a background window.
        /// </summary>
        public event EventHandler Deactivated;

        /// <summary>
        /// Occurs when the window's <see cref="P:System.Windows.Window.WindowState"/> property changes.
        /// </summary>
        public event EventHandler StateChanged;

        /// <summary>
        /// Occurs when the window's location changes.
        /// </summary>
        public event EventHandler LocationChanged;

        /// <summary>
        /// Occurs directly after <see cref="M:System.Windows.Window.Close"/> is called, and can be handled to cancel window closure.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:System.Windows.UIElement.Visibility"/> is set, or <see cref="M:System.Windows.Window.Show"/>, <see cref="M:System.Windows.Window.ShowDialog"/>, or <see cref="M:System.Windows.Window.Close"/> is called while a window is closing.</exception>
        public event CancelEventHandler Closing;

        /// <summary>
        /// Occurs when the window is about to close.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:System.Windows.UIElement.Visibility"/> is set, or <see cref="M:System.Windows.Window.Show"/>, <see cref="M:System.Windows.Window.ShowDialog"/>, or <see cref="M:System.Windows.Window.Hide"/> is called while a window is closing.</exception>
        public event EventHandler Closed;

        /// <summary>
        /// Occurs after a window's content has been rendered.
        /// </summary>
        public event EventHandler ContentRendered;
    }
}
