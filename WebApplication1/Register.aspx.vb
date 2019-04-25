Imports System.IO
Imports System.Net.Sockets

Public Class Contact
    Inherits Page

    Protected Sub WhenDoingtheLoad(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        MainRegisterPanel.Visible = True
        ConfirmationPanel.Visible = False

    End Sub



    Sub NotificationSub(ByVal Type As String, ByVal Notification As String)

        '#CCFF99 is green
        '#FFCCCC is Red
        '#FFFFCC is Yellow
        'White is White

        If Type = "GREEN" Then NotifPanel.BackColor = System.Drawing.Color.PaleGreen
        If Type = "RED" Then NotifPanel.BackColor = System.Drawing.Color.Pink
        If Type = "YELLOW" Then NotifPanel.BackColor = System.Drawing.Color.Wheat
        If Type = "WHITE" Then NotifPanel.BackColor = System.Drawing.Color.White


        NotifLabel0.Text = Notification

        NotifPanel.Visible = True


    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If CheckForInput() = False Then
            NotificationSub("YELLOW", "Please specify appropriate inputs")
            Exit Sub
        End If

        If CheckBox1.Checked = False Then
            NotificationSub("YELLOW", "Please accept the terms and conditions.")
            Exit Sub
        End If

        Dim servermsg As String


        servermsg = ServerCommand("REG" & PinTXB.Text & "," & NameTXB.Text)
        If servermsg = "E" Then
            NotificationSub("RED", "The server couldn't register you. Please try again later.")
            Exit Sub
        End If
        MainRegisterPanel.Visible = False
        ConfirmationPanel.Visible = True
        NotifPanel.Visible = False
        NAMELBL.Text = NameTXB.Text
        NewIDLBL.Text = servermsg



    End Sub

    Function ServerCommand(ByVal ClientMSG As String) As String

        Dim tc As TcpClient = New TcpClient()
        Dim ns As NetworkStream
        Dim br As BinaryReader
        Dim bw As BinaryWriter
        Dim ServerMSG As String
        ServerMSG = "E"
        If ClientMSG = "" Then
            ServerCommand = "E"
            Exit Function
        End If
        Try
            tc.Connect(“Igtnet-w.ddns.net”, 757)
            Exit Try
        Catch
            NotificationSub("RED", "Unable to connect to the server. Something's wrong. Contact CHOPO")
            ServerCommand = "NOCONNECT"
            Exit Function
        End Try
        If tc.Connected = True Then
            ns = tc.GetStream
            br = New BinaryReader(ns)
            bw = New BinaryWriter(ns)
            bw.Write(ClientMSG)
            Try
                ServerMSG = br.ReadString()
            Catch
                NotificationSub("YELLOW", "Looks like the server crashed! Contact CHOPO")
                ServerCommand = "CRASH"
                Exit Function
            End Try
            tc.Close()
        End If
        ServerCommand = ServerMSG
    End Function

    Function CheckForInput() As Boolean

        CheckForInput = True

        If NameTXB.Text.Trim(" ") = "" Then
            CheckForInput = False
        End If

        If PinTXB.Text.Trim(" ") = "" Then
            CheckForInput = False
        End If

    End Function




End Class