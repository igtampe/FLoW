Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Public Class _Default
    Inherits Page




    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        NotifPanel.Visible = False



        Dim tc As TcpClient = New TcpClient()
        Dim ns As NetworkStream
        Dim br As BinaryReader
        Dim bw As BinaryWriter
        Dim ID As String
        Dim PIN As String
        Dim ServerMSG As String

        ID = LogonID.Text
        PIN = LogonPIN.Text


        If ID = "" Then

            NotificationSub("RED", "You must enter an ID")
            Exit Sub

        End If

        If Not ID.Count = 5 Then
            NotificationSub("YELLOW", "That doesn't look like an ID. It must have 5 digits")
            Exit Sub

        End If

        If PIN = "" Then

            NotificationSub("RED", "You must enter a PIN")
            Exit Sub

        End If

        If Not PIN.Count = 4 Then

            NotificationSub("YELLOW", "That doesn't look like an PIN. It must have 4 digits")
            Exit Sub

        End If




        Try
            tc.Connect(“igtnet-w.ddns.net”, 757)
            Exit Try

        Catch
            NotificationSub("RED", "Contact CHOPO, The ViBE Server is down.")
            Exit Sub

        End Try



        If tc.Connected = True Then



            ns = tc.GetStream
            br = New BinaryReader(ns)
            bw = New BinaryWriter(ns)

            bw.Write("CU" & ID & PIN)


            Try
                ServerMSG = br.ReadString()
            Catch

                NotificationSub("YELLOW", "Looks like the server crashed! Contact CHOPO")


                Exit Sub

            End Try

            tc.Close()

            Select Case ServerMSG
                Case 1
                    NotificationSub("RED", "User not found")
                    Exit Select
                Case 2

                    NotificationSub("RED", "Incorrect Pin")
                    Exit Select

                Case 3
                    LogonPanel.Visible = False
                    MainPanel.Visible = True

                    Call LoadTheCosos()
                    Exit Select


            End Select




        End If

        LogonID.Enabled = True
        LogonPIN.Enabled = True
        Button1.Enabled = True


    End Sub

    Private Sub LoadTheCosos()
        Dim TotalBalance As Long
        Dim ID As String
        Dim Username As String
        Dim UMSNB As Boolean
        Dim GBANK As Boolean
        Dim RIVER As Boolean
        Dim UMSNBBalance As Long
        Dim GBANKBalance As Long
        Dim RIVERBalance As Long
        Dim ServerMSG As String
        Dim SplitValues() As String


        Try
            ID = LogonID.Text
        Catch
            NotificationSub("YELLOW", "Session is expiered. Sign in again!")
            Response.Redirect("Default.aspx")
            Exit Sub

        End Try

        If ID = "" Then
            NotificationSub("YELLOW", "Session is expiered. Sign in again!")
            Exit Sub
        End If


        ServerMSG = ServerCommand("INFO" & ID)

        SplitValues = ServerMSG.Split(",")

        If SplitValues(0) = 1 Then UMSNB = True Else UMSNB = False
        UMSNBBalance = SplitValues(1)
        If SplitValues(2) = 1 Then GBANK = True Else GBANK = False
        GBANKBalance = SplitValues(3)
        If SplitValues(4) = 1 Then RIVER = True Else RIVER = False
        RIVERBalance = SplitValues(5)
        Username = SplitValues(6)

        MainScreenUsernamelabel.Text = Username & " (" & ID & ")"


        UMSNBCheck.Checked = UMSNB
        GBANKCheck.Checked = GBANK
        RIVERCheck.Checked = RIVER


        UMSNBRButtonSend.Enabled = UMSNB
        UMSNBRButtonTFrom.Enabled = UMSNB
        UMSNBRButtonTTo.Enabled = UMSNB

        GBANKRButtonSend.Enabled = GBANK
        GBANKRButtonTFrom.Enabled = GBANK
        GBANKRButtonTTo.Enabled = GBANK

        RIVERRButtonSend.Enabled = RIVER
        RIVERRButtonTFrom.Enabled = RIVER
        RIVERRButtonTTo.Enabled = RIVER



        UMSBLabel.Text = UMSNBBalance.ToString("N0")
        GBANKBLabel.Text = GBANKBalance.ToString("N0")
        RIVERBLabel.Text = RIVERBalance.ToString("N0")

        TotalBalance = UMSNBBalance + RIVERBalance + GBANKBalance

        TotalBLabel.Text = TotalBalance.ToString("N0")

        Dim directoryarray() As String


        ServerMSG = ServerCommand("DIR")

        directoryarray = ServerMSG.Split(",")

        ListBox1.Items.Clear()

        For i As Integer = 0 To directoryarray.Count - 1
            ListBox1.Items.Add(directoryarray(i))
        Next

        SendFromLBL.Text = ID & "\"


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

    Protected Sub LogoutButton_Click(sender As Object, e As EventArgs) Handles LogoutButton.Click
        NotifPanel.Visible = False


        MainScreenUsernamelabel.Text = "USER"

        UMSNBCheck.Checked = False
        GBANKCheck.Checked = False
        RIVERCheck.Checked = False

        UMSBLabel.Text = "Label"
        GBANKBLabel.Text = "label"
        RIVERBLabel.Text = "Label"

        TotalBLabel.Text = "Label"


        Call NotificationSub("GREEN", "You've been signed out successfully. Adiosito!")

        MainPanel.Visible = False
        LogonPanel.Visible = True



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


        NotifLabel.Text = Notification

        NotifPanel.Visible = True


    End Sub

    Protected Sub TransferButton_Click(sender As Object, e As EventArgs) Handles TransferButton.Click

        NotifPanel.Visible = False


        TransferPanel.Visible = True
    End Sub

    Protected Sub SendButton_Click(sender As Object, e As EventArgs) Handles SendButton.Click
        NotifPanel.Visible = False
        DirectoryPanel.Visible = True

    End Sub

    Protected Sub SendMoneyCancel_Click(sender As Object, e As EventArgs) Handles SendMoneyCancel.Click
        NotifPanel.Visible = False


        SendMoneyPanel.Visible = False


    End Sub

    Protected Sub SendMoneyOK_Click(sender As Object, e As EventArgs) Handles SendMoneyOK.Click

        'Send the Monet

        Dim Destination As String
        Dim Amount As Long
        Dim fromBank As String
        Dim ServerMSG As String
        Dim FirstCaseError As Boolean

        Dim ID As String = LogonID.Text


        FirstCaseError = False

        Amount = 0
        Destination = ""

        Amount = SendAmountTXB.Text
        Destination = SendToLBL.Text

        If UMSNBRButtonSendTo.Checked = True Then
            Destination = Destination & "UMSNB"

        ElseIf GBANKRButtonSendTo.Checked = True Then
            Destination = Destination & "GBANK"

        ElseIf RIVERRButtonSendTo.Checked = True Then
            Destination = Destination & "RIVER"

        Else

            NotificationSub("YELLOW", "Please select a destination.")
            Exit Sub
            GoTo ExitLabel

        End If


        fromBank = "NO"
        If UMSNBRButtonSend.Checked = True Then fromBank = "UMSNB"
        If GBANKRButtonSend.Checked = True Then fromBank = "GBANK"
        If RIVERRButtonSend.Checked = True Then fromBank = "RIVER"



        Select Case fromBank
            Case "UMSNB"
                If Amount > CInt(UMSBLabel.Text) Then
                    Call NotificationSub("RED", "Insufficient Funds")
                    FirstCaseError = True
                    Exit Sub
                    Exit Select


                End If

                If Amount < 0 Then
                    Call NotificationSub("RED", "Do not steal pls thx bai")
                    FirstCaseError = True
                    Exit Sub
                    Exit Select
                End If

            Case "GBANK"
                If Amount > CInt(GBANKBLabel.Text) Then
                    Call NotificationSub("RED", "Insufficient Funds")
                    FirstCaseError = True
                    Exit Sub
                    Exit Select

                End If
                If Amount < 0 Then
                    Call NotificationSub("RED", "Do not steal pls thx bai")
                    FirstCaseError = True
                    Exit Sub
                    Exit Select
                End If

            Case "RIVER"
                If Amount > CInt(RIVERBLabel.Text) Then
                    Call NotificationSub("RED", "Insufficient Funds")
                    FirstCaseError = True
                    Exit Sub
                    Exit Select

                End If
                If Amount < 0 Then
                    Call NotificationSub("RED", "Do not steal pls thx bai")
                    FirstCaseError = True
                    Exit Sub
                    Exit Select
                End If

        End Select


        If FirstCaseError = False Then

            If Destination.Count = 11 Then

                If fromBank = "NO" Then

                    NotificationSub("RED", "Please select an origin")

                Else
                    'SM57174\UMSNB33118\UMSNB5000
                    ServerMSG = ServerCommand("SM" & ID & "\" & fromBank & Destination & Amount)

                    Select Case ServerMSG

                        Case "1"
                            NotificationSub("RED", "Improperly coded Vibing request")

                        Case "E"
                            NotificationSub("RED", "Could not complete transaction")

                        Case "S"
                            NotificationSub("GREEN", ID & " Successfully ~vibed~ " & Amount & "p to " & Destination & ".")
                            Call LoadTheCosos()

                            SendMoneyPanel.Visible = False



                    End Select

                End If

            Else

                NotificationSub("RED", "That doesn't seem like a destination!")


            End If

        End If

ExitLabel:

    End Sub





    Protected Sub TransferMoneyOK_Click(sender As Object, e As EventArgs) Handles TransferMoneyOK.Click
        NotifPanel.Visible = False

        'Transfer the Monet

        'Read banks

        Dim ServerMSG As String

        Dim ID As String = LogonID.Text


        Dim frombank As String
        frombank = "NO"
        If UMSNBRButtonTFrom.Checked = True Then frombank = "UMSNB"
        If GBANKRButtonTFrom.Checked = True Then frombank = "GBANK"
        If RIVERRButtonTFrom.Checked = True Then frombank = "RIVER"

        Dim Tobank As String
        Tobank = "NO"
        If UMSNBRButtonTTo.Checked = True Then Tobank = "UMSNB"
        If GBANKRButtonTTo.Checked = True Then Tobank = "GBANK"
        If RIVERRButtonTTo.Checked = True Then Tobank = "RIVER"

        'Data Validation

        Dim transferamount As Long
        Dim TransferamountString As String
        Dim FirstCaseError As Boolean

        FirstCaseError = False


        TransferamountString = TransferAmountTXB.Text

        If TransferamountString = "" Then transferamount = 0 Else transferamount = Val(TransferamountString)



        Select Case frombank
            Case "UMSNB"
                If transferamount > UMSBLabel.Text Then
                    Call NotificationSub("RED", "Insufficient Funds")
                    FirstCaseError = True
                    Exit Sub
                    Exit Select


                End If

                If transferamount < 0 Then
                    Call NotificationSub("RED", "Do not steal pls thx bai")
                    FirstCaseError = True
                    Exit Sub
                    Exit Select
                End If

            Case "GBANK"
                If transferamount > GBANKBLabel.Text Then
                    Call NotificationSub("RED", "Insufficient Funds")
                    FirstCaseError = True
                    Exit Sub
                    Exit Select

                End If
                If transferamount < 0 Then
                    Call NotificationSub("RED", "Do not steal pls thx bai")
                    FirstCaseError = True
                    Exit Sub
                    Exit Select
                End If

            Case "RIVER"
                If transferamount > RIVERBLabel.Text Then
                    Call NotificationSub("RED", "Insufficient Funds")
                    FirstCaseError = True
                    Exit Sub
                    Exit Select

                End If
                If transferamount < 0 Then
                    Call NotificationSub("RED", "Do not steal pls thx bai")
                    FirstCaseError = True
                    Exit Sub
                    Exit Select
                End If

        End Select

        If FirstCaseError = False Then

            If Tobank = "NO" Then

                Call NotificationSub("RED", "Please specify a Destination")

            Else
                If frombank = "NO" Then

                    Call NotificationSub("RED", "Please Specify an Origin")

                Else

                    If Tobank = frombank Then

                        Call NotificationSub("RED", "Destination and Origin are the same. Porque?")

                    Else
                        'TM57174UMSNBGBANK5000
                        ServerMSG = ServerCommand("TM" & ID & frombank & Tobank & transferamount)

                        Select Case ServerMSG
                            Case "1"
                                Call NotificationSub("RED", "Improperly coded Vibing request")
                            Case "E"
                                Call NotificationSub("RED", "Could not complete transaction")
                            Case "S"
                                Call NotificationSub("GREEN", "Transfered " & transferamount & "p from " & frombank & " to " & Tobank & ".")

                                Call LoadTheCosos()

                                TransferPanel.Visible = False

                        End Select

                    End If

                End If

            End If

        End If




    End Sub

    Protected Sub TransferMoneyCancel_Click(sender As Object, e As EventArgs) Handles TransferMoneyCancel.Click

        TransferPanel.Visible = False
        NotifPanel.Visible = False



    End Sub

    Protected Sub RefreshButton_Click(sender As Object, e As EventArgs) Handles RefreshButton.Click
        NotifPanel.Visible = False

        Call LoadTheCosos()

    End Sub

    Protected Sub DirectoryOK_Click(sender As Object, e As EventArgs) Handles DirectoryOK.Click

        If ListBox1.SelectedItem.ToString = "" Then
            NotificationSub("YELLOW", "Please select a user.")

        Else

            DirectoryPanel.Visible = False

            UMSNBRButtonSendTo.Enabled = False
            GBANKRButtonSendTo.Enabled = False
            RIVERRButtonSendTo.Enabled = False

            Dim INFO() As String

            INFO = ServerCommand("INFO" & ListBox1.SelectedItem.ToString.Remove(5, ListBox1.SelectedItem.ToString.Length - 5)).Split(",")

            If INFO(0) = 1 Then UMSNBRButtonSendTo.Enabled = True Else UMSNBRButtonSendTo.Enabled = False
            If INFO(2) = 1 Then GBANKRButtonSendTo.Enabled = True Else GBANKRButtonSendTo.Enabled = False
            If INFO(4) = 1 Then RIVERRButtonSendTo.Enabled = True Else RIVERRButtonSendTo.Enabled = False

            SendToLBL.Text = ListBox1.SelectedItem.ToString.Remove(5, ListBox1.SelectedItem.ToString.Length - 5) & "\"

            SendMoneyPanel.Visible = True


        End If




    End Sub

    Protected Sub DirectoryCancel_Click(sender As Object, e As EventArgs) Handles DirectoryCancel.Click
        DirectoryPanel.Visible = False
        NotifPanel.Visible = False

    End Sub

    Protected Sub BQNo_Click(sender As Object, e As EventArgs) Handles BQNo.Click
        BankQuestionPanel.Visible = False
        NotifPanel.Visible = False

    End Sub

    Protected Sub ClickUMSNB(sender As Object, e As EventArgs) Handles UMSNBHyperlink.Click
        NotifPanel.Visible = False
        BQBankLBL.Text = "UMSNB"
        BankLogo.ImageUrl = "~/Resources/UMSNB.png"

        Select Case UMSNBCheck.Checked
            Case True
                MainPanel.Visible = False
                BankWindow.Visible = True
                LoadLog(BQBankLBL.Text)
            Case False
                BankQuestionPanel.Visible = True
        End Select

    End Sub
    Protected Sub ClickGBANK(sender As Object, e As EventArgs) Handles GBANKHyperlink.Click
        NotifPanel.Visible = False
        BQBankLBL.Text = "GBANK"
        BankLogo.ImageUrl = "~/Resources/GBANK.png"

        Select Case GBANKCheck.Checked
            Case True
                MainPanel.Visible = False
                BankWindow.Visible = True
                LoadLog(BQBankLBL.Text)
            Case False
                BankQuestionPanel.Visible = True
        End Select

    End Sub
    Protected Sub ClickRIVER(sender As Object, e As EventArgs) Handles RIVERHyperlink.Click
        NotifPanel.Visible = False
        BQBankLBL.Text = "RIVER"
        BankLogo.ImageUrl = "~/Resources/Riverside.png"

        Select Case RIVERCheck.Checked
            Case True
                MainPanel.Visible = False
                BankWindow.Visible = True
                LoadLog(BQBankLBL.Text)
            Case False
                BankQuestionPanel.Visible = True
        End Select

    End Sub

    Sub LoadLog(ByVal bank As String)

        Select Case ServerCommand("BNKL" & LogonID.Text & bank)
            Case "S"

                Try
                    Dim address As String = "http://igtnet-w.ddns.net:100/logs/" & LogonID.Text & bank & ".log"
                    Dim client As WebClient = New WebClient()
                    Dim reader As StreamReader = New StreamReader(client.OpenRead(address))
                    BankLogTextbox.Text = reader.ReadToEnd
                Catch
                    NotificationSub("RED", "There was an error retreiving your log.")
                End Try

            Case "E"
                NotificationSub("RED", "There was an error retreiving your log.")
        End Select

    End Sub

    Protected Sub BQYes_Click(sender As Object, e As EventArgs) Handles BQYes.Click
        NotifPanel.Visible = False

        Select Case ServerCommand("BNKO" & LogonID.Text & BQBankLBL.Text)
            Case "S"
                Select Case BQBankLBL.Text
                    Case "UMSNB"
                        UMSNBCheck.Checked = True
                    Case "GBANK"
                        GBANKCheck.Checked = True
                    Case "RIVER"
                        RIVERCheck.Checked = True
                End Select
                LoadLog(BQBankLBL.Text)
                BankQuestionPanel.Visible = False
                MainPanel.Visible = False
                BankWindow.Visible = True
            Case "E"
                NotificationSub("RED", "An error occurred and your account could not be created." & vbNewLine & "If the problem persists, contact CHOPO.")
        End Select

    End Sub

    Protected Sub CloseBABTN_Click(sender As Object, e As EventArgs) Handles CloseBABTN.Click
        NotifPanel.Visible = False
        Dim bankbalance As Long
        Select Case BQBankLBL.Text
            Case "UMSNB"
                bankbalance = UMSBLabel.Text
            Case "GBANK"
                bankbalance = GBANKBLabel.Text
            Case "RIVER"
                bankbalance = RIVERBLabel.Text
        End Select
        If Not bankbalance = 0 Then
            NotificationSub("RED", "Please empty the account before closing it.")
            Exit Sub
        End If


        Select Case ServerCommand("BNKC" & LogonID.Text & BQBankLBL.Text)
            Case "S"
                NotificationSub("GREEN", "Account closed successfully")
                MainPanel.Visible = True
                BankWindow.Visible = False
                Select Case BQBankLBL.Text
                    Case "UMSNB"
                        UMSNBCheck.Checked = False
                    Case "GBANK"
                        GBANKCheck.Checked = False
                    Case "RIVER"
                        RIVERCheck.Checked = False
                End Select
            Case "E"
                NotificationSub("RED", "An error occurred and your account could not be closed.")
        End Select

    End Sub

    Protected Sub LogOKButton_Click(sender As Object, e As EventArgs) Handles LogOKButton.Click
        NotifPanel.Visible = False

        MainPanel.Visible = True
        BankWindow.Visible = False

    End Sub
End Class