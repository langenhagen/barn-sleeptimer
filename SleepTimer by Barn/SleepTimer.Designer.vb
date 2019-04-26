<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimer
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTimer))
    Me.grpSet = New System.Windows.Forms.GroupBox
    Me.chkLogOff = New System.Windows.Forms.CheckBox
    Me.rbnUhr = New System.Windows.Forms.RadioButton
    Me.rbnMin = New System.Windows.Forms.RadioButton
    Me.grpInfo = New System.Windows.Forms.GroupBox
    Me.lblMin = New System.Windows.Forms.Label
    Me.lblUhr = New System.Windows.Forms.Label
    Me.grpTime = New System.Windows.Forms.GroupBox
    Me.nudMin = New System.Windows.Forms.NumericUpDown
    Me.chkAuto = New System.Windows.Forms.CheckBox
    Me.lblInfo = New System.Windows.Forms.Label
    Me.dtpUhr = New System.Windows.Forms.DateTimePicker
    Me.btnSave = New System.Windows.Forms.Button
    Me.btnStart = New System.Windows.Forms.Button
    Me.tmrTimer = New System.Windows.Forms.Timer(Me.components)
    Me.ntfIcon = New System.Windows.Forms.NotifyIcon(Me.components)
    Me.btnHide = New System.Windows.Forms.Button
    Me.tltTips = New System.Windows.Forms.ToolTip(Me.components)
    Me.tmrHide = New System.Windows.Forms.Timer(Me.components)
    Me.CMnuIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.CMnuTime = New System.Windows.Forms.ToolStripMenuItem
    Me.CMnuShow = New System.Windows.Forms.ToolStripMenuItem
    Me.CMnuExit = New System.Windows.Forms.ToolStripMenuItem
    Me.CMnuLine = New System.Windows.Forms.ToolStripSeparator
    Me.grpSet.SuspendLayout()
    Me.grpInfo.SuspendLayout()
    Me.grpTime.SuspendLayout()
    CType(Me.nudMin, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.CMnuIcon.SuspendLayout()
    Me.SuspendLayout()
    '
    'grpSet
    '
    Me.grpSet.BackColor = System.Drawing.Color.Transparent
    Me.grpSet.Controls.Add(Me.chkLogOff)
    Me.grpSet.Controls.Add(Me.rbnUhr)
    Me.grpSet.Controls.Add(Me.rbnMin)
    resources.ApplyResources(Me.grpSet, "grpSet")
    Me.grpSet.Name = "grpSet"
    Me.grpSet.TabStop = False
    '
    'chkLogOff
    '
    resources.ApplyResources(Me.chkLogOff, "chkLogOff")
    Me.chkLogOff.BackColor = System.Drawing.Color.Transparent
    Me.chkLogOff.Name = "chkLogOff"
    Me.tltTips.SetToolTip(Me.chkLogOff, resources.GetString("chkLogOff.ToolTip"))
    Me.chkLogOff.UseVisualStyleBackColor = False
    '
    'rbnUhr
    '
    resources.ApplyResources(Me.rbnUhr, "rbnUhr")
    Me.rbnUhr.BackColor = System.Drawing.Color.Transparent
    Me.rbnUhr.Cursor = System.Windows.Forms.Cursors.Hand
    Me.rbnUhr.Name = "rbnUhr"
    Me.tltTips.SetToolTip(Me.rbnUhr, resources.GetString("rbnUhr.ToolTip"))
    Me.rbnUhr.UseVisualStyleBackColor = False
    '
    'rbnMin
    '
    resources.ApplyResources(Me.rbnMin, "rbnMin")
    Me.rbnMin.BackColor = System.Drawing.Color.Transparent
    Me.rbnMin.Checked = True
    Me.rbnMin.Cursor = System.Windows.Forms.Cursors.Hand
    Me.rbnMin.Name = "rbnMin"
    Me.rbnMin.TabStop = True
    Me.tltTips.SetToolTip(Me.rbnMin, resources.GetString("rbnMin.ToolTip"))
    Me.rbnMin.UseVisualStyleBackColor = False
    '
    'grpInfo
    '
    Me.grpInfo.BackColor = System.Drawing.Color.Transparent
    Me.grpInfo.Controls.Add(Me.lblMin)
    Me.grpInfo.Controls.Add(Me.lblUhr)
    resources.ApplyResources(Me.grpInfo, "grpInfo")
    Me.grpInfo.Name = "grpInfo"
    Me.grpInfo.TabStop = False
    '
    'lblMin
    '
    resources.ApplyResources(Me.lblMin, "lblMin")
    Me.lblMin.BackColor = System.Drawing.Color.Transparent
    Me.lblMin.Name = "lblMin"
    '
    'lblUhr
    '
    resources.ApplyResources(Me.lblUhr, "lblUhr")
    Me.lblUhr.BackColor = System.Drawing.Color.Transparent
    Me.lblUhr.Name = "lblUhr"
    '
    'grpTime
    '
    Me.grpTime.BackColor = System.Drawing.Color.Transparent
    Me.grpTime.Controls.Add(Me.nudMin)
    Me.grpTime.Controls.Add(Me.chkAuto)
    Me.grpTime.Controls.Add(Me.lblInfo)
    Me.grpTime.Controls.Add(Me.dtpUhr)
    resources.ApplyResources(Me.grpTime, "grpTime")
    Me.grpTime.Name = "grpTime"
    Me.grpTime.TabStop = False
    '
    'nudMin
    '
    Me.nudMin.Cursor = System.Windows.Forms.Cursors.Hand
    resources.ApplyResources(Me.nudMin, "nudMin")
    Me.nudMin.Maximum = New Decimal(New Integer() {20160, 0, 0, 0})
    Me.nudMin.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
    Me.nudMin.Name = "nudMin"
    Me.tltTips.SetToolTip(Me.nudMin, resources.GetString("nudMin.ToolTip"))
    Me.nudMin.Value = New Decimal(New Integer() {1, 0, 0, 0})
    '
    'chkAuto
    '
    resources.ApplyResources(Me.chkAuto, "chkAuto")
    Me.chkAuto.BackColor = System.Drawing.Color.Transparent
    Me.chkAuto.Cursor = System.Windows.Forms.Cursors.Hand
    Me.chkAuto.Name = "chkAuto"
    Me.tltTips.SetToolTip(Me.chkAuto, resources.GetString("chkAuto.ToolTip"))
    Me.chkAuto.UseVisualStyleBackColor = False
    '
    'lblInfo
    '
    Me.lblInfo.BackColor = System.Drawing.Color.Transparent
    Me.lblInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    resources.ApplyResources(Me.lblInfo, "lblInfo")
    Me.lblInfo.Name = "lblInfo"
    '
    'dtpUhr
    '
    Me.dtpUhr.Cursor = System.Windows.Forms.Cursors.Hand
    resources.ApplyResources(Me.dtpUhr, "dtpUhr")
    Me.dtpUhr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.dtpUhr.MinDate = New Date(2007, 1, 27, 0, 0, 0, 0)
    Me.dtpUhr.Name = "dtpUhr"
    Me.dtpUhr.ShowUpDown = True
    Me.tltTips.SetToolTip(Me.dtpUhr, resources.GetString("dtpUhr.ToolTip"))
    Me.dtpUhr.Value = New Date(2007, 1, 27, 0, 0, 0, 0)
    '
    'btnSave
    '
    Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
    resources.ApplyResources(Me.btnSave, "btnSave")
    Me.btnSave.Name = "btnSave"
    Me.tltTips.SetToolTip(Me.btnSave, resources.GetString("btnSave.ToolTip"))
    Me.btnSave.UseVisualStyleBackColor = True
    '
    'btnStart
    '
    Me.btnStart.Cursor = System.Windows.Forms.Cursors.Hand
    Me.btnStart.FlatAppearance.BorderSize = 10
    resources.ApplyResources(Me.btnStart, "btnStart")
    Me.btnStart.Name = "btnStart"
    Me.tltTips.SetToolTip(Me.btnStart, resources.GetString("btnStart.ToolTip"))
    Me.btnStart.UseVisualStyleBackColor = True
    '
    'tmrTimer
    '
    Me.tmrTimer.Interval = 60000
    '
    'ntfIcon
    '
    Me.ntfIcon.ContextMenuStrip = Me.CMnuIcon
    resources.ApplyResources(Me.ntfIcon, "ntfIcon")
    '
    'btnHide
    '
    resources.ApplyResources(Me.btnHide, "btnHide")
    Me.btnHide.Name = "btnHide"
    Me.tltTips.SetToolTip(Me.btnHide, resources.GetString("btnHide.ToolTip"))
    Me.btnHide.UseVisualStyleBackColor = True
    '
    'tltTips
    '
    resources.ApplyResources(Me.tltTips, "tltTips")
    '
    'tmrHide
    '
    Me.tmrHide.Interval = 1
    '
    'CMnuIcon
    '
    Me.CMnuIcon.BackgroundImage = Global.SleepTimer_by_Barn.My.Resources.Resources.BG
    Me.CMnuIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CMnuTime, Me.CMnuLine, Me.CMnuShow, Me.CMnuExit})
    Me.CMnuIcon.Name = "CMnuIcon"
    Me.CMnuIcon.ShowItemToolTips = False
    resources.ApplyResources(Me.CMnuIcon, "CMnuIcon")
    '
    'CMnuTime
    '
    Me.CMnuTime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    resources.ApplyResources(Me.CMnuTime, "CMnuTime")
    Me.CMnuTime.Name = "CMnuTime"
    '
    'CMnuShow
    '
    Me.CMnuShow.Checked = True
    Me.CMnuShow.CheckState = System.Windows.Forms.CheckState.Checked
    resources.ApplyResources(Me.CMnuShow, "CMnuShow")
    Me.CMnuShow.Name = "CMnuShow"
    '
    'CMnuExit
    '
    Me.CMnuExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
    Me.CMnuExit.Name = "CMnuExit"
    resources.ApplyResources(Me.CMnuExit, "CMnuExit")
    '
    'CMnuLine
    '
    Me.CMnuLine.Name = "CMnuLine"
    resources.ApplyResources(Me.CMnuLine, "CMnuLine")
    '
    'frmTimer
    '
    Me.AcceptButton = Me.btnStart
    resources.ApplyResources(Me, "$this")
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackgroundImage = Global.SleepTimer_by_Barn.My.Resources.Resources.BG
    Me.Controls.Add(Me.btnHide)
    Me.Controls.Add(Me.btnStart)
    Me.Controls.Add(Me.btnSave)
    Me.Controls.Add(Me.grpTime)
    Me.Controls.Add(Me.grpInfo)
    Me.Controls.Add(Me.grpSet)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.MaximizeBox = False
    Me.Name = "frmTimer"
    Me.Opacity = 0.85
    Me.grpSet.ResumeLayout(False)
    Me.grpSet.PerformLayout()
    Me.grpInfo.ResumeLayout(False)
    Me.grpInfo.PerformLayout()
    Me.grpTime.ResumeLayout(False)
    Me.grpTime.PerformLayout()
    CType(Me.nudMin, System.ComponentModel.ISupportInitialize).EndInit()
    Me.CMnuIcon.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents grpSet As System.Windows.Forms.GroupBox
  Friend WithEvents rbnUhr As System.Windows.Forms.RadioButton
  Friend WithEvents rbnMin As System.Windows.Forms.RadioButton
  Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
  Friend WithEvents lblMin As System.Windows.Forms.Label
  Friend WithEvents lblUhr As System.Windows.Forms.Label
  Friend WithEvents grpTime As System.Windows.Forms.GroupBox
  Friend WithEvents chkAuto As System.Windows.Forms.CheckBox
  Friend WithEvents lblInfo As System.Windows.Forms.Label
  Friend WithEvents btnSave As System.Windows.Forms.Button
  Friend WithEvents btnStart As System.Windows.Forms.Button
  Friend WithEvents nudMin As System.Windows.Forms.NumericUpDown
  Friend WithEvents dtpUhr As System.Windows.Forms.DateTimePicker
  Friend WithEvents tmrTimer As System.Windows.Forms.Timer
  Friend WithEvents ntfIcon As System.Windows.Forms.NotifyIcon
  Friend WithEvents btnHide As System.Windows.Forms.Button
  Friend WithEvents tltTips As System.Windows.Forms.ToolTip
  Friend WithEvents tmrHide As System.Windows.Forms.Timer
  Friend WithEvents chkLogOff As System.Windows.Forms.CheckBox
  Friend WithEvents CMnuIcon As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents CMnuTime As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents CMnuLine As System.Windows.Forms.ToolStripSeparator
  Friend WithEvents CMnuShow As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents CMnuExit As System.Windows.Forms.ToolStripMenuItem

End Class
