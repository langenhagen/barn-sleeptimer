Imports System.IO
Imports System.IO.Path
Imports Microsoft.Win32

Public Class frmTimer

  Inherits System.Windows.Forms.Form

  Private Minutes As Integer      'Anzahl der Minuten in Minutes als Private Variable
  Private Uhrz As Date            'Für die Uhrzeitübermittlung
  Private Force As Byte

  Private Sub ntfIcon_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ntfIcon.MouseDoubleClick

    Me.WindowState = FormWindowState.Normal   'Aufs Tray... groß machen!
    Me.Show()           'Fenster zeigen
    Me.TopMost = True   'Fenster nach vorne holen
    Me.TopMost = False  'unbemerkt wieder einreihen
    CMnuShow.Checked = True

  End Sub

  Private Sub frmTimer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Registry.CurrentUser.CreateSubKey("Software\BarnsSleepTimer") 'Against Errors

    '############################################################################
    'Registry-Key für die Zeit checken
    '############################################################################

    Try
      Dim SavedZeit As Date
      SavedZeit = Registry.CurrentUser.OpenSubKey("Software\BarnsSleepTimer").GetValue("Time").ToString()
      rbnUhr.Checked = True
      dtpUhr.Visible = True
      nudMin.Visible = False
      dtpUhr.Value = SavedZeit
      lblInfo.Text = "Bitte geben sie die gewünschte Uhrzeit ein."
    Catch
    End Try

    '############################################################################
    'Registry-Key für die Minuten checken
    '############################################################################

    Try
      Dim Mins As Integer
      Mins = Registry.CurrentUser.OpenSubKey("Software\BarnsSleepTimer").GetValue("Mins").ToString()
      rbnMin.Checked = True
      dtpUhr.Visible = False
      nudMin.Visible = True
      nudMin.Value = Mins
      lblInfo.Text = lblInfo.Text = "Bitte geben sie die gewünschte Anzahl der Minuten ein."
    Catch
    End Try

    '############################################################################
    'Registry-Key für Autostart checken und Häkchen checken, unsichtbar machen.
    '############################################################################

    Try   'Wenn der SubKey da is, Häkchen setzen, tmrEnabled für Unsichtbar einschalten
      Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run").GetValue("BarnsSleepTimer").ToString()
      chkAuto.Checked = True
      tmrHide.Enabled = True
    Catch   'Wenner nich da is, nix tun...
    End Try


    '############################################################################
    'Registry-Key für Erzwingen checken und Häkchen checken, unsichtbar machen.
    '############################################################################

    Try   'Wenn der SubKey da is, Häkchen setzen, tmrEnabled für Unsichtbar einschalten
      Registry.CurrentUser.OpenSubKey("Software\BarnsSleepTimer").GetValue("LogOff").ToString()
      chkLogOff.Checked = True
      Force = 0
    Catch   'Wenner nich da is, nix tun...
      Force = 8
    End Try

  End Sub

  Private Sub tmrTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrTimer.Tick

    '############################################################################
    'Timer für Minuten-Eingabe
    '############################################################################

    Minutes -= 1

    lblMin.Text = "Computer schaltet in " & Minutes & " Minuten ab."

    ntfIcon.Text = "SleepTimer by Barn" & vbNewLine & "Abschaltung in " & _
                    Minutes & " Minuten"
    CMnuTime.Text = Minutes & " Minuten"

    '############################################################################
    'SHUTDOWN für Minuten-Eingabe
    '############################################################################

    If (Minutes = 1) Then
      lblMin.Text = "Computer schaltet in 1 Minute ab."
      ntfIcon.Text = "SleepTimer by Barn" & vbNewLine & "Abschaltung in " & _
                      "1 Minute"
      CMnuTime.Text = "1 Minute"
    End If


    If (Minutes = 0) Then

      Dim System, Eigenschaft As Object
      System = GetObject( _
         "winmgmts:{impersonationLevel=impersonate,(Shutdown)}" & _
         "//./root/cimv2").ExecQuery( _
         "SELECT * FROM Win32_OperatingSystem")

      For Each Eigenschaft In System
        Eigenschaft.Win32Shutdown(Force) '(eigentlich 8 + irgendwie wat erzwingen --> +4
      Next

    End If

  End Sub

  Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

    '############################################################################
    'Autostart checken!
    '############################################################################

    If (chkAuto.Checked = True) Then        'Wenn Autostart aktiviert wurde, in Reg eintragen

      Dim Pfad As String
      Pfad = Environment.CurrentDirectory.ToString & "\SleepTimer by Barn.exe"
      Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).SetValue("BarnsSleepTimer", Pfad)

    Else                                    'Wenn Autostart deaktiviert...

      Try     'Wenn der SubKey da is, löschen, da Autostart deaktiviert
        Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue("BarnsSleepTimer")
      Catch   'Wenner nich da is, nix tun...
      End Try

    End If

    '############################################################################
    'Time-Key oder Minuten-Key saven! Wenn alles glatt geht...
    '############################################################################

    If (rbnUhr.Checked = True) Then     'Wenn die Uhr angwewählt

      Dim SavedZeit As Date             'Datum+Uhrzeit in den Key 'Time' übertragen...
      SavedZeit = dtpUhr.Value
      Registry.CurrentUser.OpenSubKey("Software\BarnsSleepTimer", True).SetValue("Time", SavedZeit)
      Registry.CurrentUser.OpenSubKey("Software\BarnsSleepTimer", True).DeleteValue("Mins", False)
    Else
      Dim Mins As Integer             'Datum+Uhrzeit in den Key 'Time' übertragen...
      Mins = nudMin.Value
      Registry.CurrentUser.OpenSubKey("Software\BarnsSleepTimer", True).SetValue("Mins", Mins)
      Registry.CurrentUser.OpenSubKey("Software\BarnsSleepTimer", True).DeleteValue("Time", False)
    End If

    '############################################################################
    'LogOff checken!
    '############################################################################

    If (chkLogOff.Checked = True) Then 'Wenn chkForce aktiviert wurde, in Reg eintragen

      Registry.CurrentUser.OpenSubKey("Software\BarnsSleepTimer", True).SetValue("LogOff", "Force to LogOff")
    Else                                    'Wenn Force deaktiviert...
      'Wenn der SubKey da is, löschen, da Autostart deaktiviert
      Registry.CurrentUser.OpenSubKey("Software\BarnsSleepTimer", True).DeleteValue("LogOff", False)

    End If

  End Sub

  Private Sub rbnMin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnMin.CheckedChanged

    '############################################################################
    'Wenn der Minutenchecker aktiv is, Autostarthäkchen disablen
    'Die Visibilität der Eingabeobjekte einstellen
    'Außerdedem lblInfo's Infotext einstellen
    '############################################################################

    chkAuto.Enabled = False
    chkAuto.Checked = False

    nudMin.Visible = True
    dtpUhr.Visible = False

    lblInfo.Text = "Bitte geben sie die gewünschte Anzahl der Minuten ein."


  End Sub

  Private Sub grpSet_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpSet.Enter

  End Sub

  Private Sub rbnUhr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbnUhr.CheckedChanged

    '############################################################################
    'Wenn der Uhrchecker aktiv is, Autostarthäkchen enablen
    'Die Visibilität der Eingabeobjekte einstellen
    'Außerdem lblInfo's Infotext einstellen
    '############################################################################

    chkAuto.Enabled = True

    nudMin.Visible = False
    dtpUhr.Visible = True

    lblInfo.Text = "Bitte geben sie die gewünschte Uhrzeit ein."

  End Sub

  Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click
    CMnuShow.Checked = False
    tmrHide.Enabled = True
  End Sub

  Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

    If (btnStart.Text = "Timer stoppen") Then   'Timer beide ausschalten, falls Button
      tmrTimer.Enabled = False               'schon aktiviert wurde
      tmrTimer.Enabled = False
      btnSave.Enabled = True
      chkAuto.Enabled = True
      nudMin.Enabled = True
      dtpUhr.Enabled = True
      chkLogOff.Enabled = True
      rbnUhr.Enabled = True
      rbnMin.Enabled = True
      CMnuTime.Visible = False
      CMnuLine.Visible = False
      lblUhr.Text = "Computer schaltet um ... ab."
      lblMin.Text = "Computer schaltet in ... Minuten ab."
      btnStart.Text = "Timer starten"
      ntfIcon.Text = "SleepTimer by Barn" & vbNewLine & "DDicated to Philipp"
    Else                                        'Wenn Butten aktiviert ist

      btnSave.Enabled = False
      chkAuto.Enabled = False
      nudMin.Enabled = False
      dtpUhr.Enabled = False
      chkLogOff.Enabled = False
      rbnUhr.Enabled = False
      rbnMin.Enabled = False

      If (rbnMin.Checked = True) Then           'Fallunterscheidung: Minutenanzahl

        Minutes = nudMin.Value            'Den Wert des Textfeldes in Minutes eintragen

        Uhrz = Now                        'Globale Variable Uhrz auf akt. Zeit setzen
        Uhrz = Uhrz.AddMinutes(Minutes)   'Und plus Minutes für Zeit des Shutdowns
        tmrTimer.Enabled = True        'Timer dann Aktivieren

        'Info-Labels schonmal beschriften weil wegen Warten auf Timer-Tick

        lblUhr.Text = "Computer schaltet um " & Uhrz.Hour.ToString & ":" & _
              Uhrz.Minute.ToString() & " ab."

        If (Minutes <> 1) Then
          lblMin.Text = "Computer schaltet in " & Minutes & " Minuten ab."
          ntfIcon.Text = "SleepTimer by Barn" & vbNewLine & "Abschaltung in " & _
                          Minutes & " Minuten"
          CMnuTime.Text = Minutes & " Minuten"
          CMnuTime.Visible = True
          CMnuLine.Visible = False
        Else
          lblMin.Text = "Computer schaltet in 1 Minute ab."
          ntfIcon.Text = "SleepTimer by Barn" & vbNewLine & "Abschaltung in " & _
                          "1 Minute"
          CMnuTime.Text = "1 Minute"
          CMnuTime.Visible = True
          CMnuLine.Visible = False
        End If

      Else                                'Fallunterscheidung: Uhrzeit

        Dim DEing As Date                 'Hilfsvariable der Übersicht halber
        DEing = dtpUhr.Value

        'Minutes einstellen...
        Minutes = (DEing.Hour - Now.Hour) * 60 + (DEing.Minute - Now.Minute)

        If (Minutes <= 0) Then     'Wenn minuten kleiner als Null sind, nächsten Tach...
          Minutes = Minutes + 1440
        End If

        lblUhr.Text = "Computer schaltet um " & DEing.Hour.ToString & ":" & _
              DEing.Minute.ToString & " ab."
        If (Minutes <> 1) Then
          lblMin.Text = "Computer schaltet in " & Minutes & " Minuten ab."
          ntfIcon.Text = "SleepTimer by Barn" & vbNewLine & "Abschaltung in " & _
                          Minutes & " Minuten"
          CMnuTime.Text = Minutes & " Minuten"
          CMnuTime.Visible = True
          CMnuLine.Visible = False
        Else
          lblMin.Text = "Computer schaltet in 1 Minute ab."
          ntfIcon.Text = "SleepTimer by Barn" & vbNewLine & "Abschaltung in " & _
                          "1 Minute"
          CMnuTime.Text = "1 Minute"
          CMnuTime.Visible = True
          CMnuLine.Visible = False
        End If

        tmrTimer.Enabled = True        'Und Timer Aktivieren

      End If

      btnStart.Text = "Timer stoppen"           'Text des Buttons ändern.

    End If

  End Sub

  Private Sub tmrTimerUhr_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '############################################################################
    'Timer für Uhrzeit-Eingabe
    '############################################################################


    Minutes -= 1

    lblMin.Text = "Computer schaltet in " & Minutes & " Minuten ab."

    '############################################################################
    'SHUTDOWN für Minuten-Eingabe
    '############################################################################

    If (Minutes = 0) Then

      Dim System, Eigenschaft As Object
      System = GetObject( _
         "winmgmts:{impersonationLevel=impersonate,(Shutdown)}" & _
         "//./root/cimv2").ExecQuery( _
         "SELECT * FROM Win32_OperatingSystem")

      For Each Eigenschaft In System
        Eigenschaft.Win32Shutdown() '(eigentlich 8 + irgendwie wat erzwingen --> +4
      Next

    End If


  End Sub

  Private Sub tmrHide_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHide.Tick

    '############################################################################
    'Timer für halbwegs "eleganten" Autostart
    '###########################################################################

    If Me.Opacity > 0.0 Then
      Me.Opacity -= 0.2
    Else
      Me.Hide()
      Me.Opacity = 0.85
      tmrHide.Enabled = False
    End If

  End Sub

  Private Sub chkAuto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAuto.CheckedChanged

  End Sub

  Private Sub chkForce_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLogOff.CheckedChanged
    If (chkLogOff.Checked = True) Then
      Force = 0
    Else
      Force = 8
    End If


  End Sub

  Private Sub grpTime_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpTime.Enter

  End Sub

  Private Sub CMnuShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMnuShow.Click
    If CMnuShow.Checked = True Then
      tmrHide.Enabled = True
      CMnuShow.Checked = False
    Else
      Me.WindowState = FormWindowState.Normal
      CMnuShow.Checked = True
      Me.Show()
    End If
  End Sub

  Private Sub CMnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMnuExit.Click
    End
  End Sub
End Class
