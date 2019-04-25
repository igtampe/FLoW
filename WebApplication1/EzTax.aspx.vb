Imports System.IO
Imports System.Net.Sockets

Public Class EzTax
    Inherits System.Web.UI.Page


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

    Protected Sub TimeToLogIn(sender As Object, e As EventArgs) Handles Button1.Click
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
        Dim ID As String
        Dim SplitValues() As String
        Dim Incomes() As String

        ID = LogonID.Text
        SplitValues = ServerCommand("INFO" & ID).Split(",")
        UsernameLabel.Text = SplitValues(6)

        Incomes = ServerCommand("EZTINF" & ID).Split(",")

        Dim Income As Long
        Dim EI As Long
        Dim TaxBracket As String
        Dim Tax As Long
        Dim Total As Long


        Income = Incomes(0)
        EI = Incomes(1)

        Total = Income + EI

        Select Case Total
            Case > 1000000
                Tax = Total * 0.05
                TaxBracket = "High (5%)"
                Exit Select

            Case > 100000
                Tax = Total * 0.03
                TaxBracket = "Medium (3%)"
                Exit Select
            Case Else
                Tax = Total * 0.01
                TaxBracket = "Low (1%)"
                Exit Select
        End Select

        IncomeLabel.Text = Income.ToString("N0") & "p"
        EILabel.Text = EI.ToString("N0") & "p"
        TotalLabel.Text = Total.ToString("N0") & "p"
        TaxBracketLabel.Text = TaxBracket
        TaxDueLabel.Text = Tax.ToString("N0") & "p"




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

    Protected Sub SignOutButton_Click(sender As Object, e As EventArgs) Handles SignOutButton.Click

        NotifPanel.Visible = False


        UsernameLabel.Text = "USER"

        NotificationSub("GREEN", "You've been signed out successfully. Adiosito!")

        MainPanel.Visible = False
        LogonPanel.Visible = True

    End Sub

    Protected Sub UpdateIncomeButton_Click(sender As Object, e As EventArgs) Handles UpdateIncomeButton.Click
        UpdateIncomeButton.Visible = False
        SignOutButton.Visible = False
        UploadPanel.Visible = True

    End Sub

    Protected Sub CancelUpload_Click(sender As Object, e As EventArgs) Handles CancelUpload.Click
        UpdateIncomeButton.Visible = True
        SignOutButton.Visible = True
        UploadPanel.Visible = False

    End Sub

    Protected Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim ID As String = LogonID.Text

        If Not FileUpload1.FileName.ToLower.EndsWith(".csv") Then
            NotificationSub("RED", "This doesn't appear to be a CSV file.")
            Exit Sub
        End If

        If File.Exists(ID & ".IncomeRegistry.csv") Then
            File.Delete(ID & ".IncomeRegistry.csv")
        End If

        FileUpload1.SaveAs(Server.MapPath("~") & "\" & ID & ".IncomeRegistry.csv")

        'Open the file
        FileOpen(1, Server.MapPath("~") & "\" & ID & ".IncomeRegistry.csv", OpenMode.Input)


        Dim currentline() As String
        Dim NewIncome As Long = 0

        While Not EOF(1)
            currentline = LineInput(1).Split(",")
            NewIncome = currentline(1) + NewIncome

        End While
        FileClose(1)

        Dim EI As Long
        Dim TaxBracket As String
        Dim Tax As Long
        Dim Total As Long
        EI = EILabel.Text.Replace("p", "").Replace(",", "")
        EILabel0.Text = EILabel.Text



        Total = NewIncome + EI

        Select Case Total
            Case > 1000000
                Tax = Total * 0.05
                TaxBracket = "High (5%)"
                Exit Select

            Case > 100000
                Tax = Total * 0.03
                TaxBracket = "Medium (3%)"
                Exit Select
            Case Else
                Tax = Total * 0.01
                TaxBracket = "Low (1%)"
                Exit Select
        End Select

        UpdatedIncomeLabel.Text = NewIncome.ToString("N0") & "p"
        UpdatedTotalLabel.Text = Total.ToString("N0") & "p"
        UpdatedTaxBracketLabel.Text = TaxBracket
        UpdatedTaxDueLabel.Text = Tax.ToString("N0") & "p"

        UploadPanel.Visible = False
        ConfirmationPanel.Visible = True


    End Sub

    Protected Sub NoConfirmBTN_Click(sender As Object, e As EventArgs) Handles NoConfirmBTN.Click

        UpdateIncomeButton.Visible = True
        SignOutButton.Visible = True
        UploadPanel.Visible = False
        ConfirmationPanel.Visible = False


    End Sub

    Protected Sub YesConfirmBTN_Click(sender As Object, e As EventArgs) Handles YesConfirmBTN.Click

        Select Case ServerCommand("EZTUPD" & ID & UpdatedIncomeLabel.Text.Replace("p", "").Replace(",", ""))
            Case "E"
                NotificationSub("RED", "Could not update income")
                Exit Sub

            Case "S"
                NotificationSub("GREEN", "Updated income succesfully")

                UpdateIncomeButton.Visible = True
                SignOutButton.Visible = True
                UploadPanel.Visible = False
                ConfirmationPanel.Visible = False

                LoadTheCosos()

        End Select




    End Sub
End Class